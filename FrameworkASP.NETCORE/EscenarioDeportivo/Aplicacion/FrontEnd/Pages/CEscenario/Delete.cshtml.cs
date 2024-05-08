using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CEscenario
{
    public class DeleteModel : PageModel
    {
        //Atributos 
        private readonly IREscenario objEscenario;
        private readonly IRUnidadDeportiva objUnidad;
        [BindProperty]
        public Escenario escenario {get;set;}
        public UnidadDeportiva uniDepor {get;set;}
        //Constructor
        public DeleteModel(IREscenario _objEscenario,IRUnidadDeportiva _objUnidad){
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
        public ActionResult OnPost(){
            if(objEscenario.EliminarEscenario(escenario.Id)){
                return RedirectToPage("./Index");
            }else{
                ViewData["Error"]="No fué posible eliminar este registro";
                return Page();
            }
        }
    }
}
