using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;
namespace FrontEnd.Pages.CTorneo
{
    public class DetailsModel : PageModel
    {
        //Atributos
        private readonly IRTorneo objTorneo;
        private readonly IRPatrocinador objPatrocinador;
        private readonly IRMunicipio objMunicipio;
        private readonly IRUnidadDeportiva objUniDepor;
        private readonly IRArbitro objArbitro;
        public Torneo torneo {get;set;}
        public Patrocinador patrocinador {get;set;}
        public Municipio municipio {get;set;}
        public List<UnidadDeportiva> unidadesDepor {get;set;}
        public List<Arbitro> arbitros {get;set;}
        //Metodos
        //Constructor
        public DetailsModel(IRTorneo _objTorneo,IRPatrocinador _objPatrocinador,IRMunicipio _objMunicipio,
                            IRUnidadDeportiva _objUniDepor,IRArbitro _objArbitro){
            this.objTorneo = _objTorneo;
            this.objPatrocinador = _objPatrocinador;
            this.objMunicipio = _objMunicipio;
            this.objUniDepor = _objUniDepor;
            this.objArbitro = _objArbitro;
        }
        
        public ActionResult OnGet(int id){   
            arbitros = objArbitro.ListarArbitrosList();
            unidadesDepor = objUniDepor.ListarUniDeportivaList();
            torneo=objTorneo.BuscarTorneo(id);
            if(torneo!=null){
                municipio=objMunicipio.BuscarMunicipio(torneo.MunicipioId);
                if(torneo.PatrocinadorId!=null){
                    patrocinador=objPatrocinador.BuscarPatrocinador(int.Parse(""+torneo.PatrocinadorId));
                }
                return Page();
            }else{
                ViewData["Error"]="No se encontro el Torneo";
                //Esto no debería pasar
                arbitros = objArbitro.ListarArbitrosList();
                unidadesDepor = objUniDepor.ListarUniDeportivaList();
                return Page();
            }
        }
    }
}
