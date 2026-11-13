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
        List<Dolgozat> lista = new List<Dolgozat>();
        public MainWindow()
        {
            InitializeComponent();
            lista.Add(new Dolgozat { Nev = "Kiss Péter", Eletkor = 16, Pontszam = 87 });
            lista.Add(new Dolgozat { Nev = "Nagy Anna", Eletkor = 17, Pontszam = 92 });
            lista.Add(new Dolgozat { Nev = "Szabó Tamás", Eletkor = 16, Pontszam = 78 });
            lista.Add(new Dolgozat { Nev = "Tóth Éva", Eletkor = 18, Pontszam = 95 });
            lista.Add(new Dolgozat { Nev = "Varga Bence", Eletkor = 17, Pontszam = 81 });
            lista.Add(new Dolgozat { Nev = "Horváth Zsolt", Eletkor = 16, Pontszam = 65 });
            lista.Add(new Dolgozat { Nev = "Molnár Réka", Eletkor = 18, Pontszam = 89 });
            lista.Add(new Dolgozat { Nev = "Lakatos Dániel", Eletkor = 17, Pontszam = 72 });
            dgDolgozatok.ItemsSource = lista;
        }
        private void BtnHozzaadas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dolgozat uj = new Dolgozat();
                uj.Nev = txtNev.Text;
                uj.Eletkor = Convert.ToInt32(txtEletkor.Text);
                uj.Pontszam = Convert.ToInt32(txtPontszam.Text);

                lista.Add(uj);

                dgDolgozatok.ItemsSource = null;
                dgDolgozatok.ItemsSource = lista;

                txtNev.Clear();
                txtEletkor.Clear();
                txtPontszam.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Hibás adat! Az életkor és a pontszám szám legyen.");
            }
        }

        private void BtnMentes_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("dolgozatok.txt");
            foreach (Dolgozat d in lista)
            {
                sw.WriteLine(d.Nev + ";" + d.Eletkor + ";" + d.Pontszam);
            }
            sw.Close();

            MessageBox.Show("Sikeres mentés!");
        }
    }
}