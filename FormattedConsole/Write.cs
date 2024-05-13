using System;
using System.Reflection;

namespace FormattedConsole
{
	public static class PrettyConsole
	{
		public static void Write(
				Action<string> WriteMethod, // allows either Write or WriteLine to be passed
				params(string text, ConsoleColor foreground)[] textSegments)
		// enhanced Console.Write that takes text segments with optional foreground
		{
			if(!IsConsoleWriteMethod(WriteMethod))
				throw new ArgumentException("Only Console.Write or Console.WriteLine methods are allowed.");

			foreach(var (text, foreground) in textSegments)
			{
				// set the colors and print to the console
				Console.ForegroundColor = foreground;
				WriteMethod(text ?? "");
				Console.ResetColor(); // Reset colors after writing
			}
		}

		private static bool IsConsoleWriteMethod(Action<string> method)
		// check if provided method is Console.Write() or Console.WriteLine()
		{
			// reflection to get the method's name as a string
			var methodInfo = method.Method;
			// method name must be Console's Write or WriteLine
			return   methodInfo.DeclaringType == typeof(Console) &&
					(methodInfo.Name == "Write" ||
					 methodInfo.Name == "WriteLine");
		}

	}
}
