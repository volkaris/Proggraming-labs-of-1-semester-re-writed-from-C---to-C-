
using ConsoleApp1;
//using TestProject2;

string? value=null;
string? value2=null;
ArgParser argParser=new ArgParser("dadasdasd");
argParser.Parse(argParser.SplitString("app --param1=value1 --param2=value2"));
argParser.AddStringArgument("param1").StoreValue(ref value);
argParser.AddStringArgument("param2").StoreValue(ref value2);
Console.WriteLine(value);
Console.WriteLine(value2);
int x = 10;


