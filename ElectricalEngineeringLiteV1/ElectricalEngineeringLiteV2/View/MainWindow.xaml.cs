using System.Windows;

namespace ElectricalEngineeringLiteV1.View {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        private readonly ViewModel.ViewModel _viewModel;
        public MainWindow() {
            InitializeComponent();
            _viewModel = (ViewModel.ViewModel)Application.Current.Resources["ViewModel"];
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e) {
            _viewModel.CadController.DrawPanel(_viewModel.ElectricalPanel);
        }
    }
}