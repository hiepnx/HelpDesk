using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Repository.Base
{
    public interface IDatabaseSchemaManagerRepository
    {
        void EnsureSchemaVersion();
    }
}
