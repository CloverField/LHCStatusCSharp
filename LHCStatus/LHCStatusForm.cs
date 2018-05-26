using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LHCStatus
{
    public partial class LHCStatusForm : Form
    {
        public LHCStatusForm()
        {
            InitializeComponent();
        }

        private void LHCStatusForm_Load(object sender, EventArgs e)
        {
            var systemTime = DateTime.Now;
            var cernTime = TimeZoneInfo.ConvertTime(DateTime.Now,
                TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time"));

            SystemCERNTimeLabel.Text = String.Format("Current System Time: {0}\nCurrent CERN Time: {1}\n",
                systemTime.ToLongTimeString(), cernTime.ToLongTimeString());

            SystemCERNDateLabel.Text = String.Format("Current System Date: {0}\nCurrent CERN Date: {1}\n",
                systemTime.ToLongDateString(), cernTime.ToLongDateString());
        }
    }
}
