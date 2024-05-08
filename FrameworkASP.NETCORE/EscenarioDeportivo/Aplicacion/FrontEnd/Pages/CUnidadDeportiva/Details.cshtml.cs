using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CUnidadDeportiva
{
    public class DetailsModel : PageModel
    {
        private readonly IRUnidadDeportiva objUnidad;
        private readonly IRTorneo objTorneo;

        public UnidadDeportiva unidadDeportiva {get;set;}
        public Torneo torneo {get;set;}
        //Constructor
        public DetailsModel(IRUnidadDeportiva _objUnidad,IRTorneo _objTorneo){
            this.objTorneo=_objTorneo;
            this.objUnidad=_objUnidad;
        }
        public ActionResult OnGet(int id){
            unidadDeportiva=objUnidad.BuscarUniDeporiva(id);
            if(unidadDeportiva==null){
                ViewData["Error"]="No se encontró la Unidad Deportiva";
                return Page();
            }else{
                if(unidadDeportiva.TorneoId!=null){
                    torneo=objTorneo.BuscarTorneo(int.Parse(""+unidadDeportiva.TorneoId));
                }
                return Page();
            }
        }
    }
}
