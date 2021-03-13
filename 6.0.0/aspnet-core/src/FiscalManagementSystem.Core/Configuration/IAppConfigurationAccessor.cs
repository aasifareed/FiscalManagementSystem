using Microsoft.Extensions.Configuration;

namespace FiscalManagementSystem.Configuration
{
	public interface IAppConfigurationAccessor
	{
		IConfigurationRoot Configuration { get; }
	}
}