using CoreV01.Properties;

namespace CoreV01.Feeder {
    public class BaseConsumer: DBDependence {
        /// <summary>
        /// 1 Технологический номер оборудования
        /// </summary>
        public string TechnologicalNumber { get; set; } = "";

        /// <summary>
        /// 2 Наименование механизма
        /// </summary>
        public string MechanismName { get; set; } = "";

        /// <summary>
        ///3 Тип оборудования для расчёта токов в кабеле
        /// TODO далее можно усложнить расчёт на базе этого элемента для автоподборки коэффициентов
        /// </summary>
        public ConsumerType LoadType { get; set; } = ConsumerType.Technological;


        /// <summary>
        /// 4 Коэффициент (кратность) пускового тока
        /// </summary>
        public double StartingCurrentMultiplicity { get; set; } = 1;

        /// <summary>
        /// 5 Номинальная электрическая мощность кВт
        /// </summary>
        public double RatedElectricPower { get; set; } = 0.1;

        /// <summary>
        /// 6 Коэффициент использования
        /// </summary>
        public double UsageFactor { get; set; } = 0.85;

        /// <summary>
        /// 7 Коэффициент мощности косинус фи
        /// </summary>
        public double PowerFactor { get; set; } = 0.85;

        /// <summary>
        /// 8 Коэффициент мощности тангенс фи
        /// </summary>
        public double TanPowerFactor { get; set; } = 0.01;

        /// <summary>
        /// 9 Коэффициент полезного действия КПД
        /// </summary>
        public double EfficiencyFactor { get; set; } = 0.8;

        /// <summary>
        /// 10 Тип системы заземления TN-C-S
        /// </summary>
        public string TypeGroundingSystem { get; set; } = "TN-C-S";

        /// <summary>
        /// 11 Напряжение В
        /// </summary>
        public double Voltage { get; set; } = 400;

        /// <summary>
        /// 12 Количество фаз
        /// </summary>
        public int PhaseNumber { get; set; } = 3;

        /// <summary>
        /// 13 Количество электроприёмников
        /// </summary>
        public int NumberElectricalReceivers { get; set; } = 1;

        /// <summary>
        /// 14 Количество часов работы в год
        /// </summary>
        public int HoursWorkedPerYear { get; set; } = 1;

        /// <summary>
        /// 15 Номер помещения (оборудования) по генплну в котором расположено оборудование
        /// </summary>
        public string LocationEquipmentInstallation { get; set; } = "";

        /// <summary>
        /// 16 Классификация помещняи по взрыво-,пожароопасности зон
        /// </summary>
        public string ClassificationEquipmentInstallation { get; set; } = "";

        /// <summary>
        /// 17 Квадрат номинальной мощности
        /// </summary>
        public double RatedPowerSquared { get; set; } = 1;

        /// <summary>
        /// 18 Реактивная мощность
        /// </summary>
        public double ReactivePower { get; set; } = 1;

        /// <summary>
        /// 19 Номинальный ток
        /// </summary>
        public double RatedCurrent { get; set; } = 1;

        /// <summary>
        /// 20 Пусковой ток
        /// </summary>
        public double StartingCurrent { get; set; } = 1;

        ///TODO дописать методы сравнения - для реализации поиска и удаления потребителя из массива потребителей
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