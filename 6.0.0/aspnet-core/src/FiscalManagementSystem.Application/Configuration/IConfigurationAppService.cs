using System.Threading.Tasks;
using FiscalManagementSystem.Configuration.Dto;

namespace FiscalManagementSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
