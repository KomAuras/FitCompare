using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FitCompare
{
    public class CompareItem
    {
        public enum ItemTypes
        {
            Empty,
            Caption,
            LowSlot,
            MidSlot,
            HighSlot,
            Rigs,
            Subsystems,
            Drones,
            Cargo
        }

        public enum MatchTypes
        {
            Empty,
            Matched,
            MatchedWithoutQty,
            NotMatched
        }

        public Image ItemTypeIcon { get; set; }
        public Image MatchedIcon { get; set; }
        public string RawText { get; set; }
        public int Qty { get; set; }
        private ItemTypes _ItemType;
        public ItemTypes ItemType
        {
            get { return _ItemType; }
            set
            {
                _ItemType = value;
                SetItemTypeIcon(value);
            }
        }
        public string CompareText;
        public MatchTypes Matched;

        public CompareItem(string text = "", ItemTypes it = CompareItem.ItemTypes.Empty)
        {
            RawText = text;
            CompareText = text;
            Qty = 0;
            switch (it)
            {
                case ItemTypes.Caption:
                    // TODO: тут проблемы если закачивается не фит!
                    if (text.Length > 0)
                        SetCompareText(text.Substring(1, text.IndexOf(',') - 1));
                    break;
                case ItemTypes.LowSlot:
                case ItemTypes.MidSlot:
                case ItemTypes.HighSlot:
                case ItemTypes.Subsystems:
                case ItemTypes.Rigs:
                    if (text[0] == '[')
                    {
                        RawText = "";
                        SetCompareText("");
                    }
                    break;
                case ItemTypes.Drones:
                case ItemTypes.Cargo:
                    string lastWord = text.Split(' ').Last();
                    if (Regex.IsMatch(lastWord, "^x(\\d*)$", RegexOptions.IgnoreCase))
                    {
                        Match match = Regex.Match(lastWord, "(\\d*)$", RegexOptions.IgnoreCase);
                        Qty = Int32.Parse(match.Value);
                        string onlyName = text.Substring(0, text.LastIndexOf(" ") < 0 ? 0 : text.LastIndexOf(" "));
                        RawText = "x" + match.Value + " " + onlyName;
                        CompareText = onlyName;
                    }
                    break;
            }
            ItemType = it;
            SetMatched();
        }

        public void SetCompareText(string text)
        {
            CompareText = text;
        }

        public void SetItemTypeIcon(ItemTypes it)
        {
            switch (it)
            {
                case ItemTypes.LowSlot:
                    ItemTypeIcon = Properties.Resources.slot_low_small;
                    break;
                case ItemTypes.MidSlot:
                    ItemTypeIcon = Properties.Resources.slot_med_small;
                    break;
                case ItemTypes.HighSlot:
                    ItemTypeIcon = Properties.Resources.slot_high_small;
                    break;
                case ItemTypes.Subsystems:
                    ItemTypeIcon = Properties.Resources.slot_subsystem_small;
                    break;
                case ItemTypes.Rigs:
                    ItemTypeIcon = Properties.Resources.slot_rig_small;
                    break;
                default:
                    ItemTypeIcon = Properties.Resources.transparent_small;
                    break;
            }
        }

        public void SetMatched(MatchTypes mt = MatchTypes.Empty)
        {
            Matched = mt;
            switch (mt)
            {
                case MatchTypes.NotMatched:
                    MatchedIcon = Properties.Resources.bullet_red;
                    break;
                case MatchTypes.MatchedWithoutQty:
                    MatchedIcon = Properties.Resources.bullet_yellow;
                    break;
                case MatchTypes.Matched:
                    MatchedIcon = Properties.Resources.bullet_green;
                    break;
                default:
                    MatchedIcon = Properties.Resources.transparent_small;
                    break;
            }
        }
    }
}