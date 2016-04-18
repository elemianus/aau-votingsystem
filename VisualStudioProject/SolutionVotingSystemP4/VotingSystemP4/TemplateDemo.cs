using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VotingSystemP4
{
    public partial class TemplateDemo : Form
    {
        
        public TemplateDemo()
        {
            InitializeComponent();

        }

        private void TemplateDemo_Load(object sender, EventArgs e)
        {
            //listView1.Columns.Add("First Column Title");
            // When the enclosing form loads, add three string items to the ListView.
            // ... Use an array of strings.
            /*string[] array = { "cat", "dog", "mouse" };
            var items = listView1.Items;
            foreach (var value in array)
            {
                items.Add(value);
            }*/

            ListViewItem[] rows = new ListViewItem[] {
                CreateListViewRow("Parlament election", "1337","13-37-90"),
                CreateListViewRow("EU election", "1337","13-37-90"),
                CreateListViewRow("Municipality election", "1337","13-37-90")
            };

            listView1.Items.AddRange(rows);
        }

        private ListViewItem CreateListViewRow(string electionType, string electionOpenDate, string electionDeadline) {
            var row = new ListViewItem(electionType);
            row.SubItems.Add(electionOpenDate);
            row.SubItems.Add(electionDeadline);
            return row;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                MessageBox.Show(item.SubItems[0].ToString());
            }
            
            chooseElectionPanel.Visible = false;
            //chooseElectionPanel = castVotePanel;

            castVotePanel.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
