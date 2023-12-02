using System;
using System.Linq;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		Run(task, testFilter);
	}
	
	private static void Run(string input, string filter) 
	{
		var games = new List<Game>();
		foreach(var line in input.Split(Environment.NewLine)) {
			var game = Game.Parse(line);
			games.Add(game);
			Console.WriteLine(game);
		}
		
		var cubeFilter = new Cube[] {
			new Cube {
				Color = Color.Red,
				Count = 12,
			}, 
			new Cube {
				Color = Color.Green,
				Count = 13,
			},
			new Cube {
				Color = Color.Blue,
				Count = 14,
			}
		};
		
		var sum = 0;
		foreach(var game in games)
		{
			var can = game.IsPossible(cubeFilter);
			Console.WriteLine($"{game.Id} can{(can ? "" : " not")} be made.");
			if (can) sum+= game.Id;
		}
		Console.WriteLine(sum);
		
		var powerSum = 0;
		foreach(var game in games) 
		{
			var minimumForGame = game.Minimum;
			var power = game.Power(minimumForGame.Cubes[0], minimumForGame.Cubes[1], minimumForGame.Cubes[2]);
			Console.WriteLine($"{game.Id} -> {game.Minimum}, {power}");
			powerSum += power;
		}
		Console.WriteLine($"power: {powerSum}");
	}
	
	public enum Color 
	{
		Red,
		Green,
		Blue
	}

	public class Game 
	{
		public int Id {get;set;}
		public List<Set> Sets {get;set;}
		
		public static Game Parse(string line) 
		{
			// Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
			var prep = line.Replace("Game ", "").Split(": ");
			var id = int.Parse(prep[0]);
			var sets = prep[1].Split("; ");

			return new Game {
				Id = id,
				Sets = Set.Parse(sets).ToList()
			};	
		}
		
		public Set Minimum 
		{
			get {
				var minimalCubeCountPerColor = 
					Sets.SelectMany(cubeSet => cubeSet.Cubes)
						.GroupBy(c => c.Color)
						.ToDictionary(c => c.Key, c => c.Max(cs => cs.Count));
					
				return new Set {
					Cubes = minimalCubeCountPerColor.Select(c =>
						new Cube{
							Color = c.Key,
							Count = c.Value
						}).ToList()
				};
			}
		}
		
		public int Power(Cube red, Cube green, Cube blue) 
			=> red.Count * green.Count * blue.Count;			
				
		public bool IsPossible(params Cube[] filter) 
		{
			foreach(var cube in filter)
			{
				if (Sets.Any(s => s.Cubes.Any(c => c.Color == cube.Color && c.Count > cube.Count)))
				{
					return false;
				}
			}
			return true;
		}
		
		public override string ToString() {
			return $"Game {Id:0000}, {Sets.Count} sets : {string.Join("; ", Sets.Select(s => s.ToString()))})";
		}
	}

	public class Set 
	{
		public List<Cube> Cubes {get;set;}
		
		public static IEnumerable<Set> Parse(string[] sets) 
		{
			// 1 blue, 2 green; 
			// 3 green, 4 blue, 1 red; 
			// 1 green, 1 blue
			var output = new List<Set>();
			foreach(var CubeSet in sets) 
			{
				var items = CubeSet.Split(", ");
				output.Add(new Set {
					Cubes = items.Select(Cube.Parse).ToList()
				});
			}
			return output;
		}
		
		public override string ToString()
		{
			return string.Join(',', Cubes.Select(r => r.ToString()));
		}
	}
	
	public class Cube 
	{
		public Color Color {get;set;}
		public int Count {get;set;}
		
		public static Cube Parse(string input) 
		{
			var prep = input.Split(" ");
			return new Cube {
				Count = int.Parse(prep[0]),
				Color = prep[1] == "red" ? Color.Red : prep[1] == "blue"? Color.Blue : Color.Green
			};
		}
		
		public override string ToString()
		{
			return $"{Count} {Color}";
		}
	}
	
	private static string testFilter = @"12 red cubes, 13 green cubes, and 14 blue cubes";

	private static string test = @"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
	
	private static string task = @"Game 1: 1 red, 3 blue, 11 green; 1 blue, 5 red; 3 blue, 5 green, 13 red; 6 red, 1 blue, 4 green; 16 red, 12 green
Game 2: 3 red, 13 blue, 5 green; 14 green, 14 blue; 9 blue, 10 green, 3 red; 2 green, 5 blue; 11 green, 3 blue, 3 red; 16 blue, 2 red, 9 green
Game 3: 17 blue, 5 red; 3 red, 11 green, 17 blue; 1 red, 6 blue, 9 green; 3 blue, 11 green, 1 red; 3 green, 10 red, 11 blue; 12 red, 3 green, 15 blue
Game 4: 14 green, 14 red, 1 blue; 15 red, 13 green, 1 blue; 6 green, 15 red; 7 green
Game 5: 3 green, 1 blue, 3 red; 6 red, 2 green, 2 blue; 12 red, 3 green, 1 blue; 2 green, 9 red; 1 blue; 2 blue, 10 red
Game 6: 5 blue, 5 green; 4 blue, 1 red, 10 green; 16 green, 1 red, 6 blue; 1 red, 1 blue, 13 green; 1 red, 5 blue, 7 green; 14 green, 17 blue
Game 7: 1 green, 8 blue, 4 red; 1 green, 4 blue, 4 red; 6 blue, 4 red, 4 green; 1 red, 8 green
Game 8: 2 red, 5 blue, 1 green; 1 blue, 4 red, 8 green; 6 blue, 12 green, 6 red; 3 blue, 5 red; 8 red, 2 blue, 13 green; 5 green, 4 red, 3 blue
Game 9: 11 red; 1 green, 2 red, 2 blue; 1 blue, 2 green, 9 red; 4 red, 2 green, 2 blue; 1 blue, 2 green; 1 blue, 9 red, 2 green
Game 10: 9 red, 4 green; 1 blue, 3 red, 7 green; 3 green, 1 red, 1 blue; 7 green, 4 red, 1 blue; 1 blue, 5 green, 10 red; 1 red, 5 green
Game 11: 2 blue, 4 red, 3 green; 1 blue, 7 red; 4 green, 7 red, 1 blue; 3 blue, 6 green, 4 red; 3 red, 1 green, 3 blue
Game 12: 1 green, 6 red, 5 blue; 3 green, 2 red, 4 blue; 3 green, 1 red, 3 blue
Game 13: 6 green, 1 red, 9 blue; 11 red, 4 blue, 12 green; 6 green, 9 red, 19 blue; 2 green, 6 blue; 10 green, 1 red, 16 blue; 4 green, 14 blue
Game 14: 7 blue, 2 red; 1 green, 2 red, 19 blue; 12 blue, 6 green, 11 red
Game 15: 4 red, 4 green, 7 blue; 15 blue, 1 green, 8 red; 2 red, 10 green, 11 blue; 5 red, 4 blue, 6 green; 9 red, 8 blue, 3 green; 9 blue, 9 red
Game 16: 7 red, 2 blue, 19 green; 6 blue, 9 green; 8 green, 6 red, 19 blue; 11 green, 7 red, 1 blue; 9 blue, 3 red, 17 green
Game 17: 3 blue, 4 green, 5 red; 2 red, 4 green, 11 blue; 6 blue, 13 green; 3 blue, 12 green, 7 red
Game 18: 9 red, 6 blue, 7 green; 3 green, 3 blue, 5 red; 18 red, 6 blue, 4 green; 3 green, 10 red, 8 blue
Game 19: 3 red, 6 green; 1 red, 5 green, 4 blue; 3 red, 14 blue
Game 20: 2 green, 2 blue, 4 red; 14 red, 6 blue, 5 green; 1 blue, 5 red, 3 green; 10 red, 6 green, 6 blue
Game 21: 10 blue, 12 green, 3 red; 1 green, 14 red; 5 blue, 7 green; 12 blue, 1 red, 13 green; 7 red, 4 green
Game 22: 2 red, 1 blue; 1 red, 2 blue; 1 red, 1 green, 3 blue; 3 blue; 1 red; 1 green, 2 red
Game 23: 4 blue, 4 green, 1 red; 3 blue, 1 red, 6 green; 1 red, 1 blue
Game 24: 5 blue, 15 green, 13 red; 20 green, 13 blue, 6 red; 5 blue, 11 red, 16 green; 6 red, 5 blue, 13 green; 12 blue, 13 green, 3 red
Game 25: 10 blue, 17 red; 12 red, 16 blue, 3 green; 4 green, 12 blue, 10 red; 8 blue, 3 green, 10 red; 5 green, 2 red, 12 blue
Game 26: 11 red, 9 blue; 3 blue, 3 red, 3 green; 10 blue, 3 green, 4 red; 1 green, 4 blue, 9 red; 5 green, 1 red, 7 blue; 1 red, 3 blue, 3 green
Game 27: 1 green, 12 red, 4 blue; 5 red, 2 green, 1 blue; 3 green, 6 blue, 10 red; 1 green, 4 red, 3 blue
Game 28: 6 blue; 2 green; 2 green, 8 blue, 1 red; 2 green, 2 blue; 6 blue, 8 green; 9 green, 5 blue
Game 29: 1 green, 9 blue, 9 red; 13 green, 4 red, 9 blue; 3 green, 8 blue, 15 red; 15 green, 18 blue, 3 red; 16 green, 10 red; 16 green, 12 blue, 16 red
Game 30: 14 blue, 4 green, 1 red; 7 red, 14 blue; 2 blue, 4 red, 1 green
Game 31: 2 red, 14 green, 3 blue; 3 blue, 3 green, 4 red; 8 blue, 4 red, 1 green; 8 green, 3 blue; 10 blue, 1 red, 11 green; 13 green, 2 red, 3 blue
Game 32: 8 blue, 16 red; 2 green, 8 blue, 16 red; 16 blue, 4 green, 17 red; 2 red, 5 green, 4 blue
Game 33: 2 red, 2 green, 1 blue; 5 red, 1 blue; 8 green, 14 red
Game 34: 4 red, 4 green; 9 green; 1 blue, 16 green; 1 blue, 5 red, 9 green; 2 red, 15 green, 1 blue
Game 35: 1 green, 5 red; 1 green, 15 red, 13 blue; 2 red, 13 blue, 17 green; 9 blue, 3 red, 11 green; 7 green, 8 blue, 14 red
Game 36: 19 green; 3 green, 1 blue, 1 red; 1 green, 8 blue; 13 green, 5 red, 5 blue
Game 37: 12 red, 7 green, 3 blue; 12 blue, 10 red, 9 green; 17 green, 8 red, 13 blue; 9 blue, 9 green, 8 red; 4 red, 13 green, 13 blue; 15 green, 12 red, 14 blue
Game 38: 5 blue, 1 green, 20 red; 1 green, 13 red, 18 blue; 17 blue, 9 red, 10 green; 4 blue, 4 red, 12 green; 12 blue, 12 red, 6 green; 12 green, 13 red, 2 blue
Game 39: 7 blue, 6 red, 2 green; 6 blue, 1 red; 7 blue, 1 red
Game 40: 1 blue, 3 red; 15 blue, 1 green; 1 green, 16 red, 2 blue
Game 41: 2 blue, 4 green; 8 green, 3 red; 2 blue, 9 red, 4 green; 4 red, 3 blue, 10 green; 5 green, 3 blue, 2 red
Game 42: 7 green, 2 blue, 1 red; 8 green, 4 red; 5 blue, 1 red, 3 green
Game 43: 3 red, 1 blue; 1 blue, 2 green, 2 red; 1 red, 2 blue; 3 blue
Game 44: 3 green, 14 blue, 1 red; 16 blue, 5 red, 11 green; 12 green, 1 blue; 13 blue, 1 red; 5 blue, 2 red, 6 green; 3 blue, 5 red, 11 green
Game 45: 7 blue, 1 red; 1 red, 3 blue; 3 green, 14 blue, 1 red; 4 blue, 3 green, 1 red; 15 blue, 1 red, 3 green
Game 46: 15 red, 4 blue; 15 red, 11 blue, 3 green; 14 red, 2 green, 2 blue; 14 red, 8 blue, 3 green; 4 red, 1 blue
Game 47: 4 green, 2 blue, 3 red; 8 red, 2 green, 18 blue; 1 green, 17 blue, 1 red
Game 48: 2 green, 4 red, 2 blue; 15 blue, 16 red, 5 green; 14 blue, 2 green, 10 red; 3 green, 13 red, 6 blue; 8 green, 4 red, 12 blue; 15 red, 3 green, 9 blue
Game 49: 1 green, 6 red, 7 blue; 1 blue, 9 green, 9 red; 4 green, 8 red; 9 blue, 1 red, 14 green; 2 blue, 9 red
Game 50: 3 red, 10 blue, 14 green; 2 red, 9 blue, 7 green; 4 blue, 12 green; 1 red, 4 green, 5 blue
Game 51: 2 green, 6 blue; 1 green, 10 blue, 1 red; 3 blue, 2 green
Game 52: 1 green, 4 red, 1 blue; 3 red, 5 green, 4 blue; 1 blue, 3 red, 5 green; 1 red, 1 green, 1 blue; 12 green, 2 red, 4 blue; 10 blue, 7 green, 1 red
Game 53: 12 red, 1 blue; 8 red, 11 blue, 11 green; 8 red, 6 blue, 13 green; 11 blue, 11 red, 16 green; 6 red, 9 green, 4 blue
Game 54: 2 red, 8 blue, 15 green; 4 green, 3 blue, 6 red; 12 green, 13 blue, 4 red
Game 55: 1 green, 16 blue, 4 red; 3 red, 1 blue, 1 green; 12 red, 16 blue; 3 red
Game 56: 4 green; 1 red, 4 green; 2 red, 3 blue, 7 green; 2 red, 3 blue, 15 green
Game 57: 17 green; 1 green, 9 blue; 1 red, 1 green, 9 blue
Game 58: 3 green, 8 red, 7 blue; 4 green, 9 blue, 2 red; 1 red, 2 green, 11 blue; 8 blue, 4 green
Game 59: 6 green, 1 red; 4 blue, 6 green; 4 green, 5 blue
Game 60: 3 green, 5 blue, 1 red; 7 green, 5 blue, 16 red; 14 red, 1 green, 1 blue; 7 green, 2 blue; 13 red, 5 green, 5 blue
Game 61: 1 green, 2 blue, 2 red; 2 green; 6 red, 1 blue, 1 green
Game 62: 5 red, 8 blue, 1 green; 1 red, 1 blue; 2 green, 8 blue
Game 63: 2 red, 2 blue, 2 green; 9 blue, 7 green; 1 green, 4 blue; 18 green, 3 blue
Game 64: 13 green, 1 blue, 6 red; 13 green, 15 red, 8 blue; 5 green, 14 red, 4 blue; 2 green, 8 blue, 12 red; 1 blue, 5 red, 13 green; 7 blue, 8 green, 2 red
Game 65: 7 blue, 12 red, 6 green; 11 red, 8 green, 8 blue; 9 red, 7 green, 7 blue; 14 red, 2 blue, 17 green
Game 66: 2 green, 5 red; 7 red, 14 blue; 19 blue, 2 green; 7 blue, 4 green, 6 red
Game 67: 4 green, 17 red, 7 blue; 4 blue, 6 green; 7 green, 7 red, 12 blue; 2 red, 14 blue
Game 68: 1 red, 11 green, 4 blue; 17 blue, 1 red, 10 green; 3 red, 7 green, 1 blue; 7 green, 3 red, 6 blue; 2 red, 3 green; 2 green, 2 red, 4 blue
Game 69: 5 blue, 4 red; 3 red, 11 green, 1 blue; 6 green, 2 blue; 10 green, 4 red, 5 blue; 2 red, 11 green
Game 70: 16 red, 7 blue, 1 green; 14 red, 1 blue, 4 green; 4 red, 4 green; 7 blue, 5 red, 2 green
Game 71: 14 red, 2 blue, 13 green; 7 green, 5 red, 2 blue; 3 blue, 9 green, 11 red; 10 red, 4 blue, 1 green
Game 72: 1 green, 2 red, 6 blue; 4 green, 4 red, 9 blue; 6 green, 8 blue, 1 red; 5 red, 4 green, 9 blue; 15 blue, 2 green, 7 red; 10 blue, 2 green, 10 red
Game 73: 7 green, 6 red, 7 blue; 6 blue, 5 red, 8 green; 5 blue, 5 red
Game 74: 11 red, 1 blue; 2 green, 4 blue, 1 red; 1 green, 2 blue, 11 red; 9 red, 5 blue; 15 red, 10 blue; 9 red, 3 blue
Game 75: 1 blue, 6 red, 9 green; 5 red, 1 blue, 8 green; 2 green, 2 red, 1 blue; 7 red, 1 green; 3 green, 6 red, 2 blue; 1 green, 1 red
Game 76: 16 red, 3 blue, 9 green; 4 blue, 4 green; 5 blue, 1 green, 10 red; 6 blue, 13 red; 1 blue, 2 green, 8 red
Game 77: 4 red, 4 blue; 5 blue, 5 red; 6 red, 3 green
Game 78: 11 green, 1 red; 1 blue, 18 green, 1 red; 6 green, 5 red, 2 blue; 6 red, 1 blue, 15 green; 5 green, 5 red
Game 79: 2 red, 3 green, 13 blue; 7 blue, 5 green; 4 blue, 2 red, 6 green; 6 green, 15 blue
Game 80: 9 green, 2 blue, 1 red; 8 green, 1 red; 1 blue, 7 green; 2 green, 1 blue; 3 green; 5 green, 1 red, 2 blue
Game 81: 2 blue, 8 green, 1 red; 3 green, 1 blue; 6 blue, 1 green; 3 blue, 3 green, 1 red; 2 green, 8 blue; 1 red, 8 blue, 2 green
Game 82: 5 blue, 4 red, 1 green; 9 red, 12 green, 8 blue; 9 red, 6 green, 15 blue; 8 blue, 10 red, 6 green
Game 83: 2 green, 7 blue, 4 red; 2 blue, 11 red, 9 green; 7 red, 7 green, 6 blue; 12 blue, 4 red, 11 green; 11 green, 7 blue; 7 green, 5 red, 2 blue
Game 84: 9 red, 1 blue, 7 green; 5 red, 5 green; 4 green, 4 blue; 4 green, 5 red
Game 85: 5 green, 13 red, 11 blue; 5 blue, 19 green, 15 red; 17 red, 3 green, 8 blue; 13 green, 10 red; 3 green, 17 red, 11 blue
Game 86: 1 green, 11 blue; 11 blue, 1 green, 8 red; 6 blue, 4 red; 4 blue, 17 red; 1 green, 15 red
Game 87: 3 green, 8 red, 6 blue; 6 red, 13 green, 1 blue; 4 blue, 8 red, 8 green
Game 88: 5 green, 5 blue; 3 green, 10 blue, 2 red; 6 blue, 7 red, 1 green; 5 green, 3 red, 11 blue; 8 red, 4 green, 6 blue
Game 89: 5 green, 10 blue, 12 red; 1 green, 13 red, 8 blue; 4 red, 11 green, 12 blue
Game 90: 4 green, 3 red, 11 blue; 1 green, 12 red, 12 blue; 9 blue, 5 red, 1 green; 2 green, 12 blue, 12 red
Game 91: 5 red, 8 blue, 1 green; 5 green, 3 blue; 9 blue, 7 green, 5 red; 1 green, 3 blue, 6 red; 9 blue, 11 green, 4 red; 2 green, 4 red, 10 blue
Game 92: 11 blue, 1 red, 6 green; 10 blue, 2 red; 4 red, 6 green, 19 blue
Game 93: 1 green, 3 blue, 3 red; 3 red; 5 blue, 3 red; 1 green, 4 red
Game 94: 9 red, 4 blue, 4 green; 1 blue, 6 red, 15 green; 10 red, 5 blue, 1 green; 2 blue, 4 green, 8 red
Game 95: 13 blue, 4 green, 3 red; 15 green, 3 red, 2 blue; 16 green, 8 blue, 2 red
Game 96: 15 blue, 7 green, 3 red; 5 red, 7 green, 17 blue; 6 red, 12 blue; 5 green, 10 blue, 4 red
Game 97: 5 red, 2 green; 8 red; 1 blue, 7 green, 2 red; 7 red, 15 green
Game 98: 6 green, 1 blue, 1 red; 3 green, 3 red; 1 blue, 13 green, 4 red
Game 99: 16 red, 5 blue, 9 green; 2 green, 7 blue, 2 red; 10 blue, 3 green; 9 red, 8 blue, 13 green; 16 green, 13 red, 10 blue
Game 100: 16 blue, 12 red, 3 green; 2 green, 7 blue; 5 blue, 4 green; 10 blue, 6 red, 6 green; 5 red, 12 blue, 2 green; 9 red, 12 blue, 11 green";
}
