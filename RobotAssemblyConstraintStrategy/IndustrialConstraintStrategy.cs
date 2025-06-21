namespace RobotFactory.RobotAssemblyConstraintStrategy;

/**
 * Industriel (I) : ne peut contenir que des pièces ou systèmes (G) ou (I)
 * */
public class IndustrialConstraintStrategy : IConstraintStrategy
{
    public bool IsValid(List<Piece> pieces)
    {
        return pieces.All(piece =>
            piece.GetCategory() == Category.Industrial ||
            piece.GetCategory() == Category.Generalist);
    }
    public bool IsValidSystem(System system)
    {
        return system.GetCategory() == Category.Industrial ||
               system.GetCategory() == Category.Generalist;
    }
}