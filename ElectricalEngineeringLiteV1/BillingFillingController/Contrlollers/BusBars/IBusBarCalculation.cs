using System.Collections.Generic;
using CoreV01.Feeder;

namespace BillingFillingController.Contrlollers.BusBars {
    public interface IBusBarCalculation {
        double GetInstallCapacity(List<BaseConsumer> consumers);
        double GetRatedCapacity(List<BaseConsumer> consumers);
        double GetBusbarPowerFactor(List<BaseConsumer> consumers);
        double GetBusbarRatedCurrent(List<BaseConsumer> consumers);
    }
}