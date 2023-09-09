using System;

public class cardHolder
{
    string cardNum;
    int pin;
    string PrimeiroNome;
    string UltimoNome;
    double balance;

    public cardHolder(string cardNum, int pin, string PrimeiroNome, string UltimoNome, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.PrimeiroNome = PrimeiroNome;
        this.UltimoNome = UltimoNome;   
        this.balance = balance;

    }

    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getPrimeiroNome()
    {
        return PrimeiroNome;
    }

    public string getUltimoNome() 
    { return UltimoNome; 
    
    
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum (string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setPrimeiroNome(string newPrimeiroNome)
    {
        PrimeiroNome = newPrimeiroNome;
    }

    public void setUltimoNome(string newUltimoNome)
    {
        UltimoNome = newUltimoNome;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is:" +currentUser.getBalance());
        }

        void Withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdraw = double.Parse(Console.ReadLine());
            //Check if the user has enough money
            if(currentUser.getBalance() > withdraw)
            {
                Console.WriteLine("Insufficient balance: (");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("You're good to go! Thank You :)");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("43567840917", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new cardHolder("98647628494", 3456, "Ashley", "Jones", 321.13));
        cardHolders.Add(new cardHolder("51234567899", 9999, "Frida", "Dickerson", 105.59));
        cardHolders.Add(new cardHolder("87356471389", 2468, "Muneeb", "Harding", 851.84));
        cardHolders.Add(new cardHolder("76825468373", 4826, "Dawn", "Smith", 54.27));

        // Prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }

        Console.WriteLine("Welcome" + currentUser.getPrimeiroNome() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { Withdraw(currentUser); }
            else if(option==3) { balance(currentUser); }
            else if(option==4) { break; }
            else { option= 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! have a nice day :)");
    }

        

}
