using ContactManagement.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Data
{
    public class ContextManager : IContextManager
    {
        private ContactManagementEntities _dbContext;

        public ContactManagementEntities DBContext
        {
            get
            {
                if (_dbContext == null)
                    _dbContext = new ContactManagementEntities();

                return _dbContext;
            }
        }        
    }
}
