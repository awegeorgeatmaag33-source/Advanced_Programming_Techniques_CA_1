public class Order
{
    private static int counter = 1;

    private int order_no;
    private Churros order_details;
    private int quantity;
    private double bill;

    // Constructor
    public Order(Churros order_details, int quantity)
    {
        this.order_no = counter++;
        this.order_details = order_details;
        this.quantity = quantity;
    }

    // Properties
    public int OrderNo
    {
        get { return order_no; }
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    // Method to calculate bill
    public double PayBill()
    {
        bill = order_details.Price * quantity;
        return bill;
    }

    public void CollectOrder()
    {
        Console.WriteLine("Your Order " + order_no + " has been collected.");
    }

    public void DisplayOrder()
    {
        Console.WriteLine("Order No: " + order_no);
        Console.WriteLine("Item: " + order_details.Name);
        Console.WriteLine("Quantity: " + quantity);
        Console.WriteLine("Your Total Bill: Euros " + PayBill());
    }
}