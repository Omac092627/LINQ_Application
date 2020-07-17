using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using LINQ_IN_MANHATTAN.Classes;
using System.IO;

namespace LINQ_IN_MANHATTAN.Classes
{
    public  class Neighborhood
    {
        //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Geometry
        {
            [JsonProperty("type")]
            public string type;
            [JsonProperty("coordinates")]
            public List<double> coordinates;

        }

        public class Properties
        {
            [JsonProperty("zip")]
            public string zip;
            [JsonProperty("city")]
            public string city;
            [JsonProperty("state")]
            public string state;
            [JsonProperty("address")]
            public string address;
            [JsonProperty("borough")]
            public string borough;
            [JsonProperty("neighborhood")]
            public string neighborhood;
            [JsonProperty("county")]
            public string county;

        }




        public class Feature
        {
            [JsonProperty("type")]
            public string type;
            [JsonProperty("geometry")]
            public Geometry geometry;
            [JsonProperty("properties")]
            public Properties properties;

        }

        public class Root
        {
            [JsonProperty("features")]
            public List<Feature> features;
            [JsonProperty("type")]
            public string type;


        }
        public void JsonSerialize(object data, string filePath)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            StreamWriter sw = new StreamWriter(filePath);
            JsonWriter jsonWriter = new JsonTextWriter(sw);

            jsonSerializer.Serialize(jsonWriter, data);

            jsonWriter.Close();
            sw.Close();
        }

        public object JsonDeserializer(Type dataType, string filePath)
        {
            JObject obj = null;
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                JsonReader jsonReader = new JsonTextReader(sr);
                obj = jsonSerializer.Deserialize(jsonReader) as JObject;
                jsonReader.Close();
                sr.Close();

            }
            return obj.ToObject(dataType);

        }

    }


    }
