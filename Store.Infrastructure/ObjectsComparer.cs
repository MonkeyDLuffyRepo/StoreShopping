using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Infrastructure
{
    public class ObjectsComparer
    {
        public static List<string> GetChangedFields(object origin, object object2)
        {
            var ChangedFields = new List<string>();
            var OriginType = origin.GetType();
            var Object2Type = object2.GetType();
            foreach (var originProperty in OriginType.GetProperties())
            {
                var object2Property = Object2Type.GetProperty(originProperty.Name);
                if (object2Property != null && originProperty != null)
                {
                    //if (originProperty.PropertyType == typeof(string))
                    if (originProperty.PropertyType != typeof(object))
                    {
                        object originValue = originProperty.GetValue(origin, null);
                        object dataValue = object2Property.GetValue(object2, null);

                        if ((dataValue != null && (originValue is null || !originValue.Equals(dataValue))))
                            ChangedFields.Add(originProperty.Name);
                    }


                }
            }
            return ChangedFields;
        }

    }
}
