namespace RobotFactory;

public class RobotTemplate
{
    private string name;
    private Dictionary<Piece, int> pieces = new Dictionary<Piece, int>();
    
    public RobotTemplate(string name, Dictionary<Piece, int> pieces)
    {
        this.name = name;
        this.pieces = pieces;
    }

    public void ShowPiecesNeeded(int quantity = 1)
    {
        foreach (var piece in pieces)
        {
            Console.WriteLine($"{piece.Value * quantity} {piece.Key.ToString()}");
        }
    }
}
