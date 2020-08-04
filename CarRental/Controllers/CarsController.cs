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
    using Models.CarViewModels;

    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CarsController(
            ILogger<CarsController> logger,
            IUnitOfWork unitOfWork
        )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = new GetFormResponseModel<CarListViewModel>
                {
                    Model = new CarListViewModel
                    {
                        Cars = await _unitOfWork.CarRepository.Query
                            .Select(x => new CarViewModel
                            {
                                Id = x.Id,
                                Brand = x.Brand,
                                Model = x.Model,
                                Class = x.Class,
                                IssueYear = (ushort)x.IssueYear,
                                RegistrationNumber = x.RegistrationNumber,
                            })
                            .ToArrayAsync()
                    }
                };
                return model.CreateSucceededResult();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "api/Cars GET technical error");
                return new GetFormResponseModel<CarListViewModel>().CreateFailedResult("Sorry there was a technical error. Try to retry the request or contact technical support.");
            }
        }
    }
}