using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceManagementSystem.util;
using Insurance_management_system.Dao;
using Insurance_management_system.Entity;
using Insurance_management_system.Exception;


namespace Insurance_management_system.Main
{
    public class MainModule
    {
        static SqlConnection conn;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("Insurance Management System");
                Console.WriteLine("=======================================");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Update Policy");
                Console.WriteLine("2. Create Policy");
                Console.WriteLine("3. Get Policy");
                Console.WriteLine("4. Delete Policy");
                Console.WriteLine("5. Get all the policies");
                Console.WriteLine("6. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": UpdatePolicy();
                        break;
                    case "2": CreatePolicy();
                        break;
                    case "3":  GetPolicy();
                        break;
                    case "4": DeletePolicy();
                        break;
                    case "5": GetAllPolicies();
                        break;
                    case "6":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid selection, please try again.");
                        break;
                }
            }
        }
        public static void CreatePolicy()
        {
            try
            {
                IInsuranceManagementService insuranceManagementService = new InsuranceManagementServiceImpl();

                Console.WriteLine("enter the policy ID, policy number and policy Details");

                Policy policy = new Policy();

                policy.PolicyId = Convert.ToInt32(Console.ReadLine());

                policy.policyNumber = Console.ReadLine();

                policy.CoverageDetails = Console.ReadLine();

                insuranceManagementService.CreatePolicy(policy);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public static void DeletePolicy()
        {
            try
            {
                IInsuranceManagementService insuranceManagementService = new InsuranceManagementServiceImpl();
                Console.WriteLine("enter the policy Id ");
                Policy policy = new Policy();
                policy.PolicyId = Convert.ToInt32(Console.ReadLine());
                insuranceManagementService.DeletePolicy(policy.PolicyId);
            }
            catch (PolicyNotFoundException ex)
            {
                Console.WriteLine($"Policy not found: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        public static void GetPolicy()
        {
            try
            {
                IInsuranceManagementService insuranceManagementService = new InsuranceManagementServiceImpl();

                Console.WriteLine("Enter the policy ID:");

                int policyID = Convert.ToInt32(Console.ReadLine());

                List<Policy> policies = insuranceManagementService.GetPolicy(policyID);

                foreach (var policy in policies)
                {

                    Console.WriteLine($"policy ID: {policy.PolicyId}\npolicy number: {policy.policyNumber}\ndetails: {policy.CoverageDetails}");
                }
                if (policies.Count == 0)
                {
                    throw new PolicyNotFoundException("Policy not found");
                }
            }
            catch (PolicyNotFoundException ex)
            {
                Console.WriteLine($"Policy not found: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }



        public static void UpdatePolicy()
        {
            try
            {
                IInsuranceManagementService insurance = new InsuranceManagementServiceImpl();

                Console.WriteLine("enter the policy ID where you want to update");

                Policy policy = new Policy();

                policy.PolicyId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("enter the update for details");

                policy.CoverageDetails = Console.ReadLine().ToString();

                insurance.UpdatePolicy(policy.PolicyId, policy.CoverageDetails);
            }
            catch (PolicyNotFoundException ex)
            {
                Console.WriteLine($"Policy not found: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public static void GetAllPolicies()
        {
            try
            {
                IInsuranceManagementService insurance = new InsuranceManagementServiceImpl();
                List<Policy> policies = insurance.GetAllPolicies();

                if (policies != null && policies.Count > 0)
                {
                    foreach (Policy policy in policies)
                    {
                        Console.WriteLine($"PolicyId: {policy.PolicyId}, PolicyNumber: {policy.policyNumber}, CoverageDetails: {policy.CoverageDetails}");
                    }
                }
                else
                {
                    Console.WriteLine("No policies found.");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }



}


