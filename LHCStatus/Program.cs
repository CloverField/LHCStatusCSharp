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

namespace LHCStatus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What do you want to Check?");
            var LHCStatusOptions = typeof(StatusOptions)
                .GetFields()
                .Select(f => f.GetValue(null))
                .ToList();
            var i = 1;
            LHCStatusOptions.ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
            var input = Console.ReadLine().ToUpper();
            switch (input)
            {
                case "1":
                    Console.WriteLine("What sector do you want to check?");
                    var cryoValues = Enum.GetValues(typeof(Machine.Sector)).Cast<Machine.Sector>();
                    i = 1;
                    cryoValues.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            if (CryoStatus.GetSectorStatus(Machine.Sector.Sector12))
                                Console.WriteLine("Everthing looks good in Sector 12.");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector 12.");
                            break;
                        case "2":
                            if(CryoStatus.GetSectorStatus(Machine.Sector.Sector23))
                                Console.WriteLine("Everthing looks good in Sector 23.");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector 23.");
                            break;
                        case "3":
                            if (CryoStatus.GetSectorStatus(Machine.Sector.Sector34))
                                Console.WriteLine("Everthing looks good in Sector 34.");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector 34.");
                            break;
                        case "4":
                            if (CryoStatus.GetSectorStatus(Machine.Sector.Sector45))
                                Console.WriteLine("Everthing looks good in Sector 45.");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector 45.");
                            break;
                        case "5":
                            if (CryoStatus.GetSectorStatus(Machine.Sector.Sector56))
                                Console.WriteLine("Everthing looks good in Sector 56.");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector 56.");
                            break;
                        case "6":
                            if (CryoStatus.GetSectorStatus(Machine.Sector.Sector67))
                                Console.WriteLine("Everthing looks good in Sector 67.");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector 67.");
                            break;
                        case "7":
                            if (CryoStatus.GetSectorStatus(Machine.Sector.Sector78))
                                Console.WriteLine("Everthing looks good in Sector 78.");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector 78.");
                            break;
                        case "8":
                            if (CryoStatus.GetSectorStatus(Machine.Sector.Sector81))
                                Console.WriteLine("Everthing looks good in Sector 81.");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector 81.");
                            break;
                        default:
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("What sector do you want to check?");
                    var sectorValues = Enum.GetValues(typeof(Machine.Sector)).Cast<Machine.Sector>();
                    i = 1;
                    sectorValues.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            if (CryoStatus.GetSixtyAmpPCPermitStatus(Machine.Sector.Sector12))
                                Console.WriteLine("The PC Permit is set in Sector 12.");
                            else
                                Console.WriteLine("Looks like the PC Permit is not set in Sector 12.");
                            break;
                        case "2":
                            if (CryoStatus.GetSixtyAmpPCPermitStatus(Machine.Sector.Sector23))
                                Console.WriteLine("The PC Permit is set in Sector 23.");
                            else
                                Console.WriteLine("Looks like the PC Permit is not set in Sector 23.");
                            break;
                        case "3":
                            if (CryoStatus.GetSixtyAmpPCPermitStatus(Machine.Sector.Sector34))
                                Console.WriteLine("The PC Permit is set in Sector 34.");
                            else
                                Console.WriteLine("Looks like the PC Permit is not set in Sector 34.");
                            break;
                        case "4":
                            if (CryoStatus.GetSixtyAmpPCPermitStatus(Machine.Sector.Sector45))
                                Console.WriteLine("The PC Permit is set in Sector 45.");
                            else
                                Console.WriteLine("Looks like the PC Permit is not set in Sector 45.");
                            break;
                        case "5":
                            if (CryoStatus.GetSixtyAmpPCPermitStatus(Machine.Sector.Sector56))
                                Console.WriteLine("The PC Permit is set in Sector 56.");
                            else
                                Console.WriteLine("Looks like the PC Permit is not set in Sector 56.");
                            break;
                        case "6":
                            if (CryoStatus.GetSixtyAmpPCPermitStatus(Machine.Sector.Sector67))
                                Console.WriteLine("The PC Permit is set in Sector 67.");
                            else
                                Console.WriteLine("Looks like the PC Permit is not set in Sector 67.");
                            break;
                        case "7":
                            if (CryoStatus.GetSixtyAmpPCPermitStatus(Machine.Sector.Sector78))
                                Console.WriteLine("The PC Permit is set in Sector 78.");
                            else
                                Console.WriteLine("Looks like the PC Permit is not set in Sector 78");
                            break;
                        case "8":
                            if (CryoStatus.GetSixtyAmpPCPermitStatus(Machine.Sector.Sector81))
                                Console.WriteLine("The PC Permit is set in Sector 81.");
                            else
                                Console.WriteLine("Looks like the PC Permit is not set in Sector 81.");
                            break;
                        default:
                            break;
                    }
                    break;
                case "3":
                    Console.WriteLine("What sector do you want to check?");
                    var rfValues = Enum.GetValues(typeof(Machine.RF)).Cast<Machine.RF>();
                    i = 1;
                    rfValues.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            if (CryoStatus.GetRFStatus(Machine.RF.Sector1L4))
                                Console.WriteLine("Everthing looks good in Sector1L4.");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector1L4.");
                            break;
                        case "2":
                            if (CryoStatus.GetRFStatus(Machine.RF.Sector1R4))
                                Console.WriteLine("Everthing looks good in Sector1R4.");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector1R4.");
                            break;
                        case "3":
                            if (CryoStatus.GetRFStatus(Machine.RF.Sector2L4))
                                Console.WriteLine("Everthing looks good in Sector2L4.");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector2L4.");
                            break;
                        case "4":
                            if (CryoStatus.GetRFStatus(Machine.RF.Sector2R4))
                                Console.WriteLine("Everthing looks good in Sector2R4.");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector2R4.");
                            break;
                        default:
                            break;
                    }
                    break;
                case "4":
                    Console.WriteLine("What sector do you want to check?");
                    var beamDumpValues = Enum.GetValues(typeof(Machine.BeamDump)).Cast<Machine.BeamDump>();
                    i = 1;
                    beamDumpValues.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            if(BeamDumpStatus.GetBeamDumpStatus(Machine.BeamDump.Beam1))
                                Console.WriteLine("Everthing looks good for the Beam 1 Beam Dump.");
                            else
                                Console.WriteLine("Looks like the Beam 1 Beam Dump is faulty.");
                            break;
                        case "2":
                            if (BeamDumpStatus.GetBeamDumpStatus(Machine.BeamDump.Beam2))
                                Console.WriteLine("Everthing looks good for the Beam 2 Beam Dump.");
                            else
                                Console.WriteLine("Looks like the Beam 2 Beam Dump is faulty.");
                            break;
                        default:
                            break;
                    }
                    break;
                case "5":
                    Console.WriteLine("Which magnet do you want to check?");
                    var expMagnetValues = Enum.GetValues(typeof(Machine.EXPMagnets)).Cast<Machine.EXPMagnets>();
                    i = 1;
                    expMagnetValues.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString().Replace('_',' ')));
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            if (MagnetStatus.GetEXPMagnetStatus(Machine.EXPMagnets.ALICE_dipole))
                                Console.WriteLine("The ALICE Dipole is functioning correctly");
                            else
                                Console.WriteLine("Looks like there is a fault in the ALICE Dipole.");
                            break;
                        case "2":
                            if (MagnetStatus.GetEXPMagnetStatus(Machine.EXPMagnets.ALICE_solenoid))
                                Console.WriteLine("The ALICE Solenoid is functioning correctly");
                            else
                                Console.WriteLine("Looks like there is a fault in the ALICE Solenoid.");
                            break;
                        case "3":
                            if (MagnetStatus.GetEXPMagnetStatus(Machine.EXPMagnets.ATLAS_solenoid))
                                Console.WriteLine("The ATLAS Solenoid is functioning correctly");
                            else
                                Console.WriteLine("Looks like there is a fault in the ATLAS Solenoid.");
                            break;
                        case "4":
                            if (MagnetStatus.GetEXPMagnetStatus(Machine.EXPMagnets.ATLAS_torid))
                                Console.WriteLine("The ATLAS Torid is functioning correctly");
                            else
                                Console.WriteLine("Looks like there is a fault in the ATLAS Torid.");
                            break;
                        case "5":
                            if (MagnetStatus.GetEXPMagnetStatus(Machine.EXPMagnets.CMS_solenoid))
                                Console.WriteLine("The CMS Solenoid is functioning correctly");
                            else
                                Console.WriteLine("Looks like there is a fault in the CMS Solenoid.");
                            break;
                        case "6":
                            if (MagnetStatus.GetEXPMagnetStatus(Machine.EXPMagnets.LHCb_dipole))
                                Console.WriteLine("The LHCb Dipole is functioning correctly");
                            else
                                Console.WriteLine("Looks like there is a fault in the LHCb Dipole.");
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
