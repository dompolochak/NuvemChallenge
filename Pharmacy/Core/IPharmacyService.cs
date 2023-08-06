using System;
using Pharmacy.Models;

namespace Pharmacy.Core
{
	public interface IPharmacyService
	{
		IPharmacyRepository Pharmacies { get; }
		Task<IEnumerable<PharmacyModel>> GetPharmacies();
		Task<PharmacyModel?> GetById(int id);
        Task<bool> Add(PharmacyModel pharmacy);
        bool Update(PharmacyModel pharmacy);
        Task<bool> Delete(PharmacyModel pharmacy);
        Task CompleteAsync();
	}
}

