using RobotFactory.RobotAssemblyConstraintStrategy;

namespace RobotFactory;

public class Factory
{
    //All types of available pieces
    /*
 *  Modules principaux (nécessitent l’installation d’un système principal) :
   o Core_CM1
   o Core_CD1
   o Core_CI1
    Générateurs :
   o Generator_GM1
   o Generator_GD1
   o Generator_GI1
    Modules de préhension :
   o Arms_AM1
   o Arms_AD1
   o Arms_AI1
    Modules de déplacement :
   o Legs_LM1
   o Legs_LD1
   o Legs_LI1
   Le seul système principal disponible actuellement et compatible avec tous les modules
   principaux est le : System_SB1
 */
    private Stock stocks = Stock.Instance; //call to the singleton stock instance
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
        .AddPiece(Legs_LI1)
        .Build();
    public void ShowStock()
    {
        stocks.DisplayStock();
    
    }
    public void checkPiecesAvailability(Dictionary<string, int> robotQuantities)
    {
        bool isAvailable = true;
        foreach (var robotQuantity in robotQuantities)
        {
            List<Piece> pieces = new List<Piece>();
            switch (robotQuantity.Key.ToUpper())
            {
                case "XM-1":
                    pieces = XM1.GetNeededPieces();
                    break;
                case "RD-1":
                    pieces = RD1.GetNeededPieces();
                    break;
                case "WI-1":
                    pieces = WI1.GetNeededPieces();
                    break;
                default:
                    Utils.ShowError("Invalid robot type name.");
                    break;
            }

            foreach (Piece piece in pieces)
            {
                Console.WriteLine($"{robotQuantity.Value} {piece.GetName()}");
                if(stocks.GetStock(piece.GetName()) < robotQuantity.Value)
                {
                    isAvailable = false;
                    break;
                }
            }
            
            if (isAvailable == false)
            {
                break;
            }
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(isAvailable? "AVAILABLE" : "UNAVAILABLE");
        Console.ResetColor();
        
    }
    public void CheckNeededStock(Dictionary<string, int> robotQuantities)
    {
        foreach (var robotQuantity in robotQuantities)
        {
            Console.WriteLine($"{robotQuantity.Value} {robotQuantity.Key}");
                 
            switch (robotQuantity.Key.ToUpper())
            {
                case "XM-1":
                    XM1.ShowPiecesNeeded(robotQuantity.Value);
                    break;
                case "RD-1":
                    RD1.ShowPiecesNeeded(robotQuantity.Value);
                    break;
                case "WI-1":
                    WI1.ShowPiecesNeeded(robotQuantity.Value);
                    break;
                default:
                    Utils.ShowError("Invalid robot type name.");
                    break;
            }
            Console.WriteLine();
            
        }
    }

    public void GetRobotProductionInstructions(Dictionary<string, int> robotQuantities)
    {
        foreach (var sameRobotQuantity in robotQuantities)
        {
            for (int i = 0; i < sameRobotQuantity.Value; i++)
            {
                Console.WriteLine("PRODUCING " + sameRobotQuantity.Key + " (" + (i + 1) + "/" + sameRobotQuantity.Value + ")");

                List<Piece> pieces;
                //fixme : c'est pas très joli mais ok 
                switch (sameRobotQuantity.Key.ToUpper()) 
                {
                    case "WI-1" :
                        pieces = (WI1.GetNeededPieces());
                        WI1.ShowInstructions(pieces);
                        break;
                    case "RD-1" :
                        pieces = (RD1.GetNeededPieces());
                        RD1.ShowInstructions(pieces);
                        break;
                    case "XM-1":
                        pieces = (XM1.GetNeededPieces());
                        XM1.ShowInstructions(pieces);
                        break;
                    default:
                        Utils.ShowError("Invalid robot type name.");
                        break;
                }
                
                Console.WriteLine("FINISHED " + sameRobotQuantity.Key + " (" + (i + 1) + "/" + sameRobotQuantity.Value + ")");
            }
        }
    }

    public void ProduceRobot(Dictionary<string, int> robotQuantities)
    {
        foreach (var robotQuantity in robotQuantities)
        {
            List<Piece> pieces = new List<Piece>();
            switch (robotQuantity.Key.ToUpper())
            {
                case "XM-1":
                    pieces = XM1.GetNeededPieces();
                    break;
                case "RD-1":
                    pieces = RD1.GetNeededPieces();
                    break;
                case "WI-1":
                    pieces = WI1.GetNeededPieces();
                    break;
                default:
                    Utils.ShowError("Invalid robot type name.");
                    break;
            }

            foreach (Piece piece in pieces)
            {
                stocks.UpdateStock(piece.GetName(), robotQuantity.Value); //only works cuz we need 1 piece of each?
            }
            stocks.UpdateStock(robotQuantity.Key, robotQuantity.Value);
            Console.WriteLine("STOCK_UPDATED");
        }
    }
    
}