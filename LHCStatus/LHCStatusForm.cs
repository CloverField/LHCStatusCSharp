using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LHCStatusOptions;
using LHCStatusFunctions;
using LHCEnums;
using Cryogenics;
using System.Threading.Tasks;

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

            Reset();
        }

        private void Reset()
        {
            LHCButtonTableLayoutPanel.Controls.Clear();
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

        private void CheckCryoSelected(string input)
        {
            LHCButtonTableLayoutPanel.Controls.Clear();
            var cryoValues = Enum.GetValues(typeof(Machine.Cryo.Sectors)).Cast<Machine.Cryo.Sectors>();
            foreach (var value in cryoValues)
            {
                var b = new Button()
                {
                    Name = value.ToString(),
                    Text = value.ToString()
                };
                b.Click += CryoButtonClick;
                LHCButtonTableLayoutPanel.Controls.Add(b);
            }
        }

        private void CryoButtonClick(object sender, EventArgs e)
        {
            var cryoValues = Enum.GetValues(typeof(Machine.Cryo.Sectors)).Cast<Machine.Cryo.Sectors>().ToList();
            Button button = sender as Button;
            var input = (cryoValues.FindIndex(f => f.ToString() == button.Name) + 1).ToString();
            var task = Task<bool>.Factory.StartNew(() => {
                return Functions.CheckCryo(input);
                });

            if (!task.Wait(10000))
                throw new Exception("Timed out waiting for task to complete.");

            if (task.IsFaulted)
                throw new Exception("Task failed.");

            if (task.Exception != null)
                throw task.Exception;

            if (task.Result)
                MessageBox.Show(String.Format("Cryo Status is good for {0}.", cryoValues[int.Parse(input) - 1]));
            else
                MessageBox.Show(String.Format("Cryo is down for {0}.", cryoValues[int.Parse(input) - 1]));

            Reset();
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
                    CheckCryoSelected(input);
                    break;
                case "2":
                    Functions.CheckCryoStatusForIndividualMagnet(input);
                    break;
                case "3":
                    CheckSectorPCPermitSelected(input);
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

        private void CheckSectorPCPermitSelected(string input)
        {
            LHCButtonTableLayoutPanel.Controls.Clear();
            var sectorValues = Enum.GetValues(typeof(Machine.Cryo.PCPermit)).Cast<Machine.Cryo.PCPermit>();
            foreach (var value in sectorValues)
            {
                var b = new Button()
                {
                    Name = value.ToString(),
                    Text = value.ToString()
                };
                b.Click += SectorButtonClick;
                LHCButtonTableLayoutPanel.Controls.Add(b);
            }
        }

        private void SectorButtonClick(object sender, EventArgs e)
        {
            var sectorValues = Enum.GetValues(typeof(Machine.Cryo.PCPermit)).Cast<Machine.Cryo.PCPermit>().ToList();
            Button button = sender as Button;
            var input = (sectorValues.FindIndex(f => f.ToString() == button.Name) + 1).ToString();
            var task = Task<bool>.Factory.StartNew(() => {
                return Functions.CheckSectorPCPermit(input);
            });

            if (!task.Wait(10000))
                throw new Exception("Timed out waiting for task to complete.");

            if (task.IsFaulted)
                throw new Exception("Task failed.");

            if (task.Exception != null)
                throw task.Exception;

            if (task.Result)
                MessageBox.Show(String.Format("PC Permits are good for Sector {0}.", sectorValues[int.Parse(input) - 1]));
            else
                MessageBox.Show(String.Format("PC Permits are good for {0}.", sectorValues[int.Parse(input) - 1]));

            Reset();
        }
    }
}
