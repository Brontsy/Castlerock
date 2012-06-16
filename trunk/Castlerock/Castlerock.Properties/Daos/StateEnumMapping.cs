using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Type;
using Castlerock.Properties.Enums;

namespace Castlerock.Properties.Daos
{
    public class StateEnumMapping : EnumCharType<State>
    {
        public StateEnumMapping()
            : base()
        {
        }
    }
}
