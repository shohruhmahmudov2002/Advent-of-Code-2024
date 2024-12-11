using System.Diagnostics.CodeAnalysis;

namespace AoC_Day_2;
internal class Program
{
    static void Main(string[] args)
    {
        string path = "AoC2.txt";
        List<List<int>> list = ReadText(path);
        int safe = 0;                           
        int doubleSafe = 0;                                                 
        foreach(List<int> list2 in list)
        {
            if(SafeCheck(list2))
            {
                safe++;
                doubleSafe++;
            }
            else
            {
                for(int i = 0; i < list2.Count; i++)
                {
                    List<int> copyList = new List<int>(list2);
                    copyList.RemoveAt(i);
                    if(SafeCheck(copyList))
                    {
                        doubleSafe++;
                        break;
                    }
                }
            }
        }
        Console.WriteLine(safe);    //Part 1 result
        Console.WriteLine(doubleSafe);  //Part 2 result
    }
    static List<List<int>> ReadText(string path)
    {
        List<List<int>> list = new List<List<int>>();
        using var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        using var sr = new StreamReader(fs);
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            List<int> list2 = new List<int>();
            string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in parts) 
            {
                list2.Add(int.Parse(part));
            }
            list.Add(list2);
        }
        return list;
    }
    static bool SafeCheck(List<int> list)
    {
        bool ascending = true;
        bool descending = true;
        for (int i = 1; i < list.Count; i++)
        {
            int diff = list[i] - list[i - 1];
            if(diff < 1 || diff > 3)
                ascending = false;
            if(diff > -1 || diff < -3)
                descending = false;
            if(!ascending && !descending)
                return false;
        }
        return true;
    }
}
