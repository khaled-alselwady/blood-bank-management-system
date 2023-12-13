using BloodBank_DataAccessLayer_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_BusinessLayer_
{
    public class clsTransfer
    {
        public int TransferID { get; set; }
        public int PatientID { get; set; }
        public string BloodGroupName { get; set; }
        public DateTime TransferDate { get; set; }

        public clsTransfer()
        {
            this.TransferID = -1;
            this.PatientID = -1;
            this.BloodGroupName = string.Empty;
            this.TransferDate = DateTime.MinValue;
        }

        private clsTransfer(int transferID, int patientID, string bloodGroupName, DateTime transferDate)
        {
            this.TransferID = transferID;
            this.PatientID = patientID;
            this.BloodGroupName = bloodGroupName;
            this.TransferDate = transferDate;
        }

        private bool _AddNewTransfer()
        {
            this.TransferID = clsTransferDataAccessLayer.AddNewTransfer(this.PatientID,this.BloodGroupName,
                                                                        this.TransferDate);

            return (this.TransferID != -1);
        }

        public bool Save()
        {
            return _AddNewTransfer();
        }

        public static int GetTotalTransfers()
        {
            return clsTransferDataAccessLayer.GetTotalTransfers();
        }

        public static DataView GetAllTransfer()
        {
            return clsTransferDataAccessLayer.GetAllTransfer();
        }

    }
}
