using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Program
    {
        static void Main(string[] args)
        {


            // Question 1
            Console.WriteLine("Question 1 Execution");
             BankAccountProgram.Run();

            // Question 2
            Console.WriteLine("Question 2 Execution");
            StudentGradeProgram.Run();

            // Question 3
            Console.WriteLine("Question 3 Execution");
            TemperatureConversionProgram.Run();

            // Question 4
            Console.WriteLine("Question 4 Execution");
            EmployeeManagementProgram.Run();

            // Question 5
            Console.WriteLine("Question 5 Execution");
            SimpleCalculatorProgram.Run();

            // Question 6
            Console.WriteLine("Question 6 Execution");
            LibraryManagementProgram.Run();

            // Question 7
            Console.WriteLine("Question 7 Execution");
            PrimeNumberCheckerProgram.Run();

            // Question 8
            Console.WriteLine("Question 8 Execution");
            CarRentalProgram.Run();

            // Question 9
            Console.WriteLine("Question 9 Execution");
            ECommerceOrderProgram.Run();

            // Question 10
            Console.WriteLine("Question 10 Execution");
            MovieTicketBookingProgram.Run();
        }
    }

    // 1. Bank Account 
    public class BankAccount
    {
        public string AccountHolder { get; private set; }
        private decimal balance;

        public BankAccount(string accountHolder, decimal initialBalance)
        {
            AccountHolder = accountHolder;
            balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Deposit must be positive");
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Withdrawal must be positive");
            if (amount > balance) throw new InvalidOperationException("Insufficient balance");
            balance -= amount;
        }

        public decimal GetBalance() => balance;
    }

    public class BankAccountProgram
    {
        public static void Run()
        {
            BankAccount account = new BankAccount("John Doe", 500M);
            account.Deposit(200M);
            Console.WriteLine($"Balance: {account.GetBalance():C}");
            account.Withdraw(100M);
            Console.WriteLine($"Final Balance: {account.GetBalance():C}");
        }
    }

    // 2. Student Grade Calculation Program
    public class StudentGradeProgram
    {
        public static void Run()
        {
            int[] marks = new int[3];
            int total = 0;

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter marks for subject {i + 1}: ");
                marks[i] = int.Parse(Console.ReadLine());
                if (marks[i] < 0 || marks[i] > 100) throw new ArgumentException("Marks must be between 0 and 100");
                total += marks[i];
            }

            double average = total / 3.0;
            char grade = average >= 90 ? 'A' : average >= 80 ? 'B' : average >= 70 ? 'C' : average >= 60 ? 'D' : 'F';
            Console.WriteLine($"Average: {average}, Grade: {grade}");
        }
    }

    // 3. Temperature Conversion Program
    public class TemperatureConversionProgram
    {
        public static void Run()
        {
            double temperature;
            char unit;

            do
            {
                Console.Write("Enter temperature (e.g., 32F or 100C): ");
                string input = Console.ReadLine();
                temperature = double.Parse(input.Substring(0, input.Length - 1));
                unit = char.ToUpper(input[input.Length - 1]);

                if (unit == 'C')
                {
                    double fahrenheit = (temperature * 9 / 5) + 32;
                    Console.WriteLine($"{temperature}C is {fahrenheit}F");
                }
                else if (unit == 'F')
                {
                    double celsius = (temperature - 32) * 5 / 9;
                    Console.WriteLine($"{temperature}F is {celsius}C");
                }

                Console.Write("Do you want to convert another temperature? (y/n): ");
            } while (Console.ReadLine().ToLower() == "y");
        }
    }

    // 4. Employee Management System
    public class Employee
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        private decimal Salary { get; set; }
        public string Department { get; private set; }

        public Employee(string name, int age, decimal salary, string department)
        {
            if (age <= 0) throw new ArgumentException("Age must be positive");
            Name = name;
            Age = age;
            Salary = salary;
            Department = department;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Department: {Department}, Salary: {Salary:C}");
        }
    }

    public class EmployeeManagementProgram
    {
        public static void Run()
        {
            Employee emp = new Employee("Alice", 30, 50000M, "HR");
            emp.DisplayDetails();
        }
    }

    // 5. Simple Calculator Program
    public class SimpleCalculatorProgram
    {
        public static void Run()
        {
            Console.Write("Enter first number: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());

            Console.Write("Enter operation (+, -, *, /): ");
            char operation = char.Parse(Console.ReadLine());

            double result = 0;

            switch (operation)
            {
                case '+': result = num1 + num2; break;
                case '-': result = num1 - num2; break;
                case '*': result = num1 * num2; break;
                case '/':
                    if (num2 == 0) throw new DivideByZeroException("Cannot divide by zero");
                    result = num1 / num2;
                    break;
                default: Console.WriteLine("Invalid operation"); break;
            }

            Console.WriteLine($"Result: {result}");
        }
    }

    // 6. Library Management System
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int CopiesAvailable { get; set; }

        public void IssueBook()
        {
            if (CopiesAvailable <= 0) throw new InvalidOperationException("No copies available");
            CopiesAvailable--;
        }

        public void ReturnBook()
        {
            CopiesAvailable++;
        }
    }

    public class LibraryManagementProgram
    {
        public static void Run()
        {
            Book book = new Book { Title = "C# Programming", Author = "John Smith", ISBN = "12345", CopiesAvailable = 3 };
            book.IssueBook();
            Console.WriteLine($"Copies left: {book.CopiesAvailable}");
        }
    }

    // 7. Prime Number Checker
    public class PrimeNumberCheckerProgram
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            if (number <= 1) Console.WriteLine("Not a prime number");
            else
            {
                bool isPrime = true;
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                Console.WriteLine(isPrime ? "Prime number" : "Not a prime number");
            }
        }
    }

    // 8. Car Rental System
    public class Car
    {
        public string Model { get; set; }
        public decimal DailyRate { get; set; }
        public bool IsAvailable { get; set; }

        public decimal RentCar(int days)
        {
            if (!IsAvailable) throw new InvalidOperationException("Car is not available for rent");
            return days * DailyRate;
        }
    }

    public class CarRentalProgram
    {
        public static void Run()
        {
            Car car = new Car { Model = "Tesla", DailyRate = 100M, IsAvailable = true };
            Console.WriteLine($"Total cost for 3 days: {car.RentCar(3):C}");
        }
    }

    // 9. E-commerce Order Management System
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public string OrderStatus { get; set; }

        public void UpdateStatus(string newStatus)
        {
            OrderStatus = newStatus;
        }

        public void DisplayOrder()
        {
            Console.WriteLine($"OrderID: {OrderID}, Customer: {CustomerName}, Amount: {Amount:C}, Status: {OrderStatus}");
        }
    }

    public class ECommerceOrderProgram
    {
        public static void Run()
        {
            Order order = new Order { OrderID = 1, CustomerName = "John Doe", Amount = 150M, OrderStatus = "Placed" };
            order.UpdateStatus("Shipped");
            order.DisplayOrder();
        }
    }

    // 10. Movie Ticket Booking System
    public class MovieTicket
    {
        public string MovieName { get; set; }
        public string ShowTime { get; set; }
        public int SeatNumber { get; set; }
        public decimal TicketPrice { get; set; }

        public decimal ApplyDiscount()
        {
            if (TicketPrice > 100M)
                return TicketPrice * 0.9M; // 10% discount
            return TicketPrice;
        }
    }

    public class MovieTicketBookingProgram
    {
        public static void Run()
        {
            MovieTicket ticket = new MovieTicket { MovieName = "Inception", ShowTime = "7 PM", SeatNumber = 12, TicketPrice = 120M };
            Console.WriteLine($"Discounted Price: {ticket.ApplyDiscount():C}");
        }
    }
}

