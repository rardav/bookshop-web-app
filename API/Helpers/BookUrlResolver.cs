using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class BookUrlResolver : IValueResolver<Book, BookToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public BookUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Book source, BookToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}