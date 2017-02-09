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
        private List<TextBox> IngredientNames = new List<TextBox>();
        private List<TextBox> Amount = new List<TextBox>();

        public Form1()
        {
            InitializeComponent();
            NumberOfRows = tableLayoutPanel1.RowCount; //Get the current number of rows in the table
            AddNewIngredientRow(); //Add the first row on initialization
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
            IngredientNames.Add(ingredientTemplate);

            TextBox amountTemplate = GetTextboxTemplate();
            tableLayoutPanel1.Controls.Add(GetTextboxTemplate(), 1, NumberOfRows - 1);
            Amount.Add(amountTemplate);
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
            //TODO: remove row code
        }
    }
}
