using System;
using System.Linq;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [SetUp]

        [Test]
        public void ConstructorWorkCorrect()
        {
            int id = Random.Shared.Next();
            string name = Random.Shared.Next().ToString();
            Person person = new(id, name);

            Assert.AreEqual(id ,person.Id);
            Assert.AreEqual(name , person.UserName);
        }

        [Test]
        public void DatabaseAddWorkCorrect()
        {
            for (int i = 0; i < 16; i++)
            {
                int id = Random.Shared.Next();
                string name = Random.Shared.Next().ToString();
                Person person = new(id, name);
                Database database = new();
                database.Add(person);
                Assert.AreEqual(1, database.Count);
            }
        }

        [Test]
        public void DatabaseAddThrowIfTryAddMoreTheCapacity()
        {
            Database database = new();
            int id = Random.Shared.Next(); ;
            string name = Random.Shared.Next().ToString(); ;
            Person currentPerson = new(id,name);
            for (int i = 0; i < 16; i++)
            {
                id = Random.Shared.Next();
                 name = Random.Shared.Next().ToString();
                Person person = new(id, name);
               
                database.Add(person);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(currentPerson));
        }

        [Test]
        public void DatabaseAddThrowIfTryAddBigerArray()
        {
            List<Person> personList = new();
            for (int i = 0; i < 17; i++)
            {
                int id = Random.Shared.Next();
                string name = Random.Shared.Next().ToString();
                Person person = new(id, name);
                
                personList.Add(person);
            }
            Assert.Throws<ArgumentException>(() =>  new Database(personList.ToArray()));
        }
        
        [Test]
        public void DatabaseAddTwoUserWhitSameUsername()
        {
            int id = Random.Shared.Next();
            int idTwo = Random.Shared.Next();
            string name = Random.Shared.Next().ToString();
            Person person = new(id, name);
            Database database = new(person);
            Person personTwo = new(idTwo, name);
            Assert.Throws<InvalidOperationException>(() => database.Add(personTwo));
        }
        [Test]
        public void DatabaseAddTwoUserWhitSameId()
        {
            int id = Random.Shared.Next();
            string name = Random.Shared.Next().ToString();
            string nameTwo = Random.Shared.Next().ToString();
            Person person = new(id, name);
            Database database = new();
            database.Add(person);
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(id, nameTwo)));
        }
        [Test]
        public void DatabaseRemoveWorkCorrect()  
        {
            int arrCapacity = Random.Shared.Next(0, 16);
            Person[] randomCapacity = new Person[arrCapacity];

            List<Person> toCheck = new();
            for (int i = 0; i < arrCapacity; i++)
            {
                int id = Random.Shared.Next();
                string name = Random.Shared.Next().ToString();
                Person person = new(id, name);
                randomCapacity[i] = person;
                toCheck.Add(person);
            }
            Database database = new(randomCapacity);

            for (int i = 0; i < arrCapacity -1; i++)
            {
                database.Remove();
                toCheck.RemoveAt(toCheck.Count - 1);
                Assert.AreEqual(toCheck.Count, database.Count);
                Person person = toCheck.LastOrDefault();
                int personId = (int)person.Id;
                Assert.AreSame(person , database.FindById(personId));
            }
        }

        [Test]
        public void RemoveThrowIfArrayIsEmpty()
        {
            Database database = new();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FindByUsernameWorkCorrect()
        {
            Person person = new (Random.Shared.Next(),Random.Shared.Next().ToString());
            Database database = new(person);
            Assert.AreSame(person , database.FindByUsername(person.UserName));
        }

        [Test]
        public void FindByUsernameTrowWhenNoUserIsPresent()
        {
            int id = Random.Shared.Next();
            string name = Random.Shared.Next().ToString();
            Person person = new(id, name);
            Database database = new(person);
            string username = Random.Shared.Next().ToString();
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(username));
        }

        [Test]
        public void FindByUsernameThrowWhenUsernameIsNull()
        {
            int id = Random.Shared.Next();
            string name = Random.Shared.Next().ToString();
            Person person = new(id, name);
            Database database = new(person);
            string username = null;
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username));
        }

        [Test]
        public void FindByUsernameThrowBecauseCaseSensitive()
        {
            int id = Random.Shared.Next();
            string name = Random.Shared.Next().ToString();
            Person person = new(id, name);
            Database database = new(person);
            string username = Random.Shared.Next().ToString().ToLower();
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(username.ToUpper()));
        }

        [Test]
        public void FindByUsernameThrowWhenUsernameIsEmpty()
        {
            int id = Random.Shared.Next();
            string name = Random.Shared.Next().ToString();
            Person person = new(id, name);
            Database database = new(person);
            string username = "";
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username));
        }

        [Test]
        public void FindByIdThrowIfNoUserIsPresentById()
        {

            int arrCapacity = Random.Shared.Next(0, 16);
            Person[] randomCapacity = new Person[arrCapacity];
            for (int i = 0; i < arrCapacity; i++)
            {
                int id = Random.Shared.Next(5 , 300);
                string name = Random.Shared.Next().ToString();
                Person person = new(id, name);
                randomCapacity[i] = person;
            }
            Database database = new(randomCapacity);
            Assert.Throws<InvalidOperationException>(() => database.FindById(Random.Shared.Next(1, 4)));
        }
        
        [Test]
        public void FindByIdThrowIfNegativeIdAreFound()
        {

            int arrCapacity = Random.Shared.Next(0, 16);
            Person[] randomCapacity = new Person[arrCapacity];
            for (int i = 0; i < arrCapacity; i++)
            {
                int id = Random.Shared.Next(5 , 300);
                string name = Random.Shared.Next().ToString();
                Person person = new(id, name);
                randomCapacity[i] = person;
            }
            Database database = new(randomCapacity);
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-231));
        }

        [Test]
        public void FindByIdWorkCorrect()
        {
            Person person = new(Random.Shared.Next(), Random.Shared.Next().ToString());
            Database database = new(person);
            Assert.AreSame(person, database.FindById(person.Id));
        }
    }
}