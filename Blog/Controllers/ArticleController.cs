using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Blog.Models;
using BusinessLayer;
using BusinessLayer.ModelsBL;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ArticlesManager _articlesManager;
        private readonly AuthorManager _authorManager;
        private readonly Mapper _mapper;

        public ArticleController()
        {
            _articlesManager = new ArticlesManager();
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

        // GET
        public ActionResult Index()
        {
            var articles = _articlesManager.GetAll();
            var articlesMap = _mapper.Map<IList<ArticlePL>>(articles);
            var result = new AllArticleViewModel {Articles = articlesMap};
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var article = _articlesManager.GetById(id);
            var articleMap = _mapper.Map<ArticlePL>(article);
            var result = new ArticleViewModel {Article = articleMap};
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            _articlesManager.RemoveById(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var authors = _authorManager.GetAll();
            var authorsMap = _mapper.Map<IList<AuthorPL>>(authors);
            var result = new SelectList(authorsMap, "Id", "Name");
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(AddArticleViewModel article)
        {
            var author = _authorManager.GetAll().First(el => el.Id == article.AuthorId);
            var newArticle = new ArticleBL
            {
                Title = article.Title,
                DateCreation = DateTime.Now,
                Author = author,
                Description = article.Description,
                Content = article.Content
            };
            _articlesManager.Add(newArticle);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var article = _articlesManager.GetById(id);
            var articleMap = _mapper.Map<ArticlePL>(article);

            var authors = _authorManager.GetAll();
            var authorsMap = _mapper.Map<IList<AuthorPL>>(authors);
            var select = new SelectList(authorsMap, "Id", "Name");
            var result = new EditArticleViewModel
            {
                Article = articleMap,
                Select = select
            };
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(AddArticleViewModel article)
        {
            var author = _authorManager.GetAll().First(el => el.Id == article.AuthorId);
            var newArticle = new ArticleBL
            {
                Id = article.Id,
                Title = article.Title,
                Author = author,
                Description = article.Description,
                Content = article.Content
            };
            _articlesManager.Edit(newArticle);
            return RedirectToAction("Index");
        }
    }
}
