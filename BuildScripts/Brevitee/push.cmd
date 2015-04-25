@echo off

nuget push Packages\BreviteeToolkit.%1.nupkg 
nuget push Packages\Brevitee.%1.nupkg 
nuget push Packages\Brevitee.Analytics.%1.nupkg
nuget push Packages\Brevitee.Automation.%1.nupkg
nuget push Packages\Brevitee.CommandLine.%1.nupkg 
nuget push Packages\Brevitee.Data.%1.nupkg
nuget push Packages\Brevitee.Data.Repositories.%1.nupkg
nuget push Packages\Brevitee.Distributed.%1.nupkg
nuget push Packages\Brevitee.Drawing.%1.nupkg
nuget push Packages\Brevitee.Dust.%1.nupkg
nuget push Packages\Brevitee.Encryption.%1.nupkg
nuget push Packages\Brevitee.Html.%1.nupkg
nuget push Packages\Brevitee.Incubation.%1.nupkg 
nuget push Packages\Brevitee.Javascript.%1.nupkg
nuget push Packages\Brevitee.Logging.%1.nupkg 
nuget push Packages\Brevitee.Management.%1.nupkg
nuget push Packages\Brevitee.Messaging.%1.nupkg
nuget push Packages\Brevitee.Net.%1.nupkg
nuget push Packages\Brevitee.Profiguration.%1.nupkg
nuget push Packages\Brevitee.Schema.Org.%1.nupkg
nuget push Packages\Brevitee.Server.%1.nupkg 
nuget push Packages\Brevitee.ServiceProxy.%1.nupkg 
nuget push Packages\Brevitee.SourceControl.%1.nupkg 
nuget push Packages\Brevitee.Syndication.%1.nupkg 
nuget push Packages\Brevitee.Testing.%1.nupkg 
nuget push Packages\Brevitee.UserAccounts.%1.nupkg
nuget push Packages\Brevitee.Yaml.%1.nupkg

:END