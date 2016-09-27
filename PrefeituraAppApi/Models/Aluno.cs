using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PrefeituraAppApi.Models
{
    [DataContract]
    public class Aluno
    {
        public Aluno()
        {
            Historico = new Historico(this);
        }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public Historico Historico { get; set; }
    }

    [DataContract]
    public class Historico
    {
        public Historico(Aluno aluno)
        {
            this.Materias = new List<Materia>
            {
                new Materia { Nome = "Geografia" },
                new Materia { Nome = "Matemática" },
                new Materia { Nome = "Português" },
                new Materia { Nome = "Biologia" },
                new Materia { Nome = "Química" },
                new Materia { Nome = "Física" },
            };
        }
        
        [DataMember]
        public IList<Materia> Materias { get; set; }
    }

    [DataContract]
    public class Materia
    {
        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public decimal Nota
        {
            get
            {
                Random random = new Random();
                return random.Next(0, 100);
            }
        }

        [DataMember]
        public string Situacao
        {
            get
            {
                if (this.Nota >= 60)
                    return "Aprovado";

                return "Reprovado";
            }
        }
    }
}
