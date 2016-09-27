using System.Runtime.Serialization;

namespace PrefeituraAppApi.Models
{
    [DataContract]
    public class Logradouro
    {
        public Logradouro()
        {

        }

        public Logradouro(bool jaPassou)
        {
            this.JaPassou = jaPassou;
        }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Coleta
        {
            get
            {
                if (JaPassou)
                    return "Sim";

                return "Não";
            }
        }

        [DataMember]
        private bool JaPassou { get; set; }
    }
}
