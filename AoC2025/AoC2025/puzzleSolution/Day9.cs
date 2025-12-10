class AoC2025Day9
{

    public static void Part1()
    {
        int day = 9;
        long area = 0;
        bool example = false;

        string[] input = readInput(day, example);
        List<Tile> tiles = new();

        foreach (string pos in input)
        {
            tiles.Add(new Tile(pos));
        }

        for (int i = 0; i < tiles.Count; i++)
        {
            for (int j = 0; j < tiles.Count; j++)
            {
                Tile tileA = tiles[i];
                Tile tileB = tiles[j];

                long result = Math.Abs(tileA.posX - tileB.posX + 1) * Math.Abs(tileA.posY - tileB.posY + 1);
                if (result > area) area = result;

                Console.WriteLine($"size: {result}");
            }
        }

        Console.WriteLine($"Answer of day{day} = {area}");
    }

    public static void Part2()
    {
        int day = 9;
        long area = 0;
        bool example = true;

        string[] input = readInput(day, example);

        //determine grid size by largest/Smallest of x/y position
        
        //Walk green outline from point to point

        
        
    

        //List all optional arreas with their size sorted from large to small (part 1 solution)

        //Check if they fit within the bounderies

    }


    public static string[] readInput(int day, bool useExample)
    {
        if (useExample)
        {
            string[] exampleInput = File.ReadAllLines($"./puzzleInputFiles/exampleInputDay{day}.txt");
            return exampleInput;
        }
        else
        {
            string[] puzzleInput = File.ReadAllLines($"./puzzleInputFiles/puzzleInputDay{day}.txt");
            return puzzleInput;
        }
    }
}

class Tile
{
    public long posY, posX;

    public Tile(string data)
    {
        string[] pos = data.Split(',');
        this.posX = long.Parse(pos[0]);
        this.posY = long.Parse(pos[1]);
    }
}









