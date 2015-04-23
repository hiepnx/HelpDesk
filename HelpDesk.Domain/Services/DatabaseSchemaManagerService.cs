using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDesk.Domain.Repository.Base;
using HelpDesk.Domain.Services.Base;

namespace HelpDesk.Domain.Services
{
    [Export(typeof(IDatabaseSchemaManagerService))]
    public class DatabaseSchemaManagerService : IDatabaseSchemaManagerService
    {
        [ImportingConstructor]
        public DatabaseSchemaManagerService(IDatabaseSchemaManagerRepository repository)
        {
            Repository = repository;
        }

        private IDatabaseSchemaManagerRepository Repository { get; set; }

        public void EnsureSchemaVersion()
        {
            Repository.EnsureSchemaVersion();
        }
    }
}
