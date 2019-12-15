using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.API.Controllers
{
    [Route("api/user")]
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
                IQueryable<SchoolUser> users = _repositories.SchoolUsers.Query();
                return Ok(_mapper.Map<IEnumerable<SchoolUser>, IEnumerable<UserViewModel>>(users));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}