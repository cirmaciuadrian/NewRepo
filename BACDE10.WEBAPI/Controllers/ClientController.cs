using BACDE10.BusinessLogic.Interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BACDE10.WEBAPI.Controllers;

public class ClientController : BaseController
{
    private readonly IClientService _clientService;

	public ClientController(IClientService clientService)
	{
		_clientService = clientService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllAsync()
	{
		return Ok(await _clientService.GetAsync());
	}
	
}
