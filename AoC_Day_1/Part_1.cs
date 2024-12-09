namespace AoC;
internal class Part_1
{
    static void Main(string[] args)
    {
        string path = "AoC.txt";
        (int[] column1, int[] column2) = ReadText(path);
        Array.Sort(column1);
        Array.Sort(column2);
        int sum = 0;
        for (int i = 0; i < column1.Length; i++)
        {
            sum += Math.Abs(column1[i] - column2[i]);
            Console.WriteLine($"{column1[i]}-{column2[i]} = {column1[i] - column2[i]}");
        }
        Console.WriteLine(sum);
        Console.WriteLine(Repeated(column1,column2));
    }
    static (int[], int[]) ReadText(string path)
    {
        List<int> column1 = new List<int>();
        List<int> column2 = new List<int>();
        using var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        using var stream = new StreamReader(fs);
        string line;
        while ((line = stream.ReadLine()) != null)
        {
            string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                column1.Add(int.Parse(parts[0]));
                column2.Add(int.Parse(parts[1]));
            }
        }
        return (column1.ToArray(), column2.ToArray());
    }
    static long Repeated(int[] column1, int[] column2) 
    {
        int counter = 0;
        long sum = 0;
        Dictionary<int,int> result = new Dictionary<int,int>();
        foreach (int num in column2)
        {
            if(result.ContainsKey(num))
                result[num]++;
            else
                result[num] = 1;
        }
        foreach(int num in column1)
        {
            if(result.ContainsKey(num))
                sum += result[num] * num;
        }
        return sum;
    }
}

