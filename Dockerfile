FROM microsoft/dotnet:2.2.100-preview2-sdk AS build-env
COPY ./FakeSender.Api /app
WORKDIR /app
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT dotnet FakeSender.Api.dll

