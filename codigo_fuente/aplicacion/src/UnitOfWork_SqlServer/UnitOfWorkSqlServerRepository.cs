using Repository_Interface;
using Repository_SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace UnitOfWork_SqlServer
{
    public class UnitOfWorkSqlServerRepository: IUnitOfWorkRepository
    {
        public IClienteRepository ClienteRepository { get; }
        public ITipo_DocumentoRepository Tipo_DocumentoRepository { get; }
        public IUsuarioRepository UsuarioRepository { get; }
        public IPresupuestoRepository PresupuestoRepository { get; }
        public IUbicacionRepository UbicacionRepository { get; }
        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            ClienteRepository = new ClienteRepository(context, transaction);

            Tipo_DocumentoRepository = new Tipo_DocumentoRepository(context, transaction);

            UsuarioRepository = new UsuarioRepository(context, transaction);

            PresupuestoRepository = new PresupuestoRepository(context, transaction);

            UbicacionRepository = new UbicacionRepository(context, transaction);

        }
        
    }
}
