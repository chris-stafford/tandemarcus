using Microsoft.AspNetCore.Mvc;

namespace API.Arcus.Webservice.Controllers
{
	/// <summary>
	/// API Controller for Health Check
	/// </summary>
	[ApiController]
	public class HealthController : ControllerBase
	{

		/// <summary>
		/// Verify webservice is responding
		/// </summary>
		public HealthController()
		{
		}

		/// <summary>
		/// Health check
		/// </summary>
		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
		[HttpGet("health")]
		public ActionResult<bool> IsAlive()
		{
			return Ok(true);
		}
	}
}