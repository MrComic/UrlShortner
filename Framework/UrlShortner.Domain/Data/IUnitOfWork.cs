using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortner.Framework.Domain.Data
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
