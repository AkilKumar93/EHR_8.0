using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using Acurus.Capella.Core.DTO;
using Acurus.Capella.Core.DomainObjects;
using Acurus.Capella.DataAccess;
using Acurus.Capella.DataAccess.ManagerObjects;

namespace Acurus.Capella.ImmunizationSubmission
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Start");
                ImmunizationUtilityManager objImmunization = new ImmunizationUtilityManager();
                objImmunization.GenerateImmunizationRegistry();
                Console.WriteLine("Completed");
            }
            catch(Exception ex) {
                Console.WriteLine("Exception Occured:"+Environment.NewLine);
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}
