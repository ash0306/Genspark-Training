using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Intefaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<Employee>>> Get()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();
                return Ok(employees.ToList());
            }
            catch (NoEmployeesFoundException nefe)
            {
                return NotFound(new ErrorModel(404,nefe.Message));
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(IList<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<Employee>> Put(int id, string phone)
        {
            try
            {
                var employee = await _employeeService.UpdateEmployeePhone(id, phone);
                return Ok(employee);
            }
            catch (NoSuchEmployeeException nsee)
            {
                return NotFound(new ErrorModel(404, nsee.Message));
            }
        }

        [HttpGet]//get by id using get - input via query
        [Route("GetEmployeeByPhone")]
        [ProducesResponseType(typeof(IList<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<Employee>> Get(string phone)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByPhone(phone);
                return Ok(employee);
            }
            catch(NoSuchEmployeeException nsee)
            {
                return NotFound(new ErrorModel(404, nsee.Message));
            }
        }

        [HttpPost]//get by id using post - input via body
        [ProducesResponseType(typeof(IList<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<Employee>> Post([FromBody]string phone)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByPhone(phone);
                return Ok(employee);
            }
            catch (NoSuchEmployeeException nsee)
            {
                return NotFound(new ErrorModel(404, nsee.Message));
            }
        }
    }
}
