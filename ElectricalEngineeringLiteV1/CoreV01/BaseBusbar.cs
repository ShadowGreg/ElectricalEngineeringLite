﻿using System.Collections.Generic;
using CoreV01.Feeder;

namespace CoreV01.Properties {
    public class BaseBusbar: DBDependence {
        /// <summary>
        /// Мощность оборудования  установленная на секцию шин кВт
        /// </summary>
        public double installedCapacity { get; set; }

        /// <summary>
        /// Расчётная мощность оборудования установленного на секцию шин кВт
        /// </summary>
        public double RatedCapacity { get; set; }

        /// <summary>
        /// Коэффициент мощности шины
        /// </summary>
        public double PowerFactor { get; set; }

        /// <summary>
        /// Расчётный ток на шине
        /// </summary>
        public double RatedCurrent { get; set; }

        /// <summary>
        /// Ток короткого замыкания на секции шин
        /// </summary>
        public double ShortCircuitCurrent { get; set; }

        /// <summary>
        /// Ввводной выключатель
        /// </summary>
        public BaseCircuitBreaker InputSwitch { get; set; }

        /// <summary>
        /// Ток в аварийном режиме на вводном выключателе
        /// </summary>
        public double EmergencyСurrentInputSwitch { get; set; }

        /// <summary>
        /// Секционный выключатель
        /// </summary>
        public BaseCircuitBreaker SectionalCircuitBreaker { get; set; }

        /// <summary>
        /// Ток в аварийном режиме на секционном выключателе
        /// </summary>
        public double EmergencyСurrentSectionalSwitch { get; set; }

        /// <summary>
        /// Фидеры на секции
        /// </summary>
        public List<BaseFeeder> feeders { get; set; }
    }
}