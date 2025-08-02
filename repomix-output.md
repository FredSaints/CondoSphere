This file is a merged representation of a subset of the codebase, containing files not matching ignore patterns, combined into a single document by Repomix.

# File Summary

## Purpose
This file contains a packed representation of a subset of the repository's contents that is considered the most important context.
It is designed to be easily consumable by AI systems for analysis, code review,
or other automated processes.

## File Format
The content is organized as follows:
1. This summary section
2. Repository information
3. Directory structure
4. Repository files (if enabled)
5. Multiple file entries, each consisting of:
  a. A header with the file path (## File: path/to/file)
  b. The full contents of the file in a code block

## Usage Guidelines
- This file should be treated as read-only. Any changes should be made to the
  original repository files, not this packed version.
- When processing this file, use the file path to distinguish
  between different files in the repository.
- Be aware that this file may contain sensitive information. Handle it with
  the same level of security as you would the original repository.

## Notes
- Some files may have been excluded based on .gitignore rules and Repomix's configuration
- Binary files are not included in this packed representation. Please refer to the Repository Structure section for a complete list of file paths, including binary files
- Files matching these patterns are excluded: **/*.jpg, **/*.png, **/*.csproj, **/*.sln, **/lib/**, **/bin/**, **/obj/**, **/Migrations/**, **/migrations/**, **/*.user, **/.github/**, .gitignore
- Files matching patterns in .gitignore are excluded
- Files matching default ignore patterns are excluded
- Files are sorted by Git change count (files with more changes are at the bottom)

# Directory Structure
```
.vs/CondoSphere/config/applicationhost.config
.vs/CondoSphere/v17/DocumentLayout.backup.json
.vs/CondoSphere/v17/DocumentLayout.json
.vs/CondoSphere/v17/HierarchyCache.v1.txt
.vs/VSWorkspaceState.json
CondoSphere.API/appsettings.Development.json
CondoSphere.API/appsettings.json
CondoSphere.API/CondoSphere.API.http
CondoSphere.API/Controllers/AccountsController.cs
CondoSphere.API/Controllers/CondominiumsController.cs
CondoSphere.API/Controllers/ResidentsController.cs
CondoSphere.API/Controllers/UnitsController.cs
CondoSphere.API/Program.cs
CondoSphere.API/Properties/launchSettings.json
CondoSphere.Application/Authorization/IsCondoManagerRequirement.cs
CondoSphere.Application/Interfaces/ICompanyRepository.cs
CondoSphere.Application/Interfaces/ICondominiumRepository.cs
CondoSphere.Application/Interfaces/ICurrentUserService.cs
CondoSphere.Application/Interfaces/IMailService.cs
CondoSphere.Application/Interfaces/IUnitOfWork.cs
CondoSphere.Application/Interfaces/IUnitRepository.cs
CondoSphere.Application/Interfaces/IUserRepository.cs
CondoSphere.Application/Mappings/CondominiumProfile.cs
CondoSphere.Application/Mappings/UnitProfile.cs
CondoSphere.Application/Services/Condominium/CondominiumService.cs
CondoSphere.Application/Services/Condominium/ICondominiumService.cs
CondoSphere.Application/Services/Condominium/IUnitService.cs
CondoSphere.Application/Services/Condominium/UnitService.cs
CondoSphere.Application/Services/Token/ITokenService.cs
CondoSphere.Application/Services/Token/TokenService.cs
CondoSphere.Application/Services/User/IUserService.cs
CondoSphere.Application/Services/User/UserService.cs
CondoSphere.Application/Validators/Condominiums/CreateUpdateCondominiumDtoValidator.cs
CondoSphere.Application/Validators/Condominiums/CreateUpdateUnitDtoValidator.cs
CondoSphere.Core/DTOs/Account/AssignManagerDto.cs
CondoSphere.Core/DTOs/Account/LoginDto.cs
CondoSphere.Core/DTOs/Account/RegisterDto.cs
CondoSphere.Core/DTOs/Account/RegisterManagerDto.cs
CondoSphere.Core/DTOs/Account/RegisterResidentDto.cs
CondoSphere.Core/DTOs/Account/SetPasswordDto.cs
CondoSphere.Core/DTOs/Account/UserDto.cs
CondoSphere.Core/DTOs/Account/UserListDto.cs
CondoSphere.Core/DTOs/Condominiums/CondominiumDto.cs
CondoSphere.Core/DTOs/Condominiums/CreateUpdateCondominiumDto.cs
CondoSphere.Core/DTOs/Condominiums/CreateUpdateUnitDto.cs
CondoSphere.Core/DTOs/Condominiums/UnitDto.cs
CondoSphere.Core/Entities/Condominiums/Assembly.cs
CondoSphere.Core/Entities/Condominiums/Condominium.cs
CondoSphere.Core/Entities/Condominiums/Document.cs
CondoSphere.Core/Entities/Condominiums/Intervention.cs
CondoSphere.Core/Entities/Condominiums/Occurrence.cs
CondoSphere.Core/Entities/Condominiums/Unit.cs
CondoSphere.Core/Entities/Financials/Expense.cs
CondoSphere.Core/Entities/Financials/QuotaPayment.cs
CondoSphere.Core/Entities/Financials/Receipt.cs
CondoSphere.Core/Entities/Financials/UnitQuota.cs
CondoSphere.Core/Entities/Users/Company.cs
CondoSphere.Core/Entities/Users/Notification.cs
CondoSphere.Core/Entities/Users/User.cs
CondoSphere.Core/Enums/InterventionStatus.cs
CondoSphere.Core/Enums/OccurrenceStatus.cs
CondoSphere.Core/Enums/SystemRole.cs
CondoSphere.Core/Enums/UnitQuotaStatus.cs
CondoSphere.Core/IEntity.cs
CondoSphere.Core/RoleConstants.cs
CondoSphere.Infrastructure/Authorization/IsCondoManagerHandler.cs
CondoSphere.Infrastructure/Data/CondominiumDbContext.cs
CondoSphere.Infrastructure/Data/SeedDb.cs
CondoSphere.Infrastructure/Data/UserManagementDbContext.cs
CondoSphere.Infrastructure/Repositories/CompanyRepository.cs
CondoSphere.Infrastructure/Repositories/CondominiumRepository.cs
CondoSphere.Infrastructure/Repositories/UnitOfWork.cs
CondoSphere.Infrastructure/Repositories/UnitRepository.cs
CondoSphere.Infrastructure/Repositories/UserRepository.cs
CondoSphere.Infrastructure/Services/CurrentUserService.cs
CondoSphere.Infrastructure/Services/MailService.cs
CondoSphere.Web/appsettings.Development.json
CondoSphere.Web/appsettings.json
CondoSphere.Web/Controllers/AccountController.cs
CondoSphere.Web/Controllers/AdministrationController.cs
CondoSphere.Web/Controllers/CondoManagementController.cs
CondoSphere.Web/Controllers/HomeController.cs
CondoSphere.Web/Models/AssignManagerViewModel.cs
CondoSphere.Web/Models/CondominiumDetailsViewModel.cs
CondoSphere.Web/Models/ErrorViewModel.cs
CondoSphere.Web/Models/ManagementDashboardViewModel.cs
CondoSphere.Web/Models/RegisterResidentViewModel.cs
CondoSphere.Web/Program.cs
CondoSphere.Web/Properties/launchSettings.json
CondoSphere.Web/Services/ApiClient.cs
CondoSphere.Web/Services/JwtForwardingDelegatingHandler.cs
CondoSphere.Web/Views/_ViewImports.cshtml
CondoSphere.Web/Views/_ViewStart.cshtml
CondoSphere.Web/Views/Account/Login.cshtml
CondoSphere.Web/Views/Account/SetPassword.cshtml
CondoSphere.Web/Views/Administration/AssignManager.cshtml
CondoSphere.Web/Views/Administration/CreateCondominium.cshtml
CondoSphere.Web/Views/Administration/Index.cshtml
CondoSphere.Web/Views/Administration/RegisterManager.cshtml
CondoSphere.Web/Views/CondoManagement/CreateUnit.cshtml
CondoSphere.Web/Views/CondoManagement/Details.cshtml
CondoSphere.Web/Views/CondoManagement/Index.cshtml
CondoSphere.Web/Views/CondoManagement/RegisterResident.cshtml
CondoSphere.Web/Views/Home/Index.cshtml
CondoSphere.Web/Views/Home/Privacy.cshtml
CondoSphere.Web/Views/Shared/_Layout.cshtml
CondoSphere.Web/Views/Shared/_Layout.cshtml.css
CondoSphere.Web/Views/Shared/_LoginPartial.cshtml
CondoSphere.Web/Views/Shared/_ValidationScriptsPartial.cshtml
CondoSphere.Web/Views/Shared/Error.cshtml
CondoSphere.Web/wwwroot/css/site.css
CondoSphere.Web/wwwroot/js/site.js
```

# Files

## File: .vs/CondoSphere/config/applicationhost.config
```
<?xml version="1.0" encoding="UTF-8"?>
<!--

    IIS configuration sections.

    For schema documentation, see
    %IIS_BIN%\config\schema\IIS_schema.xml.
    
    Please make a backup of this file before making any changes to it.

    NOTE: The following environment variables are available to be used
          within this file and are understood by the IIS Express.

          %IIS_USER_HOME% - The IIS Express home directory for the user
          %IIS_SITES_HOME% - The default home directory for sites
          %IIS_BIN% - The location of the IIS Express binaries
          %SYSTEMDRIVE% - The drive letter of %IIS_BIN%

-->
<configuration>
	<!--

        The <configSections> section controls the registration of sections.
        Section is the basic unit of deployment, locking, searching and
        containment for configuration settings.
        
        Every section belongs to one section group.
        A section group is a container of logically-related sections.
        
        Sections cannot be nested.
        Section groups may be nested.
        
        <section
            name=""  [Required, Collection Key] [XML name of the section]
            allowDefinition="Everywhere" [MachineOnly|MachineToApplication|AppHostOnly|Everywhere] [Level where it can be set]
            overrideModeDefault="Allow"  [Allow|Deny] [Default delegation mode]
            allowLocation="true"  [true|false] [Allowed in location tags]
        />
        
        The recommended way to unlock sections is by using a location tag:
        <location path="Default Web Site" overrideMode="Allow">
            <system.webServer>
                <asp />
            </system.webServer>
        </location>

    -->
	<configSections>
		<sectionGroup name="system.applicationHost">
			<section name="applicationPools" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />
			<section name="configHistory" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />
			<section name="customMetadata" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />
			<section name="listenerAdapters" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />
			<section name="log" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />
			<section name="serviceAutoStartProviders" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />
			<section name="sites" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />
			<section name="webLimits" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />
		</sectionGroup>
		<sectionGroup name="system.webServer">
			<section name="asp" overrideModeDefault="Deny" />
			<section name="caching" overrideModeDefault="Allow" />
			<section name="cgi" overrideModeDefault="Deny" />
			<section name="defaultDocument" overrideModeDefault="Allow" />
			<section name="directoryBrowse" overrideModeDefault="Allow" />
			<section name="fastCgi" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />
			<section name="globalModules" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />
			<section name="handlers" overrideModeDefault="Deny" />
			<section name="httpCompression" overrideModeDefault="Allow" allowDefinition="Everywhere" />
			<section name="httpErrors" overrideModeDefault="Allow" />
			<section name="httpLogging" overrideModeDefault="Deny" />
			<section name="httpProtocol" overrideModeDefault="Allow" />
			<section name="httpRedirect" overrideModeDefault="Allow" />
			<section name="httpTracing" overrideModeDefault="Deny" />
			<section name="isapiFilters" allowDefinition="MachineToApplication" overrideModeDefault="Deny" />
			<section name="modules" allowDefinition="MachineToApplication" overrideModeDefault="Deny" />
			<section name="applicationInitialization" allowDefinition="MachineToApplication" overrideModeDefault="Allow" />
			<section name="odbcLogging" overrideModeDefault="Deny" />
			<sectionGroup name="security">
				<section name="access" overrideModeDefault="Deny" />
				<section name="applicationDependencies" overrideModeDefault="Deny" />
				<sectionGroup name="authentication">
					<section name="anonymousAuthentication" overrideModeDefault="Deny" />
					<section name="basicAuthentication" overrideModeDefault="Deny" />
					<section name="clientCertificateMappingAuthentication" overrideModeDefault="Deny" />
					<section name="digestAuthentication" overrideModeDefault="Deny" />
					<section name="iisClientCertificateMappingAuthentication" overrideModeDefault="Deny" />
					<section name="windowsAuthentication" overrideModeDefault="Deny" />
				</sectionGroup>
				<section name="authorization" overrideModeDefault="Allow" />
				<section name="ipSecurity" overrideModeDefault="Deny" />
				<section name="dynamicIpSecurity" overrideModeDefault="Deny" />
				<section name="isapiCgiRestriction" allowDefinition="AppHostOnly" overrideModeDefault="Deny" />
				<section name="requestFiltering" overrideModeDefault="Allow" />
			</sectionGroup>
			<section name="serverRuntime" overrideModeDefault="Deny" />
			<section name="serverSideInclude" overrideModeDefault="Deny" />
			<section name="staticContent" overrideModeDefault="Allow" />
			<sectionGroup name="tracing">
				<section name="traceFailedRequests" overrideModeDefault="Allow" />
				<section name="traceProviderDefinitions" overrideModeDefault="Deny" />
			</sectionGroup>
			<section name="urlCompression" overrideModeDefault="Allow" />
			<section name="validation" overrideModeDefault="Allow" />
			<sectionGroup name="webdav">
				<section name="globalSettings" overrideModeDefault="Deny" />
				<section name="authoring" overrideModeDefault="Deny" />
				<section name="authoringRules" overrideModeDefault="Deny" />
			</sectionGroup>
			<sectionGroup name="rewrite">
				<section name="allowedServerVariables" overrideModeDefault="Deny" />
				<section name="rules" overrideModeDefault="Allow" />
				<section name="outboundRules" overrideModeDefault="Allow" />
				<section name="globalRules" overrideModeDefault="Deny" allowDefinition="AppHostOnly" />
				<section name="providers" overrideModeDefault="Allow" />
				<section name="rewriteMaps" overrideModeDefault="Allow" />
			</sectionGroup>
			<section name="webSocket" overrideModeDefault="Deny" />
		</sectionGroup>
	</configSections>
	<configProtectedData>
		<providers>
			<add name="IISWASOnlyRsaProvider" type="" description="Uses RsaCryptoServiceProvider to encrypt and decrypt" keyContainerName="iisWasKey" cspProviderName="" useMachineContainer="true" useOAEP="false" />
			<add name="AesProvider" type="Microsoft.ApplicationHost.AesProtectedConfigurationProvider" description="Uses an AES session key to encrypt and decrypt" keyContainerName="iisConfigurationKey" cspProviderName="" useOAEP="false" useMachineContainer="true" sessionKey="AQIAAA5mAAAApAAA/HKxkz6alrlAPez0IUgujj/6k3WxCDriHp6jvpv3yEZmo7h6SMzGLxo4mTrIQVHSkB7tmElHKfUFTzE2BWF7nFWHY6Z6qmGBauFzwJMwESjril7Gjz69RBFH259HQ6aRDq9Xfx7U7H4HtdmnKNqGjgl/hwPQBGeIlWiDh+sYv3vKB0QU971tjX6H2B+9armlnC8UOuA6JYMDMI/VLLL16sng0fWAy5JYe0YVABVjiAWDW264RZW9Tr1Oax4qHZKg+SdjULxeOc2YmpX+d0yeITo1HkPF1hN1gHpIPIUDo05ilHUNfR3OkjVCIQK4cFKCq1s8NH+y+13MxUC4Fn1AlQ==" />
			<add name="IISWASOnlyAesProvider" type="Microsoft.ApplicationHost.AesProtectedConfigurationProvider" description="Uses an AES session key to encrypt and decrypt" keyContainerName="iisWasKey" cspProviderName="" useOAEP="false" useMachineContainer="true" sessionKey="AQIAAA5mAAAApAAALmU8lTC+v2qtfQiiiquvvLpUQqKLEXs+jSKoWCM/uPhyB++k4dwug19mGidNK5FYiWK2KYE1yhjVJcbp12E98Q0R2nT7eBiCMY2JairxQ591rqABK7keGaIjwH7PwGzSpILl3RJ4YFvJ/7ZXEJxeDZIjW8ZxWVXx+/VyHs9U3WguLEkgMUX3jrxJi8LouxaIVPJAv/YQ1ZCWs8zImitxX/C/7o7yaIxznfsN5nGQzQfpUDPeby99aw2zPVTtZI2LaWIBON8guABvZ6JtJVDWmfdK6sodbnwdZkr6/Z2rfvamT1dC1SpQrGG7ulR/f9/GXvCaW10ZVKxekBF/CYlNMg==" />
		</providers>
	</configProtectedData>
	<system.applicationHost>
		<applicationPools>
			<add name="Clr4IntegratedAppPool" managedRuntimeVersion="v4.0" managedPipelineMode="Integrated" CLRConfigFile="%IIS_USER_HOME%\config\aspnet.config" autoStart="true" />
			<add name="Clr4ClassicAppPool" managedRuntimeVersion="v4.0" managedPipelineMode="Classic" CLRConfigFile="%IIS_USER_HOME%\config\aspnet.config" autoStart="true" />
			<add name="Clr2IntegratedAppPool" managedRuntimeVersion="v2.0" managedPipelineMode="Integrated" CLRConfigFile="%IIS_USER_HOME%\config\aspnet.config" autoStart="true" />
			<add name="Clr2ClassicAppPool" managedRuntimeVersion="v2.0" managedPipelineMode="Classic" CLRConfigFile="%IIS_USER_HOME%\config\aspnet.config" autoStart="true" />
			<add name="UnmanagedClassicAppPool" managedRuntimeVersion="" managedPipelineMode="Classic" autoStart="true" />
			<applicationPoolDefaults managedRuntimeVersion="v4.0">
				<processModel loadUserProfile="true" setProfileEnvironment="false" />
			</applicationPoolDefaults>
		</applicationPools>
		<!--

          The <listenerAdapters> section defines the protocols with which the
          Windows Process Activation Service (WAS) binds.

        -->
		<listenerAdapters>
			<add name="http" />
		</listenerAdapters>
		<sites>
			<site name="WebSite1" id="1" serverAutoStart="true">
				<application path="/">
					<virtualDirectory path="/" physicalPath="%IIS_SITES_HOME%\WebSite1" />
				</application>
				<bindings>
					<binding protocol="http" bindingInformation=":8080:localhost" />
				</bindings>
			</site>
			<siteDefaults>
				<!-- To enable logging, please change the below attribute "enabled" to "true" -->
				<logFile logFormat="W3C" directory="%AppData%\Microsoft\IISExpressLogs" enabled="false" />
				<traceFailedRequestsLogging directory="%AppData%\Microsoft" enabled="false" maxLogFileSizeKB="1024" />
			</siteDefaults>
			<applicationDefaults applicationPool="Clr4IntegratedAppPool" />
			<virtualDirectoryDefaults allowSubDirConfig="true" />
		</sites>
		<webLimits />
	</system.applicationHost>
	<system.webServer>
		<serverRuntime />
		<asp scriptErrorSentToBrowser="true">
			<cache diskTemplateCacheDirectory="%TEMP%\iisexpress\ASP Compiled Templates" />
			<limits />
		</asp>
		<caching enabled="true" enableKernelCache="true">
		</caching>
		<cgi />
		<defaultDocument enabled="true">
			<files>
				<add value="Default.htm" />
				<add value="Default.asp" />
				<add value="index.htm" />
				<add value="index.html" />
				<add value="iisstart.htm" />
				<add value="default.aspx" />
			</files>
		</defaultDocument>
		<directoryBrowse enabled="false" />
		<fastCgi />
		<!--

          The <globalModules> section defines all native-code modules.
          To enable a module, specify it in the <modules> section.

        -->
		<globalModules>
			<add name="HttpLoggingModule" image="%IIS_BIN%\loghttp.dll" />
			<add name="UriCacheModule" image="%IIS_BIN%\cachuri.dll" />
			<add name="TokenCacheModule" image="%IIS_BIN%\cachtokn.dll" />
			<add name="DynamicCompressionModule" image="%IIS_BIN%\compdyn.dll" />
			<add name="StaticCompressionModule" image="%IIS_BIN%\compstat.dll" />
			<add name="DefaultDocumentModule" image="%IIS_BIN%\defdoc.dll" />
			<add name="DirectoryListingModule" image="%IIS_BIN%\dirlist.dll" />
			<add name="ProtocolSupportModule" image="%IIS_BIN%\protsup.dll" />
			<add name="HttpRedirectionModule" image="%IIS_BIN%\redirect.dll" />
			<add name="ServerSideIncludeModule" image="%IIS_BIN%\iis_ssi.dll" />
			<add name="StaticFileModule" image="%IIS_BIN%\static.dll" />
			<add name="AnonymousAuthenticationModule" image="%IIS_BIN%\authanon.dll" />
			<add name="CertificateMappingAuthenticationModule" image="%IIS_BIN%\authcert.dll" />
			<add name="UrlAuthorizationModule" image="%IIS_BIN%\urlauthz.dll" />
			<add name="BasicAuthenticationModule" image="%IIS_BIN%\authbas.dll" />
			<add name="WindowsAuthenticationModule" image="%IIS_BIN%\authsspi.dll" />
			<add name="IISCertificateMappingAuthenticationModule" image="%IIS_BIN%\authmap.dll" />
			<add name="IpRestrictionModule" image="%IIS_BIN%\iprestr.dll" />
			<add name="DynamicIpRestrictionModule" image="%IIS_BIN%\diprestr.dll" />
			<add name="RequestFilteringModule" image="%IIS_BIN%\modrqflt.dll" />
			<add name="CustomLoggingModule" image="%IIS_BIN%\logcust.dll" />
			<add name="CustomErrorModule" image="%IIS_BIN%\custerr.dll" />
			<add name="FailedRequestsTracingModule" image="%IIS_BIN%\iisfreb.dll" />
			<add name="RequestMonitorModule" image="%IIS_BIN%\iisreqs.dll" />
			<add name="IsapiModule" image="%IIS_BIN%\isapi.dll" />
			<add name="IsapiFilterModule" image="%IIS_BIN%\filter.dll" />
			<add name="CgiModule" image="%IIS_BIN%\cgi.dll" />
			<add name="FastCgiModule" image="%IIS_BIN%\iisfcgi.dll" />
			<!--            <add name="WebDAVModule" image="%IIS_BIN%\webdav.dll" /> -->
			<add name="RewriteModule" image="%IIS_BIN%\rewrite.dll" />
			<add name="ConfigurationValidationModule" image="%IIS_BIN%\validcfg.dll" />
			<add name="WebSocketModule" image="%IIS_BIN%\iiswsock.dll" />
			<add name="WebMatrixSupportModule" image="%IIS_BIN%\webmatrixsup.dll" />
			<add name="ManagedEngine" image="%windir%\Microsoft.NET\Framework\v2.0.50727\webengine.dll" preCondition="integratedMode,runtimeVersionv2.0,bitness32" />
			<add name="ManagedEngine64" image="%windir%\Microsoft.NET\Framework64\v2.0.50727\webengine.dll" preCondition="integratedMode,runtimeVersionv2.0,bitness64" />
			<add name="ManagedEngineV4.0_32bit" image="%windir%\Microsoft.NET\Framework\v4.0.30319\webengine4.dll" preCondition="integratedMode,runtimeVersionv4.0,bitness32" />
			<add name="ManagedEngineV4.0_64bit" image="%windir%\Microsoft.NET\Framework64\v4.0.30319\webengine4.dll" preCondition="integratedMode,runtimeVersionv4.0,bitness64" />
			<add name="ApplicationInitializationModule" image="%IIS_BIN%\warmup.dll" />
		</globalModules>
		<httpCompression directory="%TEMP%">
			<scheme name="gzip" dll="%IIS_BIN%\gzip.dll" />
			<dynamicTypes>
				<add mimeType="text/*" enabled="true" />
				<add mimeType="message/*" enabled="true" />
				<add mimeType="application/x-javascript" enabled="true" />
				<add mimeType="application/javascript" enabled="true" />
				<add mimeType="*/*" enabled="false" />
				<add mimeType="text/event-stream" enabled="false" />
			</dynamicTypes>
			<staticTypes>
				<add mimeType="text/*" enabled="true" />
				<add mimeType="message/*" enabled="true" />
				<add mimeType="application/javascript" enabled="true" />
				<add mimeType="application/atom+xml" enabled="true" />
				<add mimeType="application/xaml+xml" enabled="true" />
				<add mimeType="image/svg+xml" enabled="true" />
				<add mimeType="*/*" enabled="false" />
			</staticTypes>
		</httpCompression>
		<httpErrors lockAttributes="allowAbsolutePathsWhenDelegated,defaultPath">
			<error statusCode="401" prefixLanguageFilePath="%IIS_BIN%\custerr" path="401.htm" />
			<error statusCode="403" prefixLanguageFilePath="%IIS_BIN%\custerr" path="403.htm" />
			<error statusCode="404" prefixLanguageFilePath="%IIS_BIN%\custerr" path="404.htm" />
			<error statusCode="405" prefixLanguageFilePath="%IIS_BIN%\custerr" path="405.htm" />
			<error statusCode="406" prefixLanguageFilePath="%IIS_BIN%\custerr" path="406.htm" />
			<error statusCode="412" prefixLanguageFilePath="%IIS_BIN%\custerr" path="412.htm" />
			<error statusCode="500" prefixLanguageFilePath="%IIS_BIN%\custerr" path="500.htm" />
			<error statusCode="501" prefixLanguageFilePath="%IIS_BIN%\custerr" path="501.htm" />
			<error statusCode="502" prefixLanguageFilePath="%IIS_BIN%\custerr" path="502.htm" />
		</httpErrors>
		<httpLogging dontLog="false" />
		<httpProtocol>
			<customHeaders>
				<clear />
				<add name="X-Powered-By" value="ASP.NET" />
			</customHeaders>
			<redirectHeaders>
				<clear />
			</redirectHeaders>
		</httpProtocol>
		<httpRedirect enabled="false" />
		<httpTracing />
		<isapiFilters>
			<filter name="ASP.Net_2.0.50727-64" path="%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_filter.dll" enableCache="true" preCondition="bitness64,runtimeVersionv2.0" />
			<filter name="ASP.Net_2.0.50727.0" path="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_filter.dll" enableCache="true" preCondition="bitness32,runtimeVersionv2.0" />
			<filter name="ASP.Net_2.0_for_v1.1" path="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_filter.dll" enableCache="true" preCondition="runtimeVersionv1.1" />
			<filter name="ASP.Net_4.0_32bit" path="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_filter.dll" enableCache="true" preCondition="bitness32,runtimeVersionv4.0" />
			<filter name="ASP.Net_4.0_64bit" path="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_filter.dll" enableCache="true" preCondition="bitness64,runtimeVersionv4.0" />
		</isapiFilters>
		<odbcLogging />
		<security>
			<access sslFlags="None" />
			<applicationDependencies>
				<application name="Active Server Pages" groupId="ASP" />
			</applicationDependencies>
			<authentication>
				<anonymousAuthentication enabled="true" userName="" />
				<basicAuthentication enabled="false" />
				<clientCertificateMappingAuthentication enabled="false" />
				<digestAuthentication enabled="false" />
				<iisClientCertificateMappingAuthentication enabled="false">
				</iisClientCertificateMappingAuthentication>
				<windowsAuthentication enabled="false">
					<providers>
						<add value="Negotiate" />
						<add value="NTLM" />
					</providers>
				</windowsAuthentication>
			</authentication>
			<authorization>
				<add accessType="Allow" users="*" />
			</authorization>
			<ipSecurity allowUnlisted="true" />
			<isapiCgiRestriction notListedIsapisAllowed="true" notListedCgisAllowed="true">
				<add path="%windir%\Microsoft.NET\Framework64\v4.0.30319\webengine4.dll" allowed="true" groupId="ASP.NET_v4.0" description="ASP.NET_v4.0" />
				<add path="%windir%\Microsoft.NET\Framework\v4.0.30319\webengine4.dll" allowed="true" groupId="ASP.NET_v4.0" description="ASP.NET_v4.0" />
				<add path="%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll" allowed="true" groupId="ASP.NET v2.0.50727" description="ASP.NET v2.0.50727" />
				<add path="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll" allowed="true" groupId="ASP.NET v2.0.50727" description="ASP.NET v2.0.50727" />
			</isapiCgiRestriction>
			<requestFiltering>
				<fileExtensions allowUnlisted="true" applyToWebDAV="true">
					<add fileExtension=".asa" allowed="false" />
					<add fileExtension=".asax" allowed="false" />
					<add fileExtension=".ascx" allowed="false" />
					<add fileExtension=".master" allowed="false" />
					<add fileExtension=".skin" allowed="false" />
					<add fileExtension=".browser" allowed="false" />
					<add fileExtension=".sitemap" allowed="false" />
					<add fileExtension=".config" allowed="false" />
					<add fileExtension=".cs" allowed="false" />
					<add fileExtension=".csproj" allowed="false" />
					<add fileExtension=".vb" allowed="false" />
					<add fileExtension=".vbproj" allowed="false" />
					<add fileExtension=".webinfo" allowed="false" />
					<add fileExtension=".licx" allowed="false" />
					<add fileExtension=".resx" allowed="false" />
					<add fileExtension=".resources" allowed="false" />
					<add fileExtension=".mdb" allowed="false" />
					<add fileExtension=".vjsproj" allowed="false" />
					<add fileExtension=".java" allowed="false" />
					<add fileExtension=".jsl" allowed="false" />
					<add fileExtension=".ldb" allowed="false" />
					<add fileExtension=".dsdgm" allowed="false" />
					<add fileExtension=".ssdgm" allowed="false" />
					<add fileExtension=".lsad" allowed="false" />
					<add fileExtension=".ssmap" allowed="false" />
					<add fileExtension=".cd" allowed="false" />
					<add fileExtension=".dsprototype" allowed="false" />
					<add fileExtension=".lsaprototype" allowed="false" />
					<add fileExtension=".sdm" allowed="false" />
					<add fileExtension=".sdmDocument" allowed="false" />
					<add fileExtension=".mdf" allowed="false" />
					<add fileExtension=".ldf" allowed="false" />
					<add fileExtension=".ad" allowed="false" />
					<add fileExtension=".dd" allowed="false" />
					<add fileExtension=".ldd" allowed="false" />
					<add fileExtension=".sd" allowed="false" />
					<add fileExtension=".adprototype" allowed="false" />
					<add fileExtension=".lddprototype" allowed="false" />
					<add fileExtension=".exclude" allowed="false" />
					<add fileExtension=".refresh" allowed="false" />
					<add fileExtension=".compiled" allowed="false" />
					<add fileExtension=".msgx" allowed="false" />
					<add fileExtension=".vsdisco" allowed="false" />
					<add fileExtension=".rules" allowed="false" />
				</fileExtensions>
				<verbs allowUnlisted="true" applyToWebDAV="true" />
				<hiddenSegments applyToWebDAV="true">
					<add segment="web.config" />
					<add segment="bin" />
					<add segment="App_code" />
					<add segment="App_GlobalResources" />
					<add segment="App_LocalResources" />
					<add segment="App_WebReferences" />
					<add segment="App_Data" />
					<add segment="App_Browsers" />
				</hiddenSegments>
			</requestFiltering>
		</security>
		<serverSideInclude ssiExecDisable="false" />
		<staticContent lockAttributes="isDocFooterFileName">
			<mimeMap fileExtension=".323" mimeType="text/h323" />
			<mimeMap fileExtension=".3g2" mimeType="video/3gpp2" />
			<mimeMap fileExtension=".3gp2" mimeType="video/3gpp2" />
			<mimeMap fileExtension=".3gp" mimeType="video/3gpp" />
			<mimeMap fileExtension=".3gpp" mimeType="video/3gpp" />
			<mimeMap fileExtension=".aac" mimeType="audio/aac" />
			<mimeMap fileExtension=".aaf" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".aca" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".accdb" mimeType="application/msaccess" />
			<mimeMap fileExtension=".accde" mimeType="application/msaccess" />
			<mimeMap fileExtension=".accdt" mimeType="application/msaccess" />
			<mimeMap fileExtension=".acx" mimeType="application/internet-property-stream" />
			<mimeMap fileExtension=".adt" mimeType="audio/vnd.dlna.adts" />
			<mimeMap fileExtension=".adts" mimeType="audio/vnd.dlna.adts" />
			<mimeMap fileExtension=".afm" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".ai" mimeType="application/postscript" />
			<mimeMap fileExtension=".aif" mimeType="audio/x-aiff" />
			<mimeMap fileExtension=".aifc" mimeType="audio/aiff" />
			<mimeMap fileExtension=".aiff" mimeType="audio/aiff" />
			<mimeMap fileExtension=".appcache" mimeType="text/cache-manifest" />
			<mimeMap fileExtension=".application" mimeType="application/x-ms-application" />
			<mimeMap fileExtension=".art" mimeType="image/x-jg" />
			<mimeMap fileExtension=".asd" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".asf" mimeType="video/x-ms-asf" />
			<mimeMap fileExtension=".asi" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".asm" mimeType="text/plain" />
			<mimeMap fileExtension=".asr" mimeType="video/x-ms-asf" />
			<mimeMap fileExtension=".asx" mimeType="video/x-ms-asf" />
			<mimeMap fileExtension=".atom" mimeType="application/atom+xml" />
			<mimeMap fileExtension=".au" mimeType="audio/basic" />
			<mimeMap fileExtension=".avi" mimeType="video/avi" />
			<mimeMap fileExtension=".axs" mimeType="application/olescript" />
			<mimeMap fileExtension=".bas" mimeType="text/plain" />
			<mimeMap fileExtension=".bcpio" mimeType="application/x-bcpio" />
			<mimeMap fileExtension=".bin" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".bmp" mimeType="image/bmp" />
			<mimeMap fileExtension=".c" mimeType="text/plain" />
			<mimeMap fileExtension=".cab" mimeType="application/vnd.ms-cab-compressed" />
			<mimeMap fileExtension=".calx" mimeType="application/vnd.ms-office.calx" />
			<mimeMap fileExtension=".cat" mimeType="application/vnd.ms-pki.seccat" />
			<mimeMap fileExtension=".cdf" mimeType="application/x-cdf" />
			<mimeMap fileExtension=".chm" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".class" mimeType="application/x-java-applet" />
			<mimeMap fileExtension=".clp" mimeType="application/x-msclip" />
			<mimeMap fileExtension=".cmx" mimeType="image/x-cmx" />
			<mimeMap fileExtension=".cnf" mimeType="text/plain" />
			<mimeMap fileExtension=".cod" mimeType="image/cis-cod" />
			<mimeMap fileExtension=".cpio" mimeType="application/x-cpio" />
			<mimeMap fileExtension=".cpp" mimeType="text/plain" />
			<mimeMap fileExtension=".crd" mimeType="application/x-mscardfile" />
			<mimeMap fileExtension=".crl" mimeType="application/pkix-crl" />
			<mimeMap fileExtension=".crt" mimeType="application/x-x509-ca-cert" />
			<mimeMap fileExtension=".csh" mimeType="application/x-csh" />
			<mimeMap fileExtension=".css" mimeType="text/css" />
			<mimeMap fileExtension=".csv" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".cur" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".dcr" mimeType="application/x-director" />
			<mimeMap fileExtension=".deploy" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".der" mimeType="application/x-x509-ca-cert" />
			<mimeMap fileExtension=".dib" mimeType="image/bmp" />
			<mimeMap fileExtension=".dir" mimeType="application/x-director" />
			<mimeMap fileExtension=".disco" mimeType="text/xml" />
			<mimeMap fileExtension=".dll" mimeType="application/x-msdownload" />
			<mimeMap fileExtension=".dll.config" mimeType="text/xml" />
			<mimeMap fileExtension=".dlm" mimeType="text/dlm" />
			<mimeMap fileExtension=".doc" mimeType="application/msword" />
			<mimeMap fileExtension=".docm" mimeType="application/vnd.ms-word.document.macroEnabled.12" />
			<mimeMap fileExtension=".docx" mimeType="application/vnd.openxmlformats-officedocument.wordprocessingml.document" />
			<mimeMap fileExtension=".dot" mimeType="application/msword" />
			<mimeMap fileExtension=".dotm" mimeType="application/vnd.ms-word.template.macroEnabled.12" />
			<mimeMap fileExtension=".dotx" mimeType="application/vnd.openxmlformats-officedocument.wordprocessingml.template" />
			<mimeMap fileExtension=".dsp" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".dtd" mimeType="text/xml" />
			<mimeMap fileExtension=".dvi" mimeType="application/x-dvi" />
			<mimeMap fileExtension=".dvr-ms" mimeType="video/x-ms-dvr" />
			<mimeMap fileExtension=".dwf" mimeType="drawing/x-dwf" />
			<mimeMap fileExtension=".dwp" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".dxr" mimeType="application/x-director" />
			<mimeMap fileExtension=".eml" mimeType="message/rfc822" />
			<mimeMap fileExtension=".emz" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".eot" mimeType="application/vnd.ms-fontobject" />
			<mimeMap fileExtension=".eps" mimeType="application/postscript" />
			<mimeMap fileExtension=".esd" mimeType="application/vnd.ms-cab-compressed" />
			<mimeMap fileExtension=".etx" mimeType="text/x-setext" />
			<mimeMap fileExtension=".evy" mimeType="application/envoy" />
			<mimeMap fileExtension=".exe" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".exe.config" mimeType="text/xml" />
			<mimeMap fileExtension=".fdf" mimeType="application/vnd.fdf" />
			<mimeMap fileExtension=".fif" mimeType="application/fractals" />
			<mimeMap fileExtension=".fla" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".flr" mimeType="x-world/x-vrml" />
			<mimeMap fileExtension=".flv" mimeType="video/x-flv" />
			<mimeMap fileExtension=".gif" mimeType="image/gif" />
			<mimeMap fileExtension=".glb" mimeType="model/gltf-binary" />
			<mimeMap fileExtension=".gtar" mimeType="application/x-gtar" />
			<mimeMap fileExtension=".gz" mimeType="application/x-gzip" />
			<mimeMap fileExtension=".h" mimeType="text/plain" />
			<mimeMap fileExtension=".hdf" mimeType="application/x-hdf" />
			<mimeMap fileExtension=".hdml" mimeType="text/x-hdml" />
			<mimeMap fileExtension=".hhc" mimeType="application/x-oleobject" />
			<mimeMap fileExtension=".hhk" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".hhp" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".hlp" mimeType="application/winhlp" />
			<mimeMap fileExtension=".hqx" mimeType="application/mac-binhex40" />
			<mimeMap fileExtension=".hta" mimeType="application/hta" />
			<mimeMap fileExtension=".htc" mimeType="text/x-component" />
			<mimeMap fileExtension=".htm" mimeType="text/html" />
			<mimeMap fileExtension=".html" mimeType="text/html" />
			<mimeMap fileExtension=".htt" mimeType="text/webviewhtml" />
			<mimeMap fileExtension=".hxt" mimeType="text/html" />
			<mimeMap fileExtension=".ico" mimeType="image/x-icon" />
			<mimeMap fileExtension=".ics" mimeType="text/calendar" />
			<mimeMap fileExtension=".ief" mimeType="image/ief" />
			<mimeMap fileExtension=".iii" mimeType="application/x-iphone" />
			<mimeMap fileExtension=".inf" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".ins" mimeType="application/x-internet-signup" />
			<mimeMap fileExtension=".isp" mimeType="application/x-internet-signup" />
			<mimeMap fileExtension=".IVF" mimeType="video/x-ivf" />
			<mimeMap fileExtension=".jar" mimeType="application/java-archive" />
			<mimeMap fileExtension=".java" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".jck" mimeType="application/liquidmotion" />
			<mimeMap fileExtension=".jcz" mimeType="application/liquidmotion" />
			<mimeMap fileExtension=".jfif" mimeType="image/pjpeg" />
			<mimeMap fileExtension=".jpb" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".jpe" mimeType="image/jpeg" />
			<mimeMap fileExtension=".jpeg" mimeType="image/jpeg" />
			<mimeMap fileExtension=".jpg" mimeType="image/jpeg" />
			<mimeMap fileExtension=".js" mimeType="application/javascript" />
			<mimeMap fileExtension=".json" mimeType="application/json" />
			<mimeMap fileExtension=".jsonld" mimeType="application/ld+json" />
			<mimeMap fileExtension=".jsx" mimeType="text/jscript" />
			<mimeMap fileExtension=".latex" mimeType="application/x-latex" />
			<mimeMap fileExtension=".less" mimeType="text/css" />
			<mimeMap fileExtension=".lit" mimeType="application/x-ms-reader" />
			<mimeMap fileExtension=".lpk" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".lsf" mimeType="video/x-la-asf" />
			<mimeMap fileExtension=".lsx" mimeType="video/x-la-asf" />
			<mimeMap fileExtension=".lzh" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".m13" mimeType="application/x-msmediaview" />
			<mimeMap fileExtension=".m14" mimeType="application/x-msmediaview" />
			<mimeMap fileExtension=".m1v" mimeType="video/mpeg" />
			<mimeMap fileExtension=".m2ts" mimeType="video/vnd.dlna.mpeg-tts" />
			<mimeMap fileExtension=".m3u" mimeType="audio/x-mpegurl" />
			<mimeMap fileExtension=".m4a" mimeType="audio/mp4" />
			<mimeMap fileExtension=".m4v" mimeType="video/mp4" />
			<mimeMap fileExtension=".man" mimeType="application/x-troff-man" />
			<mimeMap fileExtension=".manifest" mimeType="application/x-ms-manifest" />
			<mimeMap fileExtension=".map" mimeType="text/plain" />
			<mimeMap fileExtension=".mdb" mimeType="application/x-msaccess" />
			<mimeMap fileExtension=".mdp" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".me" mimeType="application/x-troff-me" />
			<mimeMap fileExtension=".mht" mimeType="message/rfc822" />
			<mimeMap fileExtension=".mhtml" mimeType="message/rfc822" />
			<mimeMap fileExtension=".mid" mimeType="audio/mid" />
			<mimeMap fileExtension=".midi" mimeType="audio/mid" />
			<mimeMap fileExtension=".mix" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".mmf" mimeType="application/x-smaf" />
			<mimeMap fileExtension=".mno" mimeType="text/xml" />
			<mimeMap fileExtension=".mny" mimeType="application/x-msmoney" />
			<mimeMap fileExtension=".mov" mimeType="video/quicktime" />
			<mimeMap fileExtension=".movie" mimeType="video/x-sgi-movie" />
			<mimeMap fileExtension=".mp2" mimeType="video/mpeg" />
			<mimeMap fileExtension=".mp3" mimeType="audio/mpeg" />
			<mimeMap fileExtension=".mp4" mimeType="video/mp4" />
			<mimeMap fileExtension=".mp4v" mimeType="video/mp4" />
			<mimeMap fileExtension=".mpa" mimeType="video/mpeg" />
			<mimeMap fileExtension=".mpe" mimeType="video/mpeg" />
			<mimeMap fileExtension=".mpeg" mimeType="video/mpeg" />
			<mimeMap fileExtension=".mpg" mimeType="video/mpeg" />
			<mimeMap fileExtension=".mpp" mimeType="application/vnd.ms-project" />
			<mimeMap fileExtension=".mpv2" mimeType="video/mpeg" />
			<mimeMap fileExtension=".ms" mimeType="application/x-troff-ms" />
			<mimeMap fileExtension=".msi" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".mso" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".mvb" mimeType="application/x-msmediaview" />
			<mimeMap fileExtension=".mvc" mimeType="application/x-miva-compiled" />
			<mimeMap fileExtension=".nc" mimeType="application/x-netcdf" />
			<mimeMap fileExtension=".nsc" mimeType="video/x-ms-asf" />
			<mimeMap fileExtension=".nws" mimeType="message/rfc822" />
			<mimeMap fileExtension=".ocx" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".oda" mimeType="application/oda" />
			<mimeMap fileExtension=".odc" mimeType="text/x-ms-odc" />
			<mimeMap fileExtension=".ods" mimeType="application/oleobject" />
			<mimeMap fileExtension=".oga" mimeType="audio/ogg" />
			<mimeMap fileExtension=".ogg" mimeType="video/ogg" />
			<mimeMap fileExtension=".ogv" mimeType="video/ogg" />
			<mimeMap fileExtension=".one" mimeType="application/onenote" />
			<mimeMap fileExtension=".onea" mimeType="application/onenote" />
			<mimeMap fileExtension=".onetoc" mimeType="application/onenote" />
			<mimeMap fileExtension=".onetoc2" mimeType="application/onenote" />
			<mimeMap fileExtension=".onetmp" mimeType="application/onenote" />
			<mimeMap fileExtension=".onepkg" mimeType="application/onenote" />
			<mimeMap fileExtension=".osdx" mimeType="application/opensearchdescription+xml" />
			<mimeMap fileExtension=".otf" mimeType="font/otf" />
			<mimeMap fileExtension=".p10" mimeType="application/pkcs10" />
			<mimeMap fileExtension=".p12" mimeType="application/x-pkcs12" />
			<mimeMap fileExtension=".p7b" mimeType="application/x-pkcs7-certificates" />
			<mimeMap fileExtension=".p7c" mimeType="application/pkcs7-mime" />
			<mimeMap fileExtension=".p7m" mimeType="application/pkcs7-mime" />
			<mimeMap fileExtension=".p7r" mimeType="application/x-pkcs7-certreqresp" />
			<mimeMap fileExtension=".p7s" mimeType="application/pkcs7-signature" />
			<mimeMap fileExtension=".pbm" mimeType="image/x-portable-bitmap" />
			<mimeMap fileExtension=".pcx" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".pcz" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".pdf" mimeType="application/pdf" />
			<mimeMap fileExtension=".pfb" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".pfm" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".pfx" mimeType="application/x-pkcs12" />
			<mimeMap fileExtension=".pgm" mimeType="image/x-portable-graymap" />
			<mimeMap fileExtension=".pko" mimeType="application/vnd.ms-pki.pko" />
			<mimeMap fileExtension=".pma" mimeType="application/x-perfmon" />
			<mimeMap fileExtension=".pmc" mimeType="application/x-perfmon" />
			<mimeMap fileExtension=".pml" mimeType="application/x-perfmon" />
			<mimeMap fileExtension=".pmr" mimeType="application/x-perfmon" />
			<mimeMap fileExtension=".pmw" mimeType="application/x-perfmon" />
			<mimeMap fileExtension=".png" mimeType="image/png" />
			<mimeMap fileExtension=".pnm" mimeType="image/x-portable-anymap" />
			<mimeMap fileExtension=".pnz" mimeType="image/png" />
			<mimeMap fileExtension=".pot" mimeType="application/vnd.ms-powerpoint" />
			<mimeMap fileExtension=".potm" mimeType="application/vnd.ms-powerpoint.template.macroEnabled.12" />
			<mimeMap fileExtension=".potx" mimeType="application/vnd.openxmlformats-officedocument.presentationml.template" />
			<mimeMap fileExtension=".ppam" mimeType="application/vnd.ms-powerpoint.addin.macroEnabled.12" />
			<mimeMap fileExtension=".ppm" mimeType="image/x-portable-pixmap" />
			<mimeMap fileExtension=".pps" mimeType="application/vnd.ms-powerpoint" />
			<mimeMap fileExtension=".ppsm" mimeType="application/vnd.ms-powerpoint.slideshow.macroEnabled.12" />
			<mimeMap fileExtension=".ppsx" mimeType="application/vnd.openxmlformats-officedocument.presentationml.slideshow" />
			<mimeMap fileExtension=".ppt" mimeType="application/vnd.ms-powerpoint" />
			<mimeMap fileExtension=".pptm" mimeType="application/vnd.ms-powerpoint.presentation.macroEnabled.12" />
			<mimeMap fileExtension=".pptx" mimeType="application/vnd.openxmlformats-officedocument.presentationml.presentation" />
			<mimeMap fileExtension=".prf" mimeType="application/pics-rules" />
			<mimeMap fileExtension=".prm" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".prx" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".ps" mimeType="application/postscript" />
			<mimeMap fileExtension=".psd" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".psm" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".psp" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".pub" mimeType="application/x-mspublisher" />
			<mimeMap fileExtension=".qt" mimeType="video/quicktime" />
			<mimeMap fileExtension=".qtl" mimeType="application/x-quicktimeplayer" />
			<mimeMap fileExtension=".qxd" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".ra" mimeType="audio/x-pn-realaudio" />
			<mimeMap fileExtension=".ram" mimeType="audio/x-pn-realaudio" />
			<mimeMap fileExtension=".rar" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".ras" mimeType="image/x-cmu-raster" />
			<mimeMap fileExtension=".rf" mimeType="image/vnd.rn-realflash" />
			<mimeMap fileExtension=".rgb" mimeType="image/x-rgb" />
			<mimeMap fileExtension=".rm" mimeType="application/vnd.rn-realmedia" />
			<mimeMap fileExtension=".rmi" mimeType="audio/mid" />
			<mimeMap fileExtension=".roff" mimeType="application/x-troff" />
			<mimeMap fileExtension=".rpm" mimeType="audio/x-pn-realaudio-plugin" />
			<mimeMap fileExtension=".rtf" mimeType="application/rtf" />
			<mimeMap fileExtension=".rtx" mimeType="text/richtext" />
			<mimeMap fileExtension=".scd" mimeType="application/x-msschedule" />
			<mimeMap fileExtension=".sct" mimeType="text/scriptlet" />
			<mimeMap fileExtension=".sea" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".setpay" mimeType="application/set-payment-initiation" />
			<mimeMap fileExtension=".setreg" mimeType="application/set-registration-initiation" />
			<mimeMap fileExtension=".sgml" mimeType="text/sgml" />
			<mimeMap fileExtension=".sh" mimeType="application/x-sh" />
			<mimeMap fileExtension=".shar" mimeType="application/x-shar" />
			<mimeMap fileExtension=".sit" mimeType="application/x-stuffit" />
			<mimeMap fileExtension=".sldm" mimeType="application/vnd.ms-powerpoint.slide.macroEnabled.12" />
			<mimeMap fileExtension=".sldx" mimeType="application/vnd.openxmlformats-officedocument.presentationml.slide" />
			<mimeMap fileExtension=".smd" mimeType="audio/x-smd" />
			<mimeMap fileExtension=".smi" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".smx" mimeType="audio/x-smd" />
			<mimeMap fileExtension=".smz" mimeType="audio/x-smd" />
			<mimeMap fileExtension=".snd" mimeType="audio/basic" />
			<mimeMap fileExtension=".snp" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".spc" mimeType="application/x-pkcs7-certificates" />
			<mimeMap fileExtension=".spl" mimeType="application/futuresplash" />
			<mimeMap fileExtension=".spx" mimeType="audio/ogg" />
			<mimeMap fileExtension=".src" mimeType="application/x-wais-source" />
			<mimeMap fileExtension=".ssm" mimeType="application/streamingmedia" />
			<mimeMap fileExtension=".sst" mimeType="application/vnd.ms-pki.certstore" />
			<mimeMap fileExtension=".stl" mimeType="application/vnd.ms-pki.stl" />
			<mimeMap fileExtension=".sv4cpio" mimeType="application/x-sv4cpio" />
			<mimeMap fileExtension=".sv4crc" mimeType="application/x-sv4crc" />
			<mimeMap fileExtension=".svg" mimeType="image/svg+xml" />
			<mimeMap fileExtension=".svgz" mimeType="image/svg+xml" />
			<mimeMap fileExtension=".swf" mimeType="application/x-shockwave-flash" />
			<mimeMap fileExtension=".t" mimeType="application/x-troff" />
			<mimeMap fileExtension=".tar" mimeType="application/x-tar" />
			<mimeMap fileExtension=".tcl" mimeType="application/x-tcl" />
			<mimeMap fileExtension=".tex" mimeType="application/x-tex" />
			<mimeMap fileExtension=".texi" mimeType="application/x-texinfo" />
			<mimeMap fileExtension=".texinfo" mimeType="application/x-texinfo" />
			<mimeMap fileExtension=".tgz" mimeType="application/x-compressed" />
			<mimeMap fileExtension=".thmx" mimeType="application/vnd.ms-officetheme" />
			<mimeMap fileExtension=".thn" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".tif" mimeType="image/tiff" />
			<mimeMap fileExtension=".tiff" mimeType="image/tiff" />
			<mimeMap fileExtension=".toc" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".tr" mimeType="application/x-troff" />
			<mimeMap fileExtension=".trm" mimeType="application/x-msterminal" />
			<mimeMap fileExtension=".ts" mimeType="video/vnd.dlna.mpeg-tts" />
			<mimeMap fileExtension=".tsv" mimeType="text/tab-separated-values" />
			<mimeMap fileExtension=".ttf" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".tts" mimeType="video/vnd.dlna.mpeg-tts" />
			<mimeMap fileExtension=".txt" mimeType="text/plain" />
			<mimeMap fileExtension=".u32" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".uls" mimeType="text/iuls" />
			<mimeMap fileExtension=".ustar" mimeType="application/x-ustar" />
			<mimeMap fileExtension=".vbs" mimeType="text/vbscript" />
			<mimeMap fileExtension=".vcf" mimeType="text/x-vcard" />
			<mimeMap fileExtension=".vcs" mimeType="text/plain" />
			<mimeMap fileExtension=".vdx" mimeType="application/vnd.ms-visio.viewer" />
			<mimeMap fileExtension=".vml" mimeType="text/xml" />
			<mimeMap fileExtension=".vsd" mimeType="application/vnd.visio" />
			<mimeMap fileExtension=".vss" mimeType="application/vnd.visio" />
			<mimeMap fileExtension=".vst" mimeType="application/vnd.visio" />
			<mimeMap fileExtension=".vsto" mimeType="application/x-ms-vsto" />
			<mimeMap fileExtension=".vsw" mimeType="application/vnd.visio" />
			<mimeMap fileExtension=".vsx" mimeType="application/vnd.visio" />
			<mimeMap fileExtension=".vtx" mimeType="application/vnd.visio" />
			<mimeMap fileExtension=".wasm" mimeType="application/wasm" />
			<mimeMap fileExtension=".wav" mimeType="audio/wav" />
			<mimeMap fileExtension=".wax" mimeType="audio/x-ms-wax" />
			<mimeMap fileExtension=".wbmp" mimeType="image/vnd.wap.wbmp" />
			<mimeMap fileExtension=".wcm" mimeType="application/vnd.ms-works" />
			<mimeMap fileExtension=".wdb" mimeType="application/vnd.ms-works" />
			<mimeMap fileExtension=".webm" mimeType="video/webm" />
			<mimeMap fileExtension=".wks" mimeType="application/vnd.ms-works" />
			<mimeMap fileExtension=".wm" mimeType="video/x-ms-wm" />
			<mimeMap fileExtension=".wma" mimeType="audio/x-ms-wma" />
			<mimeMap fileExtension=".wmd" mimeType="application/x-ms-wmd" />
			<mimeMap fileExtension=".wmf" mimeType="application/x-msmetafile" />
			<mimeMap fileExtension=".wml" mimeType="text/vnd.wap.wml" />
			<mimeMap fileExtension=".wmlc" mimeType="application/vnd.wap.wmlc" />
			<mimeMap fileExtension=".wmls" mimeType="text/vnd.wap.wmlscript" />
			<mimeMap fileExtension=".wmlsc" mimeType="application/vnd.wap.wmlscriptc" />
			<mimeMap fileExtension=".wmp" mimeType="video/x-ms-wmp" />
			<mimeMap fileExtension=".wmv" mimeType="video/x-ms-wmv" />
			<mimeMap fileExtension=".wmx" mimeType="video/x-ms-wmx" />
			<mimeMap fileExtension=".wmz" mimeType="application/x-ms-wmz" />
			<mimeMap fileExtension=".woff" mimeType="font/x-woff" />
			<mimeMap fileExtension=".woff2" mimeType="application/font-woff2" />
			<mimeMap fileExtension=".wps" mimeType="application/vnd.ms-works" />
			<mimeMap fileExtension=".wri" mimeType="application/x-mswrite" />
			<mimeMap fileExtension=".wrl" mimeType="x-world/x-vrml" />
			<mimeMap fileExtension=".wrz" mimeType="x-world/x-vrml" />
			<mimeMap fileExtension=".wsdl" mimeType="text/xml" />
			<mimeMap fileExtension=".wtv" mimeType="video/x-ms-wtv" />
			<mimeMap fileExtension=".wvx" mimeType="video/x-ms-wvx" />
			<mimeMap fileExtension=".x" mimeType="application/directx" />
			<mimeMap fileExtension=".xaf" mimeType="x-world/x-vrml" />
			<mimeMap fileExtension=".xaml" mimeType="application/xaml+xml" />
			<mimeMap fileExtension=".xap" mimeType="application/x-silverlight-app" />
			<mimeMap fileExtension=".xbap" mimeType="application/x-ms-xbap" />
			<mimeMap fileExtension=".xbm" mimeType="image/x-xbitmap" />
			<mimeMap fileExtension=".xdr" mimeType="text/plain" />
			<mimeMap fileExtension=".xht" mimeType="application/xhtml+xml" />
			<mimeMap fileExtension=".xhtml" mimeType="application/xhtml+xml" />
			<mimeMap fileExtension=".xla" mimeType="application/vnd.ms-excel" />
			<mimeMap fileExtension=".xlam" mimeType="application/vnd.ms-excel.addin.macroEnabled.12" />
			<mimeMap fileExtension=".xlc" mimeType="application/vnd.ms-excel" />
			<mimeMap fileExtension=".xlm" mimeType="application/vnd.ms-excel" />
			<mimeMap fileExtension=".xls" mimeType="application/vnd.ms-excel" />
			<mimeMap fileExtension=".xlsb" mimeType="application/vnd.ms-excel.sheet.binary.macroEnabled.12" />
			<mimeMap fileExtension=".xlsm" mimeType="application/vnd.ms-excel.sheet.macroEnabled.12" />
			<mimeMap fileExtension=".xlsx" mimeType="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" />
			<mimeMap fileExtension=".xlt" mimeType="application/vnd.ms-excel" />
			<mimeMap fileExtension=".xltm" mimeType="application/vnd.ms-excel.template.macroEnabled.12" />
			<mimeMap fileExtension=".xltx" mimeType="application/vnd.openxmlformats-officedocument.spreadsheetml.template" />
			<mimeMap fileExtension=".xlw" mimeType="application/vnd.ms-excel" />
			<mimeMap fileExtension=".xml" mimeType="text/xml" />
			<mimeMap fileExtension=".xof" mimeType="x-world/x-vrml" />
			<mimeMap fileExtension=".xpm" mimeType="image/x-xpixmap" />
			<mimeMap fileExtension=".xps" mimeType="application/vnd.ms-xpsdocument" />
			<mimeMap fileExtension=".xsd" mimeType="text/xml" />
			<mimeMap fileExtension=".xsf" mimeType="text/xml" />
			<mimeMap fileExtension=".xsl" mimeType="text/xml" />
			<mimeMap fileExtension=".xslt" mimeType="text/xml" />
			<mimeMap fileExtension=".xsn" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".xtp" mimeType="application/octet-stream" />
			<mimeMap fileExtension=".xwd" mimeType="image/x-xwindowdump" />
			<mimeMap fileExtension=".z" mimeType="application/x-compress" />
			<mimeMap fileExtension=".zip" mimeType="application/x-zip-compressed" />
		</staticContent>
		<tracing>
			<traceFailedRequests>
				<add path="*">
					<traceAreas>
						<add provider="ASP" verbosity="Verbose" />
						<add provider="ASPNET" areas="Infrastructure,Module,Page,AppServices" verbosity="Verbose" />
						<add provider="ISAPI Extension" verbosity="Verbose" />
						<add provider="WWW Server" areas="Authentication,Security,Filter,StaticFile,CGI,Compression,Cache,RequestNotifications,Module,Rewrite,WebSocket" verbosity="Verbose" />
					</traceAreas>
					<failureDefinitions statusCodes="200-999" />
				</add>
			</traceFailedRequests>
			<traceProviderDefinitions>
				<add name="WWW Server" guid="{3a2a4e84-4c21-4981-ae10-3fda0d9b0f83}">
					<areas>
						<clear />
						<add name="Authentication" value="2" />
						<add name="Security" value="4" />
						<add name="Filter" value="8" />
						<add name="StaticFile" value="16" />
						<add name="CGI" value="32" />
						<add name="Compression" value="64" />
						<add name="Cache" value="128" />
						<add name="RequestNotifications" value="256" />
						<add name="Module" value="512" />
						<add name="Rewrite" value="1024" />
						<add name="FastCGI" value="4096" />
						<add name="WebSocket" value="16384" />
					</areas>
				</add>
				<add name="ASP" guid="{06b94d9a-b15e-456e-a4ef-37c984a2cb4b}">
					<areas>
						<clear />
					</areas>
				</add>
				<add name="ISAPI Extension" guid="{a1c2040e-8840-4c31-ba11-9871031a19ea}">
					<areas>
						<clear />
					</areas>
				</add>
				<add name="ASPNET" guid="{AFF081FE-0247-4275-9C4E-021F3DC1DA35}">
					<areas>
						<add name="Infrastructure" value="1" />
						<add name="Module" value="2" />
						<add name="Page" value="4" />
						<add name="AppServices" value="8" />
					</areas>
				</add>
			</traceProviderDefinitions>
		</tracing>
		<urlCompression />
		<validation />
		<webdav>
			<globalSettings>
				<propertyStores>
					<add name="webdav_simple_prop" image="%IIS_BIN%\webdav_simple_prop.dll" image32="%IIS_BIN%\webdav_simple_prop.dll" />
				</propertyStores>
				<lockStores>
					<add name="webdav_simple_lock" image="%IIS_BIN%\webdav_simple_lock.dll" image32="%IIS_BIN%\webdav_simple_lock.dll" />
				</lockStores>
			</globalSettings>
			<authoring>
				<locks enabled="true" lockStore="webdav_simple_lock" />
			</authoring>
			<authoringRules />
		</webdav>
		<webSocket />
		<applicationInitialization />
	</system.webServer>
	<location path="" overrideMode="Allow">
		<system.webServer>
			<modules>
				<add name="IsapiFilterModule" lockItem="true" />
				<add name="BasicAuthenticationModule" lockItem="true" />
				<add name="IsapiModule" lockItem="true" />
				<add name="HttpLoggingModule" lockItem="true" />
				<add name="DynamicCompressionModule" lockItem="true" />
				<add name="StaticCompressionModule" lockItem="true" />
				<add name="DefaultDocumentModule" lockItem="true" />
				<add name="DirectoryListingModule" lockItem="true" />
				<add name="ProtocolSupportModule" lockItem="true" />
				<add name="HttpRedirectionModule" lockItem="true" />
				<add name="ServerSideIncludeModule" lockItem="true" />
				<add name="StaticFileModule" lockItem="true" />
				<add name="AnonymousAuthenticationModule" lockItem="true" />
				<add name="CertificateMappingAuthenticationModule" lockItem="true" />
				<add name="UrlAuthorizationModule" lockItem="true" />
				<add name="WindowsAuthenticationModule" lockItem="true" />
				<add name="IISCertificateMappingAuthenticationModule" lockItem="true" />
				<add name="WebMatrixSupportModule" lockItem="true" />
				<add name="IpRestrictionModule" lockItem="true" />
				<add name="DynamicIpRestrictionModule" lockItem="true" />
				<add name="RequestFilteringModule" lockItem="true" />
				<add name="CustomLoggingModule" lockItem="true" />
				<add name="CustomErrorModule" lockItem="true" />
				<add name="FailedRequestsTracingModule" lockItem="true" />
				<add name="CgiModule" lockItem="true" />
				<add name="FastCgiModule" lockItem="true" />
				<!--                <add name="WebDAVModule" /> -->
				<add name="RewriteModule" />
				<add name="OutputCache" type="System.Web.Caching.OutputCacheModule" preCondition="managedHandler" />
				<add name="Session" type="System.Web.SessionState.SessionStateModule" preCondition="managedHandler" />
				<add name="WindowsAuthentication" type="System.Web.Security.WindowsAuthenticationModule" preCondition="managedHandler" />
				<add name="FormsAuthentication" type="System.Web.Security.FormsAuthenticationModule" preCondition="managedHandler" />
				<add name="DefaultAuthentication" type="System.Web.Security.DefaultAuthenticationModule" preCondition="managedHandler" />
				<add name="RoleManager" type="System.Web.Security.RoleManagerModule" preCondition="managedHandler" />
				<add name="UrlAuthorization" type="System.Web.Security.UrlAuthorizationModule" preCondition="managedHandler" />
				<add name="FileAuthorization" type="System.Web.Security.FileAuthorizationModule" preCondition="managedHandler" />
				<add name="AnonymousIdentification" type="System.Web.Security.AnonymousIdentificationModule" preCondition="managedHandler" />
				<add name="Profile" type="System.Web.Profile.ProfileModule" preCondition="managedHandler" />
				<add name="UrlMappingsModule" type="System.Web.UrlMappingsModule" preCondition="managedHandler" />
				<add name="ApplicationInitializationModule" lockItem="true" />
				<add name="WebSocketModule" lockItem="true" />
				<add name="ServiceModel-4.0" type="System.ServiceModel.Activation.ServiceHttpModule,System.ServiceModel.Activation,Version=4.0.0.0,Culture=neutral,PublicKeyToken=31bf3856ad364e35" preCondition="managedHandler,runtimeVersionv4.0" />
				<add name="ConfigurationValidationModule" lockItem="true" />
				<add name="UrlRoutingModule-4.0" type="System.Web.Routing.UrlRoutingModule" preCondition="managedHandler,runtimeVersionv4.0" />
				<add name="ScriptModule-4.0" type="System.Web.Handlers.ScriptModule, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" preCondition="managedHandler,runtimeVersionv4.0" />
				<add name="ServiceModel" type="System.ServiceModel.Activation.HttpModule, System.ServiceModel, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" preCondition="managedHandler,runtimeVersionv2.0" />
			</modules>
			<handlers accessPolicy="Read, Script">
				<!--                <add name="WebDAV" path="*" verb="PROPFIND,PROPPATCH,MKCOL,PUT,COPY,DELETE,MOVE,LOCK,UNLOCK" modules="WebDAVModule" resourceType="Unspecified" requireAccess="None" /> -->
				<add name="AXD-ISAPI-4.0_64bit" path="*.axd" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness64" responseBufferLimit="0" />
				<add name="PageHandlerFactory-ISAPI-4.0_64bit" path="*.aspx" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness64" responseBufferLimit="0" />
				<add name="SimpleHandlerFactory-ISAPI-4.0_64bit" path="*.ashx" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness64" responseBufferLimit="0" />
				<add name="WebServiceHandlerFactory-ISAPI-4.0_64bit" path="*.asmx" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness64" responseBufferLimit="0" />
				<add name="HttpRemotingHandlerFactory-rem-ISAPI-4.0_64bit" path="*.rem" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness64" responseBufferLimit="0" />
				<add name="HttpRemotingHandlerFactory-soap-ISAPI-4.0_64bit" path="*.soap" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness64" responseBufferLimit="0" />
				<add name="svc-ISAPI-4.0_64bit" path="*.svc" verb="*" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness64" />
				<add name="rules-ISAPI-4.0_64bit" path="*.rules" verb="*" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness64" />
				<add name="xoml-ISAPI-4.0_64bit" path="*.xoml" verb="*" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness64" />
				<add name="xamlx-ISAPI-4.0_64bit" path="*.xamlx" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness64" />
				<add name="aspq-ISAPI-4.0_64bit" path="*.aspq" verb="*" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness64" responseBufferLimit="0" />
				<add name="cshtm-ISAPI-4.0_64bit" path="*.cshtm" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness64" responseBufferLimit="0" />
				<add name="cshtml-ISAPI-4.0_64bit" path="*.cshtml" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness64" responseBufferLimit="0" />
				<add name="vbhtm-ISAPI-4.0_64bit" path="*.vbhtm" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness64" responseBufferLimit="0" />
				<add name="vbhtml-ISAPI-4.0_64bit" path="*.vbhtml" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness64" responseBufferLimit="0" />
				<add name="svc-Integrated" path="*.svc" verb="*" type="System.ServiceModel.Activation.HttpHandler, System.ServiceModel, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" preCondition="integratedMode,runtimeVersionv2.0" />
				<add name="svc-ISAPI-2.0" path="*.svc" verb="*" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness32" />
				<add name="xoml-Integrated" path="*.xoml" verb="*" type="System.ServiceModel.Activation.HttpHandler, System.ServiceModel, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" preCondition="integratedMode,runtimeVersionv2.0" />
				<add name="xoml-ISAPI-2.0" path="*.xoml" verb="*" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness32" />
				<add name="rules-Integrated" path="*.rules" verb="*" type="System.ServiceModel.Activation.HttpHandler, System.ServiceModel, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" preCondition="integratedMode,runtimeVersionv2.0" />
				<add name="rules-ISAPI-2.0" path="*.rules" verb="*" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness32" />
				<add name="AXD-ISAPI-4.0_32bit" path="*.axd" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness32" responseBufferLimit="0" />
				<add name="PageHandlerFactory-ISAPI-4.0_32bit" path="*.aspx" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness32" responseBufferLimit="0" />
				<add name="SimpleHandlerFactory-ISAPI-4.0_32bit" path="*.ashx" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness32" responseBufferLimit="0" />
				<add name="WebServiceHandlerFactory-ISAPI-4.0_32bit" path="*.asmx" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness32" responseBufferLimit="0" />
				<add name="HttpRemotingHandlerFactory-rem-ISAPI-4.0_32bit" path="*.rem" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness32" responseBufferLimit="0" />
				<add name="HttpRemotingHandlerFactory-soap-ISAPI-4.0_32bit" path="*.soap" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness32" responseBufferLimit="0" />
				<add name="svc-ISAPI-4.0_32bit" path="*.svc" verb="*" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness32" />
				<add name="rules-ISAPI-4.0_32bit" path="*.rules" verb="*" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness32" />
				<add name="xoml-ISAPI-4.0_32bit" path="*.xoml" verb="*" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness32" />
				<add name="xamlx-ISAPI-4.0_32bit" path="*.xamlx" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness32" />
				<add name="aspq-ISAPI-4.0_32bit" path="*.aspq" verb="*" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness32" responseBufferLimit="0" />
				<add name="cshtm-ISAPI-4.0_32bit" path="*.cshtm" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness32" responseBufferLimit="0" />
				<add name="cshtml-ISAPI-4.0_32bit" path="*.cshtml" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness32" responseBufferLimit="0" />
				<add name="vbhtm-ISAPI-4.0_32bit" path="*.vbhtm" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness32" responseBufferLimit="0" />
				<add name="vbhtml-ISAPI-4.0_32bit" path="*.vbhtml" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness32" responseBufferLimit="0" />
				<add name="TraceHandler-Integrated-4.0" path="trace.axd" verb="GET,HEAD,POST,DEBUG" type="System.Web.Handlers.TraceHandler" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="WebAdminHandler-Integrated-4.0" path="WebAdmin.axd" verb="GET,DEBUG" type="System.Web.Handlers.WebAdminHandler" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="AssemblyResourceLoader-Integrated-4.0" path="WebResource.axd" verb="GET,DEBUG" type="System.Web.Handlers.AssemblyResourceLoader" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="PageHandlerFactory-Integrated-4.0" path="*.aspx" verb="GET,HEAD,POST,DEBUG" type="System.Web.UI.PageHandlerFactory" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="SimpleHandlerFactory-Integrated-4.0" path="*.ashx" verb="GET,HEAD,POST,DEBUG" type="System.Web.UI.SimpleHandlerFactory" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="WebServiceHandlerFactory-Integrated-4.0" path="*.asmx" verb="GET,HEAD,POST,DEBUG" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="HttpRemotingHandlerFactory-rem-Integrated-4.0" path="*.rem" verb="GET,HEAD,POST,DEBUG" type="System.Runtime.Remoting.Channels.Http.HttpRemotingHandlerFactory, System.Runtime.Remoting, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="HttpRemotingHandlerFactory-soap-Integrated-4.0" path="*.soap" verb="GET,HEAD,POST,DEBUG" type="System.Runtime.Remoting.Channels.Http.HttpRemotingHandlerFactory, System.Runtime.Remoting, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="svc-Integrated-4.0" path="*.svc" verb="*" type="System.ServiceModel.Activation.ServiceHttpHandlerFactory, System.ServiceModel.Activation, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="rules-Integrated-4.0" path="*.rules" verb="*" type="System.ServiceModel.Activation.ServiceHttpHandlerFactory, System.ServiceModel.Activation, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="xoml-Integrated-4.0" path="*.xoml" verb="*" type="System.ServiceModel.Activation.ServiceHttpHandlerFactory, System.ServiceModel.Activation, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="xamlx-Integrated-4.0" path="*.xamlx" verb="GET,HEAD,POST,DEBUG" type="System.Xaml.Hosting.XamlHttpHandlerFactory, System.Xaml.Hosting, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="aspq-Integrated-4.0" path="*.aspq" verb="GET,HEAD,POST,DEBUG" type="System.Web.HttpForbiddenHandler" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="cshtm-Integrated-4.0" path="*.cshtm" verb="GET,HEAD,POST,DEBUG" type="System.Web.HttpForbiddenHandler" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="cshtml-Integrated-4.0" path="*.cshtml" verb="GET,HEAD,POST,DEBUG" type="System.Web.HttpForbiddenHandler" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="vbhtm-Integrated-4.0" path="*.vbhtm" verb="GET,HEAD,POST,DEBUG" type="System.Web.HttpForbiddenHandler" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="vbhtml-Integrated-4.0" path="*.vbhtml" verb="GET,HEAD,POST,DEBUG" type="System.Web.HttpForbiddenHandler" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="ScriptHandlerFactoryAppServices-Integrated-4.0" path="*_AppService.axd" verb="*" type="System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="ScriptResourceIntegrated-4.0" path="*ScriptResource.axd" verb="GET,HEAD" type="System.Web.Handlers.ScriptResourceHandler, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" preCondition="integratedMode,runtimeVersionv4.0" />
				<add name="ASPClassic" path="*.asp" verb="GET,HEAD,POST" modules="IsapiModule" scriptProcessor="%IIS_BIN%\asp.dll" resourceType="File" />
				<add name="SecurityCertificate" path="*.cer" verb="GET,HEAD,POST" modules="IsapiModule" scriptProcessor="%IIS_BIN%\asp.dll" resourceType="File" />
				<add name="ISAPI-dll" path="*.dll" verb="*" modules="IsapiModule" resourceType="File" requireAccess="Execute" allowPathInfo="true" />
				<add name="TraceHandler-Integrated" path="trace.axd" verb="GET,HEAD,POST,DEBUG" type="System.Web.Handlers.TraceHandler" preCondition="integratedMode,runtimeVersionv2.0" />
				<add name="WebAdminHandler-Integrated" path="WebAdmin.axd" verb="GET,DEBUG" type="System.Web.Handlers.WebAdminHandler" preCondition="integratedMode,runtimeVersionv2.0" />
				<add name="AssemblyResourceLoader-Integrated" path="WebResource.axd" verb="GET,DEBUG" type="System.Web.Handlers.AssemblyResourceLoader" preCondition="integratedMode,runtimeVersionv2.0" />
				<add name="PageHandlerFactory-Integrated" path="*.aspx" verb="GET,HEAD,POST,DEBUG" type="System.Web.UI.PageHandlerFactory" preCondition="integratedMode,runtimeVersionv2.0" />
				<add name="SimpleHandlerFactory-Integrated" path="*.ashx" verb="GET,HEAD,POST,DEBUG" type="System.Web.UI.SimpleHandlerFactory" preCondition="integratedMode,runtimeVersionv2.0" />
				<add name="WebServiceHandlerFactory-Integrated" path="*.asmx" verb="GET,HEAD,POST,DEBUG" type="System.Web.Services.Protocols.WebServiceHandlerFactory,System.Web.Services,Version=2.0.0.0,Culture=neutral,PublicKeyToken=b03f5f7f11d50a3a" preCondition="integratedMode,runtimeVersionv2.0" />
				<add name="HttpRemotingHandlerFactory-rem-Integrated" path="*.rem" verb="GET,HEAD,POST,DEBUG" type="System.Runtime.Remoting.Channels.Http.HttpRemotingHandlerFactory,System.Runtime.Remoting,Version=2.0.0.0,Culture=neutral,PublicKeyToken=b77a5c561934e089" preCondition="integratedMode,runtimeVersionv2.0" />
				<add name="HttpRemotingHandlerFactory-soap-Integrated" path="*.soap" verb="GET,HEAD,POST,DEBUG" type="System.Runtime.Remoting.Channels.Http.HttpRemotingHandlerFactory,System.Runtime.Remoting,Version=2.0.0.0,Culture=neutral,PublicKeyToken=b77a5c561934e089" preCondition="integratedMode,runtimeVersionv2.0" />
				<add name="AXD-ISAPI-2.0" path="*.axd" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness32" responseBufferLimit="0" />
				<add name="PageHandlerFactory-ISAPI-2.0" path="*.aspx" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness32" responseBufferLimit="0" />
				<add name="SimpleHandlerFactory-ISAPI-2.0" path="*.ashx" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness32" responseBufferLimit="0" />
				<add name="WebServiceHandlerFactory-ISAPI-2.0" path="*.asmx" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness32" responseBufferLimit="0" />
				<add name="HttpRemotingHandlerFactory-rem-ISAPI-2.0" path="*.rem" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness32" responseBufferLimit="0" />
				<add name="HttpRemotingHandlerFactory-soap-ISAPI-2.0" path="*.soap" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness32" responseBufferLimit="0" />
				<add name="svc-ISAPI-2.0-64" path="*.svc" verb="*" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness64" />
				<add name="AXD-ISAPI-2.0-64" path="*.axd" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness64" responseBufferLimit="0" />
				<add name="PageHandlerFactory-ISAPI-2.0-64" path="*.aspx" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness64" responseBufferLimit="0" />
				<add name="SimpleHandlerFactory-ISAPI-2.0-64" path="*.ashx" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness64" responseBufferLimit="0" />
				<add name="WebServiceHandlerFactory-ISAPI-2.0-64" path="*.asmx" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness64" responseBufferLimit="0" />
				<add name="HttpRemotingHandlerFactory-rem-ISAPI-2.0-64" path="*.rem" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness64" responseBufferLimit="0" />
				<add name="HttpRemotingHandlerFactory-soap-ISAPI-2.0-64" path="*.soap" verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness64" responseBufferLimit="0" />
				<add name="rules-64-ISAPI-2.0" path="*.rules" verb="*" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness64" />
				<add name="xoml-64-ISAPI-2.0" path="*.xoml" verb="*" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v2.0.50727\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv2.0,bitness64" />
				<add name="CGI-exe" path="*.exe" verb="*" modules="CgiModule" resourceType="File" requireAccess="Execute" allowPathInfo="true" />
				<add name="SSINC-stm" path="*.stm" verb="GET,HEAD,POST" modules="ServerSideIncludeModule" resourceType="File" />
				<add name="SSINC-shtm" path="*.shtm" verb="GET,HEAD,POST" modules="ServerSideIncludeModule" resourceType="File" />
				<add name="SSINC-shtml" path="*.shtml" verb="GET,HEAD,POST" modules="ServerSideIncludeModule" resourceType="File" />
				<add name="TRACEVerbHandler" path="*" verb="TRACE" modules="ProtocolSupportModule" requireAccess="None" />
				<add name="OPTIONSVerbHandler" path="*" verb="OPTIONS" modules="ProtocolSupportModule" requireAccess="None" />
				<add name="ExtensionlessUrlHandler-ISAPI-4.0_32bit" path="*." verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness32" responseBufferLimit="0" />
				<add name="ExtensionlessUrlHandler-ISAPI-4.0_64bit" path="*." verb="GET,HEAD,POST,DEBUG" modules="IsapiModule" scriptProcessor="%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_isapi.dll" preCondition="classicMode,runtimeVersionv4.0,bitness64" responseBufferLimit="0" />
				<add name="ExtensionlessUrlHandler-Integrated-4.0" path="*." verb="GET,HEAD,POST,DEBUG" type="System.Web.Handlers.TransferRequestHandler" preCondition="integratedMode,runtimeVersionv4.0" responseBufferLimit="0" />
				<add name="StaticFile" path="*" verb="*" modules="StaticFileModule,DefaultDocumentModule,DirectoryListingModule" resourceType="Either" requireAccess="Read" />
			</handlers>
		</system.webServer>
	</location>
</configuration>
```

## File: .vs/CondoSphere/v17/DocumentLayout.backup.json
```json
{
  "Version": 1,
  "WorkspaceRootPath": "C:\\Projectos\\CondoSphere\\",
  "Documents": [
    {
      "AbsoluteMoniker": "D:0:0:{3CD67153-1978-4AFB-A62C-CE4D630BE31B}|CondoSphere.API\\CondoSphere.API.csproj|c:\\projectos\\condosphere\\condosphere.api\\controllers\\accountscontroller.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{3CD67153-1978-4AFB-A62C-CE4D630BE31B}|CondoSphere.API\\CondoSphere.API.csproj|solutionrelative:condosphere.api\\controllers\\accountscontroller.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|c:\\projectos\\condosphere\\condosphere.web\\controllers\\condomanagementcontroller.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|solutionrelative:condosphere.web\\controllers\\condomanagementcontroller.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|c:\\projectos\\condosphere\\condosphere.web\\views\\condomanagement\\details.cshtml||{40D31677-CBC0-4297-A9EF-89D907823A98}",
      "RelativeMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|solutionrelative:condosphere.web\\views\\condomanagement\\details.cshtml||{40D31677-CBC0-4297-A9EF-89D907823A98}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|c:\\projectos\\condosphere\\condosphere.web\\models\\condominiumdetailsviewmodel.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|solutionrelative:condosphere.web\\models\\condominiumdetailsviewmodel.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|c:\\projectos\\condosphere\\condosphere.web\\services\\apiclient.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|solutionrelative:condosphere.web\\services\\apiclient.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{3CD67153-1978-4AFB-A62C-CE4D630BE31B}|CondoSphere.API\\CondoSphere.API.csproj|c:\\projectos\\condosphere\\condosphere.api\\controllers\\unitscontroller.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{3CD67153-1978-4AFB-A62C-CE4D630BE31B}|CondoSphere.API\\CondoSphere.API.csproj|solutionrelative:condosphere.api\\controllers\\unitscontroller.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{3CD67153-1978-4AFB-A62C-CE4D630BE31B}|CondoSphere.API\\CondoSphere.API.csproj|c:\\projectos\\condosphere\\condosphere.api\\program.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{3CD67153-1978-4AFB-A62C-CE4D630BE31B}|CondoSphere.API\\CondoSphere.API.csproj|solutionrelative:condosphere.api\\program.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{38537366-246F-4DB5-B861-3C250F99E8C7}|CondoSphere.Application\\CondoSphere.Application.csproj|c:\\projectos\\condosphere\\condosphere.application\\services\\condominium\\unitservice.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{38537366-246F-4DB5-B861-3C250F99E8C7}|CondoSphere.Application\\CondoSphere.Application.csproj|solutionrelative:condosphere.application\\services\\condominium\\unitservice.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{38537366-246F-4DB5-B861-3C250F99E8C7}|CondoSphere.Application\\CondoSphere.Application.csproj|c:\\projectos\\condosphere\\condosphere.application\\services\\condominium\\iunitservice.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{38537366-246F-4DB5-B861-3C250F99E8C7}|CondoSphere.Application\\CondoSphere.Application.csproj|solutionrelative:condosphere.application\\services\\condominium\\iunitservice.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|c:\\projectos\\condosphere\\condosphere.web\\views\\condomanagement\\index.cshtml||{40D31677-CBC0-4297-A9EF-89D907823A98}",
      "RelativeMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|solutionrelative:condosphere.web\\views\\condomanagement\\index.cshtml||{40D31677-CBC0-4297-A9EF-89D907823A98}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{38537366-246F-4DB5-B861-3C250F99E8C7}|CondoSphere.Application\\CondoSphere.Application.csproj|c:\\projectos\\condosphere\\condosphere.application\\services\\user\\userservice.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{38537366-246F-4DB5-B861-3C250F99E8C7}|CondoSphere.Application\\CondoSphere.Application.csproj|solutionrelative:condosphere.application\\services\\user\\userservice.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|c:\\projectos\\condosphere\\condosphere.web\\views\\condomanagement\\registerresident.cshtml||{40D31677-CBC0-4297-A9EF-89D907823A98}",
      "RelativeMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|solutionrelative:condosphere.web\\views\\condomanagement\\registerresident.cshtml||{40D31677-CBC0-4297-A9EF-89D907823A98}"
    }
  ],
  "DocumentGroupContainers": [
    {
      "Orientation": 0,
      "VerticalTabListWidth": 256,
      "DocumentGroups": [
        {
          "DockedWidth": 200,
          "SelectedChildIndex": 6,
          "Children": [
            {
              "$type": "Bookmark",
              "Name": "ST:0:0:{1c64b9c2-e352-428e-a56d-0ace190b99a6}"
            },
            {
              "$type": "Bookmark",
              "Name": "ST:0:0:{aa2115a1-9712-457b-9047-dbb71ca2cdd2}"
            },
            {
              "$type": "Bookmark",
              "Name": "ST:0:0:{3ae79031-e1bc-11d0-8f78-00a0c9110057}"
            },
            {
              "$type": "Bookmark",
              "Name": "ST:0:0:{d78612c7-9962-4b83-95d9-268046dad23a}"
            },
            {
              "$type": "Bookmark",
              "Name": "ST:0:0:{eefa5220-e298-11d0-8f78-00a0c9110057}"
            },
            {
              "$type": "Bookmark",
              "Name": "ST:129:0:{116d2292-e37d-41cd-a077-ebacac4c8cc4}"
            },
            {
              "$type": "Document",
              "DocumentIndex": 0,
              "Title": "AccountsController.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.API\\Controllers\\AccountsController.cs",
              "RelativeDocumentMoniker": "CondoSphere.API\\Controllers\\AccountsController.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.API\\Controllers\\AccountsController.cs",
              "RelativeToolTip": "CondoSphere.API\\Controllers\\AccountsController.cs",
              "ViewState": "AgIAAAkAAAAAAAAAAAAAABwAAAAiAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T15:45:03.667Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 2,
              "Title": "Details.cshtml",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Views\\CondoManagement\\Details.cshtml",
              "RelativeDocumentMoniker": "CondoSphere.Web\\Views\\CondoManagement\\Details.cshtml",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Views\\CondoManagement\\Details.cshtml",
              "RelativeToolTip": "CondoSphere.Web\\Views\\CondoManagement\\Details.cshtml",
              "ViewState": "AgIAAEAAAAAAAAAAAAAYwE8AAAAGAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000759|",
              "WhenOpened": "2025-08-01T15:39:36.397Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 3,
              "Title": "CondominiumDetailsViewModel.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Models\\CondominiumDetailsViewModel.cs",
              "RelativeDocumentMoniker": "CondoSphere.Web\\Models\\CondominiumDetailsViewModel.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Models\\CondominiumDetailsViewModel.cs",
              "RelativeToolTip": "CondoSphere.Web\\Models\\CondominiumDetailsViewModel.cs",
              "ViewState": "AgIAAAAAAAAAAAAAAAAAABMAAAABAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T15:36:29.572Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 4,
              "Title": "ApiClient.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Services\\ApiClient.cs",
              "RelativeDocumentMoniker": "CondoSphere.Web\\Services\\ApiClient.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Services\\ApiClient.cs",
              "RelativeToolTip": "CondoSphere.Web\\Services\\ApiClient.cs",
              "ViewState": "AgIAAEgAAAAAAAAAAAAkwG0AAAAJAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T15:35:55.193Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 5,
              "Title": "UnitsController.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.API\\Controllers\\UnitsController.cs",
              "RelativeDocumentMoniker": "CondoSphere.API\\Controllers\\UnitsController.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.API\\Controllers\\UnitsController.cs",
              "RelativeToolTip": "CondoSphere.API\\Controllers\\UnitsController.cs",
              "ViewState": "AgIAAGUAAAAAAAAAAAAYwHcAAAAJAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T15:35:20.882Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 6,
              "Title": "Program.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.API\\Program.cs",
              "RelativeDocumentMoniker": "CondoSphere.API\\Program.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.API\\Program.cs",
              "RelativeToolTip": "CondoSphere.API\\Program.cs",
              "ViewState": "AgIAADYAAAAAAAAAAAAnwGEAAAAvAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T15:34:27.807Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 7,
              "Title": "UnitService.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Application\\Services\\Condominium\\UnitService.cs",
              "RelativeDocumentMoniker": "CondoSphere.Application\\Services\\Condominium\\UnitService.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Application\\Services\\Condominium\\UnitService.cs",
              "RelativeToolTip": "CondoSphere.Application\\Services\\Condominium\\UnitService.cs",
              "ViewState": "AgIAADMAAAAAAAAAAAAAwEUAAAANAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T15:32:43.5Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 8,
              "Title": "IUnitService.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Application\\Services\\Condominium\\IUnitService.cs",
              "RelativeDocumentMoniker": "CondoSphere.Application\\Services\\Condominium\\IUnitService.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Application\\Services\\Condominium\\IUnitService.cs",
              "RelativeToolTip": "CondoSphere.Application\\Services\\Condominium\\IUnitService.cs",
              "ViewState": "AgIAAAAAAAAAAAAAAAAAAAsAAAA1AAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T15:32:07.177Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 9,
              "Title": "Index.cshtml",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Views\\CondoManagement\\Index.cshtml",
              "RelativeDocumentMoniker": "CondoSphere.Web\\Views\\CondoManagement\\Index.cshtml",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Views\\CondoManagement\\Index.cshtml",
              "RelativeToolTip": "CondoSphere.Web\\Views\\CondoManagement\\Index.cshtml",
              "ViewState": "AgIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000759|",
              "WhenOpened": "2025-08-01T15:22:47.334Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 10,
              "Title": "UserService.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Application\\Services\\User\\UserService.cs",
              "RelativeDocumentMoniker": "CondoSphere.Application\\Services\\User\\UserService.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Application\\Services\\User\\UserService.cs",
              "RelativeToolTip": "CondoSphere.Application\\Services\\User\\UserService.cs",
              "ViewState": "AgIAAJUAAAAAAAAAAAApwJoAAABZAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T14:43:44.411Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 11,
              "Title": "RegisterResident.cshtml",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Views\\CondoManagement\\RegisterResident.cshtml",
              "RelativeDocumentMoniker": "CondoSphere.Web\\Views\\CondoManagement\\RegisterResident.cshtml",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Views\\CondoManagement\\RegisterResident.cshtml",
              "RelativeToolTip": "CondoSphere.Web\\Views\\CondoManagement\\RegisterResident.cshtml",
              "ViewState": "AgIAAAAAAAAAAAAAAAAQwC0AAAABAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000759|",
              "WhenOpened": "2025-08-01T14:42:21.94Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 1,
              "Title": "CondoManagementController.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Controllers\\CondoManagementController.cs",
              "RelativeDocumentMoniker": "CondoSphere.Web\\Controllers\\CondoManagementController.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Controllers\\CondoManagementController.cs",
              "RelativeToolTip": "CondoSphere.Web\\Controllers\\CondoManagementController.cs",
              "ViewState": "AgIAAGYAAAAAAAAAAAAAwJAAAAAJAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T14:40:58.382Z",
              "EditorCaption": ""
            }
          ]
        }
      ]
    }
  ]
}
```

## File: .vs/CondoSphere/v17/DocumentLayout.json
```json
{
  "Version": 1,
  "WorkspaceRootPath": "C:\\Projectos\\CondoSphere\\",
  "Documents": [
    {
      "AbsoluteMoniker": "D:0:0:{3CD67153-1978-4AFB-A62C-CE4D630BE31B}|CondoSphere.API\\CondoSphere.API.csproj|c:\\projectos\\condosphere\\condosphere.api\\controllers\\accountscontroller.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{3CD67153-1978-4AFB-A62C-CE4D630BE31B}|CondoSphere.API\\CondoSphere.API.csproj|solutionrelative:condosphere.api\\controllers\\accountscontroller.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|c:\\projectos\\condosphere\\condosphere.web\\controllers\\condomanagementcontroller.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|solutionrelative:condosphere.web\\controllers\\condomanagementcontroller.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|c:\\projectos\\condosphere\\condosphere.web\\views\\condomanagement\\details.cshtml||{40D31677-CBC0-4297-A9EF-89D907823A98}",
      "RelativeMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|solutionrelative:condosphere.web\\views\\condomanagement\\details.cshtml||{40D31677-CBC0-4297-A9EF-89D907823A98}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|c:\\projectos\\condosphere\\condosphere.web\\models\\condominiumdetailsviewmodel.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|solutionrelative:condosphere.web\\models\\condominiumdetailsviewmodel.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|c:\\projectos\\condosphere\\condosphere.web\\services\\apiclient.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|solutionrelative:condosphere.web\\services\\apiclient.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{3CD67153-1978-4AFB-A62C-CE4D630BE31B}|CondoSphere.API\\CondoSphere.API.csproj|c:\\projectos\\condosphere\\condosphere.api\\controllers\\unitscontroller.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{3CD67153-1978-4AFB-A62C-CE4D630BE31B}|CondoSphere.API\\CondoSphere.API.csproj|solutionrelative:condosphere.api\\controllers\\unitscontroller.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{3CD67153-1978-4AFB-A62C-CE4D630BE31B}|CondoSphere.API\\CondoSphere.API.csproj|c:\\projectos\\condosphere\\condosphere.api\\program.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{3CD67153-1978-4AFB-A62C-CE4D630BE31B}|CondoSphere.API\\CondoSphere.API.csproj|solutionrelative:condosphere.api\\program.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{38537366-246F-4DB5-B861-3C250F99E8C7}|CondoSphere.Application\\CondoSphere.Application.csproj|c:\\projectos\\condosphere\\condosphere.application\\services\\condominium\\unitservice.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{38537366-246F-4DB5-B861-3C250F99E8C7}|CondoSphere.Application\\CondoSphere.Application.csproj|solutionrelative:condosphere.application\\services\\condominium\\unitservice.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{38537366-246F-4DB5-B861-3C250F99E8C7}|CondoSphere.Application\\CondoSphere.Application.csproj|c:\\projectos\\condosphere\\condosphere.application\\services\\condominium\\iunitservice.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{38537366-246F-4DB5-B861-3C250F99E8C7}|CondoSphere.Application\\CondoSphere.Application.csproj|solutionrelative:condosphere.application\\services\\condominium\\iunitservice.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|c:\\projectos\\condosphere\\condosphere.web\\views\\condomanagement\\index.cshtml||{40D31677-CBC0-4297-A9EF-89D907823A98}",
      "RelativeMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|solutionrelative:condosphere.web\\views\\condomanagement\\index.cshtml||{40D31677-CBC0-4297-A9EF-89D907823A98}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{38537366-246F-4DB5-B861-3C250F99E8C7}|CondoSphere.Application\\CondoSphere.Application.csproj|c:\\projectos\\condosphere\\condosphere.application\\services\\user\\userservice.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}",
      "RelativeMoniker": "D:0:0:{38537366-246F-4DB5-B861-3C250F99E8C7}|CondoSphere.Application\\CondoSphere.Application.csproj|solutionrelative:condosphere.application\\services\\user\\userservice.cs||{A6C744A8-0E4A-4FC6-886A-064283054674}"
    },
    {
      "AbsoluteMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|c:\\projectos\\condosphere\\condosphere.web\\views\\condomanagement\\registerresident.cshtml||{40D31677-CBC0-4297-A9EF-89D907823A98}",
      "RelativeMoniker": "D:0:0:{1E1FC90D-B1C1-4A4A-B8AE-F8FA723036EA}|CondoSphere.Web\\CondoSphere.Web.csproj|solutionrelative:condosphere.web\\views\\condomanagement\\registerresident.cshtml||{40D31677-CBC0-4297-A9EF-89D907823A98}"
    }
  ],
  "DocumentGroupContainers": [
    {
      "Orientation": 0,
      "VerticalTabListWidth": 256,
      "DocumentGroups": [
        {
          "DockedWidth": 200,
          "SelectedChildIndex": 6,
          "Children": [
            {
              "$type": "Bookmark",
              "Name": "ST:0:0:{1c64b9c2-e352-428e-a56d-0ace190b99a6}"
            },
            {
              "$type": "Bookmark",
              "Name": "ST:0:0:{aa2115a1-9712-457b-9047-dbb71ca2cdd2}"
            },
            {
              "$type": "Bookmark",
              "Name": "ST:0:0:{3ae79031-e1bc-11d0-8f78-00a0c9110057}"
            },
            {
              "$type": "Bookmark",
              "Name": "ST:0:0:{d78612c7-9962-4b83-95d9-268046dad23a}"
            },
            {
              "$type": "Bookmark",
              "Name": "ST:0:0:{eefa5220-e298-11d0-8f78-00a0c9110057}"
            },
            {
              "$type": "Bookmark",
              "Name": "ST:129:0:{116d2292-e37d-41cd-a077-ebacac4c8cc4}"
            },
            {
              "$type": "Document",
              "DocumentIndex": 0,
              "Title": "AccountsController.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.API\\Controllers\\AccountsController.cs",
              "RelativeDocumentMoniker": "CondoSphere.API\\Controllers\\AccountsController.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.API\\Controllers\\AccountsController.cs",
              "RelativeToolTip": "CondoSphere.API\\Controllers\\AccountsController.cs",
              "ViewState": "AgIAAAkAAAAAAAAAAAAAABwAAAAiAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T15:45:03.667Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 2,
              "Title": "Details.cshtml",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Views\\CondoManagement\\Details.cshtml",
              "RelativeDocumentMoniker": "CondoSphere.Web\\Views\\CondoManagement\\Details.cshtml",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Views\\CondoManagement\\Details.cshtml",
              "RelativeToolTip": "CondoSphere.Web\\Views\\CondoManagement\\Details.cshtml",
              "ViewState": "AgIAAEAAAAAAAAAAAAAYwE8AAAAGAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000759|",
              "WhenOpened": "2025-08-01T15:39:36.397Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 3,
              "Title": "CondominiumDetailsViewModel.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Models\\CondominiumDetailsViewModel.cs",
              "RelativeDocumentMoniker": "CondoSphere.Web\\Models\\CondominiumDetailsViewModel.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Models\\CondominiumDetailsViewModel.cs",
              "RelativeToolTip": "CondoSphere.Web\\Models\\CondominiumDetailsViewModel.cs",
              "ViewState": "AgIAAAAAAAAAAAAAAAAAABMAAAABAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T15:36:29.572Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 4,
              "Title": "ApiClient.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Services\\ApiClient.cs",
              "RelativeDocumentMoniker": "CondoSphere.Web\\Services\\ApiClient.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Services\\ApiClient.cs",
              "RelativeToolTip": "CondoSphere.Web\\Services\\ApiClient.cs",
              "ViewState": "AgIAAEgAAAAAAAAAAAAkwG0AAAAJAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T15:35:55.193Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 5,
              "Title": "UnitsController.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.API\\Controllers\\UnitsController.cs",
              "RelativeDocumentMoniker": "CondoSphere.API\\Controllers\\UnitsController.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.API\\Controllers\\UnitsController.cs",
              "RelativeToolTip": "CondoSphere.API\\Controllers\\UnitsController.cs",
              "ViewState": "AgIAAGUAAAAAAAAAAAAYwHcAAAAJAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T15:35:20.882Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 6,
              "Title": "Program.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.API\\Program.cs",
              "RelativeDocumentMoniker": "CondoSphere.API\\Program.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.API\\Program.cs",
              "RelativeToolTip": "CondoSphere.API\\Program.cs",
              "ViewState": "AgIAADYAAAAAAAAAAAAnwGEAAAAvAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T15:34:27.807Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 7,
              "Title": "UnitService.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Application\\Services\\Condominium\\UnitService.cs",
              "RelativeDocumentMoniker": "CondoSphere.Application\\Services\\Condominium\\UnitService.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Application\\Services\\Condominium\\UnitService.cs",
              "RelativeToolTip": "CondoSphere.Application\\Services\\Condominium\\UnitService.cs",
              "ViewState": "AgIAADMAAAAAAAAAAAAAwEUAAAANAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T15:32:43.5Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 8,
              "Title": "IUnitService.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Application\\Services\\Condominium\\IUnitService.cs",
              "RelativeDocumentMoniker": "CondoSphere.Application\\Services\\Condominium\\IUnitService.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Application\\Services\\Condominium\\IUnitService.cs",
              "RelativeToolTip": "CondoSphere.Application\\Services\\Condominium\\IUnitService.cs",
              "ViewState": "AgIAAAAAAAAAAAAAAAAAAAsAAAA1AAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T15:32:07.177Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 9,
              "Title": "Index.cshtml",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Views\\CondoManagement\\Index.cshtml",
              "RelativeDocumentMoniker": "CondoSphere.Web\\Views\\CondoManagement\\Index.cshtml",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Views\\CondoManagement\\Index.cshtml",
              "RelativeToolTip": "CondoSphere.Web\\Views\\CondoManagement\\Index.cshtml",
              "ViewState": "AgIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000759|",
              "WhenOpened": "2025-08-01T15:22:47.334Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 10,
              "Title": "UserService.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Application\\Services\\User\\UserService.cs",
              "RelativeDocumentMoniker": "CondoSphere.Application\\Services\\User\\UserService.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Application\\Services\\User\\UserService.cs",
              "RelativeToolTip": "CondoSphere.Application\\Services\\User\\UserService.cs",
              "ViewState": "AgIAAJUAAAAAAAAAAAApwJoAAABZAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T14:43:44.411Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 11,
              "Title": "RegisterResident.cshtml",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Views\\CondoManagement\\RegisterResident.cshtml",
              "RelativeDocumentMoniker": "CondoSphere.Web\\Views\\CondoManagement\\RegisterResident.cshtml",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Views\\CondoManagement\\RegisterResident.cshtml",
              "RelativeToolTip": "CondoSphere.Web\\Views\\CondoManagement\\RegisterResident.cshtml",
              "ViewState": "AgIAAAAAAAAAAAAAAAAQwC0AAAABAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000759|",
              "WhenOpened": "2025-08-01T14:42:21.94Z",
              "EditorCaption": ""
            },
            {
              "$type": "Document",
              "DocumentIndex": 1,
              "Title": "CondoManagementController.cs",
              "DocumentMoniker": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Controllers\\CondoManagementController.cs",
              "RelativeDocumentMoniker": "CondoSphere.Web\\Controllers\\CondoManagementController.cs",
              "ToolTip": "C:\\Projectos\\CondoSphere\\CondoSphere.Web\\Controllers\\CondoManagementController.cs",
              "RelativeToolTip": "CondoSphere.Web\\Controllers\\CondoManagementController.cs",
              "ViewState": "AgIAAGYAAAAAAAAAAAAAwJAAAAAJAAAAAAAAAA==",
              "Icon": "ae27a6b0-e345-4288-96df-5eaf394ee369.000738|",
              "WhenOpened": "2025-08-01T14:40:58.382Z",
              "EditorCaption": ""
            }
          ]
        }
      ]
    }
  ]
}
```

## File: .vs/CondoSphere/v17/HierarchyCache.v1.txt
```
++Solution 'CondoSphere' ‎ (5 of 5 projects)
i:{00000000-0000-0000-0000-000000000000}:CondoSphere.sln
++CondoSphere.API
i:{00000000-0000-0000-0000-000000000000}:CondoSphere.API
++Connected Services 
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1561
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:>1562
++Dependencies
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1566
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:>995
i:{38537366-246f-4db5-b861-3c250f99e8c7}:>997
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:>996
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:>1565
++Properties
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\projectos\condosphere\condosphere.api\properties\
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\properties\
++launchSettings.json
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\projectos\condosphere\condosphere.api\properties\launchsettings.json
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\properties\launchsettings.json
++Controllers
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\projectos\condosphere\condosphere.api\controllers\
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\controllers\
++AccountsController.cs
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\projectos\condosphere\condosphere.api\controllers\accountscontroller.cs
++CondominiumsController.cs
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\projectos\condosphere\condosphere.api\controllers\condominiumscontroller.cs
++ResidentsController.cs
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\projectos\condosphere\condosphere.api\controllers\residentscontroller.cs
++UnitsController.cs
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\projectos\condosphere\condosphere.api\controllers\unitscontroller.cs
++appsettings.json
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\projectos\condosphere\condosphere.api\appsettings.json
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\appsettings.json
++CondoSphere.API.http
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\projectos\condosphere\condosphere.api\condosphere.api.http
++Program.cs
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\projectos\condosphere\condosphere.api\program.cs
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\program.cs
++No service dependencies discovered
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1563
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:>1564
++Analyzers
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1667
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:>1568
i:{38537366-246f-4db5-b861-3c250f99e8c7}:>1617
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:>1639
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:>1570
++Frameworks
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1690
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:>1611
i:{38537366-246f-4db5-b861-3c250f99e8c7}:>1628
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:>1656
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:>1594
++Packages
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1693
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:>1613
i:{38537366-246f-4db5-b861-3c250f99e8c7}:>1630
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:>1659
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:>1597
++Projects
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1663
i:{38537366-246f-4db5-b861-3c250f99e8c7}:>1615
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:>1636
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:>1567
++appsettings.Development.json
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\projectos\condosphere\condosphere.api\appsettings.development.json
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\appsettings.development.json
++Microsoft.AspNetCore.Analyzers
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk.web\analyzers\cs\microsoft.aspnetcore.analyzers.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk.web\analyzers\cs\microsoft.aspnetcore.analyzers.dll
++Microsoft.AspNetCore.App.Analyzers
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\packs\microsoft.aspnetcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.aspnetcore.app.analyzers.dll
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\program files\dotnet\packs\microsoft.aspnetcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.aspnetcore.app.analyzers.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\packs\microsoft.aspnetcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.aspnetcore.app.analyzers.dll
++Microsoft.AspNetCore.App.CodeFixes
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\packs\microsoft.aspnetcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.aspnetcore.app.codefixes.dll
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\program files\dotnet\packs\microsoft.aspnetcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.aspnetcore.app.codefixes.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\packs\microsoft.aspnetcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.aspnetcore.app.codefixes.dll
++Microsoft.AspNetCore.Components.Analyzers
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\packs\microsoft.aspnetcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.aspnetcore.components.analyzers.dll
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\program files\dotnet\packs\microsoft.aspnetcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.aspnetcore.components.analyzers.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\packs\microsoft.aspnetcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.aspnetcore.components.analyzers.dll
++Microsoft.AspNetCore.Mvc.Analyzers
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk.web\analyzers\cs\microsoft.aspnetcore.mvc.analyzers.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk.web\analyzers\cs\microsoft.aspnetcore.mvc.analyzers.dll
++Microsoft.AspNetCore.Razor.Utilities.Shared
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk.razor\source-generators\microsoft.aspnetcore.razor.utilities.shared.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk.razor\source-generators\microsoft.aspnetcore.razor.utilities.shared.dll
++Microsoft.CodeAnalysis.Analyzers
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\users\fredp\.nuget\packages\microsoft.codeanalysis.analyzers\3.3.3\analyzers\dotnet\cs\microsoft.codeanalysis.analyzers.dll
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\users\fredp\.nuget\packages\microsoft.codeanalysis.analyzers\3.3.3\analyzers\dotnet\cs\microsoft.codeanalysis.analyzers.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\users\fredp\.nuget\packages\microsoft.codeanalysis.analyzers\3.3.3\analyzers\dotnet\cs\microsoft.codeanalysis.analyzers.dll
++Microsoft.CodeAnalysis.CSharp.Analyzers
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\users\fredp\.nuget\packages\microsoft.codeanalysis.analyzers\3.3.3\analyzers\dotnet\cs\microsoft.codeanalysis.csharp.analyzers.dll
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\users\fredp\.nuget\packages\microsoft.codeanalysis.analyzers\3.3.3\analyzers\dotnet\cs\microsoft.codeanalysis.csharp.analyzers.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\users\fredp\.nuget\packages\microsoft.codeanalysis.analyzers\3.3.3\analyzers\dotnet\cs\microsoft.codeanalysis.csharp.analyzers.dll
++Microsoft.CodeAnalysis.CSharp.NetAnalyzers
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk\analyzers\microsoft.codeanalysis.csharp.netanalyzers.dll
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk\analyzers\microsoft.codeanalysis.csharp.netanalyzers.dll
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk\analyzers\microsoft.codeanalysis.csharp.netanalyzers.dll
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk\analyzers\microsoft.codeanalysis.csharp.netanalyzers.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk\analyzers\microsoft.codeanalysis.csharp.netanalyzers.dll
++Microsoft.CodeAnalysis.NetAnalyzers
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk\analyzers\microsoft.codeanalysis.netanalyzers.dll
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk\analyzers\microsoft.codeanalysis.netanalyzers.dll
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk\analyzers\microsoft.codeanalysis.netanalyzers.dll
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk\analyzers\microsoft.codeanalysis.netanalyzers.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk\analyzers\microsoft.codeanalysis.netanalyzers.dll
++Microsoft.CodeAnalysis.Razor.Compiler
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk.razor\source-generators\microsoft.codeanalysis.razor.compiler.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk.razor\source-generators\microsoft.codeanalysis.razor.compiler.dll
++Microsoft.EntityFrameworkCore.Analyzers
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\users\fredp\.nuget\packages\microsoft.entityframeworkcore.analyzers\8.0.18\analyzers\dotnet\cs\microsoft.entityframeworkcore.analyzers.dll
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\users\fredp\.nuget\packages\microsoft.entityframeworkcore.analyzers\8.0.18\analyzers\dotnet\cs\microsoft.entityframeworkcore.analyzers.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\users\fredp\.nuget\packages\microsoft.entityframeworkcore.analyzers\8.0.18\analyzers\dotnet\cs\microsoft.entityframeworkcore.analyzers.dll
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\users\fredp\.nuget\packages\microsoft.entityframeworkcore.analyzers\8.0.18\analyzers\dotnet\cs\microsoft.entityframeworkcore.analyzers.dll
++Microsoft.Extensions.Logging.Generators
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\packs\microsoft.aspnetcore.app.ref\8.0.18\analyzers\dotnet\roslyn4.4\cs\microsoft.extensions.logging.generators.dll
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\users\fredp\.nuget\packages\microsoft.extensions.logging.abstractions\8.0.2\analyzers\dotnet\roslyn4.4\cs\microsoft.extensions.logging.generators.dll
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\users\fredp\.nuget\packages\microsoft.extensions.logging.abstractions\8.0.3\analyzers\dotnet\roslyn4.4\cs\microsoft.extensions.logging.generators.dll
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\program files\dotnet\packs\microsoft.aspnetcore.app.ref\8.0.18\analyzers\dotnet\roslyn4.4\cs\microsoft.extensions.logging.generators.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\packs\microsoft.aspnetcore.app.ref\8.0.18\analyzers\dotnet\roslyn4.4\cs\microsoft.extensions.logging.generators.dll
++Microsoft.Extensions.ObjectPool
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk.razor\source-generators\microsoft.extensions.objectpool.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk.razor\source-generators\microsoft.extensions.objectpool.dll
++Microsoft.Extensions.Options.SourceGeneration
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\packs\microsoft.aspnetcore.app.ref\8.0.18\analyzers\dotnet\roslyn4.4\cs\microsoft.extensions.options.sourcegeneration.dll
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\users\fredp\.nuget\packages\microsoft.extensions.options\8.0.2\analyzers\dotnet\roslyn4.4\cs\microsoft.extensions.options.sourcegeneration.dll
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\users\fredp\.nuget\packages\microsoft.extensions.options\8.0.2\analyzers\dotnet\roslyn4.4\cs\microsoft.extensions.options.sourcegeneration.dll
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\program files\dotnet\packs\microsoft.aspnetcore.app.ref\8.0.18\analyzers\dotnet\roslyn4.4\cs\microsoft.extensions.options.sourcegeneration.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\packs\microsoft.aspnetcore.app.ref\8.0.18\analyzers\dotnet\roslyn4.4\cs\microsoft.extensions.options.sourcegeneration.dll
++Microsoft.Interop.ComInterfaceGenerator
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.cominterfacegenerator.dll
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.cominterfacegenerator.dll
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.cominterfacegenerator.dll
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.cominterfacegenerator.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.cominterfacegenerator.dll
++Microsoft.Interop.JavaScript.JSImportGenerator
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.javascript.jsimportgenerator.dll
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.javascript.jsimportgenerator.dll
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.javascript.jsimportgenerator.dll
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.javascript.jsimportgenerator.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.javascript.jsimportgenerator.dll
++Microsoft.Interop.LibraryImportGenerator
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.libraryimportgenerator.dll
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.libraryimportgenerator.dll
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.libraryimportgenerator.dll
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.libraryimportgenerator.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.libraryimportgenerator.dll
++Microsoft.Interop.SourceGeneration
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.sourcegeneration.dll
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.sourcegeneration.dll
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.sourcegeneration.dll
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.sourcegeneration.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\microsoft.interop.sourcegeneration.dll
++System.Collections.Immutable
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk.razor\source-generators\system.collections.immutable.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\sdk\9.0.302\sdks\microsoft.net.sdk.razor\source-generators\system.collections.immutable.dll
++System.Text.Json.SourceGeneration
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\system.text.json.sourcegeneration.dll
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\system.text.json.sourcegeneration.dll
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\system.text.json.sourcegeneration.dll
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\system.text.json.sourcegeneration.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\system.text.json.sourcegeneration.dll
++System.Text.RegularExpressions.Generator
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\system.text.regularexpressions.generator.dll
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\system.text.regularexpressions.generator.dll
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\system.text.regularexpressions.generator.dll
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\system.text.regularexpressions.generator.dll
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\program files\dotnet\packs\microsoft.netcore.app.ref\8.0.18\analyzers\dotnet\cs\system.text.regularexpressions.generator.dll
++Microsoft.AspNetCore.App
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1691
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:>1657
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:>1595
++Microsoft.NETCore.App
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1692
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:>1612
i:{38537366-246f-4db5-b861-3c250f99e8c7}:>1629
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:>1658
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:>1596
++AutoMapper (15.0.0)
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1697
i:{38537366-246f-4db5-b861-3c250f99e8c7}:>1635
++FluentValidation.DependencyInjectionExtensions (12.0.0)
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1694
++Microsoft.AspNetCore.Authentication.JwtBearer (8.0.18)
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1698
++Microsoft.EntityFrameworkCore.Design (8.0.18)
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1695
++Swashbuckle.AspNetCore (6.6.2)
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1696
++CondoSphere.Application
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1666
i:{02ea681e-c7d8-13c7-8484-4ac65e1b71e8}:CondoSphere.Application
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:>1638
++CondoSphere.Core
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1665
i:{02ea681e-c7d8-13c7-8484-4ac65e1b71e8}:CondoSphere.Core
i:{38537366-246f-4db5-b861-3c250f99e8c7}:>1616
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:>1637
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:>1569
++CondoSphere.Infrastructure
i:{3cd67153-1978-4afb-a62c-ce4d630be31b}:>1664
i:{02ea681e-c7d8-13c7-8484-4ac65e1b71e8}:CondoSphere.Infrastructure
++Libraries
i:{00000000-0000-0000-0000-000000000000}:Libraries
++DTOs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\dtos\
++Account
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\dtos\account\
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\account\
++AssignManagerDto.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\dtos\account\assignmanagerdto.cs
++LoginDto.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\dtos\account\logindto.cs
++RegisterDto.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\dtos\account\registerdto.cs
++RegisterManagerDto.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\dtos\account\registermanagerdto.cs
++RegisterResidentDto.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\dtos\account\registerresidentdto.cs
++SetPasswordDto.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\dtos\account\setpassworddto.cs
++UserDto.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\dtos\account\userdto.cs
++UserListDto.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\dtos\account\userlistdto.cs
++Condominiums
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\dtos\condominiums\
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\condominiums\
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\validators\condominiums\
++Entities
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\
++Enums
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\enums\
++IEntity.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\ientity.cs
++RoleConstants.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\roleconstants.cs
++CondominiumDto.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\dtos\condominiums\condominiumdto.cs
++CreateUpdateCondominiumDto.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\dtos\condominiums\createupdatecondominiumdto.cs
++CreateUpdateUnitDto.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\dtos\condominiums\createupdateunitdto.cs
++UnitDto.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\dtos\condominiums\unitdto.cs
++Financials
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\financials\
++Users
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\users\
++InterventionStatus.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\enums\interventionstatus.cs
++OccurrenceStatus.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\enums\occurrencestatus.cs
++SystemRole.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\enums\systemrole.cs
++UnitQuotaStatus.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\enums\unitquotastatus.cs
++Microsoft.Extensions.Identity.Stores (8.0.18)
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:>1614
++Assembly.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\condominiums\assembly.cs
++Condominium.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\condominiums\condominium.cs
++Document.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\condominiums\document.cs
++Intervention.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\condominiums\intervention.cs
++Occurrence.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\condominiums\occurrence.cs
++Unit.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\condominiums\unit.cs
++Expense.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\financials\expense.cs
++QuotaPayment.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\financials\quotapayment.cs
++Receipt.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\financials\receipt.cs
++UnitQuota.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\financials\unitquota.cs
++Company.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\users\company.cs
++Notification.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\users\notification.cs
++User.cs
i:{0e6bf8fa-9c45-4820-b08e-bc9bb2e2cbc1}:c:\projectos\condosphere\condosphere.core\entities\users\user.cs
++Authorization
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\authorization\
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\authorization\
++Interfaces
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\interfaces\
++Mappings
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\mappings\
++Services
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\services\
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\services\
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\services\
++Validators
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\validators\
++IsCondoManagerRequirement.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\authorization\iscondomanagerrequirement.cs
++ICompanyRepository.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\interfaces\icompanyrepository.cs
++ICondominiumRepository.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\interfaces\icondominiumrepository.cs
++ICurrentUserService.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\interfaces\icurrentuserservice.cs
++IMailService.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\interfaces\imailservice.cs
++IUnitOfWork.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\interfaces\iunitofwork.cs
++IUnitRepository.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\interfaces\iunitrepository.cs
++IUserRepository.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\interfaces\iuserrepository.cs
++CondominiumProfile.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\mappings\condominiumprofile.cs
++UnitProfile.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\mappings\unitprofile.cs
++Condominium
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\services\condominium\
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\migrations\condominium\
++Token
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\services\token\
++User
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\services\user\
++FluentValidation (12.0.0)
i:{38537366-246f-4db5-b861-3c250f99e8c7}:>1634
++Microsoft.AspNetCore.Authorization (8.0.18)
i:{38537366-246f-4db5-b861-3c250f99e8c7}:>1633
++Microsoft.AspNetCore.Identity (2.3.1)
i:{38537366-246f-4db5-b861-3c250f99e8c7}:>1632
++System.IdentityModel.Tokens.Jwt (8.12.1)
i:{38537366-246f-4db5-b861-3c250f99e8c7}:>1631
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:>1599
++CondominiumService.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\services\condominium\condominiumservice.cs
++ICondominiumService.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\services\condominium\icondominiumservice.cs
++IUnitService.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\services\condominium\iunitservice.cs
++UnitService.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\services\condominium\unitservice.cs
++ITokenService.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\services\token\itokenservice.cs
++TokenService.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\services\token\tokenservice.cs
++IUserService.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\services\user\iuserservice.cs
++UserService.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\services\user\userservice.cs
++CreateUpdateCondominiumDtoValidator.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\validators\condominiums\createupdatecondominiumdtovalidator.cs
++CreateUpdateUnitDtoValidator.cs
i:{38537366-246f-4db5-b861-3c250f99e8c7}:c:\projectos\condosphere\condosphere.application\validators\condominiums\createupdateunitdtovalidator.cs
++Data
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\
++Repositories
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\repositories\
++IsCondoManagerHandler.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\authorization\iscondomanagerhandler.cs
++Migrations
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\migrations\
++CondominiumDbContext.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\condominiumdbcontext.cs
++SeedDb.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\seeddb.cs
++UserManagementDbContext.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\usermanagementdbcontext.cs
++CompanyRepository.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\repositories\companyrepository.cs
++CondominiumRepository.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\repositories\condominiumrepository.cs
++UnitOfWork.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\repositories\unitofwork.cs
++UnitRepository.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\repositories\unitrepository.cs
++UserRepository.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\repositories\userrepository.cs
++CurrentUserService.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\services\currentuserservice.cs
++MailService.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\services\mailservice.cs
++Microsoft.AspNetCore.Identity.EntityFrameworkCore (8.0.18)
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:>1661
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:>1600
++Microsoft.EntityFrameworkCore.SqlServer (8.0.18)
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:>1660
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:>1598
++Microsoft.EntityFrameworkCore.Tools (8.0.18)
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:>1662
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:>1601
++UserManagement
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\migrations\usermanagement\
++20250709181303_InitialCondoDbCreate.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\migrations\condominium\20250709181303_initialcondodbcreate.cs
++20250710095332_AddManagerIdToCondominium.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\migrations\condominium\20250710095332_addmanageridtocondominium.cs
++20250714114014_AddResidentIdToUnit.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\migrations\condominium\20250714114014_addresidentidtounit.cs
++CondominiumDbContextModelSnapshot.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\migrations\condominium\condominiumdbcontextmodelsnapshot.cs
++20250708211620_InitialUserDbCreate.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\migrations\usermanagement\20250708211620_initialuserdbcreate.cs
++UserManagementDbContextModelSnapshot.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\migrations\usermanagement\usermanagementdbcontextmodelsnapshot.cs
++20250709181303_InitialCondoDbCreate.Designer.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\migrations\condominium\20250709181303_initialcondodbcreate.designer.cs
++20250710095332_AddManagerIdToCondominium.Designer.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\migrations\condominium\20250710095332_addmanageridtocondominium.designer.cs
++20250714114014_AddResidentIdToUnit.Designer.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\migrations\condominium\20250714114014_addresidentidtounit.designer.cs
++20250708211620_InitialUserDbCreate.Designer.cs
i:{b0f6b621-c045-46cd-833d-c61526c966f1}:c:\projectos\condosphere\condosphere.infrastructure\data\migrations\usermanagement\20250708211620_initialuserdbcreate.designer.cs
++CondoSphere.Web
i:{00000000-0000-0000-0000-000000000000}:CondoSphere.Web
++wwwroot
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\
++AccountController.cs
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\controllers\accountcontroller.cs
++CondoManagementController.cs
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\controllers\condomanagementcontroller.cs
++HomeController.cs
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\controllers\homecontroller.cs
++ManagementController.cs
++Models
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\models\
++CondominiumDetailsViewModel.cs
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\models\condominiumdetailsviewmodel.cs
++ErrorViewModel.cs
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\models\errorviewmodel.cs
++ManagementDashboardViewModel.cs
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\models\managementdashboardviewmodel.cs
++ApiClient.cs
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\services\apiclient.cs
++JwtForwardingDelegatingHandler.cs
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\services\jwtforwardingdelegatinghandler.cs
++Views
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\
++Login.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\account\login.cshtml
++SetPassword.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\account\setpassword.cshtml
++Home
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\home\
++Management
++Index.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\home\index.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\administration\index.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\condomanagement\index.cshtml
++RegisterManager.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\administration\registermanager.cshtml
++Shared
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\shared\
++_Layout.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\shared\_layout.cshtml
++_LoginPartial.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\shared\_loginpartial.cshtml
++_ValidationScriptsPartial.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\shared\_validationscriptspartial.cshtml
++Error.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\shared\error.cshtml
++_ViewImports.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\_viewimports.cshtml
++_ViewStart.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\_viewstart.cshtml
++css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\css\
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\
++js
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\js\
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\js\
++lib
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\
++favicon.ico
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\favicon.ico
++Privacy.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\home\privacy.cshtml
++_Layout.cshtml.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\shared\_layout.cshtml.css
++site.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\css\site.css
++site.js
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\js\site.js
++bootstrap
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\
++jquery
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery\
++jquery-validation
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery-validation\
++jquery-validation-unobtrusive
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery-validation-unobtrusive\
++dist
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery\dist\
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery-validation\dist\
++LICENSE
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\license
++LICENSE.txt
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery\license.txt
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery-validation-unobtrusive\license.txt
++LICENSE.md
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery-validation\license.md
++jquery.validate.unobtrusive.js
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery-validation-unobtrusive\jquery.validate.unobtrusive.js
++jquery.js
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery\dist\jquery.js
++additional-methods.js
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery-validation\dist\additional-methods.js
++jquery.validate.js
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery-validation\dist\jquery.validate.js
++jquery.validate.unobtrusive.min.js
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery-validation-unobtrusive\jquery.validate.unobtrusive.min.js
++bootstrap.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap.css
++bootstrap-grid.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-grid.css
++bootstrap-reboot.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-reboot.css
++bootstrap-utilities.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-utilities.css
++bootstrap.js
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\js\bootstrap.js
++jquery.min.js
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery\dist\jquery.min.js
++additional-methods.min.js
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery-validation\dist\additional-methods.min.js
++jquery.validate.min.js
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery-validation\dist\jquery.validate.min.js
++bootstrap.css.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap.css.map
++bootstrap.min.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap.min.css
++bootstrap.rtl.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap.rtl.css
++bootstrap-grid.css.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-grid.css.map
++bootstrap-grid.min.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-grid.min.css
++bootstrap-grid.rtl.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-grid.rtl.css
++bootstrap-reboot.css.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-reboot.css.map
++bootstrap-reboot.min.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-reboot.min.css
++bootstrap-reboot.rtl.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-reboot.rtl.css
++bootstrap-utilities.css.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-utilities.css.map
++bootstrap-utilities.min.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-utilities.min.css
++bootstrap-utilities.rtl.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-utilities.rtl.css
++bootstrap.bundle.js
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\js\bootstrap.bundle.js
++bootstrap.esm.js
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\js\bootstrap.esm.js
++bootstrap.js.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\js\bootstrap.js.map
++bootstrap.min.js
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\js\bootstrap.min.js
++jquery.min.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\jquery\dist\jquery.min.map
++bootstrap.min.css.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap.min.css.map
++bootstrap.rtl.css.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap.rtl.css.map
++bootstrap.rtl.min.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap.rtl.min.css
++bootstrap-grid.min.css.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-grid.min.css.map
++bootstrap-grid.rtl.css.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-grid.rtl.css.map
++bootstrap-grid.rtl.min.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-grid.rtl.min.css
++bootstrap-reboot.min.css.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-reboot.min.css.map
++bootstrap-reboot.rtl.css.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-reboot.rtl.css.map
++bootstrap-reboot.rtl.min.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-reboot.rtl.min.css
++bootstrap-utilities.min.css.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-utilities.min.css.map
++bootstrap-utilities.rtl.css.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-utilities.rtl.css.map
++bootstrap-utilities.rtl.min.css
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-utilities.rtl.min.css
++bootstrap.bundle.js.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\js\bootstrap.bundle.js.map
++bootstrap.bundle.min.js
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\js\bootstrap.bundle.min.js
++bootstrap.esm.js.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\js\bootstrap.esm.js.map
++bootstrap.esm.min.js
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\js\bootstrap.esm.min.js
++bootstrap.min.js.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\js\bootstrap.min.js.map
++bootstrap.rtl.min.css.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap.rtl.min.css.map
++bootstrap-grid.rtl.min.css.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-grid.rtl.min.css.map
++bootstrap-reboot.rtl.min.css.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-reboot.rtl.min.css.map
++bootstrap-utilities.rtl.min.css.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\css\bootstrap-utilities.rtl.min.css.map
++bootstrap.bundle.min.js.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\js\bootstrap.bundle.min.js.map
++bootstrap.esm.min.js.map
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\wwwroot\lib\bootstrap\dist\js\bootstrap.esm.min.js.map
++CreateCondominium.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\administration\createcondominium.cshtml
++AssignManagerViewModel.cs
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\models\assignmanagerviewmodel.cs
++AssignManager.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\administration\assignmanager.cshtml
++Microsoft.EntityFrameworkCore (8.0.18)
i:{38537366-246f-4db5-b861-3c250f99e8c7}:>1705
++Administration
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\administration\
++AdministrationController.cs
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\controllers\administrationcontroller.cs
++NewFolder
++CondoManagement
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\condomanagement\
++Details.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\condomanagement\details.cshtml
++CreateUnit.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\condomanagement\createunit.cshtml
++RegisterResident.cshtml
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\views\condomanagement\registerresident.cshtml
++RegisterResidentViewModel.cs
i:{1e1fc90d-b1c1-4a4a-b8ae-f8fa723036ea}:c:\projectos\condosphere\condosphere.web\models\registerresidentviewmodel.cs
```

## File: .vs/VSWorkspaceState.json
```json
{
  "ExpandedNodes": [
    ""
  ],
  "SelectedNode": "\\CondoSphere.sln",
  "PreviewInSolutionExplorer": false
}
```

## File: CondoSphere.API/Controllers/ResidentsController.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.User;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/condominiums/{condominiumId}/residents")]
    [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
    public class ResidentsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public ResidentsController(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterResident(int condominiumId, [FromBody] RegisterResidentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                // This should not happen due to the authorization policy, but it's a good safeguard.
                return Unauthorized("Company information is missing from the token.");
            }

            var result = await _userService.RegisterResidentAsync(dto, companyId.Value, condominiumId);

            if (result.Succeeded)
            {
                return StatusCode(201, new { Message = "Resident registered successfully. A welcome email has been sent for them to set their password." });
            }

            return BadRequest(result.Errors);
        }
    }
}
```

## File: CondoSphere.Core/DTOs/Account/RegisterResidentDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    public class RegisterResidentDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int UnitId { get; set; }
    }
}
```

## File: CondoSphere.Core/DTOs/Account/SetPasswordDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    public class SetPasswordDto
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string Token { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Web/Controllers/AdministrationController.cs
```csharp
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CondoSphere.Web.Controllers
{
    [Authorize(Roles = RoleConstants.CompanyAdmin)]
    [Route("administration")] // Optional: You can add a base route for the entire controller
    public class AdministrationController : Controller
    {
        private readonly ApiClient _apiClient;

        public AdministrationController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet("")] // This will now map to "/administration"
        public async Task<IActionResult> Index()
        {
            var users = await _apiClient.GetUsersAsync();
            var condominiums = await _apiClient.GetCondominiumsAsync();

            var viewModel = new ManagementDashboardViewModel
            {
                Users = users ?? new List<UserListDto>(),
                Condominiums = condominiums ?? new List<CondominiumDto>()
            };

            return View(viewModel);
        }

        [HttpGet("register-manager")] // Maps to "/administration/register-manager"
        public IActionResult RegisterManager()
        {
            return View();
        }

        [HttpPost("register-manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterManager(RegisterManagerDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await _apiClient.RegisterManagerAsync(model);

            if (success)
            {
                TempData["SuccessMessage"] = "Manager registration initiated. They will receive an email to set their password.";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Failed to register manager. The email may already be in use.");
            return View(model);
        }

        [HttpGet("create-condominium")] // Maps to "/administration/create-condominium"
        public IActionResult CreateCondominium()
        {
            return View();
        }

        [HttpPost("create-condominium")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCondominium(CreateUpdateCondominiumDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var success = await _apiClient.CreateCondominiumAsync(model);

            if (success)
            {
                TempData["SuccessMessage"] = "Condominium created successfully!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while creating the condominium. Please try again.");
            return View(model);
        }

        // ===== CORRECTED ROUTES BELOW =====
        [HttpGet("condominiums/{condominiumId}/assign-manager")]
        public async Task<IActionResult> AssignManager(int condominiumId)
        {
            var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
            if (condo == null)
            {
                return NotFound();
            }

            var managers = await _apiClient.GetAvailableManagersAsync();

            ViewData["Condominium"] = condo;
            ViewData["AvailableManagers"] = managers.Select(m => new SelectListItem
            {
                Text = $"{m.FirstName} {m.LastName} ({m.Email})",
                Value = m.Id.ToString()
            });

            return View(new AssignManagerViewModel());
        }

        [HttpPost("condominiums/{condominiumId}/assign-manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignManager(int condominiumId, AssignManagerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await RepopulateAssignManagerViewDataAsync(condominiumId);
                return View(model);
            }

            var dto = new AssignManagerDto { ManagerId = model.SelectedManagerId };
            var success = await _apiClient.AssignManagerAsync(condominiumId, dto);

            if (success)
            {
                TempData["SuccessMessage"] = "Manager assigned successfully!";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "An error occurred while assigning the manager. Please verify the manager is valid and try again.");

            await RepopulateAssignManagerViewDataAsync(condominiumId);
            return View(model);
        }

        private async Task RepopulateAssignManagerViewDataAsync(int condominiumId)
        {
            var condo = await _apiClient.GetCondominiumDetailsAsync(condominiumId);
            var managers = await _apiClient.GetAvailableManagersAsync();
            ViewData["Condominium"] = condo;
            ViewData["AvailableManagers"] = managers.Select(m => new SelectListItem
            {
                Text = $"{m.FirstName} {m.LastName} ({m.Email})",
                Value = m.Id.ToString()
            });
        }
    }
}
```

## File: CondoSphere.Web/Controllers/CondoManagementController.cs
```csharp
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Web.Models;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.Web.Controllers
{
    [Authorize(Roles = RoleConstants.CondoManager)]
    [Route("condo-management")]
    public class CondoManagementController : Controller
    {
        private readonly ApiClient _apiClient;

        public CondoManagementController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var condominiums = await _apiClient.GetMyManagedCondominiumsAsync();
            return View(condominiums);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var condo = await _apiClient.GetCondominiumDetailsAsync(id);
            var units = await _apiClient.GetUnitsForCondominiumAsync(id);
            var users = await _apiClient.GetUsersAsync();
            var userLookup = users.ToDictionary(u => u.Id, u => $"{u.FirstName} {u.LastName}");

            var unitViewModels = units.Select(unit => new UnitDetailViewModel
            {
                Id = unit.Id,
                Identifier = unit.Identifier,
                ResidentId = unit.ResidentId,
                ResidentName = unit.ResidentId.HasValue && userLookup.ContainsKey(unit.ResidentId.Value)
                    ? userLookup[unit.ResidentId.Value]
                    : null
            });

            var viewModel = new CondominiumDetailsViewModel
            {
                Condominium = condo,
                Units = unitViewModels
            };

            return View(viewModel);
        }

        [HttpGet("units/{unitId}/register-resident")]
        public IActionResult RegisterResident(int unitId, int condominiumId)
        {
            var model = new RegisterResidentViewModel
            {
                UnitId = unitId,
                CondominiumId = condominiumId
            };
            return View(model);
        }

        [HttpPost("units/{unitId}/register-resident")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterResident(RegisterResidentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Create the DTO to send to the API from the ViewModel
            var dto = new RegisterResidentDto
            {
                UnitId = model.UnitId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            // ===== CORRECTED LOGIC HERE =====
            // The ApiClient method returns a simple boolean, not a tuple.
            var success = await _apiClient.RegisterResidentAsync(model.CondominiumId, dto);

            if (success)
            {
                TempData["SuccessMessage"] = "Resident registered successfully! A welcome email has been sent.";
                return RedirectToAction(nameof(Details), new { id = model.CondominiumId });
            }

            // Use a generic error message since the current ApiClient doesn't return a specific one.
            ModelState.AddModelError(string.Empty, "Failed to register resident. The unit may be occupied or the email may be in use.");
            return View(model);
        }

        [HttpGet("{condominiumId}/units/create")]
        public IActionResult CreateUnit(int condominiumId)
        {
            ViewData["CondominiumId"] = condominiumId;
            return View();
        }

        [HttpPost("{condominiumId}/units/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUnit(int condominiumId, CreateUpdateUnitDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["CondominiumId"] = condominiumId;
                return View(dto);
            }

            var success = await _apiClient.CreateUnitAsync(condominiumId, dto);
            if (success)
            {
                TempData["SuccessMessage"] = $"Unit '{dto.Identifier}' was created successfully!";
                return RedirectToAction(nameof(Details), new { id = condominiumId });
            }

            ModelState.AddModelError(string.Empty, "Failed to create the unit. Please try again.");
            ViewData["CondominiumId"] = condominiumId;
            return View(dto);
        }

        [HttpPost("{condominiumId}/units/{unitId}/unassign")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnassignResident(int condominiumId, int unitId)
        {
            var success = await _apiClient.UnassignResidentAsync(condominiumId, unitId);

            if (success)
            {
                TempData["SuccessMessage"] = "Resident has been unassigned and the unit is now vacant.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to unassign resident."; // We'll need to display this in the layout
            }

            return RedirectToAction(nameof(Details), new { id = condominiumId });
        }
    }
}
```

## File: CondoSphere.Web/Models/AssignManagerViewModel.cs
```csharp
using CondoSphere.Core.DTOs.Condominiums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Web.Models
{
    public class AssignManagerViewModel
    {
        [Required(ErrorMessage = "Please select a manager.")]
        [Display(Name = "Select Manager")]
        public int SelectedManagerId { get; set; }
    }
}
```

## File: CondoSphere.Web/Models/CondominiumDetailsViewModel.cs
```csharp
using CondoSphere.Core.DTOs.Condominiums;

namespace CondoSphere.Web.Models
{
    // A new class to hold combined Unit and Resident information for the view
    public class UnitDetailViewModel
    {
        public int Id { get; set; }
        public string Identifier { get; set; } = string.Empty;
        public int? ResidentId { get; set; }
        public string? ResidentName { get; set; }
    }

    public class CondominiumDetailsViewModel
    {
        public CondominiumDto Condominium { get; set; }
        // The list now uses our new, richer view model
        public IEnumerable<UnitDetailViewModel> Units { get; set; } = new List<UnitDetailViewModel>();
    }
}
```

## File: CondoSphere.Web/Models/RegisterResidentViewModel.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Web.Models
{
    public class RegisterResidentViewModel
    {
        [Required]
        public int UnitId { get; set; }

        [Required]
        public int CondominiumId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Web/Views/Account/SetPassword.cshtml
```
@model CondoSphere.Core.DTOs.Account.SetPasswordDto

@{
    ViewData["Title"] = "Set Your Password";
}

<h1>@ViewData["Title"]</h1>
<h4>Complete your account registration by setting a secure password.</h4>
<hr />

<div class="row">
    <div class="col-md-6">
        <form asp-action="SetPassword" method="post">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <input type="hidden" asp-for="UserId" />
            <input type="hidden" asp-for="Token" />

            <div class="form-floating mb-3">
                <input asp-for="Password" class="form-control" type="password" />
                <label asp-for="Password"></label>
                <span asp-validation-for="Password" class="text-danger"></span>
            </div>

            <div class="form-floating mb-3">
                <input asp-for="ConfirmPassword" class="form-control" type="password" />
                <label asp-for="ConfirmPassword"></label>
                <span asp-validation-for="ConfirmPassword" class="text-danger"></span>
            </div>

            <button type="submit" class="btn btn-primary">Set Password</button>
        </form>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

## File: CondoSphere.Web/Views/Administration/AssignManager.cshtml
```
@model AssignManagerViewModel
@{
    ViewData["Title"] = "Assign Manager";
    // Retrieve the display data from ViewData
    var condominium = ViewData["Condominium"] as CondoSphere.Core.DTOs.Condominiums.CondominiumDto;
    var availableManagers = ViewData["AvailableManagers"] as IEnumerable<SelectListItem>;
}

<h1>@ViewData["Title"]</h1>
<hr />
<h4>Condominium: <strong>@condominium.Name</strong></h4>
<p>Select a manager from the list below to assign them to this condominium.</p>

<div class="row">
    <div class="col-md-6">
        <form asp-action="AssignManager" asp-route-condominiumId="@condominium.Id" method="post">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <div class="form-group mb-3">
                <label asp-for="SelectedManagerId" class="form-label"></label>
                <select asp-for="SelectedManagerId" asp-items="availableManagers" class="form-control">
                    <option value="">-- Please select a manager --</option>
                </select>
                <span asp-validation-for="SelectedManagerId" class="text-danger"></span>
            </div>

            <button type="submit" class="btn btn-primary">Assign Manager</button>
            <a asp-action="Index" class="btn btn-secondary">Cancel</a>
        </form>
    </div>
</div>
```

## File: CondoSphere.Web/Views/Administration/CreateCondominium.cshtml
```
@model CondoSphere.Core.DTOs.Condominiums.CreateUpdateCondominiumDto

@{
    ViewData["Title"] = "Create New Condominium";
}

<h1>@ViewData["Title"]</h1>
<hr />

<div class="row">
    <div class="col-md-6">
        <form asp-action="CreateCondominium" method="post">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <div class="form-floating mb-3">
                <input asp-for="Name" class="form-control" placeholder="e.g., Central Park Residences" />
                <label asp-for="Name"></label>
                <span asp-validation-for="Name" class="text-danger"></span>
            </div>

            <div class="form-floating mb-3">
                <input asp-for="Address" class="form-control" placeholder="e.g., 123 Main Street, Anytown" />
                <label asp-for="Address"></label>
                <span asp-validation-for="Address" class="text-danger"></span>
            </div>

            <button type="submit" class="btn btn-success">Create Condominium</button>
            <a asp-action="Index" class="btn btn-secondary">Cancel</a>
        </form>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

## File: CondoSphere.Web/Views/Administration/Index.cshtml
```
@model ManagementDashboardViewModel

@{
    ViewData["Title"] = "Admin Dashboard";
}

<div class="d-flex justify-content-between align-items-center mb-4">
    <div>
        <h1>@ViewData["Title"]</h1>
        <p class="text-muted">Manage your company's users and condominiums.</p>
    </div>
    <div>
        <a class="btn btn-primary" asp-action="RegisterManager">
            <i class="bi bi-person-plus-fill me-1"></i> Register New Manager
        </a>
        <a class="btn btn-success" asp-action="CreateCondominium">
            <i class="bi bi-building-fill-add me-1"></i> Create Condominium
        </a>
    </div>
</div>

<div class="row">
    <div class="col-lg-8">
        <div class="card shadow-sm mb-4">
            <div class="card-header">
                <h5 class="mb-0">Managed Condominiums</h5>
            </div>
            <div class="card-body p-0">
                @if (Model.Condominiums.Any())
                {
                    <div class="table-responsive">
                        <table class="table table-hover mb-0">
                            <thead>
                                <tr>
                                    <th scope="col">Name</th>
                                    <th scope="col">Address</th>
                                    <th scope="col">Assigned Manager</th> @* <-- ADD THIS HEADER *@
                                    <th scope="col" class="text-end">Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                @foreach (var condo in Model.Condominiums)
                                {
                                    <tr>
                                        <td>@condo.Name</td>
                                        <td>@condo.Address</td>

                                        @* ===== NEW LOGIC FOR MANAGER COLUMN ===== *@
                                        <td>
                                            @if (!string.IsNullOrEmpty(condo.ManagerName))
                                            {
                                                <span class="text-muted">@condo.ManagerName</span>
                                            }
                                        </td>

                                        <td class="text-end">
                                            @if (string.IsNullOrEmpty(condo.ManagerName))
                                            {
                                                <a asp-action="AssignManager" asp-route-condominiumId="@condo.Id" class="btn btn-sm btn-primary">Assign Manager</a>
                                            }
                                            else
                                            {
                                                <a asp-action="AssignManager" asp-route-condominiumId="@condo.Id" class="btn btn-sm btn-outline-secondary">Re-assign</a>
                                            }
                                            @* <a href="#" class="btn btn-sm btn-outline-primary">Edit</a> *@
                                        </td>
                                    </tr>
                                }
                            </tbody>
                        </table>
                    </div>
                }
                else
                {
                    <div class="text-center p-4">
                        <p class="text-muted mb-0">No condominiums have been created yet. Click the "Create Condominium" button to get started.</p>
                    </div>
                }
            </div>
        </div>
    </div>

    <div class="col-lg-4">
        <div class="card shadow-sm mb-4">
            <div class="card-header">
                <h5 class="mb-0">Company Users</h5>
            </div>
            <div class="card-body p-0">
                @if (Model.Users.Any())
                {
                    <div class="table-responsive">
                        <table class="table table-hover mb-0">
                            <thead>
                                <tr>
                                    <th scope="col">Name</th>
                                    <th scope="col">Role</th>
                                </tr>
                            </thead>
                            <tbody>
                                @foreach (var user in Model.Users)
                                {
                                    <tr>
                                        <td>@user.FirstName @user.LastName<br /><small class="text-muted">@user.Email</small></td>
                                        <td><span class="badge bg-secondary">@user.Role</span></td>
                                    </tr>
                                }
                            </tbody>
                        </table>
                    </div>
                }
                else
                {
                    <div class="text-center p-4">
                        <p class="text-muted mb-0">No users found.</p>
                    </div>
                }
            </div>
        </div>
    </div>
</div>
```

## File: CondoSphere.Web/Views/Administration/RegisterManager.cshtml
```
@model CondoSphere.Core.DTOs.Account.RegisterManagerDto

@{
    ViewData["Title"] = "Register New Manager";
}

<h1>@ViewData["Title"]</h1>
<hr />

<div class="row">
    <div class="col-md-6">
        <form asp-action="RegisterManager" method="post">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <div class="form-floating mb-3">
                <input asp-for="FirstName" class="form-control" />
                <label asp-for="FirstName"></label>
                <span asp-validation-for="FirstName" class="text-danger"></span>
            </div>

            <div class="form-floating mb-3">
                <input asp-for="LastName" class="form-control" />
                <label asp-for="LastName"></label>
                <span asp-validation-for="LastName" class="text-danger"></span>
            </div>

            <div class="form-floating mb-3">
                <input asp-for="Email" class="form-control" />
                <label asp-for="Email"></label>
                <span asp-validation-for="Email" class="text-danger"></span>
            </div>

            <button type="submit" class="btn btn-primary">Register Manager</button>
            <a asp-action="Index" class="btn btn-secondary">Cancel</a>
        </form>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

## File: CondoSphere.Web/Views/CondoManagement/CreateUnit.cshtml
```
@model CondoSphere.Core.DTOs.Condominiums.CreateUpdateUnitDto

@{
    ViewData["Title"] = "Add New Unit";
    var condominiumId = ViewData["CondominiumId"];
}

<h1>@ViewData["Title"]</h1>
<hr />

<div class="row">
    <div class="col-md-6">
        <form asp-action="CreateUnit" asp-route-condominiumId="@condominiumId" method="post">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>

            <div class="form-floating mb-3">
                <input asp-for="Identifier" class="form-control" placeholder="e.g., Apt 101, Block B - Floor 2" />
                <label asp-for="Identifier">Unit Identifier</label>
                <span asp-validation-for="Identifier" class="text-danger"></span>
            </div>

            <button type="submit" class="btn btn-success">Create Unit</button>
            <a asp-action="Details" asp-route-id="@condominiumId" class="btn btn-secondary">Cancel</a>
        </form>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

## File: CondoSphere.Web/Views/CondoManagement/Details.cshtml
```
@model CondoSphere.Web.Models.CondominiumDetailsViewModel

@{
    ViewData["Title"] = $"Manage: {Model.Condominium.Name}";
}

<div class="d-flex justify-content-between align-items-center mb-4">
    <div>
        <h1>@Model.Condominium.Name</h1>
        <p class="text-muted mb-0">@Model.Condominium.Address</p>
    </div>
    <div>
        <a asp-action="CreateUnit" asp-route-condominiumId="@Model.Condominium.Id" class="btn btn-success">
            <i class="bi bi-plus-square-fill me-1"></i> Add New Unit
        </a>
    </div>
</div>

<div class="card shadow-sm">
    <div class="card-header">
        <h5 class="mb-0">Units</h5>
    </div>
    <div class="card-body p-0">
        @if (Model.Units.Any())
        {
            <div class="table-responsive">
                <table class="table table-hover mb-0 align-middle">
                    <thead>
                        <tr>
                            <th scope="col">Identifier</th>
                            <th scope="col">Status / Resident</th>
                            <th scope="col" class="text-end">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        @foreach (var unit in Model.Units)
                        {
                            <tr>
                                <td><strong>@unit.Identifier</strong></td>
                                <td>
                                    @if (unit.ResidentId.HasValue)
                                    {
                                        <span class="badge bg-info">Occupied</span>
                                        <span class="ms-2">@unit.ResidentName</span>
                                    }
                                    else
                                    {
                                        <span class="badge bg-success">Vacant</span>
                                    }
                                </td>
                                <td class="text-end">
                                    @if (unit.ResidentId.HasValue)
                                    {
                                        <form asp-action="UnassignResident" asp-route-condominiumId="@Model.Condominium.Id" asp-route-unitId="@unit.Id" method="post" onsubmit="return confirm('Are you sure you want to unassign this resident? Their account will be deactivated.');">
                                            @Html.AntiForgeryToken()
                                            <button type="submit" class="btn btn-sm btn-outline-danger">Unassign Resident</button>
                                        </form>
                                    }
                                    else
                                    {
                                        <a asp-action="RegisterResident"
                                           asp-route-unitId="@unit.Id"
                                           asp-route-condominiumId="@Model.Condominium.Id"
                                           class="btn btn-sm btn-primary">Register Resident</a>
                                    }
                                </td>
                            </tr>
                        }
                    </tbody>
                </table>
            </div>
        }
        else
        {
            <div class="text-center p-4">
                <p class="text-muted mb-0">No units have been created for this condominium yet.</p>
            </div>
        }
    </div>
</div>

<div class="mt-4">
    <a asp-action="Index" class="btn btn-outline-secondary">
        <i class="bi bi-arrow-left me-1"></i> Back to My Condos
    </a>
</div>
```

## File: CondoSphere.Web/Views/CondoManagement/Index.cshtml
```
@model IEnumerable<CondoSphere.Core.DTOs.Condominiums.CondominiumDto>

@{
    ViewData["Title"] = "My Managed Condominiums";
}

<div class="d-flex justify-content-between align-items-center mb-4">
    <div>
        <h1>@ViewData["Title"]</h1>
        <p class="text-muted">Select a condominium to manage its units and residents.</p>
    </div>
</div>

@if (Model.Any())
{
    <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
        @foreach (var condo in Model)
        {
            <div class="col">
                <div class="card h-100 shadow-sm">
                    <div class="card-body">
                        <h5 class="card-title">@condo.Name</h5>
                        <p class="card-text text-muted">@condo.Address</p>
                    </div>
                    <div class="card-footer bg-transparent border-top-0 text-end">
                        <a asp-controller="CondoManagement" asp-action="Details" asp-route-id="@condo.Id" class="btn btn-primary">
                            <i class="bi bi-gear-fill me-1"></i> Manage
                        </a>
                    </div>
                </div>
            </div>
        }
    </div>
}
else
{
    <div class="text-center p-5">
        <h3 class="text-muted">No Condominiums Assigned</h3>
        <p>You have not been assigned to manage any condominiums yet. Please contact your company administrator.</p>
    </div>
}
```

## File: CondoSphere.Web/Views/CondoManagement/RegisterResident.cshtml
```
@model CondoSphere.Web.Models.RegisterResidentViewModel

@{
    ViewData["Title"] = "Register New Resident";
}

<h1>@ViewData["Title"]</h1>
<p class="text-muted">You are registering a new resident for Unit ID: @Model.UnitId in Condominium ID: @Model.CondominiumId</p>
<hr />

<div class="row">
    <div class="col-md-6">
        <form asp-action="RegisterResident" method="post">
            <div asp-validation-summary="All" class="text-danger"></div>

            @* Add hidden fields for the IDs to ensure they are posted back *@
            <input type="hidden" asp-for="UnitId" />
            <input type="hidden" asp-for="CondominiumId" />

            <div class="form-floating mb-3">
                <input asp-for="FirstName" class="form-control" />
                <label asp-for="FirstName"></label>
                <span asp-validation-for="FirstName" class="text-danger"></span>
            </div>

            <div class="form-floating mb-3">
                <input asp-for="LastName" class="form-control" />
                <label asp-for="LastName"></label>
                <span asp-validation-for="LastName" class="text-danger"></span>
            </div>

            <div class="form-floating mb-3">
                <input asp-for="Email" class="form-control" />
                <label asp-for="Email"></label>
                <span asp-validation-for="Email" class="text-danger"></span>
            </div>

            <button type="submit" class="btn btn-primary">Register Resident</button>
            <a asp-action="Details" asp-route-id="@Model.CondominiumId" class="btn btn-secondary">Cancel</a>
        </form>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

## File: CondoSphere.API/appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## File: CondoSphere.API/Properties/launchSettings.json
```json
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:48584",
      "sslPort": 44322
    }
  },
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "http://localhost:5263",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "https://localhost:7177;http://localhost:5263",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

## File: CondoSphere.Application/Authorization/IsCondoManagerRequirement.cs
```csharp
using Microsoft.AspNetCore.Authorization;

namespace CondoSphere.Application.Authorization
{
    /// <summary>
    /// This requirement ensures that the authenticated user is the assigned manager
    /// of the specific condominium they are trying to access.
    /// </summary>
    public class IsCondoManagerRequirement : IAuthorizationRequirement
    {
    }
}
```

## File: CondoSphere.Application/Interfaces/ICompanyRepository.cs
```csharp
using CondoSphere.Core.Entities.Users;
using System.Threading.Tasks;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// Defines the contract for a repository that manages Company data.
    /// </summary>
    public interface ICompanyRepository
    {
        Task AddAsync(Company company);
        void Remove(Company company);
        Task<int> SaveChangesAsync();
    }
}
```

## File: CondoSphere.Application/Interfaces/IMailService.cs
```csharp
namespace CondoSphere.Application.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string content);
    }
}
```

## File: CondoSphere.Application/Interfaces/IUnitOfWork.cs
```csharp
namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// Defines a unit of work that can coordinate transactions across multiple repositories.
    /// </summary>
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICompanyRepository Companies { get; }
        // TODO: We can add other repositories here later, e.g., IUserRepository
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> CompleteAsync();
    }
}
```

## File: CondoSphere.Application/Interfaces/IUnitRepository.cs
```csharp
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Interfaces
{
    public interface IUnitRepository
    {
        Task AddAsync(Unit unit);
        void Update(Unit unit);
        void Remove(Unit unit);
        Task<Unit?> GetByIdAsync(int unitId);
        Task<IEnumerable<Unit>> GetAllAsync(int condominiumId);
        Task<int> SaveChangesAsync();
    }
}
```

## File: CondoSphere.Application/Interfaces/IUserRepository.cs
```csharp
using CondoSphere.Core.DTOs.Account;

namespace CondoSphere.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserListDto>> GetCompanyUsersWithRolesAsync(int companyId);
        Task<IEnumerable<UserListDto>> GetUsersInRoleAsync(string roleName, int companyId);
    }
}
```

## File: CondoSphere.Application/Mappings/CondominiumProfile.cs
```csharp
using AutoMapper;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Mappings
{
    public class CondominiumProfile : Profile
    {
        public CondominiumProfile()
        {
            // This defines a map from the Condominium entity to the CondominiumDto.
            // AutoMapper is smart enough to map properties with the same name automatically.
            CreateMap<Condominium, CondominiumDto>();

            // This defines a map from the CreateUpdateCondominiumDto to the Condominium entity.
            // This will be used when creating or updating a condominium.
            CreateMap<CreateUpdateCondominiumDto, Condominium>();
        }
    }
}
```

## File: CondoSphere.Application/Mappings/UnitProfile.cs
```csharp
using AutoMapper;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Mappings
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            CreateMap<Unit, UnitDto>();
            CreateMap<CreateUpdateUnitDto, Unit>();
        }
    }
}
```

## File: CondoSphere.Application/Services/Condominium/ICondominiumService.cs
```csharp
using CondoSphere.Core.DTOs.Condominiums;

namespace CondoSphere.Application.Services.Condominium
{
    public interface ICondominiumService
    {
        Task<CondominiumDto?> GetCondominiumByIdAsync(int id, int companyId);
        Task<IEnumerable<CondominiumDto>> GetAllCondominiumsAsync(int companyId, int pageNumber, int pageSize);
        Task<CondominiumDto> CreateCondominiumAsync(CreateUpdateCondominiumDto condominiumDto, int companyId);
        Task<bool> UpdateCondominiumAsync(int id, CreateUpdateCondominiumDto condominiumDto, int companyId);
        Task<bool> DeleteCondominiumAsync(int id, int companyId);
        Task<bool> AssignManagerAsync(int condominiumId, int managerId, int companyId);
        Task<IEnumerable<CondominiumDto>> GetCondominiumsByManagerIdAsync(int managerId);
    }
}
```

## File: CondoSphere.Application/Services/Condominium/IUnitService.cs
```csharp
using CondoSphere.Core.DTOs.Condominiums;

namespace CondoSphere.Application.Services.Condominium
{
    public interface IUnitService
    {
        Task<IEnumerable<UnitDto>> GetUnitsForCondominiumAsync(int condominiumId);
        Task<UnitDto?> GetUnitByIdAsync(int unitId);
        Task<UnitDto> CreateUnitAsync(CreateUpdateUnitDto unitDto, int condominiumId, int companyId);
        Task<bool> UpdateUnitAsync(int unitId, CreateUpdateUnitDto unitDto);
        Task<bool> DeleteUnitAsync(int unitId);
        Task<bool> UnassignResidentAsync(int unitId);
    }
}
```

## File: CondoSphere.Application/Services/Condominium/UnitService.cs
```csharp
using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.DTOs.Condominiums;
using Microsoft.AspNetCore.Identity;
using CoreUnit = CondoSphere.Core.Entities.Condominiums.Unit;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Condominium
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<CoreUser> _userManager;

        public UnitService(IUnitRepository unitRepository, IMapper mapper, UserManager<CoreUser> userManager)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<UnitDto> CreateUnitAsync(CreateUpdateUnitDto unitDto, int condominiumId, int companyId)
        {
            var unit = _mapper.Map<CoreUnit>(unitDto);
            unit.CondominiumId = condominiumId;
            unit.CompanyId = companyId;

            await _unitRepository.AddAsync(unit);
            await _unitRepository.SaveChangesAsync();

            return _mapper.Map<UnitDto>(unit);
        }

        public async Task<bool> DeleteUnitAsync(int unitId)
        {
            var unit = await _unitRepository.GetByIdAsync(unitId);
            if (unit == null) return false;

            _unitRepository.Remove(unit);
            return await _unitRepository.SaveChangesAsync() > 0;
        }

        public async Task<UnitDto?> GetUnitByIdAsync(int unitId)
        {
            var unit = await _unitRepository.GetByIdAsync(unitId);
            return _mapper.Map<UnitDto>(unit);
        }

        public async Task<IEnumerable<UnitDto>> GetUnitsForCondominiumAsync(int condominiumId)
        {
            var units = await _unitRepository.GetAllAsync(condominiumId);
            return _mapper.Map<IEnumerable<UnitDto>>(units);
        }

        public async Task<bool> UpdateUnitAsync(int unitId, CreateUpdateUnitDto unitDto)
        {
            var unit = await _unitRepository.GetByIdAsync(unitId);
            if (unit == null) return false;

            _mapper.Map(unitDto, unit);
            _unitRepository.Update(unit);
            return await _unitRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> UnassignResidentAsync(int unitId)
        {
            var unit = await _unitRepository.GetByIdAsync(unitId);
            if (unit?.ResidentId == null)
            {
                return false;
            }

            var residentId = unit.ResidentId.Value;

            unit.ResidentId = null;
            _unitRepository.Update(unit);

            var formerResident = await _userManager.FindByIdAsync(residentId.ToString());
            if (formerResident != null)
            {
                formerResident.IsActive = false;
                await _userManager.UpdateAsync(formerResident);
            }

            return await _unitRepository.SaveChangesAsync() > 0;
        }
    }
}
```

## File: CondoSphere.Application/Services/Token/ITokenService.cs
```csharp
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Token
{
    public interface ITokenService
    {
        Task<string> CreateToken(CoreUser user);
    }
}
```

## File: CondoSphere.Application/Services/Token/TokenService.cs
```csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<CoreUser> _userManager;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config, UserManager<CoreUser> userManager)
        {
            _config = config;
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        }

        public async Task<string> CreateToken(CoreUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
            
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName ?? string.Empty),
                new Claim("companyId", user.CompanyId.ToString() ?? string.Empty)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
```

## File: CondoSphere.Application/Validators/Condominiums/CreateUpdateCondominiumDtoValidator.cs
```csharp
using CondoSphere.Core.DTOs.Condominiums;
using FluentValidation;

namespace CondoSphere.Application.Validators.Condominiums
{
    public class CreateUpdateCondominiumDtoValidator : AbstractValidator<CreateUpdateCondominiumDto>
    {
        public CreateUpdateCondominiumDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .Length(5, 255).WithMessage("Address must be between 5 and 255 characters.");
        }
    }
}
```

## File: CondoSphere.Application/Validators/Condominiums/CreateUpdateUnitDtoValidator.cs
```csharp
using CondoSphere.Core.DTOs.Condominiums;
using FluentValidation;

namespace CondoSphere.Application.Validators.Condominiums
{
    public class CreateUpdateUnitDtoValidator : AbstractValidator<CreateUpdateUnitDto>
    {
        public CreateUpdateUnitDtoValidator()
        {
            RuleFor(x => x.Identifier)
                .NotEmpty().WithMessage("Identifier is required.")
                .MaximumLength(100).WithMessage("Identifier cannot exceed 100 characters.");
        }
    }
}
```

## File: CondoSphere.Core/DTOs/Account/AssignManagerDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    /// <summary>
    /// Represents the data required to assign a manager to a condominium.
    /// </summary>
    public class AssignManagerDto
    {
        /// <summary>
        /// The ID of the User (who must have the CondoManager role) to be assigned.
        /// </summary>
        [Required]
        public int ManagerId { get; set; }
    }
}
```

## File: CondoSphere.Core/DTOs/Account/LoginDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Account/RegisterDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Account
{
    /// <summary>
    /// Represents the data required to register a new company and its first administrator.
    /// </summary>
    public class RegisterDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]//TODO: Aumentar a segurança da password (por enquanto vamos usar 123456)
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Account/RegisterManagerDto.cs
```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.DTOs.Account
{
    /// <summary>
    /// Represents the data required by a Company Admin to register a new Condominium Manager.
    /// </summary>
    public class RegisterManagerDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Account/UserDto.cs
```csharp
namespace CondoSphere.Core.DTOs.Account
{
    /// <summary>
    /// Represents the data returned to the client after a successful login.
    /// </summary>
    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Account/UserListDto.cs
```csharp
namespace CondoSphere.Core.DTOs.Account
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Condominiums/CondominiumDto.cs
```csharp
namespace CondoSphere.Core.DTOs.Condominiums
{
    /// <summary>
    /// Represents a condominium when being displayed to the user.
    /// </summary>
    public class CondominiumDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public string? ManagerName { get; set; }
    }
}
```

## File: CondoSphere.Core/DTOs/Condominiums/CreateUpdateCondominiumDto.cs
```csharp
using System.ComponentModel.DataAnnotations;

namespace CondoSphere.Core.DTOs.Condominiums
{
    /// <summary>
    /// Represents the data needed to create or update a condominium.
    /// </summary>
    public class CreateUpdateCondominiumDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Address { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Condominiums/CreateUpdateUnitDto.cs
```csharp
namespace CondoSphere.Core.DTOs.Condominiums
{
    /// <summary>
    /// Represents the data needed to create or update a Unit.
    /// </summary>
    public class CreateUpdateUnitDto
    {
        public string Identifier { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/DTOs/Condominiums/UnitDto.cs
```csharp
namespace CondoSphere.Core.DTOs.Condominiums
{
    /// <summary>
    /// Represents a Unit when being displayed to the user.
    /// </summary>
    public class UnitDto
    {
        public int Id { get; set; }
        public string Identifier { get; set; } = string.Empty;
        public int CondominiumId { get; set; }
        public int? ResidentId { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Condominiums/Assembly.cs
```csharp
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Condominiums
{
    public class Assembly : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; } = string.Empty;
        public string? MinutesUrl { get; set; }
        public int CondominiumId { get; set; }
        public int CompanyId { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Condominiums/Document.cs
```csharp
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Condominiums
{
    public class Document : IEntity
    {
        /// <summary>
        /// The unique identifier for the document.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The foreign key to the condominium this document belongs to.
        /// </summary>
        public int CondominiumId { get; set; }

        /// <summary>
        /// The foreign key to the company that manages this condominium, for multi-tenancy.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The foreign key to the user who uploaded the document.
        /// </summary>
        public int UploadedByUserId { get; set; }

        /// <summary>
        /// The user-facing title of the document.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// A brief description of the document's content.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The original name of the file that was uploaded.
        /// </summary>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// The path to the file in a physical location (e.g., on disk) or a full URL to its location in blob storage.
        /// </summary>
        public string FilePathOrUrl { get; set; } = string.Empty;

        /// <summary>
        /// The category of the document, used for filtering (e.g., "Minutes", "Regulation", "Budget").
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// The date and time the document was uploaded.
        /// </summary>
        public DateTime UploadDate { get; set; } = DateTime.UtcNow;
    }
}
```

## File: CondoSphere.Core/Entities/Condominiums/Intervention.cs
```csharp
using CondoSphere.Core;
using CondoSphere.Core.Enums;

namespace CondoSphere.Core.Entities.Condominiums
{
    public class Intervention : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public InterventionStatus Status { get; set; }
        public int? OccurrenceId { get; set; }
        public int CompanyId { get; set; }
        public int? UnitId { get; set; }
        public int CondominiumId { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Condominiums/Occurrence.cs
```csharp
using CondoSphere.Core;
using CondoSphere.Core.Enums;

namespace CondoSphere.Core.Entities.Condominiums
{
    public class Occurrence : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ReportedDate { get; set; } = DateTime.UtcNow;
        public OccurrenceStatus Status { get; set; }
        public int? UnitId { get; set; }
        public int CondominiumId { get; set; }
        public int CompanyId { get; set; }
        public int ReportedByUserId { get; set; }
        public int? AssignedToUserId { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Financials/Expense.cs
```csharp
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Financials
{
    /// <summary>
    /// Represents a common expense incurred by the condominium (e.g., maintenance, utilities).
    /// </summary>
    public class Expense : IEntity
    {
        /// <summary>
        /// The unique identifier for the expense.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The foreign key to the condominium this expense belongs to.
        /// </summary>
        public int CondominiumId { get; set; }

        /// <summary>
        /// The foreign key to the company, for multi-tenancy.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// A descriptive title for the expense (e.g., "Elevator Maintenance Q3").
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// A more detailed description of the expense.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The total amount of the expense.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The date the expense was incurred.
        /// </summary>
        public DateTime ExpenseDate { get; set; }

        /// <summary>
        /// The name of the supplier or vendor who provided the service/product.
        /// </summary>
        public string? SupplierName { get; set; }

        /// <summary>
        /// The reference number from the supplier's invoice.
        /// </summary>
        public string? InvoiceNumber { get; set; }

        /// <summary>
        /// The category of the expense for reporting (e.g., "Maintenance", "Utilities", "Cleaning").
        /// </summary>
        public string Category { get; set; } = string.Empty;
    }
}
```

## File: CondoSphere.Core/Entities/Financials/QuotaPayment.cs
```csharp
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Financials
{
    public class QuotaPayment : IEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string? TransactionReference { get; set; }
        public int UnitQuotaId { get; set; }
        public int UnitId { get; set; }
        public int CompanyId { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Financials/Receipt.cs
```csharp
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Financials
{
    public class Receipt : IEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        public int QuotaPaymentId { get; set; }
        public string Details { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int CondominiumId { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Financials/UnitQuota.cs
```csharp
using CondoSphere.Core;
using CondoSphere.Core.Enums;

namespace CondoSphere.Core.Entities.Financials
{
    /// <summary>
    /// Represents a single quota (bill or charge) issued to a condominium unit.
    /// This is the core record for what a resident owes.
    /// </summary>
    public class UnitQuota : IEntity
    {
        /// <summary>
        /// The unique identifier for the quota.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The foreign key to the specific unit this quota is for.
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// The foreign key to the condominium, denormalized for easier querying.
        /// </summary>
        public int CondominiumId { get; set; }

        /// <summary>
        /// The foreign key to the company, for multi-tenancy.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// A description of the quota (e.g., "Monthly Fee - August 2024").
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The total amount that is due for this quota.
        /// </summary>
        public decimal AmountDue { get; set; }

        /// <summary>
        /// The date by which this quota should be paid.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// The amount that has been paid towards this quota so far.
        /// </summary>
        public decimal AmountPaid { get; set; }

        /// <summary>
        /// The date the quota was fully paid. Null if not yet paid.
        /// </summary>
        public DateTime? PaymentDate { get; set; }

        /// <summary>
        /// The current status of the quota (e.g., "Pending", "Paid", "PartiallyPaid", "Overdue").
        /// </summary>
        public UnitQuotaStatus Status { get; set; }

        /// <summary>
        /// A payment reference number, if applicable (e.g., Multibanco reference).
        /// </summary>
        public string? ReferenceNumber { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Users/Company.cs
```csharp
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Users
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? VatNumber { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
```

## File: CondoSphere.Core/Entities/Users/Notification.cs
```csharp
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Users
{
    public class Notification : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime SentDate { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; }
        public DateTime? ReadDate { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Users/User.cs
```csharp
using CondoSphere.Core;
using Microsoft.AspNetCore.Identity;

namespace CondoSphere.Core.Entities.Users
{
    /// <summary>
    /// Represents a user in the system. Extends the default ASP.NET Core IdentityUser
    /// to use an integer as the primary key and adds custom properties.
    /// The 'Id' from IdentityUser<int> satisfies the IEntity interface contract.
    /// </summary>
    public class User : IdentityUser<int>, IEntity
    {
     
        public int? CompanyId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
```

## File: CondoSphere.Core/Enums/InterventionStatus.cs
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.Enums
{
    /// <summary>
    /// Represents the possible statuses for a maintenance intervention.
    /// </summary>
    public enum InterventionStatus
    {
        /// <summary>
        /// The intervention has been planned but not yet started.
        /// </summary>
        Scheduled = 1,

        /// <summary>
        /// The intervention is currently in progress.
        /// </summary>
        InProgress = 2,

        /// <summary>
        /// The intervention work has been completed.
        /// </summary>
        Completed = 3,

        /// <summary>
        /// The intervention has been cancelled.
        /// </summary>
        Cancelled = 4
    }
}
```

## File: CondoSphere.Core/Enums/OccurrenceStatus.cs
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.Enums
{
    public enum OccurrenceStatus
    {
        /// <summary>
        /// The occurrence has been reported but not yet acted upon.
        /// </summary>
        Open = 1,

        /// <summary>
        /// The occurrence is currently being worked on.
        /// </summary>
        InProgress = 2,

        /// <summary>
        /// The occurrence is temporarily on hold.
        /// </summary>
        OnHold = 3,

        /// <summary>
        /// The issue has been resolved but is pending final confirmation.
        /// </summary>
        Resolved = 4,

        /// <summary>
        /// The occurrence has been fully resolved and closed.
        /// </summary>
        Closed = 5
    }
}
```

## File: CondoSphere.Core/Enums/SystemRole.cs
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.Enums
{
    /// <summary>
    /// Represents the core user roles within the system.
    /// The values should correspond to the IDs in the Roles database table.
    /// </summary>
    public enum SystemRole
    {
        CompanyAdmin = 1,
        CondoManager = 2,
        CondoResident = 3,
        Employee = 4,
        PlatformSuperAdmin = 5
    }
}
```

## File: CondoSphere.Core/Enums/UnitQuotaStatus.cs
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondoSphere.Core.Enums
{
    /// <summary>
    /// Represents the possible statuses for a unit's quota (bill).
    /// </summary>
    public enum UnitQuotaStatus
    {
        /// <summary>
        /// The quota has been issued but not yet paid.
        /// </summary>
        Pending = 1,

        /// <summary>
        /// The quota has been paid in full.
        /// </summary>
        Paid = 2,

        /// <summary>
        /// The quota has been partially paid.
        /// </summary>
        PartiallyPaid = 3,

        /// <summary>
        /// The quota's due date has passed, and it remains unpaid.
        /// </summary>
        Overdue = 4,

        /// <summary>
        /// The quota has been cancelled or voided.
        /// </summary>
        Cancelled = 5
    }
}
```

## File: CondoSphere.Core/IEntity.cs
```csharp
namespace CondoSphere.Core
{
    public interface IEntity
    {
        public int Id { get; set; }
    }
}
```

## File: CondoSphere.Core/RoleConstants.cs
```csharp
namespace CondoSphere.Core
{
    /// <summary>
    /// Provides constant string values for system roles to avoid magic strings in code.
    /// </summary>
    public static class RoleConstants
    {
        public const string CompanyAdmin = "CompanyAdmin";
        public const string CondoManager = "CondoManager";
        public const string CondoResident = "CondoResident";
        public const string Employee = "Employee";
        public const string PlatformSuperAdmin = "PlatformSuperAdmin";
    }
}
```

## File: CondoSphere.Infrastructure/Data/CondominiumDbContext.cs
```csharp
using CondoSphere.Core.Entities.Condominiums;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Data
{
    public class CondominiumDbContext : DbContext
    {
        // DbSet for each entity that belongs in this database
        public DbSet<Condominium> Condominiums { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Occurrence> Occurrences { get; set; }
        public DbSet<Intervention> Interventions { get; set; }
        public DbSet<Assembly> Assemblies { get; set; }
        // TODO: Add DbSets for the virtual assembly features later

        public CondominiumDbContext(DbContextOptions<CondominiumDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Here we can add configurations, like composite keys
            // For example, ensuring a Unit identifier is unique within a Condominium
            modelBuilder.Entity<Unit>()
                .HasIndex(u => new { u.CondominiumId, u.Identifier })
                .IsUnique();
        }
    }
}
```

## File: CondoSphere.Infrastructure/Repositories/CompanyRepository.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Users;
using CondoSphere.Infrastructure.Data;

namespace CondoSphere.Infrastructure.Repositories
{
    /// <summary>
    /// Implements the ICompanyRepository using Entity Framework Core.
    /// </summary>
    public class CompanyRepository : ICompanyRepository
    {
        private readonly UserManagementDbContext _context;

        public CompanyRepository(UserManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

        public void Remove(Company company)
        {
            _context.Companies.Remove(company);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
```

## File: CondoSphere.Infrastructure/Repositories/UnitOfWork.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace CondoSphere.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManagementDbContext _context;
        private IDbContextTransaction? _transaction;

        public ICompanyRepository Companies { get; }

        public UnitOfWork(UserManagementDbContext context)
        {
            _context = context;
            Companies = new CompanyRepository(_context);
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
        }

        public async Task<int> CompleteAsync()
        {
            // SaveChangesAsync will automatically participate in the active transaction.
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            // Ensure the transaction is disposed of properly.
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
            }
            await _context.DisposeAsync();
        }
    }
}
```

## File: CondoSphere.Infrastructure/Repositories/UnitRepository.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Condominiums;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly CondominiumDbContext _context;

        public UnitRepository(CondominiumDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Unit unit)
        {
            await _context.Units.AddAsync(unit);
        }

        public async Task<IEnumerable<Unit>> GetAllAsync(int condominiumId)
        {
            return await _context.Units
                .Where(u => u.CondominiumId == condominiumId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Unit?> GetByIdAsync(int unitId)
        {
            return await _context.Units.FindAsync(unitId);
        }

        public void Remove(Unit unit)
        {
            _context.Units.Remove(unit);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Unit unit)
        {
            _context.Entry(unit).State = EntityState.Modified;
        }
    }
}
```

## File: CondoSphere.Infrastructure/Repositories/UserRepository.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManagementDbContext _context;

        public UserRepository(UserManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserListDto>> GetCompanyUsersWithRolesAsync(int companyId)
        {
            var usersWithRoles = await _context.Users
                .Where(u => u.CompanyId == companyId)
                .Select(u => new UserListDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Role = (from userRole in _context.UserRoles
                            join role in _context.Roles on userRole.RoleId equals role.Id
                            where userRole.UserId == u.Id
                            select role.Name).FirstOrDefault() ?? "No Role"
                })
                .AsNoTracking()
                .ToListAsync();

            return usersWithRoles;
        }

        public async Task<IEnumerable<UserListDto>> GetUsersInRoleAsync(string roleName, int companyId)
        {
            var usersInRole = await _context.Users
                .Where(u => u.CompanyId == companyId && _context.UserRoles.Any(ur => ur.UserId == u.Id && _context.Roles.Any(r => r.Id == ur.RoleId && r.Name == roleName)))
                .Select(u => new UserListDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Role = roleName
                })
                .AsNoTracking()
                .ToListAsync();

            return usersInRole;
        }
    }
}
```

## File: CondoSphere.Infrastructure/Services/MailService.cs
```csharp
using CondoSphere.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace CondoSphere.Infrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string toEmail, string subject, string content)
        {
            // Read all settings from configuration (appsettings + user secrets)
            var from = _configuration["MailSettings:From"];
            var smtp = _configuration["MailSettings:Smtp"];
            var port = int.Parse(_configuration["MailSettings:Port"]);
            var password = _configuration["MailSettings:Password"];

            var message = new MailMessage
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = content,
                IsBodyHtml = true
            };

            message.To.Add(new MailAddress(toEmail));

            // Configure the SmtpClient for Gmail
            var client = new SmtpClient
            {
                Host = smtp,
                Port = port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from, password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            return client.SendMailAsync(message);
        }
    }
}
```

## File: CondoSphere.Web/appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## File: CondoSphere.Web/Controllers/HomeController.cs
```csharp
using CondoSphere.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CondoSphere.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
```

## File: CondoSphere.Web/Models/ErrorViewModel.cs
```csharp
namespace CondoSphere.Web.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
```

## File: CondoSphere.Web/Models/ManagementDashboardViewModel.cs
```csharp
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;

namespace CondoSphere.Web.Models
{
    public class ManagementDashboardViewModel
    {
        public IEnumerable<UserListDto> Users { get; set; } = new List<UserListDto>();
        public IEnumerable<CondominiumDto> Condominiums { get; set; } = new List<CondominiumDto>();
    }
}
```

## File: CondoSphere.Web/Properties/launchSettings.json
```json
{
  "$schema": "http://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:61532",
      "sslPort": 44394
    }
  },
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "http://localhost:5017",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "https://localhost:7183;http://localhost:5017",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

## File: CondoSphere.Web/Services/JwtForwardingDelegatingHandler.cs
```csharp
using System.Net.Http.Headers;

namespace CondoSphere.Web.Services
{
    public class JwtForwardingDelegatingHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtForwardingDelegatingHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Try to get the access_token from the authenticated user's claims
            var token = _httpContextAccessor.HttpContext?.User.FindFirst("access_token")?.Value;

            // If a token is found, add it to the outgoing request's Authorization header
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
```

## File: CondoSphere.Web/Views/_ViewImports.cshtml
```
@using CondoSphere.Web
@using CondoSphere.Web.Models
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

## File: CondoSphere.Web/Views/_ViewStart.cshtml
```
@{
    Layout = "_Layout";
}
```

## File: CondoSphere.Web/Views/Account/Login.cshtml
```
@model CondoSphere.Core.DTOs.Account.LoginDto

@{
    ViewData["Title"] = "Log in";
}

<h1>@ViewData["Title"]</h1>
<div class="row">
    <div class="col-md-4">
        <section>
            <form id="account" method="post">
                @Html.AntiForgeryToken()
                <hr />
                <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                <div class="form-floating mb-3">
                    <input asp-for="Email" class="form-control" autocomplete="username" aria-required="true" />
                    <label asp-for="Email" class="form-label"></label>
                    <span asp-validation-for="Email" class="text-danger"></span>
                </div>
                <div class="form-floating mb-3">
                    <input asp-for="Password" class="form-control" type="password" autocomplete="current-password" aria-required="true" />
                    <label asp-for="Password" class="form-label"></label>
                    <span asp-validation-for="Password" class="text-danger"></span>
                </div>
                <div>
                    <button id="login-submit" type="submit" class="w-100 btn btn-lg btn-primary">Log in</button>
                </div>
            </form>
        </section>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

## File: CondoSphere.Web/Views/Home/Index.cshtml
```
@{
    ViewData["Title"] = "Home Page";
}

<div class="text-center">
    <h1 class="display-4">Welcome</h1>
    <p>Learn about <a href="https://learn.microsoft.com/aspnet/core">building Web apps with ASP.NET Core</a>.</p>
</div>
```

## File: CondoSphere.Web/Views/Home/Privacy.cshtml
```
@{
    ViewData["Title"] = "Privacy Policy";
}
<h1>@ViewData["Title"]</h1>

<p>Use this page to detail your site's privacy policy.</p>
```

## File: CondoSphere.Web/Views/Shared/_Layout.cshtml.css
```css
/* Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
for details on configuring this project to bundle and minify static web assets. */

a.navbar-brand {
  white-space: normal;
  text-align: center;
  word-break: break-all;
}

a {
  color: #0077cc;
}

.btn-primary {
  color: #fff;
  background-color: #1b6ec2;
  border-color: #1861ac;
}

.nav-pills .nav-link.active, .nav-pills .show > .nav-link {
  color: #fff;
  background-color: #1b6ec2;
  border-color: #1861ac;
}

.border-top {
  border-top: 1px solid #e5e5e5;
}
.border-bottom {
  border-bottom: 1px solid #e5e5e5;
}

.box-shadow {
  box-shadow: 0 .25rem .75rem rgba(0, 0, 0, .05);
}

button.accept-policy {
  font-size: 1rem;
  line-height: inherit;
}

.footer {
  position: absolute;
  bottom: 0;
  width: 100%;
  white-space: nowrap;
  line-height: 60px;
}
```

## File: CondoSphere.Web/Views/Shared/_LoginPartial.cshtml
```
@using Microsoft.AspNetCore.Identity
@using CondoSphere.Core.Entities.Users

<ul class="navbar-nav">
    @if (User.Identity?.IsAuthenticated == true)
    {
        <li class="nav-item">
            @* We can access the user's name (which is their email in our case) from the ClaimsPrincipal *@
            <a class="nav-link text-dark" href="#" title="Manage">Hello, @User.Identity.Name!</a>
        </li>
        <li class="nav-item">
            <form class="form-inline" asp-controller="Account" asp-action="Logout" method="post">
                @Html.AntiForgeryToken()
                <button type="submit" class="nav-link btn btn-link text-dark">Logout</button>
            </form>
        </li>
    }
    else
    {
        <li class="nav-item">
            <a class="nav-link text-dark" asp-controller="Account" asp-action="Login">Login</a>
        </li>
        @* We can add a Register link here later if needed *@
    }
</ul>
```

## File: CondoSphere.Web/Views/Shared/_ValidationScriptsPartial.cshtml
```
<script src="~/lib/jquery-validation/dist/jquery.validate.min.js"></script>
<script src="~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js"></script>
```

## File: CondoSphere.Web/Views/Shared/Error.cshtml
```
@model ErrorViewModel
@{
    ViewData["Title"] = "Error";
}

<h1 class="text-danger">Error.</h1>
<h2 class="text-danger">An error occurred while processing your request.</h2>

@if (Model.ShowRequestId)
{
    <p>
        <strong>Request ID:</strong> <code>@Model.RequestId</code>
    </p>
}

<h3>Development Mode</h3>
<p>
    Swapping to <strong>Development</strong> environment will display more detailed information about the error that occurred.
</p>
<p>
    <strong>The Development environment shouldn't be enabled for deployed applications.</strong>
    It can result in displaying sensitive information from exceptions to end users.
    For local debugging, enable the <strong>Development</strong> environment by setting the <strong>ASPNETCORE_ENVIRONMENT</strong> environment variable to <strong>Development</strong>
    and restarting the app.
</p>
```

## File: CondoSphere.Web/wwwroot/css/site.css
```css
html {
  font-size: 14px;
}

@media (min-width: 768px) {
  html {
    font-size: 16px;
  }
}

.btn:focus, .btn:active:focus, .btn-link.nav-link:focus, .form-control:focus, .form-check-input:focus {
  box-shadow: 0 0 0 0.1rem white, 0 0 0 0.25rem #258cfb;
}

html {
  position: relative;
  min-height: 100%;
}

body {
  margin-bottom: 60px;
}
```

## File: CondoSphere.Web/wwwroot/js/site.js
```javascript
// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
```

## File: CondoSphere.API/CondoSphere.API.http
```
@CondoSphere.API_HostAddress = https://localhost:7177

### REGISTER A NEW COMPANY AND ADMIN ###

POST {{CondoSphere.API_HostAddress}}/api/accounts/register-admin
Content-Type: application/json

{
  "companyName": "My New Test Company",
  "firstName": "Test",
  "lastName": "Admin",
  "email": "test.admin@mynewcompany.com",
  "password": "123456",
  "confirmPassword": "123456!"
}
```

## File: CondoSphere.API/Controllers/AccountsController.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.User;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;
        private readonly UserManager<CoreUser> _userManager;

        public AccountsController(IUserService userService,
                                  ICurrentUserService currentUserService,
                                  UserManager<CoreUser> userManager)
        {
            _userService = userService;
            _currentUserService = currentUserService;
            _userManager = userManager;
        }

        [HttpGet("company-users")]
        [Authorize(Roles = $"{RoleConstants.CompanyAdmin},{RoleConstants.CondoManager}")]
        public async Task<IActionResult> GetCompanyUsers()
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var users = await _userService.GetCompanyUsersWithRolesAsync(companyId.Value);

            return Ok(users);
        }

        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterCompanyAdmin([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.RegisterCompanyAdminAsync(registerDto);

            if (result.Succeeded)
            {
                return StatusCode(201, new { Message = "Company and administrator registered successfully." });
            }

            foreach (var error in result.Errors)
            {
                var errorKey = !string.IsNullOrEmpty(error.Code) ? error.Code : "RegistrationError";
                ModelState.AddModelError(errorKey, error.Description);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDto = await _userService.LoginAsync(loginDto);

            if (userDto == null)
            {
                return Unauthorized(new { Message = "Invalid email or password." });
            }

            return Ok(userDto);
        }

        [HttpPost("register-manager")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> RegisterManager([FromBody] RegisterManagerDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var result = await _userService.RegisterManagerAsync(registerDto, companyId.Value);

            if (result.Succeeded)
            {
                return StatusCode(201, new { Message = "Condominium Manager registered successfully." });
            }

            foreach (var error in result.Errors)
            {
                var errorKey = !string.IsNullOrEmpty(error.Code) ? error.Code : "RegistrationError";
                ModelState.AddModelError(errorKey, error.Description);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("confirm-email")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(int userId, string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return BadRequest("A valid token is required.");
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var decodedToken = System.Net.WebUtility.UrlDecode(token);
            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);

            if (result.Succeeded)
            {
                return Content("<h1>Email confirmed successfully!</h1><p>You can now log in.</p>", "text/html");
            }

            return BadRequest("Email could not be confirmed. The link may have expired.");
        }

        [HttpPost("set-password")]
        [AllowAnonymous]
        public async Task<IActionResult> SetPassword([FromBody] SetPasswordDto setPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByIdAsync(setPasswordDto.UserId);
            if (user == null)
            {
                // Do not reveal that the user does not exist.
                // Return a generic success message to prevent user enumeration attacks.
                return Ok(new { Message = "If a matching account was found, a password has been set." });
            }

            var result = await _userManager.ResetPasswordAsync(user, setPasswordDto.Token, setPasswordDto.Password);

            if (result.Succeeded)
            {
                // This is the crucial step: we now confirm their email because they have proven ownership
                // by successfully using the token that was sent there.
                if (!user.EmailConfirmed)
                {
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                }
                return Ok(new { Message = "Your password has been set successfully. You can now log in." });
            }

            // If token is invalid, passwords don't match criteria, etc.
            return BadRequest(result.Errors);
        }

        [HttpGet("managers")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> GetAvailableManagers()
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var managers = await _userService.GetAvailableManagersAsync(companyId.Value);
            return Ok(managers);
        }
    }
}
```

## File: CondoSphere.API/Controllers/CondominiumsController.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Condominium;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CondominiumsController : ControllerBase
    {
        private readonly ICondominiumService _condominiumService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IValidator<CreateUpdateCondominiumDto> _validator;

        public CondominiumsController(
            ICondominiumService condominiumService,
            ICurrentUserService currentUserService,
             IValidator<CreateUpdateCondominiumDto> validator)
        {
            _condominiumService = condominiumService;
            _currentUserService = currentUserService;
            _validator = validator;
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var condominiums = await _condominiumService.GetAllCondominiumsAsync(companyId.Value, pageNumber, pageSize);
            return Ok(condominiums);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var condominium = await _condominiumService.GetCondominiumByIdAsync(id, companyId.Value);

            if (condominium == null)
            {
                return NotFound();
            }
            return Ok(condominium);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> Create([FromBody] CreateUpdateCondominiumDto condominiumDto)
        {
            var validationResult = await _validator.ValidateAsync(condominiumDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var newCondominium = await _condominiumService.CreateCondominiumAsync(condominiumDto, companyId.Value);

            return CreatedAtAction(nameof(GetById), new { id = newCondominium.Id }, newCondominium);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateUpdateCondominiumDto condominiumDto)
        {
            var validationResult = await _validator.ValidateAsync(condominiumDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var success = await _condominiumService.UpdateCondominiumAsync(id, condominiumDto, companyId.Value);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> Delete(int id)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null)
            {
                return Unauthorized("Company information is missing from the token.");
            }

            var success = await _condominiumService.DeleteCondominiumAsync(id, companyId.Value);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch("{condominiumId}/assign-manager")]
        [Authorize(Roles = RoleConstants.CompanyAdmin)]
        public async Task<IActionResult> AssignManager(int condominiumId, [FromBody] AssignManagerDto dto)
        {
            var companyId = _currentUserService.CompanyId;
            if (companyId == null) return Unauthorized();

            // We use the manager ID from the request body (dto.ManagerId)
            var success = await _condominiumService.AssignManagerAsync(condominiumId, dto.ManagerId, companyId.Value);

            if (!success)
            {
                return BadRequest("Failed to assign manager. Verify condominium and manager IDs are valid for your company.");
            }

            return NoContent();
        }

        [HttpGet("my-managed")]
        [Authorize(Roles = RoleConstants.CondoManager)]
        public async Task<IActionResult> GetMyManagedCondominiums()
        {
            var managerId = _currentUserService.UserId;
            if (managerId == null)
            {
                return Unauthorized("User ID is missing from the token.");
            }

            // We need a new service method for this. Let's add it.
            var condominiums = await _condominiumService.GetCondominiumsByManagerIdAsync(managerId.Value);

            return Ok(condominiums);
        }
    }
}
```

## File: CondoSphere.API/Controllers/UnitsController.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Condominium;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Condominiums;
using CondoSphere.Core.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoSphere.API.Controllers
{
    [ApiController]
    [Route("api/condominiums/{condominiumId}/units")]
    [Authorize] // All actions in this controller require an authenticated user.
    public class UnitsController : ControllerBase
    {
        private readonly IUnitService _unitService;
        private readonly IValidator<CreateUpdateUnitDto> _validator;
        private readonly ICurrentUserService _currentUserService;

        public UnitsController(
            IUnitService unitService,
            IValidator<CreateUpdateUnitDto> validator,
            ICurrentUserService currentUserService)
        {
            _unitService = unitService;
            _validator = validator;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        [Authorize(Policy = "IsCondoManagerPolicy")] // Checks if user is CompanyAdmin OR assigned manager.
        public async Task<IActionResult> GetUnitsForCondominium(int condominiumId)
        {
            var units = await _unitService.GetUnitsForCondominiumAsync(condominiumId);
            return Ok(units);
        }

        [HttpGet("{unitId}")]
        [Authorize(Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> GetUnitById(int condominiumId, int unitId)
        {
            var unit = await _unitService.GetUnitByIdAsync(unitId);
            if (unit == null || unit.CondominiumId != condominiumId)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")] // Must be a manager AND be assigned to this condo.
        public async Task<IActionResult> CreateUnit(int condominiumId, [FromBody] CreateUpdateUnitDto unitDto)
        {
            var validationResult = await _validator.ValidateAsync(unitDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var companyId = _currentUserService.CompanyId;
            if (!companyId.HasValue)
            {
                return Forbid(); // Should not be possible if auth has passed, but is a good safeguard.
            }

            var newUnit = await _unitService.CreateUnitAsync(unitDto, condominiumId, companyId.Value);

            return CreatedAtAction(nameof(GetUnitById), new { condominiumId, unitId = newUnit.Id }, newUnit);
        }

        [HttpPut("{unitId}")]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> UpdateUnit(int condominiumId, int unitId, [FromBody] CreateUpdateUnitDto unitDto)
        {
            var validationResult = await _validator.ValidateAsync(unitDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var existingUnit = await _unitService.GetUnitByIdAsync(unitId);
            if (existingUnit == null || existingUnit.CondominiumId != condominiumId)
            {
                return NotFound();
            }

            var success = await _unitService.UpdateUnitAsync(unitId, unitDto);
            if (!success)
            {
                return NotFound(); // Or another appropriate error
            }

            return NoContent();
        }

        [HttpDelete("{unitId}")]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> DeleteUnit(int condominiumId, int unitId)
        {
            var existingUnit = await _unitService.GetUnitByIdAsync(unitId);
            if (existingUnit == null || existingUnit.CondominiumId != condominiumId)
            {
                return NotFound();
            }

            var success = await _unitService.DeleteUnitAsync(unitId);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPatch("{unitId}/unassign-resident")]
        [Authorize(Roles = RoleConstants.CondoManager, Policy = "IsCondoManagerPolicy")]
        public async Task<IActionResult> UnassignResident(int condominiumId, int unitId)
        {
            var unit = await _unitService.GetUnitByIdAsync(unitId);
            if (unit == null || unit.CondominiumId != condominiumId)
            {
                return NotFound();
            }

            var success = await _unitService.UnassignResidentAsync(unitId);

            if (success)
            {
                return NoContent();
            }

            return BadRequest(new { Message = "Failed to unassign resident. The unit might already be vacant." });
        }
    }
}
```

## File: CondoSphere.Application/Interfaces/ICondominiumRepository.cs
```csharp
using CondoSphere.Core.Entities.Condominiums;

namespace CondoSphere.Application.Interfaces
{
    /// <summary>
    /// Defines the contract for data operations related to Condominiums.
    /// </summary>
    public interface ICondominiumRepository
    {
        Task AddAsync(Condominium condominium);
        void Update(Condominium condominium);
        void Remove(Condominium condominium);
        Task<Condominium?> GetByIdAsync(int id, int companyId);
        Task<IEnumerable<Condominium>> GetAllAsync(int companyId, int pageNumber, int pageSize);
        Task<int> SaveChangesAsync();
        Task<IEnumerable<Condominium>> GetByManagerIdAsync(int managerId);
    }
}
```

## File: CondoSphere.Application/Interfaces/ICurrentUserService.cs
```csharp
namespace CondoSphere.Application.Interfaces
{
    public interface ICurrentUserService
    {
        int? UserId { get; }
        int? CompanyId { get; }
        string? UserEmail { get; }
        bool IsInRole(string roleName);
        Task<(bool IsAuthorized, int? CompanyId)> CanManageCondominium(int condominiumId);
    }
}
```

## File: CondoSphere.Application/Services/Condominium/CondominiumService.cs
```csharp
using AutoMapper;
using CondoSphere.Application.Interfaces;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Condominiums;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CoreCondominium = CondoSphere.Core.Entities.Condominiums.Condominium;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.Condominium
{
    public class CondominiumService : ICondominiumService
    {
        private readonly ICondominiumRepository _condominiumRepository;
        private readonly UserManager<CoreUser> _userManager;
        private readonly IMapper _mapper;

        public CondominiumService(
            ICondominiumRepository condominiumRepository,
            UserManager<CoreUser> userManager,
            IMapper mapper)
        {
            _condominiumRepository = condominiumRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CondominiumDto> CreateCondominiumAsync(CreateUpdateCondominiumDto condominiumDto, int companyId)
        {
            var condominium = _mapper.Map<CoreCondominium>(condominiumDto);
            condominium.CompanyId = companyId;

            await _condominiumRepository.AddAsync(condominium);
            await _condominiumRepository.SaveChangesAsync();

            return _mapper.Map<CondominiumDto>(condominium);
        }

        public async Task<IEnumerable<CondominiumDto>> GetAllCondominiumsAsync(int companyId, int pageNumber, int pageSize)
        {
            // 1. Fetch the raw condominium data from the repository
            var condominiums = await _condominiumRepository.GetAllAsync(companyId, pageNumber, pageSize);
            if (!condominiums.Any())
            {
                return Enumerable.Empty<CondominiumDto>();
            }

            // 2. Map the entities to DTOs
            var condominiumDtos = _mapper.Map<List<CondominiumDto>>(condominiums);

            // 3. Efficiently fetch the names for all required managers in a single query
            var managerIds = condominiums
                .Where(c => c.ManagerId.HasValue)
                .Select(c => c.ManagerId.Value)
                .Distinct()
                .ToList();

            if (managerIds.Any())
            {
                var managers = await _userManager.Users
                    .Where(u => managerIds.Contains(u.Id))
                    .ToDictionaryAsync(u => u.Id, u => $"{u.FirstName} {u.LastName}");

                // 4. Stitch the manager names onto the DTOs
                foreach (var dto in condominiumDtos)
                {
                    var condo = condominiums.First(c => c.Id == dto.Id);
                    if (condo.ManagerId.HasValue && managers.ContainsKey(condo.ManagerId.Value))
                    {
                        dto.ManagerName = managers[condo.ManagerId.Value];
                    }
                }
            }

            return condominiumDtos;
        }

        public async Task<CondominiumDto?> GetCondominiumByIdAsync(int id, int companyId)
        {
            var condominium = await _condominiumRepository.GetByIdAsync(id, companyId);
            return _mapper.Map<CondominiumDto>(condominium);
        }

        public async Task<bool> UpdateCondominiumAsync(int id, CreateUpdateCondominiumDto condominiumDto, int companyId)
        {
            var condominium = await _condominiumRepository.GetByIdAsync(id, companyId);
            if (condominium == null)
            {
                return false;
            }

            _mapper.Map(condominiumDto, condominium);

            _condominiumRepository.Update(condominium);
            return await _condominiumRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCondominiumAsync(int id, int companyId)
        {
            var condominium = await _condominiumRepository.GetByIdAsync(id, companyId);
            if (condominium == null)
            {
                return false;
            }

            _condominiumRepository.Remove(condominium);
            return await _condominiumRepository.SaveChangesAsync() > 0;
        }

        public async Task<bool> AssignManagerAsync(int condominiumId, int managerId, int companyId)
        {
            var condominium = await _condominiumRepository.GetByIdAsync(condominiumId, companyId);
            if (condominium == null) return false;

            var manager = await _userManager.FindByIdAsync(managerId.ToString());
            if (manager == null || manager.CompanyId != companyId) return false;

            var roles = await _userManager.GetRolesAsync(manager);
            if (!roles.Contains(RoleConstants.CondoManager)) return false;

            condominium.ManagerId = managerId;
            _condominiumRepository.Update(condominium);
            return await _condominiumRepository.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CondominiumDto>> GetCondominiumsByManagerIdAsync(int managerId)
        {
            var condominiums = await _condominiumRepository.GetByManagerIdAsync(managerId);
            return _mapper.Map<IEnumerable<CondominiumDto>>(condominiums);
        }
    }
}
```

## File: CondoSphere.Application/Services/User/IUserService.cs
```csharp
using CondoSphere.Core.DTOs.Account;
using Microsoft.AspNetCore.Identity;

namespace CondoSphere.Application.Services.User
{
    /// <summary>
    /// Defines the contract for user management services.
    /// </summary>
    public interface IUserService
    {
        Task<IdentityResult> RegisterCompanyAdminAsync(RegisterDto registerDto);
        Task<UserDto?> LoginAsync(LoginDto loginDto);
        Task<IdentityResult> RegisterManagerAsync(RegisterManagerDto registerDto, int companyId);
        Task<IEnumerable<UserListDto>> GetCompanyUsersWithRolesAsync(int companyId);
        Task<IdentityResult> RegisterResidentAsync(RegisterResidentDto dto, int companyId, int condominiumId);
        Task<IEnumerable<UserListDto>> GetAvailableManagersAsync(int companyId);
    }
}
```

## File: CondoSphere.Application/Services/User/UserService.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Token;
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;
using CoreUser = CondoSphere.Core.Entities.Users.User;

namespace CondoSphere.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<CoreUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IUnitRepository _unitRepository; // Dependency for resident registration

        public UserService(
            UserManager<CoreUser> userManager,
            IUnitOfWork unitOfWork,
            ITokenService tokenService,
            IMailService mailService,
            IConfiguration configuration,
            IUserRepository userRepository,
            IUnitRepository unitRepository) // Inject the new dependency
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _mailService = mailService;
            _configuration = configuration;
            _userRepository = userRepository;
            _unitRepository = unitRepository; // Assign the new dependency
        }

        public async Task<UserDto?> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return null;
            }

            return new UserDto
            {
                FirstName = user.FirstName ?? string.Empty,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user)
            };
        }

        public async Task<IdentityResult> RegisterCompanyAdminAsync(RegisterDto registerDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "An account with this email address already exists." });
            }

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var newCompany = new Company { Name = registerDto.CompanyName, IsActive = true };
                await _unitOfWork.Companies.AddAsync(newCompany);
                await _unitOfWork.CompleteAsync();

                var newUser = new CoreUser
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    Email = registerDto.Email,
                    UserName = registerDto.Email,
                    CompanyId = newCompany.Id,
                    IsActive = true
                };

                var result = await _userManager.CreateAsync(newUser, registerDto.Password);
                if (!result.Succeeded)
                {
                    await _unitOfWork.RollbackAsync();
                    return result;
                }

                await _userManager.AddToRoleAsync(newUser, RoleConstants.CompanyAdmin);

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                var encodedToken = WebUtility.UrlEncode(token);
                var webAppBaseUrl = _configuration["ClientSettings:WebAppBaseUrl"];
                var confirmationLink = $"{webAppBaseUrl}/Account/ConfirmEmail?userId={newUser.Id}&token={encodedToken}";

                await _mailService.SendEmailAsync(
                    newUser.Email,
                    "Confirm your CondoSphere Account",
                    $"<h1>Welcome to CondoSphere!</h1><p>Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.</p>");

                await _unitOfWork.CommitAsync();

                return IdentityResult.Success;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<IdentityResult> RegisterManagerAsync(RegisterManagerDto registerDto, int companyId)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "An account with this email address already exists." });
            }

            var newUser = new CoreUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.Email,
                CompanyId = companyId,
                IsActive = true,
                EmailConfirmed = false // Email is not confirmed until they set the password
            };

            var result = await _userManager.CreateAsync(newUser); // Create user without password
            if (!result.Succeeded)
            {
                return result;
            }

            await _userManager.AddToRoleAsync(newUser, RoleConstants.CondoManager);

            // Generate and send the "Set Password" link
            var token = await _userManager.GeneratePasswordResetTokenAsync(newUser);
            var encodedToken = WebUtility.UrlEncode(token);
            var setPasswordLink = $"{_configuration["ClientSettings:WebAppBaseUrl"]}/Account/SetPassword?userId={newUser.Id}&token={encodedToken}";

            await _mailService.SendEmailAsync(
                newUser.Email,
                "You've been invited to CondoSphere - Set Your Password",
                $"<h1>Welcome, Manager!</h1>" +
                $"<p>You have been registered as a Condominium Manager. Please complete your account setup by setting a password.</p>" +
                $"<p><a href='{setPasswordLink}'>Set Your Password</a></p>");

            return IdentityResult.Success;
        }

        public async Task<IEnumerable<UserListDto>> GetCompanyUsersWithRolesAsync(int companyId)
        {
            return await _userRepository.GetCompanyUsersWithRolesAsync(companyId);
        }

        public async Task<IdentityResult> RegisterResidentAsync(RegisterResidentDto dto, int companyId, int condominiumId)
        {
            // 1. Validate that the Unit exists, belongs to the correct condominium, and is available
            var unit = await _unitRepository.GetByIdAsync(dto.UnitId);
            if (unit == null || unit.CondominiumId != condominiumId)
            {
                return IdentityResult.Failed(new IdentityError { Code = "UnitNotFound", Description = "Unit not found in this condominium." });
            }

            if (unit.ResidentId.HasValue)
            {
                return IdentityResult.Failed(new IdentityError { Code = "UnitOccupied", Description = "This unit already has an assigned resident." });
            }

            // 2. Check if user email already exists
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Code = "DuplicateEmail", Description = "An account with this email address already exists." });
            }

            // 3. Create the new user WITHOUT a password.
            // The account is created but is effectively 'locked' until a password is set.
            var newUser = new CoreUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = dto.Email,
                CompanyId = companyId,
                IsActive = true,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(newUser); // This overload does not require a password.
            if (!result.Succeeded)
            {
                return result;
            }

            // 4. Assign the correct role
            await _userManager.AddToRoleAsync(newUser, RoleConstants.CondoResident);

            // 5. Link the new user to the unit and save
            unit.ResidentId = newUser.Id;
            _unitRepository.Update(unit);
            await _unitRepository.SaveChangesAsync();

            // 6. Generate a "Set Password" token and send the welcome email
            var token = await _userManager.GeneratePasswordResetTokenAsync(newUser);
            var encodedToken = WebUtility.UrlEncode(token);

            // This URL will point to a new page we need to create in the Web project
            var setPasswordLink = $"{_configuration["ClientSettings:WebAppBaseUrl"]}/Account/SetPassword?userId={newUser.Id}&token={encodedToken}";

            await _mailService.SendEmailAsync(
                newUser.Email,
                "Welcome to CondoSphere - Set Your Password",
                $"<h1>Welcome to CondoSphere!</h1>" +
                $"<p>An account has been created for you by your condominium management.</p>" +
                $"<p>Please complete your registration by setting your password. Click the link below to get started:</p>" +
                $"<p><a href='{setPasswordLink}'>Set Your Password</a></p>");

            return IdentityResult.Success;
        }

        public async Task<IEnumerable<UserListDto>> GetAvailableManagersAsync(int companyId)
        {
            return await _userRepository.GetUsersInRoleAsync(RoleConstants.CondoManager, companyId);
        }
    }
}
```

## File: CondoSphere.Core/Entities/Condominiums/Condominium.cs
```csharp
using CondoSphere.Core;

namespace CondoSphere.Core.Entities.Condominiums
{
    public class Condominium : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int? ManagerId { get; set; }
    }
}
```

## File: CondoSphere.Core/Entities/Condominiums/Unit.cs
```csharp
namespace CondoSphere.Core.Entities.Condominiums
{
    /// <summary>
    /// Represents a single unit or fraction within a Condominium,
    /// such as an apartment, office, or storage space.
    /// </summary>
    public class Unit : IEntity
    {
        /// <summary>
        /// The unique primary key for the Unit.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A user-friendly identifier for the unit, such as "Apt 101", "Fraction A", or "Floor 2, Office 3".
        /// This is the name displayed in the UI.
        /// </summary>
        public string Identifier { get; set; } = string.Empty;

        /// <summary>
        /// The foreign key linking this Unit to its parent Condominium.
        /// This is a required field, as a Unit cannot exist without being part of a Condominium.
        /// </summary>
        public int CondominiumId { get; set; }

        /// <summary>
        /// The foreign key to the company that manages this unit's condominium.
        /// This is denormalized from the parent Condominium entity to allow for more
        //  efficient, tenant-scoped queries without requiring a join.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// The foreign key to the User who is the official resident of this unit.
        /// Nullable because a unit can be vacant.
        /// </summary>
        public int? ResidentId { get; set; }
    }
}
```

## File: CondoSphere.Infrastructure/Authorization/IsCondoManagerHandler.cs
```csharp
using CondoSphere.Application.Authorization;
using CondoSphere.Core;
using CondoSphere.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CondoSphere.Infrastructure.Authorization
{
    public class IsCondoManagerHandler : AuthorizationHandler<IsCondoManagerRequirement>
    {
        private readonly CondominiumDbContext _condoContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IsCondoManagerHandler(CondominiumDbContext condoContext, IHttpContextAccessor httpContextAccessor)
        {
            _condoContext = condoContext;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            IsCondoManagerRequirement requirement)
        {
            // First, check for the override role. A CompanyAdmin can manage everything.
            if (context.User.IsInRole(RoleConstants.CompanyAdmin))
            {
                context.Succeed(requirement);
                return;
            }

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
            {
                context.Fail();
                return;
            }

            var userIdClaim = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdClaim, out var userId))
            {
                context.Fail();
                return;
            }

            var condominiumIdRouteValue = httpContext.GetRouteValue("condominiumId")?.ToString();
            if (!int.TryParse(condominiumIdRouteValue, out var condominiumId))
            {
                condominiumIdRouteValue = httpContext.GetRouteValue("id")?.ToString();
                if (!int.TryParse(condominiumIdRouteValue, out condominiumId))
                {
                    context.Fail();
                    return;
                }
            }

            // Check the database to see if this user is the manager of this condominium.
            // We do NOT use IgnoreQueryFilters() here. This is intentional.
            // We want this authorization check to respect any global filters, such as a
            // potential future soft-delete "IsActive" flag on condominiums.
            bool isManagerOfCondo = await _condoContext.Condominiums
                .AnyAsync(c => c.Id == condominiumId && c.ManagerId == userId);

            if (isManagerOfCondo)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}
```

## File: CondoSphere.Infrastructure/Data/SeedDb.cs
```csharp
using CondoSphere.Core;
using CondoSphere.Core.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace CondoSphere.Infrastructure.Data
{
    /// <summary>
    /// Responsible for seeding initial data into the database.
    /// </summary>
    public class SeedDb
    {
        private readonly UserManagementDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public SeedDb(UserManagementDbContext context, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
        }

        private async Task CheckRolesAsync()
        {
            // Use the constant for the check
            if (!await _roleManager.RoleExistsAsync(RoleConstants.CompanyAdmin))
            {
                // Use the constants for creation
                await _roleManager.CreateAsync(new IdentityRole<int>(RoleConstants.CompanyAdmin));
                await _roleManager.CreateAsync(new IdentityRole<int>(RoleConstants.CondoManager));
                await _roleManager.CreateAsync(new IdentityRole<int>(RoleConstants.CondoResident));
                await _roleManager.CreateAsync(new IdentityRole<int>(RoleConstants.Employee));
                await _roleManager.CreateAsync(new IdentityRole<int>(RoleConstants.PlatformSuperAdmin));
            }
        }
    }
}
```

## File: CondoSphere.Infrastructure/Data/UserManagementDbContext.cs
```csharp
using CondoSphere.Core.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Data
{
    /// <summary>
    /// Represents the database context for the User Management database.
    /// Inherits from IdentityDbContext to include tables for ASP.NET Core Identity.
    /// </summary>
    public class UserManagementDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        // DbSet properties tell EF Core which of our entities should become tables.

        /// <summary>
        /// Represents the 'Companies' table.
        /// </summary>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Represents the 'Notifications' table.
        /// </summary>
        public DbSet<Notification> Notifications { get; set; }

        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().HasQueryFilter(u => u.IsActive);
            builder.Entity<Company>().HasQueryFilter(c => c.IsActive);
        }
    }
}
```

## File: CondoSphere.Infrastructure/Repositories/CondominiumRepository.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Core.Entities.Condominiums;
using CondoSphere.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CondoSphere.Infrastructure.Repositories
{
    public class CondominiumRepository : ICondominiumRepository
    {
        private readonly CondominiumDbContext _context;

        public CondominiumRepository(CondominiumDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Condominium condominium)
        {
            await _context.Condominiums.AddAsync(condominium);
        }

        public async Task<IEnumerable<Condominium>> GetAllAsync(int companyId, int pageNumber, int pageSize)
        {
            var query = _context.Condominiums
                .Where(c => c.CompanyId == companyId);

            var pagedQuery = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return await pagedQuery.AsNoTracking().ToListAsync();
        }

        public async Task<Condominium?> GetByIdAsync(int id, int companyId)
        {
            return await _context.Condominiums
                .FirstOrDefaultAsync(c => c.Id == id && c.CompanyId == companyId);
        }

        public void Remove(Condominium condominium)
        {
            _context.Condominiums.Remove(condominium);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Condominium condominium)
        {
            _context.Entry(condominium).State = EntityState.Modified;
        }
        public async Task<IEnumerable<Condominium>> GetByManagerIdAsync(int managerId)
        {
            return await _context.Condominiums
                .Where(c => c.ManagerId == managerId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
```

## File: CondoSphere.Infrastructure/Services/CurrentUserService.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CondoSphere.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CondominiumDbContext _condoContext;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, CondominiumDbContext condoContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _condoContext = condoContext;
        }

        public int? UserId => GetClaimValue<int>(ClaimTypes.NameIdentifier);

        public int? CompanyId => GetClaimValue<int>("companyId");

        public string? UserEmail => GetClaimValue<string>(ClaimTypes.Email);

        public bool IsInRole(string roleName)
        {
            return _httpContextAccessor.HttpContext?.User.IsInRole(roleName) ?? false;
        }

        private T? GetClaimValue<T>(string claimType)
        {
            var claimValue = _httpContextAccessor.HttpContext?.User?.FindFirstValue(claimType);
            if (string.IsNullOrEmpty(claimValue))
            {
                return default;
            }
            return (T)Convert.ChangeType(claimValue, typeof(T));
        }

        public async Task<(bool IsAuthorized, int? CompanyId)> CanManageCondominium(int condominiumId)
        {
            var userId = this.UserId; // Get user ID from the existing property
            if (userId == null) return (false, null);

            // One single, efficient database call to check everything.
            var condo = await _condoContext.Condominiums
                                .AsNoTracking()
                                .FirstOrDefaultAsync(c => c.Id == condominiumId && c.ManagerId == userId);

            if (condo != null)
            {
                // If found, user is authorized, and we return the condo's CompanyId.
                return (true, condo.CompanyId);
            }

            // If not found, user is not authorized.
            return (false, null);
        }
    }
}
```

## File: CondoSphere.Web/appsettings.Development.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## File: CondoSphere.Web/Controllers/AccountController.cs
```csharp
using CondoSphere.Core;
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CondoSphere.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiClient _apiClient;
        private readonly IConfiguration _configuration;

        public AccountController(ApiClient apiClient, IConfiguration configuration)
        {
            _apiClient = apiClient;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userDto = await _apiClient.LoginAsync(model);

            if (userDto == null || string.IsNullOrWhiteSpace(userDto.Token))
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            var handler = new JwtSecurityTokenHandler();
            var principal = handler.ValidateToken(
                userDto.Token,
                new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                },
                out _);

            // Create a new claims identity to add our custom access_token claim
            var claimsIdentity = (ClaimsIdentity)principal.Identity;
            claimsIdentity.AddClaim(new Claim("access_token", userDto.Token));

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, // Make the cookie persistent
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
            };

            // Use the new identity with the added claim to sign in
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            if (User.IsInRole(RoleConstants.CompanyAdmin))
            {
                return RedirectToAction("Index", "Administration");
            }
            if (User.IsInRole(RoleConstants.CondoManager))
            {
                return RedirectToAction("Index", "CondoManagement");
            }
            if (User.IsInRole(RoleConstants.CondoResident))
            {
                return RedirectToAction("Index", "Portal");
            }

            return RedirectToAction("Index", "Home"); // Fallback for any other case
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Use the built-in method to sign out, which automatically clears the authentication cookie.
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        // Optional: An Access Denied page for users who are logged in but not authorized for a specific page.
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SetPassword(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return BadRequest("A user ID and token must be supplied for password set.");
            }

            var model = new SetPasswordDto { UserId = userId, Token = token };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetPassword(SetPasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (success, message) = await _apiClient.SetPasswordAsync(model);

            if (success)
            {
                TempData["SuccessMessage"] = message;
                return RedirectToAction(nameof(Login));
            }

            ModelState.AddModelError(string.Empty, message);
            return View(model);
        }
    }
}
```

## File: CondoSphere.Web/Services/ApiClient.cs
```csharp
using CondoSphere.Core.DTOs.Account;
using CondoSphere.Core.DTOs.Condominiums;

namespace CondoSphere.Web.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDto?> LoginAsync(LoginDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/login", loginDto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UserDto>();
            }

            return null;
        }

        public async Task<bool> RegisterManagerAsync(RegisterManagerDto registerDto)
        {
            // We need to send the token with this request. This is the next major step.
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/register-manager", registerDto);
            return response.IsSuccessStatusCode;
        }

        // --- ADD THESE NEW METHODS ---
        public async Task<IEnumerable<CondominiumDto>> GetCondominiumsAsync()
        {
            // TODO: Add paging parameters
            return await _httpClient.GetFromJsonAsync<IEnumerable<CondominiumDto>>("/api/condominiums");
        }

        public async Task<IEnumerable<UserListDto>> GetUsersAsync()
        {
            // TODO: We need to create this API endpoint next.
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserListDto>>("/api/accounts/company-users");
        }

        public async Task<IEnumerable<CondominiumDto>> GetMyManagedCondominiumsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CondominiumDto>>("/api/condominiums/my-managed");
        }

        public async Task<CondominiumDto> GetCondominiumDetailsAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CondominiumDto>($"/api/condominiums/{id}");
        }

        public async Task<IEnumerable<UnitDto>> GetUnitsForCondominiumAsync(int condominiumId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UnitDto>>($"/api/condominiums/{condominiumId}/units");
        }

        public async Task<bool> RegisterResidentAsync(int condominiumId, RegisterResidentDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/condominiums/{condominiumId}/residents", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<(bool Success, string Message)> SetPasswordAsync(SetPasswordDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/accounts/set-password", dto);
            var responseContent = await response.Content.ReadFromJsonAsync<object>(); // Or a specific response DTO

            if (response.IsSuccessStatusCode)
            {
                // A simple way to get the message back
                var message = responseContent?.GetType().GetProperty("message")?.GetValue(responseContent)?.ToString();
                return (true, message ?? "Password set successfully.");
            }

            // Handle error messages if the API returns them in a structured way
            return (false, "Failed to set password. The link may have expired or the password may not meet complexity requirements.");
        }

        public async Task<bool> CreateCondominiumAsync(CreateUpdateCondominiumDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/condominiums", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<UserListDto>> GetAvailableManagersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<UserListDto>>("/api/accounts/managers");
        }

        public async Task<bool> AssignManagerAsync(int condominiumId, AssignManagerDto dto)
        {
            var response = await _httpClient.PatchAsJsonAsync($"/api/condominiums/{condominiumId}/assign-manager", dto);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> CreateUnitAsync(int condominiumId, CreateUpdateUnitDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/condominiums/{condominiumId}/units", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UnassignResidentAsync(int condominiumId, int unitId)
        {
            var response = await _httpClient.PatchAsync($"/api/condominiums/{condominiumId}/units/{unitId}/unassign-resident", null);
            return response.IsSuccessStatusCode;
        }
    }
}
```

## File: CondoSphere.Web/Views/Shared/_Layout.cshtml
```
@using CondoSphere.Core
@using Microsoft.AspNetCore.Identity

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"] - CondoSphere</title>
    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="~/css/site.css" asp-append-version="true" />
    <link rel="stylesheet" href="~/CondoSphere.Web.styles.css" asp-append-version="true" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
</head>
<body>
    <header>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
            <div class="container-fluid">
                <a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">CondoSphere</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                    <ul class="navbar-nav flex-grow-1">
                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
                        </li>

                        @* ===== START OF NEW ROLE-AWARE NAVIGATION ===== *@
                        @if (User.Identity != null && User.Identity.IsAuthenticated)
                        {
                            if (User.IsInRole(RoleConstants.CompanyAdmin))
                            {
                                <li class="nav-item">
                                    <a class="nav-link text-dark" asp-controller="Administration" asp-action="Index">Admin Dashboard</a>
                                </li>
                            }
                            if (User.IsInRole(RoleConstants.CondoManager))
                            {
                                <li class="nav-item">
                                    <a class="nav-link text-dark" asp-controller="CondoManagement" asp-action="Index">My Condos</a>
                                </li>
                            }
                            if (User.IsInRole(RoleConstants.CondoResident))
                            {
                                <li class="nav-item">
                                    <a class="nav-link text-dark" asp-controller="Portal" asp-action="Index">My Portal</a>
                                </li>
                            }
                        }
                        @* ===== END OF NEW ROLE-AWARE NAVIGATION ===== *@

                        <li class="nav-item">
                            <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
                        </li>
                    </ul>

                    <partial name="_LoginPartial" />

                </div>
            </div>
        </nav>
    </header>
    <div class="container">
        <main role="main" class="pb-3">
            @* Add support for TempData success messages *@
            @if (TempData["SuccessMessage"] != null)
            {
                <div class="alert alert-success" role="alert">
                    @TempData["SuccessMessage"]
                </div>
            }
            @RenderBody()
        </main>
    </div>

    <footer class="border-top footer text-muted">
        <div class="container">
            © 2025 - CondoSphere - <a asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
        </div>
    </footer>
    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="~/js/site.js" asp-append-version="true"></script>
    @await RenderSectionAsync("Scripts", required: false)
</body>
</html>
```

## File: CondoSphere.API/appsettings.Development.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "UserManagementConnection": "Server=(LocalDb)\\MSSQLLocalDB;Database=CondoSphere_UserManagementDB;Trusted_Connection=True;",
    "CondominiumConnection": "Server=(LocalDb)\\MSSQLLocalDB;Database=CondoSphere_CondominiumDB;Trusted_Connection=True;"
  },
  "MailSettings": {
    "From": "condosphere.geral@gmail.com",
    "Smtp": "smtp.gmail.com",
    "Port": 587,
    "Username": "condosphere.geral@gmail.com"
  }
}
```

## File: CondoSphere.Web/Program.cs
```csharp
using CondoSphere.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// --- Add services to the container. ---

// 1. Configure standard MVC services.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor(); // Required for the handler to access the current HttpContext

// 2. Register the handler. It's transient because handlers can have state.
builder.Services.AddTransient<JwtForwardingDelegatingHandler>();

// 3. Configure Authentication services using the "Cookies" scheme.
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        // The name of the cookie that will store our authentication session.
        options.Cookie.Name = "CondoSphere.AuthCookie";
        // If an unauthenticated user tries to access a protected page, redirect them to the Login page.
        options.LoginPath = "/Account/Login";
        // If a logged-in user tries to access a resource they don't have permission for.
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

// 4. Configure Authorization services. This can be expanded with policies later.
builder.Services.AddAuthorization();

// 5. Configure our typed HttpClient for communicating with the API.
builder.Services.AddHttpClient<ApiClient>(client =>
{
    // Set the base URL for all API calls made by this client.
    // This value comes from our appsettings file (e.g., appsettings.Development.json).
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]);
})
.AddHttpMessageHandler<JwtForwardingDelegatingHandler>(); // Attach the handler to the HttpClient pipeline

var app = builder.Build();

// --- Configure the HTTP request pipeline. ---

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// The correct order for authentication middleware in the pipeline:
// 1. UseAuthentication: Identifies who the user is by reading the cookie.
// 2. UseAuthorization: Checks if the identified user has permission to access the requested resource.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```

## File: CondoSphere.API/Program.cs
```csharp
using CondoSphere.Application.Interfaces;
using CondoSphere.Application.Services.Condominium;
using CondoSphere.Application.Services.Token;
using CondoSphere.Application.Services.User;
using CondoSphere.Core.Entities.Users;
using CondoSphere.Infrastructure.Data;
using CondoSphere.Infrastructure.Repositories;
using CondoSphere.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using FluentValidation;
using CondoSphere.Application.Authorization;
using CondoSphere.Infrastructure.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace CondoSphere.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var userManagementConnectionString = builder.Configuration.GetConnectionString("UserManagementConnection");
            var condominiumConnectionString = builder.Configuration.GetConnectionString("CondominiumConnection");

            builder.Services.AddDbContext<UserManagementDbContext>(options =>options.UseSqlServer(userManagementConnectionString));
            builder.Services.AddDbContext<CondominiumDbContext>(options =>options.UseSqlServer(condominiumConnectionString));

            builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                //TODO: Aumentar a segurança da password (por enquanto vamos usar 123456)
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<UserManagementDbContext>()
            .AddDefaultTokenProviders()
            .AddRoles<IdentityRole<int>>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });


            //Services-----------------------------------------------------------------------------------

            builder.Services.AddTransient<SeedDb>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<ICondominiumRepository, CondominiumRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICondominiumService, CondominiumService>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IMailService, MailService>();
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(typeof(CondoSphere.Application.Mappings.CondominiumProfile).Assembly);
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("IsCondoManagerPolicy", policy =>
                    policy.AddRequirements(new IsCondoManagerRequirement()));
            });

            builder.Services.AddScoped<IAuthorizationHandler, IsCondoManagerHandler>();


            builder.Services.AddControllers();
            builder.Services.AddValidatorsFromAssemblyContaining<CondoSphere.Application.Validators.Condominiums.CreateUpdateCondominiumDtoValidator>();
            builder.Services.AddScoped<IUnitRepository, UnitRepository>();
            builder.Services.AddScoped<IUnitService, UnitService>();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                // 1. Define the security scheme (what kind of security we are using)
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                // 2. Make Swagger UI apply this security scheme to all endpoints that have an [Authorize] attribute
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<SeedDb>();
                await seeder.SeedAsync();
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
```
