using System;
namespace Pharmacy.Models
{
	public class PharmacyModel
	{
		public void Copy(PharmacyModel pharmacy)
		{
			this.Name = pharmacy.Name;
			this.Address = pharmacy.Address;
			this.City = pharmacy.City;
			this.State = pharmacy.State;
			this.ZipCode = pharmacy.ZipCode;
			this.NumOfFilledPrescriptions = pharmacy.NumOfFilledPrescriptions;
		}

		public int Id { get; set; }

		public required string Name { get; set; }

		public required string Address { get; set; }

		public required string City { get; set; }

		public required string State { get; set; }

		public int ZipCode { get; set; }

		public int NumOfFilledPrescriptions { get; set; }

		public DateTime CreationDate { get; set; }

		public DateTime LastUpdate { get; set; }

		
	}
}

