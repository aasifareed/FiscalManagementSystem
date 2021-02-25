using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace FiscalManagementSystem.Localization
{
    public static class FiscalManagementSystemLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(FiscalManagementSystemConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(FiscalManagementSystemLocalizationConfigurer).GetAssembly(),
                        "FiscalManagementSystem.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
