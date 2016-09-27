using System.Runtime.Serialization;

namespace PrefeituraAppApi.Models
{
    [DataContract]
    public class Solicitacao
    {
        public Solicitacao(Logradouro logradouro, enTipoSolicitacao tipoSolicitacao)
        {
            Logradouro = logradouro;
            TipoSolicitacao = tipoSolicitacao;
        }

        public Solicitacao(Logradouro logradouro, enTipoSolicitacao tipoSolicitacao, Cidadao cidadao)
        {
            Logradouro = logradouro;
            TipoSolicitacao = tipoSolicitacao;
            Cidadao = cidadao;
        }

        [DataMember]
        public Logradouro Logradouro { get; set; }

        [DataMember]
        public Cidadao Cidadao { get; set; }

        [DataMember]
        public enTipoSolicitacao TipoSolicitacao { get; set; }

        [DataMember]
        public bool Concluido { get; set; }
    }

    public enum enTipoSolicitacao : int
    {
        PodaArvore = 1,
        ConstrucaoMeioFio = 2,
        RecolhimentoCarrosAbandonados = 3,
        DesobstrucaoViaPublica = 4,
        DesobstrucaoCorrego = 5,
        ColetaAnimalMorto = 6,
        LimpezaBocaLobo = 7,
        AdocaoCaes = 8,
        AdocaoGatos = 9,
    }
}
