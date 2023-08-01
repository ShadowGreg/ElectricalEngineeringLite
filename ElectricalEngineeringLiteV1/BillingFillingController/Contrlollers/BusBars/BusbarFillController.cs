using System.Collections.Generic;
using BillingFillingController.Calculators;
using BillingFillingController.Contrlollers.Breakers;
using BillingFillingController.Contrlollers.Feeder;
using CoreV01.Feeder;
using CoreV01.Properties;

namespace BillingFillingController.Contrlollers.BusBars {
    public class BusbarFillController {
        private static List<BaseConsumer> _consumers;
        private static List<BaseFeeder> _feeders;
        private static BaseBusbar _busbar;
        private readonly double _voltage;

        public static RMTCalculation BusbarCalculations { get; set; }

        public BusbarFillController(double voltage) {
            _voltage = voltage;
            _consumers = new List<BaseConsumer>();
            _feeders = new List<BaseFeeder>();
            _busbar = new BaseBusbar();
            BusbarCalculations = new RMTCalculation();
        }


        public void AddConsumerOnBus(BaseConsumer newConsumer, double length = 5, double maxVoltageDrop = 2.5) {
            _consumers.Add(newConsumer);
            if (_feeders.Count == 0) {
                _feeders.Add(new FeederFillController(newConsumer).GetFeeder(length, 1, maxVoltageDrop));
            }
            else {
                int index = _feeders.Count + 1;
                _feeders.Add(new FeederFillController(newConsumer).GetFeeder(length, index, maxVoltageDrop));
            }

            _feeders[_feeders.Count - 1].OwnerId = _busbar.SelfId;
            _feeders[_feeders.Count - 1].SequentialNumber = _feeders.Count;
            _feeders[_feeders.Count - 1].CircuitBreaker.NameOnBus += _feeders.Count;
            FillBusbarParams();
        }

        private void FillBusbarParams() {
            void BasicFilling() {
                _busbar.EmergencyСurrentInputSwitch = _busbar.RatedCurrent;
                _busbar.SectionalCircuitBreaker = null;
                _busbar.EmergencyСurrentSectionalSwitch = 0;
            }

            _busbar.InstalledCapacity = BusbarCalculations.GetInstallCapacity(_consumers, _voltage);
            _busbar.RatedCapacity = BusbarCalculations.ActiveRatedPowerOfTheBus;
            _busbar.PowerFactor = BusbarCalculations.BusPowerFactor;
            _busbar.RatedCurrent = BusbarCalculations.DesignBusbarCurrent;
            _busbar.InputSwitch = GetBusbarInputSwitch();
            _busbar.InputSwitch.NameOnBus = "QS";
            _busbar.feeders = _feeders;

            BasicFilling();
        }

        private BaseCircuitBreaker GetBusbarInputSwitch() {
            return new CircuitBreakerFillController().GetInputSwitch(_busbar.RatedCurrent);
        }

        public void AddConsumersListOnBus(IEnumerable<BaseConsumer> consumers) {
            _consumers.AddRange(consumers);
            foreach (var consumer in consumers) {
                AddConsumerOnBus(consumer);
            }
        }

        public BaseBusbar GetBusbar() => _busbar;
    }
}