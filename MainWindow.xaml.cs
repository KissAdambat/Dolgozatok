using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dolgozatok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Dolgozat
    {
        public string Nev { get; set; }
        public int Eletkor { get; set; }
        public int Pontszam { get; set; }
    }
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Dolgozat> dolgozatok = new ObservableCollection<Dolgozat>
        {
            new Dolgozat { Nev = "Kiss Péter",     Eletkor = 16, Pontszam = 87 },
            new Dolgozat { Nev = "Nagy Anna",      Eletkor = 17, Pontszam = 92 },
            new Dolgozat { Nev = "Szabó Tamás",    Eletkor = 16, Pontszam = 78 },
            new Dolgozat { Nev = "Tóth Éva",       Eletkor = 18, Pontszam = 95 },
            new Dolgozat { Nev = "Varga Bence",    Eletkor = 17, Pontszam = 81 },
            new Dolgozat { Nev = "Horváth Zsolt",  Eletkor = 16, Pontszam = 65 },
            new Dolgozat { Nev = "Molnár Réka",    Eletkor = 18, Pontszam = 89 },
            new Dolgozat { Nev = "Lakatos Dániel", Eletkor = 17, Pontszam = 72 },
        };
        public MainWindow()
        {
            InitializeComponent();
            lvDolgozatok.ItemsSource = dolgozatok;
        }
        private void BtnHozzaadas_Click(object sender, RoutedEventArgs e)
        {
            string nev = txtNev.Text.Trim();

            if (string.IsNullOrEmpty(nev))
            {
                MessageBox.Show("Add meg a nevet!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtNev.Focus();
                return;
            }
            if (!int.TryParse(txtEletkor.Text, out int eletkor) || eletkor <= 0)
            {
                MessageBox.Show("Az életkor pozitív egész szám legyen!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtEletkor.Focus();
                return;
            }
            if (!int.TryParse(txtPontszam.Text, out int pontszam) || pontszam < 0)
            {
                MessageBox.Show("A pontszám nem negatív egész szám legyen!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPontszam.Focus();
                return;
            }

            dolgozatok.Add(new Dolgozat { Nev = nev, Eletkor = eletkor, Pontszam = pontszam });

            txtNev.Clear();
            txtEletkor.Clear();
            txtPontszam.Clear();
            txtNev.Focus();
        }

        private void BtnMentes_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog
            {
                Filter = "Szövegfájl (*.txt)|*.txt",
                FileName = "dolgozatok.txt"
            };

            if (dlg.ShowDialog() != true) return;

            var sb = new StringBuilder();
            sb.AppendLine("Nev;Eletkor;Pontszam");
            foreach (var d in dolgozatok)
                sb.AppendLine($"{d.Nev};{d.Eletkor};{d.Pontszam}");

            File.WriteAllText(dlg.FileName, sb.ToString(), new UTF8Encoding(true));
            MessageBox.Show("Sikeres mentés!", "Mentés", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}