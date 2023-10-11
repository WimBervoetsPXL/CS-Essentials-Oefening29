using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Oefening29
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StringBuilder sb = new StringBuilder();
        public MainWindow()
        {
            InitializeComponent();
        }

        private double Bereken(double x, double y, string bewerking)
        {
            switch(bewerking)
            {
                case "+":
                    return x + y;
                    
                case "-": 
                    return x - y;
                
                case "x": 
                    return x * y;

                case "/":
                    return x / y;

                default:
                    return 0;
            }
        }
        /// <summary>
        /// Returns true when both numbers are valid doubles, the actual values are returned via out parameters but only when the input is valid
        /// </summary>
        private bool LeesGetallen(out double getal1, out double getal2)
        {
            if (double.TryParse(TxtGetal1.Text, out getal1) & double.TryParse(TxtGetal2.Text, out getal2))
                return true;
            else
            {
                getal1 = 0; 
                getal2 = 0;
                return false;   
            }
        }   
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Gebruik de tekst (content) van de knop om te bepalen welke bewerking moet worden uitgevoerd (+, -, x of /)
            Button btn = sender as Button;
            string bewerking = btn.Content.ToString();

            double getal1, getal2;
            
            if(LeesGetallen(out getal1, out getal2))
            {
                double uitkomst = Bereken(getal1, getal2, bewerking);
                //Voeg een lijn toe aan de stringBuilder om een historiek van alle bewerkingen bij te houden:
                sb.AppendLine($"{getal1} {bewerking} {getal2} = {uitkomst}");
                //Toon de historiek in de textbox:
                TxtResultaat.Text = sb.ToString();
                TxtResultaat.ScrollToEnd(); //Zorgt ervoor dat de laatste regel van de textbox altijd zichtbaar is
            }

            TxtGetal1.Focus();
            TxtGetal1.SelectAll();
        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxtResultaat.Clear();
            sb.Clear();

            TxtGetal1.Clear();
            TxtGetal2.Clear();
            TxtGetal1.Focus();
        }
    }
}
