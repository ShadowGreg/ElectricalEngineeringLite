using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using CoreV01.Feeder;
using ElectricalEngineeringLiteV1.View;

namespace ElectricalEngineeringLiteV1.ViewModel {
    public partial class ViewModel: ViewModelBase {
        private ObservableCollection<BaseConsumer> _consumers;
        private static Selected _actual;

        public ViewModel() {
            _consumers = new ObservableCollection<BaseConsumer>(new DataBase.DataBase().GetConsumers());
            _actual = new Selected(_consumers[0]);
            _addedConsumer = new BaseConsumer();
            _electricReceiverFields = new Dictionary<string, object>();
        }

        public void AddConsumer(BaseConsumer consumer) {
            
            _consumers.Add(consumer);
            OnPropertyChanged(nameof(AddConsumer));
        }

        public ObservableCollection<BaseConsumer> Consumers
        {
            get => _consumers;
            set
            {
                _consumers = value;
                OnPropertyChanged(nameof(Consumers));
            }
        }

        public object SelectedObject
        {
            get => _actual;
            set
            {
                _actual = new Selected(value);
                OnPropertyChanged("SelectedObject");
            }
        }
    }

    public class Selected: ViewModelBase {
        private object _obj;
        public Dictionary<string, object> Prop { get; }

        public Selected(object obj) {
            _obj = obj;
            Prop = GetValues(obj);
            OnPropertyChanged(nameof(Selected));
        }

        private static Dictionary<string, object> GetValues(object obj) {
            Dictionary<string, object> values = new Dictionary<string, object>();
            Type type = obj.GetType();
            PropertyInfo[] fields = type.GetProperties();
            foreach (PropertyInfo field in fields) {
                if (field.Name == "SelfId" || field.Name == "OwnerId") break;

                values[field.Name] = field.GetValue(obj);
            }

            return values;
        }
    }
}