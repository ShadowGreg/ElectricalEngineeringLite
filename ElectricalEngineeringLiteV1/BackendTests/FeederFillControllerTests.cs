using System.Collections.Generic;
using BillingFillingController.Contrlollers;
using CoreV01.Feeder;
using NUnit.Framework;

namespace BackendTests {
    [TestFixture]
    public class FeederFillControllerTests {
        private List<BaseConsumer> _consumers;
        private ConsumerFillController _consumerFillController;

        [SetUp]
        public void Setup() {
            _consumers = new DataBase.DataBase().GetConsumers();
            _consumerFillController = new ConsumerFillController();
            foreach (var consumer in _consumers) {
                _consumerFillController.FillConsumerFields(consumer);
            }
        }

        [Test]
        public void FeederFillController_Test() {
            // Arrange
            FeederFillController controller = new FeederFillController(_consumers[0]);

            // Act
            var feeder = controller.GetFeeder(20, 1, 2.3);

            // Assert
            Assert.NotNull(feeder);
        }
    }
}