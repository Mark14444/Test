
using Microsoft.EntityFrameworkCore;
using Test.Domain.Context;

namespace Test.UnitTest.Base
{
    internal static class ContextGenerator
    {
        internal static TestContext GetContext()
        {
            var contextOptions = new DbContextOptionsBuilder<TestContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            return new TestContext(contextOptions);
        }
    }
}
