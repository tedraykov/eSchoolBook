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
        protected IMapper Mapper { get; set; }
        protected ILogger<BaseService> Logger { get; set; }
        
        public BaseService(
            IRepositories repositories,
            ILogger<BaseService> logger,
            IMapper mapper)
        {
            this.Repositories = repositories;
            this.Logger = logger;
            this.Mapper = mapper;
        }

    }
}
