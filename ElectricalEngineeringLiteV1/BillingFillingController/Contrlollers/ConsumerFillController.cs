using System;
using BillingFillingController.Calculators;
using CoreV01.Feeder;

namespace BillingFillingController.Contrlollers {
    public class ConsumerFillController {
        private ConsumerCalculator _calculator;

        public ConsumerFillController(ConsumerCalculator calculator) {
            _calculator = calculator;
        }

        public void FillConsumerFields(BaseConsumer сonsumer) {
            if (сonsumer.TypeGroundingSystem.Contains("TN")) {
                сonsumer.PhaseNumber = PhaseNumber(сonsumer.Voltage);
                сonsumer.UsageFactor = 0.33;
                сonsumer.TanPowerFactor = _calculator.GetTanPowerFactor(сonsumer.PowerFactor);
                сonsumer.RatedPowerSquared = _calculator.GetRatedPowerSquared(сonsumer.RatedElectricPower);
                сonsumer.ReactivePower = _calculator.GetReactivePower(сonsumer);
                сonsumer.RatedCurrent = _calculator.GetRatedCurrent(сonsumer);
                сonsumer.StartingCurrent = _calculator.StartingCurrent(сonsumer);
            }

            throw new FormatException("Не рализована система заземления IT");
        }

        private int PhaseNumber(double сonsumerVoltage) {
            return сonsumerVoltage < 380 ? 1 : 3;
        }
    }
}