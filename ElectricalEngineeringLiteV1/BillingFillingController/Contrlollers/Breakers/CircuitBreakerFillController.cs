using System.Collections.Generic;
using System.Data;
using CoreV01.Feeder;

namespace BillingFillingController.Contrlollers.Breakers {
    public class CircuitBreakerFillController {
        private readonly BreakerData _breakerData = new BreakerData();

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
                double key = GetKey(_breakerData._theePolesBreakerData, consumerCurrent);
                return _breakerData._theePolesBreakerData[key];
            }

            throw new DataException("GetTreePolesBreaker ошибка в обработке");
        }

        private BaseCircuitBreaker GetSinglePolesBreaker(BaseConsumer consumer, BaseCable cable) {
            double consumerCurrent = consumer.RatedCurrent;
            double cableCurrent = cable.MaxCableCurrent;
            if (consumerCurrent < cableCurrent) {
                double key = GetKey(_breakerData._singlePolesBreakerData, consumerCurrent);
                return _breakerData._singlePolesBreakerData[key];
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