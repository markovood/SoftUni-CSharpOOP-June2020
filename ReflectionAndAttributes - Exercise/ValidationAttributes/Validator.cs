using System;
using System.Collections.Generic;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            var properties = objType.GetProperties();

            foreach (var property in properties)
            {
                IEnumerable<MyValidationAttribute> allMyAttributes = property.GetCustomAttributes<MyValidationAttribute>();

                foreach (var attr in allMyAttributes)
                {
                    var propertyValue = property.GetValue(obj);

                    if (!attr.IsValid(propertyValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}