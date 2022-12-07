using AutoMapper;
using AutoMapper.Configuration;
using BookStore.API.Data;
using BookStore.API.Models;

namespace BookStore.API.Helpers
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}
