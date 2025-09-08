namespace KauppakantaTunilla;

using Microsoft.Data.Sqlite;
class Program
{
    static void Main(string[] args)
    {
        KauppaDB kauppaDB = new KauppaDB();
        while (true)
        {
            Console.WriteLine("Haluatko lisätä tuotteen (L), hakea (H), vai lopettaa (X)?");
            string? vastaus = Console.ReadLine();

            switch (vastaus)
            {
                case "L":
                    Console.WriteLine("Anna tuotteen nimi:");
                    string? nimi = Console.ReadLine();
                    Console.WriteLine("Anna tuotteen hinta:");
                    double hinta = Convert.ToDouble(Console.ReadLine());
                    kauppaDB.LisaaTuote(nimi, hinta);
                    break;

                case "H":
                    Console.WriteLine("Anna haettavan tuotteen nimi");
                    string? haettavaninimi = Console.ReadLine();
                    string tuotteet = kauppaDB.HaeTuotteet(haettavaninimi);
                    Console.WriteLine(tuotteet);
                    break;

                case "X":
                    return;

                default:
                    Console.WriteLine("Väärä valinta. Anna L, H tai X.");
                    break;
            }
        }
    }
}
