using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static YaKalendar.SerDeser;

namespace YaKalendar
{
    public partial class MainWindow : Window
    {
        List<Zametk> zametka = new List<Zametk>();
        public MainWindow()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = desktopPath + "/AAA.json";
            Serialize(zametka, path);
            InitializeComponent();
            DatePicker.SelectedDate = DateTime.Now;
        }

        private void Zam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Zametk selectedZametk = (Zametk)Zam.SelectedItem;
            if (selectedZametk != null)
            {
                _1.Text = selectedZametk.name;
                _2.Text = selectedZametk.description;
            }
            else 
            {
                _1.Text = null;
                _2.Text = null;
            }

        }

        private void D_Click(object sender, RoutedEventArgs e)
        {
            int selected = Zam.SelectedIndex;
            zametka.RemoveAt(selected);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = desktopPath + "/AAA.json";
            Serialize(zametka, path);
            var allZametki = Deserialize<List<Zametk>>(path);
            var selectedDate = Convert.ToDateTime(DatePicker.SelectedDate);
            var filteredZametki = allZametki.Where(z => z.date.Date == selectedDate).ToList();
            Zam.ItemsSource = filteredZametki;
            Zam.Items.Refresh();
            Zam.UnselectAll();
        }

        private void c_Click(object sender, RoutedEventArgs e)
        {
            string name = _1.Text;
            string description = _2.Text;
            DateTime date = Convert.ToDateTime(DatePicker.Text);
            Zametk z = new Zametk(name, description, date);
            zametka.Add(z);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = desktopPath + "/AAA.json";
            Serialize(zametka, path);
            var allZametki = Deserialize<List<Zametk>>(path);
            var selectedDate = Convert.ToDateTime(DatePicker.Text);
            var filteredZametki = allZametki.Where(za => za.date.Date == selectedDate).ToList();
            Zam.ItemsSource = filteredZametki;
            Zam.Items.Refresh();
        }

        private void s_Click(object sender, RoutedEventArgs e)
        {
            Zametk selectedZametk = (Zametk)Zam.SelectedItem;
            selectedZametk.name = _1.Text;
            selectedZametk.description = _2.Text;
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = desktopPath + "/AAA.json";
            Serialize(zametka, path);
            zametka = Deserialize<List<Zametk>>(path);
            Zam.Items.Refresh();
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = desktopPath + "/AAA.json";
            var allZametki = Deserialize<List<Zametk>>(path);
            var selectedDate = Convert.ToDateTime(DatePicker.SelectedDate);
            var filteredZametki = allZametki.Where(za => za.date.Date == selectedDate).ToList();
            Zam.ItemsSource = filteredZametki;
            Zam.Items.Refresh();
        }
    }
}
