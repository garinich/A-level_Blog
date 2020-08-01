using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.ModelsBL;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace BusinessLayer
{
    public class ArticlesManager
    {
        private readonly ArticleRepo _articleRepo;
        private readonly Mapper _mapper;

        public ArticlesManager()
        {
            _articleRepo = new ArticleRepo();

            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleBL>();
                cfg.CreateMap<ArticleBL, Article>();
                cfg.CreateMap<Author, AuthorBL>();
                cfg.CreateMap<AuthorBL, Author>();
            });

            _mapper = new Mapper(conf);
        }

        public IList<ArticleBL> GetAll()
        {
            return _mapper.Map<IList<ArticleBL>>(_articleRepo.GetAll());
        }

        public ArticleBL GetById(int id)
        {
            return _mapper.Map<ArticleBL>(_articleRepo.GetById(id));
        }

        public void RemoveById(int id)
        {
            _articleRepo.RemoveById(id);
        }

        public void Add(ArticleBL article)
        {
            _articleRepo.Add(_mapper.Map<Article>(article));
        }

        public void Edit(ArticleBL article)
        {
            _articleRepo.Edit(_mapper.Map<Article>(article));
        }
    }
}
