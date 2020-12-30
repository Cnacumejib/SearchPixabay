using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Forms;
using SearchPixabay.Entities;
using SearchPixabay.IWAContracts;
using SearchPixabay.WebAccessor;

namespace SearchPixabay
{
    public partial class Form1 : Form
    {
        private IWebAccessorContracts pixabayAccessor;
        public Form1()
        {
            InitializeComponent();
        }

        private void SetAccessorKey(string key = "")
        {
            if (string.IsNullOrEmpty(key))
            {
                pixabayAccessor = new PixabayAccessor();
                key = "default";
            }
            else
            {
                pixabayAccessor = new PixabayAccessor(key);
            }

            if (pixabayAccessor.GetImagePages(new List<string> { "sea" }).Any())
            {
                labelKey.Text = $"connected - {key}";
            }
            else
            {
                labelKey.Text = $"key failure - {key}";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetAccessorKey();
        }

        private void BtnSetKey_Click(object sender, EventArgs e)
        {
            SetAccessorKey(textBox3.Text);
        }

        private void btnSearchImages_Click(object sender, EventArgs e)
        {

            IEnumerable<WebImage> images = pixabayAccessor.GetImagePages(txtTags.Lines);

            listBoxUrls.Items.Clear();
            foreach (WebImage image in images)
            {
                listBoxUrls.Items.Add(image);
            }
        }

        private void listBoxUrls_Click(object sender, EventArgs e)
        {
            if (listBoxUrls.SelectedIndex > -1)
            {
                try
                {
                    string url = listBoxUrls.SelectedItem.ToString().Split(new char[] { '\t' })[1];
                    pictureBox1.Load(url);
                    pictureBox1.Refresh();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
