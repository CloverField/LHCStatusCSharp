﻿using System;
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

namespace LHCStatus
{
    class LHCStatus
    {
        static void Main(string[] args)
        {
            var systemTime = DateTime.Now;
            var cernTime = TimeZoneInfo.ConvertTime(DateTime.Now, 
                TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time"));

            Console.WriteLine("Current System Time: {0}\nCurrent CERN Time: {1}\n",
                systemTime.ToLongTimeString(), cernTime.ToLongTimeString());

            Console.WriteLine("Current System Date: {0}\nCurrent CERN Date: {1}\n",
                systemTime.ToLongDateString(), cernTime.ToLongDateString());

            Console.WriteLine("What do you want to Check?");
            var LHCStatusOptions = typeof(StatusOptions)
                .GetFields()
                .Select(f => f.GetValue(null))
                .ToList();
            var i = 1;
            LHCStatusOptions.ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CheckCryo(input);
                    break;
                case "2":
                    CheckCryoStatusForIndividualMagnet(input);      
                    break;
                case "3":
                    CheckIndividualPCPermit(input);
                    break;
                case "4":
                    CheckIndividualPCPermits(input);
                    break;
                case "5":
                    CheckRFCryo(input);
                    break;
                case "6":
                    CheckIndividualRFStatus(input);
                    break;
                case "7":
                    CheckBeamDump(input);
                    break;
                case "8":
                    CheckIndividualBeamDumpComponent(input);
                    break;
                case "9":
                    CheckEXPMagnets();
                    break;
                case "10":
                    CheckIndividualEXPMagnet(input);
                    break;
                case "11":
                    CheckBeamSMPFlags(input);
                    break;
                case "12":
                    CheckIndiviualBeamSMPFlag(input);
                    break;
                case "13":
                    PerformOCROnVistarPage(input);
                    break;
                default:
                    break;
            }
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        private static void PerformOCROnVistarPage(string input, int i = 1)
        {
            i = 1;
            Console.WriteLine("Page do you want to check");
            var vistars = Enum.GetValues(typeof(Machine.Vistar.Pages)).Cast<Machine.Vistar.Pages>();
            vistars.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString().Replace('_', ' ')));
            input = Console.ReadLine();
            string result = null;
            switch (input)
            {
                case "1":
                    if (!LHCOCR.ProcessData(Machine.Vistar.Pages.LHC_Configuration, out result))
                        Console.WriteLine("Was unable to perform OCR.");
                    else
                        if (result != null) Console.WriteLine(result);
                    break;
                case "2":
                    if(!LHCOCR.ProcessData(Machine.Vistar.Pages.LHC_Coordination, out result))
                        Console.WriteLine("Was unable to perform OCR.");
                    else
                        if (result != null) Console.WriteLine(result);
                    break;
                case "3":
                    if(!LHCOCR.ProcessData(Machine.Vistar.Pages.LHC_Cryogenics, out result))
                        Console.WriteLine("Was unable to perform OCR.");
                    else
                        if (result != null) Console.WriteLine(result);
                    break;
                case "4":
                    if(!LHCOCR.ProcessData(Machine.Vistar.Pages.LHC_EXP_Magnets, out result))
                        Console.WriteLine("Was unable to perform OCR.");
                    else
                        if (result != null) Console.WriteLine(result);
                    break;
                case "5":
                    if(!LHCOCR.ProcessData(Machine.Vistar.Pages.LHC_Luminosity, out result))
                        Console.WriteLine("Was unable to perform OCR.");
                    else
                        if (result != null) Console.WriteLine(result);
                    break;
                case "6":
                    if(!LHCOCR.ProcessData(Machine.Vistar.Pages.LHC_Operation, out result))
                        Console.WriteLine("Was unable to perform OCR.");
                    else
                        if (result != null) Console.WriteLine(result);
                    break;
                case "7":
                    if(!LHCOCR.ProcessData(Machine.Vistar.Pages.LHC_Page_1_Beam_Mode, out result))
                        Console.WriteLine("Was unable to perform OCR.");
                    else
                        if (result != null) Console.WriteLine(result);
                    break;
                case "8":
                    if (!LHCOCR.ProcessData(Machine.Vistar.Pages.LHC_Page_1_Comments, out result))
                        Console.WriteLine("Was unable to perform OCR.");
                    else
                        if (result != null) Console.WriteLine(result);
                    break;
                default:
                    break;
            }
        }

        private static void CheckIndividualRFStatus(string input, int i = 1)
        {
            i = 1;
            Console.WriteLine("Which cavity do you want to check?");
            var rfCavity = Enum.GetValues(typeof(Machine.RF.Cryo)).Cast<Machine.RF.Cryo>();
            rfCavity.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    if(CryoStatus.GetRFStatusIndividual(Machine.RF.Cryo.CM1L4))
                        Console.WriteLine("Everything looks good in for CM1L4.");
                    else
                        Console.WriteLine("The Cryo status is faulty in CM1L4");
                    break;
                case "2":
                    if (CryoStatus.GetRFStatusIndividual(Machine.RF.Cryo.CS1L4))
                        Console.WriteLine("Everything looks good in for CS1L4.");
                    else
                        Console.WriteLine("The Cryo status is faulty in CS1L4");
                    break;
                case "3":
                    if (CryoStatus.GetRFStatusIndividual(Machine.RF.Cryo.CM2L4))
                        Console.WriteLine("Everything looks good in for CM2L4.");
                    else
                        Console.WriteLine("The Cryo status is faulty in CM2L4");
                    break;
                case "4":
                    if (CryoStatus.GetRFStatusIndividual(Machine.RF.Cryo.CS2L4))
                        Console.WriteLine("Everything looks good in for CS2L4.");
                    else
                        Console.WriteLine("The Cryo status is faulty in CS2L4");
                    break;
                case "5":
                    if (CryoStatus.GetRFStatusIndividual(Machine.RF.Cryo.CM1R4))
                        Console.WriteLine("Everything looks good in for CM1R4.");
                    else
                        Console.WriteLine("The Cryo status is faulty in CM1R4");
                    break;
                case "6":
                    if (CryoStatus.GetRFStatusIndividual(Machine.RF.Cryo.CS1R4))
                        Console.WriteLine("Everything looks good in for CS1R4.");
                    else
                        Console.WriteLine("The Cryo status is faulty in CS1R4");
                    break;
                case "7":
                    if (CryoStatus.GetRFStatusIndividual(Machine.RF.Cryo.CM2R4))
                        Console.WriteLine("Everything looks good in for CM2R4.");
                    else
                        Console.WriteLine("The Cryo status is faulty in CM2R4");
                    break;
                case "8":
                    if (CryoStatus.GetRFStatusIndividual(Machine.RF.Cryo.CS2R4))
                        Console.WriteLine("Everything looks good in for CS2R4.");
                    else
                        Console.WriteLine("The Cryo status is faulty in CS2R4");
                    break;
                default:
                    break;
            }
        }

        private static void CheckIndividualPCPermits(string input, int i = 1)
        {
            Console.WriteLine("Which permit do you want to check?");
            var permits = Enum.GetValues(typeof(Machine.Cryo.PCPermit)).Cast<Machine.Cryo.PCPermit>();
            i = 1;
            permits.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    if (CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S12))
                        Console.WriteLine("The PC permit looks good.");
                    else
                        Console.WriteLine("The PC Permit is false.");
                    break;
                case "2":
                    if (CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S23))
                        Console.WriteLine("The PC permit looks good.");
                    else
                        Console.WriteLine("The PC Permit is false.");
                    break;
                case "3":
                    if (CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S34))
                        Console.WriteLine("The PC permit looks good.");
                    else
                        Console.WriteLine("The PC Permit is false.");
                    break;
                case "4":
                    if (CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S45))
                        Console.WriteLine("The PC permit looks good.");
                    else
                        Console.WriteLine("The PC Permit is false.");
                    break;
                case "5":
                    if (CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S56))
                        Console.WriteLine("The PC permit looks good.");
                    else
                        Console.WriteLine("The PC Permit is false.");
                    break;
                case "6":
                    if (CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S67))
                        Console.WriteLine("The PC permit looks good.");
                    else
                        Console.WriteLine("The PC Permit is false.");
                    break;
                case "7":
                    if (CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S78))
                        Console.WriteLine("The PC permit looks good.");
                    else
                        Console.WriteLine("The PC Permit is false.");
                    break;
                case "8":
                    if (CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S81))
                        Console.WriteLine("The PC permit looks good.");
                    else
                        Console.WriteLine("The PC Permit is false.");
                    break;
                default:
                    break;
            }
        }

        private static void CheckCryoStatusForIndividualMagnet(string input, int i = 1)
        {
            Console.WriteLine("Which sector do you want to check?");
            var sectors = Enum.GetValues(typeof(Machine.Cryo.Sectors)).Cast<Machine.Cryo.Sectors>();
            i = 1;
            sectors.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
            input = Console.ReadLine();
            Machine.Cryo.Sectors sector;
            if (int.TryParse(input, out int choice))
                sector = sectors.ToList()[choice - 1];
            else
            {
                Console.WriteLine("Please enter a valid choice.");
                return;
            }

            List<Machine.Cryo.Magnets.Magnet> magnets = new List<Machine.Cryo.Magnets.Magnet>();

            switch (sector)
            {
                case Machine.Cryo.Sectors.Sector12:
                    magnets = Enum.GetValues(typeof(Machine.Cryo.Magnets.Magnet)).Cast<Machine.Cryo.Magnets.Magnet>().ToList().GetRange(0,10);
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

            i = 1;
            magnets.ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
            input = Console.ReadLine();
            Machine.Cryo.Magnets.Magnet magnet;
            if (int.TryParse(input, out choice))
                magnet = magnets.ToList()[choice - 1];
            else
            {
                Console.WriteLine("Please enter a valid choice.");
                return;
            }

            if (CryoStatus.GetSectorStatusIndividual(sector, magnet))
                Console.WriteLine("Everything looks good for " + magnet.ToString());
            else
                Console.WriteLine("Cryo is down for " + magnet.ToString());
        }

        private static void CheckIndiviualBeamSMPFlag(string input, int i = 1)
        {
            Console.WriteLine("Which beam do you want to check?");
            var beamValues2 = Enum.GetValues(typeof(Machine.Beam)).Cast<Machine.Beam>();
            i = 1;
            beamValues2.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Which SMP Flag do you want to check?");
                    var beam1SmpFlags = Enum.GetValues(typeof(Machine.Page1.SMPFlags)).Cast<Machine.Page1.SMPFlags>();
                    i = 1;
                    beam1SmpFlags.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString().Replace('_', ' ')));
                    input = Console.ReadLine();
                    bool beam1status;
                    switch (input)
                    {
                        case "1":
                            beam1status = PageStatus.GetSMPStatus(Machine.Beam.Beam1, Machine.Page1.SMPFlags.Beam_Presence);
                            Console.WriteLine("Beam 1 Beam Presence Flag is {0}.", beam1status);
                            break;
                        case "2":
                            beam1status = PageStatus.GetSMPStatus(Machine.Beam.Beam1, Machine.Page1.SMPFlags.Global_Beam_Permit);
                            Console.WriteLine("Beam 1 Global Beam Permit Flag is {0}.", beam1status);
                            break;
                        case "3":
                            beam1status = PageStatus.GetSMPStatus(Machine.Beam.Beam1, Machine.Page1.SMPFlags.Link_Status_of_Beam_Permits);
                            Console.WriteLine("Beam 1 Link Status of Beam Permits Flag is {0}.", beam1status);
                            break;
                        case "4":
                            beam1status = PageStatus.GetSMPStatus(Machine.Beam.Beam1, Machine.Page1.SMPFlags.Moveable_Devices_Allowed_In);
                            Console.WriteLine("Beam 1 Moveable Devices Allowed In Flag is {0}.", beam1status);
                            break;
                        case "5":
                            beam1status = PageStatus.GetSMPStatus(Machine.Beam.Beam1, Machine.Page1.SMPFlags.Setup_Beam);
                            Console.WriteLine("Beam 1 Setup Beam Flag is {0}.", beam1status);
                            break;
                        case "6":
                            beam1status = PageStatus.GetSMPStatus(Machine.Beam.Beam1, Machine.Page1.SMPFlags.Stable_Beams);
                            Console.WriteLine("Beam 1 Stable Beams Flag is {0}.", beam1status);
                            break;
                        default:
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("Which SMP Flag do you want to check?");
                    var beam2SmpFlags = Enum.GetValues(typeof(Machine.Page1.SMPFlags)).Cast<Machine.Page1.SMPFlags>();
                    i = 1;
                    beam2SmpFlags.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString().Replace('_', ' ')));
                    input = Console.ReadLine();
                    bool beam2status;
                    switch (input)
                    {
                        case "1":
                            beam2status = PageStatus.GetSMPStatus(Machine.Beam.Beam2, Machine.Page1.SMPFlags.Beam_Presence);
                            Console.WriteLine("Beam 2 Beam Presence Flag is {0}.", beam2status);
                            break;
                        case "2":
                            beam2status = PageStatus.GetSMPStatus(Machine.Beam.Beam2, Machine.Page1.SMPFlags.Global_Beam_Permit);
                            Console.WriteLine("Beam 2 Global Beam Permit Flag is {0}.", beam2status);
                            break;
                        case "3":
                            beam2status = PageStatus.GetSMPStatus(Machine.Beam.Beam2, Machine.Page1.SMPFlags.Link_Status_of_Beam_Permits);
                            Console.WriteLine("Beam 2 Link Status of Beam Permits Flag is {0}.", beam2status);
                            break;
                        case "4":
                            beam2status = PageStatus.GetSMPStatus(Machine.Beam.Beam2, Machine.Page1.SMPFlags.Moveable_Devices_Allowed_In);
                            Console.WriteLine("Beam 2 Moveable Devices Allowed In Flag is {0}.", beam2status);
                            break;
                        case "5":
                            beam2status = PageStatus.GetSMPStatus(Machine.Beam.Beam2, Machine.Page1.SMPFlags.Setup_Beam);
                            Console.WriteLine("Beam 2 Setup Beam Flag is {0}.", beam2status);
                            break;
                        case "6":
                            beam2status = PageStatus.GetSMPStatus(Machine.Beam.Beam2, Machine.Page1.SMPFlags.Stable_Beams);
                            Console.WriteLine("Beam 2 Stable Beams Flag is {0}.", beam2status);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private static void CheckBeamSMPFlags(string input, int i = 1)
        {
            Console.WriteLine("Which beam do you want to check?");
            var beamValues = Enum.GetValues(typeof(Machine.Beam)).Cast<Machine.Beam>();
            i = 1;
            beamValues.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    if (PageStatus.GetBeamSMPStatus(Machine.Beam.Beam1))
                        Console.WriteLine("Beam 1's SMP Status is good.");
                    else
                        Console.WriteLine("There is a fault with Beam 1's SMP Status.");
                    break;
                case "2":
                    if (PageStatus.GetBeamSMPStatus(Machine.Beam.Beam2))
                        Console.WriteLine("Beam 2's SMP Status is good.");
                    else
                        Console.WriteLine("There is a fault with Beam 2's SMP Status.");
                    break;
                default:
                    break;
            }
        }

        private static void CheckEXPMagnets()
        {
            if (MagnetStatus.GetEXPMagnetStatus())
                Console.WriteLine("All EXP magnets are functioning correctly.");
            else
                Console.WriteLine("Not all EXP magnets are functioning correctly");
        }

        private static void CheckIndividualEXPMagnet(string input, int i = 1)
        {
            Console.WriteLine("Which magnet do you want to check?");
            var expMagnetValues = Enum.GetValues(typeof(Machine.EXPMagnets)).Cast<Machine.EXPMagnets>();
            i = 1;
            expMagnetValues.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString().Replace('_', ' ')));
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    if (MagnetStatus.GetEXPMagnetStatusIndividual(Machine.EXPMagnets.ALICE_dipole))
                        Console.WriteLine("The ALICE Dipole is functioning correctly");
                    else
                        Console.WriteLine("Looks like there is a fault in the ALICE Dipole.");
                    break;
                case "2":
                    if (MagnetStatus.GetEXPMagnetStatusIndividual(Machine.EXPMagnets.ALICE_solenoid))
                        Console.WriteLine("The ALICE Solenoid is functioning correctly");
                    else
                        Console.WriteLine("Looks like there is a fault in the ALICE Solenoid.");
                    break;
                case "3":
                    if (MagnetStatus.GetEXPMagnetStatusIndividual(Machine.EXPMagnets.ATLAS_solenoid))
                        Console.WriteLine("The ATLAS Solenoid is functioning correctly");
                    else
                        Console.WriteLine("Looks like there is a fault in the ATLAS Solenoid.");
                    break;
                case "4":
                    if (MagnetStatus.GetEXPMagnetStatusIndividual(Machine.EXPMagnets.ATLAS_torid))
                        Console.WriteLine("The ATLAS Torid is functioning correctly");
                    else
                        Console.WriteLine("Looks like there is a fault in the ATLAS Torid.");
                    break;
                case "5":
                    if (MagnetStatus.GetEXPMagnetStatusIndividual(Machine.EXPMagnets.CMS_solenoid))
                        Console.WriteLine("The CMS Solenoid is functioning correctly");
                    else
                        Console.WriteLine("Looks like there is a fault in the CMS Solenoid.");
                    break;
                case "6":
                    if (MagnetStatus.GetEXPMagnetStatusIndividual(Machine.EXPMagnets.LHCb_dipole))
                        Console.WriteLine("The LHCb Dipole is functioning correctly");
                    else
                        Console.WriteLine("Looks like there is a fault in the LHCb Dipole.");
                    break;
                default:
                    break;
            }
        }

        private static void CheckIndividualBeamDumpComponent(string input, int i = 1)
        {
            Console.WriteLine("Which Beam dump do you want to check?");
            var beamDumpValuesIndividual = Enum.GetValues(typeof(Machine.Beam)).Cast<Machine.Beam>();
            i = 1;
            beamDumpValuesIndividual.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Which component do you want to check?");
                    var beamOneComponents = Enum.GetValues(typeof(Machine.BeamDump.Components)).Cast<Machine.BeamDump.Components>();
                    i = 1;
                    foreach (var s in beamOneComponents)
                    {
                        if (s.ToString() != "TIMEOUT")
                            Console.WriteLine(i++ + "." + s.ToString().Replace('_', ' ').Replace('U', '-'));
                        else
                            Console.WriteLine(i++ + "." + s.ToString());
                    }
                    input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.BeamDumped))
                                Console.WriteLine("Beam 1 has not been dumped.");
                            else
                                Console.WriteLine("Beam 1 has been dumped.");
                            break;
                        case "2":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.Kicker))
                                Console.WriteLine("The kicker is good.");
                            else
                                Console.WriteLine("The kicker is faulty.");
                            break;
                        case "3":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.BETS))
                                Console.WriteLine("The BETS is good.");
                            else
                                Console.WriteLine("The BETS is faulty.");
                            break;
                        case "4":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.IPOC_U_Beam_Dump_Pane))
                                Console.WriteLine("The IPOC in the beam dump pane is good.");
                            else
                                Console.WriteLine("The IPOC in the beam dump pane is faulty.");
                            break;
                        case "5":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.LASS))
                                Console.WriteLine("The LASS is good.");
                            else
                                Console.WriteLine("The LASS is faulty.");
                            break;
                        case "6":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.RETRIGGER))
                                Console.WriteLine("The RETRIGGER is good.");
                            else
                                Console.WriteLine("The RETRIGGER is faulty.");
                            break;
                        case "7":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.XPOC))
                                Console.WriteLine("The XPOC is good.");
                            else
                                Console.WriteLine("The XPOC is faulty.");
                            break;
                        case "8":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.REMOTE_U_Beam_Dump_Pane))
                                Console.WriteLine("The REMOTE in the beam dump pane is good.");
                            else
                                Console.WriteLine("The REMOTE in the beam dump pane is faulty");
                            break;
                        case "9":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.ON_U_Beam_Dump_Pane))
                                Console.WriteLine("The ON in the beam dump pane is good.");
                            else
                                Console.WriteLine("The ON in the beam dump pane is faulty.");
                            break;
                        case "10":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.REMOTE_U_Injection_Pane))
                                Console.WriteLine("The REMOTE in the injection pane is good.");
                            else
                                Console.WriteLine("The REMOTE in the injection pane is faulty.");
                            break;
                        case "11":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.ON_U_Injection_Pane))
                                Console.WriteLine("The ON in the injection pane is good.");
                            else
                                Console.WriteLine("The ON in the injection pane is faulty.");
                            break;
                        case "12":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.TIMING_ON))
                                Console.WriteLine("The TIMEING ON is good.");
                            else
                                Console.WriteLine("The TIMEING ON is faulty.");
                            break;
                        case "13":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.CONDITIONING))
                                Console.WriteLine("The CONDITIONING is good.");
                            else
                                Console.WriteLine("The CONDITIONING is faulty.");
                            break;
                        case "14":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.TIMEOUT))
                                Console.WriteLine("The TIMEOUT has not expired.");
                            else
                                Console.WriteLine("The TIMEOUT has expired.");
                            break;
                        case "15":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.IPOC_U_Injection_Pane))
                                Console.WriteLine("The IPOC in the injection pane is good.");
                            else
                                Console.WriteLine("The IPOC in the injection pane is faulty.");
                            break;
                        case "16":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam1, Machine.BeamDump.Components.IQC))
                                Console.WriteLine("The IQC is good.");
                            else
                                Console.WriteLine("The IQC is faulty.");
                            break;
                        default:
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("Which component do you want to check?");
                    var beamTwoComponents = Enum.GetValues(typeof(Machine.BeamDump.Components)).Cast<Machine.BeamDump.Components>();
                    i = 1;
                    foreach (var s in beamTwoComponents)
                    {
                        if (s.ToString() != "TIMEOUT")
                            Console.WriteLine(i++ + "." + s.ToString().Replace('_', ' ').Replace('U', '-'));
                        else
                            Console.WriteLine(i++ + "." + s.ToString());
                    }
                    input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam2, Machine.BeamDump.Components.BeamDumped))
                                Console.WriteLine("Beam 2 has not been dumped.");
                            else
                                Console.WriteLine("Beam 2 has been dumped.");
                            break;
                        case "2":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam2, Machine.BeamDump.Components.Kicker))
                                Console.WriteLine("The kicker is good.");
                            else
                                Console.WriteLine("The kicker is faulty.");
                            break;
                        case "3":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam2, Machine.BeamDump.Components.BETS))
                                Console.WriteLine("The BETS is good.");
                            else
                                Console.WriteLine("The BETS is faulty.");
                            break;
                        case "4":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam2, Machine.BeamDump.Components.IPOC_U_Beam_Dump_Pane))
                                Console.WriteLine("The IPOC in the beam dump pane is good.");
                            else
                                Console.WriteLine("The IPOC in the beam dump pane is faulty.");
                            break;
                        case "5":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam2, Machine.BeamDump.Components.LASS))
                                Console.WriteLine("The LASS is good.");
                            else
                                Console.WriteLine("The LASS is faulty.");
                            break;
                        case "6":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam2, Machine.BeamDump.Components.RETRIGGER))
                                Console.WriteLine("The RETRIGGER is good.");
                            else
                                Console.WriteLine("The RETRIGGER is faulty.");
                            break;
                        case "7":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam2, Machine.BeamDump.Components.XPOC))
                                Console.WriteLine("The XPOC is good.");
                            else
                                Console.WriteLine("The XPOC is faulty.");
                            break;
                        case "8":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam2, Machine.BeamDump.Components.REMOTE_U_Beam_Dump_Pane))
                                Console.WriteLine("The REMOTE in the beam dump pane is good.");
                            else
                                Console.WriteLine("The REMOTE in the beam dump pane is faulty");
                            break;
                        case "9":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam2, Machine.BeamDump.Components.ON_U_Beam_Dump_Pane))
                                Console.WriteLine("The ON in the beam dump pane is good.");
                            else
                                Console.WriteLine("The ON in the beam dump pane is faulty.");
                            break;
                        case "10":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam2, Machine.BeamDump.Components.REMOTE_U_Injection_Pane))
                                Console.WriteLine("The REMOTE in the injection pane is good.");
                            else
                                Console.WriteLine("The REMOTE in the injection pane is faulty.");
                            break;
                        case "11":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam2, Machine.BeamDump.Components.ON_U_Injection_Pane))
                                Console.WriteLine("The ON in the injection pane is good.");
                            else
                                Console.WriteLine("The ON in the injection pane is faulty.");
                            break;
                        case "12":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam2, Machine.BeamDump.Components.TIMING_ON))
                                Console.WriteLine("The TIMEING ON is good.");
                            else
                                Console.WriteLine("The TIMEING ON is faulty.");
                            break;
                        case "13":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam2, Machine.BeamDump.Components.CONDITIONING))
                                Console.WriteLine("The CONDITIONING is good.");
                            else
                                Console.WriteLine("The CONDITIONING is faulty.");
                            break;
                        case "14":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam2, Machine.BeamDump.Components.TIMEOUT))
                                Console.WriteLine("The TIMEOUT has not expired.");
                            else
                                Console.WriteLine("The TIMEOUT has expired.");
                            break;
                        case "15":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam2, Machine.BeamDump.Components.IPOC_U_Injection_Pane))
                                Console.WriteLine("The IPOC in the injection pane is good.");
                            else
                                Console.WriteLine("The IPOC in the injection pane is faulty.");
                            break;
                        case "16":
                            if (BeamDumpStatus.GetBeamDumpStatusIndividual(Machine.Beam.Beam2, Machine.BeamDump.Components.IQC))
                                Console.WriteLine("The IQC is good.");
                            else
                                Console.WriteLine("The IQC is faulty.");
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private static void CheckBeamDump(string input, int i = 1)
        {
            Console.WriteLine("Which Beam dump do you want to check?");
            var beamDumpValues = Enum.GetValues(typeof(Machine.Beam)).Cast<Machine.Beam>();
            i = 1;
            beamDumpValues.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    if (BeamDumpStatus.GetBeamBeamDumpStatus(Machine.Beam.Beam1))
                        Console.WriteLine("Everything looks good for the Beam 1 Beam Dump.");
                    else
                        Console.WriteLine("Looks like the Beam 1 Beam Dump is faulty.");
                    break;
                case "2":
                    if (BeamDumpStatus.GetBeamBeamDumpStatus(Machine.Beam.Beam2))
                        Console.WriteLine("Everything looks good for the Beam 2 Beam Dump.");
                    else
                        Console.WriteLine("Looks like the Beam 2 Beam Dump is faulty.");
                    break;
                default:
                    break;
            }
        }

        private static void CheckRFCryo(string input, int i = 1)
        {
            Console.WriteLine("What sector do you want to check?");
            var rfValues = Enum.GetValues(typeof(Machine.RF.Sectors)).Cast<Machine.RF.Sectors>();
            i = 1;
            rfValues.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    if (CryoStatus.GetRFStatus(Machine.RF.Sectors.Sector1L4))
                        Console.WriteLine("Everything looks good in Sector1L4.");
                    else
                        Console.WriteLine("Looks like Cryo is down in Sector1L4.");
                    break;
                case "2":
                    if (CryoStatus.GetRFStatus(Machine.RF.Sectors.Sector1R4))
                        Console.WriteLine("Everything looks good in Sector1R4.");
                    else
                        Console.WriteLine("Looks like Cryo is down in Sector1R4.");
                    break;
                case "3":
                    if (CryoStatus.GetRFStatus(Machine.RF.Sectors.Sector2L4))
                        Console.WriteLine("Everything looks good in Sector2L4.");
                    else
                        Console.WriteLine("Looks like Cryo is down in Sector2L4.");
                    break;
                case "4":
                    if (CryoStatus.GetRFStatus(Machine.RF.Sectors.Sector2R4))
                        Console.WriteLine("Everything looks good in Sector2R4.");
                    else
                        Console.WriteLine("Looks like Cryo is down in Sector2R4.");
                    break;
                default:
                    break;
            }
        }

        private static void CheckIndividualPCPermit(string input, int i = 1)
        {
            Console.WriteLine("What sector do you want to check?");
            var sectorValues = Enum.GetValues(typeof(Machine.Cryo.PCPermit)).Cast<Machine.Cryo.PCPermit>();
            i = 1;
            sectorValues.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    if (CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S12))
                        Console.WriteLine("The PC Permit is set in Sector 12.");
                    else
                        Console.WriteLine("Looks like the PC Permit is not set in Sector 12.");
                    break;
                case "2":
                    if (CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S23))
                        Console.WriteLine("The PC Permit is set in Sector 23.");
                    else
                        Console.WriteLine("Looks like the PC Permit is not set in Sector 23.");
                    break;
                case "3":
                    if (CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S34))
                        Console.WriteLine("The PC Permit is set in Sector 34.");
                    else
                        Console.WriteLine("Looks like the PC Permit is not set in Sector 34.");
                    break;
                case "4":
                    if (CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S45))
                        Console.WriteLine("The PC Permit is set in Sector 45.");
                    else
                        Console.WriteLine("Looks like the PC Permit is not set in Sector 45.");
                    break;
                case "5":
                    if (CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S56))
                        Console.WriteLine("The PC Permit is set in Sector 56.");
                    else
                        Console.WriteLine("Looks like the PC Permit is not set in Sector 56.");
                    break;
                case "6":
                    if (CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S67))
                        Console.WriteLine("The PC Permit is set in Sector 67.");
                    else
                        Console.WriteLine("Looks like the PC Permit is not set in Sector 67.");
                    break;
                case "7":
                    if (CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S78))
                        Console.WriteLine("The PC Permit is set in Sector 78.");
                    else
                        Console.WriteLine("Looks like the PC Permit is not set in Sector 78");
                    break;
                case "8":
                    if (CryoStatus.GetIndividualSixtyAmpPCPermitStatus(Machine.Cryo.PCPermit.S81))
                        Console.WriteLine("The PC Permit is set in Sector 81.");
                    else
                        Console.WriteLine("Looks like the PC Permit is not set in Sector 81.");
                    break;
                default:
                    break;
            }
        }

        private static void CheckCryo(string input, int i = 1)
        {
            Console.WriteLine("What sector do you want to check?");
            var cryoValues = Enum.GetValues(typeof(Machine.Cryo.Sectors)).Cast<Machine.Cryo.Sectors>();
            i = 1;
            cryoValues.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    if (CryoStatus.GetSectorStatus(Machine.Cryo.Sectors.Sector12))
                        Console.WriteLine("Everything looks good in Sector 12.");
                    else
                        Console.WriteLine("Looks like Cryo is down in Sector 12.");
                    break;
                case "2":
                    if (CryoStatus.GetSectorStatus(Machine.Cryo.Sectors.Sector23))
                        Console.WriteLine("Everything looks good in Sector 23.");
                    else
                        Console.WriteLine("Looks like Cryo is down in Sector 23.");
                    break;
                case "3":
                    if (CryoStatus.GetSectorStatus(Machine.Cryo.Sectors.Sector34))
                        Console.WriteLine("Everything looks good in Sector 34.");
                    else
                        Console.WriteLine("Looks like Cryo is down in Sector 34.");
                    break;
                case "4":
                    if (CryoStatus.GetSectorStatus(Machine.Cryo.Sectors.Sector45))
                        Console.WriteLine("Everything looks good in Sector 45.");
                    else
                        Console.WriteLine("Looks like Cryo is down in Sector 45.");
                    break;
                case "5":
                    if (CryoStatus.GetSectorStatus(Machine.Cryo.Sectors.Sector56))
                        Console.WriteLine("Everything looks good in Sector 56.");
                    else
                        Console.WriteLine("Looks like Cryo is down in Sector 56.");
                    break;
                case "6":
                    if (CryoStatus.GetSectorStatus(Machine.Cryo.Sectors.Sector67))
                        Console.WriteLine("Everything looks good in Sector 67.");
                    else
                        Console.WriteLine("Looks like Cryo is down in Sector 67.");
                    break;
                case "7":
                    if (CryoStatus.GetSectorStatus(Machine.Cryo.Sectors.Sector78))
                        Console.WriteLine("Everything looks good in Sector 78.");
                    else
                        Console.WriteLine("Looks like Cryo is down in Sector 78.");
                    break;
                case "8":
                    if (CryoStatus.GetSectorStatus(Machine.Cryo.Sectors.Sector81))
                        Console.WriteLine("Everything looks good in Sector 81.");
                    else
                        Console.WriteLine("Looks like Cryo is down in Sector 81.");
                    break;
                default:
                    break;
            }
        }
    }
}
