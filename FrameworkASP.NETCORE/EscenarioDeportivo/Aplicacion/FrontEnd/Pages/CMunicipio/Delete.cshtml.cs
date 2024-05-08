using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CMunicipio
{
    public class DeleteModel : PageModel{

        //Atributos
        private readonly IRMunicipio objMunicipio;
        private readonly IRTorneo objTorneo;
        [BindProperty]
        public Municipio municipio {get;set;}
        public List<Torneo> torneos {get;set;}

        //Metodos
        //Constructor
        public DeleteModel(IRMunicipio _objMunicipio,IRTorneo _objTorneo){
            this.objMunicipio = _objMunicipio;
            this.objTorneo = _objTorneo;
        }

        //Sirve para enviar información al formulario
        public ActionResult OnGet(int id)
        {
            municipio=objMunicipio.BuscarMunicipio(id);
            torneos=objTorneo.ListarTorneosList();
            if(municipio==null){
                ViewData["Error"]="No se ha encontrado el municipio";
                //Esto no debería pasar
                return Page();
            }
            return Page();
        }
        public ActionResult OnPost(){
            if(objMunicipio.EliminarMunicipio(municipio.Id)){
                return RedirectToPage("./Index");
            }else{
                torneos=objTorneo.ListarTorneosList();
                ViewData["Error"]="No fue posible eliminar este registro";
                return Page();
            }
        }
    }
}
