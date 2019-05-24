//----------------------------------------------------------
// <filename>Log.cs</filename>
// <author>BRY</author>
// <date>04/07/2012</date>
// <company>SoDevLog</company>
// <copyright file="Log.cs" company="SoDevLog">
// 	Copyright (c) SoDevLog. All rights reserved.
// </copyright> 
//----------------------------------------------------------
namespace Log4
{
	using System;
	using System.Diagnostics;
	using System.IO;
	using log4net;
	using log4net.Config;
	using log4net.Core;
	using log4net.Repository.Hierarchy;

	/// <summary>
	/// Class for logging events throught Log4Net.
	/// Use a "Log4Net.config" file in your application to configure the way you want to log events.
	/// </summary>
	internal class Log
	{
		private readonly string configFileName = "Log4Net.config";
		private readonly int stackLevel = 2;
		private readonly char loggerNameSeparator = '|';

		private readonly Action<ILog, string> actionDebug = (x, y) => x.Debug(y);
		private readonly Action<ILog, string> actionInfo = (x, y) => x.Info(y);
		private readonly Action<ILog, string> actionWarn = (x, y) => x.Warn(y);
		private readonly Action<ILog, string> actionError = (x, y) => x.Error(y);
		private readonly Action<ILog, string> actionFatal = (x, y) => x.Fatal(y);

		private static Log instance = new Log();

		private Log()
		{
			// Load configuration file
			if (!((Hierarchy)LogManager.GetRepository()).Configured)
			{
				XmlConfigurator.ConfigureAndWatch(new FileInfo(this.configFileName));
			}
		}

		#region ILogService Membres

		/// <summary>
		/// Add a debug message
		/// </summary>
		/// <param name="message">message to add</param>
		public static void Debug(string message)
		{
			Log.instance.LogMessage(message, null, Level.Debug, Log.instance.actionDebug);
		}

		/// <summary>
		/// Add an info message
		/// </summary>
		/// <param name="message">message to add</param>
		public static void Info(string message)
		{
			Log.instance.LogMessage(message, null, Level.Info, Log.instance.actionInfo);
		}

		/// <summary>
		/// Add a warn message
		/// </summary>
		/// <param name="message">message to add</param>
		public static void Warn(string message)
		{
			Log.instance.LogMessage(message, null, Level.Warn, Log.instance.actionWarn);
		}

		/// <summary>
		/// Add an error message
		/// </summary>
		/// <param name="message">message to add</param>
		public static void Error(string message)
		{
			Log.instance.LogMessage(message, null, Level.Error, Log.instance.actionError);
		}

		/// <summary>
		/// Add a fatal message
		/// </summary>
		/// <param name="message">message to add</param>
		public static void Fatal(string message)
		{
			Log.instance.LogMessage(message, null, Level.Fatal, Log.instance.actionFatal);
		}

		/// <summary>
		/// Add a debug message (better performance)
		/// </summary>
		/// <param name="sender">type of sender is used to retrieve the corresponding logger</param>
		/// <param name="message">message to add</param>
		public static void Debug(object sender, string message)
		{
			Log.instance.LogMessage(message, sender.GetType(), Level.Debug, Log.instance.actionDebug);
		}

		/// <summary>
		/// Add an info message (better performance)
		/// </summary>
		/// <param name="sender">type of sender is used to retrieve the corresponding logger</param>
		/// <param name="message">message to add</param>
		public static void Info(object sender, string message)
		{
			Log.instance.LogMessage(message, sender.GetType(), Level.Info, Log.instance.actionInfo);
		}

		/// <summary>
		/// Add a warn message (better performance)
		/// </summary>
		/// <param name="sender">type of sender is used to retrieve the corresponding logger</param>
		/// <param name="message">message to add</param>
		public static void Warn(object sender, string message)
		{
			Log.instance.LogMessage(message, sender.GetType(), Level.Warn, Log.instance.actionWarn);
		}

		/// <summary>
		/// Add an error message (better performance)
		/// </summary>
		/// <param name="sender">type of sender is used to retrieve the corresponding logger</param>
		/// <param name="message">message to add</param>
		public static void Error(object sender, string message)
		{
			Log.instance.LogMessage(message, sender.GetType(), Level.Error, Log.instance.actionError);
		}

		/// <summary>
		/// Add a fatal message (better performance)
		/// </summary>
		/// <param name="sender">type of sender is used to retrieve the corresponding logger</param>
		/// <param name="message">message to add</param>
		public static void Fatal(object sender, string message)
		{
			Log.instance.LogMessage(message, sender.GetType(), Level.Fatal, Log.instance.actionFatal);
		}

		#endregion

		private void LogMessage(string message, Type logType, Level expectedLevel, Action<ILog, string> action)
		{
			string messageToLog = message;
			string logTypeName;
			StackFrame stackFrame = null;
			if (logType == null)
			{
				stackFrame = new StackFrame(this.stackLevel, true);
				logTypeName = stackFrame.GetMethod().DeclaringType.FullName;
			}
			else
			{
				logTypeName = logType.FullName;
#if DEBUG
				stackFrame = new StackFrame(this.stackLevel, true);
#endif
			}

#if DEBUG
			messageToLog += this.BuildDebugMessage(stackFrame);
#endif

			ILog log = this.FindDefineLogger(logTypeName);
			if (log.Logger.IsEnabledFor(expectedLevel))
			{
				action(log, messageToLog);
			}
		}

		private ILog FindDefineLogger(string typeName)
		{
			ILog logger = null;
			if ((logger = LogManager.Exists(typeName.Replace('.', this.loggerNameSeparator))) == null)
			{
				int indexOfSep = typeName.LastIndexOf('.');
				if (indexOfSep > 0)
				{
					return this.FindDefineLogger(typeName.Remove(indexOfSep));
				}
			}

			if (logger != null)
			{
				return logger;
			}

			return LogManager.GetLogger(typeName);
		}

		private string BuildDebugMessage(StackFrame stackFrame)
		{
			Type logType = stackFrame.GetMethod().DeclaringType;
			string className = stackFrame.GetMethod().DeclaringType.Name;
			string methodName = stackFrame.GetMethod().Name;
			string lineNumber = stackFrame.GetFileLineNumber().ToString();
			return String.Format("\t({0}:{1}({2}))", className, methodName, lineNumber);
		}
	}
}
