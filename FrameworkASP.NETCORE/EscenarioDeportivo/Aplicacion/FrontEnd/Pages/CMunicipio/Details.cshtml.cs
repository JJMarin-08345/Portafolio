using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CMunicipio
{
    public class DetailsModel : PageModel{
        //Atributos
        private readonly IRMunicipio objMunicipio;
        private readonly IRTorneo objToreno;
        public Municipio municipio {get;set;}
        public List<Torneo> torneos {get;set;}

        //Metodos
        //Constructor
        public DetailsModel(IRMunicipio _objMunicipio,IRTorneo _objTorneo){
            this.objMunicipio = _objMunicipio;
            this.objToreno = _objTorneo;
        }
        public ActionResult OnGet(int id){//Este int id siempre pide desde el index.cshtml, haciendo uso del asp-route-id = nombredelaentidad.Id 
            municipio=objMunicipio.BuscarMunicipio(id);
            torneos = objToreno.ListarTorneosList();
            if(municipio==null){
                ViewData["Error"]="No se encontró el municipio";
                //Esto nunca debería pasar
                return Page();
            }
            return Page();
        }
    }
}
