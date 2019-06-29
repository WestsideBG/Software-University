using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldsNames)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {className}");

        Type type = Type.GetType(className);

        FieldInfo[] fields = type.GetFields((BindingFlags)62);

        var instance = Activator.CreateInstance(type);

        foreach (var fieldInfo in fields.Where(f => fieldsNames.Contains(f.Name)))
        {
            sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(instance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type type = Type.GetType(className);

        var instance = Activator.CreateInstance(type);

        var publicFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
        var privateGetters = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(x => x.Name.StartsWith("get"));
        var privateSetters = type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .Where(x => x.Name.StartsWith("set"));

        foreach (FieldInfo fieldInfo in publicFields)
        {
            sb.AppendLine($"{fieldInfo.Name} must be private!");
        }

        foreach (var privateGetter in privateGetters)
        {
            sb.AppendLine($"{privateGetter.Name} have to be public!");

        }

        foreach (var privateSetter in privateSetters)
        {
            sb.AppendLine($"{privateSetter.Name} have to be private!");

        }

        return sb.ToString().Trim();
    }

}