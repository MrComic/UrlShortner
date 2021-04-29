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
namespace UrlShortner.Core.ApplicationServices.ShortenedUrls.CommandHandlers
{
    public class CreateHandler : ICommandHandler<Create>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUrlShortnerRepository  urlShortnerRepository;
        
        public CreateHandler(IUnitOfWork unitOfWork,
                             IUrlShortnerRepository urlShortnerRepository)
        {
            this.unitOfWork = unitOfWork;
            this.urlShortnerRepository = urlShortnerRepository;
        }

        public int Handle(Create command)
        {
            var Url = new ShortenedUrl(command.Url);
            urlShortnerRepository.add(Url);
            unitOfWork.Commit();
            return Url.Id;
        }

    }
}
