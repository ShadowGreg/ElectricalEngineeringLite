using System.Windows;
using System.Windows.Controls;
using ElectricalEngineeringLiteV1.View.Consumer;

namespace ElectricalEngineeringLiteV1.View {
    public partial class Toolbox: Page {
        private readonly ViewModel.ViewModel _viewModel;

        public Toolbox() {
            InitializeComponent();
            _viewModel = (ViewModel.ViewModel)Application.Current.Resources["ViewModel"];
        }

        private void Add_Consumer(object sender, RoutedEventArgs e) {
            Window addConsumer = new AddConsumer();
            addConsumer.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            throw new System.NotImplementedException();
        }

        private void Calculate_Consumer(object sender, RoutedEventArgs e) {
            _viewModel.RowsAssembly();
        }

        private void Edit_Click(object sender, RoutedEventArgs e) {
            Window editConsumer = new EditConsumer();
            editConsumer.Show();
        }
    }
}