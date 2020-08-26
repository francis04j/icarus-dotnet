
# RUN JUST THIS CONTAINER FROM ROOT (folder with .sln file):
# docker build --pull -t api -f src/WebApi/Dockerfile .
#
# RUN COMMAND
# docker run --name recoupapi --rm -it -p 44360:44360 api
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY *.sln .
COPY . .
# RUN echo $(ls -1 .)

WORKDIR /app/Src/WebApi
RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/Src/WebApi/out ./

# Optional: Set this here if not setting it from docker-compose.yml
ENV ASPNETCORE_ENVIRONMENT Development

ENTRYPOINT ["dotnet", "Api.dll"]