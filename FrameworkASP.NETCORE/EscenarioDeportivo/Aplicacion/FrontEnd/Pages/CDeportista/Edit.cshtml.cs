using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CDeportista
{
    public class EditModel : PageModel
    {
        //Atributos
        private readonly IRDeportista objDeportista;
        private readonly IREquipo objEquipo;
        [BindProperty]
        public Deportista deportista {get;set;}
        public IEnumerable<Equipo> lstEquipos {get;set;}
        //Metodo COnstructor
        public EditModel(IRDeportista _objDeportista, IREquipo _objEquipo){
            this.objDeportista = _objDeportista;
            this.objEquipo = _objEquipo;
        }
        public ActionResult OnGet(int id){
            lstEquipos=objEquipo.ListarEquipoIE();
            deportista=objDeportista.BuscarDeportista(id);
            if(deportista==null){
                //Esto no debería pasar
                ViewData["Error"]="No se encontró el Deportista";
                return Page();
            }
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                return Page();
            }
            if(objDeportista.ModificarDeportista(deportista)){
                return RedirectToPage("./Index");
            }else{
                ViewData["Error"]="No fué posible modificar este Deportistas";
                return Page();
            }
        }
    }
}
