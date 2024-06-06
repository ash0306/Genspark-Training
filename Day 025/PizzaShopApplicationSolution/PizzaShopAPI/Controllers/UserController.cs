using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaShopAPI.Interfaces;
using PizzaShopAPI.Models.DTOs;

namespace PizzaShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(LoginReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UserLoginDTO), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginReturnDTO>> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var result = await _userService.Login(userLoginDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("User not authorised");
                return Unauthorized(new
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Message = "Please Use Correct Credentials"
                });
            }
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(UserRegisterDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UserRegisterDTO), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserRegisterDTO>> Register(UserRegisterDTO userDTO)
        {
            try
            {
                UserRegisterDTO result = await _userService.Register(userDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("User not registered");
                return BadRequest(new
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Please Use Correct Credentials"
                });
            }
        }
    }
}
