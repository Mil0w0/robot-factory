namespace RobotFactory;

public sealed class Stock
{
    
    // SINGLETON PATTERN TO ACCESS THE SAME STOCK INSTANCE GLOBALLY
  
    private Stock()
    {
    }
    private static Stock? _instance;

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
    
    //fixme: oui j'ai pas fait d'effort mais il y aura un refacto sur toute la classe
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
    public int System_SM1 { get; set; } = 1;
    public int System_SD1 { get; set; } = 1;
    public int System_SI1 { get; set; } = 1;
    public int System_SB1 { get; set; } = 1;
  
    
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

    public void UpdateStock(string pieceName, int quantity)
    {
        switch (pieceName.ToUpper())
        {
            case "XM-1":
                XM1 += quantity;
                break;
            case "RD-1":
                RD1 += quantity;
                break;
            case "WI-1":
                WI1 += quantity;
                break;
            case "CORE_CM1":
                Core_CM1 -= quantity;
                break;
            case "CORE_CD1":
                Core_CD1 -= quantity;
                break;
            case "CORE_CI1":
                Core_CI1 -= quantity;
                break;
            case "GENERATOR_GM1":
                Generator_GM1 -= quantity;
                break;
            case "GENERATOR_GD1":
                Generator_GD1 -= quantity;
                break;
            case "GENERATOR_GI1":
                Generator_GI1 -= quantity;
                break;
            case "ARMS_AM1":
                Arms_AM1 -= quantity;
                break;
            case "ARMS_AD1":
                Arms_AD1 -= quantity;
                break;
            case "ARMS_AI1":
                Arms_AI1 -= quantity;
                break;
            case "LEGS_LM1":
                Legs_LM1 -= quantity;
                break;
            case "LEGS_LD1":
                Legs_LD1 -= quantity;
                break;
            case "LEGS_LI1":
                Legs_LI1 -= quantity;
                break;
        }
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
            case "SYSTEM_SM1":
                return System_SM1;
            case "SYSTEM_SD1":
                return System_SD1;
            case "SYSTEM_SI1":
                return System_SI1;
            case "SYSTEM_SB1":
                return System_SB1;
                
                
            default:
                Utils.ShowError("Invalid robot piece name.");
                return 0;
        }
        
    }
}