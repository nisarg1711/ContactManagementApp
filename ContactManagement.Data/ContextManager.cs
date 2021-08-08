using ContactManagement.Data.Abstractions;

namespace ContactManagement.Data
{
    /// <summary>
    /// This is the ContextManager class to call the database from EF
    /// </summary>
    public class ContextManager : IContextManager
    {
        private ContactDBEntities _dbContext;

        public ContactDBEntities DBContext
        {
            get
            {
                if (_dbContext == null)
                    _dbContext = new ContactDBEntities();

                return _dbContext;
            }
        }        
    }
}
