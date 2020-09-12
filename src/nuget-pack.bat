del .nuget\*.nupkg /f/s/q

nuget pack HtmlAgilityPack.Net45/HtmlAgilityPack.Net45.csproj -OutputDirectory .nuget\ -properties Configuration=Release

pause