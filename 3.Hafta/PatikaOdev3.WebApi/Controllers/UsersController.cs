using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatikaOdev3.Business.Absract;
using PatikaOdev3.Model.DTOs.UserDTOs;
using PatikaOdev3.Model.Entities;
using System;
using System.Collections.Generic;

namespace PatikaOdev3.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        /// <summary>
        /// Kullanıcı listesini getirir.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UserList()
        {
            var userList = _userService.GetUndeletedUserList();
            if (userList.Count > 0)
            {
                return Ok(_mapper.Map<List<UserListDTO>>(userList));
            }
            else
            {
                return BadRequest("Gösterilecek kullanıcı bulunamadı.");
            }


        }

        /// <summary>
        /// Kullanıcı adına göre kayıt getirir.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("name")]
        public IActionResult GetUser([FromQuery] string userName)
        {
            var user = _userService.GetUnDeletedUserWithUserName(userName);
            if (user != null)
            {
                return Ok(_mapper.Map<List<UserListDTO>>(user));
            }
            else
            {
                return BadRequest($"{userName} Kullanıcı adına sahip kayıt bulunamadı.");
            }


        }

        /// <summary>
        /// Yeni kullanıcı ekler.
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] UserAddDTO userDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _mapper.Map<User>(userDto);

                    var result = _userService.Insert(user);


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
        /// Kayıtlı kullanıcı bilgilerini günceller.
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] UserUpdateDTO userDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _mapper.Map<User>(userDto);

                    user.IsDelete = true;

                    var result = _userService.Update(user);


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
        /// Kayıtlı Kullanıcı kalıcı değil işlevsel olarak siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var userInDb = _userService.GetById(id);
                userInDb.IsDelete = false;

                var result = _userService.Update(userInDb);

                if (result.IsSuccess)
                {
                    result.Message = "Kullanıcı başarıyla silindi.";
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
