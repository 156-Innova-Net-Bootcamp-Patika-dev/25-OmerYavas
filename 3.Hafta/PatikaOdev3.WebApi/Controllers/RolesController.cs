using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatikaOdev3.Business.Absract;
using PatikaOdev3.Model.DTOs.RoleAddDTOs;
using PatikaOdev3.Model.Entities;
using System.Collections.Generic;

namespace PatikaOdev3.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RolesController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }


        /// <summary>
        /// Rol listesini getirir.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetRoleList()
        {
            var roleList = _roleService.GetUndeletedRoleList();
            if (roleList.Count > 0)
            {
                return Ok(_mapper.Map<List<Role>>(roleList));
            }
            else
            {
                return BadRequest("Gösterilecek rol bulunamadı.");
            }


        }

        /// <summary>
        /// Rol adına göre kayıt getirir.
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("RoleName")]
        public IActionResult GetRole(string roleName)
        {
            var role = _roleService.GetUnDeletedRole(roleName);
            if (role != null)
            {
                return Ok(_mapper.Map<RoleListDTO>(role));
            }
            else
            {
                return BadRequest($"{roleName} adında rol bulunamadı.");
            }


        }

        /// <summary>
        /// Yeni rol ekler.
        /// </summary>
        /// <param name="roleDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] RoleAddDTO roleDto)
        {
            if (ModelState.IsValid)
            {
                var role = _mapper.Map<Role>(roleDto);

                var result = _roleService.Insert(role);


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
        /// Kayıtlı rol bilgilerini günceller.
        /// </summary>
        /// <param name="roleDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] RoleUpdateDTO roleDto)
        {
            if (ModelState.IsValid)
            {
                var role = _mapper.Map<Role>(roleDto);

                role.IsDelete = true;

                var result = _roleService.Update(role);


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
        /// Kayıtlı rolnin kalıcı değil işlevsel olarak siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("id")]
        public IActionResult Delete(int id)
        {
            var result = _roleService.Update(new Role { Id = id });


            if (result.IsSuccess)
            {
                result.Message = "Rol başarıyla silindi.";
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }


}
