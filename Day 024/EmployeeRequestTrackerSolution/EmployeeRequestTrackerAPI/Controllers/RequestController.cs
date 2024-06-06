using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Intefaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }


        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(AddRequestDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<AddRequestDTO>> AddRequest([FromBody]AddRequestDTO addRequestDTO)
        {
            try
            {
                var employeeClaimId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                int empId = Convert.ToInt32(employeeClaimId);
                AddRequestReturnDTO addRequestReturnDTO = new AddRequestReturnDTO() {
                    RequestDescription = addRequestDTO.RequestDescription,
                    RequestReaisedBy = empId
                };
                var request = await _requestService.AddRequest(addRequestReturnDTO);
                return Ok(addRequestReturnDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("GetAllAdminRequests")]
        [HttpGet]
        [ProducesResponseType(typeof(Request), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Request>>> GetAdminRequest()
        {
            try
            {
                var requests = (await _requestService.GetAllAdminRequests()).ToList();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [Authorize(Roles = "User")]
        [Route("GetAllUserRequests")]
        [HttpGet]
        [ProducesResponseType(typeof(Request), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Request>>> GetUserRequest()
        {
            try
            {
                var employeeClaimId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                int empId = Convert.ToInt32(employeeClaimId);
                var requests = (await _requestService.GetAllUserRequests(empId)).ToList();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }
    }
}
