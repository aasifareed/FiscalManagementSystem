using Abp.Dependency;

namespace FiscalManagementSystem.Storage
{
	public interface ITempFileCacheManager : ITransientDependency
	{
		void SetFile(string token, byte[] content);

		byte[] GetFile(string token);
	}
}