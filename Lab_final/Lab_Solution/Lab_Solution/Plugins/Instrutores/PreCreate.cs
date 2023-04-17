using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace Lab_Solution.Plugins.Instrutores
{
    public class PreCreate : PluginBase
    {
        public PreCreate(string unsecurem , string secure) : base(typeof(PreCreate)) {

        }
        protected override void ExecuteCrmPlugin(LocalPluginContext localPluginContext)
        {
            if (localPluginContext == null) throw new InvalidPluginExecutionException("LocalPluginContext");

            IPluginExecutionContext context = localPluginContext.PluginExecutionContext;
            IOrganizationService serviceAdmin = localPluginContext.OrganizationServiceAdmin;

            Entity entityTarget = null;
            if (context.InputParameters.Contains("Target"))
            {
                entityTarget = context.InputParameters["Target"] as Entity;

                if (entityTarget == null) return;

                if (!entityTarget.Contains("dio_telefone"))
                {
                    throw new InvalidPluginExecutionException("O Telefone é obrigatorio!");
                }
            }
        }
    }
}
