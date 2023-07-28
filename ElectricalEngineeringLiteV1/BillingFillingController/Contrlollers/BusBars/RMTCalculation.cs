using System.Collections.Generic;
using CoreV01.Feeder;

namespace BillingFillingController.Contrlollers.BusBars {
    public class RMTCalculation: IBusBarCalculation {
        /// <summary>
        /// Эквивалентное число электро приёмников на шине
        /// </summary>
        public double EquivalentNumberOfElectricalReceivers { get; set; }

        /// <summary>
        /// номинальная мощность
        /// </summary>
        public double RatedPower { get; set; }

        /// <summary>
        /// номинальная мощность одинаковых электро приёмников
        /// </summary>
        public double RatedPowerOfIdenticalElectricalReceivers { get; set; }

        /// <summary>
        /// коэффициент использования шины
        /// </summary>
        public double BusUtilizationFactor { get; set; }

        /// <summary>
        /// коэффициента мощности шины
        /// </summary>
        public double BusPowerFactor { get; set; }

        /// <summary>
        /// Тангенс коэффициента мощности шины
        /// </summary>
        public double TangentOfBusPowerFactor { get; set; }

        /// <summary>
        /// активная средняя расчётная мощность
        /// </summary>
        public double ActiveAverageDesignPower { get; set; }

        /// <summary>
        /// реактивная средняя расчётная мощность 
        /// </summary>
        public double ReactiveAverageRatedPower { get; set; }

        /// <summary>
        /// квадрат номинальной мощности 
        /// </summary>
        public double SquareOfRatedPower { get; set; }

        /// <summary>
        /// коэффициент расчётной нагрузки
        /// </summary>
        public double DesignLoadFactor { get; set; }

        /// <summary>
        /// активная расчётная мощность шины
        /// </summary>
        public double ActiveRatedPowerOfTheBus { get; set; }

        /// <summary>
        /// реактивная расчётная мощность шины 
        /// </summary>
        public double ReactiveRatedPowerOfTheBus { get; set; }

        /// <summary>
        /// полная расчётная мощность шины 
        /// </summary>
        public double TotalDesignPowerOfTheBus { get; set; }

        /// <summary>
        /// Расчётный ток на шине
        /// </summary>
        public double DesignBusbarCurrent { get; set; }

        public double GetInstallCapacity(List<BaseConsumer> consumers) {
            throw new System.NotImplementedException();
        }

        public double GetRatedCapacity(List<BaseConsumer> consumers) {
            throw new System.NotImplementedException();
        }

        public double GetBusbarPowerFactor(List<BaseConsumer> consumers) {
            throw new System.NotImplementedException();
        }

        public double GetBusbarRatedCurrent(List<BaseConsumer> consumers) {
            throw new System.NotImplementedException();
        }
    }
}