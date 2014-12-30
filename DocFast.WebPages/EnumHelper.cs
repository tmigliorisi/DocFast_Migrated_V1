using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace SeleNUnit.WebObjects
{


   
        public static class EnumHelper
        {
            public static string GetEnumDescription(Enum value)
            {
                var fieldName = value.ToString();
                var fieldInfo = value.GetType().GetField(fieldName);
                var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                return attributes.Length > 0 ? attributes[0].Description : fieldName;
            }
        }
    
}
