using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entitie
{
    public class Ent_Usuario
    {
        public int Usu_Id { get; set; }
        public string? Usu_Correo { get; set; }
        public string? Usu_Clave { get; set; }
        public string? Usu_NomApellidos { get; set; }
        public Ent_Rol eRol { get; set; } = new();
        public DateTime Usu_FecHoraRegistro { get; set; }
        public string? Usu_Observacion { get; set; }
        public bool Usu_Estado { get; set; }
        public string? Usu_TokenActualizado { get; set; }
        public DateTime Usu_FecHoraTokenActualizado { get; set; }

    }
}
