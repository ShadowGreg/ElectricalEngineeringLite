using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using CoreV01.Feeder;

namespace ElectricalEngineeringLiteV1.ViewModel {
    public partial class ViewModel {
        private ObservableCollection<BaseConsumer> _consumers;
        private static Selected _actual;


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

        public BaseConsumer SelectedConsumer
        {
            get
            {
                var obj = _actual.Obj as BaseConsumer;
                if (obj != null)
                    return obj;
                throw new FileFormatException("Нет возможности скастить до BaseConsumer ошибка ");
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
        public Dictionary<string, object> Prop { get; }

        public object Obj { get; }

        public Selected(object obj) {
            Obj = obj;
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