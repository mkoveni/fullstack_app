FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /app 

COPY *.sln .
COPY Api/*.csproj ./Api/
COPY Core/*.csproj ./Core/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY Tests/*.csproj ./Tests/ 

RUN dotnet restore 

COPY Api/. ./Api/
COPY Core/. ./Core/
COPY Infrastructure/. ./Infrastructure/ 

WORKDIR /app/Api
RUN dotnet publish -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app 

EXPOSE 80

COPY --from=build /app/Api/out ./
ENTRYPOINT ["dotnet", "Api.dll"]