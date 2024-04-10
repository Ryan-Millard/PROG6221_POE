using System;
using FormattedConsole;

namespace Program
{
	class Program
	{
		static void Main(string[] args)
		{
			PrettyConsole.Write(Console.Write, ("Hello", ConsoleColor.Red, ConsoleColor.Yellow));
		}
	}
}
