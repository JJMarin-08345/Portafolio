using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CUnidadDeportiva
{
    public class EditModel : PageModel
    {
        private readonly IRUnidadDeportiva objUnidad;
        private readonly IRTorneo objTorneo;
        [BindProperty]
        public UnidadDeportiva unidadDeportiva {get;set;}
        public IEnumerable<Torneo> lstTorneo {get;set;}
        //Constructor
        public EditModel(IRUnidadDeportiva _objUnidad,IRTorneo _objTorneo){
            this.objUnidad = _objUnidad;
            this.objTorneo = _objTorneo;
        }
        public ActionResult OnGet(int id){
            lstTorneo=objTorneo.ListarTorneosIE();
            unidadDeportiva = objUnidad.BuscarUniDeporiva(id);
            if(unidadDeportiva==null){
                ViewData["Error"]="No se encontró la Unidad Deportiva";
                return Page();
            }
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                lstTorneo=objTorneo.ListarTorneosIE();
                return Page();
            }
            if(objUnidad.ModificarUniDeportiva(unidadDeportiva)){
                return RedirectToPage("./Index");
            }else{
                lstTorneo=objTorneo.ListarTorneosIE();
                ViewData["Error"]="Ya existe una unidad con esta misma dirección";
                return Page();
            }
        }
    }
}
