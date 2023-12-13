using BloodBank_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_BusinessLayer_
{
    public class clsBloodGroup
    {
        public int BloodGroupID { get; set; }
        public string BloodGroupName { get; set; }
        public int QuantityInStock { get; set; }

        public clsBloodGroup()
        {
            this.BloodGroupID = -1;
            this.BloodGroupName = string.Empty;
            this.QuantityInStock = 0;
        }

        private clsBloodGroup(int BloodGroupID, string BloodGroupName, int QuantityInStock)
        {
            this.BloodGroupID = BloodGroupID;
            this.BloodGroupName = BloodGroupName;
            this.QuantityInStock = QuantityInStock;
        }

        private bool _UpdateQuantity()
        {
            return clsBloodGroupDataAccessLayer.UpdateQuantity(this.BloodGroupID, this.QuantityInStock);
        }

        public static clsBloodGroup Find(int BloodGroupID)
        {
            string BloodGroupName = string.Empty;
            int QuantityInStock = 0;

            if (clsBloodGroupDataAccessLayer.GetBloodGroupInfo(BloodGroupID, ref BloodGroupName, ref QuantityInStock))
            {
                return new clsBloodGroup(BloodGroupID, BloodGroupName, QuantityInStock);
            }
            else
            {
                return null;
            }

        }

        public static clsBloodGroup Find(string BloodGroupName)
        {
            int BloodGroupID = -1, QuantityInStock = 0;

            if (clsBloodGroupDataAccessLayer.GetBloodGroupInfo(BloodGroupName, ref BloodGroupID, ref QuantityInStock))
            {
                return new clsBloodGroup(BloodGroupID, BloodGroupName, QuantityInStock);
            }
            else
            {
                return null;
            }

        }

        public bool Save()
        {
            return _UpdateQuantity();
        }

        public static DataView GetAllBloodGroups()
        {
            return clsBloodGroupDataAccessLayer.GetAllBloodGroups();
        }

        public static DataView GetSpecificBloodGroup(string BloodGroupName)
        {
            return clsBloodGroupDataAccessLayer.GetSpecificBloodGroup(BloodGroupName);
        }

    }
}
