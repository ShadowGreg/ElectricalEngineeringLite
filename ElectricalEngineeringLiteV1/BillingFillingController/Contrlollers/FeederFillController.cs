﻿using System.Linq;
using System.Runtime.InteropServices;
using BillingFillingController.Contrlollers.Cable;
using CoreV01.Feeder;

namespace BillingFillingController.Contrlollers {
    public class FeederFillController {
        public BaseCable Cable { get; set; }
        public BaseCircuitBreaker CircuitBreaker { get; set; }
        public BaseConsumer Consumer { get; }
        private readonly ConsumerFillController _consumerFillController;

        public FeederFillController(BaseConsumer consumer) {
            Consumer = consumer;
            Cable = new BaseCable();
            CircuitBreaker = new BaseCircuitBreaker();
            _consumerFillController = new ConsumerFillController();
        }

        public BaseFeeder GetFeeder(double length, int num, double maxVoltageDrop) {
            BaseFeeder outputFeeder = new BaseFeeder() {
                Consumer = Consumer
            };
            _consumerFillController.FillConsumerFields(Consumer);
            Consumer.SequentialNumber = num;
            Consumer.OwnerId = outputFeeder.SelfId;
            Cable = new CableFillController(Consumer, length).CableSelect(maxVoltageDrop);
            Cable.OwnerId = outputFeeder.SelfId;
            outputFeeder.Cable = Cable;
            CircuitBreaker = new CircuitBreakerFillController().BreakerSelect(Consumer, Cable);
            CircuitBreaker.OwnerId = outputFeeder.SelfId;
            outputFeeder.CircuitBreaker = CircuitBreaker;

            return outputFeeder;
        }
    }
}