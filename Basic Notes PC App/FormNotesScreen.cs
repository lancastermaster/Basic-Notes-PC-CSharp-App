using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Basic_Notes_PC_App
{
    public partial class FormNotesScreen : Form
    {
        public static FormNotesScreen instance = new FormNotesScreen();
        public string line;
        public string itemSelected;
        public FormNotesScreen()
        {
            InitializeComponent();
            instance = this;
            //File.Open(noteslist, FileMode.Open, FileAccess.ReadWrite);
            /*foreach (string s in Data.notes)
            {
                listBox1.Items.Add(s);
            }*/
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditNote editNote = new FormEditNote();
            editNote.Mode = FormEditNote.mode.Add;
            editNote.Show();

            //this.Hide();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            line = listBox1.SelectedItem.ToString();
            itemSelected = listBox1.SelectedItem.ToString();
            FormEditNote editNote = new FormEditNote();
            editNote.Mode = FormEditNote.mode.Edit;
            //editNote.richTextBox1.Text = line;
            editNote.importNoteToEdit(line);
            editNote.Show();
            //this.Hide();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.notes.Clear();
            /*foreach (Object item in listBox1.Items)
            {
                Data.notes.Add(item.ToString());
            }*/

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string noteFileName = saveFileDialog1.FileName;
                foreach (Object item in listBox1.Items)
                {
                    Data.notes.Add(item.ToString());
                }
                Data.writeFile(noteFileName);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string notefile = openFileDialog1.FileName;
                Data.readFile(notefile);
                foreach (string s in Data.notes)
                {
                    listBox1.Items.Add(s);
                }
                //Data.notesFile = openFileDialog1.FileName;

            }
        }
    }
}
