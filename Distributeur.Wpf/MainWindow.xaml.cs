using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Distributeur.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ProductenOpvullen();
            Munten();
        }

        enum Producten
        {
            Water = 170,
            Cola = 180,
            Twix = 190,
            Wafel = 200
        }

        private void ProductenOpvullen()
        {
            lstArtikels.Items.Add((Producten)170);
            lstArtikels.Items.Add((Producten)180);
            lstArtikels.Items.Add((Producten)190);
            lstArtikels.Items.Add((Producten)200);      
        }

        private void Munten()
        {
            lstInworp.ItemsSource = geld; 
        }

        decimal[] geld = new decimal[5] { 0.10M, 0.20M, 0.50M, 1.00M, 2.00M };
        int[] betaald = new int[5];
        decimal waarde;
        int optel;
        private void lstArtikels_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Producten product = (Producten)lstArtikels.SelectedItem;
            waarde = (decimal)product;
            waarde = waarde / 100;
            lblGekozenArtikel.Content = ($"{product} \t {waarde}");

        }

        private void lstInworp_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Betalingen();
            ReedsontvangenBedrag();
        }

        private void Betalingen()
        {
            optel = betaald[lstInworp.SelectedIndex];
            betaald[lstInworp.SelectedIndex] = optel + 1;
            Debug.Print(optel.ToString());
            lblSamenVatting.Content = "0,10:" + "\t" + betaald[0] + " stuks \n" +
                "0,20:" + "\t" + betaald[1] + " stuks \n" +
                "0,50:" + "\t" + betaald[2] + " stuks \n" +
                "1,00:" + "\t" + betaald[3] + " stuks \n" +
                "2,00:" + "\t" + betaald[4] + " stuks \n";
        }
        
        private void ReedsontvangenBedrag()
        {
            int i = 0;
            decimal reeds = 0;
            while(i < betaald.Length)
            {
                reeds += betaald[i] * geld[i];
                i++;
            }
            
            lblL.Content = reeds + "€";
        }



    }

}
