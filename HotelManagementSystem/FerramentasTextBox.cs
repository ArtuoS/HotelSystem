using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    class FerramentasTextBox
    {
        public static void LimpaTextBoxes(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var TextBox = c as TextBox;
                var MaskedTextBox = c as MaskedTextBox;
                if (TextBox != null)
                    (TextBox).Clear();
                if (MaskedTextBox != null)
                    (MaskedTextBox).Clear();
                if(c.HasChildren)
                    LimpaTextBoxes(c);
            }
        }

        /*
        public static void VerificaTextBoxVazia(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if(c is TextBox)
                {
                    if(string.IsNullOrEmpty(c.Text.Trim()))
                    {
                        MessageBox.Show("Preencha todos os campos!");
                        return;
                    }
                }
            }
        }
        */

    }

    
}
