namespace Ispit.Model
{
	internal class Proizvod
	{

		public Proizvod(int proizvodID, string naziv)
		{
			ProizvodID = proizvodID;
			Naziv = naziv;
		}
		public int ProizvodID { get; set; }
		public string Naziv { get; set; }
	}

}

