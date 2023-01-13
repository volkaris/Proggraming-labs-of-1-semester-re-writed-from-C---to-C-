using System.Linq.Expressions;

namespace ConsoleApp1;

public class ArgParser
{
    private string str;
    private string currentParametr;
    private  List<KeyValuePair<string, string>> _values;
    public  ArgParser(string str)  {
        this.str = str;
        this._values=new List<KeyValuePair<string, string>>();
    }
    public ArgParser Default(string value)
    {
        this._values.Add(new KeyValuePair<string, string>(this.currentParametr, value));
       // this._values[^1] = new KeyValuePair<string, string>(this._values[^1].Key,value);
        return this;
    }
    public ArgParser AddStringArgument(string valueName)
    {
        currentParametr = valueName;
        return this;
    }
    public ArgParser AddIntArgument(string valueName)
    {
        {
            AddStringArgument(valueName);
            return this;
        }
    }


    public string GetStringValue(string valueName) {
        foreach(var entities in _values  ) {
            if (entities.Key==valueName) {
                return entities.Value;
            }
        }
        throw new ArgumentException("No such parameters was provided",valueName);
    }
    public Int64 GetIntValue(string valueName)
    {
        foreach (var entities in _values)
        {
            if (entities.Key==valueName)
            {
                return Convert.ToInt64(entities.Value);
            }
        }
        throw new ArgumentException($"No such parameters was provided:{valueName}");
    }


    public void Parse(string[] splittedArray) {
        for (var i = 1; i < splittedArray.Length; i++)
        {
            var position = splittedArray[i].IndexOf("=", StringComparison.Ordinal);
            var key = splittedArray[i].Substring(0, position);
            if (key.Contains("--")) {
                key = key.Replace("--", "");
            }
            else if (key.Contains("-")) {
                key = key.Replace("-", "");
            }

            string value = splittedArray[i].Substring(position + 1);
          //  if (_values.Count>0) {
                //for (int index = 0; index < _values.Count; index++) {
                  //  if (_values[index].Key == key) {
                      //  _values[index] = new KeyValuePair<string, string>(key, value);
                   // }
                //}
           // } else {
                _values.Add(new KeyValuePair<string, string>(key,value));
        }
    }
    
    public string[] SplitString(string str1) {
        string[] arr = str1.Split(" ");
        return arr;
    }

    public void StoreValue(ref string whereToStore)
    {
        whereToStore = GetStringValue(currentParametr);
    }
}