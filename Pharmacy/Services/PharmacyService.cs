using Pharmacy.Core;
using Pharmacy.Core.Repositories;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Services
{
    public class PharmacyService : IPharmacyService, IDisposable
    {
        private readonly ApiDBContext _context;

        public PharmacyService(ApiDBContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var _logger = loggerFactory.CreateLogger("logs");

            Pharmacies = new PharmacyRepository(_context, _logger);
        }

        public IPharmacyRepository Pharmacies { get; private set; }

        public async Task<IEnumerable<PharmacyModel>> GetPharmacies()
        {
            return await Pharmacies.All();
        }

        public async Task<PharmacyModel?> GetById(int id)
        {
            return await Pharmacies.GetByID(id);
        }

        public async Task<bool> Add(PharmacyModel pharmacy)
        {
            pharmacy.CreationDate = DateTime.Now;
            return await Pharmacies.Add(pharmacy);
        }

        public async Task<bool> Update(PharmacyModel pharmacy)
        {
            var existingPharmacy = await Pharmacies.GetByID(pharmacy.Id);
            if(existingPharmacy == null)
            {
                return false;
            }
            existingPharmacy.Copy(pharmacy);
            pharmacy.LastUpdate = DateTime.Now;
            await CompleteAsync();
            return true;
        }

        public async Task<bool> Delete(PharmacyModel pharmacy)
        {
            return await Pharmacies.Delete(pharmacy);
        }


        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

