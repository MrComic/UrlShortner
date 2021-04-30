using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortner.Core.Domain.ShortenedUrls.Commands;
using UrlShortner.Core.Domain.ShortenedUrls.Data;
using UrlShortner.Framework.Domain.ApplicationServices;
using UrlShortner.Framework.Domain.Data;
using UrlShortner.Core.Domain.ShortenedUrls.Entities;
using UrlShortner.Framework.Domain.Exceptions;

namespace UrlShortner.Core.ApplicationServices.ShortenedUrls.CommandHandlers
{
    public class RequestToRedirectHandler : ICommandHandler<Redirect,string>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUrlShortnerRepository urlShortnerRepository;

        public RequestToRedirectHandler(IUnitOfWork unitOfWork,
                             IUrlShortnerRepository urlShortnerRepository)
        {
            this.unitOfWork = unitOfWork;
            this.urlShortnerRepository = urlShortnerRepository;
        }

        public string Handle(Redirect command)
        {
            var entity = urlShortnerRepository.Load(command.Id);
            if (entity == null)
            {
                throw new CustomExceptionsBase("شناسه ارسالی وجود ندارد");
            }
            entity.VisitThisLink();
            unitOfWork.Commit();
            return entity.ActualUrl;
        }
    }
}
