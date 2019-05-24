using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace WPFPrimsToolKit.ViewModels
{
	/// <summary>
	/// Represents a River
	/// </summary>
	public class River // BRY : INotifyPropertyChanged
	{
		static River()
		{
		}

        private string name = string.Empty;
		public string Name
		{
			get { return name; }
			set { name = value; }
        }
            
        private int milesLong = 0;
        public int MilesLong
		{
            get { return milesLong; }
            set { milesLong = value; }
		}
	}
}