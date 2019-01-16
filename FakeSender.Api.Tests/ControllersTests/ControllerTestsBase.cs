using System;
using FakeSender.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace FakeSender.Api.Tests.ControllersTests
{
    public class ControllerTestsBase<T>
    {
        protected readonly DbContextOptions<ApplicationContext> Options;
        protected readonly ILogger<T> Logger;

        public ControllerTestsBase(String databaseName)
        {
            Options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;
            Logger = new Mock<ILogger<T>>().Object;
        }
    }
}