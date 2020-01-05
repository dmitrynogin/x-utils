﻿using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System
{
    public static class ServiceLocator
    {
        public static T GetService<T>(this IServiceProvider provider, string uri) =>
            provider.GetService<T>(new Uri(uri));

        public static object GetService(this IServiceProvider provider, string uri) =>
            provider.GetService(new Uri(uri));

        public static T GetService<T>(this IServiceProvider provider, Uri uri) =>
            (T)provider.GetService(uri);

        public static object GetService(this IServiceProvider provider, Uri uri)
        {
            if (uri.Scheme != "ioc")
                throw new NotSupportedException("Schema not supported.");

            var factory = (Delegate)provider.GetService(GetFactory(uri));
            return factory.DynamicInvoke(GetArguments(uri));
        }

        static Type GetFactory(Uri uri)
        {
            var types = GetParameters(uri).Select(p => p.ParameterType).Append(GetReturnType(uri));
            Func<Type[], Type> getType = Expression.GetFuncType;
            return getType(types.ToArray());
        }

        static object[] GetArguments(Uri uri)
        {
            var arguments = uri.Query
                .TrimStart('?')
                .Split('&')
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