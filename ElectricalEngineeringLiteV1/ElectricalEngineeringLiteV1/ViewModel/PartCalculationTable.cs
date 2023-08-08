using System.Collections.ObjectModel;
using System.Linq;
using BillingFillingController.Contrlollers.ElectricalPanel;
using ElectricalEngineeringLiteV1.ViewModel.Util;

namespace ElectricalEngineeringLiteV1.ViewModel {
    public partial class ViewModel {
        private void GetNewPanel() {
            _electricalPanelFillController = new ElectricalPanelFillController();
            _electricalPanelFillController.AddOnPanel(_consumers.ToList());
        }

        public ObservableCollection<Row> Row
        {
            get => _rows;
            set
            {
                _rows = value;
                OnPropertyChanged(nameof(Row));
                RowsAssembly();
            }
        }

        public void RowsAssembly() {
            ObservableCollection<Row> tempRows = new ObservableCollection<Row>();
            GetNewPanel();
            _electricalPanel = _electricalPanelFillController.GetPanel();
            tempRows.Add(new Row() {
                Name = _electricalPanel.TechnologicalNumber,
            });
            var _busbar = _electricalPanel.BusBars[0];
            tempRows.Add(new Row() {
                Name = _busbar.BusbarName,
            });
            var _feeders = _busbar.Feeders;
            foreach (var feeder in _feeders) {
                tempRows.Add(new Row() {
                    Name = feeder.Consumer.TechnologicalNumber,
                    NumberOfReceivers = feeder.Consumer.NumberElectricalReceivers,
                    RatedPower = feeder.Consumer.RatedElectricPower,
                    RatedPowerOfIdenticalElectricalReceivers = feeder.Consumer.RatedElectricPower,
                    UtilizationFactor = feeder.Consumer.UsageFactor,
                    PowerFactor = feeder.Consumer.PowerFactor,
                    TangentPowerFactor = feeder.Consumer.TanPowerFactor,
                    ActiveAverageDesignPower = feeder.Consumer.UsageFactor * feeder.Consumer.RatedElectricPower,
                    ReactiveAverageRatedPower = feeder.Consumer.ReactivePower,
                    SquareOfRatedPower = feeder.Consumer.RatedPowerSquared * feeder.Consumer.RatedPowerSquared,
                });
            }

            var _busbarFillController = _electricalPanelFillController.GetBusbarFillController();
            tempRows.Add(new Row() {
                Name = $"ИТОГО по шине {_busbar.BusbarName}:",
                NumberOfReceivers = _busbarFillController.BusbarCalculations.NumberOfReceivers,
                RatedPower = _busbarFillController.BusbarCalculations.RatedPower,
                RatedPowerOfIdenticalElectricalReceivers =
                    _busbarFillController.BusbarCalculations.RatedPowerOfIdenticalElectricalReceivers,
                UtilizationFactor = _busbarFillController.BusbarCalculations.BusUtilizationFactor,
                PowerFactor = _busbarFillController.BusbarCalculations.BusPowerFactor,
                TangentPowerFactor = _busbarFillController.BusbarCalculations.TangentOfBusPowerFactor,
                ActiveAverageDesignPower = _busbarFillController.BusbarCalculations.ActiveAverageDesignPower,
                ReactiveAverageRatedPower = _busbarFillController.BusbarCalculations.ActiveRatedPowerOfTheBus,
                SquareOfRatedPower = _busbarFillController.BusbarCalculations.SquareOfRatedPower,
                EquivalentNumberOfElectricalReceivers =
                    _busbarFillController.BusbarCalculations.EquivalentNumberOfElectricalReceivers,
                DesignLoadFactor = _busbarFillController.BusbarCalculations.DesignLoadFactor,
                ActiveRatedPower = _busbarFillController.BusbarCalculations.ActiveRatedPowerOfTheBus,
                ReactiveRatedPower = _busbarFillController.BusbarCalculations.ReactiveRatedPowerOfTheBus,
                TotalDesignPower = _busbarFillController.BusbarCalculations.TotalDesignPowerOfTheBus,
                DesignBusbarCurrent = _busbarFillController.BusbarCalculations.DesignBusbarCurrent,
            });
            tempRows.Add(new Row() {
                Name = $"ИТОГО по щиту {_electricalPanel.MechanismName}:",
                NumberOfReceivers = _busbarFillController.BusbarCalculations.NumberOfReceivers,
                RatedPower = _busbarFillController.BusbarCalculations.RatedPower,
                RatedPowerOfIdenticalElectricalReceivers =
                    _busbarFillController.BusbarCalculations.RatedPowerOfIdenticalElectricalReceivers,
                UtilizationFactor = _busbarFillController.BusbarCalculations.BusUtilizationFactor,
                PowerFactor = _busbarFillController.BusbarCalculations.BusPowerFactor,
                TangentPowerFactor = _busbarFillController.BusbarCalculations.TangentOfBusPowerFactor,
                ActiveAverageDesignPower = _busbarFillController.BusbarCalculations.ActiveAverageDesignPower,
                ReactiveAverageRatedPower = _busbarFillController.BusbarCalculations.ActiveRatedPowerOfTheBus,
                SquareOfRatedPower = _busbarFillController.BusbarCalculations.SquareOfRatedPower,
                EquivalentNumberOfElectricalReceivers =
                    _busbarFillController.BusbarCalculations.EquivalentNumberOfElectricalReceivers,
                DesignLoadFactor = _busbarFillController.BusbarCalculations.DesignLoadFactor,
                ActiveRatedPower = _busbarFillController.BusbarCalculations.ActiveRatedPowerOfTheBus,
                ReactiveRatedPower = _busbarFillController.BusbarCalculations.ReactiveRatedPowerOfTheBus,
                TotalDesignPower = _busbarFillController.BusbarCalculations.TotalDesignPowerOfTheBus,
                DesignBusbarCurrent = _busbarFillController.BusbarCalculations.DesignBusbarCurrent,
            });
            _rows = tempRows;
            RebaseNode();
            OnPropertyChanged(nameof(Row));
        }
    }
}