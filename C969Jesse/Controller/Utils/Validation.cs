using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969Jesse.Utils
{
    public static class Validation
    {
        // Requirement F: Validates for empty text, type of each textbox, and whether to enable Save Button
        public static bool ValidateTextBox(TextBox textBox, string type, ErrorProvider errorProvider)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider.SetError(textBox, "This field cannot be empty");
                isValid = false;
            }
            else if (!ValidateType(textBox, type, errorProvider))
            {
                isValid = false;
            }
            else
            {
                errorProvider.SetError(textBox, "");
            }

            textBox.BackColor = isValid ? Color.White : Color.Salmon;
            return isValid;
        }

        private static bool ValidateType(TextBox textBox, string type, ErrorProvider errorProvider)
        {
            bool isValid = true;

            switch (type)
            {
                case "int":
                    if (!int.TryParse(textBox.Text, out int intNumber))
                    {
                        errorProvider.SetError(textBox, "Invalid integer format");
                        isValid = false;
                    }
                    else
                    {
                        errorProvider.SetError(textBox, "");
                    }
                    break;

                case "decimal":
                    if (!decimal.TryParse(textBox.Text, out decimal decimalNumber))
                    {
                        errorProvider.SetError(textBox, "Invalid decimal format");
                        isValid = false;
                    }
                    else
                    {
                        errorProvider.SetError(textBox, "");
                    }
                    break;

                case "string":
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        errorProvider.SetError(textBox, "This field cannot be empty");
                        isValid = false;
                    }
                    else
                    {
                        errorProvider.SetError(textBox, "");
                    }
                    break;
                case "phone":
                    Regex phoneRegex = new Regex(@"^(\+?\d{1,2}\s?)?((\(\d{1,3}\))|\d{1,3})[-.\s]?\d{1,4}[-.\s]?\d{1,4}([-.\s]?\d{1,9})?$");
                    if (phoneRegex.IsMatch(textBox.Text))
                    {
                        errorProvider.SetError(textBox, "");
                    }
                    else
                    {
                        errorProvider.SetError(textBox, "Invalid phone number format");
                        isValid = false;
                    }
                    break;
                default:
                    errorProvider.SetError(textBox, "Unknown type");
                    isValid = false;
                    break;
            }
            textBox.BackColor = isValid ? Color.White : Color.Salmon;
            return isValid;
        }


    }
}
