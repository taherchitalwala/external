using alvazaratAPI53.Models.ApiResponse;
using alvazaratAPI53.Models.specificJamaat;
using alvazaratAPI53.Repositories.specificJamaat;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace alvazaratAPI53.Controllers.Murasalaat
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class specificJamaat : ControllerBase
    {
        private readonly IspecificJamaatRepository _murasalaatRepository;
        private readonly IConfiguration _config;

        public specificJamaat(IspecificJamaatRepository murasalaatRepository, IConfiguration config)
        {
            _murasalaatRepository = murasalaatRepository;
            _config = config;
        }

        [HttpGet(), ActionName("get-specific-jamaat")]
        public async Task<IActionResult> GetSpecificJamaat([FromQuery] string? param1 = null)
        {
            // 🔒 Step 1 — Validate allowed IPs
            var allowedIps = _config.GetSection("Security:AllowedIPs").Get<string[]>() ?? [];
            var remoteIp = HttpContext.Connection.RemoteIpAddress;

            bool ipAllowed = allowedIps.Any(ip =>
                IPAddress.TryParse(ip, out var allowed) && allowed.Equals(remoteIp));

            if (!ipAllowed)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    ApiArrayResponse<specificJamaatList>.Fail("Access denied: unauthorized request."));
            }

            // ❌ Step 2 — Check if param1 is missing
            if (string.IsNullOrWhiteSpace(param1))
            {
                return BadRequest(ApiArrayResponse<specificJamaatList>.Fail("The 'param1' parameter is required."));
            }

            // ⚠️ Step 3 — Validate param1 is numeric
            if (!int.TryParse(param1, out var jamaatId))
            {
                return BadRequest(ApiArrayResponse<specificJamaatList>.Fail("Invalid 'param1' value. It must be a number."));
            }

            // ✅ Step 4 — Query database
            var result = await _murasalaatRepository.GetspecificJamaat(param1);

            if (result != null && result.Any())
            {
                return Ok(ApiArrayResponse<specificJamaatList>.Ok(result, "Mauze details retrieved successfully"));
            }
            else
            {
                return NotFound(ApiArrayResponse<specificJamaatList>.Fail("No Mauze found for the given parameter."));
            }
        }
    }
}
