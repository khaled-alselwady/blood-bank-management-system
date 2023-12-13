using BloodBank_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_BusinessLayer_
{
    public class clsDonor : clsPerson
    {
        public enum enDonorMode { AddNew, Update };
        public enDonorMode _DonorMode = enDonorMode.AddNew;

        private static clsPerson _Person;

        public int DonorID { get; set; }

        public clsDonor() : base()
        {
            this.DonorID = -1;
            this._DonorMode = enDonorMode.AddNew;
            base._PersonMode = clsPerson.enPersonMode.AddNew;
        }

        private clsDonor(int DonorID, int personID, string name, byte age, char gender,
                         string phone, string address, int bloodGroupID) :
                         base(personID, name, age, gender, phone, address, bloodGroupID)
        {
            this.DonorID = DonorID;
            this._DonorMode = enDonorMode.Update;
            base._PersonMode = clsPerson.enPersonMode.Update;
        }

        private bool _AddNewDonor()
        {
            if (base.Save())
            {
                this.DonorID = clsDonorDataAccessLayer.AddNewDonor(base.PersonID);
            }

            return (this.DonorID != -1);
        }

        private bool _UpdateDonor()
        {
            return base.Save();
        }

        private static int _GetPersonIDByDonorID(int DonorID)
        {
            return clsDonorDataAccessLayer.GetPersonIDByDonorID(DonorID);
        }

        public static clsDonor FindDonor(int DonorID)
        {
            int PersonID = -1;

            if (clsDonorDataAccessLayer.GetDonorInfo(DonorID, ref PersonID))
            {
                _Person = clsPerson.FindPerson(PersonID);

                if (_Person != null)
                {
                    return new clsDonor(DonorID, _Person.PersonID, _Person.Name, _Person.Age, _Person.Gender,
                                        _Person.Phone, _Person.Address, _Person.BloodGroupID);
                }
            }

            return null;
        }

        public override bool Save()
        {
            switch (this._DonorMode)
            {
                case enDonorMode.AddNew:
                    return _AddNewDonor();

                case enDonorMode.Update:
                    return _UpdateDonor();
            }

            return false;
        }

        public static bool DeleteDonor(int DonorID)
        {

            int PersonID = _GetPersonIDByDonorID(DonorID);

            if (clsDonorDataAccessLayer.DeleteDonor(DonorID))
            {
                return clsPerson.DeletePerson(PersonID);
            }

            return false;
        }

        public static bool IsDonorExists(int DonorID)
        {
            return clsDonorDataAccessLayer.IsDonorExists(DonorID);
        }

        public static int GetTotalDonors()
        {
            return clsDonorDataAccessLayer.GetTotalDonors();
        }

        public static DataView GetAllDonors()
        {
            return clsDonorDataAccessLayer.GetAllDonors();
        }

        public static DataView SearchDonorsContainByDonorID(string Contain, string BloodGroupName)
        {
            return clsDonorDataAccessLayer.SearchDonorsContainByDonorID(Contain, BloodGroupName);
        }

        public static DataView SearchDonorsContainByDonorName(string Contain, string BloodGroupName)
        {
            return clsDonorDataAccessLayer.SearchDonorsContainByDonorName(Contain, BloodGroupName);
        }

        public static DataView GetAllDonorsWithSpecificBloodGroup(string BloodGroupName)
        {
            return clsDonorDataAccessLayer.GetAllDonorsWithSpecificBloodGroup(BloodGroupName);
        }
    }
}
