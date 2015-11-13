using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class CSVParser
    {

        internal string Parse(string filePath)
        {

            using (CsvReader reader = new CsvReader(filePath))
            {
                var csv = new List<object>(); // or, List<YourClass>
                int count = 0;
                string[] props = null;
                foreach (string[] values in reader.RowEnumerator)
                {
                    if (count == 0)
                    {
                        props = values;
                    }
                    else
                    {

                        Dictionary<string, object> obj = new Dictionary<string, object>();
                        var properties = values;
                        for (int i = 0; i < properties.Length; i++)
                        {

                            obj[props[i]] = properties[i];


                        }

                        csv.Add(obj);

                    }
                    count++;
                }


                string json = JsonConvert.SerializeObject(csv);
                return json;
            }
        }
    }
}
