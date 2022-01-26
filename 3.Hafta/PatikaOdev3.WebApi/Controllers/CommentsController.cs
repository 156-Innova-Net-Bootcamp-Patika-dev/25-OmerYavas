using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatikaOdev3.Business.Absract;
using PatikaOdev3.Model.DTOs.CommentDTOs;
using PatikaOdev3.Model.Entities;
using System;
using System.Collections.Generic;

namespace PatikaOdev3.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }


        /// <summary>
        /// Yorum listesini getirir.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCommentList()
        {
            var commentList = _commentService.GetUndeletedCommentList();
            if (commentList.Count > 0)
            {
                return Ok(_mapper.Map<List<CommentListDTO>>(commentList));
            }
            else
            {
                return BadRequest("Gösterilecek yorum bulunamadı.");
            }


        }



        /// <summary>
        /// Yeni Yorum ekler.
        /// </summary>
        /// <param name="commentDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] CommentAddDTO commentDto)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var comment = _mapper.Map<Comment>(commentDto);

                    var result = _commentService.Insert(comment);


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
        /// Kayıtlı yorum bilgilerini günceller.
        /// </summary>
        /// <param name="commentDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] CommentUpdateDTO commentDto)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var commentInDb = _commentService.GetById(commentDto.Id);

                    var comment = _mapper.Map<Comment>(commentDto);

                    comment.ArticleId = commentInDb.ArticleId;

                    comment.IsDelete = true;
                    var result = _commentService.Update(comment);


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
        /// Kayıtlı yorumu kalıcı olarak siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("id")]
        public IActionResult Delete(int id)
        {
            try
            {

                var result = _commentService.Delete(id);


                if (result.IsSuccess)
                {
                    result.Message = "Yorum başarıyla silindi.";
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
