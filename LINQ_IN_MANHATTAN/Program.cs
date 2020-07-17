using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using LINQ_IN_MANHATTAN.Classes;
using System.IO;

namespace LINQ_IN_MANHATTAN
{
    class Program
    {

        static void Main(string[] args)
        {
            Neighborhood lilNeigh = new Neighborhood();
/*            lilNeigh.JsonSerialize(typeof(Neighborhood), "../../data.json");
*/
            string strResult = JsonConvert.SerializeObject(lilNeigh);
            strResult = File.ReadAllText(@"../../data.json");
            Neighborhood result = JsonConvert.DeserializeObject<Neighborhood>(strResult);
            Console.WriteLine(result.ToString());

        }


        }



 


    }




