using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using GildedRoseKata.Refactored;
using VerifyTests;
using VerifyXunit;

using Xunit;

namespace GildedRoseKata.Refactored.Tests
{
    [UsesVerify]
    public class ApprovalTest
    {
        [Fact]
        public Task ThirtyDays()
        {
            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            var output = fakeoutput.ToString();

            return Verifier.Verify(output);
        }
    }
}
