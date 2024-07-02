using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiKatalog.Model
{
    public class ElementSistemaConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(ElementSistema));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            if (jo["Grupa"] != null && jo["Numere"] != null)
            {
                return jo.ToObject<Izvodjac>(serializer);
            }
            else if (jo["DatumIzbacivanja"] != null)
            {
                return jo.ToObject<MuzickaNumera>(serializer);
            }
            else if (jo["DatumIzdavanja"] != null )
            {
                return jo.ToObject<Album>(serializer);
            }
            else if (jo["DatumDesavanja"] != null)
            {
                return jo.ToObject<Koncert>(serializer);
            }
            else if (jo["Ivodjaci"] != null && jo["Numere"]!=null)
            {
                return jo.ToObject<MuzickaGrupa>(serializer);
            }
            throw new Exception("Unknown type of ElementSistema");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);
            t.WriteTo(writer);
        }
    }
}
