namespace RobotFactory;

public class Piece
{
    private string name;
    private string type;
    private Category category;

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

    public virtual Category GetCategory()
    {
        return category;
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
    private Category category;
    private System system ;

    public Core(string name, Category category)
    {
        this.name = name;
        this.category = category;
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
    
    public System getSystem()
    {
        return system;
    }

    public void SetSystem(System system)
    {
        this.system = system;
    }

    public override Category GetCategory()
    {
        return category;
    }
}

public class Arm : Piece
{
    private string name;
    private string type = "ARM";
    private Category category;

    public Arm(string name, Category category)
    {
        this.name = name;
        this.category = category;
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

    public override Category GetCategory()
    {
        return category;
    }
}

public class Leg : Piece
{
    private string name;
    private string type = "LEG";
    private Category category;

    public Leg(string name, Category category)
    {
        this.name = name;
        this.category = category;
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

    public override Category GetCategory()
    {
        return category;
    }
}

public class Generator : Piece
{
    private string name;
    private string type = "GENERATOR";
    private Category category;

    public Generator(string name, Category category)
    {
        this.category = category;
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

    public override Category GetCategory()
    {
        return category;
    }
}

public class System 
{
    private string name;
    private string type = "SYSTEM";
    private Category category;

    public System(string name, Category category)
    {
        this.name = name;
        this.category = category;
    }

    public override string ToString()
    {
        return name;
    }

    public string GetName()
    {
        return name;
    }

    public Category GetCategory()
    {
        return category;
    }
}