namespace RobotFactory.RobotAssemblyConstraintStrategy;

public static class RobotTemplateHelper
{
    public static IConstraintStrategy GuessConstraintStrategy(List<Piece> pieces)
    {  
        
        var categories = pieces.Select(piece => piece.GetCategory()).Distinct().ToList();

        // A robot cannot be built with multiple categories
        if (categories.Count > 1)
        {
            Utils.ShowError($"Invalid template: Pieces contain multiple categories [{string.Join(", ", categories)}].");
        }
        Category category = categories[0];

        // A robot cannot be purely generalist
        if (category == Category.Generalist)
        {
            Utils.ShowError("A robot cannot be Generalist.");
            throw new InvalidOperationException("Invalid robot classification: Generalist only.");
        }

        // Map category to constraint strategy
        return category switch
        {
            Category.Domestic => new DomesticConstraintStrategy(),
            Category.Industrial=> new IndustrialConstraintStrategy(),
            Category.Military => new MilitaryConstraintStrategy(),
        };
    }
}