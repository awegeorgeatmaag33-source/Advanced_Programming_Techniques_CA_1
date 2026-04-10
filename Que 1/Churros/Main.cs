using System;
using System.Collections.Generic;

class Program
{
    static Queue<Order> orderQueue = new Queue<Order>();

    static void Main(string[] args)
    {
        int choice;

        do
        {
            Console.WriteLine("\nOur Available Delicious Churros:");
            Console.WriteLine("1.Please place your Order");
            Console.WriteLine("2. Deliver your Order");
            Console.WriteLine("0. Exit");
            Console.Write("Choose option: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    PlaceOrder();
                    break;

                case 2:
                    DeliverOrder();
                    break;

                case 0:
                    Console.WriteLine("Exiting system...");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

        } while (choice != 0);
    }

    static void PlaceOrder()
    {
        Console.WriteLine("\nOur Menu are as folloows:");
        Console.WriteLine("1. Churros with Coarse Sugar (Euros 5.60 cents)");
        Console.WriteLine("2. Churros with Plain Sugar (Euros 3.00 cents)");
        Console.WriteLine("3. Churros with Ice Cream (Euros 7.50 cents)");
        Console.WriteLine("4. Churros with Fillings (Euros 10.15 cents)");
        Console.WriteLine("5. Churros with Chocolate (Euros 12.69 cents)");
        Console.WriteLine("0. Back to Main Menu");

        Console.Write("Select item: ");
        int itemChoice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter quantity: ");
        int quantity = Convert.ToInt32(Console.ReadLine());

        Churros selected = null;

        switch (itemChoice)
        {
            case 1:
                selected = new Churros("Coarse Sugar", 5.60);
                break;
            case 2:
                selected = new Churros("Plain Sugar", 3.00);
                break;
            case 3:
                selected = new Churros("Ice Cream", 7.50);
                break;
            case 4:
                selected = new Churros("Fillings", 10.15);
                break;
            case 5:
                selected = new Churros("Chocolate", 12.69);
                break;
            case 0:
                Console.WriteLine("Returning to main Menu........");
                return;
            default:
                Console.WriteLine("Invalid item.");
                return;
        }

        Order order = new Order(selected, quantity);
        orderQueue.Enqueue(order);

        Console.WriteLine("Your order has been placed successfully. Your order Number is: " + order.OrderNo);
        Console.WriteLine("Here is your Total Bill: Euros " + order.PayBill());
    }

    static void DeliverOrder()
    {
        if (orderQueue.Count > 0)
        {
            Order order = orderQueue.Dequeue();
            order.DisplayOrder();
            order.CollectOrder();
        }
        else
        {
            Console.WriteLine("No orders in queue.");
        }
    }
}