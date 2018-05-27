using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Cryogenics;
using LHCEnums;
using LHCStatusOptions;
using BeamDump;
using EXPMagnetStatus;
using Page1Status;
using OCR;
using System.Windows.Forms;

namespace LHCStatus
{
    class LHCStatus
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new LHCStatusForm());
        }
    }
}