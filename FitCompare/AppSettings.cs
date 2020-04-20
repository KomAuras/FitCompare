using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;
using System;

namespace FitCompare
{
    public class AppSettings : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        [DefaultSettingValue("0")]
        public bool StayOnTop
        {
            get
            {
                return ((bool)this["StayOnTop"]);
            }
            set
            {
                this["StayOnTop"] = (bool)value;
            }
        }
        //public int Test=1;
        //public Dictionary<string, WindowState> WindowStates = new Dictionary<string, WindowState>();
        //public void SaveState(Form f)
        //{
        //    if (!WindowStates.ContainsKey(f.Name))
        //    {
        //        WindowStates.Add(f.Name, new WindowState());
        //    }
        //    WindowStates[f.Name].Set(f);
        //}
        //public void RestoreState(Form f)
        //{
        //    //var name = f.Name;
        //    //f.WindowState = Properties.Settings.Default.F1State;
        //    //this.Location = Properties.Settings.Default.F1Location;
        //    //this.Size = Properties.Settings.Default.F1Size;
        //}
    }

    public class WindowState
    {
        public int windowState;
        public Point location;
        public Size size;

        public void Set(Form f)
        {
            windowState = (int)f.WindowState;
            location = f.Location;
            size = f.Size;
        }
    }
}
