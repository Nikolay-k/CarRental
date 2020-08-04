using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace CarRental.Helpers
{
    using Models;
    public static class ActionResultHelper
    {
        public static IActionResult CreateSucceededResult<T>(this T model, string message = null) where T : PostFormResponseModel
        {
            model.Result.Success = true;
            model.Result.Message = message;
            return new JsonResult(model);
        }

        public static IActionResult CreateSucceededResult<TModel>(this GetFormResponseModel<TModel> model, string message = null)
        {
            model.Result.Success = true;
            model.Result.Message = message;
            return new JsonResult(model);
        }

        public static IActionResult CreateSucceededResult<TModel, TBag>(this GetFormResponseModel<TModel, TBag> model, string message = null)
        {
            model.Result.Success = true;
            model.Result.Message = message;
            return new JsonResult(model);
        }

        public static IActionResult CreateSucceededResult<T>(string message = null) where T : PostFormResponseModel, new()
        {
            var model = new T();
            model.Result.Success = true;
            model.Result.Message = message;
            return new JsonResult(model);
        }

        public static IActionResult CreateSucceededResult(string message = null)
        {
            var model = new ResultResponseModel
            {
                Success = true,
                Message = message
            };
            return new JsonResult(model);
        }

        public static IActionResult CreateFailedResult<T>(this T model, params string[] errors) where T : PostFormResponseModel
        {
            model.Result.Success = false;
            model.Result.Errors = errors;
            return new JsonResult(model);
        }

        public static IActionResult CreateFailedResult<TModel>(this GetFormResponseModel<TModel> model, params string[] errors) where TModel : new()
        {
            model.Model = new TModel();
            model.Result.Success = false;
            model.Result.Errors = errors;
            return new JsonResult(model);
        }

        public static IActionResult CreateFailedResult<TModel, TBag>(this GetFormResponseModel<TModel, TBag> model, params string[] errors) where TModel : new() where TBag : new()
        {
            model.Model = new TModel();
            model.Bag = new TBag();
            model.Result.Success = false;
            model.Result.Errors = errors;
            return new JsonResult(model);
        }

        public static IActionResult CreateFailedResult<T>(params string[] errors) where T : PostFormResponseModel, new()
        {
            var model = new T();
            model.Result.Errors = errors;
            return new JsonResult(model);
        }

        public static IActionResult CreateFailedResult(params string[] errors)
        {
            var model = new ResultResponseModel
            {
                Errors = errors
            };
            return new JsonResult(model);
        }

        public static IActionResult CreateFailedResult<T>(ModelStateDictionary modelState) where T : PostFormResponseModel, new()
        {
            var model = new T();
            model.Result.Errors = GetModelErrors(modelState);
            return new JsonResult(model);
        }

        public static IActionResult CreateFailedResult<T>(IdentityResult result) where T : PostFormResponseModel, new()
        {
            var model = CreateFailedModel<T>(result);
            return new JsonResult(model);
        }

        public static T CreateFailedModel<T>(IdentityResult result) where T : PostFormResponseModel, new()
        {
            var model = new T();
            model.Result.Errors = GetIdentityErrors(result);
            return model;
        }

        private static string[] GetModelErrors(ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToArray();
        }

        private static string[] GetIdentityErrors(IdentityResult result)
        {
            return result.Errors
                .Where(x => x.Code != "DuplicateUserName") //UserName is the same as EMail
                .Select(x => x.Description)
                .ToArray();
        }
    }
}
