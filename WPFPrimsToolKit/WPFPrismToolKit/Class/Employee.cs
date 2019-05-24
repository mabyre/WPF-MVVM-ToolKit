using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPFPrimsToolKit
{
    /// <summary>
    /// Class utilisée par l'exemple StaticSample
    /// </summary>
    public class Employee
    {
        private int empId;
        private static int nextEmpid = 100;
        private static string company = "MY_WORLD_COMPAGNY_INIT";

        public Employee()
        {
            empId = nextEmpid++;
        }

        //
        // On pourrait par exemple ajouter ce constructeur static
        // pour modifier la compagnie de nouveau employees
        //
        // --- Rules for static Constructor:
        // A class can have only one static constructor
        // Static constructor can not have any parameter
        // Static constructor can not have any access specifier
        // It is used to initialize the static data members of the class
        // for any number of object creation, the static constructor gets executed only once
        // The static constructor gets executed when the class is used
        // Static constructor can not be invoked by the programmer explicitly
        //
        static Employee()
        {
            // Initialize static members only
            company = "NEW_WORLD_COMPAGNY";
        }

        internal void Print(ref string message)
        {
            message += "Employee ID : " + this.empId.ToString() + Environment.NewLine;
        }

        public static void PrintNextEmpID(ref string message)
        {
            message += "Next Employee ID : " + nextEmpid.ToString() + Environment.NewLine;
        }

        public static void PrintCompagny(ref string message)
        {
            message += "Compagny : " + company.ToString() + Environment.NewLine;
        }
    }

    /// <summary>
    /// Je sais pas trop pourquoi j'ai créé cette class je voulais libérer la mémoire mais
    /// ça marche pas comme ça, quand je rappelle le control et que je clique sur "Run" 
    /// le compteur ne cesse de s'incrémenter
    /// </summary>
    public class EmployeeDisposable : Employee, IDisposable
    {
        public void Dispose()
        {

        }
    }
}
