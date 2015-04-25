echo off
SET VERSIONKIND=%1
if %VERSIONKIND%=="" GOTO END
echo %VERSIONKIND%

nuver %VERSIONKIND% /path:BreviteeToolkit\BreviteeToolkit.nuspec 
nuver %VERSIONKIND% /path:Brevitee\Brevitee.nuspec 
nuver %VERSIONKIND% /path:Brevitee.Analytics\Brevitee.Analytics.nuspec
nuver %VERSIONKIND% /path:Brevitee.Automation\Brevitee.Automation.nuspec
nuver %VERSIONKIND% /path:Brevitee.CommandLine\Brevitee.CommandLine.nuspec 
nuver %VERSIONKIND% /path:Brevitee.Data\Brevitee.Data.nuspec
nuver %VERSIONKIND% /path:Brevitee.Data.Repositories\Brevitee.Data.Repositories.nuspec
nuver %VERSIONKIND% /path:Brevitee.Distributed\Brevitee.Distributed.nuspec
nuver %VERSIONKIND% /path:Brevitee.Drawing\Brevitee.Drawing.nuspec
nuver %VERSIONKIND% /path:Brevitee.Dust\Brevitee.Dust.nuspec
nuver %VERSIONKIND% /path:Brevitee.Encryption\Brevitee.Encryption.nuspec
nuver %VERSIONKIND% /path:Brevitee.Html\Brevitee.Html.nuspec
nuver %VERSIONKIND% /path:Brevitee.Incubation\Brevitee.Incubation.nuspec 
nuver %VERSIONKIND% /path:Brevitee.Javascript\Brevitee.Javascript.nuspec
nuver %VERSIONKIND% /path:Brevitee.Logging\Brevitee.Logging.nuspec 
nuver %VERSIONKIND% /path:Brevitee.Management\Brevitee.Management.nuspec
nuver %VERSIONKIND% /path:Brevitee.Messaging\Brevitee.Messaging.nuspec
nuver %VERSIONKIND% /path:Brevitee.Net\Brevitee.Net.nuspec
nuver %VERSIONKIND% /path:Brevitee.Profiguration\Brevitee.Profiguration.nuspec
nuver %VERSIONKIND% /path:Brevitee.Schema.Org\Brevitee.Schema.Org.nuspec
nuver %VERSIONKIND% /path:Brevitee.Server\Brevitee.Server.nuspec 
nuver %VERSIONKIND% /path:Brevitee.ServiceProxy\Brevitee.ServiceProxy.nuspec 
nuver %VERSIONKIND% /path:Brevitee.SourceControl\Brevitee.SourceControl.nuspec 
nuver %VERSIONKIND% /path:Brevitee.Syndication\Brevitee.Syndication.nuspec 
nuver %VERSIONKIND% /path:Brevitee.Testing\Brevitee.Testing.nuspec 
nuver %VERSIONKIND% /path:Brevitee.UserAccounts\Brevitee.UserAccounts.nuspec
nuver %VERSIONKIND% /path:Brevitee.Yaml\Brevitee.Yaml.nuspec

:END