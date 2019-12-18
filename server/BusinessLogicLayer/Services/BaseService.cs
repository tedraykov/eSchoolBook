using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.BusinessLogicLayer.Services
{
    public class BaseService
    {
        protected IRepositories Repositories;
        protected UserManager<User> UserManager { get; set; }
        protected IMapper Mapper { get; set; }
        protected ILogger<BaseService> Logger { get; set; }
        
        public BaseService(
            IRepositories repositories,
            UserManager<User> userManager,
            ILogger<BaseService> logger,
            IMapper mapper)
        {
            this.Repositories = repositories;
            this.UserManager = userManager;
            this.Logger = logger;
            this.Mapper = mapper;
        }

    }
}
