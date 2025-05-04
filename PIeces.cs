namespace RobotFactory;
public class Piece
{
    private string name;
    private string type;
    
    public override string ToString()
    {
        return name; 
    }
    public virtual string GetName()
    {
        return name;
    }  
    public virtual string GetPieceType()
    {
        return type;
    }
}
public class Assembly : Piece
{
    private string name;
    private string type = "ASSEMBLY";
    
    public Assembly(string name)
    {
        this.name = name;
    }
    
    public override string ToString()
    {
        return name; 
    }
    public override string GetName()
    {
        return name;
    }
    
    public override string GetPieceType()
    {
        return type;
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
    
    public override string GetName()
    {
        return name;
    }
    
    public override string GetPieceType()
    {
        return type;
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
    
    public override string GetName()
    {
        return name;
    }
    
    public override string GetPieceType()
    {
        return type;
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
    
    public override string GetName()
    {
        return name;
    }
    
    public override string GetPieceType()
    {
        return type;
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
    
    public override string GetName()
    {
        return name;
    }
    
    public override string GetPieceType()
    {
        return type;
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
    
    public string GetName()
    {
        return name;
    }
}