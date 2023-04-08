namespace puzzle15;

public class NumbersIndexBox
{

    public IEnumerable<int> Numbers { get; private set; }
        
    public IEnumerable<int>? Index { get; private set; }
    public PrintNumbers PrintNumbers{ get; private set; }
        
    public NumbersIndexBox (IEnumerable<int> numbers, IEnumerable<int>? index, PrintNumbers printNumbers = PrintNumbers.TwoIndexs)
    {
        Numbers = numbers;
        Index = index; 
        PrintNumbers = printNumbers;
    }
        
}