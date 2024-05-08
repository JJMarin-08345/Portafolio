using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CEscenario
{
    public class DetailsModel : PageModel
    {
        //Atributos 
        private readonly IREscenario objEscenario;
        private readonly IRUnidadDeportiva objUnidad;
        public Escenario escenario {get;set;}
        public UnidadDeportiva uniDepor {get;set;}
        //Constructor
        public DetailsModel(IREscenario _objEscenario,IRUnidadDeportiva _objUnidad){
            this.objEscenario=_objEscenario;
            this.objUnidad=_objUnidad;
        }
        public ActionResult OnGet(int id){
            escenario = objEscenario.BuscarEscenario(id);
            if(escenario==null){
                //No debería pasar
                ViewData["Error"]="No se encontró el Escenario";
                return Page();
            }else{
                uniDepor=objUnidad.BuscarUniDeporiva(escenario.UnidadDeportivaId);
                return Page();
            }
        }
    }
}
