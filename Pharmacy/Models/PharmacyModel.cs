using System;
namespace Pharmacy.Models
{
	public class PharmacyModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Address { get; set; }

		public string City { get; set; }

		public string State { get; set; }

		public int ZipCode { get; set; }

		public int NumOfFilledPrescriptions { get; set; }

		public DateTime CreationDate { get; set; }

		public DateTime LastUpdate { get; set; }

		
	}
}

