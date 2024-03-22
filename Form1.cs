using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week10
{
    public partial class Form1 : Form
    {
        List<InventoryItem> items = new List<InventoryItem>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadListBox();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            if ( form.DialogResult == DialogResult.OK)
            {
                InventoryItem newitem = form.newItem;
                if (newitem != null)
                {
                    items.Add(newitem);
                    InventoryDB.SaveItems(items); //saving the item added to the database
                    LoadListBox();
                }
            }  
        }

        public void LoadListBox()
        {
            try
            {
                listBox1.Items.Clear();
                items = InventoryDB.GetItems(); //Getting the item from the database
                foreach (var item in items)
                {
                    listBox1.Items.Add(item.ToString()); // Modify as per your item representation
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                DialogResult res = MessageBox.Show("Do you want to do this?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        items.RemoveAt(listBox1.SelectedIndex);
                        InventoryDB.SaveItems(items);
                        LoadListBox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else this.Close();
            }
            else MessageBox.Show("Select an Item to delete", "Alert", MessageBoxButtons.OK);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
