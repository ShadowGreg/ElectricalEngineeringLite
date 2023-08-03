using System;
using System.Collections.Generic;
using System.Reflection;
using CoreV01.Feeder;

namespace ElectricalEngineeringLiteV1.ViewModel {
    public class ViewModel: ViewModelBase {
        private List<BaseConsumer> _consumers;
        private SelectedObj _actualObj;

        public ViewModel() {
            _consumers = new DataBase.DataBase().GetConsumers();
            _actualObj = new SelectedObj(_consumers[0]);
        }

        public List<BaseConsumer> Consumers
        {
            get => _consumers;
            set
            {
                _consumers = value;
                OnPropertyChanged(nameof(Consumers));
            }
        }

        public SelectedObj SelectedObj
        {
            get => _actualObj;
            set
            {
                _actualObj = new SelectedObj(value);
                OnPropertyChanged(nameof(SelectedObj));
            }
        }
    }

    public class SelectedObj {
        private object _obj;
        public Dictionary<string, object> Prop { get; }

        public SelectedObj(object obj) {
            _obj = obj;
            Prop = GetValues(obj);
        }

        private static Dictionary<string, object> GetValues(object obj) {
            Dictionary<string, object> values = new Dictionary<string, object>();
            Type type = obj.GetType();
            PropertyInfo[] fields = type.GetProperties();
            foreach (PropertyInfo field in fields) {
                if (field.Name == "FooFields") break;

                values[field.Name] = field.GetValue(obj);
            }

            return values;
        }
    }
}