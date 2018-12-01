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

        public ControllerTestsBase()
        {
            Options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            Logger = new Mock<ILogger<T>>().Object;
        }
    }
}