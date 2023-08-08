using System.Windows;
using System.Windows.Controls;

namespace ElectricalEngineeringLiteV1.View.CenterFrame.DistributionNetworkTable {
    public partial class DistributionNetworkTable: Page {
        private readonly ViewModel.ViewModel _viewModel;
        public DistributionNetworkTable() {
            InitializeComponent();
            _viewModel = (ViewModel.ViewModel)Application.Current.Resources["ViewModel"];
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e) {
            var temp2 = e;
            _viewModel.SelectedObject = ((Node)e.NewValue).BaseNode;
        }
    }
}