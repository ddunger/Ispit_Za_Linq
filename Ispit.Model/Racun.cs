namespace Ispit.Model
{
	internal class Racun
	{

		public Racun(int brojRacuna, int proizvodID, int kolicina)
		{
			BrojRacuna = brojRacuna;
			ProizvodID = proizvodID;
			Kolicina = kolicina;
		}
		public int BrojRacuna { get; set; }
		public int ProizvodID { get; set; }
		public int Kolicina { get; set; }

	}
}
