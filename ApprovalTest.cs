using ApprovalTests;
using System;
using System.IO;
using System.Text;
using ApprovalTests.Reporters;
using Xunit;

namespace csharp
{
    public class ApprovalTest
    {
        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void ThirtyDays()
        {
            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            String output = fakeoutput.ToString();
            Approvals.Verify(output);
        }
    }
}
