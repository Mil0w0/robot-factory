namespace RobotFactory.RobotAssemblyConstraintStrategy;

/**
 * Militaire (M) : ne peut contenir que des pièces (M) ou (I) et des systèmes (M) ou (
 */
public class MilitaryConstraintStrategy : IConstraintStrategy
{
    public bool IsValid(List<Piece> pieces)
    {
        return pieces.All(piece =>
            piece.GetCategory() == Category.Military ||
            piece.GetCategory() == Category.Industrial );
    }
    
    public bool IsValidSystem(System system)
    {
        return system.GetCategory() == Category.Military ||
               system.GetCategory() == Category.Industrial;
    }
    
    public int GetMaxModulesAllowed()
    {
        return 4;
    }
}