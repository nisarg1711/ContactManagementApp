using ContactManagement.Data.Abstractions;

namespace ContactManagement.Data
{
    /// <summary>
    /// This is the ContextManager class to call the database from EF
    /// </summary>
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
