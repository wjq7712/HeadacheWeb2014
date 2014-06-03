using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
namespace HeadacheCDSSWeb.Models
{
    public class ObjectMapper
    {
        public static IList<PropertyMapper> GetMapperProperties(Type sourceType, Type targetType)
        {
            var sourceProperties = sourceType.GetProperties();
            var targetProperties = targetType.GetProperties();
            return (from s in sourceProperties
                    from t in targetProperties
                    where s.Name == t.Name && s.CanRead && t.CanWrite && s.PropertyType == t.PropertyType
                    select new PropertyMapper
                    {
                        SourceProperty = s,
                        TargetProperty = t
                    }).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void CopyProperties(object source, object target)
        {
            var sourceType = source.GetType();
            var targetType = target.GetType();
            var mapperProperties = GetMapperProperties(sourceType, targetType);

            for (int index = 0, count = mapperProperties.Count; index < count; index++)
            {
                var property = mapperProperties[index];
                if (property.SourceProperty.Name != "Id" && property.SourceProperty.Name != "PatBasicInfor") // 不能改变原有ID
                {
                    var sourceValue = property.SourceProperty.GetValue(source, null);
                    property.TargetProperty.SetValue(target, sourceValue, null);
                }

            }
        }
        public static void CopyValueProperties(object source, object target)
        {
            var sourceType = source.GetType();
            var targetType = target.GetType();
            var mapperProperties = GetMapperProperties(sourceType, targetType);

            for (int index = 0, count = mapperProperties.Count; index < count; index++)
            {
                var property = mapperProperties[index];
                if (property.SourceProperty.Name != "Id" && property.SourceProperty.Name != "VisitRecord") // 不能改变原有ID
                {
                    var sourceValue = property.SourceProperty.GetValue(source, null);
                    property.TargetProperty.SetValue(target, sourceValue, null);
                }

            }
        }
        public static void CopyFrontProperties(object source, object target)
        {
            var sourceType = source.GetType();
            var targetType = target.GetType();
            var mapperProperties = GetMapperProperties(sourceType, targetType);

            for (int index = 0, count = mapperProperties.Count; index < count; index++)
            {
                var property = mapperProperties[index];
                if (property.SourceProperty.Name != "VisitRecord")
                {
                    if (property.SourceProperty.GetValue(source, null).ToString() != "") // 不能改变原有ID
                    {
                        var sourceValue = property.SourceProperty.GetValue(source, null);
                        property.TargetProperty.SetValue(target, sourceValue, null);
                    }
                    else
                    {
                        property.TargetProperty.SetValue(target, "0", null);
                    }

                }
            }
        }

        public class PropertyMapper
        {
            /// <summary>
            ///         /// </summary>
            public PropertyInfo SourceProperty
            {
                get;
                set;
            }

            public PropertyInfo TargetProperty
            {
                get;
                set;
            }
        }

    }
}