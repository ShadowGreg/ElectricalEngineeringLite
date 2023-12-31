﻿using System.Windows;
using System.Windows.Controls;
using CoreV01.Feeder;
using ElectricalEngineeringLiteV1.View.Consumer;
using ElectricalEngineeringLiteV1.ViewModel;

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

        private void DelConsumer_Click(object sender, RoutedEventArgs e) {
            _viewModel.DelConsumer(_viewModel.SelectedConsumer);
            _viewModel.RowsAssembly();
        }

        private void Calculate_Consumer(object sender, RoutedEventArgs e) {
            _viewModel.RowsAssembly();
            MessageBox.Show("Расчёт окончен",
                "Расчёт",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void Edit_Click(object sender, RoutedEventArgs e) {
            Window editConsumer = new EditConsumer();
            editConsumer.Show();
        }
    }
}