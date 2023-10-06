using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Solution.Plugins.TabelaVirtual
{
    public class Update : PluginBase
    {
        public Update(string unsecurem, string secure) : base(typeof(Update))
        {

        }
        protected override void ExecuteCrmPlugin(LocalPluginContext localPluginContext)
        {
            if (localPluginContext == null) throw new InvalidPluginExecutionException("LocalPluginContext");

            IPluginExecutionContext context = localPluginContext.PluginExecutionContext;
            IOrganizationService serviceAdmin = localPluginContext.OrganizationServiceAdmin;


        }
    }
}
