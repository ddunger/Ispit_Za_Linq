using System;
using System.Collections.Generic;
using System.Linq;

namespace Ispit.Model
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var ListaProizvoda = new List<Proizvod>()
			{
				new Proizvod (1, "Čokolada - za kuhanje"),
				new Proizvod (2, "Lino Lada - Gold"),
				new Proizvod (3, "Papir za pečenje"),
				new Proizvod (4, "Brašno - pšenično"),
				new Proizvod (5, "Šećer - standard"),
			};

			var ListaRacuna = new List<Racun>()
			{
				new Racun(100, 3, 800),
				new Racun(101, 2, 650),
				new Racun(102, 3, 900),
				new Racun(103, 4, 700),
				new Racun(104, 3, 900),
				new Racun(105, 4, 650),
				new Racun(106, 1, 458)
			};

			//Slika1

			var upit1 = from p in ListaProizvoda
						select p;

			//var upit1 = ListaProizvoda.OrderBy(p => p.ProizvodID).ToList();

			Console.WriteLine("Ovdje je popis proizvoda:\n============================================");

			foreach (var p in upit1)
			{
				Console.WriteLine($"ID: {p.ProizvodID}, Naziv: {p.Naziv}");
			}

			//Slika2

			var upit2 = from r in ListaRacuna
						orderby r.BrojRacuna
						select r;

			//var upit2 = ListaRacuna.OrderBy(r => r.BrojRacuna).ToList();

			Console.WriteLine("\n\nOvdje je popis računa:\n============================================");

			foreach (var r in upit2)
			{
				Console.WriteLine($"BrojRacuna: {r.BrojRacuna}, ID proizvoda: {r.ProizvodID}, Količina: {r.Kolicina}");
			}

			//Sortiranje

			var SortiraniProizvodi = from p in ListaProizvoda
									 orderby p.Naziv ascending
									 select p;

			Console.WriteLine("\n\nProizvodi sortirani po nazivu:\n============================================");

			foreach (var sortirano in SortiraniProizvodi)
			{
				Console.WriteLine($"{sortirano.Naziv}");
			}

			//Join

			var ListaSpojenihPodataka = from p in ListaProizvoda
										join r in ListaRacuna on p.ProizvodID equals r.ProizvodID
										select new
										{
											IDproizvoda = p.ProizvodID,
											NazivProizvoda = p.Naziv,
											KolicinaProizvoda = r.Kolicina
										};

			var ListaSpojenihPodataka2 = ListaProizvoda.Join(
										 ListaRacuna,
										 p => p.ProizvodID,
										 r => r.ProizvodID,
										 (p, r) => new
										 {
										 	IDproizvoda = p.ProizvodID,
										 	NazivProizvoda = p.Naziv,
										 	KolicinaProizvoda = r.Kolicina
										 }).ToList();

			Console.WriteLine("\n\nID proizvoda:    Naziv Proizvoda:         Kupljena količina:\n============================================================");

			foreach (var spojeno in ListaSpojenihPodataka)
			{
				Console.WriteLine($"{spojeno.IDproizvoda,-16} {spojeno.NazivProizvoda,-35} {spojeno.KolicinaProizvoda}");
			}


			Console.ReadLine();
		}
	}
}
