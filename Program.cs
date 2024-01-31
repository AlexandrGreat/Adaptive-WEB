using System.Reflection;
using System.Collections.Specialized;
using System.Collections;
using System.Globalization;
using System.Xml.Serialization;
using System.Text.Json;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Timers;

//LIB 1 Base class library (System.Collections.Generic)
Person p =new Person();
p.Age = 20;
List<Person> list=new List<Person>();
list.Add(p);
Console.WriteLine(list[0].ToString());

//LIB 2 Runtime Infrastructure Library (System.Reflection)
Type personType = typeof(Person);
PropertyInfo personName = personType.GetProperty("Name");
personName.SetValue(p,"Hello");
Console.WriteLine(list[0].ToString());

//LIB 3 Network Library (System.Collections.Specialized)
StringDictionary sd = new StringDictionary();
sd.Add("Hello", "Privit");
sd.Add("World", "Svit");
sd.Add("Example", "Priklad");
foreach (DictionaryEntry de in sd)
    Console.WriteLine(de.Key+" "+de.Value);

//LIB 4 Reflection Library (System.Globalization)
CultureInfo ci = new CultureInfo("en-EN",false);
Console.WriteLine(ci.CompareInfo);
Console.WriteLine(ci.DisplayName);
Console.WriteLine(ci.EnglishName);
Console.WriteLine(ci.IsNeutralCulture);
Console.WriteLine(ci.IsReadOnly);
Console.WriteLine(ci.LCID);
Console.WriteLine(ci.Name);
Console.WriteLine(ci.NativeName);

//LIB 5 XML Library (System.Xml)
Person1 p1 = new Person1();
p1.Age = 20;
p1.Name = "HUMAN";
TextWriter writer = new StreamWriter("LR2output.txt");
XmlSerializer serializer = new XmlSerializer(typeof(Person1));
serializer.Serialize(writer,p1);
writer.Close();

//API 1 System.Text.Json
string jsonString = JsonSerializer.Serialize(p1);
Console.WriteLine(jsonString);

//API 2 System.Collections.Concurrent
int NUMITEMS=64;
int initialCapacity = 101;
int numProcs = Environment.ProcessorCount;
int concurrencyLvl = numProcs * 2;
ConcurrentDictionary<int,int>cd=new ConcurrentDictionary<int,int>(concurrencyLvl,initialCapacity);
for (int i = 0; i < NUMITEMS; i++)
    cd[i] = i * i;
Console.WriteLine(cd[23] + " " + 23 * 23);

//API 3 System.Collections.ObjectModel
IDictionary<string,string> d=new Dictionary<string,string>();
d.Add("Hello", "Privit");
d.Add("World", "Svit");
d.Add("Example", "Priklad");
ReadOnlyDictionary<string, string> rod = d.AsReadOnly();
Console.WriteLine(rod.Last());

//API 4 System.ComponentModel
bool bVal = true;
string str = "false";
Console.WriteLine(TypeDescriptor.GetConverter(bVal).ConvertTo(bVal,typeof(string)));
Console.WriteLine(TypeDescriptor.GetConverter(bVal).ConvertFrom(str));

//API 5 System.Timers
System.Timers.Timer aTimer=new System.Timers.Timer(2000);
aTimer.Elapsed += OnTimerEvent;
aTimer.AutoReset = true;
aTimer.Enabled = true;
Console.WriteLine("Startting timer with  2sec interval\n"+DateTime.Now);
Console.ReadLine();
aTimer.Stop();
aTimer.Dispose();
void OnTimerEvent(Object src,ElapsedEventArgs e)
{ 
    Console.WriteLine(e.SignalTime);
}


class Person
{
    public static string Name { get; set; }
    public int Age { get; set; }

    public string ToString() { return (Name + " " + Age); }
}

public class Person1
{
    public string Name { get; set; }
    public int Age { get; set; }

    public string ToString() { return (Name + " " + Age); }
}
