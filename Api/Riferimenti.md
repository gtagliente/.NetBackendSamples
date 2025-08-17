Create a .net core webapi on VsCode and running with debugger, then create an image and run it with docker container
https://youtu.be/8FPtEyuxX4A?si=BtvmydVu2l97DLoT

.Net Cmds
    - dotnet new webapi -n vscodeApi   ==> Creates webapi .net core
    - dotnet build/ run  vscodeApi.csproj

Docker
https://www.youtube.com/watch?v=1siuM5h-uLA&t=318s
https://www.youtube.com/watch?v=2lWMMfmwE8w
https://youtu.be/yQtgY4VG3kM?si=xYzYngqFTgM2rySB


docker build -t cleanarchitectureapi_1 . -f CleanArchitecture.API/Dockerfile

Certificato Https su docker cmd: %USERPROFILE%| powershell: $env:USERPROFILE
https://stackoverflow.com/questions/77063237/how-to-configure-ssl-certificate-in-docker-container
https://learn.microsoft.com/en-us/aspnet/core/security/docker-https?view=aspnetcore-9.0
https://stackoverflow.com/questions/64017267/dotnet-dev-certs-certificate-not-trusted

dotnet dev-certs https -ep %USERPROFILE%\.dotnet\https\aspnetapp.pfx -p myCrtPW2025.
dotnet dev-certs https -ep C:\Users\gianl\.dotnet\https\aspnetapp.pfx -p myCrtPW2025.

docker run -p 32781:51112 -e ASPNETCORE_URLS=https://+:51112 -e ASPNETCORE_HTTPS_PORT=51112 -e ASPNETCORE_Kestrel__Certificates__Default__Password="myCrtPW2025." -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx  -v $env:USERPROFILE\.dotnet\https:/https  --name clarchcontainer cleanarchitectureapi_1

Docker Debugging
Debugger VS2022
https://learn.microsoft.com/en-us/visualstudio/debugger/attach-to-process-running-in-docker-container?view=vs-2022

Debugger VSCODE
https://robearlam.com/blog/using-vscode-to-debug-a-netcore-application-running-inside-a-Docker-container

Installare applicazioni nel container docker (da eseguire nel terminale del container target)
iputils-ping serve per fare ping dal container di docker (l'ho usato per testare la raggiungibilità di un altro container)
apt-get update -y
apt-get install -y iputils-ping


Creare progetto in vscode
https://learn.microsoft.com/en-us/dotnet/core/tutorials/library-with-visual-studio-code

Usare NugetPackageManager in vscode
https://code.visualstudio.com/docs/csharp/package-management


Estensione vscode per gestire le solution .net
https://stackoverflow.com/questions/49805204/adding-reference-to-another-project-from-visual-studio-code
vscode-solution-explore