using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Core;
using Pharmacy.Models;

namespace Pharmacy.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PharmacyController: ControllerBase
	{
		private readonly IPharmacyService _service;
		public PharmacyController(IPharmacyService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await _service.GetPharmacies());
		}

		[HttpGet]
		[Route("GetById")]
		public async Task<IActionResult> GetById(int id)
		{
			var pharmacy = await _service.GetById(id);

			if(pharmacy == null)
			{
				return NotFound();
			}

			return Ok(pharmacy);
		}

		[HttpPost]
		[Route("PostPharmacy")]
		public async Task<IActionResult> Post(PharmacyModel pharmacy)
		{
			await _service.Add(pharmacy);
			await _service.CompleteAsync();
			return Ok();
		}

		[HttpDelete]
		[Route("DeletePharmacy")]
		public async Task<IActionResult> Delete(int id)
		{
            var pharmacy = await _service.GetById(id);

            if (pharmacy == null)
            {
                return NotFound();
            }

			await _service.Delete(pharmacy);
			await _service.CompleteAsync();

			return NoContent();
        }

		[HttpPut]
		[Route("UpdatePharmacy")]
		public async Task<IActionResult> Update(PharmacyModel pharmacy)
		{
			var result = await _service.Update(pharmacy);
			return result == true ? Ok() : NotFound();
		}

		[HttpPatch]
		[Route("PartialUpdatePharmacy")]
		public async Task<IActionResult> Patch(int id, JsonPatchDocument<PharmacyModel> patchDocument)
		{
			var existingPharmacy = await _service.GetById(id);

			if(existingPharmacy == null)
			{
				return NotFound();
			}

			patchDocument.ApplyTo(existingPharmacy, ModelState);

			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			existingPharmacy.LastUpdate = DateTime.Now;
			await _service.CompleteAsync();

            return NoContent();

		}
	}
}

