using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CUnidadDeportiva
{
    public class DeleteModel : PageModel
    {
        private readonly IRUnidadDeportiva objUnidad;
        private readonly IRTorneo objTorneo;
        [BindProperty]
        public UnidadDeportiva unidadDeportiva {get;set;}
        public Torneo torneo {get;set;}
        //Constructor
        public DeleteModel(IRUnidadDeportiva _objUnidad,IRTorneo _objTorneo){
            this.objUnidad = _objUnidad;
            this.objTorneo = _objTorneo;
        }
        public ActionResult OnGet(int id){
            unidadDeportiva=objUnidad.BuscarUniDeporiva(id);
            if(unidadDeportiva==null){
                ViewData["Error"]="No se encontró la Unidad Deportiva";
                return Page();
            }else{
                if(unidadDeportiva.TorneoId!=null){
                    torneo=objTorneo.BuscarTorneo(int.Parse(" "+unidadDeportiva.TorneoId));
                }
                return Page();
            }
        }
        public ActionResult OnPost(){
            if(objUnidad.EliminarUniDeportiva(unidadDeportiva.Id)){
                return RedirectToPage("./Index");
            }else{
                ViewData["Error"]="No fue posible eliminar este registro";
                return Page();
            }
        }
    }
}
