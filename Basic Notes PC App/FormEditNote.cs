using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basic_Notes_PC_App
{
    public partial class FormEditNote : Form
    {
        public enum mode 
        {
            Add,
            Edit
        }

        public static FormEditNote instance = new FormEditNote();
        public mode Mode;
        public string note;
        public FormEditNote()
        {
            InitializeComponent();
            instance = this;
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNotesScreen.instance.Show();
            this.Dispose();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case mode.Add:
                    note = richTextBox1.Text;
                    FormNotesScreen.instance.listBox1.Items.Add(note);
                    break;
                case mode.Edit: //not replacing original string in note listbox
                    note = richTextBox1.Text;
                    //FormNotesScreen.instance.itemSelected = note;
                    int i = FormNotesScreen.instance.listBox1.Items.IndexOf(FormNotesScreen.instance.listBox1.SelectedItem);
                    FormNotesScreen.instance.listBox1.Items.RemoveAt(i);
                    FormNotesScreen.instance.listBox1.Items.Insert(i, note);
                    //FormNotesScreen.instance.listBox1.SelectedItem = note;
                    break;
            }
            //FormNotesScreen.instance.Show();
            this.Dispose();
        }

        public void importNoteToEdit(string line)
        {
            if (Mode == mode.Edit)
            {
                richTextBox1.Text = line;
            }
            else
            {}
        }
    }
}
