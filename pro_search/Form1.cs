using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro_search
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.phone_book_table' table. You can move, or remove it, as needed.
            
            this.search_item_box.SelectedIndex = 0;
            this.panel1.Visible = true;
            this.panel2_date.Visible = false;
        }
        private void search_item_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(search_item_box.SelectedIndex == 1)
            {
                this.panel2_date.Visible=true;
                this.panel1.Visible = false;
            }
            else
            {
                this.panel2_date.Visible = false;
                this.panel1.Visible = true;
            }
        }

        private void search_type_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.search_type_box.SelectedIndex == 4)
            {
                this.and_label.Visible = true;
                this.textBox2.Visible = true;

            }
            else
            {
                this.and_label.Visible = false;
                this.textBox2.Visible = false;

            }
        }

        private void phone_book_tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.phone_book_tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            //----------- NOT SELECTED INDEX CODE---------------------
            if(this.search_type_box.SelectedIndex ==-1)
            {
                MessageBox.Show("Please select type search!");
            }
            //---------------------------------------------------------
            if(this.search_item_box.SelectedIndex == 1) // birth date
            {
                this.phone_book_tableTableAdapter.FillBy_Date(dataSet1.phone_book_table,
                                this.dateTimePicker1.Value.ToString(),
                                this.dateTimePicker2.Value.ToString());
            }
            if (this.search_item_box.SelectedIndex == 0)    // last name
            {
                if(this.search_type_box.SelectedIndex ==0) // Equal
                {
                    this.phone_book_tableTableAdapter.FillBy(this.dataSet1.phone_book_table, textBox1.Text );
                }
                if (this.search_type_box.SelectedIndex == 1) //End With
                {
                    this.phone_book_tableTableAdapter.FillBy(this.dataSet1.phone_book_table, textBox1.Text + "%");
                }
                if (this.search_type_box.SelectedIndex == 2) // Start With
                {
                    this.phone_book_tableTableAdapter.FillBy(this.dataSet1.phone_book_table,"%" + textBox1.Text);
                }
                if (this.search_type_box.SelectedIndex == 3) // EveryWhere
                {
                    this.phone_book_tableTableAdapter.FillBy(this.dataSet1.phone_book_table,"%" + textBox1.Text + "%");
                }
                if (this.search_type_box.SelectedIndex == 4) // Between
                {
                    this.phone_book_tableTableAdapter.FillBy1(this.dataSet1.phone_book_table, this.textBox1.Text,this.textBox2.Text);
                }
                if (this.search_type_box.SelectedIndex == 5) // Not equal
                {
                    this.phone_book_tableTableAdapter.FillBy_last_name_not_equal(this.dataSet1.phone_book_table, this.textBox1.Text);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.phone_book_tableTableAdapter.Fill(this.dataSet1.phone_book_table);
        }
    }
}
