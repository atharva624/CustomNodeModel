using FilterNode;
using System.Windows.Controls;

namespace CustomDynamoNodes
{
    public partial class DropdownFilterNodeView : UserControl
    {
        private DropdownFilterNode _node;

        public DropdownFilterNodeView(DropdownFilterNode node)
        {
            InitializeComponent();
            _node = node;

            // Bind ComboBox items to node items
            DropdownComboBox.ItemsSource = _node.Items;
            DropdownComboBox.SelectedItem = _node.SelectedItem;
        }

        private void DropdownComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DropdownComboBox.SelectedItem != null)
            {
                _node.SelectedItem = DropdownComboBox.SelectedItem.ToString();
            }
        }
    }
}
