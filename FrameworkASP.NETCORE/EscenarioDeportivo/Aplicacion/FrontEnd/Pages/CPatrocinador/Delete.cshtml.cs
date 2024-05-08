using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CPatrocinador
{
    public class DeleteModel : PageModel
    {
        //Atributos
        private readonly IRPatrocinador objPatrocinador;
        //Para propiedades navigacionales
        private readonly IRTorneo objTorneo;
        private readonly IREquipo objEquipo;
        [BindProperty]
        public Patrocinador patrocinador {get;set;}
        //Para propiedades navigacionales
        public List<Equipo> equipos { get; set; }
        public List<Torneo> torneos { get; set; }
        //Metodo Constructor por defecto
        public DeleteModel(IRPatrocinador _objPatrocinador,IREquipo _objEquipo,IRTorneo _objTorneo){
            this.objPatrocinador = _objPatrocinador;
            this.objEquipo = _objEquipo;
            this.objTorneo = _objTorneo;
        }
        public ActionResult OnGet(int id)//Capturado en el Index
        {
            torneos = objTorneo.ListarTorneosList();
            equipos = objEquipo.ListarEquipoList();
            patrocinador=objPatrocinador.BuscarPatrocinador(id);
            if(patrocinador==null){
                //Esto no debería pasar
                ViewData["Error"]="No se encontró el patrocinador";
                return Page();
            }
            return Page();
        }
        public ActionResult OnPost(){
            if(objPatrocinador.EliminarPatrocinador(patrocinador.Id)){
                return RedirectToPage("./Index");
            }else{
                torneos = objTorneo.ListarTorneosList();
                equipos = objEquipo.ListarEquipoList();
                ViewData["Error"]="No fue posible eliminar este registro"+
                                    "\r Quizás hayan muchos equipos y torneos relacionados con este patrocinador"+
                                    "\r Si se borrase, se borrarian los equipos y torneos en donde este este patrocinador";
                return Page();
            }
        }
    }
}
