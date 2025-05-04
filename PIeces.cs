namespace RobotFactory;
public class Piece
{
    private string name;
    private string type;
    
    public override string ToString()
    {
        return name; 
    }
}
public class Core : Piece
{
    private string name;
    private string type = "CORE";
    private System system = null;
    
    public Core(string name)
    {
        this.name = name;
        
    }
    public override string ToString()
    {
        return name;
    }
}

public class Arm : Piece
{
    private string name;
    private string type = "ARM";
    
    public Arm(string name)
    {
        this.name = name;
        
    }
    public override string ToString()
    {
        return name;
    }
}

public class Leg : Piece
{
    private string name;
    private string type = "LEG";
    
    public Leg(string name)
    {
        this.name = name;
    }
    public override string ToString()
    {
        return name; 
    }
}
public class Generator: Piece
{
    private string name;
    private string type = "GENERATOR";
    
    public Generator(string name)
    {
        this.name = name;
    }
    public override string ToString()
    {
        return name; 
    }
}

public class System
{
    private string name;
    
    public System(string name)
    {
        this.name = name;
    }
    public override string ToString()
    { 
        return name; 
    }
}