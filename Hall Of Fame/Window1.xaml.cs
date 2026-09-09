using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Data.Sqlite;

namespace Hall_Of_Fame
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window // hier kommt der Code hin, der den Text aus den Boxen ausliest und in die SQL-Datenbank packt
    {
        public Window1() 
        {
            InitializeComponent();
        }

        internal void W1ZurueckButton_Click(object sender, RoutedEventArgs e) // dieses Fenster wird geschlossen und das Main Window wieder geöffnet
        {
            
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void Eintragen_Click(object sender, RoutedEventArgs e) // der Eintragen-Button wird geklickt, die Inhalte der Boxen werden in die SQL-Datenbank übergeben
        {

            string connectionString = "DataSource=HOF_Datenbank.db"; // Datenquelle wird wieder als String definiert, wird später den Methoden übergeben

            using SqliteConnection connection = new SqliteConnection(connectionString); // erstellt Verbindung zu der Datenquelle
            connection.Open();

            string sql = @"
                        INSERT INTO Gewinner (SiegNr, GewinnDatum, Spielmodus, Spitzname, Spezies)
                        VALUES ($siegnr, $datum, $spielmodus, $spitzname, $spezies);";

            using SqliteCommand command = new SqliteCommand(sql, connection);

            command.Parameters.AddWithValue("$siegnr", siegnrBox.Text);
            command.Parameters.AddWithValue("$datum", datumBox.Text);
            command.Parameters.AddWithValue("$spielmodus", spielmodusBox.Text);
            command.Parameters.AddWithValue("$spitzname", spitznameBox.Text);
            command.Parameters.AddWithValue("$spezies", speziesBox.Text);

            command.ExecuteNonQuery();

            MessageBox.Show("Gewinner " + spitznameBox.Text + " wurde eingetragen!");
        
        }
    }
}
