using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FitCompare
{
    public partial class MainForm : Form
    {
        private ClipboardManager manager;
        private AppSettings config;
        private NotifyIcon tray = new NotifyIcon();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            //tray
            Resize += MainForm_Resize;
            Disposed += MainForm_Disposed;
            tray.Visible = true;
            tray.BalloonTipTitle = Text;
            tray.Icon = System.Drawing.SystemIcons.Information;
            tray.MouseDoubleClick += Tray_MouseDoubleClick;

            SetupDataGrid(ListDataGrid1);
            SetupDataGrid(ListDataGrid2);

            manager = new ClipboardManager();
            CompareItemsList list1 = new CompareItemsList(ListDataGrid1);
            CompareItemsList list2 = new CompareItemsList(ListDataGrid2);
            list2.SetNext(list1);
            manager.SetList(list2);

            // Load settings
            config = new AppSettings();

            // Add checkbox
            CheckBox checkBoxTopMost = new CheckBox();
            checkBoxTopMost.DataBindings.Add(new Binding("Checked", config, "StayOnTop"));
            checkBoxTopMost.Text = "Stay on top";
            checkBoxTopMost.CheckStateChanged += checkBoxTopMost_CheckStateChanged;
            checkBoxTopMost.BackColor = Color.Transparent;

            ToolStripControlHost controlHost = new ToolStripControlHost(checkBoxTopMost);
            controlHost.Alignment = ToolStripItemAlignment.Right;
            StripTools.Items.Add(controlHost);
        }

        private void Tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
            Activate();
            ShowInTaskbar = true;
        }

        private void MainForm_Resize(object sender, System.EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
            }
        }

        private void MainForm_Disposed(object sender, System.EventArgs e)
        {
            tray.Visible = false;
        }

        private void SetupDataGrid(DataGridView dg)
        {
            dg.RowHeadersVisible = false;
            dg.MultiSelect = false;
            dg.BackgroundColor = Color.White;
            // size by height
            dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dg.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dg.AutoGenerateColumns = false;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "";
            imageColumn.DataPropertyName = "MatchedIcon";
            imageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dg.Columns.Add(imageColumn);

            imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "";
            imageColumn.DataPropertyName = "ItemTypeIcon";
            imageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dg.Columns.Add(imageColumn);

            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Name";
            textColumn.DataPropertyName = "RawText";
            textColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg.Columns.Add(textColumn);

            /*
            DataGridViewTextBoxColumn textColumn1 = new DataGridViewTextBoxColumn();
            textColumn1.HeaderText = "TEMP";
            textColumn1.DataPropertyName = "ItemType";
            textColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg.Columns.Add(textColumn1);
            */
        }

        private void checkBoxTopMost_CheckStateChanged(object sender, System.EventArgs e)
        {
            TopMost = ((CheckBox)sender).Checked;
        }

        private void ButtonTest_Click(object sender, System.EventArgs e)
        {
            manager.SetText("[Typhoon Fleet Issue, Fleet Issue 10/10 test]\nIFFA Compact Damage Control\nDrone Damage Amplifier II\nDrone Damage Amplifier II\nDrone Damage Amplifier II\nBallistic Control System II\nBallistic Control System II\nBallistic Control System II\n\nGist X-Type Explosive Deflection Field\nAdaptive Invulnerability Field II\nLarge Cap Battery II\nGist X-Type Large Shield Booster\nLarge Micro Jump Drive\n\nCruise Missile Launcher II\nCruise Missile Launcher II\nCruise Missile Launcher II\nCruise Missile Launcher II\nCruise Missile Launcher II\nCruise Missile Launcher II\n\nLarge Warhead Rigor Catalyst I\nLarge Capacitor Control Circuit I\nLarge Capacitor Control Circuit I\n\n\n\nRepublic Fleet Berserker x2\n\nScourge Cruise Missile x162");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //config.SaveState(this);
            config.Save();
        }
    }
}
