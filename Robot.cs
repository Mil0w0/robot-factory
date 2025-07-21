namespace RobotFactory;

public class RobotTemplate
{
    private string name;
    private Dictionary<Piece, int> pieces;
    
    public RobotTemplate(string name, Dictionary<Piece, int> pieces)
    {
        this.name = name;
        this.pieces = pieces;
    }
    
    public List<Piece> GetNeededPieces()
    {
        return pieces
            .SelectMany(entry => Enumerable.Repeat(entry.Key, entry.Value))
            .ToList();
    }

    public void ShowPiecesNeeded(int quantity = 1)
    {
        foreach (var piece in pieces)
        {
            Console.WriteLine($"-- {piece.Value * quantity} {piece.Key.ToString()}");
        }
    }

    public void ShowInstructions(List<Piece> pieces)
    {
        
        foreach (var piece in pieces)
        {
            Console.WriteLine("GET_OUT_OF_STOCK " + piece.GetName());
            if (piece.GetPieceType() == "CORE")
            {
                var core = (Core)piece;
                Console.WriteLine($"INSTALL {core.getSystem().ToString()} {piece.GetName()}");
            }
        }
        
        List<Piece> piecesToAssemble = new List<Piece>(pieces);
                        
        //Tant qu'on peut assembler 2 pièces
        while (piecesToAssemble.Count > 1)
        {
            Piece piece1 = piecesToAssemble[0];
            Piece piece2 = piecesToAssemble[1];

            var assembledPiece = new Assembly($"Assembly_{piece1.GetPieceType()}_{piece2.GetPieceType()}");
            Console.WriteLine($"ASSEMBLE Assembly_{piece1.GetPieceType()}_{piece2.GetPieceType()} {piece1.GetName()} {piece2.GetName()}");

            piecesToAssemble.RemoveAt(1);
            piecesToAssemble.RemoveAt(0);
            
            piecesToAssemble.Add(assembledPiece);
        }
        Console.WriteLine();
    }
    public override string ToString()
    {
        return $"RobotTemplate: {name}, Pieces: {string.Join(", ", pieces.Select(p => $"{p.Value} {p.Key.GetName()}"))}";
    }

    public string GetName()
    {
        return name;
    }
}


