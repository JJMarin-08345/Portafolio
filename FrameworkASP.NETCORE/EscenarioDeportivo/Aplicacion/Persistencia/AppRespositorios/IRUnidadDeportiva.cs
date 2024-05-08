using System;
using System.Collections.Generic;
using Dominio;

namespace Persistencia{
    public interface IRUnidadDeportiva
    {
        public bool CrearUniDeportiva(UnidadDeportiva unidad);
        public UnidadDeportiva BuscarUniDeporiva(int id);
        public bool ModificarUniDeportiva(UnidadDeportiva unidad);
        public bool EliminarUniDeportiva(int id);
        public List<UnidadDeportiva> ListarUniDeportivaList();
        public IEnumerable<UnidadDeportiva> ListarUniDeportivaIE();
    }
}