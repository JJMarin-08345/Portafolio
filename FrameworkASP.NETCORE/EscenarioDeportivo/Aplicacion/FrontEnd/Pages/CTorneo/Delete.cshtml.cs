using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CTorneo
{
    public class DeleteModel : PageModel
    {
        //Atributos
        private readonly IRTorneo objTorneo;
        private readonly IRMunicipio objMunicipio;
        private readonly IRPatrocinador objPatrocinador;
        private readonly IRUnidadDeportiva objUniDepor;
        private readonly IRArbitro objArbitro;
        [BindProperty]
        public Torneo torneo {get;set;}
        public Municipio municipio {get;set;}
        public Patrocinador patrocinador {get;set;}
        public List<Arbitro> arbitros {get;set;}
        public List<UnidadDeportiva> unidadesDepor { get; set; }

        //Metodos
        //Constructor por defecto
        public DeleteModel(IRTorneo _objTorneo,IRMunicipio _objMunicipio,IRPatrocinador _objPatrocinador,
                            IRUnidadDeportiva _objUniDepor,IRArbitro _objArbitro){
            this.objTorneo = _objTorneo;
            this.objMunicipio = _objMunicipio;
            this.objPatrocinador = _objPatrocinador;
            this.objUniDepor = _objUniDepor;
            this.objArbitro = _objArbitro;
        }
        public ActionResult OnGet(int id){
            arbitros = objArbitro.ListarArbitrosList();
            unidadesDepor = objUniDepor.ListarUniDeportivaList();
            torneo = objTorneo.BuscarTorneo(id);
            if(torneo==null){
                //Esto no debería pasar
                ViewData["Error"]="No se encontró el torneo";
                return Page();
            }else{
                municipio = objMunicipio.BuscarMunicipio(torneo.MunicipioId);
                if(torneo.PatrocinadorId!=null){
                    patrocinador = objPatrocinador.BuscarPatrocinador(int.Parse(""+torneo.PatrocinadorId));
                }
                return Page();
            }
        }
        public ActionResult OnPost(){
            if(objTorneo.EliminarTorneo(torneo.Id)){
                return RedirectToPage("./Index");
            }else{
                arbitros = objArbitro.ListarArbitrosList();
                unidadesDepor = objUniDepor.ListarUniDeportivaList();
                ViewData["Error"]="No es posible eliminar este Torneo\n"
                +"Eliminaría los Arbitros, Equipos, y Unidades Deportivas que lo contengan\n"
                +"Modifique los mencionados que estén relacionados con este Torneo";
                return Page();
            }
        }
    }
}
