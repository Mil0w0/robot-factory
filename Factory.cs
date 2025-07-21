using RobotFactory.RobotAssemblyConstraintStrategy;

namespace RobotFactory;

public class Factory
{
    private Stock stocks = Stock.Instance; //call to the singleton stock instance

    private BookOfTemplates
        bookOfTemplates = BookOfTemplates.Instance; //call to the singleton book of templates instance

    private static Core Core_CM1 = new Core("Core_CM1", Category.Military);
    private static Core Core_CD1 = new Core("Core_CD1", Category.Domestic);
    private static Core Core_CI1 = new Core("Core_CI1", Category.Industrial);
    private static Generator Generator_GM1 = new Generator("Generator_GM1", Category.Military);
    private static Generator Generator_GD1 = new Generator("Generator_GD1", Category.Domestic);
    private static Generator Generator_GI1 = new Generator("Generator_GI1", Category.Industrial);
    private static Arm Arms_AM1 = new Arm("Arms_AM1", Category.Military);
    private static Arm Arms_AD1 = new Arm("Arms_AD1", Category.Domestic);
    private static Arm Arms_AI1 = new Arm("Arms_AI1", Category.Industrial);
    private static Leg Legs_LM1 = new Leg("Legs_LM1", Category.Military);
    private static Leg Legs_LD1 = new Leg("Legs_LD1", Category.Domestic);
    private static Leg Legs_LI1 = new Leg("Legs_LI1", Category.Industrial);
    private static System System_SB1 = new System("System_SB1", Category.Generalist);
    private static System System_SM1 = new System("System_SM1", Category.Military);
    private static System System_SD1 = new System("System_SD1", Category.Domestic);
    private static System System_SI1 = new System("System_SI1", Category.Industrial);


    private RobotTemplate? XM1 = new RobotBuilder("XM-1", new MilitaryConstraintStrategy())
        .AddSystem(System_SM1)
        .AddPiece(Core_CM1)
        .AddPiece(Generator_GM1)
        .AddPiece(Arms_AM1)
        .AddPiece(Legs_LM1)
        .Build();

    private RobotTemplate? RD1 = new RobotBuilder("RD-1", new DomesticConstraintStrategy())
        .AddSystem(System_SB1)
        .AddPiece(Core_CD1)
        .AddPiece(Generator_GD1)
        .AddPiece(Arms_AD1)
        .AddPiece(Legs_LD1)
        .Build();

    private RobotTemplate? WI1 = new RobotBuilder("WI-1", new IndustrialConstraintStrategy())
        .AddSystem(System_SB1)
        .AddPiece(Core_CI1)
        .AddPiece(Generator_GI1)
        .AddPiece(Arms_AI1)
        .AddPiece(Arms_AI1)
        .AddPiece(Legs_LI1)
        .Build();

    public void AddDefaultRobotTemplates()
    {
        if (XM1 != null)
        {
            bookOfTemplates.AddTemplate("XM-1", XM1.GetNeededPieces(), new MilitaryConstraintStrategy());
        }

        if (RD1 != null)
        {
            bookOfTemplates.AddTemplate("RD-1", RD1.GetNeededPieces(), new DomesticConstraintStrategy());
        }

        if (WI1 != null)
        {
            bookOfTemplates.AddTemplate("WI-1", WI1.GetNeededPieces(), new IndustrialConstraintStrategy());
        }

        Console.WriteLine(bookOfTemplates.ToString());

        
        //DEFAULT STOCK INITIALIZATION
        stocks.Initialize(new List<Piece>
        {
            Core_CM1, Core_CD1, Core_CI1,
            Generator_GM1, Generator_GD1, Generator_GI1,
            Arms_AM1, Arms_AD1, Arms_AI1,
            Legs_LM1, Legs_LD1, Legs_LI1,
        });
    }


    public void AddRobotTemplate(string input)
    {
        string commandArgs = input.Substring("ADD_TEMPLATE ".Length).Trim();


        // Find the first space to find the name
        int firstSpaceIndex = commandArgs.IndexOf(' ');
        if (firstSpaceIndex == -1)
        {
            Utils.ShowError("INvalid command. FOllow format: ADD_TEMPLATE TEMPLATE_NAME Piece1, ..., PieceN.");
            return;
        }

        // Extract template name
        string templateName = commandArgs.Substring(0, firstSpaceIndex).Trim();


        // Extract piece names (split by commas)
        string piecesPart = commandArgs.Substring(firstSpaceIndex + 1).Trim();

        var pieceNames = piecesPart
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .Select(p => p.Trim())
            .ToList();

        var pieces = new List<Piece>();

        foreach (var pieceName in pieceNames)
        {
            //FInd the piece and add it to the pieces list for the template
            var piece = stocks.GetPiece(pieceName);
            if (piece == null)
            {
                Utils.ShowError($"Error : Unknown piece: {pieceName}");
                return;
            }

            pieces.Add(piece);
        }

        //Guessing strategy
        try
        {
            var strategy = RobotTemplateHelper.GuessConstraintStrategy(pieces);
            BookOfTemplates.Instance.AddTemplate(templateName, pieces, strategy);
        }
        catch (InvalidOperationException ex)
        {
            Utils.ShowError(ex.Message);
            return;
        }
        
        Console.WriteLine(bookOfTemplates.ToString());
    }

    public void ShowStock()
    {
        stocks.DisplayStock();
    }

    public bool checkPiecesAvailability(Dictionary<string, int> robotQuantities)
    {
        bool isAvailable = true;
        foreach (var robotQuantity in robotQuantities)
        {
            //for each robot template of the book of templates, get the needed pieces
            {
                string templateName = robotQuantity.Key;
                int quantity = robotQuantity.Value;

                var template = bookOfTemplates.GetTemplate(templateName);
                if (template == null)
                {
                    Utils.ShowError($"{templateName} is not a recognized robot.");
                    isAvailable = false;
                    return false;
                }

                List<Piece> pieces = template.GetNeededPieces();


                foreach (Piece piece in pieces)
                {
                    //DEBUG: PRConsole.WriteLine($"{robotQuantity.Value} {piece.GetName()}");
                    if (stocks.GetStock(piece.GetName()) < robotQuantity.Value)
                    {
                        isAvailable = false;
                        break;
                    }
                }
            }
            if (isAvailable == false)
            {
                break;
            }
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(isAvailable ? "AVAILABLE" : "UNAVAILABLE");
        Console.ResetColor();
        return isAvailable;
    }

    public void CheckNeededStock(Dictionary<string, int> robotQuantities)
    {
        foreach (var robotQuantity in robotQuantities)
        {
            string templateName = robotQuantity.Key;
            Console.WriteLine($"{robotQuantity.Value} {robotQuantity.Key} ");

            var template = bookOfTemplates.GetTemplate(templateName);
            if (template == null)
            {
                Utils.ShowError($"{templateName} is not a recognized robot.");
                return;
            }

            template.ShowPiecesNeeded(quantity: robotQuantity.Value);

            Console.WriteLine();
        }
    }

    public void GetRobotProductionInstructions(Dictionary<string, int> robotQuantities)
    {
        foreach (var sameRobotQuantity in robotQuantities)
        {
            for (int i = 0; i < sameRobotQuantity.Value; i++)
            {
                Console.WriteLine("PRODUCING " + sameRobotQuantity.Key + " (" + (i + 1) + "/" +
                                  sameRobotQuantity.Value + ")");

                List<Piece> pieces;
                var template = bookOfTemplates.GetTemplate(sameRobotQuantity.Key);
                if (template == null)
                {
                    Utils.ShowError($"{sameRobotQuantity.Key} is not a recognized robot.");
                    return;
                }
                pieces = template.GetNeededPieces();
                template.ShowInstructions(pieces);

                Console.WriteLine("FINISHED " + sameRobotQuantity.Key + " (" + (i + 1) + "/" +
                                  sameRobotQuantity.Value + ")");
            }
        }
    }

    public void ProduceRobot(Dictionary<string, int> robotQuantities)
    {
        foreach (var robotQuantity in robotQuantities)
        {
            string templateName = robotQuantity.Key;
            int quantity = robotQuantity.Value;

            var template = bookOfTemplates.GetTemplate(templateName);
            if (template == null)
            {
                Utils.ShowError($"{templateName} is not a recognized robot.");
                return;
            }

            List<Piece> pieces = template.GetNeededPieces();

            foreach (Piece piece in pieces)
            {
                stocks.UpdateStock(piece.GetName(), robotQuantity.Value); //only works cuz we need 1 piece of each?
            }

            stocks.UpdateStock(robotQuantity.Key, robotQuantity.Value);
            Console.WriteLine("STOCK_UPDATED");
        }
    }
    
    public void ReceivesStocks(Dictionary<string, int> itemQuantities)
    {
        // It is checked that it's conform previously
        foreach (var item in itemQuantities)
        {
            string itemName = item.Key;
            int quantity = item.Value;
            
            stocks.UpdateStock(itemName, quantity);
        }
    }

    public void SaveOrder(Dictionary<string, int> robotQuantities)
    {
        foreach (var robot in robotQuantities)
        {
            if (BookOfTemplates.Instance.GetTemplate(robot.Key) == null)
            {
                Utils.ShowError($"Unknown robot template: {robot.Key}");
            }
        }

        int orderId = BookOfOrders.Instance.AddOrder(robotQuantities);
        Console.WriteLine($"ORDER {orderId} CREATED");
    }

    public void Send(int orderId, Dictionary<string, int> robotQuantities)
    {
        BookOfOrders.Instance.ExecutePartialOrder(orderId, robotQuantities);
    }
    public void ListOrders()
    {
        BookOfOrders.Instance.ListOrders();
    }
    
}