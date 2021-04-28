using System;

namespace Guy
{
    class Guy
    {
        string name;
        int cash;

        static void Main(string[] args)
        {
            Guy joe = new Guy { cash = 50, name = "Joe" };
            Guy bob = new Guy { cash = 100, name = "Bob" };

            while (true)
            {
                joe.WriteMyInfo();
                bob.WriteMyInfo();

                Console.Write("Enter an amount: ");
                string howMuch = Console.ReadLine();
                if (howMuch == "") return;

                if (int.TryParse(howMuch, out int amount))
                {
                    Console.Write("Who should give the cash: ");
                    string whichGuy = Console.ReadLine();
                    if (whichGuy == "Joe")
                    {
                        int cashGiven = joe.GiveCash(amount);
                        bob.ReceiveCash(cashGiven);
                    }
                    else if (whichGuy == "Bob")
                    {
                        int cashGiven = bob.GiveCash(amount);
                        joe.ReceiveCash(cashGiven);
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'Joe' or 'Bob'");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter an amount (or a blank line to exit).");
                }
            }


        }

        public void WriteMyInfo()
        {
            Console.WriteLine(name + " has " + cash + " bucks.");
        }

        public int GiveCash(int amount)
        { 
            if (amount <= 0)
            {
                Console.WriteLine(name + " says: " + amount + " isn't a valid amount");
            }
            if (amount > cash)
            {
                Console.WriteLine(name + " says: " + "I don't have anough cash to give you " + amount);
                return 0;
            }
            cash -= amount;
            return amount;
        }

        public void ReceiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(name + " says: " + amount + " isn't an amount I'll take");
            }
            else 
            {
                cash += amount;
            }
        }
    }
}
