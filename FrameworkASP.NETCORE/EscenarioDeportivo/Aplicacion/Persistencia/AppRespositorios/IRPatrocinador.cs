using System;
using System.Collections.Generic;
using Dominio;

namespace Persistencia{
    public interface IRPatrocinador{
        public bool CrearPatrocinador(Patrocinador pat);
        public Patrocinador BuscarPatrocinador(int id);
        public bool ModificarPatrocinador(Patrocinador pat);
        public bool EliminarPatrocinador(int id);
        public List<Patrocinador> ListarPatrocinadorList();
        public IEnumerable<Patrocinador> ListarPatrocinadorIE();
    }
}