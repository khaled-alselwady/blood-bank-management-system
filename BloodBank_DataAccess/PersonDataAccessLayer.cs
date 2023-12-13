using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BloodBank_DataAccessLayer_
{
    public class clsPersonDataAccessLayer
    {

        public static bool GetPersonInfo(int PersonID, ref string Name, ref byte Age, ref char Gender,
                                         ref string Phone, ref string Address, ref int BloodGroupID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Persons where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    Name = (string)reader["Name"];
                    Age = (byte)reader["Age"];
                    Gender = Convert.ToChar(reader["Gender"]);
                    BloodGroupID = (int)reader["BloodGroupID"];

                    // to handle the null columns
                    Phone = (reader["Phone"] != System.DBNull.Value) ? ((string)reader["Phone"]) : (string.Empty);
                    Address = (reader["Address"] != System.DBNull.Value) ? ((string)reader["Address"]) : (string.Empty);

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

        public static int AddNewPerson(string Name, byte Age, char Gender, string Phone, string Address, int BloodGroupID)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into Persons (Name, Age, Gender, Phone, Address,BloodGroupID)
                             values (@Name, @Age, @Gender, @Phone, @Address,@BloodGroupID);
                             select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Age", Age);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@BloodGroupID", BloodGroupID);

            // to handle the columns that allow null
            if (string.IsNullOrWhiteSpace(Phone))
            {
                command.Parameters.AddWithValue("@Phone", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Phone", Phone);
            }

            if (string.IsNullOrWhiteSpace(Address))
            {
                command.Parameters.AddWithValue("@Address", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Address", Address);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    PersonID = InsertID;
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

        public static bool UpdatePerson(int PersonID, string Name, byte Age, char Gender, string Phone,
                                        string Address, int BloodGroupID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"update Persons
                             set   Name = @Name,
                                   Age = @Age,
                                   Gender = @Gender,
                                   Phone = @Phone,
                                   Address = @Address,
                                   BloodGroupID = @BloodGroupID
                             where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Age", Age);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@BloodGroupID", BloodGroupID);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            // to handle the column that allows null
            if (string.IsNullOrWhiteSpace(Phone))
            {
                command.Parameters.AddWithValue("@Phone", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Phone", Phone);
            }

            if (string.IsNullOrWhiteSpace(Address))
            {
                command.Parameters.AddWithValue("@Address", System.DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Address", Address);
            }


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

        public static bool DeletePerson(int PersonID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete from Persons where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool IsPersonExists(int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from Persons where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

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
    }
}
