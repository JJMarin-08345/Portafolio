using System;
using System.Collections.Generic;
using Dominio;

namespace Persistencia{
    public interface IREquipo{
        public bool CrearEquipo(Equipo equ);
        public Equipo BuscarEquipo(int id);
        public bool ModificarEquipo(Equipo equ);
        public bool EliminarEquipo(int id);
        public List<Equipo> ListarEquipoList();
        public IEnumerable<Equipo> ListarEquipoIE();
    }
}