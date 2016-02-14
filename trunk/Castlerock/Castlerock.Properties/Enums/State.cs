using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace Castlerock.Properties.Enums
{
    public enum State
    {
        [Description("ACT")]
        ACT,

        [Description("New South Wales")]
        NSW,

        [Description("Northen Territory")]
        NT,

        [Description("Queensland")]
        QLD,

        [Description("South Australia")]
        SA,

        [Description("Tasmania")]
        TAS,

        [Description("Victoria")]
        VIC,

        [Description("Western Australia")]
        WA
    }


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
