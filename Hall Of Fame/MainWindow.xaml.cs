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

namespace Hall_Of_Fame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window // ist nur für die Navigation
    {
        public MainWindow() // macht das Main Window auf, startet App
        {
            InitializeComponent();

            Database database = new Database(); // erstellt ein neues Objekt der von mir erstellten Klasse Database, damit die Methoden dort durchgeführt werden können
            database.DeleteTable();
            database.Initialize(); // führt die Methode Initialize durch, die eine Verbindung zu SQLite herstellt und eine neue Tabelle erstellt, sollte sie noch nicht existieren
        }

        internal void EintragenButton_Click(object sender, RoutedEventArgs e) // klick auf den Eintragen-Button, öffnet Eintragen-Fenster und schließt Main Fenster
        {
        
            Window1 window = new Window1();
            window.Show();
            this.Close();
        }

        internal void AnsehenButton_Click(Object sender, RoutedEventArgs e) // klick auf den Ansehen-Button, öffnet Ansehen-Fenster und schließt Main Fenster
        {
            Window2 window = new Window2();
            window.Show();
            this.Close();
        
        
        }
    }
}