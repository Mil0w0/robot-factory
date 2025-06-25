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
                        
        //Tant qu'on peut assembler 2 pièces
        int j = 0;
        while (j < pieces.Count - 1)
        {
            Piece piece1 = pieces[j];
            Piece piece2 = pieces[j + 1];

            var assembledPiece = new Assembly($"Assembly_{piece1.GetPieceType()}_{piece2.GetPieceType()}");
            Console.WriteLine($"ASSEMBLE Assembly_{piece1.GetPieceType()}_{piece2.GetPieceType()} {piece1.GetName()} {piece2.GetName()}");

            pieces.RemoveAt(j + 1);
            pieces.RemoveAt(j);
            
            pieces.Add(assembledPiece);

            // Move to the next pair
            j++;
        }
        Console.WriteLine();
    }
    public override string ToString()
    {
        return $"RobotTemplate: {name}, Pieces: {string.Join(", ", pieces.Keys)}";
    }

    public string GetName()
    {
        return name;
    }
}


