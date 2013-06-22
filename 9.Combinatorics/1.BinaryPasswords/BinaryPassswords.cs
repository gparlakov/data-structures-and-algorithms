using System;
class BinaryPassswords
{
    static void Main()
    {
        ulong powerOfTwo = 1;
        string password;
        password = Console.ReadLine();
        int lenght = password.Length;
        for (int i = 0; i < lenght; i++)
        {
            if (password[i]=='*')
            {
                powerOfTwo *= 2;
            }
        }
        Console.WriteLine(powerOfTwo);
    }
}