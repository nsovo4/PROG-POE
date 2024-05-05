using System;
using System.Collections.Generic;

class Account {
    public string AccountNumber { get; }
    public string OwnerName { get; }
    public double Balance { get; private set; }

    public Account(string accountNumber, string ownerName, double initialBalance) {
        AccountNumber = accountNumber;
        OwnerName = ownerName;
        Balance = initialBalance;
    }

    public void Deposit(double amount) {
        Balance += amount;
        Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
    }

    public void Withdraw(double amount) {
        if (Balance >= amount) {
            Balance -= amount;
            Console.WriteLine($"Withdrawn {amount:C}. New balance: {Balance:C}");
        } else {
            Console.WriteLine("Insufficient funds.");
        }
    }
}

class Bank {
    private List<Account> accounts = new List<Account>();

    public void AddAccount(Account account) {
        accounts.Add(account);
    }

    public Account FindAccount(string accountNumber) {
        return accounts.Find(acc => acc.AccountNumber == accountNumber);
    }
}

class Program {
    static void Main(string[] args) {
        Bank bank = new Bank();

        // Create some accounts
        Account account1 = new Account("123456", "John Doe", 1000);
        Account account2 = new Account("789012", "Jane Smith", 500);

        bank.AddAccount(account1);
        bank.AddAccount(account2);

        // Demonstration
        Console.WriteLine("Welcome to the Banking System");

        bool running = true;
        while (running) {
            Console.WriteLine("\n1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. View Balance");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    Console.Write("Enter Account Number: ");
                    string accNumDeposit = Console.ReadLine();
                    Account depositAccount = bank.FindAccount(accNumDeposit);
                    if (depositAccount != null) {
                        Console.Write("Enter amount to deposit: ");
                        double amountDeposit = Convert.ToDouble(Console.ReadLine());
                        depositAccount.Deposit(amountDeposit);
                    } else {
                        Console.WriteLine("Account not found.");
                    }
                    break;
                case "2":
                    Console.Write("Enter Account Number: ");
                    string accNumWithdraw = Console.ReadLine();
                    Account withdrawAccount = bank.FindAccount(accNumWithdraw);
                    if (withdrawAccount != null) {
                        Console.Write("Enter amount to withdraw: ");
                        double amountWithdraw = Convert.ToDouble(Console.ReadLine());
                        withdrawAccount.Withdraw(amountWithdraw);
                    } else {
                        Console.WriteLine("Account not found.");
                    }
                    break;
                case "3":
                    Console.Write("Enter Account Number: ");
                    string accNumBalance = Console.ReadLine();
                    Account balanceAccount = bank.FindAccount(accNumBalance);
                    if (balanceAccount != null) {
                        Console.WriteLine($"Account Balance: {balanceAccount.Balance:C}");
                    } else {
                        Console.WriteLine("Account not found.");
                    }
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Banking System!");
    }
}

