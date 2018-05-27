using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LHCStatusOptions;
using LHCStatusFunctions;
using LHCEnums;
using Cryogenics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LHCStatus
{
    public partial class LHCStatusForm : Form
    {
        private Machine.Cryo.Sectors? sector = null;
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
                    CheckCyroStatusForIndividualMagnetSelected(input);
                    break;
                case "3":
                    CheckSectorPCPermitSelected(input);
                    break;
                case "4":
                    Functions.CheckIndividualPCPermits(input);
                    break;
                case "5":
                    CheckRFCryoSelected(input);
                    break;
                case "6":
                    Functions.CheckIndividualRFStatus(input);
                    break;
                case "7":
                    CheckBeamDumpSelected(input);
                    break;
                case "8":
                    Functions.CheckIndividualBeamDumpComponent(input);
                    break;
                case "9":
                    CheckEXPMagnetsSelected();
                    break;
                case "10":
                    Functions.CheckIndividualEXPMagnet(input);
                    break;
                case "11":
                    CheckBeamSMPFlagsSelected(input);
                    break;
                case "12":
                    Functions.CheckIndiviualBeamSMPFlag(input);
                    break;
                case "13":
                    CheckPerfomOCROnVistarPageSelected(input);
                    break;
                default:
                    break;
            }
        }

        private void CheckCyroStatusForIndividualMagnetSelected(string input)
        {
            LHCButtonTableLayoutPanel.Controls.Clear();
            var sectors = Enum.GetValues(typeof(Machine.Cryo.Sectors)).Cast<Machine.Cryo.Sectors>();
            foreach (var sector in sectors)
            {
                var b = new Button()
                {
                    Name = sector.ToString(),
                    Text = sector.ToString(),
                    AutoSize = true
                };
                b.Click += SectorSelected;
                LHCButtonTableLayoutPanel.Controls.Add(b);
            }
        }

        private void CheckPerfomOCROnVistarPageSelected(string input)
        {
            LHCButtonTableLayoutPanel.Controls.Clear();
            var vistars = Enum.GetValues(typeof(Machine.Vistar.Pages)).Cast<Machine.Vistar.Pages>();
            foreach (var pages in vistars)
            {
                var b = new Button()
                {
                    Name = pages.ToString(),
                    Text = pages.ToString().Replace('_',' '),
                    AutoSize = true
                };
                b.Click += CheckPerfomOCROnVistarPageClick;
                LHCButtonTableLayoutPanel.Controls.Add(b);
            }
        }

        private void CheckBeamSMPFlagsSelected(string input)
        {
            LHCButtonTableLayoutPanel.Controls.Clear();
            var beamValues = Enum.GetValues(typeof(Machine.Beam)).Cast<Machine.Beam>();
            foreach (var value in beamValues)
            {
                var b = new Button()
                {
                    Name = value.ToString(),
                    Text = value.ToString(),
                    AutoSize = true
                };
                b.Click += CheckBeamSMPFlagsClick;
                LHCButtonTableLayoutPanel.Controls.Add(b);
            }
        }

        private void CheckEXPMagnetsSelected()
        {
            var task = Task<bool>.Factory.StartNew(() =>
            {
                return Functions.CheckEXPMagnets();
            });

            if (!task.Wait(4000))
                throw new Exception("Timed out waiting for task to complete.");

            if (task.IsFaulted)
                throw new Exception("Task failed.");

            if (task.Exception != null)
                throw task.Exception;

            if (task.Result)
                MessageBox.Show("All EXP Magnets are running.");
            else
                MessageBox.Show("Not all EXP Magnets are running.");
        }

        private void CheckBeamDumpSelected(string input)
        {
            LHCButtonTableLayoutPanel.Controls.Clear();
            var beamDumpValues = Enum.GetValues(typeof(Machine.Beam)).Cast<Machine.Beam>();
            foreach (var value in beamDumpValues)
            {
                var b = new Button()
                {
                    Name = value.ToString(),
                    Text = value.ToString(),
                    AutoSize = true
                };
                b.Click += CheckBeamDumpClick;
                LHCButtonTableLayoutPanel.Controls.Add(b);
            }
        }

        private void CheckRFCryoSelected(string input)
        {
            LHCButtonTableLayoutPanel.Controls.Clear();
            var rfValues = Enum.GetValues(typeof(Machine.RF.Sectors)).Cast<Machine.RF.Sectors>();
            foreach (var value in rfValues)
            {
                var b = new Button()
                {
                    Name = value.ToString(),
                    Text = value.ToString(),
                    AutoSize = true
                };
                b.Click += CheckRFCryoClick;
                LHCButtonTableLayoutPanel.Controls.Add(b);
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
                    Text = value.ToString(),
                    AutoSize = true
                };
                b.Click += SectorButtonClick;
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
                    Text = value.ToString(),
                    AutoSize = true
                };
                b.Click += CryoButtonClick;
                LHCButtonTableLayoutPanel.Controls.Add(b);
            }
        }

        private void SectorSelected(object sender, EventArgs e)
        {

            Button button = sender as Button;

            var sectors = Enum.GetValues(typeof(Machine.Cryo.Sectors)).Cast<Machine.Cryo.Sectors>().ToList();
            var input = sectors.FindIndex(f => f.ToString() == button.Name);
            sector = sectors[input];
            List<Machine.Cryo.Magnets.Magnet> magnets = new List<Machine.Cryo.Magnets.Magnet>();

            switch (sectors[input])
            {
                case Machine.Cryo.Sectors.Sector12:
                    magnets = Enum.GetValues(typeof(Machine.Cryo.Magnets.Magnet)).Cast<Machine.Cryo.Magnets.Magnet>().ToList().GetRange(0, 10);
                    break;
                case Machine.Cryo.Sectors.Sector23:
                    magnets = Enum.GetValues(typeof(Machine.Cryo.Magnets.Magnet)).Cast<Machine.Cryo.Magnets.Magnet>().ToList().GetRange(9, 6);
                    break;
                case Machine.Cryo.Sectors.Sector34:
                    magnets = Enum.GetValues(typeof(Machine.Cryo.Magnets.Magnet)).Cast<Machine.Cryo.Magnets.Magnet>().ToList().GetRange(16, 4);
                    break;
                case Machine.Cryo.Sectors.Sector45:
                    magnets = Enum.GetValues(typeof(Machine.Cryo.Magnets.Magnet)).Cast<Machine.Cryo.Magnets.Magnet>().ToList().GetRange(20, 8);
                    break;
                case Machine.Cryo.Sectors.Sector56:
                    magnets = Enum.GetValues(typeof(Machine.Cryo.Magnets.Magnet)).Cast<Machine.Cryo.Magnets.Magnet>().ToList().GetRange(28, 8);
                    break;
                case Machine.Cryo.Sectors.Sector67:
                    magnets = Enum.GetValues(typeof(Machine.Cryo.Magnets.Magnet)).Cast<Machine.Cryo.Magnets.Magnet>().ToList().GetRange(36, 4);
                    break;
                case Machine.Cryo.Sectors.Sector78:
                    magnets = Enum.GetValues(typeof(Machine.Cryo.Magnets.Magnet)).Cast<Machine.Cryo.Magnets.Magnet>().ToList().GetRange(40, 6);
                    break;
                case Machine.Cryo.Sectors.Sector81:
                    magnets = Enum.GetValues(typeof(Machine.Cryo.Magnets.Magnet)).Cast<Machine.Cryo.Magnets.Magnet>().ToList().GetRange(46, 10);
                    break;
                default:
                    break;
            }

            LHCButtonTableLayoutPanel.Controls.Clear();
            foreach (var magnet in magnets)
            {
                var b = new Button()
                {
                    Name = magnet.ToString(),
                    Text = magnet.ToString(),
                    AutoSize = true
                };
                b.Click += IndividualMagnetClick;
                LHCButtonTableLayoutPanel.Controls.Add(b);
            }

        }

        private void IndividualMagnetClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            var magnet = Enum.GetValues(typeof(Machine.Cryo.Magnets.Magnet)).Cast<Machine.Cryo.Magnets.Magnet>().Where(m => m.ToString() == button.Name).Single();
            if (sector == null)
                throw new Exception("Sector is null, it shouldn't be.");

            var task = Task<bool>.Factory.StartNew(() =>
            {
                return Functions.CheckCryoStatusForIndividualMagnet(sector.Value, magnet);
            });

            if (!task.Wait(4000))
                throw new Exception("Timed out waiting for task to complete.");

            if (task.IsFaulted)
                throw new Exception("Task failed.");

            if (task.Exception != null)
                throw task.Exception;

            if (task.Result)
                MessageBox.Show(String.Format("Cryo Status is good for magnet {0}.", magnet));
            else
                MessageBox.Show(String.Format("Cryo Status is bad for magnet {0}.", magnet));

            sector = null;
            Reset();
        }

        private void CheckPerfomOCROnVistarPageClick(object sender, EventArgs e)
        {
            var vistars = Enum.GetValues(typeof(Machine.Vistar.Pages)).Cast<Machine.Vistar.Pages>().ToList();
            Button button = sender as Button;
            var input = (vistars.FindIndex(f => f.ToString() == button.Name) + 1).ToString();
            string result = null;
            var task = Task<bool>.Factory.StartNew(() =>
            {
                return Functions.PerformOCROnVistarPage(input, out result);
            });

            if (!task.Wait(10000))
                throw new Exception("Timed out waiting for task to complete.");

            if (task.IsFaulted)
                throw new Exception("Task failed.");

            if (task.Exception != null)
                throw task.Exception;

            if (task.Result)
            {
                if (result != null)
                {
                    MessageBox.Show(String.Format("Successfully performed OCR on Page {0}.", vistars[int.Parse(input) - 1]).Replace('_', ' '));
                    MessageBox.Show(result);
                }
                else
                    MessageBox.Show(String.Format("Unable to perform OCR on Page {0}.", vistars[int.Parse(input) - 1]).Replace('_', ' '));
            }
            else
                MessageBox.Show(String.Format("Unable to perform OCR on Page {0}.", vistars[int.Parse(input) - 1]).Replace('_', ' '));

            Reset();
        }

        private void CheckBeamSMPFlagsClick(object sender, EventArgs e)
        {
            var beamValues = Enum.GetValues(typeof(Machine.Beam)).Cast<Machine.Beam>().ToList();
            Button button = sender as Button;
            var input = (beamValues.FindIndex(f => f.ToString() == button.Name) + 1).ToString();
            var task = Task<bool>.Factory.StartNew(() =>
            {
                return Functions.CheckBeamSMPFlags(input);
            });

            if (!task.Wait(4000))
                throw new Exception("Timed out waiting for task to complete.");

            if (task.IsFaulted)
                throw new Exception("Task failed.");

            if (task.Exception != null)
                throw task.Exception;

            if (task.Result)
                MessageBox.Show(String.Format("SMP Flags are good for beam {0}.", beamValues[int.Parse(input) - 1]));
            else
                MessageBox.Show(String.Format("SMP Flags are bad for beam {0}.", beamValues[int.Parse(input) - 1]));

            Reset();
        }

        private void CheckBeamDumpClick(object sender, EventArgs e)
        {
            var beamDumpValues = Enum.GetValues(typeof(Machine.Beam)).Cast<Machine.Beam>().ToList();
            Button button = sender as Button;
            var input = (beamDumpValues.FindIndex(f => f.ToString() == button.Name) + 1).ToString();
            var task = Task<bool>.Factory.StartNew(() =>
            {
                return Functions.CheckBeamDump(input);
            });

            if (!task.Wait(4000))
                throw new Exception("Timed out waiting for task to complete.");

            if (task.IsFaulted)
                throw new Exception("Task failed.");

            if (task.Exception != null)
                throw task.Exception;

            if (task.Result)
                MessageBox.Show(String.Format("Beam Dump is good for beam {0}.", beamDumpValues[int.Parse(input) - 1]));
            else
                MessageBox.Show(String.Format("Beam Dump is faulty for beam {0}.", beamDumpValues[int.Parse(input) - 1]));

            Reset();
        }

        private void CheckRFCryoClick(object sender, EventArgs e)
        {
            var rfValues = Enum.GetValues(typeof(Machine.RF.Sectors)).Cast<Machine.RF.Sectors>().ToList();
            Button button = sender as Button;
            var input = (rfValues.FindIndex(f => f.ToString() == button.Name) + 1).ToString();

            var task = Task<bool>.Factory.StartNew(() =>
            {
                return Functions.CheckRFCryo(input);
            });

            if (!task.Wait(4000))
                throw new Exception("Timed out waiting for task to complete.");

            if (task.IsFaulted)
                throw new Exception("Task failed.");

            if (task.Exception != null)
                throw task.Exception;

            if (task.Result)
                MessageBox.Show(String.Format("Cryo is good for RF Sector {0}.", rfValues[int.Parse(input) - 1]));
            else
                MessageBox.Show(String.Format("Cryo is down for RF Sector {0}.", rfValues[int.Parse(input) - 1]));

            Reset();
        }

        private void SectorButtonClick(object sender, EventArgs e)
        {
            var sectorValues = Enum.GetValues(typeof(Machine.Cryo.PCPermit)).Cast<Machine.Cryo.PCPermit>().ToList();
            Button button = sender as Button;
            var input = (sectorValues.FindIndex(f => f.ToString() == button.Name) + 1).ToString();
            var task = Task<bool>.Factory.StartNew(() => {
                return Functions.CheckSectorPCPermit(input);
            });

            if (!task.Wait(4000))
                throw new Exception("Timed out waiting for task to complete.");

            if (task.IsFaulted)
                throw new Exception("Task failed.");

            if (task.Exception != null)
                throw task.Exception;

            if (task.Result)
                MessageBox.Show(String.Format("PC Permits are good for Sector {0}.", sectorValues[int.Parse(input) - 1]));
            else
                MessageBox.Show(String.Format("PC Permits are bad for Sector {0}.", sectorValues[int.Parse(input) - 1]));

            Reset();
        }

        private void CryoButtonClick(object sender, EventArgs e)
        {
            var cryoValues = Enum.GetValues(typeof(Machine.Cryo.Sectors)).Cast<Machine.Cryo.Sectors>().ToList();
            Button button = sender as Button;
            var input = (cryoValues.FindIndex(f => f.ToString() == button.Name) + 1).ToString();
            var task = Task<bool>.Factory.StartNew(() => {
                return Functions.CheckCryo(input);
            });

            if (!task.Wait(4000))
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
    }
}
