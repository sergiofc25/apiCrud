using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork_Interface;

namespace UnitOfWork_SqlServer
{
    public class UnitOfWorkSqlServer: IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        public UnitOfWorkSqlServer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IUnitOfWorkAdapter Create()
        {
            var connectionString = _configuration.GetConnectionString("SqlServerConnection");

            return new UnitOfWorkSqlServerAdapter(connectionString);
        }

    }
}
