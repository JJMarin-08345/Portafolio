using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistencia;
using Dominio;

namespace FrontEnd.Pages.CArbitro
{
    public class DeleteModel : PageModel
    {
        //Atributos
        private readonly IRArbitro objArbitro;
        //Para propiedades navigacionales
        private readonly IRColegioInstruccion objColegio;
        private readonly IRTorneo objTorneo;
        [BindProperty]
        public Arbitro arbitro {get;set;}
        //Para propiedades navigacionales
        public ColegioInstruccion colegio {get;set;}
        public Torneo torneo {get;set;}
        //Metodos
        //Constructor
        public DeleteModel(IRArbitro _objArbitro,IRColegioInstruccion _objColegio,IRTorneo _objTorneo){
            this.objArbitro = _objArbitro;
            this.objColegio = _objColegio;
            this.objTorneo = _objTorneo;
        }
        public ActionResult OnGet(int id){
            arbitro=objArbitro.BuscarArbitro(id);
            if(arbitro==null){
                ViewData["Error"]="No se encontró el Arbitro";
                return Page();
            }else{
                colegio=objColegio.BuscarColegio(arbitro.ColegioInstruccionId);
                if(arbitro.TorneoId!=null){
                    torneo=objTorneo.BuscarTorneo(int.Parse(""+arbitro.TorneoId));
                }
                return Page();
            }
        }
        public ActionResult OnPost(){
            if(objArbitro.EliminarArbitro(arbitro.Id)){
                return RedirectToPage("./Index");
            }else{
                ViewData["Error"]="No se pudo eliminar el arbitro";
                return Page();
            }
        }
    }
}
