using System.Text;
using RobotFactory.RobotAssemblyConstraintStrategy;

namespace RobotFactory;

public sealed class BookOfTemplates
{
        private static BookOfTemplates? instance;
        private List<RobotTemplate> templates = new List<RobotTemplate>();

        private BookOfTemplates() {}

        public static BookOfTemplates Instance
        {
            get
            {
                if (instance == null)
                    instance = new BookOfTemplates();
                return instance;
            }
        }

        public override string ToString()
        {
            if (templates.Count == 0)
            {
                return "No templates available.";
            }

            var sb = new StringBuilder();
            sb.AppendLine("Available Robot Templates:");
            foreach (var template in templates)
            {
                sb.AppendLine(template.ToString());
            }
            return sb.ToString();
        }

        public bool AddTemplate(string name, List<Piece> pieces, IConstraintStrategy strategy)
        {
            var robot = new RobotBuilder(name, strategy);

            foreach (var piece in pieces)
            {
                robot.AddPiece(piece);
            }

            var template = robot.Build();
            if (template == null)
            {
                Utils.ShowError($"Template '{name}' is invalid and was not added.");
                return false;
            }

            templates.Add(template);
            Console.WriteLine($"Template '{name}' added.");
            return true;
        }
        
        public RobotTemplate? GetTemplate(string name)
        {
            return templates.FirstOrDefault(t => t.GetName() == name);
        }
        

}