using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flex_Trainer
{
    public partial class card_deit : UserControl
    {
        public card_deit()
        {
            InitializeComponent();
        }

        internal void setValues(string name, string Quantity, string Calories, string Fats, string Carbs, string Protein)
        {
            this.dietname.Text = name;
            this.details.Text = "Fats: " + Fats + "g " + "Carbs: " + Carbs + "g \n" + "Protein: " + Protein + "g " + "Calories: " + Calories + "kcal";
             this.diet_quantity.Text = Quantity;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
