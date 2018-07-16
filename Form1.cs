using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CacheCleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            //clear cache
            try
            {
                //string dir1 = "c:\\fff";
                //listBox1.Items.Add("Deleting " + dir1);
                //Directory.Delete(dir1, true); //удаление папки, и всего, что внутри
                //listBox1.Items.Add("Deleted");
                //listBox1.Items.Add("Cache files have been successfully deleted");

                listBox2.Items.Clear();

                string folderpath = "\\\\" + textBox1.Text + "\\c$\\users";
                listBox1.Items.Add("Entering to: " + folderpath);

                label5.Enabled = true;
                listBox2.Enabled = true;
                

                DirectoryInfo dir = new DirectoryInfo(folderpath);
                foreach (DirectoryInfo folder in dir.GetDirectories())
                {
                    if (folder.Exists)
                    {
                        listBox2.Items.Add(folder.Name);
                    }
                }

                listBox1.Items.Add("Get profile list from: " + folderpath);
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("ERROR - " + ex);
                //MessageBox.Show("There is no folder to delete or no access", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand); 
            }
        }

        private void listBox2_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                string selectedItem = listBox2.SelectedItem.ToString();
                string cachepath = "\\\\" + textBox1.Text + "\\c$\\users\\" + selectedItem + "\\AppData\\Local\\1C\\1cv8\\";
                listBox1.Items.Add("Deleting cahe in directory: " + cachepath);
                DirectoryInfo dir = new DirectoryInfo(cachepath);
                listBox2.Items.Clear();
                foreach (DirectoryInfo folder in dir.GetDirectories())
                {
                    if (folder.Exists)
                    {

                        if (folder.Name.Length > 20)
                        {
                            listBox2.Items.Add("deleting " + folder.Name);
                            folder.Delete(true);
                        }

                    }
                }

                string cachepath2 = "\\\\" + textBox1.Text + "\\c$\\users\\" + selectedItem + "\\AppData\\Roaming\\1C\\1cv8\\";
                listBox1.Items.Add("Deleting cahe in directory: " + cachepath2);
                DirectoryInfo dir2 = new DirectoryInfo(cachepath2);
                listBox2.Items.Clear();
                foreach (DirectoryInfo folder in dir2.GetDirectories())
                {
                    if (folder.Exists)
                    {

                        if (folder.Name.Length > 20)
                        {
                            listBox2.Items.Add("deleting" + folder.Name);
                            folder.Delete(true);
                        }

                    }
                }
                listBox1.Items.Add("Cache successfully deleted");
            }
            catch(Exception ex)
            {
                listBox1.Items.Add("ERROR - " + ex);
                //MessageBox.Show("There is no folder to delete or no access", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand); 
            };

        }

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            string strTip = "";

            //Get the item
            int nIdx = listBox1.IndexFromPoint(e.Location);
            if ((nIdx >= 0) && (nIdx < listBox1.Items.Count))
                strTip = listBox1.Items[nIdx].ToString();

            toolTip1.SetToolTip(listBox1, strTip);

        }
    }
}
