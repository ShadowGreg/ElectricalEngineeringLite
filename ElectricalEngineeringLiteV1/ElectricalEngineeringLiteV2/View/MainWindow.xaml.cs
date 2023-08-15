using System;
using System.Windows;
using ElectricalEngineeringLiteV1.View.Help;

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
            MessageBox.Show("Создание схемы завершено",
                "Схема",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void License_OnClick(object sender, RoutedEventArgs e) {
            Window licenseAgreement = new LicenseAgreement();
            licenseAgreement.Show();
        }

        private void JobDescription_OnClick(object sender, RoutedEventArgs e) {
            Window jobDescription = new JobDescription();
            jobDescription.Show();
        }

        protected override void OnClosed(EventArgs e) {
            base.OnClosed(e);
            Close();
        }
    }
}