dotnet restore

dotnet build .\SDK\CCPRestSDK 

dotnet test .\test\CCPRestSDKTest 

dotnet pack .\SDK\CCPRestSDK

$project = Get-Content ".\SDK\CCPRestSDK\project.json" | ConvertFrom-Json
$version = $project.version.Trim("-*")
nuget push .\SDK\CCPRestSDK\bin\Debug\com.cloopen.CCPRestSDKCore.$version.nupkg -source nuget -apikey $env:NUGET_API_KEY