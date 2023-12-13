using BloodBank_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_BusinessLayer_
{
    public class clsPatient : clsPerson
    {
        public enum enPatientMode { AddNew, Update };
        public enPatientMode _PatientMode = enPatientMode.AddNew;

        private static clsPerson _Person;

        public int PatientID { get; set; }

        public clsPatient() : base()
        {
            this.PatientID = -1;
            this._PatientMode = enPatientMode.AddNew;
            base._PersonMode = enPersonMode.AddNew;
        }

        private clsPatient(int PatientID, int personID, string name, byte age,
                           char gender, string phone, string address, int bloodGroupID) :
                           base(personID, name, age, gender, phone, address, bloodGroupID)
        {
            this.PatientID = PatientID;
            this._PatientMode = enPatientMode.Update;
            base._PersonMode = clsPerson.enPersonMode.Update;
        }

        private bool _AddNewPatient()
        {
            if (base.Save())
            {
                this.PatientID = clsPatientDataAccessLayer.AddNewPatient(base.PersonID);
            }

            return (this.PatientID != -1);
        }

        private bool _UpdatePatient()
        {
            return base.Save();
        }

        private static int _GetPersonIDByPatientID(int PatientID)
        {
            return clsPatientDataAccessLayer.GetPersonIDByPatientID(PatientID);
        }

        public static clsPatient FindPatient(int PatientID)
        {
            int PersonID = -1;

            if (clsPatientDataAccessLayer.GetPatientInfo(PatientID, ref PersonID))
            {
                _Person = clsPerson.FindPerson(PersonID);

                if (_Person != null)
                {
                    return new clsPatient(PatientID, _Person.PersonID, _Person.Name, _Person.Age, _Person.Gender,
                                          _Person.Phone, _Person.Address, _Person.BloodGroupID);
                }
            }

            return null;
        }

        public override bool Save()
        {
            switch (this._PatientMode)
            {
                case enPatientMode.AddNew:
                    return _AddNewPatient();

                case enPatientMode.Update:
                    return _UpdatePatient();
            }

            return false;
        }

        public static bool DeletePatient(int PatientID)
        {
            int PersonID = _GetPersonIDByPatientID(PatientID);

            if (clsPatientDataAccessLayer.DeletePatient(PatientID))
            {
                return clsPerson.DeletePerson(PersonID);
            }

            return false;
        }

        public static bool IsPatientExists(int PatientID)
        {
            return clsPatientDataAccessLayer.IsPatientExists(PatientID);
        }

        public static int GetTotalPatients()
        {
            return clsPatientDataAccessLayer.GetTotalPatients();
        }

        public static DataView GetAllPatient()
        {
            return clsPatientDataAccessLayer.GetAllPatients();
        }

        public static DataView SearchPatientsContainByPatientID(string Contain, string BloodGroupName)
        {
            return clsPatientDataAccessLayer.SearchPatientsContainByPatientID(Contain, BloodGroupName);
        }

        public static DataView SearchPatientsContainByPatientName(string Contain, string BloodGroupName)
        {
            return clsPatientDataAccessLayer.SearchPatientsContainByPatientName(Contain, BloodGroupName);
        }

        public static DataView GetAllPatientsWithSpecificBloodGroup(string BloodGroupName)
        {
            return clsPatientDataAccessLayer.GetAllPatientsWithSpecificBloodGroup(BloodGroupName);
        }

    }
}
