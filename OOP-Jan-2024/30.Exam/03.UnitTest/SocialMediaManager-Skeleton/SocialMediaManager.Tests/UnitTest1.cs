using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void Influencer_Ctor_WithValidArguments()
        {
            string username = "Pesho";
            int followers = 1000;

            Influencer influencer = new Influencer(username, followers);

            Assert.AreEqual(username, influencer.Username);
            Assert.AreEqual(followers, influencer.Followers);
        }

        [Test]
        public void InfluencerRepository_Ctor_ShouldInitializeDataList()
        {
            var repository = new InfluencerRepository();

            Assert.IsNotNull(repository.Influencers);
            Assert.AreEqual(0, repository.Influencers.Count);
        }

        [Test]
        public void InfluencerRepository_Influencers_ShouldReturnReadOnlyCollection()
        {
            var repository = new InfluencerRepository();

            var influencers = repository.Influencers;

            Assert.IsNotNull(influencers);
            Assert.IsInstanceOf<IReadOnlyCollection<Influencer>>(influencers);
        }

        [Test]
        public void RegisterInfluencerMethod_WhenIsNull_ShouldThrowException()
        {
            var repository = new InfluencerRepository();

            Assert.Throws<ArgumentNullException>(() => repository.RegisterInfluencer(null));
        }

        [Test]
        public void RegisterInfluencerMethod_WhenInfluencerExists_ShouldThrowException()
        {
            var repository = new InfluencerRepository();
            var influencer = new Influencer("Pesho", 1000);
            repository.RegisterInfluencer(influencer);

            Assert.Throws<InvalidOperationException>(() => repository.RegisterInfluencer(influencer));
        }

        [Test]
        public void RegisterInfluencerMethod_ShouldWorkProperly()
        {
            var repository = new InfluencerRepository();
            var influencer = new Influencer("Pesho", 1000);

            var result = repository.RegisterInfluencer(influencer);


            Assert.AreEqual($"Successfully added influencer {influencer.Username} with {influencer.Followers}", result);
        }

        [Test]
        public void RemoveInfluencerMethod_ShouldReturnTrue()
        {
            var repository = new InfluencerRepository();
            var influencer = new Influencer("Pesho", 1000);
            repository.RegisterInfluencer(influencer);
 
            var result = repository.RemoveInfluencer("Pesho");

            Assert.IsTrue(result);
        }

        //[TestCase("Pesho")]
        //[TestCase("Gosho")]
        //[TestCase("Dimitrichko")]
        [Test]
        public void GetInfluencerWithMostFollowers_ShouldWorkProperly()
        {
            var repository = new InfluencerRepository();
            var influencer1 = new Influencer("Pesho", 500);
            var influencer2 = new Influencer("Gosho", 1000);
            var influencer3 = new Influencer("Dimitrichko", 700);
            repository.RegisterInfluencer(influencer1);
            repository.RegisterInfluencer(influencer2);
            repository.RegisterInfluencer(influencer3);

            var result = repository.GetInfluencerWithMostFollowers();

            Assert.AreEqual(influencer2, result);
        }

        [Test]
        public void GetInfluencer_ShouldWorkProperly()
        {
            var repository = new InfluencerRepository();
            var influencer = new Influencer("Pesho", 1000);
            repository.RegisterInfluencer(influencer);

            var result = repository.GetInfluencer("Pesho");

            Assert.AreEqual(influencer, result);
        }

    }
}