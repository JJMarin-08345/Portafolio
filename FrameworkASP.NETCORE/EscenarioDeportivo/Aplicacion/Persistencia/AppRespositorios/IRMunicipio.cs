using System.Collections.Generic;
using Dominio;

//Interfaz de Municipio
namespace Persistencia{
    public interface IRMunicipio{
        //Los metodos
        public bool CrearMunicipio(Municipio mun);
        public Municipio BuscarMunicipio(int id);
        public bool ModificarMunicipio (Municipio mun);
        public bool EliminarMunicipio (int id);
        public List<Municipio> ListarMunicipiosList();
        public IEnumerable<Municipio> ListarMunicipiosIE();
    }
}
