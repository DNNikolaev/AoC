using System.Text.RegularExpressions;

var maxAmountByColor = new Dictionary<string, int>()
{
    { "red", 12 },
    { "green", 13 },
    { "blue", 14 },
};

using (var reader = new StreamReader(@"..\..\..\input"))
{
    string line;
    var sum = 0;
    var stageTwoSum = 0;
    while ((line = reader.ReadLine()) != null)
    {
        var power = 1;
        var minimumCubesByColor = new Dictionary<string, int>()
        {
            { "red", 0 },
            { "green", 0 },
            { "blue", 0 },
        };
        var valid = true;
        var splitted = line.Split(':');
        var gameId = Regex.Replace(splitted[0], @"[^\d]", "");
        Console.WriteLine($"Game ID: {gameId}");
        var gameReveals = splitted[1].Replace(" ", "").Split(';');
        foreach (var gameReveal in gameReveals)
        {
            var revealedColors = gameReveal.Split(',');
            foreach (var revealedColor in revealedColors)
            {
                var color = Regex.Replace(revealedColor, @"\d+", "");
                var amount = int.Parse(Regex.Replace(revealedColor, @"[^\d]", ""));              
                Console.WriteLine($"Color: {color}; amount: {amount}");
                if (minimumCubesByColor[color] < amount) minimumCubesByColor[color] = amount;
                if (maxAmountByColor[color] < amount)
                {
                    Console.WriteLine($"Invalid: {color}; max amount: {maxAmountByColor[color]}; actual amount: {amount}");
                    valid = false;
                    // break;
                }
            }
            // if (!valid) break;
        }

        foreach (var color in minimumCubesByColor)
        {
            power *= color.Value;
        }
        stageTwoSum += power;
        
        if (!valid) continue;
        
        sum += int.Parse(gameId);
    }    
    Console.WriteLine(sum);
    Console.WriteLine(stageTwoSum);
}

