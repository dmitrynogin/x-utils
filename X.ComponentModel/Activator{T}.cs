using System.Linq;
using System.Reflection;

namespace System
{
    public static class Activator<T>
    {
        public static T CreateInstance(string uri) =>
            CreateInstance(new Uri(uri));

        public static T CreateInstance(Uri uri) =>
            uri.Scheme != "clr" ? throw new NotSupportedException() :
            !typeof(T).IsAssignableFrom(GetReturnType(uri)) ? throw new InvalidCastException() :
            (T)Activator.CreateInstance(GetReturnType(uri), GetArguments(uri));

        static object[] GetArguments(Uri uri)
        {
            var arguments = uri.Query
                .TrimStart('?')
                .Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Split('='))
                .ToDictionary(nv => nv[0], nv => Uri.UnescapeDataString(nv[1]));

            return GetParameters(uri)
                .Select(p => Convert.ChangeType(arguments[p.Name], p.ParameterType))
                .ToArray();
        }

        static ParameterInfo[] GetParameters(Uri uri) =>
            GetReturnType(uri)
                .GetConstructors()
                .First()
                .GetParameters();

        static Type GetReturnType(Uri uri) =>
            Type.GetType($"{uri.Segments[1]}, {uri.Host}");
    }
}
