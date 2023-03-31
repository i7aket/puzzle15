namespace Puzzle15;

interface IOutput
{
    void PrintLayer0();
    void PrintEmptyBox(int shiftX, int shiftY, int height, int width);
    void Print(ComponentBox componentBox);
    void Clear();
}