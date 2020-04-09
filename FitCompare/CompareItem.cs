using System.Drawing;

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

        public Image ItemTypeIcon { get; set; }
        public Image MatchedIcon { get; set; }
        public string RawText { get; set; }
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
        public bool Matched;

        public CompareItem(string text = "")
        {
            RawText = text;
            CompareText = text;
            SetItemTypeIcon(ItemTypes.Empty);
            SetMatchedIcon(false);
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

        public void SetMatchedIcon(bool state)
        {
            if (state)
                MatchedIcon = Properties.Resources.matched_small;
            else
                MatchedIcon = Properties.Resources.transparent_small;
        }
    }
}