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
            NumberOfRows = tableLayoutPanel1.RowCount;
            AddNewIngredientRow();
        }


        private string TranslatePhraseIntoAbreviationByNumberOfCharactersBetweenFirstAndLast(string phrase)
        {
            string[] wordsInPhrase = phrase.Split(' ');
            string answerPhrase = "";

            foreach (string word in wordsInPhrase)
            {
                if (word.Length > 3)
                    answerPhrase += word.First() + (word.Length - 2).ToString() + word.Last() + " ";
                else
                    answerPhrase += word + " ";
            }

            answerPhrase.TrimEnd(' ');
            return answerPhrase;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewIngredientRow();
        }

        private void AddNewIngredientRow()
        {
            NumberOfRows++;
            //Set the new row's style
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            //                             control, column index, row index
            TextBox recipeTemplate = GetTextboxTemplate();
            tableLayoutPanel1.Controls.Add(GetTextboxTemplate(), 0, NumberOfRows - 1);
            IngredientNames.Add(recipeTemplate);

            TextBox servingsTemplate = GetTextboxTemplate();
            tableLayoutPanel1.Controls.Add(GetTextboxTemplate(), 1, NumberOfRows - 1);
            Amount.Add(servingsTemplate);
        }

        private TextBox GetTextboxTemplate()
        {
            return new TextBox();
        }

    }
}
