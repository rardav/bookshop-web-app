using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookToReturnDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.AuthorFirstName, o => o.MapFrom(s => s.Author.FirstName))
                .ForMember(d => d.AuthorLastName, o => o.MapFrom(s => s.Author.LastName))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Price))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<BookUrlResolver>())
                .ForMember(d => d.Genre, o => o.MapFrom(s => s.Genre.Name))
                .ForMember(d => d.Publisher, o => o.MapFrom(s => s.Publisher.Name))
                .ForMember(d => d.Language, o => o.MapFrom(s => s.Language.Name));
        }
    }
}