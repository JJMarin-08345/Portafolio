using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Collections.Generic;
using Persistencia;
using Dominio;

namespace FrontEnd.Pages.CArbitro
{
    public class CreateModel : PageModel
    {
        //Atributos
        private readonly IRArbitro objArbitro;
        private readonly IRColegioInstruccion objColegio;
        private readonly IRTorneo objTorneo;
        [BindProperty]
        public Arbitro arbitro {get;set;}
        public IEnumerable<ColegioInstruccion> Colegios {get;set;}
        public IEnumerable<Torneo> Torneos {get;set;}
        //Metodos
        //Constructor
        public CreateModel(IRArbitro _objArbitro,IRColegioInstruccion _objColegio,IRTorneo _objTorneo){
            this.objArbitro = _objArbitro;
            this.objColegio = _objColegio;
            this.objTorneo = _objTorneo;
        }
        public ActionResult OnGet()
        {
            Colegios=objColegio.ListarColegiosIE();
            Torneos=objTorneo.ListarTorneosIE();
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                Torneos = objTorneo.ListarTorneosIE();
                Colegios=objColegio.ListarColegiosIE();
                return Page();
            }
            if(objArbitro.CrearArbitro(arbitro)){
                return RedirectToPage("./Index");
            }else{
                Torneos=objTorneo.ListarTorneosIE();
                Colegios=objColegio.ListarColegiosIE();
                ViewData["Error"]="Ya hay un arbitro con este mismo Documento";
                return Page();
            }
            return Page();
        }
    }
}
