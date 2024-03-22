using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Week10
{
    public partial class Form2 : Form
    {
        public InventoryItem newItem { get; set; }
        public Form2()
        {
            InitializeComponent();
            
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                int Item = int.Parse(txtItem.Text);
                if (!int.TryParse(txtItem.Text, out Item))
                {
                    MessageBox.Show("Please enter a valid item number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string Description = txtDesc.Text;
                if(string.IsNullOrEmpty(Description))
                {
                    MessageBox.Show("We need a description","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                decimal.TryParse(txtPrice.Text, out decimal Price);
                if (!decimal.TryParse(txtPrice.Text, out Price))
                {
                    MessageBox.Show("Please enter a valid item digit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    newItem = new InventoryItem(Item, Description, Price);
                    DialogResult = DialogResult.OK;
                    //additional
                    DialogResult d = MessageBox.Show("Item Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (d == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                



            }
            catch (Exception ex)
            {
                MessageBox.Show("C'mon,  Add an Item:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            this.Close();
            
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            
            DialogResult = DialogResult.Cancel;
            
        }
    }
}
