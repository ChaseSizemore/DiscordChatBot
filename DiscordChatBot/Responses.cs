using System;
using Bot;

public class Responses
{
    public static string HandleResponse(string message)
    {
        string lowerMessage = message.ToLower();

        if (lowerMessage == "hello")
        {
            return "Hello!";
        }
        if (lowerMessage == "bye")
        {
            return "Bye!";
        }
        if (lowerMessage == "test")
        {
            return "Test!";
        }
        if (lowerMessage == "roll")
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 7);
            return $"You rolled a {randomNumber}!";
        }

        return "I don't understand you.";
    }
}

