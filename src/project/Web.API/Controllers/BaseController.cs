using Core.Security.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

public class BaseController : ControllerBase
{
    protected int GetUserIdFromRequest()
    {
        int userId = HttpContext.User.GetUserId();
        return userId;
    }
    
    protected string GetIpAddress()
    {
        string ipAddress = Request.Headers.ContainsKey("X-Forwarded-For")
            ? Request.Headers["X-Forwarded-For"].ToString()
            : HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString()
              ?? throw new InvalidOperationException("IP address cannot be retrieved from request.");
        return ipAddress;
    }
}