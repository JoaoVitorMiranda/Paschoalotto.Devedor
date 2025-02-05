﻿//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paschoalotto.Devedor.Domain.Interfaces.Services;
using Paschoalotto.Devedor.Domain.Models;

namespace Paschoalotto.Devedor.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : ControllerBase
    {
        private readonly DefaultAPIResponse _response;

        public BaseController()
        {
            _response = new DefaultAPIResponse();
        }

        [NonAction]
        protected ActionResult CreaterResponse(IServiceBase serviceBase, object data)
        {
            _response.Data = data;
            _response.Success = !serviceBase.HasNotifications;
            _response.Notifications = serviceBase.GetNotifications();

            if (!_response.Success)
                return BadRequest(_response);

            return Ok(_response);
        }
    }
}
