FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:9.0
WORKDIR /app
COPY --from=build /app/out .
COPY . ./

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Create startup script
RUN echo '#!/bin/bash\ndotnet ef database update\ndotnet Api.dll' > /app/start.sh
RUN chmod +x /app/start.sh

ENTRYPOINT ["/app/start.sh"]