//----------------------------------------------------------
// <filename>Config.cs</filename>
// <author>BRY</author>
// <date>04/07/2012</date>
// <company>SoDevLog</company>
// <copyright file="Config.cs" company="SoDevLog">
// 	Copyright (c) SoDevLog. All rights reserved.
// </copyright> 
//----------------------------------------------------------
namespace WPFPrimsToolKit
{
    using System;
	using System.Configuration;
    using System.Collections.Specialized;

	/// <summary>
    /// If the value does not exist in Config file return the default value
    /// else return the value set in Config file.
	/// </summary>
	public class Config
	{
		/// <summary>
        /// Get the IsInDebugMode value
		/// </summary>
		public bool IsInDebugMode
		{
			get
			{
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["IsInDebugMode"].ToString()))
                {
                    return false;
                }
                return bool.Parse(ConfigurationManager.AppSettings["IsInDebugMode"]);
			}
		}

		/// <summary>
		/// Gets or sets the path of the directory of the last setting save.
		/// </summary>
		public string SettingLastSavePath
		{
			get
			{
				return ConfigurationManager.AppSettings["Setting_LastSavePath"];
			}

			set
			{
				this.WriteSetting(value, "Setting_LastSavePath", "appSettings");
			}
		}

		/// <summary>
		/// Update the value of a setting
		/// </summary>
		/// <param name="value">New value of the setting</param>
		/// <param name="settingKey">Name of the setting (see it in the App.Config file</param>
		/// <param name="section">Name of the section (often appSettings)</param>
		private void WriteSetting(string value, string settingKey, string section)
		{
			//// Open the config file
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			//// Set the new value in the memory
			config.AppSettings.Settings[settingKey].Value = value;
			//// Update the config file
			config.Save(ConfigurationSaveMode.Modified);
			//// Refresh the file in the memory
			//// If this line is missing, the current application continue to use the old value of the setting
			ConfigurationManager.RefreshSection(section);
		}
	}
}
