using System.Collections.Generic;
using System.Linq;
using BillingFillingController.Calculators;
using BillingFillingController.Contrlollers.BusBars;
using CoreV01.Feeder;
using CoreV01.Properties;

namespace BillingFillingController.Contrlollers.ElectricalPanel {
    public class ElectricalPanelFillController {
        private static BaseElectricalPanel _electricalPanel;
        private static BusbarFillController _busbarFillController;
        public static RMTCalculation PanelCalculations { get; set; }

        public ElectricalPanelFillController(double voltage = 400, string name = "Новый щитр ЩР1") {
            _electricalPanel = new BaseElectricalPanel {
                TechnologicalNumber = name,
                BusBars = new List<BaseBusbar>(),
            };
            _busbarFillController = new BusbarFillController(voltage);
            _electricalPanel.BusBars.Add(new BaseBusbar());
        }

        private void AddConsumerOnPanel(BaseConsumer newConsumer, double length = 5, double maxVoltageDrop = 2.5,
            int busbarNum = 0) {
            _busbarFillController.AddConsumerOnBus(newConsumer, length, maxVoltageDrop);
            _electricalPanel.BusBars[busbarNum] = _busbarFillController.GetBusbar();
        }

        public void AddOnPanel(List<BaseConsumer> consumers, int busbarNum = 0) {
            if (consumers.Count() == 1) {
                AddConsumerOnPanel(consumers[0], 0);
            }
            else {
                foreach (var consumer in consumers) {
                    AddConsumerOnPanel(consumer, busbarNum);
                }
            }

            CalculatePanelFields();
        }

        public BaseElectricalPanel GetPanel() {
            CalculatePanelFields();
            return _electricalPanel;
        }

        private static void CalculatePanelFields() {
            _electricalPanel.NumberOfElectricalReceiversInstalledInTheSwitchboard = GetNumberOfReceivers();
            _electricalPanel.InstalledElectricalPowerOfTheSwitchboard = GetInstalledPowerOfSwitchboard();
            _electricalPanel.ShieldUtilizationFactor = GetShieldUtilizationFactor();
            _electricalPanel.ShieldPowerFactor = GetShieldPowerFactor();
            _electricalPanel.AverageRatedActivePower = GetAverageRatedActivePower();
            _electricalPanel.AverageDesignReactivePower = GetAverageDesignReactivePower();
            _electricalPanel.SquareOfTheRatedPowerOfThePanel = GetSquareOfTheRatedPowerOfThePanel();
            _electricalPanel.EquivalentNumberOfElectricalReceiversOfTheShield =
                GetEquivalentNumberOfElectricalReceivers();
            _electricalPanel.DesignLoadFactor = GetDesignLoadFactor();
            _electricalPanel.ShieldActivePower = GetShieldActivePower();
            _electricalPanel.ReactivePowerOfThePanel = GetReactivePowerOfThePanel();
            _electricalPanel.TotalPower = GetReactivePowerOfThePanel();
            _electricalPanel.RatedCurrent = GetRatedCurrent();
        }

        private static double GetNumberOfReceivers() {
            return _electricalPanel.BusBars.Sum(busbar => busbar.feeders.Count());
        }

        private static double GetInstalledPowerOfSwitchboard() {
            throw new System.NotImplementedException();
        }

        private static double GetShieldUtilizationFactor() {
            throw new System.NotImplementedException();
        }

        private static double GetShieldPowerFactor() {
            throw new System.NotImplementedException();
        }

        private static double GetAverageRatedActivePower() {
            throw new System.NotImplementedException();
        }

        private static double GetAverageDesignReactivePower() {
            throw new System.NotImplementedException();
        }

        private static double GetSquareOfTheRatedPowerOfThePanel() {
            throw new System.NotImplementedException();
        }

        private static double GetEquivalentNumberOfElectricalReceivers() {
            throw new System.NotImplementedException();
        }

        private static double GetDesignLoadFactor() {
            throw new System.NotImplementedException();
        }

        private static double GetShieldActivePower() {
            throw new System.NotImplementedException();
        }

        private static double GetReactivePowerOfThePanel() {
            throw new System.NotImplementedException();
        }

        private static double GetRatedCurrent() {
            throw new System.NotImplementedException();
        }
    }
}