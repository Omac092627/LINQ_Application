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
        public static Root JsonData {get; set;}

    static void Main(string[] args)
    {
            GetJson();
            var GetNeighborhoods = from place in JsonData.features
            select place.properties.neighborhood;
    }

        public static void GetJson()
        {
            string rawData = File.ReadAllText("../../../Assets/data.json");
            JsonData = JsonConvert.DeserializeObject<Root>(rawData);

            foreach (var item in JsonData.features)
            {
                Console.WriteLine(item.properties.neighborhood);
            }
        }

}



 


    }




