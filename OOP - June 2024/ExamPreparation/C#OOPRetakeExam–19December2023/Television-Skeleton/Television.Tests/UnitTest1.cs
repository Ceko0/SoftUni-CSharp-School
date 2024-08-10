using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    public class Tests
    {
        private TelevisionDevice television;
        private string brand;
        private double price;
        private int screenWidth;
        private int screenHeigth;
        private int lastChannel = 0;
        private int lastVolume = 13;
        private bool lastMuted = false;

        [SetUp]
        public void Setup()
        {
            brand = Random.Shared.Next().ToString();
            price = Random.Shared.NextDouble();
            screenWidth = Random.Shared.Next();
            screenHeigth = Random.Shared.Next();
            television = new(brand,price,screenWidth,screenHeigth);
        }

        [Test]
        public void ConstructorWorkCorrectly()
        {
            Assert.That(television.Brand, Is.EqualTo(brand));
            Assert.That(television.Price, Is.EqualTo(price));
            Assert.That(television.ScreenWidth, Is.EqualTo(screenWidth));
            Assert.That(television.ScreenHeigth, Is.EqualTo(screenHeigth));
            Assert.That(television.CurrentChannel, Is.EqualTo(lastChannel));
            Assert.That(television.Volume, Is.EqualTo(lastVolume));
            Assert.That(television.IsMuted, Is.EqualTo(lastMuted));
        }

        [Test]
        public void SwitchOnWorkCorrectly()
        {
            Assert.That($"Cahnnel {lastChannel} - Volume {lastVolume} - Sound On", Is.EqualTo(television.SwitchOn()));
        }

        [Test]
        public void ChangeChannelThrowIfChanelIsNegative()
        {
            Assert.Throws<ArgumentException>(() => television.ChangeChannel(-1));
        }
        [Test]
        public void ChangeChannelWorkCorrectly()
        {
            int chanel = Random.Shared.Next();
            Assert.That(chanel, Is.EqualTo(television.ChangeChannel(chanel)));
        }

        [Test]
        public void VolumeChangeDontReturnMoreThenMaxVolume()
        {
            int maxVolume = 100;
            Assert.That($"Volume: {maxVolume}", Is.EqualTo(television.VolumeChange("UP" , maxVolume +10)));
        }
        [Test]
        public void VolumeChangeDontReturnLessThenMinVolume()
        {
            int minVolume = 0;
            Assert.That($"Volume: {minVolume}", Is.EqualTo(television.VolumeChange("DOWN",  100)));
        }

        [Test]
        public void MuteDeviceWorkCorrectly()
        {
            Assert.IsTrue(television.MuteDevice());
        }

        [Test]
        public void ToStringOverrideWorkCorrectly()
        {
            Assert.That($"TV Device: {brand}, Screen Resolution: {screenWidth}x{screenHeigth}, Price {price}$", Is.EqualTo(television.ToString()));
        }
    }
}