using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DomainResource.Attribute;
using Nelibur.ObjectMapper;

namespace DomainResource
{
    /// <summary>
    /// Auto bind based on the Mapper attribute.
    /// Dto to entity and vice versa.
    ///
    /// this is like a auto binder for tiny mapper.
    /// </summary>
    public static class MapHelper
    {
        public static void Map()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();

            var mapperAttrType = typeof(MapperAttribute);
            var listType = typeof(List<>);

            var toBeMapped = currentAssembly.GetTypes().Where(x => x.GetCustomAttributes(mapperAttrType).Any());

            var methodInfo = typeof(TinyMapper).GetMethods()
                .First(m => m.Name == "Bind" && m.GetParameters().Length == 0);

            foreach (var type in toBeMapped)
            {
                // cast to desired attribute in this case Mapper.
                var attribute = type.GetCustomAttributes(mapperAttrType).FirstOrDefault() as MapperAttribute;

                // make a genric nethod to bind from source to target.
                var dtoToEntity = methodInfo.MakeGenericMethod(type, attribute.EntityType);

                // invoking this method.
                dtoToEntity.Invoke(null, null);

                // make a genric nethod to bind from target to source.
                var entityToDto = methodInfo.MakeGenericMethod(attribute.EntityType, type);

                entityToDto.Invoke(null, null);

                // list binding

                var dtoList = listType.MakeGenericType(type);
                var entityList = listType.MakeGenericType(attribute.EntityType);

                var dtoListToEntityList = methodInfo.MakeGenericMethod(dtoList, entityList);

                dtoListToEntityList.Invoke(null, null);

                var entityListToDtoList = methodInfo.MakeGenericMethod(entityList, dtoList);

                entityListToDtoList.Invoke(null, null);
            }
        }
    }
}
