cd src
docker build -f ./NetCoreMicro/Dockerfile -t netcoremicro.api ./NetCoreMicro
docker build -f ./NetCoreMicro.Services.Activities/Dockerfile -t netcoremicro.services.activities ./NetCoreMicro.Services.Activities
docker build -f ./NetCoreMicro.Services.Identity/Dockerfile -t netcoremicro.services.identity ./NetCoreMicro.Services.Identity