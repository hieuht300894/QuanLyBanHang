using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Method
{
    public static class ObjectCopier
    {
        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(
                source,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public static List<T> Clone<T>(this List<T> source)
        {
            var serialized = JsonConvert.SerializeObject(
                source,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return JsonConvert.DeserializeObject<List<T>>(serialized);
        }

        public static string SerializeJSON<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(
                source,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return serialized;
        }

        public static T DeserializeJSON<T>(this string source) where T : new()
        {
            try { return JsonConvert.DeserializeObject<T>(source); }
            catch { return new T(); }
        }
    }
}
