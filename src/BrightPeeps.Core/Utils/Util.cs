using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BrightPeeps.Core.Utils
{
    public static class Util
    {
        public static string GetPropertyNames<T>(T parameters)
        {
            var properties = new List<PropertyInfo>(typeof(T).GetProperties());

            var buffer = new StringBuilder();

            properties.ForEach(property => buffer.Append($"@{property.Name} "));

            return buffer.ToString();
        }
    }
}