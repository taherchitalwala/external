using alvazaratAPI53.Models.ApiResponse;
using alvazaratAPI53.Models.Masters;
using alvazaratAPI53.Models.specificJamaat;
using alvazaratAPI53.Repositories.Masters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace alvazaratAPI53.Controllers.Masters
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class allJamaat : ControllerBase
    {
        private readonly IallJamaatRepository _jamaatMasterRepository;
        private readonly IConfiguration _config;

        public allJamaat(IallJamaatRepository jamaatMasterRepository, IConfiguration config)
        {
            _jamaatMasterRepository = jamaatMasterRepository;
            _config = config;
        }

        [HttpGet(), ActionName("get-all-jamaats")]
        public async Task<IActionResult> GetAllJamaatList([FromQuery] string? param1 = null)
        {
            // 🔒 Check allowed IPs first
            var allowedIps = _config.GetSection("Security:AllowedIPs").Get<string[]>() ?? [];
            var remoteIp = HttpContext.Connection.RemoteIpAddress;

            bool ipAllowed = allowedIps.Any(ip =>
                IPAddress.TryParse(ip, out var allowed) &&
                allowed.Equals(remoteIp));

            if (!ipAllowed)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    ApiArrayResponse<allJamaatList>.Fail("Access denied: unauthorized request."));
            }

            if (!string.IsNullOrWhiteSpace(param1) && !int.TryParse(param1, out var jamaatId))
            {
                return BadRequest(ApiArrayResponse<specificJamaatList>.Fail("Invalid 'param1' value. It must be a number."));
            }

            // ✅ Fetch data
            var result = await _jamaatMasterRepository.GetAllJamaats(param1);

            if (result != null && result.Any())
            {
                return Ok(ApiArrayResponse<allJamaatList>.Ok(result, "All Mauze retrieved successfully"));
            }
            else
            {
                return NotFound(ApiArrayResponse<allJamaatList>.Fail("No Mauze data found."));
            }
        }
    }
}
