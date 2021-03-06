using System;

namespace ContactManagement.Data.Abstractions
{
    /// <summary>
    /// Instance of this interface implements UnitOfWork pattern. In an Mvc application,
    /// contexts exist for the life of a request.
    /// </summary>
    public interface IContextManager : IDisposable
    {
        ContactDBEntities DBContext { get; }
    }
}
