using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia{
    public interface IREscenario{
        public bool CrearEscenario(Escenario esc);
        public Escenario BuscarEscenario(int id);
        public bool ModificarEscenario(Escenario esc);
        public bool EliminarEscenario(int id);
        public List<Escenario> ListarEscenarioList();
        public IEnumerable<Escenario> ListarEscenarioIE();
    }
}