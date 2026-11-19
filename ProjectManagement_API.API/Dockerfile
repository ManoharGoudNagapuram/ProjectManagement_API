#stage1: build and publish
#compiling C# code, downloading NuGet packages, and publishing a .NET application require the SDK.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

#copy the project  file
COPY ["ProjectManagement_API.API/ProjectManagement_API.API.csproj", "ProjectManagement_API.API/"]
COPY ["ProjectManagement_API.Application/ProjectManagement_API.Application.csproj", "ProjectManagement_API.Application/"]
COPY ["ProjectManagement_API.Core/ProjectManagement_API.Core.csproj", "ProjectManagement_API.Core/"]
COPY ["ProjectManagement_API.Infrastracture/ProjectManagement_API.Infrastracture.csproj", "ProjectManagement_API.Infrastracture/"]

#restore packages
RUN dotnet restore "ProjectManagement_API.API/ProjectManagement_API.API.csproj"

#copy all remaining source files. the below copy is seperated from above copy because no need to restore everytime a source code changes
#and so it can uses cached dependencies.
COPY . .

# Switch to API project directory
WORKDIR /src/ProjectManagement_API.API

RUN dotnet publish "ProjectManagement_API.API.csproj" \
                    -c Release \
                    -o /app/publish
                   

#stage2: create the runtime image. this is main part to build image which uses some files from above.
#because it no need sdk, it just need run time.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

#configure HTTP port.Thiss configures ASP.NET Core to listen on HTTP port 8080
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

#copy the published application from build stage
COPY --from=build /app/publish .

USER app

#ENTRYPOINT is the command that starts your API when the container runs.
ENTRYPOINT ["dotnet", "ProjectManagement_API.API.dll"]

