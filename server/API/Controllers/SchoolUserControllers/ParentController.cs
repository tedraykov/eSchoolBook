using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolBook.BusinessLogicLayer.DTOs.Models.SchoolUserModels;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;

namespace SchoolBook.API.Controllers.SchoolUserControllers
{
    [Route("parent")]
    [Produces("application/json")]
    public class ParentController : BaseController
    {
        private readonly ILogger<BaseController> _logger;
        private readonly IParentService _parentService;

        public ParentController(
            ILogger<BaseController> logger,
            IParentService parentService) : base(logger)
        {
            _logger = logger;
            _parentService = parentService;
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin, SchoolAdmin")]
        public async Task Create([FromBody] ParentModel parentModel)
        {
            await _parentService.AddParent(parentModel);
        }
    }
}
