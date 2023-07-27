using CoreV01.Properties;

namespace CoreV01.Feeder {
    public class BaseConsumer: DBDependence {
        /// <summary>
        /// Технологический номер оборудования
        /// </summary>
        public string TechnologicalNumber { get; set; } = "";

        /// <summary>
        /// Наименование механизма
        /// </summary>
        public string MechanismName { get; set; } = "";

        /// <summary>
        ///Тип оборудования для расчёта токов в кабеле
        /// TODO далее можно усложнить расчёт на базе этого элемента для автоподборки коэффициентов
        /// </summary>
        public ConsumerType LoadType { get; set; } = ConsumerType.Technological;


        /// <summary>
        /// Коэффициент (кратность) пускового тока
        /// </summary>
        public double StartingCurrentMultiplicity { get; set; } = 1;

        /// <summary>
        /// Номинальная электрическая мощность кВт
        /// </summary>
        public double RatedElectricPower { get; set; } = 0.1;

        /// <summary>
        /// Коэффициент использования
        /// </summary>
        public double UsageFactor { get; set; } = 0.1;

        /// <summary>
        /// Коэффициент мощности косинус фи
        /// </summary>
        public double PowerFactor { get; set; } = 0.01;

        /// <summary>
        /// Коэффициент мощности тангенс фи
        /// </summary>
        public double TanPowerFactor { get; set; } = 0.01;

        /// <summary>
        /// Коэффициент полезного действия КПД
        /// </summary>
        public double EfficiencyFactor { get; set; } = 0.8;

        /// <summary>
        /// Тип системы заземления TN-C-S
        /// </summary>
        public string TypeGroundingSystem { get; set; } = "TN-C-S";

        /// <summary>
        /// Напряжение В
        /// </summary>
        public double Voltage { get; set; } = 400;

        /// <summary>
        /// Количество фаз
        /// </summary>
        public int PhaseNumber { get; set; } = 3;

        /// <summary>
        /// Количество электроприёмников
        /// </summary>
        public int NumberElectricalReceivers { get; set; } = 1;

        /// <summary>
        /// Количество часов работы в год
        /// </summary>
        public int HoursWorkedPerYear { get; set; } = 1;

        /// <summary>
        /// Номер помещения (оборудования) по генплну в котором расположено оборудование
        /// </summary>
        public string LocationEquipmentInstallation { get; set; } = "";

        /// <summary>
        /// Классификация помещняи по взрыво-,пожароопасности зон
        /// </summary>
        public string ClassificationEquipmentInstallation { get; set; } = "";

        /// <summary>
        /// Квадрат номинальной мощности
        /// </summary>
        public double RatedPowerSquared { get; set; } = 1;

        /// <summary>
        /// Реактивная мощность
        /// </summary>
        public double ReactivePower { get; set; } = 1;

        /// <summary>
        /// Номинальный ток
        /// </summary>
        public double RatedCurrent { get; set; } = 1;

        /// <summary>
        /// Пусковой ток
        /// </summary>
        public double StartingCurrent { get; set; } = 1;
    }

    public enum ConsumerType {
        Technological,
        Sanitary,
        Lighting,
        Heating,
        ElectricHeating,
        Other,
        Reserve,
        ReactivePowerCompensation
    }
}