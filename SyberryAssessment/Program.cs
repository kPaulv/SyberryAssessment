using SyberryAssessment.Utils;

string GameIteration(string input)
{
    // lines of game field
    string[] lines;
    
    // 'm' for lines number, 'n' for columns number 
    int m, n;

    // parse lines separated by '_'
    GameFieldOperator.ParseData(input, out lines);

    // set m, n from input
    GameFieldOperator.SetDimensions(lines, out m, out n);

    // two game fields: current state and new state after game cycle iteration
    int[,] universe = new int[m + 2, n + 2];
    int[,] newUniverse = new int[m + 2, n + 2];

    // load game fields
    GameFieldOperator.LoadGameField(m, n, lines, universe, newUniverse);

    // game cycle iteration
    GameFieldOperator.PerformGameIteration(universe, newUniverse, m, n);

    string answer;
    // form answer line
    GameFieldOperator.FormAnswer(newUniverse, m, n, out answer);

    return answer;
}



Console.WriteLine(GameIteration(Console.ReadLine()));

