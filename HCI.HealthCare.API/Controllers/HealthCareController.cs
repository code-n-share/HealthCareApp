using System.Net;
using HCI.HealthCare.API.Domain;
using HCI.HealthCare.API.Exceptions;
using HCI.HealthCare.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models = HCI.HealthCare.API.Models;

namespace HCI.HealthCare.API.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthCareController : ControllerBase
{
    readonly ILogger<HealthCareController> _logger;
    private readonly IHealthCareService _healthCareService;
    public HealthCareController(ILogger<HealthCareController> logger, IHealthCareService healthCareService)
    {
        _logger = logger;
        _healthCareService = healthCareService;
    }

    [HttpGet("{patientId}/visitData")]
    public async Task<IActionResult> Get(string patientId)
    {
        try
        {
            var data = await _healthCareService.GetPatientVisitInfo(patientId);
            if(data == null){
                return NotFound($"PatientId: {patientId} not found");
            }
            return Ok(data);
        }
        catch (Exception ex)
        {
             _logger.LogError("Error while fetching patient visit info", ex);
            return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong!");
        }
    }

    [HttpPost("book-appointment")]
    public async Task<IActionResult> Post(BookAppointmentDto appointment)
    {
        try
        {
            var data = await _healthCareService.BookAppointment(appointment);

            return Ok(data);
        }
        catch(PatientNotFoundException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch(PractitionerNotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
             _logger.LogError("Error while fetching patient visit info", ex);
            return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong!");
        }
    }

    [HttpGet("getAllVisits")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var data = await _healthCareService.GetAllVisitData();
            if(data == null){
                return NotFound("No vists found");
            }
            return Ok(data);
        }
        catch (Exception ex)
        {
             _logger.LogError("Error while fetching patient visit info", ex);
            return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong!");
        }
    }


    [HttpGet("getAllPatients")]
    public async Task<IActionResult> GetAllPatients()
    {
        try
        {
            var data = await _healthCareService.GetAllPatients();
            if(data == null){
                return NotFound("No patient found");
            }
            return Ok(data);
        }
        catch (Exception ex)
        {
             _logger.LogError("Error while fetching patients", ex);
            return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong!");
        }
    }

    [HttpGet("getAllPractitioners")]
    public async Task<IActionResult> GetAllPractitioners()
    {
        try
        {
            var data = await _healthCareService.GetAllPractitioners();
            if(data == null){
                return NotFound("No practitioner found");
            }
            return Ok(data);
        }
        catch (Exception ex)
        {
             _logger.LogError("Error while fetching practitioners", ex);
            return StatusCode((int)HttpStatusCode.InternalServerError, "Something went wrong!");
        }
    }
}