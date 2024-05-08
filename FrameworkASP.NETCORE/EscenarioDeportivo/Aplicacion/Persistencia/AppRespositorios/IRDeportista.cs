using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia{
    public interface IRDeportista{
        public bool CrearDeportista(Deportista deportista);
        public Deportista BuscarDeportista(int id);
        public bool ModificarDeportista(Deportista depor);
        public bool EliminarDeportista(int id);
        public IEnumerable<Deportista> ListarDeportistaXFiltro(string filtro);
        public List<Deportista> ListarDeportistaList();
        public IEnumerable<Deportista> ListarDeportistaIE();
    }
}