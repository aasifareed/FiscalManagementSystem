using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using FiscalManagementSystem.Configuration.Dto;

namespace FiscalManagementSystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FiscalManagementSystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
