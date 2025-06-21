using RobotFactory.RobotAssemblyConstraintStrategy;

namespace RobotFactory;
public class RobotBuilder
{
    private string name;
    private List<Piece> pieces = new();
    private IConstraintStrategy constraintStrategy;
    private System? pendingSystem;

    public RobotBuilder(string name, IConstraintStrategy strategy)
    {
        this.name = name;
        constraintStrategy = strategy;
    }

    public RobotBuilder AddPiece(Piece piece)
    {
        if (piece is Core core)
        {
            if (pendingSystem != null)
            {
                //make system is valid check 
                if(!constraintStrategy.IsValidSystem(pendingSystem))
                {
                    Console.WriteLine(name);
                    Utils.ShowError("Invalid system for this robot category");
                    return this;
                }
                {
                    
                }
                core.SetSystem(pendingSystem);
            }
        }
        pieces.Add(piece);
        return this;
    }
    public RobotBuilder AddSystem(System system)
    {
        this.pendingSystem = system;
        return this;
    }
    public RobotTemplate? Build()
    {
     
        if (!constraintStrategy.IsValid(pieces))
        {
            Console.WriteLine(name);
            Utils.ShowError("Invalid pieces for this robot category");
            return null;
        }

        var piecesMap = pieces.GroupBy(p => p)
            .ToDictionary(g => g.Key, g => g.Count());

        return new RobotTemplate(name, piecesMap);
    }
}
