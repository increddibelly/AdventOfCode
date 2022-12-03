namespace AdventOfCode;

public class Day02
{
    const string Input_Rock = "A";
    const string Input_Paper = "B";
    const string Input_Scissors = "C";

    const string SolutionTo_Rock = "Y"; // paper
    const string SolutionTo_Paper = "Z"; // scissors
    const string SolutionTo_Scissors = "X"; // rock

    const string Should_Lose = "X";
    const string Should_Draw = "Y";
    const string Should_Win = "Z";

    const int Score_Win = 6;
    const int Score_Draw = 3;
    const int Score_Lose = 0;

    const int Score_Rock = 1;
    const int Score_Paper = 2;
    const int Score_Scissors = 3;
    
    public static List<KeyValuePair<string, string>> Parse(string input)
    {
        return input.Split(Environment.NewLine)
            .Select(x => x.Split(" "))
            .Select(x => new KeyValuePair<string, string>(x[0], x[1]))
            .ToList();
    }

    private int ScoreMatch(string input, string played)
    {
        if (input == Input_Rock && played == SolutionTo_Scissors) return Score_Draw;
        if (input == Input_Paper && played == SolutionTo_Rock) return Score_Draw;
        if (input == Input_Scissors && played == SolutionTo_Paper) return Score_Draw;

        switch (input)
        {
            case Input_Rock: return played == SolutionTo_Rock ? Score_Win : Score_Lose;
            case Input_Paper: return played == SolutionTo_Paper ? Score_Win : Score_Lose;
            case Input_Scissors: return played == SolutionTo_Scissors ? Score_Win : Score_Lose;
        }
        return Score_Draw;
    }

    private int ScorePlayed(string played)
    {
        switch(played)
        {
            case SolutionTo_Rock: return Score_Paper;
            case SolutionTo_Paper: return Score_Scissors;
            case SolutionTo_Scissors: return Score_Rock;
        }
        return 0;
    }

    public int Day02Part1(List<KeyValuePair<string, string>> input)
    {
        var score = 0;
        foreach (var game in input)
        {
            var playedValue = ScorePlayed(game.Value);
            var matchValue = ScoreMatch(game.Key, game.Value);
            score += (matchValue + playedValue);
        }
        return score;
    }

    public int Day02Part2(List<KeyValuePair<string, string>> input)
    {
        var score = 0;
        foreach (var game in input)
        {
            var played = ForceResult(game);
            var playedValue = ScorePlayed(played);
            var matchValue = ScoreMatch(game.Key, played);
            score += (matchValue + playedValue);
        }
        return score;
    }

    private string ForceResult(KeyValuePair<string, string> game)
    {


        switch (game.Key)
        {
            case Input_Rock:
                switch (game.Value)
                {
                    case Should_Draw: return SolutionTo_Scissors;
                    case Should_Lose: return SolutionTo_Paper;
                    case Should_Win: return SolutionTo_Rock;
                }
                break;

            case Input_Paper:
                switch (game.Value)
                {
                    case Should_Draw: return SolutionTo_Rock;
                    case Should_Lose: return SolutionTo_Scissors;
                    case Should_Win: return SolutionTo_Paper;
                }
                break;

            case Input_Scissors:
                switch (game.Value)
                {
                    case Should_Draw: return SolutionTo_Paper;
                    case Should_Lose: return SolutionTo_Rock;
                    case Should_Win: return SolutionTo_Scissors;
                }
                break;
        }
        return null;
    }
}
