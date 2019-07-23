using System;
using Xunit;

namespace TestRefactoringConditinalToPolymorph
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string tester = "Hello";

            Assert.Equal(tester, GetName("Person"));
        }

        [Theory]
        [InlineData("Person", "Hello")]
        [InlineData("Dog", "Bark")]
        [InlineData("Cat", "Meow")]
        [InlineData("stsdfse", "Error")]
        public void Test2(string user, string expected)
        {
            Assert.Equal(GetName(user), expected);
        }

        public string GetName(string whoIsIt)
        {
            switch(whoIsIt)
            {
                case "Person":
                    return "Hello";
                case "Dog":
                    return "Bark";
                case "Cat":
                    return "Meow";
                default:
                    return "Error";
            }
        }
    }
}
