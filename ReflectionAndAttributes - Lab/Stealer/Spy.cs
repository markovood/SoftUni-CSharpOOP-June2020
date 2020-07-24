using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] fields)
        {
            Type type = Type.GetType(classToInvestigate);
            if (type == null)
            {
                throw new ArgumentNullException("type", "Type was not found!");
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {classToInvestigate}");
            foreach (var field in fields)
            {
                FieldInfo fieldInfo = type.GetField(field, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                var instance = Activator.CreateInstance(type);

                sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(instance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type type = Type.GetType(className);
            if (type == null)
            {
                throw new ArgumentException("className was not found");
            }

            var fields = type.GetFields(BindingFlags.Instance |
                                        BindingFlags.Public |
                                        BindingFlags.Static);
            foreach (var field in fields)
            {
                if (!field.IsPrivate)
                {
                    sb.AppendLine($"{field.Name} must be private!");
                }
            }

            var allMethods = type.GetMethods(BindingFlags.Public |
                                            BindingFlags.NonPublic |
                                            BindingFlags.Instance |
                                            BindingFlags.Static);
            var getters = allMethods.Where(m => m.Name.StartsWith("get_"));
            foreach (var getter in getters)
            {
                if (!getter.IsPublic)
                {
                    sb.AppendLine($"{getter.Name} have to be public!");
                }
            }

            var setters = allMethods.Where(m => m.Name.StartsWith("set_"));
            foreach (var setter in setters)
            {
                if (!setter.IsPrivate)
                {
                    sb.AppendLine($"{setter.Name} have to be private!");
                }
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type type = Type.GetType(className);
            if (type == null)
            {
                throw new ArgumentException("className was not found");
            }

            var allPrivateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");
            foreach (var method in allPrivateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type type = Type.GetType(className);
            if (type == null)
            {
                throw new ArgumentException("className was not found");
            }

            var allMethods = type.GetMethods(BindingFlags.Public |
                                                BindingFlags.NonPublic |
                                                BindingFlags.Instance |
                                                BindingFlags.Static);
            var getters = allMethods.Where(m => m.Name.StartsWith("get_"));
            foreach (var getter in getters)
            {
                sb.AppendLine($"{getter.Name} will return {getter.ReturnType}");
            }

            var setters = allMethods.Where(m => m.Name.StartsWith("set_"));
            foreach (var setter in setters)
            {
                sb.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }
    }
}