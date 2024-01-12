using Insurance_management_system.Entity;
using Insurance_management_system.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_management_system.Dao
{
    class InsuranceManagementServiceImpl : IInsuranceManagementService
    {
        SqlConnection connection;
        public bool CreatePolicy(Policy policy)
        {
            bool result = false;
            try
            {
                using (connection = DBConnection.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand($"insert into policy values({policy.PolicyId},'{policy.policyNumber}','{policy.CoverageDetails}');", connection);
                    connection.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        result = true;
                        Console.WriteLine("successfully created");
                    }
                    else
                    {
                        Console.WriteLine("failed to create");
                    }
                }
            }

            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public List<Policy> GetPolicy(int policyId)
        {

            List<Policy> policies = new List<Policy>();
            using (connection = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"select*from Policy where policyId={policyId};";
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    policies.Add(new Policy()
                    {
                        PolicyId = (int)dr[0],
                        policyNumber = dr[1].ToString(),
                        CoverageDetails = dr[2].ToString()
                    });
                }
                dr.Close();
                return policies;

            }
        }





        public bool UpdatePolicy(int policyID, string details)
        {

            bool result = false;
            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {


                    using (SqlCommand cmd = new SqlCommand($"update policy set details='{details}' where policyId={policyID}", connection))
                    {
                        connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result = true;
                            Console.WriteLine("Update successful");
                        }
                        else
                        {
                            result = false;
                            Console.WriteLine("No rows affected. Policy not found");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error updating the incident status {ex.Message}");

            }
            return result;
        }

       

   public bool DeletePolicy(int policyId)
        {
            bool result = false;

            using (connection = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM Policy WHERE policyId = {policyId};", connection);
                connection.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    result = true;
                    Console.WriteLine("Successfully deleted");
                }
                else
                {
                    Console.WriteLine("Failed to delete");
                }
            }

            return result;
        }

        List<Policy> IInsuranceManagementService.GetAllPolicies()
        {
            List<Policy> policies = new List<Policy>();

            using (var connection = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Policy;", connection);
                try
                {
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            policies.Add(new Policy()
                            {
                                PolicyId = (int)dr["PolicyId"], 
                                policyNumber = dr["PolicyNumber"].ToString(),
                                CoverageDetails = dr["CoverageDetails"].ToString()
                            });
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                   
                }
            }

            return policies;
        }

    }
}
















