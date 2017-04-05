using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFolderBrowserDialog
{
    public partial class Form1 : Form
    {
        Readdata readdate;

        public Form1()
        {
            InitializeComponent();
            //Form1.MaximizeBox = false;
            
        }

        #region 字段
        string _file;
        int frame = 1;

        #endregion

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                textBox1.Text = file;
                //MessageBox.Show("已选择文件:" + file, "选择文件提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _file = file;       
            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                MessageBox.Show("已选择文件夹:" + foldPath, "选择文件夹提示", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer.exe", "c:\\windows");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dodata_Click(object sender, EventArgs e)
        {
            readdate = new Readdata(_file);
            textBoxSum.Text = readdate.Framesum.ToString();
            textBoxNow.Text = "1";
            textBoxResult.Text = "";
            textBoxFinalResult.Text = readdate.ReturnResult();
            

            int i = 1;
            label1a.Text = readdate.Delta[0,i++].ToString();            label2a.Text = readdate.Delta[0,i++].ToString();
            label3a.Text = readdate.Delta[0,i++].ToString();            label4a.Text = readdate.Delta[0,i++].ToString();
            label5a.Text = readdate.Delta[0,i++].ToString();            label6a.Text = readdate.Delta[0,i++].ToString();
            label7a.Text = readdate.Delta[0,i++].ToString();            label8a.Text = readdate.Delta[0,i++].ToString();
            label9a.Text = readdate.Delta[0,i++].ToString();            label10a.Text = readdate.Delta[0,i++].ToString();
            label11a.Text = readdate.Delta[0,i++].ToString();            label12a.Text = readdate.Delta[0,i++].ToString();
            label13a.Text = readdate.Delta[0,i++].ToString();            label14a.Text = readdate.Delta[0,i++].ToString();
            label15a.Text = readdate.Delta[0,i++].ToString();            label16a.Text = readdate.Delta[0,i++].ToString();
            label17a.Text = readdate.Delta[0,i++].ToString();            label18a.Text = readdate.Delta[0,i++].ToString();
            label19a.Text = readdate.Delta[0,i++].ToString();            label20a.Text = readdate.Delta[0,i++].ToString();
            label21a.Text = readdate.Delta[0,i++].ToString();            label22a.Text = readdate.Delta[0,i++].ToString();
            label23a.Text = readdate.Delta[0,i++].ToString();            label24a.Text = readdate.Delta[0,i++].ToString();
            label25a.Text = readdate.Delta[0,i++].ToString();

            i = 1;
            label1d.Text = readdate.Delta[3, i++].ToString(); label2d.Text = readdate.Delta[3, i++].ToString();
            label3d.Text = readdate.Delta[3, i++].ToString(); label4d.Text = readdate.Delta[3, i++].ToString();
            label5d.Text = readdate.Delta[3, i++].ToString(); label6d.Text = readdate.Delta[3, i++].ToString();
            label7d.Text = readdate.Delta[3, i++].ToString(); label8d.Text = readdate.Delta[3, i++].ToString();
            label9d.Text = readdate.Delta[3, i++].ToString(); label10d.Text = readdate.Delta[3, i++].ToString();
            label11d.Text = readdate.Delta[3, i++].ToString(); label12d.Text = readdate.Delta[3, i++].ToString();
            label13d.Text = readdate.Delta[3, i++].ToString(); label14d.Text = readdate.Delta[3, i++].ToString();
            label15d.Text = readdate.Delta[3, i++].ToString(); label16d.Text = readdate.Delta[3, i++].ToString();
            label17d.Text = readdate.Delta[3, i++].ToString(); label18d.Text = readdate.Delta[3, i++].ToString();
            label19d.Text = readdate.Delta[3, i++].ToString(); label20d.Text = readdate.Delta[3, i++].ToString();
            label21d.Text = readdate.Delta[3, i++].ToString(); label22d.Text = readdate.Delta[3, i++].ToString();
            label23d.Text = readdate.Delta[3, i++].ToString(); label24d.Text = readdate.Delta[3, i++].ToString();
            label25d.Text = readdate.Delta[3, i++].ToString();

            frame = 1;

        }

        private void buttonNextFrame_Click(object sender, EventArgs e)
        {
            //显示过度表情特征
            
            //Readdata readdate = new Readdata(_file);
            if (frame - 1 >= readdate.Framesum)
                return;

            readdate.Framenow = frame;
            readdate.ReaddataByFrame(_file,frame);
            textBoxNow.Text = (frame).ToString();

            textBoxResult.Text = readdate.ReturnResult();
            

            int i = 1;
            label1b.Text = readdate.Delta[1, i++].ToString(); label2b.Text = readdate.Delta[1, i++].ToString();
            label3b.Text = readdate.Delta[1, i++].ToString(); label4b.Text = readdate.Delta[1, i++].ToString();
            label5b.Text = readdate.Delta[1, i++].ToString(); label6b.Text = readdate.Delta[1, i++].ToString();
            label7b.Text = readdate.Delta[1, i++].ToString(); label8b.Text = readdate.Delta[1, i++].ToString();
            label9b.Text = readdate.Delta[1, i++].ToString(); label10b.Text = readdate.Delta[1, i++].ToString();
            label11b.Text = readdate.Delta[1, i++].ToString(); label12b.Text = readdate.Delta[1, i++].ToString();
            label13b.Text = readdate.Delta[1, i++].ToString(); label14b.Text = readdate.Delta[1, i++].ToString();
            label15b.Text = readdate.Delta[1, i++].ToString(); label16b.Text = readdate.Delta[1, i++].ToString();
            label17b.Text = readdate.Delta[1, i++].ToString(); label18b.Text = readdate.Delta[1, i++].ToString();
            label19b.Text = readdate.Delta[1, i++].ToString(); label20b.Text = readdate.Delta[1, i++].ToString();
            label21b.Text = readdate.Delta[1, i++].ToString(); label22b.Text = readdate.Delta[1, i++].ToString();
            label23b.Text = readdate.Delta[1, i++].ToString(); label24b.Text = readdate.Delta[1, i++].ToString();
            label25b.Text = readdate.Delta[1, i++].ToString();



            //显示表情特征变化量
            i = 1;
            label1c.Text = readdate.Delta[2, i++].ToString(); label2c.Text = readdate.Delta[2, i++].ToString();
            label3c.Text = readdate.Delta[2, i++].ToString(); label4c.Text = readdate.Delta[2, i++].ToString();
            label5c.Text = readdate.Delta[2, i++].ToString(); label6c.Text = readdate.Delta[2, i++].ToString();
            label7c.Text = readdate.Delta[2, i++].ToString(); label8c.Text = readdate.Delta[2, i++].ToString();
            label9c.Text = readdate.Delta[2, i++].ToString(); label10c.Text = readdate.Delta[2, i++].ToString();
            label11c.Text = readdate.Delta[2, i++].ToString(); label12c.Text = readdate.Delta[2, i++].ToString();
            label13c.Text = readdate.Delta[2, i++].ToString(); label14c.Text = readdate.Delta[2, i++].ToString();
            label15c.Text = readdate.Delta[2, i++].ToString(); label16c.Text = readdate.Delta[2, i++].ToString();
            label17c.Text = readdate.Delta[2, i++].ToString(); label18c.Text = readdate.Delta[2, i++].ToString();
            label19c.Text = readdate.Delta[2, i++].ToString(); label20c.Text = readdate.Delta[2, i++].ToString();
            label21c.Text = readdate.Delta[2, i++].ToString(); label22c.Text = readdate.Delta[2, i++].ToString();
            label23c.Text = readdate.Delta[2, i++].ToString(); label24c.Text = readdate.Delta[2, i++].ToString();
            label25c.Text = readdate.Delta[2, i++].ToString();





            frame++;
        }
        
    }




}
