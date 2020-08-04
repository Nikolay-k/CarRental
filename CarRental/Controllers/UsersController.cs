using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    using Helpers;
    using Infrastructure.Storage;
    using Models;
    using Models.UserViewModels;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(
            ILogger<UsersController> logger,
            IUnitOfWork unitOfWork
        )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = new GetFormResponseModel<UserListViewModel>
                {
                    Model = new UserListViewModel
                    {
                        Users = await _unitOfWork.UserRepository.Query
                            .Select(x => new UserViewModel
                            {
                                Id = x.Id,
                                Surname = x.Surname,
                                Name = x.Name,
                                BirthDate = x.BirthDate,
                                DrivingLicenseNumber = x.DrivingLicenseNumber
                            })
                            .ToArrayAsync()
                    }
                };
                return model.CreateSucceededResult();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "api/Users GET technical error");
                return new GetFormResponseModel<UserListViewModel>().CreateFailedResult("Sorry there was a technical error. Try to retry the request or contact technical support.");
            }
        }
    }
}
