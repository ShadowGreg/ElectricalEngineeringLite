using System.Collections.Generic;
using CoreV01.Feeder;
using CoreV01.Properties;

namespace DataBase {
    public class DataBase: IReadWrite {
        private static List<BaseConsumer> _consumers;

        public DataBase() {
            _consumers = new List<BaseConsumer>() {
                new BaseConsumer() {
                    TechnologicalNumber = "MXZ-340-15A",
                    MechanismName = "насос технологический",
                    RatedElectricPower = 18.5,
                    PowerFactor = 0.85,
                    Voltage = 400,
                    HoursWorkedPerYear = 8700,
                    LocationEquipmentInstallation = "102",
                    StartingCurrentMultiplicity = 11
                },
                new BaseConsumer() {
                    TechnologicalNumber = "MXZ-340-15B",
                    MechanismName = "насос технологический",
                    RatedElectricPower = 18.5,
                    PowerFactor = 0.85,
                    Voltage = 400,
                    HoursWorkedPerYear = 8700,
                    LocationEquipmentInstallation = "102",
                    StartingCurrentMultiplicity = 10
                },
                new BaseConsumer() {
                    TechnologicalNumber = "MXZ-340-15C",
                    MechanismName = "насос технологический",
                    RatedElectricPower = 18.5,
                    PowerFactor = 0.85,
                    Voltage = 400,
                    HoursWorkedPerYear = 8700,
                    LocationEquipmentInstallation = "102",
                    StartingCurrentMultiplicity = 7
                },
                new BaseConsumer() {
                    TechnologicalNumber = "MXW-250-13C",
                    MechanismName = "насос технологический",
                    RatedElectricPower = 18.5,
                    PowerFactor = 0.85,
                    Voltage = 400,
                    HoursWorkedPerYear = 8700,
                    LocationEquipmentInstallation = "102",
                    StartingCurrentMultiplicity = 1
                }
            };
        }

        public List<BaseConsumer> GetConsumers() {
            new DataBase();
            return _consumers;
        }

        public static List<BaseElectricPanel> ElectricPanels { get; set; }
    }
}