using System;
using System.Runtime.Serialization;

namespace PrefeituraAppApi.Models
{
    [DataContract]
    public class Imovel
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string ValorIPTU
        {
            get
            {
                Random random = new Random(this.ID);
                return random.Next(1, 2000).ToString("C");
            }
        }
    }
}
