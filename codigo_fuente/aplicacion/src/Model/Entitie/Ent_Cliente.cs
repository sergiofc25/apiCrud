using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entitie
{
    public class Ent_Cliente
    {
        public int Cli_Id { get; set; }
        public string? Cli_NomApeRazSocial { get; set; }
        public string? Cli_Abreviatura { get; set; }
        public string? Cli_NumDocumento { get; set; }
        public Ent_Tipo_Documento eTipo_Documento { get; set; } = new();
        public bool Cli_Estado { get; set; }
    }
}
