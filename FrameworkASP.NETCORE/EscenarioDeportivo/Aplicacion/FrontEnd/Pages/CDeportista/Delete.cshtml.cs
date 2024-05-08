using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CDeportista
{
    public class DeleteModel : PageModel
    {
        //Atributos
        private readonly IRDeportista objDeportista;
        private readonly IREquipo objEquipo;
        [BindProperty]
        public Deportista deportista {get;set;}
        public Equipo equipo {get;set;}
        //Metodo Constructor
        public DeleteModel(IRDeportista _objDeportista,IREquipo _objEquipo){
            this.objDeportista = _objDeportista;
            this.objEquipo = _objEquipo;
        }
        public ActionResult OnGet(int id){
            deportista=objDeportista.BuscarDeportista(id);
            if(deportista==null){
                //Esto no debería pasar
                ViewData["Error"]="No se encontró el deportista";
                return Page();
            }else{
                equipo = objEquipo.BuscarEquipo(deportista.EquipoId);
                return Page();
            }
        }
        public ActionResult OnPost(){
            if(objDeportista.EliminarDeportista(deportista.Id)){
                return RedirectToPage("./Index");
            }else{
                ViewData["Error"]="No fue posible eliminar el Deportista";
                return Page();
            }
        }
    }
}
