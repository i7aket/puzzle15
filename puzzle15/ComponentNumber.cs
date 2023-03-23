namespace Puzzle15;

public class ComponentNumber
{
    public int ShiftX { get; private set;} 
    public int ShiftY { get; private set;} 
    public ConsoleColor color { get; private set;}
    public string[] number { get; private set;}
    public int? lines { get; private set; }

    
    public ComponentNumber (int ShiftX, int ShiftY, ConsoleColor color, int n)
    {
        this.ShiftX = ShiftX;
        this.ShiftY = ShiftY;
        this.color = color;
        this.number = ElNumber(n);
        this.lines = _numbers.GetLength(1);
    }
    
    public ComponentNumber (int n)
    {
        this.number = ElNumber(n);
    }
    
    
    public string[] ElNumber(int el)
    {
        string[] element = new string [_numbers.GetLength(1)];

        for (int i = 0; i < element.Length; i++)
            element[i] = _numbers[el,i];
        
        return element;
    } 
    
     private readonly string[,] _numbers = {
            {
                "               ",
                "               ",
                "               ",
                "               ",
                "               ",
                "               "
            },
            {
                "      ██╗      ",
                "     ███║      ",
                "     ╚██║      ",
                "      ██║      ",
                "      ██║      ",
                "      ╚═╝      "
            },
            {
                "   ██████╗     ",
                "   ╚════██╗    ",
                "    █████╔╝    ",
                "   ██╔═══╝     ",
                "   ███████╗    ",
                "   ╚══════╝    "
            },
            {
                "   ██████╗     ",
                "   ╚════██╗    ",
                "    █████╔╝    ",
                "    ╚═══██╗    ",
                "   ██████╔╝    ",
                "   ╚═════╝     "
            },
            {
                "   ██╗  ██╗    ",
                "   ██║  ██║    ",
                "   ███████║    ",
                "   ╚════██║    ",
                "        ██║    ",
                "        ╚═╝    "
            },
            {
                "   ███████╗    ",
                "   ██╔════╝    ",
                "   ███████╗    ",
                "   ╚════██║    ",
                "   ███████║    ",
                "   ╚══════╝    ",     
            },
            {
                "    ██████╗    ",
                "   ██╔════╝    ",
                "   ███████╗    ",
                "   ██╔═══██╗   ",
                "   ╚██████╔╝   ",
                "    ╚═════╝    "
            },
            {
                "   ███████╗    ",
                "   ╚════██║    ",
                "       ██╔╝    ",
                "      ██╔╝     ",  
                "      ██║      ",
                "      ╚═╝      "       
            },
            {
                "    █████╗     ",
                "   ██╔══██╗    ",
                "   ╚█████╔╝    ",
                "   ██╔══██╗    ",
                "   ╚█████╔╝    ",
                "    ╚════╝     ",      
            },
            {
                "    █████╗     ",
                "   ██╔══██╗    ",
                "   ╚██████║    ",
                "    ╚═══██║    ",
                "    █████╔╝    ",
                "    ╚════╝     "
            },
            {
                "  ██╗ ██████╗  ",
                " ███║██╔═████╗ ",
                " ╚██║██║██╔██║ ",
                "  ██║████╔╝██║ ",
                "  ██║╚██████╔╝ ",
                "  ╚═╝ ╚═════╝  ",
            },
            {
                "     ██╗ ██╗   ",
                "    ███║███║   ",
                "    ╚██║╚██║   ",
                "     ██║ ██║   ",
                "     ██║ ██║   ",
                "     ╚═╝ ╚═╝   "    
            },
            {
                "  ██╗██████╗   ",
                " ███║╚════██╗  ",
                " ╚██║ █████╔╝  ",
                "  ██║██╔═══╝   ",
                "  ██║███████╗  ",
                "  ╚═╝╚══════╝  "   
            },
            {
                "  ██╗██████╗   ",
                " ███║╚════██╗  ",
                " ╚██║ █████╔╝  ",
                "  ██║ ╚═══██╗  ",
                "  ██║██████╔╝  ",
                "  ╚═╝╚═════╝   "  
            },
            {
                "  ██╗██╗  ██╗  ",
                " ███║██║  ██║  ",
                " ╚██║███████║  ",
                "  ██║╚════██║  ",
                "  ██║     ██║  ",
                "  ╚═╝     ╚═╝  "
            },
            {
                "  ██╗███████╗  ",
                " ███║██╔════╝  ",
                " ╚██║███████╗  ",
                "  ██║╚════██║  ",
                "  ██║███████║  ",
                "  ╚═╝╚══════╝  " 
            }
    };   
}