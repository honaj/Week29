List<Purchase> purchases = new();

ConsoleKeyInfo keyInput;
do 
{
    keyInput = Console.ReadKey(true);
    
} while (keyInput.Key != ConsoleKey.Q);