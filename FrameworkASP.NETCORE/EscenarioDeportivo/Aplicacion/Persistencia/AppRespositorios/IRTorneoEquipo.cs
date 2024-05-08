using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public interface IRTorneoEquipo{
        public bool CrearTorneoEquipo(TorneoEquipo torneoEquipo);
        public IEnumerable<TorneoEquipo> ListarTorneoEquipoIE();
        public List<TorneoEquipo> ListarTorneoEquipoList();
    }
}