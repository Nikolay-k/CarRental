using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    using Helpers;
    using Infrastructure.Entities;
    using Infrastructure.Storage;
    using Models;
    using Models.OrderViewModels;

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(
            ILogger<OrdersController> logger,
            IUnitOfWork unitOfWork
        )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = new GetFormResponseModel<OrderListViewModel>
                {
                    Model = new OrderListViewModel
                    {
                        Orders = await _unitOfWork.OrderRepository.Query
                        .Include(x => x.User)
                        .Include(x => x.Car)
                        .Select(x => new OrderViewModel
                        {
                            Id = x.Id,
                            UserId = x.UserId,
                            UserName = x.User.ToString(),
                            CarId = x.CarId,
                            CarName = x.Car.ToString(),
                            RentalStartDate = x.RentalStartDate,
                            RentalEndDate = x.RentalEndDate,
                            Comment = x.Comment
                        })
                        .ToArrayAsync()
                    }
                };
                return model.CreateSucceededResult();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "api/Orders GET technical error");
                return new GetFormResponseModel<OrderListViewModel>().CreateFailedResult("Sorry there was a technical error. Try to retry the request or contact technical support.");
            }
        }

        // GET: api/Orders/{id}
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var isNewOrder = id == 0;

                OrderViewModel orderViewModel;
                if (isNewOrder)
                    orderViewModel = new OrderViewModel();
                else
                {
                    orderViewModel = await _unitOfWork.OrderRepository.Query
                    .Select(x => new OrderViewModel
                    {
                        Id = x.Id,
                        UserId = x.UserId,
                        CarId = x.CarId,
                        RentalStartDate = x.RentalStartDate,
                        RentalEndDate = x.RentalEndDate,
                        Comment = x.Comment
                    })
                    .SingleOrDefaultAsync(x => x.Id == id);
                    if (orderViewModel == null)
                        return new GetFormResponseModel<OrderViewModel, OrderViewBag>().CreateFailedResult($"Order {id} not found");
                }

                var usersBag = await _unitOfWork.UserRepository.Query
                    .Select(x => new SelectItemViewModel { Value = x.Id.ToString(), Text = x.ToString() })
                    .ToArrayAsync();

                var carsBag = await _unitOfWork.CarRepository.Query
                    .Select(x => new SelectItemViewModel { Value = x.Id.ToString(), Text = x.ToString() })
                    .ToArrayAsync();

                var model = new GetFormResponseModel<OrderViewModel, OrderViewBag>
                {
                    Model = orderViewModel,
                    Bag = new OrderViewBag
                    {
                        Users = usersBag,
                        Cars = carsBag
                    }
                };
                return model.CreateSucceededResult();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "api/Orders/{id} GET technical error");
                return new GetFormResponseModel<OrderViewModel, OrderViewBag>().CreateFailedResult("Sorry there was a technical error. Try to retry the request or contact technical support.");
            }
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderViewModel model)
        {
            try
            {
                var isNewOrder = model.Id == 0;

                Order order;
                if (isNewOrder)
                    order = new Order();
                else
                {
                    order = await _unitOfWork.OrderRepository.GetObjectAsync(model.Id);
                    if (order == null)
                        return new PostFormResponseModel().CreateFailedResult($"Order {model.Id} not found");
                }

                order.UserId = model.UserId.Value;
                order.CarId = model.CarId.Value;
                order.RentalStartDate = model.RentalStartDate.Value;
                order.RentalEndDate = model.RentalEndDate.Value;
                order.Comment = model.Comment;

                if (isNewOrder)
                    _unitOfWork.OrderRepository.AddObject(order);

                await _unitOfWork.Context.SaveChangesAsync();

                return new PostFormResponseModel().CreateSucceededResult();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "api/Orders POST technical error");
                return new PostFormResponseModel().CreateFailedResult("Sorry there was a technical error. Try to retry the request or contact technical support.");
            }
        }

        // DELETE: api/Orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetObjectAsync(id);
                if (order == null)
                    return ActionResultHelper.CreateFailedResult($"Order {id} not found");

                _unitOfWork.OrderRepository.RemoveObject(order);
                await _unitOfWork.Context.SaveChangesAsync();

                return ActionResultHelper.CreateSucceededResult();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "api/Orders/{id} DELETE technical error");
                return ActionResultHelper.CreateFailedResult("Sorry there was a technical error. Try to retry the request or contact technical support.");
            }
        }
    }
}