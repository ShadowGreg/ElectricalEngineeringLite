﻿using System;
using System.Collections.Generic;
using BillingFillingController.Contrlollers;
using BillingFillingController.Contrlollers.BusBars;
using CoreV01.Feeder;
using NUnit.Framework;

namespace BackendTests {
    public class BusbarFillControllerTests {
        private List<BaseConsumer> _consumers;
        private ConsumerFillController _consumerFillController;

        [SetUp]
        public void Setup() {
            _consumers = new List<BaseConsumer>() {
                new BaseConsumer() {
                    TechnologicalNumber = "MXW-250-13C",
                    MechanismName = "насос технологический",
                    RatedElectricPower = 3.5,
                    PowerFactor = 0.85,
                    Voltage = 230,
                    HoursWorkedPerYear = 8700,
                    LocationEquipmentInstallation = "102",
                    StartingCurrentMultiplicity = 1
                },
                new BaseConsumer() {
                    TechnologicalNumber = "MXW-250-13A",
                    MechanismName = "насос технологический",
                    RatedElectricPower = 13.5,
                    PowerFactor = 0.85,
                    Voltage = 400,
                    HoursWorkedPerYear = 8700,
                    LocationEquipmentInstallation = "102",
                    StartingCurrentMultiplicity = 1
                },
                new BaseConsumer() {
                    TechnologicalNumber = "MXW-250-13D",
                    MechanismName = "насос технологический",
                    RatedElectricPower = 1.5,
                    PowerFactor = 0.85,
                    Voltage = 400,
                    HoursWorkedPerYear = 8700,
                    LocationEquipmentInstallation = "102",
                    StartingCurrentMultiplicity = 1
                },
                new BaseConsumer() {
                    TechnologicalNumber = "MXW-250-13D",
                    MechanismName = "насос технологический",
                    RatedElectricPower = 30.5,
                    PowerFactor = 0.85,
                    Voltage = 400,
                    HoursWorkedPerYear = 8700,
                    LocationEquipmentInstallation = "102",
                    StartingCurrentMultiplicity = 1
                }
            };
            _consumerFillController = new ConsumerFillController();
            foreach (var consumer in _consumers) {
                _consumerFillController.FillConsumerFields(consumer);
            }
        }

        [Test]
        public void Checking_The_Functionality_Of_Adding_One_At_A_Time_Test() {
            // Arrange
            const double voltage = 400;
            BusbarFillController busbarFillController = new BusbarFillController(voltage);

            // Act
            foreach (var consumer in _consumers) {
                busbarFillController.AddConsumerOnBus(consumer);
            }

            var fillingBusBar = busbarFillController.GetBusbar();

            // Assert
            Assert.NotNull(fillingBusBar);
        }

        [Test]
        public void Loading_The_Consumer_Data_Sheet_Test() {
            // Arrange
            const double voltage = 400;
            BusbarFillController busbarFillController = new BusbarFillController(voltage);

            // Act
            busbarFillController.AddConsumersListOnBus(_consumers);
            var fillingBusBar = busbarFillController.GetBusbar();

            // Assert
            Assert.NotNull(fillingBusBar);
        }

        [Test]
        public void Checking_The_Relevance_Of_The_Calculation_Test() {
            // Arrange
            BaseConsumer testConsumer = new BaseConsumer() {
                TechnologicalNumber = "MXW-250-13C",
                MechanismName = "насос технологический",
                RatedElectricPower = 3.5,
                PowerFactor = 0.85,
                Voltage = 400,
                HoursWorkedPerYear = 8700,
                LocationEquipmentInstallation = "102",
                StartingCurrentMultiplicity = 1
            };
            _consumerFillController.FillConsumerFields(testConsumer);
            const double voltage = 400;
            BusbarFillController busbarFillController = new BusbarFillController(voltage);

            // Act
            for (int i = 0; i < 10; i++) {
                busbarFillController.AddConsumerOnBus(testConsumer);
            }

            var fillingBusBar = busbarFillController.GetBusbar();

            // Assert
            throw new NotImplementedException("Пока не проверены расчёты");
            Assert.NotNull(fillingBusBar);
            
        }
    }
}