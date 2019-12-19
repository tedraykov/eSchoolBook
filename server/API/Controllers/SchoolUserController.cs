using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Produces("application/json")]
    public class SchoolUserController : Controller
    {
        private readonly IRepositories _repositories;
        private readonly IMapper _mapper;

        public SchoolUserController(IRepositories repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserViewModel>> Get()
        {
            try
            {
                var users = _repositories.SchoolUsers.Query();
                return Ok(_mapper
                    .Map<IEnumerable<SchoolUser>, IEnumerable<UserViewModel>>(
                        users));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SchoolUserModel> Get(string id)
        {
            try
            {
                var user = _repositories.SchoolUsers.Query()
                    .SingleOrDefault(x => x.Id == id);
                return Ok(_mapper.Map<SchoolUser, SchoolUserModel>(user));
            }
            catch (Exception e)
            {
                return NotFound("User not found");
            }
        }
    }
}
