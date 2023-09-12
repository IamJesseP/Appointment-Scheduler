using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969Jesse.Utils
{
    public static class Validation
    {
        // Validates for empty text, type of each textbox, and whether to enable Save Button
        public static bool ValidateTextBox(TextBox textBox, string type)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.BackColor = Color.Salmon;
            }
            else
            {
                textBox.BackColor = Color.White;
            }
            return ValidateSave(textBox, type);
        }
        private static bool ValidateSave(TextBox textBox, string type)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                return false;
            }
            else if (!ValidateType(textBox, type))
            {
                return false;
            }
            else { return true; }
        }
        private static bool ValidateType(TextBox textBox, string type)
        {
            switch (type)
            {
                case "int":
                    if (int.TryParse(textBox.Text, out int intNumber))
                    {
                        textBox.BackColor = Color.White;
                        return true;
                    }
                    else
                    {
                        textBox.BackColor = Color.Salmon;
                        return false;
                    }
                case "decimal":
                    if (decimal.TryParse(textBox.Text, out decimal decimalNumber))
                    {
                        textBox.BackColor = Color.White;
                        return true;
                    }
                    else
                    {
                        textBox.BackColor = Color.Salmon;
                        return false;
                    }
                case "string":
                    textBox.BackColor = Color.White;
                    return true;
                default:
                    return false;
            }
        }

    }
}
