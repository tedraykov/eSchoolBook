using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.BusinessLogicLayer.Services
{
    public class BaseService
    {
        protected IRepositories Repositories;
        protected UserManager<User> UserManager { get; set; }
        protected IMapper Mapper { get; set; }
        
        public BaseService(
            IRepositories repositories,
            UserManager<User> userManager,
            IMapper mapper)
        {
            this.Repositories = repositories;
            this.UserManager = userManager;
            this.Mapper = mapper;
        }

    }
}
