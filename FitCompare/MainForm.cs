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
            manager.SetText("[пример, строки]\nпервая строка\nвторая строка\n\nтретья строка\n\n\nчетвертая строка\n\n\n\nпятая строка!");
        }

        private void SetupDataGrid(DataGridView dg)
        {
            dg.MultiSelect = false;
            //dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg.BackgroundColor = Color.White;
            dg.RowHeadersVisible = false;
            dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dg.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dg.AutoGenerateColumns = false;

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.HeaderText = "";
            imageColumn.DataPropertyName = "ItemTypeIcon";
            imageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dg.Columns.Add(imageColumn);

            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.HeaderText = "Name";
            textColumn.DataPropertyName = "RawText";
            dg.Columns.Add(textColumn);
        }

        private void checkBoxTopMost_CheckStateChanged(object sender, System.EventArgs e)
        {
            TopMost = ((CheckBox)sender).Checked;
        }

        private void ButtonTest_Click(object sender, System.EventArgs e)
        {
            manager.SetText("[пример, строки]\nпервая строка\nвторая строка\n\nтретья строка\n\n\nчетвертая строка\n\n\n\nпятая строка!");
        }
    }
}
