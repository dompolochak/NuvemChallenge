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
	}
}

