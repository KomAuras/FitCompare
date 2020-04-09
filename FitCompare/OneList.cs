using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FitCompare
{
    class OneList
    {
        private DataGridView control;
        private OneList next;
        private string buffer = "";
        private List<CompareItem> items;

        public OneList(DataGridView list)
        {
            SetList(list);
            items = new List<CompareItem>();
        }

        public void SetList(DataGridView control)
        {
            this.control = control;
        }

        public void SetNext(OneList list)
        {
            next = list;
        }

        public void SetText(string text)
        {
            if (next != null && buffer.Length > 0)
                next.SetText(buffer);
            buffer = text;
            Parse();
            FillListBox();
        }

        private void Parse()
        {
            /*
             * Fit format
             * https://www.eveonline.com/ru/article/import-export-fittings
             */
            int blockNumber = 1;
            int prevBlockNumber = 1;
            items.Clear();
            foreach (string line in Regex.Split(buffer, "\r\n|\r|\n"))
            {
                if (line.Length == 0)
                {
                    blockNumber++;
                    continue;
                }
                else
                {
                    CompareItem item = new CompareItem(line);
                    switch (blockNumber)
                    {
                        case 1:
                            if (line[0] == '[')
                            {
                                item.ItemType = CompareItem.ItemTypes.Caption;
                                item.SetCompareText(line.Substring(1, line.IndexOf(',') - 1));
                            }
                            else
                                item.ItemType = CompareItem.ItemTypes.LowSlot;
                            break;
                        case 2:
                            item.ItemType = CompareItem.ItemTypes.MidSlot;
                            break;
                        case 3:
                            item.ItemType = CompareItem.ItemTypes.HighSlot;
                            break;
                        case 4:
                            item.ItemType = CompareItem.ItemTypes.Rigs;
                            break;
                        case 5:
                            item.ItemType = CompareItem.ItemTypes.Subsystems;
                            break;
                        case 6:
                            item.ItemType = CompareItem.ItemTypes.Drones;
                            break;
                        case 8:
                            item.ItemType = CompareItem.ItemTypes.Cargo;
                            break;
                    }
                    if (prevBlockNumber != blockNumber)
                    {
                        CompareItem separator = new CompareItem();
                        separator.ItemType = CompareItem.ItemTypes.Empty;
                        items.Add(separator);
                    }
                    items.Add(item);
                    prevBlockNumber = blockNumber;
                }
            }
        }

        private void FillListBox()
        {
            var bindingList = new BindingList<CompareItem>(items);
            var source = new BindingSource(bindingList, null);
            control.DataSource = source;
        }
    }
}
