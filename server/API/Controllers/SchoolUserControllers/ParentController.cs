using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.ViewModels.SchoolUsers.Parent;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;

namespace SchoolBook.API.Controllers.SchoolUserControllers
{
    [Route("parents")]
    [ApiController]
    [Produces("application/json")]
    public class ParentController : BaseController
    {
        private IParentService ParentService;

        public ParentController(
            IParentService parentService,
            ILogger<BaseController> logger
            ) : base(logger)
        {
            ParentService = parentService;
        }

        [HttpGet("school/{schoolId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal")]
        public IEnumerable<ParentViewModel> GetAllParentsFromSchool(string schoolId)
        {
            return ParentService.GetAllParentsFromSchool(schoolId);
        }
        
        [HttpGet("dialog/{parentId}")]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin, Principal")]
        public ParentDialogViewModel GetParentDialogData(string parentId)
        {
            return ParentService.GetParentDialogData(parentId);
        }
    }
}