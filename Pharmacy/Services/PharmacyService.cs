using System;
using Microsoft.EntityFrameworkCore;
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
            return await Pharmacies.Add(pharmacy);
        }

        public bool Update(PharmacyModel pharmacy)
        {
            pharmacy.LastUpdate = DateTime.Now;
            return Pharmacies.Update(pharmacy);
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

