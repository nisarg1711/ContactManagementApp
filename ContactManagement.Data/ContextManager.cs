using ContactManagement.Data.Abstractions;
using Microsoft.Practices.Unity;
using System;

namespace ContactManagement.Data
{
    /// <summary>
    /// This is the ContextManager class to call the database from EF
    /// </summary>
    public class ContextManager : IContextManager
    {
        public static IUnityContainer container { get; set; }

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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }               
            }
        }
    }
}
