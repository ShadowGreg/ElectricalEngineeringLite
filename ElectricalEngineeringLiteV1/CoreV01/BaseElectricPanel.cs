using System.Collections.Generic;
using CoreV01.Feeder;

namespace CoreV01.Properties {
    public class BaseElectricPanel: BaseConsumer {
        /// <summary>
        /// Силовые шины электрического щита
        /// </summary>
        public List<BaseBusbar> Busbars { get; set; }
    }
}