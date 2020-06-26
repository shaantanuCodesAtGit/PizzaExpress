using System;
using System.Collections.Generic;
using System.Text;

namespace DomainResource.Attribute
{
    /// <summary>
    /// Mapper attribute 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MapperAttribute : System.Attribute
    {
        public readonly Type EntityType;

        public MapperAttribute(Type type)
        {
            EntityType = type;
        }
    }
}
