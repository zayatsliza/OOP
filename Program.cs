using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            double usd = 28.40;
            double eur = 33.11;
            Converter convert = new Converter(usd, eur);
            if (usd > 0 && eur > 0)
            {
                Console.WriteLine("Your UAH: ");
                double money = Convert.ToDouble(Console.ReadLine());
                if (money < 0) { Console.WriteLine(" Error "); Console.ReadKey(); }
                else
                {
                    Console.WriteLine(" it’s "); convert.UAHtoUSD(money); convert.UAHtoEUR(money);
                    Console.WriteLine("Your USD: ");
                    double money1 = Convert.ToDouble(Console.ReadLine());
                    if (money1 < 0) { Console.WriteLine(" Error "); Console.ReadKey(); }
                    else
                    {
                        Console.WriteLine(" it’s "); convert.USDtoUAH(money1);
                        Console.WriteLine("Your EUR: ");
                        double money2 = Convert.ToDouble(Console.ReadLine());
                        if (money2 < 0) { Console.WriteLine(" Error "); Console.ReadKey(); }
                        else
                        {
                            Console.WriteLine(" it’s "); convert.EURtoUAh(money2);
                            Console.ReadKey();
                        }
                    }
                }
            }
            else { Console.ReadKey(); }
        }
    }
}

class Converter
{
    private double usd, eur;
    public Converter(double usd, double eur)
    {
        if (usd <= 0 || eur <= 0) { Console.WriteLine("Error"); }
        else
        {
            this.usd = usd;
            this.eur = eur;
        }
    }
    public void UAHtoUSD(double uah)
    {
        double conv = uah / usd;
        Console.WriteLine("    " + conv + " USD \n");
    }
    public void UAHtoEUR(double uah)
    {
        double conv = uah / eur;
        Console.WriteLine(" or " + conv + " EUR \n");
    }
    public void USDtoUAH(double nusd)
    {
        double conv = nusd * usd;
        Console.WriteLine("    " + conv + " UAH \n");
    }
    public void EURtoUAh(double neur)
    {
        double conv = neur * eur;
        Console.WriteLine("    " + conv + " UAH \n");
    }
}