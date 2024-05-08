using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Persistencia;
using Dominio;

namespace FrontEnd.Pages.CMunicipio
{
    public class IndexModel : PageModel
    {
        //Atributos
        private readonly IRMunicipio objMunicipio;
        public IEnumerable<Municipio> Municipios{get;set;}

        //Metodos
        public IndexModel(IRMunicipio repoMunicipio){
            this.objMunicipio = repoMunicipio;
        }

        //Enviar vista y/o valores al usuario
        public void OnGet(){//Lo que hacemos acá, debemos conectarlo en el Index.cshtml
            Municipios=objMunicipio.ListarMunicipiosIE();
        }
    }
}
