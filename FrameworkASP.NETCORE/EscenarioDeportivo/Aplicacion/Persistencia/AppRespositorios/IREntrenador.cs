using Dominio;
using System.Collections.Generic;

namespace Persistencia{
    public interface IREntrenador{
        public bool CrearEntrenador(Entrenador trenador);
        public Entrenador BuscarEntrenador(int id);
        public bool ModificarEntrenador(Entrenador trenador);
        public bool EliminarEntrenador(int id);
        public List<Entrenador> ListarEntrenadorList();
        public IEnumerable<Entrenador> ListarEntrenadorIE();

    }
}