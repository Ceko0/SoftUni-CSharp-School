using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private InfluencerRepository repository;
        private Influencer influencer;
        private string username;
        private int followers;

        [SetUp]
        public void Setup()
        {
            repository = new();
            username = Random.Shared.Next().ToString();
            followers = Random.Shared.Next();
            influencer = new(username, followers);
        }

        [Test]
        public void InfluencerConstructorWorkCorrect()
        {
            repository = new();
            username = Random.Shared.Next().ToString();
            followers = Random.Shared.Next();
            Influencer influencer = new(username, followers);
            Assert.That(influencer.Username, Is.EqualTo(username));
            Assert.That(influencer.Followers, Is.EqualTo(followers));
        }

        [Test]
        public void RepositoryConstructorWorkCorrectly()
        {
            InfluencerRepository repository = new();
            Assert.IsEmpty(repository.Influencers);
        }

        [Test]
        public void RepositoryRegisterInfluencerWorkCorrectly()
        {
            Assert.That($"Successfully added influencer {username} with {followers}", Is.EqualTo(repository.RegisterInfluencer(influencer)));
            Assert.That(repository.Influencers.Count, Is.EqualTo(1));
        }

        [Test]
        public void RepositoryRegisterInfluencerThrowIfInfluencerIsNull()
        {
            influencer = null;
            Assert.Throws<ArgumentNullException>(() => repository.RegisterInfluencer(influencer));
        }

        [Test]
        public void RepositoryRegisterInfluencerThrowIfInfluencerIsInCollection()
        {
            repository.RegisterInfluencer(influencer);
            Assert.Throws<InvalidOperationException>(() => repository.RegisterInfluencer(influencer));
        }

        [Test]
        public void RepositoryRemoveInfluencerThrowIfInfluencerNameIsNull()
        {
            string name = null;
            Assert.Throws<ArgumentNullException>(() => repository.RemoveInfluencer(name));
        }

        [Test]
        public void RepositoryRemoveInfluencerWorkCorrectly()
        {
            Influencer influencer2 = new("a", 23);
            repository.RegisterInfluencer(influencer);
            repository.RegisterInfluencer(influencer2);

            Assert.IsTrue(repository.RemoveInfluencer("a"));
            Assert.That(repository.Influencers.Count, Is.EqualTo(1));
        }

        [Test]
        public void RepositoryGetInfluencerWithMostFollowersWorkCorrectly()
        {
            Influencer influencer1 = new("a", 11);
            Influencer influencer2 = new("b", 23);
            Influencer influencer3 = new("c", 33);
            repository.RegisterInfluencer(influencer1); repository.RegisterInfluencer(influencer2); repository.RegisterInfluencer(influencer3);
            Influencer influencer4 = repository.GetInfluencerWithMostFollowers();
            Assert.That(influencer4.Username, Is.EqualTo(influencer3.Username));
            Assert.That(influencer3, Is.SameAs(repository.GetInfluencerWithMostFollowers()));
        }
        [Test]
        public void RepositoryGetInfluencerWorkCorrectly()
        {
            Influencer influencer1 = new("a", 11);
            Influencer influencer2 = new("b", 23);
            Influencer influencer3 = new("c", 33);
            repository.RegisterInfluencer(influencer1); repository.RegisterInfluencer(influencer2); repository.RegisterInfluencer(influencer3);
            Influencer influencer4 = repository.GetInfluencer("c");
            Assert.That(influencer4.Username, Is.EqualTo(influencer3.Username));
            Assert.That(influencer3, Is.SameAs(repository.GetInfluencer("c")));
        }
    }
}