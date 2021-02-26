using System;

public enum WybranyZnak {
	Papier,
	Nozyce,
	Kamien,
	BrakWyboru
}

public class GraczCzlowiek {
	public GraczCzlowiek() {}

	public WybranyZnak WybierzRuch() {
		while(true) {
			Console.WriteLine("1) Papier. 2) Nożyce. 3) Kamień.");
			Console.Write("Co wybierasz? ");
			string s = Console.ReadLine();
			if (s == "1") return WybranyZnak.Papier;
			else if (s == "2") return WybranyZnak.Nozyce;
			else if (s == "3") return WybranyZnak.Kamien;
			else Console.WriteLine("Nieprawidłowy wybór!");
		}
	}
}

public class GraczAutomatyczny {
	Random r = new Random();

	public GraczAutomatyczny() {}

	public WybranyZnak WybierzRuch() {
		return (WybranyZnak)r.Next(0, 3);
	}
}

public class Przyklad {
	public static void Main(string[] args) {
		var gracz1 = new GraczCzlowiek();
		var gracz2 = new GraczAutomatyczny();
		int punkty = 0;
		while (punkty < 2 && punkty > -2) {
			var wybor1 = gracz1.WybierzRuch();
			var wybor2 = gracz2.WybierzRuch();
			Console.WriteLine($"Gracz pierwszy wybrał: {wybor1}.");
			Console.WriteLine($"Gracz drugi wybrał: {wybor2}.");
			// ...
			if (wybor1 == wybor2) {
				Console.WriteLine("Remis");
			}
			else if (wybor1 == WybranyZnak.Papier) {
				if (wybor2 == WybranyZnak.Nozyce) punkty -= 1;
				else punkty += 1;
			}
			else if (wybor1 == WybranyZnak.Nozyce) {
				if (wybor2 == WybranyZnak.Kamien) punkty -= 1;
				else punkty += 1;
			}
			else if (wybor1 == WybranyZnak.Kamien) {
				if (wybor2 == WybranyZnak.Papier) punkty -= 1;
				else punkty += 1;
			}
			Console.WriteLine($"Punkty: {punkty}\n");
		}
		if (punkty >= 2) Console.WriteLine("Wygrał gracz pierwszy!");
		else Console.WriteLine("Wygrał gracz drugi!");
	}
}

