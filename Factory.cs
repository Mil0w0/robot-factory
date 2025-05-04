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
    private Stock stocks = new Stock();
    private static Core Core_CM1 = new Core("Core_CM1");
    private static Core Core_CD1 = new Core("Core_CD1");
    private static Core Core_CI1 = new Core("Core_CI1");
    private static Generator Generator_GM1 = new Generator("Generator_GM1");
    private static Generator Generator_GD1 = new Generator("Generator_GD1");
    private static Generator Generator_GI1 = new Generator("Generator_GI1");
    private static Arm Arms_AM1 = new Arm("Arms_AM1");
    private static Arm Arms_AD1 = new Arm("Arms_AD1");
    private static Arm Arms_AI1 = new Arm("Arms_AI1");
    private static Leg Legs_LM1 = new Leg("Legs_LM1");
    private static Leg Legs_LD1 = new Leg("Legs_LD1");
    private static Leg Legs_LI1 = new Leg("Legs_LI1");
    private static System System_SB1 = new System("System_SB1");
    
    /*
     * L’usine est actuellement capable de produire une variété relativement limitée de robots :
        XM-1
       o Core_CM1 (System_SB1)
       o Generator_GM1
       o Arms_AM1
       o Legs_LM1
        RD-1
       o Core_CD1 (System_SB1)
       o Generator_GD1
       o Arms_AD1
       o Legs_LD1
        WI-1
       o Core_CI1 (System_SB1)
       o Generator_GI1
       o Arms_AI1
       o Legs_LI1
     */

    private static Dictionary<Piece, int> piecesForXM1 = new Dictionary<Piece, int>
    {
        { Core_CM1, 1 },
        { Generator_GM1, 1 },
        { Arms_AM1, 1 },
        { Legs_LM1, 1 }
    };
    private static Dictionary<Piece, int> piecesForRD1 = new Dictionary<Piece, int>
    {
        { Core_CD1, 1 },
        { Generator_GD1, 1 },
        { Arms_AD1, 1 },
        { Legs_LD1, 1 }
    };
    private static Dictionary<Piece, int> piecesForWI1 = new Dictionary<Piece, int>
    {
        { Core_CI1, 1 },
        { Generator_GI1, 1 },
        { Arms_AI1, 1 },
        { Legs_LI1, 1 }
    };
    private RobotTemplate XM1 = new RobotTemplate("XM-1", piecesForXM1);
    private RobotTemplate RD1 = new RobotTemplate("RD-1", piecesForRD1);
    private RobotTemplate WI1 = new RobotTemplate("WI-1", piecesForWI1);
    
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
            //todo
        }
    }
    
}
public class Stock
{
    //fixme: oui j'ai pas fait d'effort mais il y aura un refacto
    public int XM1 { get; set; } = 0;
    public int RD1 { get; set; } = 0;
    public int WI1 { get; set; } = 0;
    public int Core_CM1 { get; set; } = 1;
    public int Core_CD1 { get; set; } = 1;
    public int Core_CI1 { get; set; } = 1;
    public int Generator_GM1 { get; set; } = 1;
    public int Generator_GD1 { get; set; } = 1;
    public int Generator_GI1 { get; set; } = 1;
    public int Arms_AM1 { get; set; } = 1;
    public int Arms_AD1 { get; set; } = 1;
    public int Arms_AI1 { get; set; } = 1;
    public int Legs_LM1 { get; set; } = 1;
    public int Legs_LD1 { get; set; } = 1;
    public int Legs_LI1 { get; set; } = 1;
  
    
    public void DisplayStock()
    {
        Console.WriteLine($"{XM1} XM-1");
        Console.WriteLine($"{RD1} RD-1");
        Console.WriteLine($"{WI1} WI-1");
        Console.WriteLine($"{Core_CM1} Core_CM1");
        Console.WriteLine($"{Core_CD1} Core_CD1");
        Console.WriteLine($"{Core_CI1} Core_CI1");
        Console.WriteLine($"{Generator_GM1} Generator_GM1");
        Console.WriteLine($"{Generator_GD1} Generator_GD1");
        Console.WriteLine($"{Generator_GI1} Generator_GI1");
        Console.WriteLine($"{Arms_AM1} Arms_AM1");
        Console.WriteLine($"{Arms_AD1} Arms_AD1");
        Console.WriteLine($"{Arms_AI1} Arms_AI1");
        Console.WriteLine($"{Legs_LM1} Legs_LM1");
        Console.WriteLine($"{Legs_LD1} Legs_LD1");
        Console.WriteLine($"{Legs_LI1} Legs_LI1");
        
    }
    
    public int GetStock(string name)
    {
        switch (name.ToUpper())
        {
            case "XM-1":
                return XM1;
            case "RD-1":
                return RD1;
            case "WI-1":
                return WI1;
            case "CORE_CM1":
                return Core_CM1;
            case "CORE_CD1":
                return Core_CD1;
            case "CORE_CI1":
                return Core_CI1;
            case "GENERATOR_GM1":
                return Generator_GM1;
            case "GENERATOR_GD1":
                return Generator_GD1;
            case "GENERATOR_GI1":
                return Generator_GI1;
            case "ARMS_AM1":
                return Arms_AM1;
            case "ARMS_AD1":
                return Arms_AD1;
            case "ARMS_AI1":
                return Arms_AI1;
            case "LEGS_LM1":
                return Legs_LM1;
            case "LEGS_LD1":
                return Legs_LD1;
            case "LEGS_LI1":
                return Legs_LI1;
                
            default:
                Utils.ShowError("Invalid robot piece name.");
                return 0;
        }
    }
}