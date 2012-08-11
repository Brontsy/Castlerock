using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Portal.Interfaces.Cms;
using System.Xml;

namespace Portal.Cms.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Checks to see if the collection of controls contains the control we are looking for.
        /// This will check through and child controls of the list of controls.
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="controlId"></param>
        /// <returns></returns>
        public static IControl Child(this IList<IControl> controls, Guid controlId)
        {
            foreach (IControl control in controls)
            {
                if (control.Id == controlId)
                {
                    return control;
                }

                if (control.Controls.Count > 0)
                {
                    IControl child = control.Controls.Child(controlId);
                    if (child != null)
                    {
                        return child;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Checks to see if the collection of controls contains the control we are looking for
        /// This will not search through any childs controls etc (use children for that)
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="controlToFind"></param>
        /// <returns></returns>
        public static IControl Sibling(this IList<IControl> controls, IControl controlToFind)
        {
            foreach (IControl control in controls)
            {
                if (control.Id == controlToFind.Id)
                {
                    return control;
                }
            }

            return null;
        }

        public static IControl Parent(this IList<IControl> controls, IControl childControl)
        {
            foreach (IControl control in controls)
            {
                if (control.Id == childControl.Id)
                {
                    return control;
                }

                if (control.Controls.Sibling(childControl) != null)
                {
                    return control;
                }
            }

            return null;
        }

        public static void Update(this IList<IControl> controls, IControl controlToUpdate)
        {
            IControl foundControl = null;
            foreach (IControl control in controls)
            {
                if (control.Id == controlToUpdate.Id)
                {
                    foundControl = control;
                }

                if (foundControl == null && control.Controls.Count > 0)
                {
                    control.Controls.Update(controlToUpdate);
                }
            }

            if (foundControl != null)
            {
                controls[controls.IndexOf(foundControl)] = controlToUpdate;
            }
        }

        public static IControl Add(this IList<IControl> controls, Guid? parentControlId, IControl controlToAdd)
        {
            if (parentControlId.HasValue)
            {
                controls.Child(parentControlId.Value).Controls.Add(controlToAdd);
            }
            else
            {
                controls.Add(controlToAdd);
            }

            return controlToAdd;
        }

        public static void Delete(this IList<IControl> controls, IControl controlToDelete)
        {
            IControl foundControl = null;
            foreach (IControl control in controls)
            {
                if (control.Id == controlToDelete.Id)
                {
                    foundControl = control;
                }

                if (foundControl == null && control.Controls.Count > 0)
                {
                    control.Controls.Update(controlToDelete);
                }
            }

            if (foundControl != null)
            {
                controls.Remove(foundControl);
            }
        }

    }
}
