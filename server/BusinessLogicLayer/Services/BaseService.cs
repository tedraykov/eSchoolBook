using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SchoolBook.DataAccessLayer.Entities;

namespace SchoolBook.BusinessLogicLayer.Services
{
    public class BaseService
    {
        protected BaseService(
            UserManager<User> userManager,
            IMapper mapper)
        {
            this.UserManager = userManager;
            this.Mapper = mapper;
        }

        protected UserManager<User> UserManager { get; set; }

        protected IMapper Mapper { get; set; }
    }
}
