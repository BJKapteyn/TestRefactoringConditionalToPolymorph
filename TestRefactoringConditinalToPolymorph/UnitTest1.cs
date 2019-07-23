using System;
using Xunit;
using TestRefactoringConditinalToPolymorph;
using System.Collections.Generic;

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
        [ClassData(typeof(Animal))]
        [ClassData(typeof(Person))]
        [ClassData(typeof(Dog))]
        [ClassData(typeof(Cat))]
        [InlineData(person, "Hello")]
        [InlineData(new Dog() d, "Bark")]
        [InlineData(new Cat(), "Meow")]
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

    public class Animal : IEnumerable<object[]>
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
