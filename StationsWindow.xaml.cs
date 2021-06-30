using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace exam_8
{
    /// <summary>
    /// Interaction logic for StationsWindow.xaml
    /// </summary>
    public partial class StationsWindow : Window
    {
        private readonly BaseModel ctx = new BaseModel();

        public List<Station> SourceItems { get; private set; }
        public ICollectionView Items { get; private set; }
        public StationsWindow()
        {
            InitializeComponent();
            SourceItems = ctx.Stations.ToList();
            Items = CollectionViewSource.GetDefaultView(SourceItems);
            MainGrid.ItemsSource = Items;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBox.Text)) {
                Items.Filter = null;
                return;
            }
            var trimmed = SearchBox.Text.Trim().ToLowerInvariant();
            var sel = ((ComboBoxItem)SearchType.SelectedItem)?.Content;
            switch (sel)
            {
                case "Name":
                    Items.Filter = (o) => ((Station)o).Name.ToLower().Contains(trimmed);
                    break;
                case "Line name":
                    Items.Filter = (o) => ((Station)o).MetroLine.Name.ToLower().Contains(trimmed);
                    break;
                case "Exit count":
                    Items.Filter = (o) => ((Station)o).CountOfExits.ToString().ToLower().Contains(trimmed);
                    break;
                case "Address":
                    Items.Filter = (o) => ((Station)o).Address.ToLower().Contains(trimmed);
                    break;
                default:
                    Items.Filter = null;
                    break;
            }
            MainGrid.Items.Refresh();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var o in MainGrid.SelectedItems)
            {
                var i = (Station)o;
                ctx.Stations.Remove(i);
                SourceItems.Remove(i);
            }

            //one is enough ??
            Items.Refresh();
            MainGrid.Items.Refresh();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //New items
            foreach (var x in SourceItems.Where(x => x.Id == 0))
                ctx.Stations.Add(x);
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error saving changes to db");
            }
        }
    }
}
