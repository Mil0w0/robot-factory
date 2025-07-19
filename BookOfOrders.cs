namespace RobotFactory;

public class BookOfOrders
{
    
    private static BookOfOrders? instance;
    private List<Order> orders = new List<Order>();

    private BookOfOrders() {}

    public static BookOfOrders Instance
    {
        get
        {
            if (instance == null)
                instance = new BookOfOrders();
            return instance;
        }
    }
    
    public int AddOrder(Dictionary<string, int> robots)
    {
        var order = new Order(robots);
        orders.Add(order);
        return order.OrderId;
    }
    
    public int ExecutePartialOrder(int orderId, Dictionary<string, int> robots)
    {
        var order = orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order == null)
        {
            Utils.ShowError($"Order {orderId} not found.");
            return -1;
        }

        foreach (var robot in robots)
        {
            if (!order.robots.ContainsKey(robot.Key))
            {
                Utils.ShowError($"Robot {robot.Key} not found in order {orderId}.");
                return -1;
            }
            
            //STock available ?
            Stock stock = Stock.Instance;
            if (stock.GetRobotStock(robot.Key) < robot.Value)
            {
                Utils.ShowError("Not enough stock.");
                return -1;
            }
            //Stock update
            //Negative value means we are removing robots from stock else it only adds (this comes from the naive impl and never got changed)
            stock.UpdateStock(robot.Key, -robot.Value);
            //Order update
            order.robots[robot.Key] -= robot.Value;
        }

        if (order.IsCompleted())
        {
            orders.Remove(order);
            Console.WriteLine($"COMPLETED {orderId}");
        }
        else
        {
            //SHow remaining robots in the order
            Console.WriteLine($"Remaining for {orderId} : ");
            foreach (var robot in order.robots)
            {
                Console.Write($"{robots.Values}: {robot.Key}, ");
            }
            Console.WriteLine();
        }
        
        return order.OrderId;
    }
    
    public void ListOrders()
    {
        if (orders.Count == 0)
        {
            Utils.ShowError($"No orders");
            return;
        }
        foreach (var order in orders)
        {
            Console.WriteLine(order.ToString());
        }
    }


}

public class Order
{
    private static int orderIndex = 1;
    private int orderId;
    public Dictionary<string, int> robots;
    
    public int OrderId => orderId;

    public Order(Dictionary<string, int> robotQuantities)
    {
        this.orderId = orderIndex++;
        this.robots = new Dictionary<string, int>(robotQuantities);
    }

    
    public bool IsCompleted()
    {
        return robots.Values.All(q => q <= 0);
    }
    
    public Dictionary<string, int> GetRemainingRobots()
    {
        // Only robots with positive remaining quantities
        return robots
            .Where(kv => kv.Value > 0)
            .ToDictionary(kv => kv.Key, kv => kv.Value);
    }

    public override string ToString()
    {
        return $"ORDER {orderId}: " + 
               string.Join(", ", GetRemainingRobots()
                   .Select(kv => $"{kv.Value} {kv.Key}"));
    }
    
}