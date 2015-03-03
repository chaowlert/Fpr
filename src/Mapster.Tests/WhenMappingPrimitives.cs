﻿using System;
using System.Text;
using Mapster.Adapters;
using NUnit.Framework;
using Should;

namespace Mapster.Tests
{
    [TestFixture]
    public class WhenMappingPrimitives
    {
        [Test]
        public void Integer_Is_Mapped_To_Byte()
        {
            byte b = PrimitiveAdapter<int, byte>.Adapt(5);

            Assert.IsTrue(b == 5);
        }

        [Test]
        public void Byte_Array_Is_Mapped_Correctly()
        {
            string testString = "this is a string that will later be converted to a byte array and other text blah blah blah I'm not sure what else to put here...";

            byte[] array = Encoding.ASCII.GetBytes(testString);

            var resultArray = TypeAdapter.Adapt<byte[], byte[]>(array);

            var resultString = Encoding.ASCII.GetString(resultArray);

            testString.ShouldEqual(resultString);
        }

        [Test]
        public void Byte_Array_In_Test_Class_Is_Mapped_Correctly()
        {
            string testString = "this is a string that will later be converted to a byte array and other text blah blah blah I'm not sure what else to put here...";

            var testA = new TestA{Bytes = Encoding.ASCII.GetBytes(testString)};

            var testB = TypeAdapter.Adapt<TestA, TestB>(testA);

            var resultString = Encoding.ASCII.GetString(testB.Bytes);

            testString.ShouldEqual(resultString);
        }


        public class TestA
        {
            public Byte[] Bytes { get; set; }
        }

        public class TestB
        {
            public Byte[] Bytes { get; set; }
        }
    }
}
