using System;

class Program
{
    static void Main()
    {
        byte numberRabbitsAsked;
        byte.TryParse(Console.ReadLine(), out numberRabbitsAsked);
        uint[] equallyColoured = new uint[50];
        uint minNumberRabbits=0;
        uint[] buffer= new uint[1000002];
        uint greatesAnswer = 0;
        for (int i = 0; i < 1000001; i++)
        {
            buffer[i] = 0;
        }
        for (int i = 0; i < numberRabbitsAsked; i++)
        {
            equallyColoured[i]=uint.Parse(Console.ReadLine());
            if (greatesAnswer < equallyColoured[i])
            {
                greatesAnswer = equallyColoured[i];
            }
        }
        for (int i = 0; i < numberRabbitsAsked; i++)
        {
            buffer[equallyColoured[i]+1]++;
        }
        for (uint i = 1; i <= greatesAnswer + 1; i++)
        {            
            if (buffer[i] % i > 0)
            {
                minNumberRabbits += ((buffer[i] / i) + 1) * i;
            }
            else
            {
                minNumberRabbits += (buffer[i] / i) * i;
            }
        }

       
        Console.WriteLine(minNumberRabbits);
    }
}
