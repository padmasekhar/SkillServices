using Microsoft.AspNetCore.Mvc;
using SkillServices.Api.Constants;
using SkillServices.Api.Util;

namespace SkillServices.Api.Controllers
{
    [ApiController]
    public abstract class AppBaseController : ControllerBase
    {
        public AppBaseController(IConfiguration config, ILogger logger)
        {
            Configuration = config;
            Logger = logger;
        }
        public IConfiguration Configuration { get; set; }
        public ILogger Logger { get; set; }

        [NonAction]
        protected NotFoundObjectResult NotFoundWrapper<T>(int id, string msg = "") where T : class
        {
            ApiResponse<T> response = new ApiResponse<T>();
            response.IsSuccess = false;
            response.Message = string.IsNullOrWhiteSpace(msg) ? $"No result found for give id {id}" : msg;
            response.Payload = null;
            return NotFound(response);
        }

        [NonAction]
        protected NotFoundObjectResult NotFoundWrapper<T>(string msg = "") where T : class
        {
            ApiResponse<T> response = new ApiResponse<T>();
            response.IsSuccess = false;
            response.Message = string.IsNullOrWhiteSpace(msg) ? $"No records found!" : msg;
            response.Payload = null;
            return NotFound(response);
        }

        [NonAction]
        protected NotFoundObjectResult NotFoundWrapper(int[] ids, string msg = "")
        {
            ApiResponse<object> response = new ApiResponse<object>();
            response.IsSuccess = false;
            response.Message = string.IsNullOrWhiteSpace(msg) ? $"No result found for give id {string.Join(',', ids)}" : msg;
            response.Payload = Array.Empty<int[]>();
            return NotFound(response);
        }

        [NonAction]
        protected NotFoundObjectResult NotFoundWrapper(int id)
        {
            ApiResponse<object> response = new ApiResponse<object>();
            response.IsSuccess = false;
            response.Message = $"No result found for give id {id}";
            response.Payload = null;
            return NotFound(response);
        }

        [NonAction]
        protected OkObjectResult OkWrapper<T>(bool isSuccess, string msg, T data)
        {
            ApiResponse<T> response = new ApiResponse<T>();
            response.IsSuccess = isSuccess;
            response.Message = msg;
            response.Payload = data;
            return Ok(response);
        }
        [NonAction]
        protected OkObjectResult OkWrapper(bool isSuccess, string msg)
        {
            ApiResponse<object> response = new ApiResponse<object>();
            response.IsSuccess = isSuccess;
            response.Message = msg;
            response.Payload = null;
            return Ok(response);
        }
        [NonAction]
        protected OkObjectResult OkWrapper<T>(string msg, T data)
        {
            ApiResponse<T> response = new ApiResponse<T>();
            response.IsSuccess = true;
            response.Message = msg;
            response.Payload = data;
            return Ok(response);
        }
        [NonAction]
        protected OkObjectResult OkWrapper<T>(T data)
        {
            ApiResponse<T> response = new ApiResponse<T>();
            response.IsSuccess = true;
            response.Message = AppConstants.SUCCESS;
            response.Payload = data;
            return Ok(response);
        }
        [NonAction]
        protected OkObjectResult OkWrapper()
        {
            ApiResponse<object> response = new ApiResponse<object>();
            response.IsSuccess = true;
            response.Message = AppConstants.SUCCESS;
            response.Payload = null;
            return Ok(response);
        }
    }
}
