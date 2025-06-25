namespace RobotFactory.RobotAssemblyConstraintStrategy;

public interface IConstraintStrategy
{
        /**
         * Validates if the given pieces can be used to assemble a robot.
         */
        bool IsValid(List<Piece> pieces);
        bool IsValidSystem(System system);

        int GetMaxModulesAllowed();

}