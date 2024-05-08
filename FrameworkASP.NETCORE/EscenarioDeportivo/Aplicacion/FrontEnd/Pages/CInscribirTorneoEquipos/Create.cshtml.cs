using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CInscribirTorneoEquipos
{
    public class CreateModel : PageModel
    {
        private readonly IRTorneoEquipo objTorneoEquipo;
        private readonly IRTorneo objTorneo;
        private readonly IREquipo objEquipo;
        [BindProperty]
        public TorneoEquipo torneoEquipo {get;set;}
        public IEnumerable<Equipo> lstEquipos { get; set; }
        public IEnumerable<Torneo> lstTorneos {get;set;}
        //Constructor por defecto
        public CreateModel(IRTorneoEquipo _objTorneoEquipo,IREquipo _objEquipo,IRTorneo _objTorneo){
            this.objTorneoEquipo =_objTorneoEquipo;
            this.objEquipo = _objEquipo;
            this.objTorneo = _objTorneo;
        }
        public ActionResult OnGet(){
            lstEquipos=objEquipo.ListarEquipoIE();
            lstTorneos=objTorneo.ListarTorneosIE();
            if(lstEquipos!=null && lstTorneos!=null){
                return Page();
            }else{
                ViewData["Error"]="No hay ningún equipo o torneo para registrar";
            }
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                lstEquipos=objEquipo.ListarEquipoIE();
                lstTorneos=objTorneo.ListarTorneosIE();
                return Page();
            }
            if(objTorneoEquipo.CrearTorneoEquipo(torneoEquipo)){
                return RedirectToPage("./Index");
            }else{
                lstEquipos=objEquipo.ListarEquipoIE();
                lstTorneos=objTorneo.ListarTorneosIE();
                ViewData["Error"]="Este equipo ya se encuentra registrado en ese torneo";
                return Page();
            }
        }
    }
}
