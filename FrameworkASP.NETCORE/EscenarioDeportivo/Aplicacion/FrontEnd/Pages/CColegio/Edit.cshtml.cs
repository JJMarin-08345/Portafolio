using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistencia;
using Dominio;

namespace FrontEnd.Pages.CColegio
{
    public class EditModel : PageModel
    {
        //Atributos
        private readonly IRColegioInstruccion objColegio;
        [BindProperty]
        public ColegioInstruccion colegio {get;set;}
        //Metodos 
        //Constructor por defecto
        public EditModel(IRColegioInstruccion _objColegio){
            this.objColegio = _objColegio;
        }
        public ActionResult OnGet(int id){
            colegio = objColegio.BuscarColegio(id);
            if(colegio==null){
                ViewData["Error"]="No se encontró el colegio";
                return Page();
            }
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                return Page();
            }
            if(objColegio.ModificarColegio(colegio)){
                return RedirectToPage("./Index");
            }else{
                ViewData["Error"]="Ya existe un colegio con este mismo NIT";
                return Page();
            }
        }
    }
}
