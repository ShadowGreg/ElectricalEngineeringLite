using System.Collections.Generic;
using System.Data;
using CoreV01.Feeder;

namespace BillingFillingController.Contrlollers {
    public class CircuitBreakerFillController {
        private readonly Dictionary<double, BaseCircuitBreaker> _theePolesBreakerData =
            new Dictionary<double, BaseCircuitBreaker>() {
                { 6, new BaseCircuitBreaker() { RatedCurrent = 6 } },
                { 8, new BaseCircuitBreaker() { RatedCurrent = 8 } },
                { 10, new BaseCircuitBreaker() { RatedCurrent = 10 } },
                { 13, new BaseCircuitBreaker() { RatedCurrent = 13 } },
                { 16, new BaseCircuitBreaker() { RatedCurrent = 16 } },
                { 20, new BaseCircuitBreaker() { RatedCurrent = 20 } },
                { 25, new BaseCircuitBreaker() { RatedCurrent = 25 } },
                { 32, new BaseCircuitBreaker() { RatedCurrent = 32 } },
                { 40, new BaseCircuitBreaker() { RatedCurrent = 40 } },
                { 50, new BaseCircuitBreaker() { RatedCurrent = 50 } },
                { 63, new BaseCircuitBreaker() { RatedCurrent = 63 } },
                { 80, new BaseCircuitBreaker() { RatedCurrent = 80 } },
                { 100, new BaseCircuitBreaker() { RatedCurrent = 100 } },
                { 125, new BaseCircuitBreaker() { RatedCurrent = 125 } },
            };

        private readonly Dictionary<double, BaseCircuitBreaker> _singlePolesBreakerData =
            new Dictionary<double, BaseCircuitBreaker>() {
                { 6, new BaseCircuitBreaker() { RatedCurrent = 6, NumberPoles = 1 } },
                { 8, new BaseCircuitBreaker() { RatedCurrent = 8, NumberPoles = 1 } },
                { 10, new BaseCircuitBreaker() { RatedCurrent = 10, NumberPoles = 1 } },
                { 13, new BaseCircuitBreaker() { RatedCurrent = 13, NumberPoles = 1 } },
                { 16, new BaseCircuitBreaker() { RatedCurrent = 16, NumberPoles = 1 } },
                { 20, new BaseCircuitBreaker() { RatedCurrent = 20, NumberPoles = 1 } },
                { 25, new BaseCircuitBreaker() { RatedCurrent = 25, NumberPoles = 1 } },
                { 32, new BaseCircuitBreaker() { RatedCurrent = 32, NumberPoles = 1 } },
                { 40, new BaseCircuitBreaker() { RatedCurrent = 40, NumberPoles = 1 } },
                { 50, new BaseCircuitBreaker() { RatedCurrent = 50, NumberPoles = 1 } },
                { 63, new BaseCircuitBreaker() { RatedCurrent = 63, NumberPoles = 1 } },
                { 80, new BaseCircuitBreaker() { RatedCurrent = 80, NumberPoles = 1 } },
                { 100, new BaseCircuitBreaker() { RatedCurrent = 100, NumberPoles = 1 } },
                { 125, new BaseCircuitBreaker() { RatedCurrent = 125, NumberPoles = 1 } },
            };

        public BaseCircuitBreaker BreakerSelect(BaseConsumer consumer, BaseCable cable) {
            if (consumer.Voltage < 380) {
                return GetSinglePolesBreaker(consumer, cable);
            }

            return GetTreePolesBreaker(consumer, cable);
        }

        private BaseCircuitBreaker GetTreePolesBreaker(BaseConsumer consumer, BaseCable cable) {
            double consumerCurrent = consumer.RatedCurrent;
            double cableCurrent = cable.MaxCableCurrent;
            if (consumerCurrent < cableCurrent) {
                double key = GetKey(_theePolesBreakerData, consumerCurrent);
                return _theePolesBreakerData[key];
            }

            throw new DataException("GetTreePolesBreaker ошибка в обработке");
        }

        private BaseCircuitBreaker GetSinglePolesBreaker(BaseConsumer consumer, BaseCable cable) {
            double consumerCurrent = consumer.RatedCurrent;
            double cableCurrent = cable.MaxCableCurrent;
            if (consumerCurrent < cableCurrent) {
                double key = GetKey(_singlePolesBreakerData, consumerCurrent);
                return _singlePolesBreakerData[key];
            }

            throw new DataException("GetSinglePolesBreaker ошибка в обработке");
        }

        private double GetKey(Dictionary<double, BaseCircuitBreaker> singlePolesBreakerData, double consumerCurrent) {
            double maxKey = 0;
            double maxValue = double.MaxValue;
            var keys = new List<double>(singlePolesBreakerData.Keys);
            for (int i = 0; i < keys.Count; i++) {
                double key = keys[i];
                var value = singlePolesBreakerData[key].RatedCurrent;
                if (value > consumerCurrent && consumerCurrent > singlePolesBreakerData[keys[i - 1]].RatedCurrent) {
                    maxKey = key;
                    maxValue = value;
                }
            }

            return maxKey;
        }
    }
}