using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Type;

namespace Common.Nhibernate
{
    /// <summary>
    /// The default behaviour of NHibernate is to map enums as ints, this class will allow us to map
    /// enums to strings.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    public class GenericEnumMapper<TEnum> : EnumStringType { public GenericEnumMapper() : base(typeof(TEnum)) { } }
}
