using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JsonManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string json = System.IO.File.ReadAllText(args[0]);
                dynamic array = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                var result = new SortedDictionary<string, Dictionary<string, string>>();
                foreach (KeyValuePair<string, string> item in array){
                    string[] values = item.Key.Split('_');
                    if (result.ContainsKey(values[1])){
                        result[values[1]][values[2]] = item.Value;
                    }
                    else
                    {
                        result.Add(values[1], new Dictionary<string, string>());
                        result[values[1]].Add("door", "0");
                        result[values[1]].Add("item", "0");
                        result[values[1]].Add("light", "0");
                        result[values[1]].Add("unlock", "0");
                        result[values[1]][values[2]] = item.Value;
                    }

                }
                string output = JsonConvert.SerializeObject(result);
                System.IO.File.WriteAllText(args[0], output);

            }
            catch
            {
                Console.WriteLine("Error reading file");
            }
        }
    }
}
