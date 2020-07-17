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
        public static Root JsonData { get; set; }

        static void Main(string[] args)
        {
            GetJson();
            var GetNeighborhoods = from place in JsonData.features
                                   select place.properties.neighborhood;

            for(int i = 0; i < GetNeighborhoods.Count(); i++)
            {
                Console.WriteLine($"{i + 1}.{GetNeighborhoods.ElementAt(i)}");
            }


            var GetNeighborhoodsWithName = from place in JsonData.features
                                              where place.properties.neighborhood != ""
                                              select place.properties.neighborhood;

            for(int i = 0; i < GetNeighborhoodsWithName.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {GetNeighborhoodsWithName.ElementAt(i)}");
            }
        }

        public static void GetJson()
        {
            string rawData = File.ReadAllText("../../../Assets/data.json");
            JsonData = JsonConvert.DeserializeObject<Root>(rawData);
            int count = 0;
            foreach (var item in JsonData.features)
            {
                count++;
                Console.WriteLine(item.properties.neighborhood + count);
            }
        }

        }

    }






