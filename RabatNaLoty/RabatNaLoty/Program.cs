namespace RabatNaLoty
{
    internal class Program
    {
        static void Main(string[] args)
        {
        Start:
            int rabatWiek = 0;
            int rabatKlient = 0;
            int rabatDlugaRezerwacja = 0;
            int rabatPozaSezonem = 0;
            int wiek = 0;
            string klient = "";
            Console.WriteLine("Jaki lot wybierasz?\nJeżeli jest to lot międzynarodowy napisz 1, w przeciwnym wypadku napisz 2");
            int liczba = Convert.ToInt32(Console.ReadLine());
            string rodzajLotu = "zero";
            if (liczba == 1)
            {
                rodzajLotu = "Międzynarodowy";
            }
            else if (liczba == 2)
            {
                rodzajLotu = "Krajowy";
            }
            else
            {
                Console.WriteLine("Błędne dane, spróbuj ponownie\n");
                goto Start;
            }
            Console.WriteLine("\nPodaj wiek");
            wiek = Convert.ToInt32(Console.ReadLine());
            if (wiek < 2 && wiek >= 0 && liczba == 2)
            {
                rabatWiek = 80;
            }
            else if (wiek < 2 && wiek >= 0 && liczba == 1)
            {
                rabatWiek = 70;
            }
            else if (wiek >= 2 && wiek <= 16)
            {
                rabatWiek = 10;
            }
            else if (wiek >= 17)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("\nBłędne dane, spróbuj ponownie\n");
                goto Start;
            }


            Console.WriteLine("Podaj datę dzień/miesiąc/rok odlotu ");
            string odbierzDate = Console.ReadLine();
            var czyDataPrawdziwa = DateTime.Parse(odbierzDate);
            int rok = czyDataPrawdziwa.Year;
            int miesiac = czyDataPrawdziwa.Month;

            DateTime dataZima1 = new DateTime(rok, 12, 20);
            DateTime dataZima2 = new DateTime(rok, 01, 10);
            DateTime okresWiosenny1 = new DateTime(rok, 03, 20);
            DateTime okresWiosenny2 = new DateTime(rok, 04, 10);
            DateTime okresLetni1 = new DateTime(rok, 07, 01);
            DateTime okresLetni2 = new DateTime(rok, 08, 31);
            //DateTime okresPozaSezonem1 = new DateTime(rok, 01, 11);
            //DateTime okresPozaSezonem2 = new DateTime(rok, 03, 19);
            //DateTime okresPozaSezonem3 = new DateTime(rok, 04, 11);
            //DateTime okresPozaSezonem4 = new DateTime(rok, 06, 30);
            //DateTime okresPozaSezonem5 = new DateTime(rok, 09, 01);
            //DateTime okresPozaSezonem6 = new DateTime(rok, 12, 19);

            DateTime dzisiejszaData = DateTime.Today;

            DateTime okresZimowy1 = dataZima1.AddYears(0);
            DateTime okresZimowy2 = dataZima2;
            if (miesiac == 1)
            {
                okresZimowy1 = dataZima1.AddYears(-1);
            }
            else if (miesiac == 12)
            {
                okresZimowy2 = dataZima2.AddYears(1);
            }

            TimeSpan diff1 = dzisiejszaData.Subtract(czyDataPrawdziwa);
            int days = 0;
            days = (int)diff1.TotalDays;

            if (days < -150)
            {
                
                rabatDlugaRezerwacja = 10;
            }
            else
            {
               
            }
            if (czyDataPrawdziwa >= okresZimowy1 && czyDataPrawdziwa <= okresZimowy2)
            {
                Console.WriteLine("Jesteś w okresie zimowym \n");
            }
            else if (czyDataPrawdziwa >= okresWiosenny1 && czyDataPrawdziwa <= okresWiosenny2)
            {
                Console.WriteLine("Jesteś w okresie wiosennym \n");
            }
            else if (czyDataPrawdziwa >= okresLetni1 && czyDataPrawdziwa <= okresLetni2)
            {
                Console.WriteLine("Jesteś w okresie letnim \n");
            }
            else
            {
                if (liczba == 1)
                {
                    rabatPozaSezonem = 15;
                    Console.WriteLine("\nPrzysługuje ci rabat, za podróżowanie poza sezonem");
                }
            }
            if (wiek >= 18)
            {
                Console.WriteLine("Czy jesteś stałym klientem ?");
                klient = Console.ReadLine().Trim().ToLower();
            }
            if (wiek >= 18 && klient == "tak")
            {
                rabatKlient = 15;
                Console.WriteLine("\nPrzysługuje ci rabat za stałego klienta ");
            }
            else
            {
                Console.WriteLine();
            }
            int rabatSuma = rabatKlient + rabatWiek + rabatDlugaRezerwacja + rabatPozaSezonem;
            if (wiek < 2 && rabatSuma > 80)
            {
                rabatSuma = 80;
            }
            else if (wiek >= 2 && rabatSuma > 30)
            {
                rabatSuma = 30;
            }
            else if (liczba == 1 && wiek >= 2 && czyDataPrawdziwa >= okresZimowy1 && czyDataPrawdziwa <= okresZimowy2)
            {
                rabatSuma = 0;
                Console.WriteLine("Podróżujesz w sezonie, dla lotu międzynarodowego nie ma rabatu ");
            }
            else if (liczba == 1 && wiek >= 2 && czyDataPrawdziwa >= okresWiosenny1 && czyDataPrawdziwa <= okresWiosenny2)
            {
                rabatSuma = 0;
                Console.WriteLine("Podróżujesz w sezonie, dla lotu międzynarodowego nie ma rabatu ");
            }
            else if (liczba == 1 && wiek >= 2 && czyDataPrawdziwa >= okresLetni1 && czyDataPrawdziwa <= okresLetni2)
            {
                rabatSuma = 0;
                Console.WriteLine("Podróżujesz w sezonie, dla lotu międzynarodowego nie ma rabatu ");
            }
            Console.WriteLine("Dotychczasowe zebrane informacje\n");
            Console.WriteLine("Wiek pasażera: " + wiek + "\n" + "Rodzaj lotu: " + rodzajLotu);
            Console.WriteLine("Data odlotu: " + czyDataPrawdziwa.ToShortDateString());
            Console.WriteLine("Rabat wynosi: " + rabatSuma + " %");
        }
    }
}