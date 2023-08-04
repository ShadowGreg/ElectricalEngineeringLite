using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using ElectricalEngineeringLiteV1.ViewModel;

namespace ElectricalEngineeringLiteV1.View {
    public partial class Toolbox: Page {
        public Toolbox() {
            InitializeComponent();
        }

        private void Add_Consumer(object sender, RoutedEventArgs e) {
            Window addConsumer = new AddConsumer();
            addConsumer.Show();
        }
    }
}