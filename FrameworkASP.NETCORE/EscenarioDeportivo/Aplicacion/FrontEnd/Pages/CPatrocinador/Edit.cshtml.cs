using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CPatrocinador
{
    public class EditModel : PageModel
    {
        //Atributos
        private readonly IRPatrocinador objPatrocinador;
        [BindProperty]
        public Patrocinador patrocinador {get;set;}
        //Metodo Constructor por Defecto
        public EditModel(IRPatrocinador _objPatrocinador){
            this.objPatrocinador = _objPatrocinador;
        }
        public ActionResult OnGet(int id)//Capturado en el index
        {
            patrocinador = objPatrocinador.BuscarPatrocinador(id);
            if(patrocinador==null){
                //Esto no debería pasar
                ViewData["Error"]="No se encontró el Patrocinador";
                return Page();
            }
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                return Page();
            }
            if(objPatrocinador.ModificarPatrocinador(patrocinador)){
                return RedirectToPage("./Index");
            }else{
                ViewData["Error"]="Ya existe un patrocinador con este mismo documento";
                return Page();
            }
        }

    }
}
