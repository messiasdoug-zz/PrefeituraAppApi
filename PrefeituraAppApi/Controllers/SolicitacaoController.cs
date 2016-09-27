using PrefeituraAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PrefeituraAppApi.Controllers
{
    public class SolicitacaoController : ApiController
    {
        Imovel[] imoveis = new Imovel[]
        {
            new Imovel { ID = 1 },
            new Imovel { ID = 2 },
            new Imovel { ID = 3 }
        };

        IList<Logradouro> logradouros = new List<Logradouro>
        {
            new Logradouro { ID = 1, Nome = "Rua A" },
            new Logradouro { ID = 2, Nome = "Rua B" },
            new Logradouro { ID = 3, Nome = "Rua C" }
        };

        Aluno[] alunos = new Aluno[]
        {
            new Aluno { ID = 1, Nome = "Messias Freitas" },
            new Aluno { ID = 2, Nome = "Douglas Samper" },
            new Aluno { ID = 3, Nome = "Joao da Penha" },
        };
        
        IList<Solicitacao> solicitacoes = new List<Solicitacao>();

        //
        // GET: Solicitacao/CalcularIPTU?codigoCadastral=5

        [HttpGet]
        public IHttpActionResult CalcularIPTU(int codigoCadastral)
        {
            Imovel imovel = null;
            if ((imovel = imoveis.Where(w => w.ID == codigoCadastral).FirstOrDefault()) != null)
            {
                return Ok(imovel.ValorIPTU);
            }

            return NotFound();
        }

        //
        // GET: Solicitacao/ConsultarColetaLixo

        [HttpGet]
        public IHttpActionResult ConsultarColetaLixo(string logradouro)
        {
            Logradouro objLogradouro = BuscaLogradouro(logradouro);
            if (objLogradouro != null)
            {
                return Ok(objLogradouro.Coleta);
            }

            return NotFound();
        }

        //
        // POST: Solicitacao/PodarArvore

        [HttpPost]
        public IHttpActionResult PodarArvore(string logradouro)
        {
            Logradouro objLogradouro = BuscaLogradouro(logradouro);
            if (objLogradouro != null)
            {
                solicitacoes.Add(new Solicitacao(objLogradouro, enTipoSolicitacao.PodaArvore));

                return Ok("Solicitação feita com sucesso.");
            }

            return NotFound();
        }

        //
        // POST: Solicitacao/ConstruirMeioFio

        [HttpPost]
        public IHttpActionResult ConstruirMeioFio(string logradouro)
        {
            Logradouro objLogradouro = BuscaLogradouro(logradouro);
            if (objLogradouro != null)
            {
                solicitacoes.Add(new Solicitacao(objLogradouro, enTipoSolicitacao.ConstrucaoMeioFio));

                return Ok("Solicitação feita com sucesso.");
            }

            return NotFound();
        }

        //
        // POST: Solicitacao/RecolherCarrosAbandonados

        [HttpPost]
        public IHttpActionResult RecolherCarrosAbandonados(string logradouro)
        {
            Logradouro objLogradouro = BuscaLogradouro(logradouro);
            if (objLogradouro != null)
            {
                solicitacoes.Add(new Solicitacao(objLogradouro, enTipoSolicitacao.RecolhimentoCarrosAbandonados));

                return Ok("Solicitação feita com sucesso.");
            }

            return NotFound();
        }

        //
        // POST: Solicitacao/DesobstruirViaPublica

        [HttpPost]
        public IHttpActionResult DesobstruirViaPublica(string logradouro)
        {
            Logradouro objLogradouro = BuscaLogradouro(logradouro);
            if (objLogradouro != null)
            {
                solicitacoes.Add(new Solicitacao(objLogradouro, enTipoSolicitacao.DesobstrucaoViaPublica));

                return Ok("Solicitação feita com sucesso.");
            }

            return NotFound();
        }

        //
        // POST: Solicitacao/DesobstruirCorrego

        [HttpPost]
        public IHttpActionResult DesobstruirCorrego(string logradouro)
        {
            Logradouro objLogradouro = BuscaLogradouro(logradouro);
            if (objLogradouro != null)
            {
                solicitacoes.Add(new Solicitacao(objLogradouro, enTipoSolicitacao.DesobstrucaoCorrego));

                return Ok("Solicitação feita com sucesso.");
            }

            return NotFound();
        }

        //
        // POST: Solicitacao/ColetarAnimalMorto

        [HttpPost]
        public IHttpActionResult ColetarAnimalMorto(string logradouro)
        {
            Logradouro objLogradouro = BuscaLogradouro(logradouro);
            if (objLogradouro != null)
            {
                solicitacoes.Add(new Solicitacao(objLogradouro, enTipoSolicitacao.ColetaAnimalMorto));

                return Ok("Solicitação feita com sucesso.");
            }

            return NotFound();
        }

        //
        // POST: Solicitacao/LimparBocaLobo

        [HttpPost]
        public IHttpActionResult LimparBocaLobo(string logradouro)
        {
            Logradouro objLogradouro = BuscaLogradouro(logradouro);
            if (objLogradouro != null)
            {
                solicitacoes.Add(new Solicitacao(objLogradouro, enTipoSolicitacao.ColetaAnimalMorto));

                return Ok("Solicitação feita com sucesso.");
            }

            return NotFound();
        }

        //
        // POST: Solicitacao/HistoricoAlunoRedePublica?codigoAluno=5

        [HttpGet]
        public IHttpActionResult HistoricoAlunoRedePublica(int codigoAluno)
        {
            Aluno aluno = null;
            if ((aluno = alunos.Where(w => w.ID == codigoAluno).FirstOrDefault()) != null)
            {
                return Json(aluno);
            }

            return NotFound();
        }

        //
        // POST: Solicitacao/PedidoAdocaoCaes
        
        [HttpPost]
        public IHttpActionResult PedidoAdocaoCaes(Cidadao cidadao, string logradouro)
        {
            var objLogradouro = BuscaLogradouro(logradouro);
            if (objLogradouro == null)
            {
                objLogradouro = new Logradouro { ID = (logradouros.Count + 1), Nome = logradouro };
                logradouros.Add(objLogradouro);
            }

            solicitacoes.Add(new Solicitacao(objLogradouro, enTipoSolicitacao.AdocaoCaes, cidadao));

            return Ok("Solicitação feita com sucesso.");
        }

        //
        // POST: Solicitacao/PedidoAdocaoGatos

        [HttpPost]
        public IHttpActionResult PedidoAdocaoGatos(Cidadao cidadao, string logradouro)
        {
            var objLogradouro = BuscaLogradouro(logradouro);
            if (objLogradouro == null)
            {
                objLogradouro = new Logradouro { ID = (logradouros.Count + 1), Nome = logradouro };
                logradouros.Add(objLogradouro);
            }

            solicitacoes.Add(new Solicitacao(objLogradouro, enTipoSolicitacao.AdocaoGatos, cidadao));

            return Ok("Solicitação feita com sucesso.");
        }

        /// <summary>
        /// Busca logradouro.
        /// </summary>
        /// <param name="nomeLogradouro">Nome do logradouro.</param>
        /// <returns>Logradouro.</returns>
        private Logradouro BuscaLogradouro(string nomeLogradouro)
        {
            return logradouros.Where(w => w.Nome == nomeLogradouro).FirstOrDefault();
        }
    }
}