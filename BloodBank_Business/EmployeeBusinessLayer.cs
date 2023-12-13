using BloodBank_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_BusinessLayer_
{
    public class clsEmployee
    {
        public enum enEmployeeMode { AddNew, Update };
        public enEmployeeMode _EmployeeMode = enEmployeeMode.AddNew;

        public int EmployeeID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public clsEmployee()
        {
            this.EmployeeID = -1;
            this.Username = string.Empty;
            this.Password = string.Empty;

            this._EmployeeMode = enEmployeeMode.AddNew;
        }

        private clsEmployee(int employeeID, string username, string password)
        {
            this.EmployeeID = employeeID;
            this.Username = username;
            this.Password = password;

            this._EmployeeMode = enEmployeeMode.Update;
        }

        private bool _AddNewEmployee()
        {
            this.EmployeeID = clsEmployeeDataAccessLayer.AddNewEmployee(this.Username, this.Password);

            return (this.EmployeeID != -1);
        }

        private bool _UpdateEmployee()
        {
            return clsEmployeeDataAccessLayer.UpdateEmployee(this.EmployeeID, this.Username, this.Password);
        }

        public static clsEmployee FindEmployee(int EmployeeID)
        {
            string Username = "", Password = "";

            if (clsEmployeeDataAccessLayer.GetEmployeeInfo(EmployeeID, ref Username, ref Password))
            {
                return new clsEmployee(EmployeeID, Username, Password);
            }
            else
            {
                return null;
            }
        }

        public static clsEmployee FindEmployee(string Username)
        {
            int EmployeeID = -1;
            string Password = "";

            if (clsEmployeeDataAccessLayer.GetEmployeeInfoByUsername(Username, ref Password, ref EmployeeID))
            {
                return new clsEmployee(EmployeeID, Username, Password);
            }
            else
            {
                return null;
            }
        }

        public static clsEmployee FindEmployee(string Username, string Password)
        {
            int EmployeeID = -1;

            if (clsEmployeeDataAccessLayer.GetEmployeeInfoByUsernameAndPassword(Username, Password, ref EmployeeID))
            {
                return new clsEmployee(EmployeeID, Username, Password);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch (this._EmployeeMode)
            {
                case enEmployeeMode.AddNew:
                    return _AddNewEmployee();

                case enEmployeeMode.Update:
                    return _UpdateEmployee();
            }

            return false;
        }

        public static bool DeleteEmployee(int EmployeeID)
        {
            return clsEmployeeDataAccessLayer.DeleteEmployee(EmployeeID);
        }

        public static bool IsEmployeeExists(int EmployeeID)
        {
            return clsEmployeeDataAccessLayer.IsEmployeeExists(EmployeeID);
        }

        public static bool IsEmployeeExists(string Username)
        {
            return clsEmployeeDataAccessLayer.IsEmployeeExists(Username);
        }

        public static bool IsEmployeeExists(string Username, string Password)
        {
            return clsEmployeeDataAccessLayer.IsEmployeeExists(Username, Password);
        }

        public static int GetTotalEmployees()
        {
            return clsEmployeeDataAccessLayer.GetTotalEmployees();
        }

        public static DataView GetAllEmployees()
        {
            return clsEmployeeDataAccessLayer.GetAllEmployees();
        }

        public static DataView SearchEmployeesContainByEmployeeID(string Contain)
        {
            return clsEmployeeDataAccessLayer.SearchEmployeesContainByEmployeeID(Contain);
        }

        public static DataView SearchEmployeesContainByUsername(string Contain)
        {
            return clsEmployeeDataAccessLayer.SearchEmployeesContainByUsername(Contain);
        }


    }
}
