using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace UnitOfWork_SqlServer
{
    public class UnitOfWorkSqlServerAdapter : IUnitOfWorkAdapter
    {
        public UnitOfWorkSqlServerAdapter(string connectionString)
        {
            _context = new SqlConnection(connectionString);
            _context.Open();

            _transaction = _context.BeginTransaction();

            Repositories = new UnitOfWorkSqlServerRepository(_context, _transaction);
        }

        private SqlConnection _context { get; }

        private SqlTransaction _transaction { get; }

        public IUnitOfWorkRepository Repositories { get; set; }

        public void Dispose()
        {
            if (_transaction != null) _transaction.Dispose();

            if (_context != null)
            {
                _context.Close();
                _context.Dispose();
            }

            Repositories = null;
        }

        public void SaveChanges()
        {
            _transaction.Commit();
        }
    }
}
