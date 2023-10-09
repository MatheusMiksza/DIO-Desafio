using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Solution.Models
{
    public class ConsultaCNPJ
    {

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class AtividadePrincipal
        {
            [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
            public string Code;

            [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
            public string Text;
        }

        public class AtividadesSecundaria
        {
            [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
            public string Code;

            [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
            public string Text;
        }

        public class Billing
        {
            [JsonProperty("free", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Free;

            [JsonProperty("database", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Database;
        }

        public class Extra
        {
        }

        public class Root
        {
            [JsonProperty("abertura", NullValueHandling = NullValueHandling.Ignore)]
            public string Abertura;

            [JsonProperty("situacao", NullValueHandling = NullValueHandling.Ignore)]
            public string Situacao;

            [JsonProperty("tipo", NullValueHandling = NullValueHandling.Ignore)]
            public string Tipo;

            [JsonProperty("nome", NullValueHandling = NullValueHandling.Ignore)]
            public string Nome;

            [JsonProperty("porte", NullValueHandling = NullValueHandling.Ignore)]
            public string Porte;

            [JsonProperty("natureza_juridica", NullValueHandling = NullValueHandling.Ignore)]
            public string NaturezaJuridica;

            [JsonProperty("atividade_principal", NullValueHandling = NullValueHandling.Ignore)]
            public List<AtividadePrincipal> AtividadePrincipal;

            [JsonProperty("logradouro", NullValueHandling = NullValueHandling.Ignore)]
            public string Logradouro;

            [JsonProperty("numero", NullValueHandling = NullValueHandling.Ignore)]
            public string Numero;

            [JsonProperty("municipio", NullValueHandling = NullValueHandling.Ignore)]
            public string Municipio;

            [JsonProperty("uf", NullValueHandling = NullValueHandling.Ignore)]
            public string Uf;

            [JsonProperty("data_situacao", NullValueHandling = NullValueHandling.Ignore)]
            public string DataSituacao;

            [JsonProperty("cnpj", NullValueHandling = NullValueHandling.Ignore)]
            public string Cnpj;

            [JsonProperty("ultima_atualizacao", NullValueHandling = NullValueHandling.Ignore)]
            public DateTime? UltimaAtualizacao;

            [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
            public string Status;

            [JsonProperty("fantasia", NullValueHandling = NullValueHandling.Ignore)]
            public string Fantasia;

            [JsonProperty("complemento", NullValueHandling = NullValueHandling.Ignore)]
            public string Complemento;

            [JsonProperty("cep", NullValueHandling = NullValueHandling.Ignore)]
            public string Cep;

            [JsonProperty("bairro", NullValueHandling = NullValueHandling.Ignore)]
            public string Bairro;

            [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
            public string Email;

            [JsonProperty("telefone", NullValueHandling = NullValueHandling.Ignore)]
            public string Telefone;

            [JsonProperty("efr", NullValueHandling = NullValueHandling.Ignore)]
            public string Efr;

            [JsonProperty("motivo_situacao", NullValueHandling = NullValueHandling.Ignore)]
            public string MotivoSituacao;

            [JsonProperty("situacao_especial", NullValueHandling = NullValueHandling.Ignore)]
            public string SituacaoEspecial;

            [JsonProperty("data_situacao_especial", NullValueHandling = NullValueHandling.Ignore)]
            public string DataSituacaoEspecial;

            [JsonProperty("atividades_secundarias", NullValueHandling = NullValueHandling.Ignore)]
            public List<AtividadesSecundaria> AtividadesSecundarias;

            [JsonProperty("capital_social", NullValueHandling = NullValueHandling.Ignore)]
            public string CapitalSocial;

            [JsonProperty("qsa", NullValueHandling = NullValueHandling.Ignore)]
            public List<object> Qsa;

            [JsonProperty("extra", NullValueHandling = NullValueHandling.Ignore)]
            public Extra Extra;

            [JsonProperty("billing", NullValueHandling = NullValueHandling.Ignore)]
            public Billing Billing;
        }



    }
}
