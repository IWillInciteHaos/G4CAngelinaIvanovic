/*
 zadatak 1: konzolna aplikacija koja se ponasa kao kalkulator za stepenovanje gde prestaje sa radom na x
 */

/*
string numberS = "";
int number = 0;

Console.WriteLine("Enter a number to multiply: ");

while(numberS.CompareTo("x") != 0)
{
	numberS = Console.ReadLine();

	try
	{
		number = Int32.Parse(numberS);
		Console.WriteLine(number + " ^ 2 = " + (number * number));
	}
	catch (Exception)
	{
		if(numberS.ToLower().CompareTo("x") != 0)
			Console.WriteLine(numberS + " is not a number.");
	}
} 
*/

/*
 zadatak 2: trazi pozitivan broj n i ispisuje n brojeva fibonacijevog niza
 */
/*
int number = -1;
string numberS = "";
int[] res;

do
{
	Console.WriteLine("Unesi pozitivan broj: ");
	numberS = Console.ReadLine();
	try
	{
		number = Int32.Parse(numberS);
		if (number > 0)
		{
			break;
		}
    }
	catch (Exception)
	{
		Console.WriteLine(numberS + " nije validan broj!");
	}
}while (number <= 0);

res = new int[number];

switch (number)
{
	case 1:
		res[0] = 1;
		break;
	case 2:
		res[0] = 1;
		res[1] = 1;
		break;
	default:
		res[0] = 1;
		res[1] = 1;
		for(int i = 2; i < number; i++)
		{
			res[i] = res[i - 1] + res[i - 2];
		}
	break;
}

Console.Write("Fibonacijev niz od "+ number + " karaktera: [");
foreach (int i in res)
{
	Console.Write(" " + i + " ");
}
Console.Write("]");
*/

/*
 iz liste numbers prikazati brojeve koji su deljivi sa brojem n unesenim preko konzole
	Enumerable.Range(start, count);
 */
/*
int start = 1;
int count = 15;
List<int> numbers = Enumerable.Range(start, count).ToList();

string numberS = "";
int number = 0;

Console.WriteLine("Unesi broj: ");
numberS = Console.ReadLine();

try
{
    number = Int32.Parse(numberS);
	Console.WriteLine("Brojevi niza koji su deljivi sa " + number + ": ");
    foreach (int num in numbers)
    {
        if (num % number == 0)
        {
            Console.Write(num + " ");
        }
    }
}
catch (Exception)
{
    if (numberS.ToLower().CompareTo("x") != 0)
        Console.WriteLine(numberS + " is not a number.");
}
*/

/*
 zadatak 4: kreirati klasu Osoba koja sadrzi polja koja oznacavaju ime, starost, pol, gde je pol enum
 */

List<Osoba> osobe = new List<Osoba>()
{
	new Osoba("Ana", 15, Pol.Z),
	new Osoba("Mia", 51, Pol.Z),
	new Osoba("Neko", 35, Pol.M),
	new Osoba("KoGod", 72, Pol.N)
};

/*
 zadatak 5: lista osoba sortiranih po broju godina, opadajuce
 */

var res = osobe.OrderByDescending(ljud => ljud.Starost);

/*var res = from ljud in osobe
		  orderby ljud.Starost descending
		  select ljud;*/

/*
 zadatak 6: imena i godine osoba grupisanih po polu
 */

var res1 = osobe.GroupBy(ljud => ljud.Pol); 
/*var res1 = from ljud in osobe
		   group ljud by ljud.Pol into polovi
		   select polovi;*/
 

foreach (var pol in res1)
{
	Console.WriteLine(pol.Key); 
	foreach (var ljud in pol)
    {
        Console.Write(ljud.Ime + " ");
		Console.Write(ljud.Starost.ToString() + " ");
		Console.WriteLine();
	}
}


/*
 
 */

enum Pol
{
	M,
	Z,
	N
}

class Osoba
{
	public string Ime { get; private set; }
	public int Starost { get; private set; }
	public Pol Pol	{ get; private set; }

	public Osoba (string ime, int starost, Pol pol)
	{
		Ime = ime;
		Starost = starost;
		Pol = pol;
	}
}



