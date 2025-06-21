namespace RobotFactory;

public sealed class Stock
{
    
    // SINGLETON PATTERN TO ACCESS THE SAME STOCK INSTANCE GLOBALLY
    private static Stock? _instance;
    private  Dictionary<string, (Piece piece, int quantity)> piecesStock = new();
    private Dictionary<string, (RobotTemplate robot, int quantity)> robotStock;

    public static Stock Instance
    {
        get
        {
            if(_instance==null)
            {
                _instance = new Stock();
            }
            return _instance;
        }
    }
    private Stock()
    {
    }

    public void Initialize(IEnumerable<Piece> pieces)
    {
        if (piecesStock.Count > 0)
        {
            Utils.ShowError("Stock has already been initialized.");
            return;
        }

        robotStock = new();
        foreach (var piece in pieces)
        {
            piecesStock[piece.GetName()] = (piece, 1);
        }
    }


    public void DisplayStock()
    {
        Console.WriteLine("Pieces in stock : ");
        foreach (var piece in piecesStock)
        {
            Console.WriteLine($"{piece.Key} : {piece.Value.quantity}");
        }
        Console.WriteLine("Robots in stock : ");
        foreach (var piece in robotStock)
        {
            Console.WriteLine($"{piece.Key} : {piece.Value.quantity}");
        }
        
    }

    public void UpdateStock(string name, int addQuantity)
    {
        // Check if the piece is already in stock
        if (piecesStock.TryGetValue(name, out var pieceStock))
        {
            piecesStock[name] = (pieceStock.piece, pieceStock.quantity - addQuantity);
        }
        else
        {
            // If the piece is not found, we assume it's a robot template
            if (robotStock.TryGetValue(name, out var robot))
            {
                robotStock[name] = (robot.robot, robot.quantity + addQuantity);
            }
            else
            {
                // Need to retrieve robot template from somewhere
                var robotTemplate = BookOfTemplates.Instance.GetTemplate(name);
                if (robotTemplate != null)
                {
                    robotStock[name] = (robotTemplate, addQuantity);
                }
                else
                {
                    Utils.ShowError($"Robot or piece named '{name}' not found.");
                }
            }
        }
    }
    
    public int GetStock(string name)
    {
        return piecesStock.ContainsKey(name) ? piecesStock[name].quantity : 0;
    }
    
    public Piece? GetPiece(string name)
    {
        return piecesStock.TryGetValue(name, out var entry) ? entry.piece : null;
    }

}