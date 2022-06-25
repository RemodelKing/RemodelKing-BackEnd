using AutoMapper;
using backend.Register.Domain.Models;
using backend.Register.Resources;
using backend.Security.Authorization.Attributes;
using backend.Security.Domain.Models;
using backend.Security.Domain.Services;
using backend.Security.Domain.Services.Communication;
using backend.Security.Resources;
using backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace backend.Security.Controllers;

[AuthorizeClient]
[ApiController]
[Route("/api/v1/[controller]")]
public class UsersClientController : ControllerBase
{
    private readonly IUserClientService _userClientService;
    private readonly IMapper _mapper;

    public UsersClientController(IUserClientService userClientService, IMapper mapper)
    {
        _userClientService = userClientService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> Authenticate(AuthenticateClientRequest request)
    {
        var response = await _userClientService.Authenticate(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterClientRequest request)
    {
        //var model = _mapper.Map<RegisterRequest, Client>(request);
        var response = await _userClientService.RegisterAsync(request);
        //if (!result.Success)
          //  return BadRequest(result.Message);
        //var resource = _mapper.Map<Client, RegisterRequest>(result.Resource);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userClientService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<UserClientResource>>(users);
        return Ok(resources);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userClientService.GetByIdAsync(id);
        var resource = _mapper.Map<Client, UserClientResource>(user);

        return Ok(resource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateClientRequest request)
    {
        await _userClientService.UpdateAsync(id, request);
        return Ok(new { message = "User updated successfully" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userClientService.DeleteAsync(id);
        return Ok(new { message = "User deleted successfully" });
    }
}