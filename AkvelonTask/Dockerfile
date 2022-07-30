FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AkvelonTask/AkvelonTask.csproj", "AkvelonTask/AkvelonTask.csproj"]
RUN dotnet restore "AkvelonTask/AkvelonTask.csproj"
COPY . .
WORKDIR "/src/AkvelonTask"
RUN dotnet build "AkvelonTask.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AkvelonTask.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AkvelonTask.dll"]