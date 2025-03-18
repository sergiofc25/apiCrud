using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Interface
{
    public interface IUsuarioRepository
    {
        int Obten_Login(string Usu_Correo, string Usu_Clave);
        Ent_Usuario Obten_x_Correo(string Usu_Correo);
        Ent_Usuario Obten_Token_x_Correo(string Usu_Correo);
        bool Actualiza_Token(Ent_Usuario Usuario);
        (int, int, bool, bool, IEnumerable<Ent_Usuario>) Obten_Paginado(int RegistroPagina, int NumeroPagina, string PorNombre);
        Ent_Usuario Obten_x_Id(int Usu_Id);
        int Existe(string Usu_Correo, bool Usu_Estado);
        int Crea(Ent_Usuario Ent_Usuario);
        int Existente(int Usu_Id, string Usu_Correo, bool Usu_Estado);
        int Actualiza(Ent_Usuario Ent_Usuario);
        int Actualiza_Condicion(int Usu_Id, bool Usu_Estado);
    }
}
