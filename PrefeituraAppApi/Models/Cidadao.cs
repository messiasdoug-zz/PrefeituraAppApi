using System.Runtime.Serialization;

namespace PrefeituraAppApi.Models
{
    [DataContract]
    public class Cidadao
    {
        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string CPF { get; set; }
    }
}
