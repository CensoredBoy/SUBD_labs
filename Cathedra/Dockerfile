FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore 

COPY . ./

RUN dotnet publish ./Cathedra.csproj -c Release -o /publish
RUN dotnet test

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

COPY --from=build /publish .

ENTRYPOINT ["dotnet", "Cathedra.dll"]
