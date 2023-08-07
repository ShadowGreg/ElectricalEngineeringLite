﻿using System.Collections.Generic;
using BillingFillingController.Contrlollers.ElectricalPanel;
using CoreV01.Feeder;
using ElectricalEngineeringLiteV1.View.CenterFrame.DistributionNetworkTable;
using NUnit.Framework;

namespace BackendTests {
    [TestFixture]
    public class NodeTests {
        private List<BaseConsumer> _consumers;
        private ElectricalPanelFillController _electricalPanelFillController;

        [SetUp]
        public void Setup() {
            _electricalPanelFillController = new ElectricalPanelFillController();
        }

        [Test]
        public void ElectricalPanelFillController_Test() {
            // Arrange
            _electricalPanelFillController.AddOnPanel(new List<BaseConsumer> {
                new BaseConsumer()
            });

            // Act
            Node node = new Node(_electricalPanelFillController.GetPanel());

            // Assert
            Assert.NotNull(node);
        }
    }
}