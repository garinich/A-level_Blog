using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.ModelsBL;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace BusinessLayer
{
    public class AuthorManager
    {
        private readonly AuthorRepo _authorRepo;
        private readonly Mapper _mapper;

        public AuthorManager()
        {
            _authorRepo = new AuthorRepo();

            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleBL>();
                cfg.CreateMap<ArticleBL, Article>();
                cfg.CreateMap<Author, AuthorBL>();
                cfg.CreateMap<AuthorBL, Author>();
            });

            _mapper = new Mapper(conf);
        }

        public IList<AuthorBL> GetAll()
        {
            return _mapper.Map<IList<AuthorBL>>(_authorRepo.GetAll());
        }

        public AuthorBL GetById(int id)
        {
            return _mapper.Map<AuthorBL>(_authorRepo.GetById(id));
        }
    }
}
