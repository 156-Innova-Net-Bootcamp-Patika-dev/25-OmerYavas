using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatikaOdev3.Business.Absract;
using PatikaOdev3.Model.DTOs.CategoryDTOs;
using PatikaOdev3.Model.Entities;
using System.Collections.Generic;


namespace PatikaOdev3.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        /// <summary>
        /// Kategori listesini getirir.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCategoryList()
        {
            var categoryList = _categoryService.GetUndeletedCategoryList();
            if (categoryList.Count > 0)
            {
                return Ok(_mapper.Map<List<CategoryListDTO>>(categoryList));
            }
            else
            {
                return BadRequest("Gösterilecek kategori bulunamadı.");
            }


        }

        /// <summary>
        /// Kategori adına göre kayıt getirir.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("categoryName")]
        public IActionResult GetCategory(string categoryName)
        {
            var category = _categoryService.GetUnDeletedCategory(categoryName);
            if (category != null)
            {
                return Ok(_mapper.Map<CategoryListDTO>(category));
            }
            else
            {
                return BadRequest($"{categoryName} adında kategori bulunamadı.");
            }


        }

        /// <summary>
        /// Yeni kategori ekler.
        /// </summary>
        /// <param name="categoryDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] CategoryAddDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(categoryDto);

                var result = _categoryService.Insert(category);


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

        /// <summary>
        /// Kayıtlı kategori bilgilerini günceller.
        /// </summary>
        /// <param name="categoryDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] CategoryUpdateDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(categoryDto);
                
                category.IsDelete = true;
                var result = _categoryService.Update(category);


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

        /// <summary>
        /// Kayıtlı kategorinin kalıcı değil işlevsel olarak siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("id")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Update(new Category { Id = id });


            if (result.IsSuccess)
            {
                result.Message = "Kategori başarıyla silindi.";
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }


}
