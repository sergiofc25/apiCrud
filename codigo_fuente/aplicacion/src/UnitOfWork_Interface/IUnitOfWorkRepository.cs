using Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork_Interface
{
    public interface IUnitOfWorkRepository
    {
        IClienteRepository ClienteRepository { get; }
        ITipo_DocumentoRepository Tipo_DocumentoRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        IPresupuestoRepository PresupuestoRepository { get; }
        IUbicacionRepository UbicacionRepository { get; }
    }
}
