using Dominio;
using System.Collections.Generic;

//Interfaz de Colegio Instruccion
namespace Persistencia{
    public interface IRColegioInstruccion{
        public bool CrearColegio(ColegioInstruccion colegio);
        public ColegioInstruccion BuscarColegio(int id);
        public bool ModificarColegio(ColegioInstruccion colegio);
        public bool EliminarColegio(int id);
        public List<ColegioInstruccion> ListarColegiosList();
        public IEnumerable<ColegioInstruccion> ListarColegiosIE();
    }
}