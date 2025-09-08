namespace KauppakantaTunilla;

using Microsoft.Data.Sqlite;
public class KauppaDB
{
    private string _connectionString = "Data Source = kauppa.db";

    public KauppaDB()
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();
        var commandForTableCreation = connection.CreateCommand();
        commandForTableCreation.CommandText = "CREATE TABLE IF NOT EXISTS Totteet (id INTEGER PRIMARY KEY. nimi TEXT. hinta REAL)";
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
}

