using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatikaOdev3.Business.Absract;
using PatikaOdev3.Model.DTOs.ArticleDTOs;
using PatikaOdev3.Model.Entities;
using System;
using System.Collections.Generic;

namespace PatikaOdev3.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }


        /// <summary>
        /// Makale listesini getirir.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ArticleList()
        {
            var articleList = _articleService.GetUndeletedArticleList();
            if (articleList.Count > 0)
            {
                return Ok(_mapper.Map<List<ArticleListDTO>>(articleList));
            }
            else
            {
                return BadRequest("Gösterilecek makale bulunamadı.");
            }


        }

        /// <summary>
        /// Makale adına göre kayıt getirir.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("name")]
        public IActionResult GetArticle([FromQuery] string title)
        {
            var article = _articleService.GetUndeletedArticleWithTitle(title);
            if (article != null)
            {
                return Ok(_mapper.Map<List<ArticleListDTO>>(article));
            }
            else
            {
                return BadRequest($"{title} başlığında makale bulunamadı.");
            }


        }

        /// <summary>
        /// Yeni makale ekler.
        /// </summary>
        /// <param name="articleDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] ArticleAddDTO articleDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var article = _mapper.Map<Article>(articleDto);

                    var result = _articleService.Insert(article);


                    if (result.IsSuccess)
                    {
                        return Created("", result);
                    }
                    else
                    {
                        return BadRequest(result);
                    }
                }

                return BadRequest();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Kayıtlı makale bilgilerini günceller.
        /// </summary>
        /// <param name="articleDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] ArticleUpdateDTO articleDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var article = _mapper.Map<Article>(articleDto);

                    article.IsDelete = true;

                    var result = _articleService.Update(article);


                    if (result.IsSuccess)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest(result);
                    }
                }

                return BadRequest();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Kayıtlı Makale kalıcı değil işlevsel olarak siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var articleInDb = _articleService.GetById(id);
                articleInDb.IsDelete = false;

                var result = _articleService.Update(articleInDb);

                if (result.IsSuccess)
                {
                    result.Message = "Makale başarıyla silindi.";
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
