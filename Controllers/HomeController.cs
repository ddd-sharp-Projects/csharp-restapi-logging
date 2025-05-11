using Microsoft.AspNetCore.Mvc;
using Common.Classes;

[ApiController]
[Route("customers")]
public class HomeController : ControllerBase
{
    private readonly ICustomerService _customerService;
    public HomeController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        LogFile.Log("Index method called");


        return Ok("Testing");
    }

    [HttpPost]
    public IActionResult Index([FromBody] CreateCustomerDto createCustomerDto)
    {
        var instanceId = Guid.NewGuid();
        LogFile.Log($"InstanceId: {instanceId} | Request=> " + System.Text.Json.JsonSerializer.Serialize(createCustomerDto));

        if (createCustomerDto == null)
        {
            LogFile.Log("Request is null");
            return BadRequest($"InstanceId: {instanceId} Response=> Request is null");
        }

        if (string.IsNullOrEmpty(createCustomerDto.Name) || string.IsNullOrEmpty(createCustomerDto.Email) || string.IsNullOrEmpty(createCustomerDto.Phone))
        {
            LogFile.Log($"InstanceId: {instanceId} Response=> Request is invalid");
            return BadRequest("Request is invalid");
        }

        ResponseCustomerDto responseCustomerDto = _customerService.CreateCustomer(createCustomerDto);


        LogFile.Log($"InstanceId: {instanceId} | Response=> " + System.Text.Json.JsonSerializer.Serialize(responseCustomerDto));

        return Ok(responseCustomerDto);
    }
}
