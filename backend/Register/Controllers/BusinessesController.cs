using AutoMapper;
using backend.Register.Domain.Models;
using backend.Register.Domain.Services;
using backend.Register.Resources;
using backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace backend.Register.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class BusinessesController: ControllerBase
{
    private readonly IBusinessService _businessService;
    private readonly IMapper _mapper;

    public BusinessesController(IBusinessService businessService, IMapper mapper)
    {
        _businessService = businessService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<BusinessResource>> GetAllAsync()
    {
        
        var businesses = await _businessService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Business>, IEnumerable<BusinessResource>>(businesses);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveBusinessResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var business = _mapper.Map<SaveBusinessResource, Business>(resource);

        var result = await _businessService.CreateAsync(business);

        if (!result.Success)
            return BadRequest(result.Message);

        var clientResource = _mapper.Map<Business, BusinessResource>(result.Resource);
        return Ok(clientResource);
    }
}