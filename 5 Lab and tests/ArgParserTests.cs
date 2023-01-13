using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class ArgParserTests
    {
        [TestMethod()]
        public void StoreValueTest()
        {
            string? value = null;
            string? value2 = null;
            ArgParser parser = new ArgParser("dadasdasd");
            parser.Parse(parser.SplitString("app --param1=value1 --param2=value2"));
            parser.AddStringArgument("param1").StoreValue(ref value);
            parser.AddStringArgument("param2").StoreValue(ref value2);
            Assert.AreEqual("value1", value);
            Assert.AreEqual("value2", value2);

        }
        [TestMethod()]
        public void StringTest()
        {
            ArgParser parser = new ArgParser("dadasdasd");
            parser.Parse(parser.SplitString("app --param1=value1"));
            Assert.AreEqual("value1", parser.GetStringValue("param1"));   //expected/actuall
        }

        [TestMethod()]

        public void DefaultTest()
        {
            ArgParser parser = new ArgParser("dadasdasd");
            parser.Parse(parser.SplitString("app"));
            parser.AddStringArgument("param1").Default("value1");
            parser.AddStringArgument("param2").Default("value2");
            Assert.AreEqual("value1", parser.GetStringValue("param1"));
            Assert.AreEqual("value2", parser.GetStringValue("param2"));
        }


        [TestMethod()]
        public void MultiStringTest()
        {
            ArgParser parser = new ArgParser("dadasdasd");
            string? value = null;
            parser.Parse(parser.SplitString("app --param1=value1 --param2=value2"));
            parser.AddStringArgument("param1").StoreValue(ref value);
            parser.AddStringArgument("param2");
            Assert.AreEqual("value2", parser.GetStringValue("param2"));
            Assert.AreEqual("value1", parser.GetStringValue("param1"));
            Assert.AreEqual(value, parser.GetStringValue("param1"));
        }
        [TestMethod()]

        public void IntTest()
        {
            ArgParser parser = new ArgParser("dadasdasd");
            parser.Parse(parser.SplitString("app --param1=100500"));
            parser.AddIntArgument("param1");
            //Assert.AreEqual()

        }
        [TestMethod()]

        public void MultiValueTest()
        {
            List<int> ints = new List<int>();
            ArgParser parser = new ArgParser("dadasdasd");
            parser.Parse(parser.SplitString("app --param1=1 --param1=2 --param1=3"));
            parser.AddIntArgument("param1");
            int x = 10;
        }
    }
}