using System.Collections.Generic;
using System.Linq;
using BillingFillingController.Calculators;
using BillingFillingController.Contrlollers.BusBars;
using CoreV01.Feeder;
using CoreV01.Properties;

namespace BillingFillingController.Contrlollers.ElectricalPanel {
    public class ElectricalPanelFillController {
        private static BaseElectricalPanel _baseElectricalPanel;
        private static BusbarFillController _busbarFillController;
        public static RMTCalculation PanelCalculations { get; set; }

        public ElectricalPanelFillController(double voltage = 400, string name = "Новый щитр ЩР1") {
            _baseElectricalPanel = new BaseElectricalPanel {
                TechnologicalNumber = name,
                BusBars = new List<BaseBusbar>(),
            };
            _busbarFillController = new BusbarFillController(voltage);
            _baseElectricalPanel.BusBars.Add(new BaseBusbar());
        }

        private void AddConsumerOnPanel(BaseConsumer newConsumer, double length = 5, double maxVoltageDrop = 2.5,
            int busbarNum = 0) {
            _busbarFillController.AddConsumerOnBus(newConsumer, length, maxVoltageDrop);
            _baseElectricalPanel.BusBars[busbarNum] = _busbarFillController.GetBusbar();
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
        }

        public BaseElectricalPanel GetPanel() {
            FillPanel();
            return _baseElectricalPanel;
        }

        private void FillPanel() {
            throw new System.NotImplementedException();
        }
    }
}