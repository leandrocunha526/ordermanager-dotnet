# Use .NET SDK for build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build-env
WORKDIR /app
EXPOSE 80

# Copy everything
COPY . ./

# Restore as distinct layers
RUN dotnet restore

# Build and publish a release
RUN dotnet publish -c Release -o out

# Use ASP.NET Core runtime for runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0

# Install Kerberos/GSSAPI native dependency
RUN apt-get update \
    && apt-get install -y --no-install-recommends libgssapi-krb5-2 \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app

COPY --from=build-env /app/out .

# Entrypoint for the application
ENTRYPOINT ["dotnet", "ordermanager-dotnet.dll"]
