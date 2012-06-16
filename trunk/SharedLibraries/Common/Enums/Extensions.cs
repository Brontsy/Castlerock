using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace Common.Enums
{
    public static class Extensions
    {
        /// <summary>
        /// Gets the description of a enum value
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }
    }
}
