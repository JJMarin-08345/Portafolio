using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio{
    public class Torneo{
        public int Id {get;set;}

        //Requerimientos para campo nombre
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(60,ErrorMessage="El campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(4,ErrorMessage="El campo {0} debe tener mínimo de {1} caracteres")]
        [RegularExpression("([A-Za-z ]*)", ErrorMessage="El campo {0} no acepta valores numericos")]
        public string Nombre {get;set;}

        //Requerimientos para campo categoria
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(40)]
        [MinLength(3,ErrorMessage="El campo {0} debe tener mínimo de {1} caracteres")]
        public string Categoria {get;set;}

        //Requerimientos para campo Deporte
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(40)]
        [MinLength(3,ErrorMessage="El campo {0} debe tener mínimo de {1} caracteres")]
        public string Deporte {get;set;}

        //Requerimiento para campo FechaInicio
        [Required(ErrorMessage="Este campo es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio {get;set;}

        //Requerimiento para campo FechaFin
        [Required(ErrorMessage="Este campo es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaFin {get;set;}

        //Requerimientos para el campo CantidadEquipos
        [Required(ErrorMessage="Este campo es obligatorio")]
        [RegularExpression("([0-9]+)",ErrorMessage="Por favor ingrese solo números")]
        public int CantidadEquipos {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(40)]
        [MinLength(3,ErrorMessage="El campo {0} debe tener mínimo de {1} caracteres")]
        public string Etapa {get;set;}

        //LLAVES FORANEAS
        [Required(ErrorMessage="Escoga un Municipio donde se realizará el torneo")]
        public int MunicipioId {get;set;}
        public Municipio municipio {get;set;}

        public int? PatrocinadorId {get;set;}//Este creo puede ser nulo
        public Patrocinador patrocinador {get;set;}

        //Listas ya inicializadas
        public List<Arbitro> Arbitros {get;set;}=new List<Arbitro>();
        public List<TorneoEquipo> TorneoEquipos {get;set;}=new List<TorneoEquipo>(); //Para la relacion muchos a muchos
        public List<UnidadDeportiva> UnidadesDeportivas {get;set;}=new List<UnidadDeportiva>();
    }
}