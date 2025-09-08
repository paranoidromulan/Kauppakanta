namespace KauppakantaTunilla;

using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;
public class KauppaDB
{
    private string _connectionString = "Data Source = kauppa.db";

    public KauppaDB()
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        var commandForTableCreation = connection.CreateCommand();
        commandForTableCreation.CommandText = "CREATE TABLE IF NOT EXISTS Totteet (id INTEGER PRIMARY KEY, nimi TEXT, hinta REAL)";
        commandForTableCreation.ExecuteNonQuery();
        connection.Close();
    }
    public void LisaaTuote(string nimi, double hinta)
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        var commandForInsert = connection.CreateCommand();
        commandForInsert.CommandText = "INSERT INTO Tuotteet (nimi, hinta) VALUES (@Nimi, @Hinta)";
        commandForInsert.Parameters.AddWithValue("Nimi", nimi);
        commandForInsert.Parameters.AddWithValue("Hinta", hinta);
        commandForInsert.ExecuteNonQuery();
        connection.Close();

    }

    public string HaeTuotteet(string haettavaninimi)
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        var commandForSelect = connection.CreateCommand();
        commandForSelect.CommandText = "SELECT * FROM Tuotteet WHERE nimi LIKE @Nimi";
        commandForSelect.Parameters.AddWithValue("Nimi", haettavaninimi);
        var reader = commandForSelect.ExecuteReader();
        string tuotteet = "";

        while (reader.Read())
        {
            tuotteet += $"Id: {reader.GetInt32(0)}, Nimi: {reader.GetString(1)}, Hinta: {reader.GetDouble(2)}";

        }
        reader.Close();
        connection.Close();
        if (tuotteet == "")
        {
            return "tuotetta ei löytynyt.";
        }
        else
        {
            return tuotteet;
        }
    }
}

