using System.Collections.Generic;
using BillingFillingController.Contrlollers.ElectricalPanel;
using CoreV01.Feeder;
using NUnit.Framework;

namespace BackendTests.Properties {
    [TestFixture]
    public class CalculationsTests {
        private List<BaseConsumer> _consumers;
        private ElectricalPanelFillController _electricalPanelFillController;

        [SetUp]
        public void Setup() {
            _electricalPanelFillController = new ElectricalPanelFillController();
        }

        [Test]
        public void Basic_Calculations_For_Asingle_Electrical_Receiver_Test() {
            // Arrange
            _electricalPanelFillController.AddOnPanel(new List<BaseConsumer> {
                new BaseConsumer() {
                    TechnologicalNumber = "030-Р-008A",
                    MechanismName = "Насос Xylem, LOWARA",
                    RatedElectricPower = 10,
                    UsageFactor = 0.85,
                    PowerFactor = 0.93,
                    Voltage = 400,
                    HoursWorkedPerYear = 8700,
                    LocationEquipmentInstallation = "102",
                    StartingCurrentMultiplicity = 11
                },
            });
            object expectedPanel = null;

            // Act
            var actualPanel = _electricalPanelFillController.GetPanel();

            // Assert
            Assert.AreEqual(actualPanel, expectedPanel);
        }
    }
}