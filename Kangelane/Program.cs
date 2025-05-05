using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Kangelane
{
    private string nimi;
    private string asukoht;
    public string Nimi
    {
        get { return nimi; }
        set
        {
            if (value.Length > 2)
                nimi = value;
        }
    }
    public string Asukoht
    {
        get { return asukoht; }
        set
        {
            if (value == "Tallnn" || value == "Tartu" || value == "Narva" || value == "Parnu")
                asukoht = value;
        }
    }
    //public Kangelane(string nimivar, string asukohtvar)
    //{
    //    Nimi = nimivar;
    //    Asukoht = asukohtvar;
    //}
    public Kangelane(string nimi, string asukoht)
    {
        Nimi = nimi;
        Asukoht = asukoht;
    }
    public virtual int Paasta(int ohus)
    {
        return (int)Math.Round(ohus * 0.95);
    }
    public virtual string Vormiriietus()
    {
        return ("Vaga ilus riietus");
    }
    public virtual string Tervitus()
    {
        return($"Hola from {nimi}");
    }
    public virtual string MissiooniStaatus()
    {
        string answer;
        Random rand = new Random();
        int randomNumber = rand.Next(100);
        if (randomNumber <= 80)
        {
            answer = "Free";
        }
        else
        {
            answer = "Busy";
        }
        return answer;
    }
    public override string ToString()
    {
        return ("One of the most powerful heroes");
    }
}
class SuperKangelane : Kangelane
{
    public double osavus;
    public void SuperKangelaneOsavus()
    {
        Random rnd = new Random();
        osavus = Math.Round(rnd.NextDouble() * (5.0 - 1.0) + 1.0, 2);
    }
    public SuperKangelane(string nimi, string asukoht) : base(nimi, asukoht)//base - вызывает конструктор базового класса Kangelane,
    {
        SuperKangelaneOsavus();
    }
    public override int Paasta(int ohus)
    {
        //int osavus = (int)Math.Round(osavus);
        //double temp_var = ohus + osavus * 10;
        //int pOhus = (int)Math.Round(ohus + temp_var/ 100);
        //Console.WriteLine(ohus);
        ohus = (int)Math.Round(ohus * 0.95);
        //Console.WriteLine(ohus);
        int osavusaa = (int)Math.Round(osavus * 10);
        //Console.WriteLine(osavusaa);
        int pOhus = (ohus + osavusaa);
        return pOhus;
    }
    public override string Vormiriietus()
    {
        return "Suuuuper hero costume";
    }
    public override string Tervitus()
    {
        return $"HELOOOU FROM SUPER HEROOOO {Nimi}";
    }
    public override string MissiooniStaatus()
    {
        return "Sory but i'm busy right now";
    }
    public override string ToString()
    {
        return $"The hero is more effective for {osavus} that a hero";
    }
}
class Program
{
    static List<Kangelane> kangelased = new List<Kangelane>();
    public static void LoeKangelasedFailist()
    {
        //List<Kangelane> kangelased = new List<Kangelane>(); 
        try
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:\\Users\\zange\\source\\repos\\Kangelane\\Kangelane\\andmed.txt");
            char symbol = '/';
            foreach (string rida in File.ReadAllLines(path))
            {

                string[] andmed = rida.Split(symbol);
                string nimi = andmed[0].Trim();//trim - пробелы пока
                string asukoht = andmed[1].Trim();
                if (nimi.Contains("*"))
                {
                    kangelased.Add(new SuperKangelane(nimi, asukoht));//супер
                }
                else
                {
                    kangelased.Add(new Kangelane(nimi, asukoht));//Обычый
                }
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Viga failiga!");
        }
    }
    public static void Main(string[] args)
    {
        //Kangelane kangelane = new Kangelane();
        //string ff = kangelane.MissiooniStaatus();
        //Console.WriteLine(ff);
        LoeKangelasedFailist();
        foreach (Kangelane kangelane in kangelased)
        {
            if (kangelane is SuperKangelane superkangelane)
            {
                Console.WriteLine("Super");
                Console.WriteLine("Paasta: " + superkangelane.Paasta(1000));
                Console.WriteLine(superkangelane.ToString());
                Console.WriteLine("Vormiriietus: " + superkangelane.Vormiriietus());
                Console.WriteLine("Tervitus: " + superkangelane.Tervitus());
                Console.WriteLine("MissiooniStaatus: " + superkangelane.MissiooniStaatus());
            }
            else
            {
                Console.WriteLine("Tavaline");
                Console.WriteLine("Paasta : " + kangelane.Paasta(1000));
                Console.WriteLine(kangelane.ToString());
                Console.WriteLine("Vormiriietus: " + kangelane.Vormiriietus());
                Console.WriteLine("Tervitus: " + kangelane.Tervitus());
                Console.WriteLine("MissiooniStaatus: " + kangelane.MissiooniStaatus());
            }
        }

        Console.ReadKey();
    }
}
