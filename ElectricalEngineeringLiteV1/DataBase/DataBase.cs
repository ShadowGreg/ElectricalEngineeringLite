using System.Collections.Generic;
using CoreV01.Feeder;

namespace DataBase {
    public class DataBase: IReadWrite {
        private static List<BaseConsumer> _consumers;

        private DataBase() {
            _consumers.Add(
                new BaseConsumer() {
                    TechnologicalName = "",
                }
                );
        }

        public List<BaseConsumer> GetConsumers() {
            new DataBase();
            return _consumers;
        }
    }
}