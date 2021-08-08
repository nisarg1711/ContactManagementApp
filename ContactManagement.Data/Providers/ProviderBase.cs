using ContactManagement.Data.Abstractions;

namespace ContactManagement.Data.Providers
{
    public abstract class ProviderBase : IProviderBase
    {
        protected readonly ContactDBEntities contactEntities;

        public ProviderBase(ContactDBEntities _contactEntities)
        {
            contactEntities = _contactEntities;
        }

        public void SaveChanges()
        {
            contactEntities.SaveChanges();
        }
    }
}
