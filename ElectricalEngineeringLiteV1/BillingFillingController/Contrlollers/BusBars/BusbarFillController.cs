using System;
using System.Collections.Generic;
using CoreV01.Feeder;
using CoreV01.Properties;

namespace BillingFillingController.Contrlollers.BusBars {
    public class BusbarFillController {
        private List<BaseConsumer> _consumers;
        private List<BaseFeeder> _feeders;
        private BaseBusbar _busbar;

        public RMTCalculation BusbarCalculations { get; set; }

        public BusbarFillController() {
            _consumers = new List<BaseConsumer>();
            _feeders = new List<BaseFeeder>();
            _busbar = new BaseBusbar();
        }

        public void AddConsumerOnBus(BaseConsumer newConsumer) {
            _consumers.Add(newConsumer);
            FillBusbarParams();
        }

        private void FillBusbarParams() {
            void BasicFilling() {
                _busbar.EmergencyСurrentInputSwitch = _busbar.RatedCurrent;
                _busbar.SectionalCircuitBreaker = null;
                _busbar.EmergencyСurrentSectionalSwitch = 0;
            }

            _busbar.InstalledCapacity = BusbarCalculations.GetInstallCapacity(_consumers);
            _busbar.RatedCapacity = BusbarCalculations.GetRatedCapacity(_consumers);
            _busbar.PowerFactor = BusbarCalculations.GetBusbarPowerFactor(_consumers);
            _busbar.RatedCurrent = BusbarCalculations.GetBusbarRatedCurrent(_consumers);
            _busbar.InputSwitch = GetBusbarInputSwitch();

            BasicFilling();

            _busbar.feeders = GenerateFeeders(_feeders);
            throw new NotImplementedException();
        }

        private List<BaseFeeder> GenerateFeeders(List<BaseFeeder> feeders) {
            throw new NotImplementedException();
        }

        private BaseCircuitBreaker GetBusbarInputSwitch() {
            throw new NotImplementedException();
        }

        public void AddConsumersListOnBus(IEnumerable<BaseConsumer> consumers) {
            _consumers.AddRange(consumers);
        }

        public BaseBusbar GetBusbar() => _busbar;
    }
}