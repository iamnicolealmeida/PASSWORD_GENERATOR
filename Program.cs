using System;
using System.Security.Cryptography; 

public class PasswordGenerator
{
    public static string GeneratePassword(int length)
    {
        
        const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
        const string digits = "0123456789";
        const string specialChars = "!@#$%^&*()-_=+[]{}|;:,.<>?/";
        
       
        string allChars = upperCase + lowerCase + digits + specialChars;
        
       
        char[] password = new char[length];
        
      
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            byte[] randomNumber = new byte[1];
            
            for (int i = 0; i < length; i++)
            {
                rng.GetBytes(randomNumber);
                int randomIndex = randomNumber[0] % allChars.Length;
                password[i] = allChars[randomIndex];
            }
        }
        
        return new string(password);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
       
        Console.WriteLine("Enter the length for the password: ");
        int passwordLength;
        
        
        while (!int.TryParse(Console.ReadLine(), out passwordLength) || passwordLength <= 0)
        {
            Console.WriteLine("Please enter a valid positive integer for the password length:");
        }
        
        
        string password = PasswordGenerator.GeneratePassword(passwordLength);
        
        
        Console.WriteLine($"Generated Password: {password}");
    }
}
