cd src
dotnet publish ./NetCoreMicro -c Release -o ./bin/Docker
dotnet publish ./NetCoreMicro.Services.Activities -c Release -o ./bin/Docker
dotnet publish ./NetCoreMicro.Services.Identity -c Release -o ./bin/Docker