using System;
using System.Collections.Generic;
using BillingFillingController.Calculators;
using BillingFillingController.Contrlollers.Breakers;
using CoreV01.Feeder;
using CoreV01.Properties;

namespace BillingFillingController.Contrlollers.BusBars {
    public class BusbarFillController {
        private List<BaseConsumer> _consumers;
        private List<BaseFeeder> _feeders;
        private BaseBusbar _busbar;
        private double _voltage;

        public RMTCalculation BusbarCalculations { get; set; }

        public BusbarFillController(double voltage) {
            _voltage = voltage;
            _consumers = new List<BaseConsumer>();
            _feeders = new List<BaseFeeder>();
            _busbar = new BaseBusbar();
            BusbarCalculations = new RMTCalculation();
        }


        public void AddConsumerOnBus(BaseConsumer newConsumer, double length = 5, double maxVoltageDrop = 2.5) {
            _consumers.Add(newConsumer);
            int index = _consumers.Count - 1;
            _feeders.Add(new FeederFillController(newConsumer).GetFeeder(length, index, maxVoltageDrop));
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