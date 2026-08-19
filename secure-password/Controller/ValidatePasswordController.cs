using Microsoft.AspNetCore.Mvc;
using secure_password.Dtos;
using secure_password.Services;

namespace secure_password.Controllers;

[ApiController]
[Route("validate-password")]
public sealed class ValidatePasswordController : ControllerBase
{
    private readonly IPasswordValidator _validator;

    public ValidatePasswordController(IPasswordValidator validator)
    {
        _validator = validator;
    }

    [HttpPost]
    public IActionResult Post([FromBody] ValidatePasswordRequest request)
    {
        if (_validator.Validate(request.Password, out var errors))
            return NoContent();

        return BadRequest(new { errors });
    }
}
