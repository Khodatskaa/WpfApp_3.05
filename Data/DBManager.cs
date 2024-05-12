using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DBManager
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"; 

        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error executing query: " + ex.Message);
                }
            }

            return dt;
        }

        public DataTable GetAllProducts()
        {
            string query = "SELECT * FROM Products";
            return ExecuteQuery(query);
        }

        public DataTable GetAllSuppliers()
        {
            string query = "SELECT * FROM Suppliers";
            return ExecuteQuery(query);
        }

        public DataTable GetProductDetails()
        {
            string query = "SELECT p.ProductName, p.ProductType, s.SupplierName, s.SupplierLocation, p.Quantity, p.CostPrice, p.DeliveryDate " +
                           "FROM Products p " +
                           "INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID";
            return ExecuteQuery(query);
        }

        public DataTable GetProductsByType(string type)
        {
            string query = $"SELECT * FROM Products WHERE ProductType = '{type}'";
            return ExecuteQuery(query);
        }

        public DataTable GetProductsBySupplier(int supplierID)
        {
            string query = $"SELECT * FROM Products WHERE SupplierID = {supplierID}";
            return ExecuteQuery(query);
        }

        public DataTable GetProductWithHighestCost()
        {
            string query = "SELECT TOP 1 * FROM Products ORDER BY CostPrice DESC";
            return ExecuteQuery(query);
        }

        public DataTable GetProductWithLowestQuantity()
        {
            string query = "SELECT TOP 1 * FROM Products ORDER BY Quantity ASC";
            return ExecuteQuery(query);
        }

        public DataTable ExecuteCustomQuery(string customQuery)
        {
            return ExecuteQuery(customQuery);
        }
    }
}
