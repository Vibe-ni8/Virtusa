namespace ATMs;


class AccountDetails
{
    internal readonly string AccountHolderName;
    internal readonly ulong AccountNumber;
    internal readonly ushort Pin;
    internal ulong Balance{get; set;}
    internal string History{get; set;}

    internal AccountDetails(string accountHolderName, ulong accountNumber, ushort pin, ulong balance)
    {
        AccountHolderName = accountHolderName;
        AccountNumber = accountNumber;
        Pin = pin;
        Balance = balance;
        History = "";
    }

}



class BankDatabase
{
    private readonly List<AccountDetails> _Accounts = new List<AccountDetails>();

    internal BankDatabase()
    {
        _Accounts.Add(new AccountDetails("VIGNESH",5123456789012345,0005,35000));
        _Accounts.Add(new AccountDetails("THIYAGU",5123456789012344,0004,50500));
        _Accounts.Add(new AccountDetails("KATHIR",5123456789012343,0003,73500));
        _Accounts.Add(new AccountDetails("YOGESH",5123456789012342,0002,39800));
        _Accounts.Add(new AccountDetails("SUKESH",5123456789012341,0001,45000));
        _Accounts.Add(new AccountDetails("SARANYA",5123456789012340,0000,42070));
        _Accounts.Add(new AccountDetails("DHARSHINI",5123456789012346,0006,38060));
        _Accounts.Add(new AccountDetails("SATHIYA PRIYA",5123456789012347,0007,88000));
        _Accounts.Add(new AccountDetails("KAVIYA DHARSHINI",5123456789012348,0008,68020));
        _Accounts.Add(new AccountDetails("KIRUTHIKA",5123456789012349,0009,103000));
    }

    internal AccountDetails GetAccountDetail(ulong accountNumber)
    {
        foreach(AccountDetails account in _Accounts)
            if(account.AccountNumber == accountNumber)
                return new AccountDetails(account.AccountHolderName,account.AccountNumber,account.Pin,account.Balance);
        return new AccountDetails("Dummy",00000000,0000,0);
    }

    internal ulong? GetBalance(ulong accountNumber, ushort pin)
    {
        foreach(AccountDetails account in _Accounts)
            if(account.AccountNumber == accountNumber && account.Pin == pin)
                return account.Balance;
        return null;
    }
    
    internal bool Credit(ulong accountNumber, ushort pin, ulong depositeAmount)
    {
        foreach(AccountDetails account in _Accounts)
            if(account.AccountNumber == accountNumber && account.Pin == pin)
            {
                account.Balance += depositeAmount;
                account.History+=String.Format("{0}   credit   {1,-10}   {2,-10}\n\n",DateTime.Now,depositeAmount,account.Balance);
                return true;
            }
        return false;
    }

    internal bool Debit(ulong accountNumber, ushort pin, ulong withdrawAmount)
    {
        foreach(AccountDetails account in _Accounts)
            if(account.AccountNumber == accountNumber && account.Pin == pin)
                if(account.Balance-withdrawAmount >= 0)
                {
                    account.Balance -= withdrawAmount;
                    account.History+=String.Format("{0}   debit    {1,-10}   {2,-10}\n\n",DateTime.Now,withdrawAmount,account.Balance);
                    return true;
                }
        return false;
    }

    internal string GetHistory(ulong accountNumber, ushort pin)
    {
        foreach(AccountDetails account in _Accounts)
            if(account.AccountNumber == accountNumber && account.Pin == pin)
                {
                    return account.History;
                }
        return "";
    }
}



class AtmCurrency
{
    internal uint TwoThousand{get; set;}
    internal uint FiveHundred{get; set;}
    internal uint TwoHundred{get; set;}
    internal uint Hundred{get; set;}
    internal uint Fifty{get; set;}
    internal uint Twenty{get; set;}
    internal uint Ten{get; set;}
    internal ulong Amount => (TwoThousand*2000)+(FiveHundred*500)+(TwoHundred*200)+(Hundred*100);

    internal AtmCurrency()
    {
        TwoThousand = 50;
        FiveHundred = 50;
        TwoHundred = 50;
        Hundred = 50;
        Fifty = 50;
        Twenty = 50;
        Ten = 50;
    }
}




class Machine
{
    private static readonly BankDatabase _Bank = new BankDatabase();
    private readonly AtmCurrency _Currency = new AtmCurrency();
    private AccountDetails _CurrentUserDetail {get; set;} = new AccountDetails("Dummy",ushort.MinValue,0000,0);



    private (bool,ushort) GetPin()
    {
        ushort pin;
        Console.Write("\nEnter PIN Number: ");
        try { pin = ushort.Parse(Console.ReadLine()+""); }
        catch(FormatException)
        {
            Console.WriteLine("\nInvalid PIN Number");
            return (false,0000);
        }
        return (true,pin);
    }



    private bool DominationOverExistCheck(uint notesGiven, uint notesPresent)
    {
        if((notesGiven+notesPresent)>100)
        {
            Console.WriteLine("\nDomination Limit Exist!");
            return true;
        }
        return false;
    }



    private void Deposite()
    {
        ushort pin;
        bool havePin;
        (havePin,pin) = GetPin();
        if(!havePin)
        {
            return;
        }

        if(_CurrentUserDetail.Pin == pin)
        {
            try
            {
                Console.Write("\nEnter No. of TwoThousand Notes: ");
                ushort twoThousand = ushort.Parse(Console.ReadLine()+"");
                if(DominationOverExistCheck(twoThousand,_Currency.TwoThousand))
                    return;
                Console.Write("Enter No. of FiveHundred Notes: ");
                ushort fiveHundred = ushort.Parse(Console.ReadLine()+"");
                if(DominationOverExistCheck(fiveHundred,_Currency.FiveHundred))
                    return;
                Console.Write("Enter No. of TwoHunded Notes: ");
                ushort twoHundred = ushort.Parse(Console.ReadLine()+"");
                if(DominationOverExistCheck(twoHundred,_Currency.TwoHundred))
                    return;
                Console.Write("Enter No. of Hundred Notes: ");
                ushort hundred = ushort.Parse(Console.ReadLine()+"");
                if(DominationOverExistCheck(hundred,_Currency.Hundred))
                    return;
                Console.Write("Enter No. of Fifty Notes: ");
                ushort fifty = ushort.Parse(Console.ReadLine()+"");
                if(DominationOverExistCheck(fifty,_Currency.Fifty))
                    return;
                Console.Write("Enter No. of Twenty Notes: ");
                ushort twenty = ushort.Parse(Console.ReadLine()+"");
                if(DominationOverExistCheck(twenty,_Currency.Twenty))
                    return;
                Console.Write("Enter No. of Ten Notes: ");
                ushort ten = ushort.Parse(Console.ReadLine()+"");
                if(DominationOverExistCheck(ten,_Currency.Ten))
                    return;

                Console.WriteLine("\nProcessing...");
                ulong previousAmount = _Currency.Amount;
                _Currency.TwoThousand += twoThousand;
                _Currency.FiveHundred += fiveHundred;
                _Currency.TwoHundred += twoHundred;
                _Currency.Hundred += hundred;
                _Currency.Fifty += fifty;
                _Currency.Twenty += twenty;
                _Currency.Ten += ten;
                ulong creditAmount = _Currency.Amount - previousAmount;
                _Bank.Credit(_CurrentUserDetail.AccountNumber,pin,creditAmount);
                Thread.Sleep(5000);
                Console.WriteLine("\nAmount Credited Successfully!");
            }
            catch(FormatException)
            {
                Console.WriteLine("\nInvalid Note Number");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid PIN Number");
        }
    }



    private void Withdraw()
    {
        if(_Currency.Amount>0)
        {
            try
            {
                Console.Write("\nEnter Amount to Withdraw: ");
                ulong withdrawAmount = ulong.Parse(Console.ReadLine()+"");
                if(withdrawAmount%10 != 0)
                {
                    Console.WriteLine("\nLowest Denomination is 10.");
                }
                else if(withdrawAmount>_Bank.GetBalance(_CurrentUserDetail.AccountNumber,_CurrentUserDetail.Pin))
                {
                    Console.WriteLine("\nInsufficient fund!");
                }
                else if(_Currency.Amount>=withdrawAmount)
                {
                    ushort pin;
                    bool havePin;
                    (havePin,pin) = GetPin();
                    if(!havePin)
                    {
                        return;
                    }

                    if(_CurrentUserDetail.Pin == pin)
                    {
                        Console.WriteLine("\nProcessing...");
                        ulong tempWithdrawAmount = withdrawAmount;
                        uint[] dispendedNotes = {0,0,0,0,0,0,0};
                        for(ushort i=1;i<=8;i++)
                        {
                            uint notes = 0;
                            ushort noteValue = 0;
                            switch(i)
                            {
                                case 1:notes=_Currency.TwoThousand;noteValue=2000;break;
                                case 2:_Currency.TwoThousand=notes;notes=_Currency.FiveHundred;noteValue=500;break;
                                case 3:_Currency.FiveHundred=notes;notes=_Currency.TwoHundred;noteValue=200;break;
                                case 4:_Currency.TwoHundred=notes;notes=_Currency.Hundred;noteValue=100;break;
                                case 5:_Currency.Hundred=notes;notes=_Currency.Fifty;noteValue=50;break;
                                case 6:_Currency.Fifty=notes;notes=_Currency.Twenty;noteValue=20;break;
                                case 7:_Currency.Twenty=notes;notes=_Currency.Ten;noteValue=10;break;
                                case 8:_Currency.Ten=notes;notes=0;noteValue=0;break;
                            }
                            while(notes>0 && tempWithdrawAmount/noteValue>0)
                            {
                                notes--;
                                dispendedNotes[i-1]++;
                                tempWithdrawAmount -= noteValue;
                            }
                        }
                        if(tempWithdrawAmount == 0)
                        {
                            _Bank.Debit(_CurrentUserDetail.AccountNumber,pin,withdrawAmount);
                            Thread.Sleep(5000);
                            Console.Write("\nPress enter to collect cash");
                            Console.ReadLine();
                            Console.WriteLine("Dispended Notes: rs.2000=>{0}, rs.500=>{1}, rs.200=>{2}, rs.100=>{3}, rs.50=>{4}, rs.20=>{5}, rs.10=>{6}",dispendedNotes[0],dispendedNotes[1],dispendedNotes[2],dispendedNotes[3],dispendedNotes[4],dispendedNotes[5],dispendedNotes[6]);
                        }
                        else
                        {
                            Console.WriteLine("Denomination Empty.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid PIN Number");
                    }
                }
                else
                {
                    Console.WriteLine("\nATM does not have enough money for your withdrawal.");
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("\nInvalid Amount");
            }
        }
        else
        {
            Console.WriteLine("\nATM is now out of money!");
        }
    }



    private void CheckBalance()
    {
        ushort pin;
        bool havePin;
        (havePin,pin) = GetPin();

        if(!havePin)
        {
            Thread.Sleep(2000);
            return;
        }

        if(_CurrentUserDetail.Pin == pin)
        {
            Console.WriteLine("\nYour current balance: {0}",_Bank.GetBalance(_CurrentUserDetail.AccountNumber,pin));
            Console.Write("Press enter to exit");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("\nInvalid PIN Number");
            Thread.Sleep(2000);
        }
    }



    private void PrintHistory()
    {
        ushort pin;
        bool havePin;
        (havePin,pin) = GetPin();

        if(!havePin)
        {
            //Thread.Sleep(2000);
            return;
        }

        if(_CurrentUserDetail.Pin == pin)
        {
            Console.WriteLine("\nTRANSACTION HISTORY\n\n"+_Bank.GetHistory(_CurrentUserDetail.AccountNumber,pin));
            Console.Write("Press enter to exit");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("\nInvalid PIN Number");
            //Thread.Sleep(2000);
        }
    }



    private void ExitBlock()
    {
        Thread.Sleep(2000);
        Console.Write("\nCollect your card by press enter");
        Console.ReadLine();
        Console.WriteLine("\nThanks for visiting KYTVS!");
        Thread.Sleep(3000);
    }



    //the method show the menu for user after successful authendication from Run Method
    private void Menu()
    {
MENU:    Console.WriteLine("\nHii {0}, You have the following options\n   1.Deposite\n   2.Withdraw\n   3.Check Balance\n   4.Show Trancsaction History\n   5.Exit",_CurrentUserDetail.AccountHolderName);
MENU2:   Console.Write("Enter your choice: ");
        ushort choice;
        try { choice = ushort.Parse(Console.ReadLine()+""); }
        catch(FormatException)
        {
            Console.WriteLine("\nWrong Input\n");
            Thread.Sleep(1000);
            goto MENU2;
        }
        switch(choice)
        {
            case 1:Deposite();break;
            case 2:Withdraw();break;
            case 3:CheckBalance();goto MENU;
            case 4:PrintHistory();break;
            case 5:Console.WriteLine("\nPlease wait....");break;
            default:Console.WriteLine("\nWrong Input\n");Thread.Sleep(1000);goto MENU2;
        }
        ExitBlock();
    }



    //Starting Method that gather user detail and Authenticate it
    internal void Run()
    {
START:  Console.WriteLine("\n******************* Welcome to KYTVS *******************");
        Console.Write("Insert Card/Enter Account Number: ");
        ulong accountNumber=000000000;
        try { accountNumber = ulong.Parse(Console.ReadLine()+""); }
        catch(FormatException)
        {
            Console.WriteLine("\nInvalid Account Number");
            ExitBlock();
            return;
            //goto START;
        }
        _CurrentUserDetail = _Bank.GetAccountDetail(accountNumber);
        if( _CurrentUserDetail.AccountNumber == accountNumber)
        {
            ushort pin;
            bool havePin;
            (havePin,pin) = GetPin();

            if(!havePin)
            {
                ExitBlock();
                return;
                //goto START;
            }

            if( _CurrentUserDetail.Pin == pin )
            {
                Menu();
            }
            else
            {
                Console.WriteLine("\nInvalid PIN Number");
                ExitBlock();
            }
        }
        else
        {
            Console.WriteLine("\nInvalid Account Number");
            ExitBlock();
        }
        //goto START;//use when machine want to run again automatically
        return;
    }
}



class Program
{
    public static void Main()
    {
        Machine machine1 = new Machine();
        Machine machine2 = new Machine();
        Machine machine3 = new Machine();
        Machine machine = machine1;
L:     Console.WriteLine("\nWhere to go?\n 1.ATM at Shollinganallur\n 2.ATM at Navallur\n 3.ATM at Egatur\n 4.Close program");
        ushort choice;
        Console.Write("Enter your choice: ");
        try{ choice = ushort.Parse(Console.ReadLine()+"");}
        catch(FormatException){Console.WriteLine("\nInvalid Choise");Thread.Sleep(1000);Console.Clear();goto L;}
        if(choice>4 || choice==0)
        {
            Console.WriteLine("\nInvalid Choice");
            Thread.Sleep(1000);
            Console.Clear();
            goto L;
        }
        switch(choice)
        {
            case 1:machine = machine1;goto case 5;
            case 2:machine = machine2;goto case 5;
            case 3:machine = machine3;goto case 5;
            case 4:break;
            case 5:machine.Run();goto case 6;
            case 6:
            {
                Console.WriteLine("\nWhat to do next?\n 1.Use ATM again\n 2.Leave");
                Console.Write("Enter your choice: ");
                try{ choice = ushort.Parse(Console.ReadLine()+"");}
                catch(FormatException){Console.WriteLine("\nInvalid Choise");Thread.Sleep(1000);goto case 6;}
                if(choice==1)
                    goto case 5;
                else if(choice==2)
                    goto L;
                else
                {
                    Console.WriteLine("\nInvalid Choise");
                    Thread.Sleep(1000);
                    goto case 6;   
                }
            }

        }
    }
}
