using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace week4_BA.bl
{
    public class Account
    {
        public string AccountNumber;
        public decimal Balance; 

        public Account(string accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient balance!");
            }
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Account> Accounts { get; set; }

        public Customer(string name, int age, List<Account> accounts = null)
        {
            Name = name;
            Age = age;
            Accounts = accounts ?? new List<Account>();
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public decimal GetTotalBalance()
        {
            decimal totalBalance = 0;
            foreach (Account account in Accounts)
            {
                totalBalance += account.Balance;
            }
            return totalBalance;
        }
    }

    public class Bank
    {
        public string Name { get; set; }
        public List<Customer> Customers { get; set; }

        public Bank(string name, List<Customer> customers = null)
        {
            Name = name;
            Customers = customers ?? new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public Customer GetCustomerByName(string name)
        {
            foreach (Customer customer in Customers)
            {
                if (customer.Name == name)
                {
                    return customer;
                }
            }
            return null;
        }
    }

}
