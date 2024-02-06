using System.Reflection;

ReflectionDemonstrator rd = new ReflectionDemonstrator();

//Type + TypeInfo
Type type = typeof(ReflectionDemonstrator);
TypeInfo ti = type.GetTypeInfo();
Console.WriteLine("IsValueType:" + type.IsValueType + "\nIsArray:" + type.IsArray + "\nIsClass:" + type.IsClass + "\n");
Console.WriteLine("FullName:"+ti.FullName+"\nName:"+ti.Name+"\nNamespace:"+ti.Namespace+"\nModule"+ti.Module+"\n");

//MemberInfo
MemberInfo [] mi=type.GetMembers();
Console.WriteLine("\nLength:" + mi.Length + "\nLongLength:" + mi.LongLength + "\n");
foreach (MemberInfo m in mi) Console.WriteLine(m.Name);

//FieldInfo
FieldInfo[] fi = type.GetFields();
Console.WriteLine("\nLength:" + fi.Length + "\nLongLength:" + fi.LongLength + "\n");
foreach (FieldInfo f in fi) Console.WriteLine(f.Name);

//MethodInfo
MethodInfo[] mei=type.GetMethods();
Console.WriteLine("\nLength:" + mei.Length + "\nLongLength:" + mei.LongLength + "\n");
foreach (MethodInfo m in mei) Console.WriteLine(m.Name);

//Calling metod with reflection
MethodInfo method = type.GetMethod("Hello");
method.Invoke(rd, null);

class ReflectionDemonstrator
{
    public int intField;
    private float floatField;
    protected string stringField;
    internal double doubleField;
    public bool boolField;

    public void Hello() { Console.WriteLine("HELLO WORLD!!!"); }
    public float Add() { return (intField + floatField); }
    public string GetStringField() { return stringField; }
}
