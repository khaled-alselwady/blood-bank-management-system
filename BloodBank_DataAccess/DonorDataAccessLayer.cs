using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_DataAccessLayer_
{
    public class clsDonorDataAccessLayer
    {
        public static bool GetDonorInfo(int DonorID, ref int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Donors where DonorID = @DonorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DonorID", DonorID);

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

        public static int GetPersonIDByDonorID(int DonorID)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select PersonID from Donors where DonorID = @DonorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DonorID", DonorID);

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

        public static int AddNewDonor(int PersonID)
        {
            int DonorID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into Donors (PersonID)
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
                    DonorID = insertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return DonorID;
        }

        public static bool DeleteDonor(int DonorID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete from Donors where DonorID = @DonorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DonorID", DonorID);

            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (AffectedRows > 0);
        }

        public static bool IsDonorExists(int DonorID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from Donors where DonorID = @DonorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DonorID", DonorID);

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

        public static int GetTotalDonors()
        {
            int totalTransfers = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select count(*) from Donors";

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

        public static DataView GetAllDonors()
        {
            DataTable dtDonors = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select Donors.DonorID, Persons.Name, Persons.Age,
                             case 
                             	 when Persons.Gender = 'M' then 'Male'
                             	 when Persons.Gender = 'F' then 'Female'
                             end as Gender
                             , Persons.Phone, Persons.Address, BloodGroups.BloodGroupName
                             from Donors
                             inner join Persons on Persons.PersonID = Donors.PersonID
                             inner join BloodGroups on BloodGroups.BloodGroupID = Persons.BloodGroupID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtDonors.Load(reader);
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

            return dtDonors.DefaultView;
        }

        public static DataView SearchDonorsContainByDonorID(string Contain, string BloodGroupName)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                    select Donors.DonorID, Persons.Name, Persons.Age,
                                    case 
                                    	 when Persons.Gender = 'M' then 'Male'
                                    	 when Persons.Gender = 'F' then 'Female'
                                    end as Gender
                                    , Persons.Phone, Persons.Address, BloodGroups.BloodGroupName
                                    from Donors
                                    inner join Persons on Persons.PersonID = Donors.PersonID
                                    inner join BloodGroups on BloodGroups.BloodGroupID = Persons.BloodGroupID
                                    where (Donors.DonorID) LIKE @Contain + '%'
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

        public static DataView SearchDonorsContainByDonorName(string Contain, string BloodGroupName)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT subQuery.*
                             FROM (
                                    select Donors.DonorID, Persons.Name, Persons.Age,
                                    case 
                                    	 when Persons.Gender = 'M' then 'Male'
                                    	 when Persons.Gender = 'F' then 'Female'
                                    end as Gender
                                    , Persons.Phone, Persons.Address, BloodGroups.BloodGroupName
                                    from Donors
                                    inner join Persons on Persons.PersonID = Donors.PersonID
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

        public static DataView GetAllDonorsWithSpecificBloodGroup(string BloodGroupName)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select Donors.DonorID, Persons.Name, Persons.Age,
                             case 
                             	 when Persons.Gender = 'M' then 'Male'
                             	 when Persons.Gender = 'F' then 'Female'
                             end as Gender
                             , Persons.Phone, Persons.Address, BloodGroups.BloodGroupName
                             from Donors
                             inner join Persons on Persons.PersonID = Donors.PersonID
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
