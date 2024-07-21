using System;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));

            Type type = obj.GetType();
            PropertyInfo[] properties = type
                .GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(MyValidationAttribute), false).Any())
                .ToArray();

            foreach (PropertyInfo property in properties)
                foreach (MyValidationAttribute validationAttribute in property.GetCustomAttributes<MyValidationAttribute>())
                    if (!validationAttribute.IsValid(property.GetValue(obj))) return false;

            return true;
        }
    }
}
