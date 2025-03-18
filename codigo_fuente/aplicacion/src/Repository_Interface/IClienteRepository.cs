using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Interface
{
    public interface IClienteRepository
    {
        (int, int, bool, bool, IEnumerable<Ent_Cliente>) Obten_Paginado(int RegistroPagina, int NumeroPagina, string? PorNombre);
        IEnumerable<Ent_Cliente> Obten_Nombre();
        IEnumerable<Ent_Cliente> Obten_x_Nombre(string Cli_NomApeRazSocial);
        Ent_Cliente Obten_x_Id(int Cli_Id);
        int Existe(string Cli_NumDocumento, bool Cli_Estado);
        int Crea(Ent_Cliente Cliente);
        int Existente(int Cli_Id, string Cli_NumDocumento, bool Cli_Estado);
        int Actualiza(Ent_Cliente Cliente);
        int Actualiza_Condicion(int Cli_Id, bool Cli_Estado);

    }
}
