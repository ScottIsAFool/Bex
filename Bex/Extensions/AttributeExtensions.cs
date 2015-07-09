﻿using System.Linq;
using System.Reflection;
using Bex.Attributes;

namespace Bex.Extensions
{
    public static class AttributeExtensions
    {
        internal static string GetDescription(this object en)
        {
            var type = en.GetType();
            var memInfo = type.GetTypeInfo().DeclaredMembers;

            var attrs = memInfo.FirstOrDefault(x => x.Name == en.ToString());
            if (attrs != null)
            {
                var attribute = attrs.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(Description));
                if (attribute != null)
                {
                    return attribute.ConstructorArguments[0].Value.ToString();
                }
            }

            return en.ToString();
        }
    }
}