namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void Ctor_SetsPropertiesCorrectly()
        {
            // Arrange
            int memoryCapacity = 64;

            // Act
            var device = new Device(memoryCapacity);

            // Assert
            Assert.AreEqual(memoryCapacity, device.MemoryCapacity);
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.IsEmpty(device.Applications);
        }

        [Test]
        public void TakePhoto_WithEnoughAvailableMemory_SholdWork()
        {
            // Arrange
            int memoryCapacity = 64;
            var device = new Device(memoryCapacity);
            int photoSize = 10;

            // Act
            bool result = device.TakePhoto(photoSize);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(memoryCapacity - photoSize, device.AvailableMemory);
            Assert.AreEqual(1, device.Photos);
        }

        [Test]
        public void TakePhoto_WithoutEnoughAvailableMemory_ReturnsFalse()
        {
            // Arrange
            int memoryCapacity = 64;
            var device = new Device(memoryCapacity);
            int photoSize = 100;

            // Act
            bool result = device.TakePhoto(photoSize);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
        }

        [Test]
        public void InstallApp_WorksAndReturnsSuccessMessage()
        {
            // Arrange
            int memoryCapacity = 64;
            var device = new Device(memoryCapacity);
            string appName = "SoftUni";
            int appSize = 10;

            // Act
            string result = device.InstallApp(appName, appSize);

            // Assert
            Assert.AreEqual($"{appName} is installed successfully. Run application?", result);
            Assert.AreEqual(memoryCapacity - appSize, device.AvailableMemory);
            Assert.Contains(appName, device.Applications);
        }

        [Test]
        public void InstallApp_ThrowsException()
        {
            // Arrange
            int memoryCapacity = 64;
            var device = new Device(memoryCapacity);
            string appName = "TestApp";
            int appSize = 100;

            // Act & Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => device.InstallApp(appName, appSize));
            Assert.AreEqual("Not enough available memory to install the app.", exception.Message);
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.IsEmpty(device.Applications);
        }

        [Test]
        public void FormatDevice_ShouldWork()
        {
            // Arrange
            int memoryCapacity = 64;
            var device = new Device(memoryCapacity);
            device.TakePhoto(10);
            device.InstallApp("TestApp", 20);

            // Act
            device.FormatDevice();

            // Assert
            Assert.AreEqual(0, device.Photos);
            Assert.IsEmpty(device.Applications);
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
        }

        [Test]
        public void GetDeviceStatus_ReturnsCorrectStatusString()
        {
            // Arrange
            int memoryCapacity = 64;
            var device = new Device(memoryCapacity);
            device.TakePhoto(10);
            device.InstallApp("SoftUni", 20);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Memory Capacity: {memoryCapacity} MB, Available Memory: {memoryCapacity - 10 - 20} MB");
            sb.AppendLine($"Photos Count: 1");
            sb.AppendLine($"Applications Installed: SoftUni");

            string expectedStatus = sb.ToString().TrimEnd();

            // Act
            string actualStatus = device.GetDeviceStatus();

            // Assert
            Assert.AreEqual(expectedStatus, actualStatus);
        }

    }
}