FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

##Working file di dalam container, bukan di file system milik kita
WORKDIR /app
EXPOSE 8080

# copy .csproj and restore as distinct layers
##Formatnya : COPY [SOURCE] [DESTINATION]
COPY "reactivities.sln" "reactivities.sln"
COPY "API/API.csproj" "API/API.csproj"
COPY "Application/Application.csproj" "Application/Application.csproj"
COPY "Persistence/Persistence.csproj" "Persistence/Persistence.csproj"
COPY "Domain/Domain.csproj" "Domain/Domain.csproj"
COPY "Infrastructure/Infrastructure.csproj" "Infrastructure/Infrastructure.csproj"

RUN dotnet restore "reactivities.sln"

# copy everything else build
COPY . .
WORKDIR /app
RUN dotnet publish -c Release -o out

# build a runtime image
##Tidak menggunakan versi full dotnet/sdk, tapi versi runtime-nya saja
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "API.dll" ]
