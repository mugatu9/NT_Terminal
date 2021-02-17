using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT_Terminal
{
    public static class Notification
    {
        public static void ShowDialog(string text, string caption)
        {
            Form notification = new Form()
            {
                Width = 350,
                Height = 300,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 0, Top = 10, Width = 325, Height = 300, Text = text };
            textLabel.AutoSize = false;
            textLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
           
            Button confirmation = new Button() { Text = "Ok", Left = 400, Width = 75, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { notification.Close(); };
            notification.Controls.Add(confirmation);
            notification.Controls.Add(textLabel);
            notification.AcceptButton = confirmation;
            notification.ShowDialog();


        }
    }
}
