FROM microsoft/dotnet:2.1-sdk

COPY ./FakeSender.Api /app

WORKDIR /app

RUN ["dotnet", "restore"]

RUN ["dotnet", "build"]

ENTRYPOINT ["dotnet", "run"]

CMD ["-c", "Release"]
