using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Solution
{
    public abstract class PluginBase : IPlugin
    {
        protected class LocalPluginContext
        {
            internal IServiceProvider ServiceProvider { get; private set; }

            internal IOrganizationService OrganizationServiceAdmin { get; private set; }
            internal IOrganizationService OrganizationService { get; private set; }
            internal IPluginExecutionContext PluginExecutionContext { get; private set; }
            internal IServiceEndpointNotificationService NotificationService { get; private set; }
            internal ITracingService TracingService { get; private set; }
            internal IOrganizationServiceFactory ServiceFactory { get; private set; }

            private LocalPluginContext() { }

            internal LocalPluginContext(IServiceProvider serviceProvider)
            {
                if(serviceProvider == null) throw new ArgumentNullException("serviceProvider");


                PluginExecutionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                
                ServiceProvider = (IServiceProvider)serviceProvider.GetService(typeof(IServiceProvider));

                TracingService = (ITracingService)serviceProvider.GetService(typeof(IServiceProvider));

                NotificationService = (IServiceEndpointNotificationService)serviceProvider.GetService(typeof(IServiceEndpointNotificationService));

                ServiceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));

                OrganizationServiceAdmin = ServiceFactory.CreateOrganizationService(null);

                OrganizationService = ServiceFactory.CreateOrganizationService(PluginExecutionContext.UserId);

            }

            internal void Trace(string message)
            {
                if (string.IsNullOrWhiteSpace(message) || TracingService == null)
                {
                    return;
                }

                if (PluginExecutionContext == null)
                {
                    TracingService.Trace(message);
                }
                else
                {
                    TracingService.Trace(
                        "{0}, Correlation Id: {1}, Initiating User: {2}",
                        message,
                        PluginExecutionContext.CorrelationId,
                        PluginExecutionContext.InitiatingUserId);
                }
            }




        }

        //ChildClassName para saber qual clase esta rodando no momento
        protected string ChildClassName { get; private set; }
        internal PluginBase(Type childClassName)
        {
            ChildClassName = childClassName.ToString();
        }
        public void Execute(IServiceProvider serviceProvider)
        {
            if(serviceProvider == null) throw new ArgumentNullException("serviceProvider");

            //Chama o LocalPluginContext para desmenbrar o serviceProvider
            LocalPluginContext localPluginContext = new LocalPluginContext(serviceProvider);

            try {

                //Invoca a implementação
                ExecuteCrmPlugin(localPluginContext);

                return;
                

            } catch (FaultException<OrganizationServiceFault> e) {

                localPluginContext.Trace(string.Format(CultureInfo.InvariantCulture, "Exception: {0}", e.ToString()));

            } finally {
                localPluginContext.Trace(string.Format(CultureInfo.InvariantCulture, "Exiting {0}.Execute()",this.ChildClassName));
            }

        }

        protected virtual void ExecuteCrmPlugin(LocalPluginContext localcontext)
        {
            
        }
    }
}
