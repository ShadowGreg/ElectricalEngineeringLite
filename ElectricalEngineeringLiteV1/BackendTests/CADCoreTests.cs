using System.Collections.Generic;
using BillingFillingController.Contrlollers.ElectricalPanel;
using CADCore;
using CoreV01.Feeder;
using netDxf;
using NUnit.Framework;

namespace BackendTests {
    [TestFixture]
    public class CADCoreTests {
        private Class1 _class1;

        [SetUp]
        public void Setup() {
            _class1 = new Class1();
        }

        [Test]
        public void ElectricalPanelFillController_Test() {
            // Arrange


            // Act
            _class1.DrawDiagramFrame(new Vector2(0, 0));

            // Assert
        }

        [Test]
        public void DrawIntroductoryUnit_Test() {
            // Arrange
            ElectricalPanelFillController electricalPanelFillController = new ElectricalPanelFillController();
            BaseConsumer consumer = new BaseConsumer();

            // Act
            electricalPanelFillController.AddOnPanel(new List<BaseConsumer>() { consumer });
            var circuitBreaker = electricalPanelFillController.GetPanel().BusBars[0].InputSwitch;
            var electricalPanel = electricalPanelFillController.GetPanel();
            _class1.DrawIntroductoryUnit(new Vector2(0, 0), circuitBreaker, electricalPanel);

            // Assert
        }
        
        [Test]
        public void DrawIntroductoryUnit_With_Distance_Test() {
            // Arrange
            ElectricalPanelFillController electricalPanelFillController = new ElectricalPanelFillController();
            BaseConsumer consumer = new BaseConsumer();

            // Act
            electricalPanelFillController.AddOnPanel(new List<BaseConsumer>() { consumer });
            var circuitBreaker = electricalPanelFillController.GetPanel().BusBars[0].InputSwitch;
            var electricalPanel = electricalPanelFillController.GetPanel();
            _class1.DrawIntroductoryUnit(new Vector2(150, -300), circuitBreaker, electricalPanel);

            // Assert
        }
    }
}