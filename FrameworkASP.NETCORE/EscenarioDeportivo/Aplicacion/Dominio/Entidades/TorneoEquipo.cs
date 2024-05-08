using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio{
    public class TorneoEquipo{
        public int Id {get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        public int EquipoId {get;set;}
        public Equipo Equipo {get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        public int TorneoId {get;set;} 
        public Torneo Torneo {get;set;}
        //El ? es para decir que pueden tomar el valor null
    }
}