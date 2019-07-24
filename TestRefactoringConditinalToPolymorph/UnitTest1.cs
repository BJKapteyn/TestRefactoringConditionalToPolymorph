using System;
using Xunit;
using TestRefactoringConditinalToPolymorph;
using System.Collections.Generic;
using System.Collections;

namespace TestRefactoringConditinalToPolymorph
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string tester = "Hello";
            Person p = new Person();

            Assert.Equal(tester, SayWhat(p));
        }
        public static Person person = new Person();
        [Theory]
        [ClassData(typeof(TestData))]
        public void Test2(Animal user, string expected)
        {
            Assert.Equal(expected, SayWhat(user));
        }

        public string SayWhat(Animal a)
        {
            return a.Talk();
        }
    }
    public class Users
    {
        public static Person person = new Person();
        public static Cat cat = new Cat();
        public static Dog dog = new Dog();
    }

    public class TestData : IEnumerable<object[]>
    {
       public IEnumerator<object[]> GetEnumerator()
        {
        yield return new object[] { new Person() , "Hello"};
        yield return new object[] { new Dog() , "Bark"};
        yield return new object[] { new Cat() , "Meow" };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class Animal
    {

        public string Name { get; set; }
        public string Says { get; set; }
        public string Talk()
        {
            return Says;
        }
    }
    public class Person : Animal
    {
        public Person ()
        {
            Name = "Human";
            Says = "Hello";
        }
    }
    public class Dog : Animal
    {
        public Dog()
        {
            Name = "Dog";
            Says = "Bark";
        }
    }
    public class Cat : Animal
    {
        public Cat()
        {
            Name = "Cat";
            Says = "Meow";
        }
    }
}
