set sourceUrl=-source https://www.nuget.org/api/v2/package

nuget push %~dp0artifacts\FastHttpRequest.1.0.4.nupkg %sourceUrl%

