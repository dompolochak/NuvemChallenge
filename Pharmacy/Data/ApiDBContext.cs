using System;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Models;

namespace Pharmacy.Data
{
	public class ApiDBContext : DbContext
	{
		public DbSet<PharmacyModel> Pharmacies { get; set; }
		public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options)
		{
		}
	}
}

