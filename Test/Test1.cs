using ERPSys;
using Microsoft.Data.SqlClient;

namespace Test
{
    public class Test1
    {
        Person person = new();
        [Fact]
        public void userFullName()
        {
            string fornavn = "Unit";
            string efternavn = "Test";

            person.Fornavn = fornavn;
            person.Efternavn = efternavn;
            string fullname = person.Fullname();

            Assert.Equal("Unit Test",fullname);
            Assert.NotEqual("UnitTest", fullname);
            Assert.NotNull(fullname);
        }

        [Fact]
        public void Test()
        {

        }
    }
}