using System;
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
            Compare();
        }

        private void Compare()
        {
            if (next == null)
                return;
            foreach (CompareItem item in items)
            {
                if (item.ItemType == CompareItem.ItemTypes.Empty)
                    continue;
                foreach (CompareItem itemNext in next.items)
                {
                    if (itemNext.ItemType == CompareItem.ItemTypes.Empty)
                        continue;
                    if (!itemNext.Matched && itemNext.CompareText == item.CompareText && itemNext.Qty == item.Qty)
                    {
                        item.SetMatched(true);
                        itemNext.SetMatched(true);
                        break;
                    }
                }

            }
        }

        private void Parse()
        {
            /*
             * Fit format
             * https://www.eveonline.com/ru/article/import-export-fittings
             */
            int blockNumber = 1;
            int prevBlockNumber = 1;
            bool CaptionExists = false;
            CompareItem.ItemTypes itemType = CompareItem.ItemTypes.Empty;
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
                    if (prevBlockNumber != blockNumber)
                    {
                        CompareItem emptyItem = new CompareItem();
                        emptyItem.ItemType = CompareItem.ItemTypes.Empty;
                        items.Add(emptyItem);
                    }
                    /* TODO: обычно все в фите делится по пробелам 
                     * low,med,high,rigs,subsystems через пробел
                     * затем два пробела и
                     * дроны с карго череез пробел
                     * если слот пустое пишется [Empty (grade) slot]
                     * но если нет подсистемы то там просто пусто.
                     * нужно это как то отработать
                     */
                    switch (blockNumber)
                    {
                        case 1:
                            if (line[0] == '[' && !CaptionExists) { 
                                itemType = CompareItem.ItemTypes.Caption;
                                CaptionExists = true;
                            }
                            else
                                itemType = CompareItem.ItemTypes.LowSlot;
                            break;
                        case 2:
                            itemType = CompareItem.ItemTypes.MidSlot;
                            break;
                        case 3:
                            itemType = CompareItem.ItemTypes.HighSlot;
                            break;
                        case 4:
                            itemType = CompareItem.ItemTypes.Rigs;
                            break;
                        case 5:
                            itemType = CompareItem.ItemTypes.Subsystems;
                            break;
                        case 7:
                            itemType = CompareItem.ItemTypes.Drones;
                            break;
                        case 8:
                            itemType = CompareItem.ItemTypes.Cargo;
                            break;
                    }
                    CompareItem item = new CompareItem(line, itemType);
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
