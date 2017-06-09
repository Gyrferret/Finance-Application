using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finance_Application;

namespace TestSuite.Tests
// needed to add the nuget package for Microsoft.UnitTestFramework.Extensions in order for the namespace
// Microsoft.VisualStudio.TestTools.UnitTesting to work; 
{
    [TestClass]
    class WhenProgramRuns
    {

        private string _consoleOutput;

        [TestInitialize]

        public void Initialize()
        {
            var w = new System.IO.StringWriter();
            Console.SetOut(w);

            Program.Main(new string[0]);

            _consoleOutput = w.GetStringBuilder().ToString().Trim();
        }

        [TestMethod]
        public void SaysHelloWorld()
        {
            Assert.AreEqual("Hello, world!", _consoleOutput);
        }
    }
}
