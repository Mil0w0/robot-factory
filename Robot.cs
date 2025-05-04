namespace RobotFactory;

public class Factory
{
    private Stock stocks = new Stock();
    
    public void ShowStock()
    {
        stocks.DisplayStock();
    }
    
    public void updateStock(string robotTypeName, int quantity)
    {
        switch (robotTypeName.ToUpper())
        {
            case "XM-1":
                stocks.XM1 -= quantity;
                break;
            case "RD-1":
                stocks.RD1 -= quantity;
                break;
            case "WI-1":
                stocks.WI1 -= quantity;
                break;
            default:
                Utils.ShowError("Invalid robot type name.");
                break;
        }
    }
}
public class Stock
{
    public int XM1 { get; set; } = 1;
    public int RD1 { get; set; } = 5;
    public int WI1 { get; set; } = 2;
    
    public void DisplayStock()
    {
        Console.WriteLine($"{XM1} XM-1");
        Console.WriteLine($"{RD1} RD-1");
        Console.WriteLine($"{WI1} WI-1");
    }
}