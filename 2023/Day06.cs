using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		var boat = new Boat();
		var results = boat.Beat(new BoatRace { Duration = 7, Distance = 9 });
		Console.WriteLine(results.Count());
	    results = boat.Beat(new BoatRace { Duration = 15, Distance = 40 });
		Console.WriteLine(results.Count());
	    results = boat.Beat(new BoatRace { Duration = 30, Distance = 200 });
		Console.WriteLine(results.Count());
		
		var result = 1;
		foreach(var race in Parse(Data.Task)) {
			var count = boat.Beat(race).Count(); 
			result = result * count;
		}
		
		result = 1;
		foreach(var race in Parse2(Data.Task)) {
			var count = boat.Beat(race).Count(); 
			result = result * count;
		}
		Console.WriteLine(result);
				
	}
	
	private static IEnumerable<BoatRace> Parse(string input) {
		var parts = input.Split(Environment.NewLine);
		var times = parts[0].Replace("Time:", "").Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
		var distances = parts[1].Replace("Distance:", "").Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
		
		for(var i=0; i<times.Length; i++) {
			yield return new BoatRace{ 
				Duration = times[i], 
				Distance = distances[i] 
			};
		}
	}
	
	private static IEnumerable<BoatRace> Parse2(string input) 
	{
		var parts = input.Split(Environment.NewLine);
		var times = long.Parse( parts[0].Replace("Time:", "").Replace(" ", "") );
		var distances = long.Parse(parts[1].Replace("Distance:", "").Replace(" ", ""));
		
		yield return new BoatRace{ Duration = times, Distance = distances };
	}
}

public class BoatRace {
	public long Duration {get; set;}
	public long Distance {get;set;}
}

public class Boat{
	public IEnumerable<(long HoldTime, long Distance)> Beat(BoatRace record) {
		for(var holdTime = 1; holdTime < record.Duration -1; holdTime++){
			var remainingTime = record.Duration - holdTime;
			var speed = holdTime;
			var distance = speed * remainingTime;
			if (distance > record.Distance) 
			{
				yield return new (holdTime, distance);
			}
		}
	}
}

public static class Data {
	public static string Task = @"Time:        62     73     75     65
Distance:   644   1023   1240   1023";
	public static string Test = @"Time:      7  15   30
Distance:  9  40  200";
}
