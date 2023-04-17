dio_clientePotencial= {

    Ribbon: {
        OnClickBuscaCep: (formContext) => {
            'use strict';

            let cep = formContext.getAttribute("dio_cep");

            if (cep.getValue()  === null) {
                Xrm.Navigation.openAlertDialog("Para busca CEP preecha o campo CEP");
                return;
            }
            let data = { Cep : cep.getValue() };
            dio_clientePotencial.CallAction(null, data, "dio_ActionBuscaCEP", (retorno) => {
                if (!retorno.Retorno.includes("logradouro")) {
                    Xrm.Navigation.openAlertDialog("Ocorreu um erro na Chamada\n" + retorno.Retorno);
                    return;
                }
                let endereco = JSON.parse(retorno.Retorno);
                dio_clientePotencial.PopulaEndereco(formContext, endereco);
            })

        }
    },

    Onload: (executionContext) => {
        'use strict';
        const formContext = executionContext.getFormContext();
    },

    PopulaEndereco: (formContext, endereco) => {
        'use strict';
        formContext.getAttribute("dio_rua").setValue(endereco.logradouro);
        formContext.getAttribute("dio_bairro").setValue(endereco.bairro);
        formContext.getAttribute("dio_cidade").setValue(endereco.localidade);
        formContext.getAttribute("dio_pais").setValue("Brasil");
    },
     CallAction: (entity, data, actionName, callback) => {
         'use strict';

        var Id = Xrm.Page.data.entity.getId().replace('{', '').replace('}', '');
        var serverURL = Xrm.Page.context.getClientUrl();

        var query = entity + "(" + Id + ")/Microsoft.Dynamics.CRM." + actionName;

         if (entity === null || id === "")
             query = actionName;
        var req = new XMLHttpRequest();
        req.open("POST", serverURL + "/api/data/v9.1/" + query, true);
        req.setRequestHeader("Accept", "application/json");
        req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        req.setRequestHeader("OData-MaxVersion", "4.0");
        req.setRequestHeader("OData-Version", "4.0");
        req.onreadystatechange = function () {
            if (this.readyState == 4 /* complete */) {
                req.onreadystatechange = null;
                if (req.status >= 200 && req.status <= 300) {
                    var data = JSON.parse(this.response);
                    callback(data);
                } else {
                    var error = JSON.parse(this.response).error;
                    callback(error);
                }
            }
        };
        req.send(window.JSON.stringify(data));

    }
}