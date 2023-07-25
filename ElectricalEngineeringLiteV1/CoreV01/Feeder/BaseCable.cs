﻿using System;
using CoreV01.Properties;

namespace CoreV01.Feeder {
    public class BaseCable: DBDependence {
        /// <summary>
        /// Порядковый номер в шине - что бы при
        /// восстановлении данных не менялся порядок приёмнтков
        /// </summary>
        /// TODO нужно ли это потому что в последующем включить все элементы в фидер
        public int SequentialNumber { get; set; } = 0;

        /// <summary>
        /// Наименование кабеля - пока решение ручной ввод
        /// </summary>
        public string CableName { get; set; } = String.Empty;

        /// <summary>
        ///Марка кабеля - пока вводится в ручную 
        /// </summary>
        public string CableBrand { get; set; } = "ВВГнг-";

        /// <summary>
        ///Число жил в кабеле 
        /// </summary>
        public int CoresNumber { get; set; } = 2;

        /// <summary>
        /// Сечение кабеля в соответствии с ГОСТ и каталогом производителя
        /// </summary>
        public double CableCrossSection { get; set; } = 2.5;

        /// <summary>
        /// Потребное количество кабелей в фидере для питания потребителя
        /// </summary>
        public int NumberInFeeder { get; set; } = 1;

        /// <summary>
        /// Длинна кабеля на участке в м
        /// </summary>
        public double CableLength { get; set; } = 1;

        /// <summary>
        /// Потеря напряжения в кабеле по длине %
        /// </summary>
        public double CableVoltageLoss { get; set; } = 0.01;

        /// <summary>
        /// Номинальный ток питания потребителя А
        /// </summary>
        public double CableCurrent { get; set; } = 0.01;

        /// <summary>
        /// Ток короткого замыкания кА
        /// </summary>
        public double ShortCircuitCurrent { get; set; } = 0.01;
    }
}