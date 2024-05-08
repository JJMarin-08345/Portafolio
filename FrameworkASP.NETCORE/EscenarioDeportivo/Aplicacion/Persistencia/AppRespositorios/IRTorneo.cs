using Dominio;
using System;
using System.Collections.Generic;

namespace Persistencia{
    public interface IRTorneo{
        public bool CrearTorneo(Torneo torn);
        public Torneo BuscarTorneo(int id);
        public bool EliminarTorneo(int id);
        public bool ModificarTorneo(Torneo torn);
        public List<Torneo> ListarTorneosList();
        public IEnumerable<Torneo> ListarTorneosIE();
    }
}