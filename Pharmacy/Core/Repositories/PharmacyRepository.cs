using System;
using Pharmacy.Models;
using Pharmacy.Data;
using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Core.Repositories
{
	public class PharmacyRepository : GenericRepository<PharmacyModel>, IPharmacyRepository
	{
		public PharmacyRepository(ApiDBContext context, ILogger logger): base(context, logger)
		{
		}

		//public override async Task<PharmacyModel?> GetByID(int id)
		//{
		//	try
		//	{
		//		return await _context.Pharmacies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		//	}
		//	catch(Exception e)
		//	{
		//		Console.Write(e);
		//		throw;
		//	}
		//} 

	}
}

