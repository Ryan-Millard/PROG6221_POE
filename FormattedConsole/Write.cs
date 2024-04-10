using System;
using System.Reflection;

namespace FormattedConsole
{
	public static class PrettyConsole
	{
		// Enhanced Console.Write that takes text segments with optional foreground and background colors
		public static void Write(
				Action<string> WriteMethod,
				params (string Text, ConsoleColor Foreground, ConsoleColor Background)[] textSegments)
		{
			if(!IsConsoleWriteMethod(WriteMethod))
				throw new ArgumentException("Only Console.Write or Console.WriteLine methods are allowed.");

			foreach(var (Text, Foreground, Background) in textSegments)
			{
				Console.ForegroundColor = Foreground;
				Console.BackgroundColor = Background;
				WriteMethod(Text);
			}
			Console.ResetColor(); // Reset colors after writing
		}

		// Method to check if the provided method is Console.Write or Console.WriteLine
		private static bool IsConsoleWriteMethod(Action<string> method)
		{
			var methodInfo = method.Method;
			return   methodInfo.DeclaringType == typeof(Console) &&
					(methodInfo.Name == "Write" ||
					 methodInfo.Name == "WriteLine");
		}

	}
}
