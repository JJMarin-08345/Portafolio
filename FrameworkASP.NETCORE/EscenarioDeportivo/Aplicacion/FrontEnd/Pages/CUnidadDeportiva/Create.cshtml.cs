using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CUnidadDeportiva
{
    public class CreateModel : PageModel
    {
        private readonly IRUnidadDeportiva objUnidad;
        private readonly IRTorneo objTorneo;
        [BindProperty]
        public UnidadDeportiva unidadDeportiva {get;set;}
        public IEnumerable<Torneo> lstTorneos {get;set;}
        //Constructor
        public CreateModel(IRUnidadDeportiva _objUnidad, IRTorneo _objTorneo){
            this.objUnidad = _objUnidad;
            this.objTorneo = _objTorneo;
        }
        public ActionResult OnGet(){
            lstTorneos=objTorneo.ListarTorneosIE();
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                lstTorneos=objTorneo.ListarTorneosIE();
                return Page();
            }
            if(objUnidad.CrearUniDeportiva(unidadDeportiva)){
                return RedirectToPage("./Index");
            }else{
                lstTorneos=objTorneo.ListarTorneosIE();
                ViewData["Error"]="Ya hay una Unidad Deportiva en esta misma dirección";
                return Page();
            }
        }
    }
}
