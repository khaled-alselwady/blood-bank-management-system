using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank_DataAccessLayer_
{
    public class clsBloodGroupDataAccessLayer
    {
        public static bool GetBloodGroupInfo(int BloodGroupID, ref string BloodGroupName, ref int QuantityInStock)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from BloodGroups where BloodGroupID = @BloodGroupID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BloodGroupID", BloodGroupID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    BloodGroupName = (string)reader["BloodGroupName"];
                    QuantityInStock = (int)reader["QuantityInStock"];
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

        public static bool GetBloodGroupInfo(string BloodGroupName, ref int BloodGroupID, ref int QuantityInStock)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from BloodGroups where BloodGroupName = @BloodGroupName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BloodGroupName", BloodGroupName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    BloodGroupID = (int)reader["BloodGroupID"];
                    QuantityInStock = (int)reader["QuantityInStock"];
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

        public static bool UpdateQuantity(int BloodGroupID, int QuantityInStock)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"update BloodGroups
                             set QuantityInStock = @QuantityInStock
                             where BloodGroupID = @BloodGroupID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@QuantityInStock", QuantityInStock);
            command.Parameters.AddWithValue("@BloodGroupID", BloodGroupID);

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

        public static DataView GetAllBloodGroups()
        {
            DataTable dtBloodGroups = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from BloodGroups";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtBloodGroups.Load(reader);
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

            return dtBloodGroups.DefaultView;
        }

        public static DataView GetSpecificBloodGroup(string BloodGroupName)
        {
            DataTable dtBloodGroups = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from BloodGroups where BloodGroupName = @BloodGroupName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BloodGroupName", BloodGroupName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtBloodGroups.Load(reader);
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

            return dtBloodGroups.DefaultView;
        }

    }
}
