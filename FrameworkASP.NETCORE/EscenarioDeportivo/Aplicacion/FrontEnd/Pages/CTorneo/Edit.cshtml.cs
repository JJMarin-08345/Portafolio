using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CTorneo
{
    public class EditModel : PageModel
    {
        //Atributos
        private readonly IRTorneo objTorneo;
        private readonly IRPatrocinador objPatrocinador;
        private readonly IRMunicipio objMunicipio;
        [BindProperty]
        public Torneo torneo {get;set;}
        public IEnumerable<Patrocinador> patrocinadores {get;set;}
        public IEnumerable<Municipio> municipios {get;set;}
        //Metodo Constructor por defecto
        public EditModel(IRTorneo _objTorneo,IRPatrocinador _objPatrocinador,IRMunicipio _objMunicipio){
            this.objTorneo = _objTorneo;
            this.objPatrocinador = _objPatrocinador;
            this.objMunicipio = _objMunicipio;
        }

        //Metodos de funcionalidad
        public ActionResult OnGet(int id){//Este id se captura en el index con 
            //asp-route-id dentro del comando de los botones editar,detalles y eliminar
            patrocinadores=objPatrocinador.ListarPatrocinadorIE();
            municipios=objMunicipio.ListarMunicipiosIE();
            torneo=objTorneo.BuscarTorneo(id);
            if(torneo==null){
                //Esto no debería pasar
                ViewData["Error"]="No se encontró el torneo";
                return Page();
            }
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                patrocinadores=objPatrocinador.ListarPatrocinadorIE();
                municipios=objMunicipio.ListarMunicipiosIE();
                return Page();
            }
            if(objTorneo.ModificarTorneo(torneo)){
                return RedirectToPage("./Index");
            }else{
                patrocinadores=objPatrocinador.ListarPatrocinadorIE();
                municipios=objMunicipio.ListarMunicipiosIE();
                ViewData["Error"]="No fué posible modificar este registro";
                return Page();
            }
        }
    }
}
