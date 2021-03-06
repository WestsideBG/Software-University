﻿using System;
using System.Linq;
using System.Reflection;

namespace CodingTracker
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);

            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            foreach (MethodInfo methodInfo in methods)
            {
                if (methodInfo.CustomAttributes.Any(a => a.AttributeType == typeof(SoftUniAttribute)))
                {
                    var attrs = methodInfo.GetCustomAttributes(false);

                    foreach (SoftUniAttribute attr in attrs)
                    {
                        Console.WriteLine($"{methodInfo.Name} is written by {attr.Name}");
                    }
                }
            }
        }
    }
}