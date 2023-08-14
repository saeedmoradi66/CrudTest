using NUnit.Framework;

using static Mc2.CrudTest.AcceptanceTests.Testing;

namespace Mc2.CrudTest.AcceptanceTests;
[TestFixture]
public abstract class BaseTestFixture
{
    [SetUp]
    public async Task TestSetUp()
    {
        await ResetState();
    }
}
