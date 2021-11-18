using Blog.Common.Interfaces;
using Blog.Common.Models.ServiceResult;
using Blog.DTOs.Persons;

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
        public async Task<ActionResult<PaginatedServiceResult<GetPersonDTO>>> GetAllUsers()
        {
            return await _userService.GetPaginatedUsersAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult>> CreateUser([FromBody] CreatePersonDTO newUser)
        {
            return Created("", await _userService.CreateUserAsync(newUser));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResult<GetPersonDTO>>> GetUser(Guid id)
        {
            return await _userService.GetUserByIDAsync(id);
        }
    }
}
