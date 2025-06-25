namespace RobotFactory.RobotAssemblyConstraintStrategy;


/**
 * Domestique (D) : ne peut contenir que des pièces ou systèmes (D), (G) ou (I)
 */
public class DomesticConstraintStrategy : IConstraintStrategy
{
    public bool IsValid(List<Piece> pieces)
    {
        return pieces.All(piece => 
            piece.GetCategory() == Category.Domestic ||
            piece.GetCategory() == Category.Generalist ||
            piece.GetCategory() == Category.Industrial);
    }
    
    public bool IsValidSystem(System system)
    {
        return system.GetCategory() == Category.Domestic ||
               system.GetCategory() == Category.Generalist ||
               system.GetCategory() == Category.Industrial;
    }
    public int GetMaxModulesAllowed()
    {
        return 3;
    }
}