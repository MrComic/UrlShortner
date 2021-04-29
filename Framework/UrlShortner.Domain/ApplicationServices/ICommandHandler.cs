using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortner.Framework.Domain.ApplicationServices
{
    public interface ICommandHandler<TCommand>
    {
        int Handle(TCommand command);
    }
}
