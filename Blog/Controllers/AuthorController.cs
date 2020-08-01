using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Blog.Models;
using BusinessLayer;
using BusinessLayer.ModelsBL;

namespace Blog.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorManager _authorManager;
        private readonly Mapper _mapper;

        public AuthorController()
        {
            _authorManager = new AuthorManager();

            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleBL, ArticlePL>();
                cfg.CreateMap<ArticlePL, ArticleBL>();

                cfg.CreateMap<AuthorBL, AuthorPL>();
                cfg.CreateMap<AuthorPL, AuthorBL>();
            });

            _mapper = new Mapper(conf);
        }

        public ActionResult Index()
        {
            var authors = _authorManager.GetAll();
            var authorsMap = _mapper.Map<IList<AuthorPL>>(authors);
            var result = new AllAuthorViewModel {Authors = authorsMap};
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var authors = _authorManager.GetById(id);
            var authorsMap = _mapper.Map<AuthorPL>(authors);
            var result = new AuthorViewModel {Author = authorsMap};
            return View(result);
        }
    }
}
