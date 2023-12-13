using BloodBank_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_BusinessLayer_
{
    public class clsPerson
    {

        public enum enPersonMode { AddNew, Update };
        public enPersonMode _PersonMode = enPersonMode.AddNew;

        public int PersonID { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public char Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int BloodGroupID { get; set; }

        public clsPerson()
        {
            this.PersonID = -1;
            this.Name = string.Empty;
            this.Age = 0;
            this.Gender = Char.MinValue;
            this.Phone = string.Empty;
            this.Address = string.Empty;
            this.BloodGroupID = -1;

            this._PersonMode = enPersonMode.AddNew;
        }

        protected clsPerson(int personID, string name, byte age, char gender,
                            string phone, string address, int bloodGroupID)
        {
            this.PersonID = personID;
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            this.Phone = phone;
            this.Address = address;
            this.BloodGroupID = bloodGroupID;

            this._PersonMode = enPersonMode.Update;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonDataAccessLayer.AddNewPerson(this.Name, this.Age, this.Gender, this.Phone,
                                                                  this.Address, this.BloodGroupID);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPersonDataAccessLayer.UpdatePerson(this.PersonID, this.Name, this.Age, this.Gender,
                                                         this.Phone, this.Address, this.BloodGroupID);
        }

        public static clsPerson FindPerson(int personID)
        {
            string Name = "", Phone = "", Address = "";
            byte Age = 0;
            char Gender = Char.MinValue;
            int BloodGroupID = -1;

            if (clsPersonDataAccessLayer.GetPersonInfo(personID, ref Name, ref Age, ref Gender,
                                                       ref Phone, ref Address, ref BloodGroupID))
            {
                return new clsPerson(personID, Name, Age, Gender, Phone, Address, BloodGroupID);
            }
            else
            {
                return null;
            }

        }

        public virtual bool Save()
        {
            switch (this._PersonMode)
            {

                case enPersonMode.AddNew:
                    return _AddNewPerson();

                case enPersonMode.Update:
                    return _UpdatePerson();
            }

            return false;
        }

        public static bool DeletePerson(int personID)
        {
            return clsPersonDataAccessLayer.DeletePerson(personID);
        }

        public static bool IsPersonExists(int personID)
        {
            return clsPersonDataAccessLayer.IsPersonExists(personID);
        }
    }
}
