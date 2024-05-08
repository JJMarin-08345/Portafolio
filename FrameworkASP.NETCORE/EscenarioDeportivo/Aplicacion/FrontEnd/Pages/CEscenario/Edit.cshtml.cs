using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CEscenario
{
    public class EditModel : PageModel
    {
        //Atributos
        private readonly IREscenario objEscenario;
        private readonly IRUnidadDeportiva objUnidad;
        [BindProperty]
        public Escenario escenario {get;set;}
        public IEnumerable<UnidadDeportiva> lstUnidades { get; set; }
        //Constructor por defecto
        public EditModel(IREscenario _objEscenario,IRUnidadDeportiva _objUnidad){
            this.objEscenario=_objEscenario;
            this.objUnidad =_objUnidad;
        }
        public ActionResult OnGet(int id){
            lstUnidades=objUnidad.ListarUniDeportivaIE();
            escenario=objEscenario.BuscarEscenario(id);
            if(escenario==null){
                //No debe pasar
                ViewData["Error"]="No se encontró el Escenario";
                return Page();
            }
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                lstUnidades=objUnidad.ListarUniDeportivaIE();
                return Page();
            }
            if(objEscenario.ModificarEscenario(escenario)){
                return RedirectToPage("./Index");
            }else{
                lstUnidades=objUnidad.ListarUniDeportivaIE();
                ViewData["Error"]="Ya existe un escenario con este nombre";
                return Page();
            }
        }
    }
}
