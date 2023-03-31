namespace Puzzle15;

interface iOutput
{
    void PrintLayer0();
    void PrintEmptyBox(int shiftX, int shiftY, int height, int width);
    void Print(ComponentBox componentBox);
    void Clear();
}