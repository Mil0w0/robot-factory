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
    
    public List<Piece> GetNeededPieces()
    {
        return new List<Piece>(pieces.Keys); //fixme later
    }

    public void ShowPiecesNeeded(int quantity = 1)
    {
        foreach (var piece in pieces)
        {
            Console.WriteLine($"{piece.Value * quantity} {piece.Key.ToString()}");
        }
    }

    public void ShowInstructions(List<Piece> pieces)
    {
        
        foreach (var piece in pieces)
        {
            Console.WriteLine("GET_OUT_OF_STOCK " + piece.GetName());
            if (piece.GetPieceType() == "CORE")
            {
                Console.WriteLine($"INSTALL System_SB1 {piece.GetName()}");
            }
        }
                        
        //Tant qu'on peut assembler 2 pièces
        while (pieces.Count > 1)
        {
            for (int j = 0; j < pieces.Count; j++)
            {
                Piece piece1 = pieces[j];
                Piece piece2 = pieces[j+1];

                var assembledPiece = new Assembly($"Assembly_{piece1.GetPieceType()}_{piece2.GetPieceType()}");
                Console.WriteLine($"ASSEMBLE Assembly_{piece1.GetPieceType()}_{piece2.GetPieceType()} {piece1.GetName()} {piece2.GetName()}");

                pieces.Add(assembledPiece);

                pieces.RemoveAt(j+1); 
                pieces.RemoveAt(j); 
            }
        }
        Console.WriteLine();
    }
}
