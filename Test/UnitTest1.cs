using System;
using System.Net;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public async void GetServiceTest()
        {
            var client = new TestClientProvider().Client;

            var okResult = await client.GetAsync("api/Contacts");

            okResult.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, okResult.StatusCode);
        }
    }
}
