using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // helo ban nho
            InitializeComponent();
            // Thêm tất cả các font đã được khởi tạo
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            // Thêm kiểu chữ 
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int size in sizes)
            {
                toolStripComboBox2.Items.Add(size.ToString());
            }
            toolStripComboBox1.SelectedItem = "Tahoma";
            toolStripComboBox2.SelectedItem = "14";
        }
        // Khởi tạo font chữ có sẵn của Windowns
        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richText.ForeColor = fontDlg.Color;
                richText.Font = fontDlg.Font;
            }
        }
        //Thoát
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Hàm tạo mới văn bản
        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.Clear();
            richText.Font = new Font("Tahoma", 14, FontStyle.Regular);
            toolStripComboBox1.SelectedItem = "Tahoma";
            toolStripComboBox2.SelectedItem = "14";

        }
        // Hàm tạo mới văn bản
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richText.Clear();
            richText.Font = new Font("Tahoma", 14, FontStyle.Regular);
            toolStripComboBox1.SelectedItem = "Tahoma";
            toolStripComboBox2.SelectedItem = "14";

        }
        // Hàm mở tập tin
        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tệp văn bản (*.txt;*.rtf)|*.txt;*.rtf|Tất cả các tệp (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                // Kiểm tra định dạng của tập tin và thực hiện xử lý tương ứng
                if (fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    // Xử lý tập tin *.txt
                    try
                    {
                        richText.LoadFile(fileName, RichTextBoxStreamType.PlainText);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể mở tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (fileName.EndsWith(".rtf", StringComparison.OrdinalIgnoreCase))
                {
                    // Xử lý tập tin *.rtf
                    try
                    {
                        richText.LoadFile(fileName, RichTextBoxStreamType.RichText);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể mở tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Định dạng tập tin không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Hàm lưu Văn bản
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Title = "Lưu tập tin văn bản ";
            saveFileDialog.DefaultExt = "rft";
            saveFileDialog.Filter = " RichText files| *.rft & ";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = saveFileDialog.FileName;
                try
                {
                    richText.SaveFile(selectedFileName, RichTextBoxStreamType.UnicodePlainText);
                    MessageBox.Show("Tập tin đã được lưu thành công!", " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Đã xảy ra lỗi trong quá trình lưu tập tin: " + ex.Message, " Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Lưu văn bản
        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Title = "Lưu tập tin văn bản ";
            saveFileDialog.DefaultExt = "rft";
            saveFileDialog.Filter = " RichText files| *.rft & ";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = saveFileDialog.FileName;
                try
                {
                    richText.SaveFile(selectedFileName, RichTextBoxStreamType.UnicodePlainText);
                    MessageBox.Show("Tập tin đã được lưu thành công!", " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Đã xảy ra lỗi trong quá trình lưu tập tin: " + ex.Message, " Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Khởi tạo update font style
        private void UpdateTextFontStyle(FontStyle style)
        {
            Font currentFont = richText.Font;
            if (currentFont.Style.HasFlag(style))
            {
                Font newFont = new Font(currentFont, currentFont.Style & ~style);
                richText.Font = newFont;
            }
            else
            {
                Font newFont = new Font(currentFont, currentFont.Style | style);
                richText.Font = newFont;
            }
        }
        // In đâm
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            UpdateTextFontStyle(FontStyle.Bold);
        }
        // In nghiêng
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            UpdateTextFontStyle(FontStyle.Italic);
        }
        // Gạch chân
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            UpdateTextFontStyle(FontStyle.Underline);
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox2.Text != "")
            {
                richText.Font = new Font(toolStripComboBox1.Text, float.Parse(toolStripComboBox2.Text));
            }
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(toolStripComboBox1.Text) && !string.IsNullOrEmpty(toolStripComboBox2.Text))
            {
                string selectedFontName = toolStripComboBox1.Text;
                float selectedFontSize;

                if (float.TryParse(toolStripComboBox2.Text, out selectedFontSize))
                {
                    Font newFont = new Font(selectedFontName, selectedFontSize);
                    richText.Font = newFont;
                }
            }
        }
    }
}
