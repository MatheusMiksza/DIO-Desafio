using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lab_Solution.Models;
using Newtonsoft.Json;

namespace Lab_Solution.Plugins.TabelaVirtual
{
    public class RetrieveMultiplo : PluginBase
    {
        public RetrieveMultiplo(string unsecurem, string secure) : base(typeof(RetrieveMultiplo))
        {

        }
        ConsultaCNPJ.Root consultaCNPJ = new ConsultaCNPJ.Root();
        EntityCollection ec = new EntityCollection();
        protected override void ExecuteCrmPlugin(LocalPluginContext localPluginContext)
        {
            if (localPluginContext == null) throw new InvalidPluginExecutionException("LocalPluginContext");

            IPluginExecutionContext context = localPluginContext.PluginExecutionContext;
            IOrganizationService serviceAdmin = localPluginContext.OrganizationServiceAdmin;
            
            var qe = (QueryExpression)context.InputParameters["Query"];
            var a = (string)qe.Criteria.Conditions[0].Values[0];
            //BuscaCNPJAsync(a);
            MontaTblVirtual();

            context.OutputParameters["BusinessEntityCollection"] = ec;



        }

        async Task BuscaCNPJAsync(string cnpj)
        {
            string url = $"https://www.receitaws.com.br/v1/cnpj/{cnpj}?callback=?";
            string retorno = string.Empty;
            
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    retorno = client.DownloadString(url);
                    consultaCNPJ =  JsonConvert.DeserializeObject<ConsultaCNPJ.Root>(retorno);
                }

                
            }
            catch (WebException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        void MontaTblVirtual()
        {
            
            Entity entity = new Entity("mm_consultacnpj");
            entity.Attributes.Add("mm_cnpj", "05.300.584/0001-07");
            entity.Attributes.Add("mm_name", "Zé das Couve");
            entity.Attributes.Add("mm_situacao","Plantando Couve");

            ec.Entities.Add(entity);


        }
    }
}
