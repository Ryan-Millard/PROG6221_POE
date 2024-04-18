using System;
using System.Reflection;

namespace FormattedConsole
{
	public static class PrettyConsole
	{
		// Enhanced Console.Write that takes text segments with optional foreground and background colors
		public static void Write(
				Action<string> WriteMethod, // allows either Write or WriteLine to be passed
				params (string Text, ConsoleColor Foreground, ConsoleColor Background)[] textSegments)
		{
			if(!IsConsoleWriteMethod(WriteMethod))
				throw new ArgumentException("Only Console.Write or Console.WriteLine methods are allowed.");

			foreach(var (Text, Foreground, Background) in textSegments)
			{
				// set the colors and print to the console
				Console.ForegroundColor = Foreground;
				Console.BackgroundColor = Background;
				WriteMethod(Text ?? "");
			}
			Console.ResetColor(); // Reset colors after writing
		}

		// Method to check if the provided method is Console.Write or Console.WriteLine
		private static bool IsConsoleWriteMethod(Action<string> method)
		{
			// reflection is used to get the method's name as a string
			var methodInfo = method.Method;
			// method name as a string must be either Console's Write or WriteLine
			return   methodInfo.DeclaringType == typeof(Console) &&
					(methodInfo.Name == "Write" ||
					 methodInfo.Name == "WriteLine");
		}

	}
}
