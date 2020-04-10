using System.Drawing;
using System.Windows.Forms;

namespace FitCompare
{
    public partial class MainForm : Form
    {
        private ClipboardManager manager;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            //TopMost = true;
            SetupDataGrid(ListDataGrid1);
            SetupDataGrid(ListDataGrid2);

            manager = new ClipboardManager();
            OneList list1 = new OneList(ListDataGrid1);
            OneList list2 = new OneList(ListDataGrid2);
            list2.SetNext(list1);
            manager.SetList(list2);

            // добавляем чекбокс в тулбар
            CheckBox checkBoxTopMost = new CheckBox();
            checkBoxTopMost.Text = "Stay on top";
            checkBoxTopMost.Checked = TopMost;
            checkBoxTopMost.CheckStateChanged += checkBoxTopMost_CheckStateChanged;
            checkBoxTopMost.BackColor = Color.Transparent;
            ToolStripControlHost controlHost = new ToolStripControlHost(checkBoxTopMost);
            controlHost.Alignment = ToolStripItemAlignment.Right;
            StripTools.Items.Add(controlHost);
            /////// 
            manager.SetText("[Typhoon Fleet Issue, Fleet Issue 10/10 test]\nIFFA Compact Damage Control\nDrone Damage Amplifier II\nDrone Damage Amplifier II\nDrone Damage Amplifier II\nBallistic Control System II\nBallistic Control System II\nBallistic Control System II\n\nGist X-Type Explosive Deflection Field\nAdaptive Invulnerability Field II\nLarge Cap Battery II\nGist X-Type Large Shield Booster\nLarge Micro Jump Drive\n\nCruise Missile Launcher II\nCruise Missile Launcher II\nCruise Missile Launcher II\nCruise Missile Launcher II\nCruise Missile Launcher II\nCruise Missile Launcher II\n\nLarge Warhead Rigor Catalyst I\nLarge Capacitor Control Circuit I\nLarge Capacitor Control Circuit I\n\n\n\nRepublic Fleet Berserker x2\n\nScourge Cruise Missile x162");
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

            DataGridViewTextBoxColumn textColumn1 = new DataGridViewTextBoxColumn();
            textColumn1.HeaderText = "TEMP";
            textColumn1.DataPropertyName = "ItemType";
            textColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg.Columns.Add(textColumn1);
        }

        private void checkBoxTopMost_CheckStateChanged(object sender, System.EventArgs e)
        {
            TopMost = ((CheckBox)sender).Checked;
        }

        private void ButtonTest_Click(object sender, System.EventArgs e)
        {
            manager.SetText("[Typhoon Fleet Issue, Fleet Issue 10/10 test]\nIFFA Compact Damage Control\nDrone Damage Amplifier II\nDrone Damage Amplifier II\nDrone Damage Amplifier II\nBallistic Control System II\nBallistic Control System II\nBallistic Control System II\n\nGist X-Type Explosive Deflection Field\nAdaptive Invulnerability Field II\nLarge Cap Battery II\nGist X-Type Large Shield Booster\nLarge Micro Jump Drive\n\nCruise Missile Launcher II\nCruise Missile Launcher II\nCruise Missile Launcher II\nCruise Missile Launcher II\nCruise Missile Launcher II\nCruise Missile Launcher II\n\nLarge Warhead Rigor Catalyst I\nLarge Capacitor Control Circuit I\nLarge Capacitor Control Circuit I\n\n\n\nRepublic Fleet Berserker x2\n\nScourge Cruise Missile x162");
        }
    }
}
