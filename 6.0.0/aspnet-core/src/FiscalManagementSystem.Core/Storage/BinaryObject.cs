using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp;
using Abp.Domain.Entities;

namespace FiscalManagementSystem.Storage
{
	[Table("AppBinaryObjects")]
	public class BinaryObject : Entity<Guid>, IMayHaveTenant
	{
		public BinaryObject()
		{
			Id = SequentialGuidGenerator.Instance.Create();
		}

		public BinaryObject(int? tenantId, byte[] bytes)
			: this()
		{
			TenantId = tenantId;
			Bytes = bytes;
		}


		public BinaryObject(int? tenantId, byte[] bytes, string fileName, string fileDescription,
			bool internalCommunication, bool complaintDocumentation)
			: this()
		{
			TenantId = tenantId;
			Bytes = bytes;
			FileName = fileName;
			FileDescription = fileDescription;
			InternalCommunication = internalCommunication;
			ComplaintDocumentation = complaintDocumentation;
		}

		[Required] public virtual byte[] Bytes { get; set; }

		public string FileName { get; set; }
		public string FileDescription { get; set; }
		public bool InternalCommunication { get; set; }
		public bool ComplaintDocumentation { get; set; }
		public virtual int? TenantId { get; set; }
	}
}