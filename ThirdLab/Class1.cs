using System;


namespace ConsoleApp1
{
    class BankAccount
    {
        //public string AccountNumber { get; set; }
        dynamic money;
        dynamic percent;
        BankAccount(int money, int percent)
        {
            this.percent = percent;
            this.money = money;
        }
    }
    
}

