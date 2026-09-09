using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using Microsoft.Data.Sqlite; // nutzt Klassen und Methoden aus diesem Pack, das ich über NuGet installiert habe

namespace Hall_Of_Fame
{
    internal class Database // das hier ist die Klasse für die SQL-Datenbank
    {
        private const string ConnectionString = "Data Source=HOF_Datenbank.db"; // ich initialisiere diese Variable, dann muss ich nicht immer DataSource=... schreiben.

        public void Initialize() // lässt eine Datenbank erstellen, wenn diese noch nicht existieren sollte
        {
            using SqliteConnection connection = new SqliteConnection(ConnectionString); // diese SqliteConnection mit dem übergebenen ConnectionString wird erstellt und in die Variable connection gepackt
            connection.Open(); // es wird eine Verbindung zu dieser Connection hergestellt via dem oben definierten ConnectionString, der die Datenquelle angibt.

            string sql = @"
                    CREATE TABLE IF NOT EXISTS Gewinner (Id INTEGER PRIMARY KEY, SiegNr TEXT NOT NULL, GewinnDatum TEXT NOT NULL, Spielmodus TEXT NOT NULL, Spitzname TEXT NOT NULL, Spezies TEXT NOT NULL);";

            using SqliteCommand command = new SqliteCommand(sql, connection);
            command.ExecuteNonQuery();
          
        }

        public void DeleteTable() // falls ich die Tabelle nochmal anpassen muss packe ich diese Methode vor initialize rein damit die Tabelle gelöscht wird damit sie neu erstellt werden kann. Wird dann wieder rausgenommen
        {
            using SqliteConnection connection = new SqliteConnection(ConnectionString);
            connection.Open();

            string deleteTable = "DROP TABLE IF EXISTS Gewinner;";

            using SqliteCommand deleteCommand =
                new SqliteCommand(deleteTable, connection);

            deleteCommand.ExecuteNonQuery();
        }

    }
}
