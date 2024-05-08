using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Persistencia;
using Dominio;

namespace FrontEnd.Pages.CTorneo
{
    public class CreateModel : PageModel
    {
        //Atributos
        private readonly IRTorneo objTorneo;
        private readonly IRMunicipio objMunicipio;
        private readonly IRPatrocinador objPatrocinador;
        [BindProperty]
        public Torneo torneo {get;set;}
        public IEnumerable<Municipio> Municipios {get;set;}
        public IEnumerable<Patrocinador> Patrocinadores {get;set;}
        //Metodos
        //Constructor
        public CreateModel(IRTorneo _objTorneo,IRMunicipio _objMunicipio,IRPatrocinador _objPatrocinador){
            this.objTorneo = _objTorneo;
            this.objMunicipio = _objMunicipio;
            this.objPatrocinador = _objPatrocinador;
        }
        public ActionResult OnGet()
        {
            Municipios=objMunicipio.ListarMunicipiosIE();
            Patrocinadores=objPatrocinador.ListarPatrocinadorIE();
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                Municipios=objMunicipio.ListarMunicipiosIE();
                Patrocinadores=objPatrocinador.ListarPatrocinadorIE();
                return Page();
            }
            if(objTorneo.CrearTorneo(torneo)){
                return RedirectToPage("./Index");
            }else{
                Municipios=objMunicipio.ListarMunicipiosIE();
                Patrocinadores=objPatrocinador.ListarPatrocinadorIE();
                ViewData["Error"]="No se pudo crear el torneo";
                return Page();
            }
            return Page();
        }
    }
}
