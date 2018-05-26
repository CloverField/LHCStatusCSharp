using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LHCStatusOptions;
using LHCStatusFunctions;

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

            var LHCStatusOptions = typeof(StatusOptions)
                .GetFields()
                .Select(f => f.GetValue(null))
                .ToList();

            for (int i = 0; i < LHCStatusOptions.Count; i++)
            {
                var b = new Button()
                {
                    Name = LHCStatusOptions[i].ToString(),
                    Text = LHCStatusOptions[i].ToString(),
                    AutoSize = true
                };
                b.Click += Button_Click;
                LHCButtonTableLayoutPanel.Controls.Add(b);
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            var LHCStatusOptions = typeof(StatusOptions)
                .GetFields()
                .Select(f => f.GetValue(null))
                .ToList();
            Button button = sender as Button;
            var input = (LHCStatusOptions.FindIndex(f => f.ToString() == button.Name) + 1).ToString();

            switch (input)
            {
                case "1":
                    Functions.CheckCryo(input);
                    break;
                case "2":
                    Functions.CheckCryoStatusForIndividualMagnet(input);
                    break;
                case "3":
                    Functions.CheckIndividualPCPermit(input);
                    break;
                case "4":
                    Functions.CheckIndividualPCPermits(input);
                    break;
                case "5":
                    Functions.CheckRFCryo(input);
                    break;
                case "6":
                    Functions.CheckIndividualRFStatus(input);
                    break;
                case "7":
                    Functions.CheckBeamDump(input);
                    break;
                case "8":
                    Functions.CheckIndividualBeamDumpComponent(input);
                    break;
                case "9":
                    Functions.CheckEXPMagnets();
                    break;
                case "10":
                    Functions.CheckIndividualEXPMagnet(input);
                    break;
                case "11":
                    Functions.CheckBeamSMPFlags(input);
                    break;
                case "12":
                    Functions.CheckIndiviualBeamSMPFlag(input);
                    break;
                case "13":
                    Functions.PerformOCROnVistarPage(input);
                    break;
                default:
                    break;
            }
        }
    }
}
