using vscodeApi.Interfaces;
using Clients.CleanArchitectureClient;  
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;


namespace vscodeApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class InteropController : ControllerBase
{

    private readonly ILogger<InteropController> _logger;
    private readonly IInteropService _interopService;

    public InteropController(ILogger<InteropController> logger, IInteropService interopService)
    {
        _logger = logger;
        _interopService = interopService;
    }   
 
    [HttpGet("blogs")]
    [ProducesResponseType(typeof(IEnumerable<Blog>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBlogs()
    {
        var blogs = await _interopService.GetAllBlogs();
        return Ok(blogs);
    }

}