using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryogenics;
using LHCEnums;

namespace LHCStatus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What do you want to Check?");
            Console.WriteLine("1. Cryo Status\n2. 60 AMP PC Permit Status \n3. RF Status");
            var input = Console.ReadLine().ToUpper();
            switch (input)
            {
                case "1":
                    Console.WriteLine("What sector do you want to check?");
                    var cryoValues = Enum.GetValues(typeof(Machine.Sector)).Cast<Machine.Sector>();
                    var i = 1;
                    cryoValues.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            if (CryoStatus.GetSectorStatus(Machine.Sector.Sector12))
                                Console.WriteLine("Everthing looks good in Sector 12");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector 12");
                            break;
                        case "2":
                            if(CryoStatus.GetSectorStatus(Machine.Sector.Sector23))
                                Console.WriteLine("Everthing looks good in Sector 23");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector 23");
                            break;
                        case "3":
                            if (CryoStatus.GetSectorStatus(Machine.Sector.Sector34))
                                Console.WriteLine("Everthing looks good in Sector 34");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector 34");
                            break;
                        case "4":
                            if (CryoStatus.GetSectorStatus(Machine.Sector.Sector45))
                                Console.WriteLine("Everthing looks good in Sector 45");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector 45");
                            break;
                        case "5":
                            if (CryoStatus.GetSectorStatus(Machine.Sector.Sector56))
                                Console.WriteLine("Everthing looks good in Sector 56");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector 56");
                            break;
                        case "6":
                            if (CryoStatus.GetSectorStatus(Machine.Sector.Sector67))
                                Console.WriteLine("Everthing looks good in Sector 67");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector 67");
                            break;
                        case "7":
                            if (CryoStatus.GetSectorStatus(Machine.Sector.Sector78))
                                Console.WriteLine("Everthing looks good in Sector 12");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector 12");
                            break;
                        case "8":
                            if (CryoStatus.GetSectorStatus(Machine.Sector.Sector81))
                                Console.WriteLine("Everthing looks good in Sector 12");
                            else
                                Console.WriteLine("Looks like Cryo is down in Sector 12");
                            break;
                        default:
                            Console.WriteLine("Please enter a valid number!");
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
                            break;
                        case "2":
                            break;
                        case "3":
                            break;
                        case "4":
                            break;
                        case "5":
                            break;
                        case "6":
                            break;
                        case "7":
                            break;
                        case "8":
                            break;
                        default:
                            break;
                    }
                    break;
                case "3":
                    Console.WriteLine("What sector do you want to check?");
                    var rfValues= Enum.GetValues(typeof(Machine.RF)).Cast<Machine.RF>();
                    i = 1;
                    rfValues.ToList().ForEach(s => Console.WriteLine(i++ + "." + s.ToString()));
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            break;
                        case "2":
                            break;
                        case "3":
                            break;
                        case "4":
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
