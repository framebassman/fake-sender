FROM microsoft/dotnet:2.2-sdk AS build-env
COPY ./FakeSender.Api /app
WORKDIR /app
RUN dotnet clean
RUN dotnet restore
RUN dotnet ef database update
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2.0-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT dotnet FakeSender.Api.dll
