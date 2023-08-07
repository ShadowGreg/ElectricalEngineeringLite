using System.Collections.Generic;
using System.Collections.ObjectModel;
using CoreV01.Feeder;
using CoreV01.Properties;

namespace ElectricalEngineeringLiteV1.View.CenterFrame.DistributionNetworkTable {
    public class Node {
        public ObservableCollection<Node> Children { get; }
        public string Description { get; } = "";

        public Node(BaseConsumer consumer) {
            Description = consumer.TechnologicalNumber;
        }

        public Node(BaseCircuitBreaker breaker) {
            Description = breaker.NameOnBus;
        }

        public Node(BaseCable cable) {
            Description = cable.CableName;
        }

        public Node(BaseFeeder feeder) {
            Description = feeder.CircuitBreaker.NameOnBus;
            Children = new ObservableCollection<Node> {
                new Node(feeder.CircuitBreaker),
                new Node(feeder.Cable),
                new Node(feeder.Consumer)
            };
        }

        public Node(List<BaseFeeder> feeders) {
            Children = new ObservableCollection<Node>();
            foreach (var feeder in feeders) {
                Children.Add(new Node(feeder));
            }
        }

        public Node(BaseBusbar busbar) {
            Description = busbar.BusbarName;
            Children = new ObservableCollection<Node> {
                new Node(busbar.Feeders),
            };
        }

        public Node(List<BaseBusbar> busbars) {
            foreach (var busbar in busbars) {
                Description = busbar.BusbarName;
                Children = new ObservableCollection<Node> {
                    new Node(busbar),
                };
            }
        }

        public Node(BaseElectricalPanel panel) {
            Description = panel.TechnologicalNumber;
            Children = new ObservableCollection<Node> {
                new Node(panel.BusBars)
            };
        }
    }
}