﻿using System.Linq;
using NUnit.Framework;
using IntervalTree;

namespace IntervalTreeTests
{
    [TestFixture]
    public class ReadmeExampleTests
    {
        [Test]
        public void Query_CreateTreeAndExecuteQuery_ExpectCorrectElementsToBeReturned()
        {
            var tree = new IntervalTree<int, string>()
            {
                { 0, 10, "1" },
                { 20, 30, "2" },
                { 15, 17, "3" },
                { 25, 35, "4" },
            };

            var results1 = tree.Query(5).ToArray();
            Assert.That(results1.Count, Is.EqualTo(1));
            Assert.That(results1[0].Value, Is.EqualTo("1"));

            var results2 = tree.Query(10).ToArray();
            Assert.That(results2.Count, Is.EqualTo(1));
            Assert.That(results2[0].Value, Is.EqualTo("1"));

            var results3 = tree.Query(29).ToArray();
            Assert.That(results3.Count, Is.EqualTo(2));
            Assert.That(results3[0].Value, Is.EqualTo("2"));
            Assert.That(results3[1].Value, Is.EqualTo("4"));

            var results4 = tree.Query(5, 15).ToArray();
            Assert.That(results4.Count, Is.EqualTo(2));
            Assert.That(results4[0].Value, Is.EqualTo("3"));
            Assert.That(results4[1].Value, Is.EqualTo("1"));
        }
    }
}
