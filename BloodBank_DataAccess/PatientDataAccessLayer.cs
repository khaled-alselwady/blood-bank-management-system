using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_DataAccessLayer_
{
    public class clsPatientDataAccessLayer
    {
        public static bool GetPatientInfo(int PatientID, ref int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Patients where PatientID = @PatientID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                }
                else
                {
                    IsFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static int GetPersonIDByPatientID(int PatientID)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select PersonID from Patients where PatientID = @PatientID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    PersonID = ID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }

        public static int AddNewPatient(int PersonID)
        {
            int PatientID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into Patients (PersonID)
                             values (@PersonID)
                             select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertID))
                {
                    PatientID = insertID;
                }
            }
            catch (Exception ex)
            {

            }

            finally
            {
                connection.Close();
            }

            return PatientID;
        }

        public static bool DeletePatient(int PatientID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete from Patients where PatientID = @PatientID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (AffectedRows > 0);
        }

        public static bool IsPatientExists(int PatientID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from Patients where PatientID = @PatientID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static int GetTotalPatients()
        {
            int totalTransfers = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select count(*) from Patients";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int Total))
                {
                    totalTransfers = Total;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return totalTransfers;

        }

        public static DataView GetAllPatients()
        {
            DataTable dtPatients = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Patients.PatientID, Persons.Name, Persons.Age,
                             case 
                             	 when Persons.Gender = 'M' then 'Male'
                             	 when Persons.Gender = 'F' then 'Female'
                             end as Gender
                             , Persons.Phone, Persons.Address, BloodGroups.BloodGroupName
                             FROM  Patients 
                             INNER JOIN Persons ON Patients.PersonID = Persons.PersonID
                             INNER JOIN BloodGroups ON Persons.BloodGroupID = BloodGroups.BloodGroupID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtPatients.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dtPatients.DefaultView;
        }

        public static DataView SearchPatientsContainByPatientID(string Contain, string BloodGroupName)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                    select Patients.PatientID, Persons.Name, Persons.Age,
                                    case 
                                    	 when Persons.Gender = 'M' then 'Male'
                                    	 when Persons.Gender = 'F' then 'Female'
                                    end as Gender
                                    , Persons.Phone, Persons.Address, BloodGroups.BloodGroupName
                                    from Patients
                                    inner join Persons on Persons.PersonID = Patients.PersonID
                                    inner join BloodGroups on BloodGroups.BloodGroupID = Persons.BloodGroupID
                                    where (Patients.PatientID) LIKE @Contain + '%'
                                    and (@BloodGroupName = 'All' OR BloodGroups.BloodGroupName = @BloodGroupName)
                                  ) AS subQuery;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contain", Contain);
            command.Parameters.AddWithValue("@BloodGroupName", BloodGroupName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt.DefaultView;

        }

        public static DataView SearchPatientsContainByPatientName(string Contain, string BloodGroupName)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                    select Patients.PatientID, Persons.Name, Persons.Age,
                                    case 
                                    	 when Persons.Gender = 'M' then 'Male'
                                    	 when Persons.Gender = 'F' then 'Female'
                                    end as Gender
                                    , Persons.Phone, Persons.Address, BloodGroups.BloodGroupName
                                    from Patients
                                    inner join Persons on Persons.PersonID = Patients.PersonID
                                    inner join BloodGroups on BloodGroups.BloodGroupID = Persons.BloodGroupID
                                    where (Persons.Name) LIKE @Contain + '%'
                                    and (@BloodGroupName = 'All' OR BloodGroups.BloodGroupName = @BloodGroupName)
                                  ) AS subQuery;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contain", Contain);
            command.Parameters.AddWithValue("@BloodGroupName", BloodGroupName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt.DefaultView;

        }

        public static DataView GetAllPatientsWithSpecificBloodGroup(string BloodGroupName)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select Patients.PatientID, Persons.Name, Persons.Age,
                             case 
                             	 when Persons.Gender = 'M' then 'Male'
                             	 when Persons.Gender = 'F' then 'Female'
                             end as Gender
                             , Persons.Phone, Persons.Address, BloodGroups.BloodGroupName
                             from Patients
                             inner join Persons on Persons.PersonID = Patients.PersonID
                             inner join BloodGroups on BloodGroups.BloodGroupID = Persons.BloodGroupID
                             where BloodGroups.BloodGroupName = @BloodGroupName";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BloodGroupName", BloodGroupName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt.DefaultView;
        }

    }
}
