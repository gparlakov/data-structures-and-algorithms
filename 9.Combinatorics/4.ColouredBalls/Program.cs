using System;
using System.Numerics;
class Program
{
    static BigInteger factorial(int number)
    {
        BigInteger result = 1;
        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }
        return result;
    }

    static void Main()
    {
        char[] balls = new char[30];
        int numberOfBalls=0,ballColours=0;
        char buffer='z';
        int counter = 0;
        do
        {
            buffer = (char)Console.Read();
            balls[counter] = buffer;
            counter++;
        } while (buffer >= 'A' && buffer <= 'Z'&&counter<30);

        for (int i = 0; i < 30; i++)
        {
            if (balls[i]>='A'&&balls[i]<='Z')
            {
                numberOfBalls++;
            }
        }

        int[] colors = new int[6];
        counter = 0;
        for (buffer='A';buffer  <='Z'; buffer++)
        {
            for (int i = 0; i < numberOfBalls; i++)
            {
                if (buffer==balls[i])
                {
                    colors[counter]++;
                }                
            }
            if (colors[counter] > 0 && counter<5)
            {
                counter++;
            }
        }

        Console.WriteLine(factorial(numberOfBalls) / (factorial(colors[0]) * factorial(colors[1]) * factorial(colors[2]) * factorial(colors[3]) * factorial(colors[4])));
                
    }
}