using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World");
	}
}

public class Card {
	public static Dictionary<char, int> Values = new Dictionary<char, int> {
		{ 'A', 14},
		{ 'K', 13},
		{ 'Q', 12},
		{ 'J', 11},
		{ 'T', 10},
		{ '9', 9},
		{ '8', 8},
		{ '7', 7},
		{ '6', 6},
		{ '5', 5},
		{ '4', 4},
		{ '3', 3},
		{ '2', 2 },
	};
	
	public char Value { get; private set; }
	
	public static bool operator > (Card other) {
		return Values[Value] > Values[other.Value];
	}
	
	public static bool operator < (Card other) {
		return Values[other.Value] > Values[Value];
	}
	
	public static IEnumerable<Card> Parse(string input) {
		return input.Select(c => new Card {
			Value = c
		});
	}
}
