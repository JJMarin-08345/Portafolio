using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CEscenario
{
    public class CreateModel : PageModel
    {
        private readonly IREscenario objEscenario;
        private readonly IRUnidadDeportiva objUnidad;
        [BindProperty]
        public Escenario escenario {get;set;}
        public IEnumerable<UnidadDeportiva> lstUnidades {get;set;}
        //Constructor
        public CreateModel(IREscenario _objEscenario,IRUnidadDeportiva _objUnidad){
            this.objEscenario=_objEscenario;
            this.objUnidad=_objUnidad;
        }
        public ActionResult OnGet(){
            lstUnidades = objUnidad.ListarUniDeportivaIE();
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                lstUnidades = objUnidad.ListarUniDeportivaIE();
                return Page();
            }
            if(objEscenario.CrearEscenario(escenario)){
                return RedirectToPage("./Index");
            }else{
                lstUnidades = objUnidad.ListarUniDeportivaIE();
                ViewData["Error"]="Ya hay un escenario con este mismo nombre";
                return Page();
            }

        }
    }
}
