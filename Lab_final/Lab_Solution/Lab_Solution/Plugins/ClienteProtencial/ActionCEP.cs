using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Solution.Plugins.ClienteProtencial
{
    public class ActionCEP : PluginBase
    {
        public ActionCEP(string unsecurem, string secure) : base(typeof(ActionCEP)) { }

        protected override void ExecuteCrmPlugin(LocalPluginContext localPluginContext)
        {

            if (localPluginContext == null) throw new InvalidPluginExecutionException("LocalPluginContext");

            IPluginExecutionContext context = localPluginContext.PluginExecutionContext;
            IOrganizationService serviceAdmin = localPluginContext.OrganizationServiceAdmin;

            string cep = (string)context.InputParameters["Cep"];
            string retorno = string.Empty;
            string urlViacep = $"https://viacep.com.br/ws/{cep}/json/";
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Encoding = Encoding.UTF8;
                    retorno = client.DownloadString(urlViacep);
                }
                context.OutputParameters["Retorno"] = retorno;
            }
            catch (WebException e)
            {
                context.OutputParameters["Retorno"] = $"Erro na execução da Acrion \nDetalhes: {e.Message}";
            }
            catch(Exception e)
            {
                context.OutputParameters["Retorno"] =$"Erro na execução da Acrion \nDetalhes: {e.Message}";
            }
           
        }
    }
}
