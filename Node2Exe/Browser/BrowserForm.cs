using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    public partial class BrowserForm : Form
    {
        String url = "";

        public BrowserForm(String urlToVisit)
        {
            InitializeComponent();
            url = urlToVisit;
        }

        private void BrowserForm_Load(object sender, EventArgs e)
        {
            webControl1.Source = new Uri(url);
        }
    }
}
