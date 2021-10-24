using Blog.Common.Interfaces;
using Blog.Common.Models.ServiceResult;
using Blog.DTOs.Users;
using Blog.Users.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedServiceResult<GetUserDTO>>> GetAllUsers()
        {
            return Ok(await _userService.GetPaginatedUsers());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult>> CreateUser([FromBody] CreateUserDTO newUser)
        {
            return Created("", await _userService.CreateUser(newUser));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResult<GetUserDTO>>> GetUser(Guid id)
        {
            return Ok(await _userService.GetUserByID(id));
        }
    }
}
