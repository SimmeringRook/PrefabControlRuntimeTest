 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrefabControlRuntimeTest
{
    public partial class Form1 : Form
    {
        private int NumberOfRows;
        private List<TextBox> IngredientNameTxtBoxes = new List<TextBox>();
        private List<TextBox> AmountTxtBoxes = new List<TextBox>();

        public Form1()
        {
            InitializeComponent();
            NumberOfRows = tableLayoutPanel1.RowCount; //Get the current number of rows in the table
            AddNewIngredientRow(); //Add the first row on initialization
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewIngredientRow();
        }

        private void AddNewIngredientRow()
        {
            //Increment the number of Rows
            NumberOfRows++;

            //Set the new row's style
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            //Grab a copy of the TextBox Template
            TextBox ingredientTemplate = GetTextboxTemplate();
            //Add it into a new row
            tableLayoutPanel1.Controls.Add(GetTextboxTemplate(), 0, NumberOfRows - 1); //control, column index, row index
            //Save a reference for when all input is complete
            IngredientNameTxtBoxes.Add(ingredientTemplate);

            TextBox amountTemplate = GetTextboxTemplate();
            tableLayoutPanel1.Controls.Add(GetTextboxTemplate(), 1, NumberOfRows - 1);
            AmountTxtBoxes.Add(amountTemplate);

            if (NumberOfRows > 2)
                button2.Enabled = true;
        }

        private TextBox GetTextboxTemplate()
        {
            //Any customization for the textbox would be done here
            //If Ingredient Textboxes have different customization/vaildation rules than the amount textbox,
            //we can split this into two functions, and assign them accordingly
            return new TextBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NumberOfRows--;

            //Remove the controls
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            {
                Control controlToRemove = tableLayoutPanel1.GetControlFromPosition(i, NumberOfRows);
                tableLayoutPanel1.Controls.Remove(controlToRemove);
            }

            //Remove the row from the table
            tableLayoutPanel1.RowStyles.RemoveAt(NumberOfRows - 1);
            tableLayoutPanel1.RowCount = NumberOfRows - 1;

            //Remove the saved references from the list
            IngredientNameTxtBoxes.RemoveAt(IngredientNameTxtBoxes.Count - 1);
            AmountTxtBoxes.RemoveAt(AmountTxtBoxes.Count - 1);

            if (NumberOfRows == 2)
                button2.Enabled = false;
        }
    }
}
