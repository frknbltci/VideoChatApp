using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sipay.Helpers
{
   public class JsonBuilder
    {
        public static string SerializeToJsonString<T>(T request)
        {
            return JsonConvert.SerializeObject(request, new JsonSerializerSettings()
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new ContractResolverWithOnlyPrivates()
            });
        }

        public static StringContent ToJsonString<T>(T request)
        {
            var temp = SerializeToJsonString<T>(request);

            return new StringContent(temp, Encoding.UTF8, "application/json");
        }

        public class ContractResolverWithOnlyPrivates : DefaultContractResolver
        {
            protected override Newtonsoft.Json.Serialization.JsonProperty CreateProperty(System.Reflection.MemberInfo member, MemberSerialization memberSerialization)
            {
                var prop = base.CreateProperty(member, memberSerialization);

                var property = member as System.Reflection.PropertyInfo;
                if (property != null)
                {
                    var hasPrivateSetter = property.GetSetMethod() != null;

                    prop.ShouldSerialize = instance =>
                    {

                        return !hasPrivateSetter;
                    };

                }

                return prop;
            }
        }
    }

}

