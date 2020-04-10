/*
 * A library for anonymously monitoring clipboard entries.
 * https://github.com/Willy-Kimura/SharpClipboard
 */
using System;
using WK.Libraries.SharpClipboardNS;
using static WK.Libraries.SharpClipboardNS.SharpClipboard;

namespace FitCompare
{
    class ClipboardManager
    {
        private OneList list;
        private SharpClipboard clipboard;

        public ClipboardManager()
        {
            clipboard = new SharpClipboard();
            clipboard.ClipboardChanged += ClipboardChanged;
        }

        public void SetList(OneList list)
        {
            this.list = list;
        }

        private void ClipboardChanged(Object sender, ClipboardChangedEventArgs e)
        {
            if (e.ContentType == SharpClipboard.ContentTypes.Text && clipboard.ClipboardText[0] == '[')
            {
                list.SetText(clipboard.ClipboardText);
            }
        }

        public void SetText(string text)
        {
            list.SetText(text);
        }
    }
}
