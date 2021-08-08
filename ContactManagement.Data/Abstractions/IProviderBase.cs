using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.Data.Abstractions
{
    public interface IProviderBase
    {
        void SaveChanges();
    }
}
