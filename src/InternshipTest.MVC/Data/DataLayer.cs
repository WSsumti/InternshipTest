using InternshipTest.MVC.Models;
using System.Data.SqlClient;

namespace InternshipTest.MVC.Data
{
    public class DataLayer : IDataLayer
    {
        private readonly IConfiguration _configuration;
        public DataLayer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void CreateSale(Sale sale)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                SqlCommand sqlCommand = new SqlCommand("CreateSale", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@WorkOrder", sale.WorkOrder);
                sqlCommand.Parameters.AddWithValue("@OrderQuantity", sale.OrderQuantity);
                sqlCommand.Parameters.AddWithValue("@SalesOrder", sale.SalesOrder);
                sqlCommand.Parameters.AddWithValue("@ProductID", sale.ProductID);
                sqlCommand.Parameters.AddWithValue("@OrderStatus", sale.OrderStatus);
                sqlCommand.Parameters.AddWithValue("@ProductDescription", sale.ProductDescription);
                sqlCommand.Parameters.AddWithValue("@SalesOrderItem", sale.SalesOrderItem);
                sqlCommand.Parameters.AddWithValue("@Timestamp", sale.Timestamp);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteSale(string salesOrder)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                SqlCommand sqlCommand = new SqlCommand("DeleteSale", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@SalesOrder", salesOrder);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public IEnumerable<Sale> GetAllSales()
        {
            var retrieveSale = new List<Sale>();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                SqlCommand sqlCommand = new SqlCommand("ViewAllSale", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Sale sale = new Sale()
                    {
                        WorkOrder = reader["WorkOrder"].ToString(),
                        OrderQuantity = Convert.ToDecimal(reader["OrderQuantity"]),
                        SalesOrder = reader["SalesOrder"].ToString(),
                        ProductID = reader["ProductID"].ToString(),
                        OrderStatus = reader["OrderStatus"].ToString(),
                        ProductDescription = reader["ProductDescription"].ToString(),
                        SalesOrderItem = reader["SalesOrderItem"].ToString(),
                        Timestamp = Convert.ToDateTime(reader["Timestamp"]),
                    };
                    retrieveSale.Add(sale);
                }
                connection.Close();
            }
            return retrieveSale;
        }

        public Sale GetSaleByID(string salesOrder)
        {
            var returnSale = new Sale();
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {

                SqlCommand sqlCommand = new SqlCommand("GetSaleByID", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SalesOrder", salesOrder);
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Sale sale = new Sale()
                    {
                        WorkOrder = reader["WorkOrder"].ToString(),
                        OrderQuantity = Convert.ToDecimal(reader["OrderQuantity"]),
                        SalesOrder = reader["SalesOrder"].ToString(),
                        ProductID = reader["ProductID"].ToString(),
                        OrderStatus = reader["OrderStatus"].ToString(),
                        ProductDescription = reader["ProductDescription"].ToString(),
                        SalesOrderItem = reader["SalesOrderItem"].ToString(),
                        Timestamp = Convert.ToDateTime(reader["Timestamp"]),
                    };
                    returnSale = sale;
                }
                connection.Close();
            }
            return returnSale;
        }

        public void UpdateSale(Sale sale)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                SqlCommand sqlCommand = new SqlCommand("UpdateSale", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@WorkOrder", sale.WorkOrder);
                sqlCommand.Parameters.AddWithValue("@OrderQuantity", sale.OrderQuantity);
                sqlCommand.Parameters.AddWithValue("@SalesOrder", sale.SalesOrder);
                sqlCommand.Parameters.AddWithValue("@ProductID", sale.ProductID);
                sqlCommand.Parameters.AddWithValue("@OrderStatus", sale.OrderStatus);
                sqlCommand.Parameters.AddWithValue("@ProductDescription", sale.ProductDescription);
                sqlCommand.Parameters.AddWithValue("@SalesOrderItem", sale.SalesOrderItem);
                sqlCommand.Parameters.AddWithValue("@Timestamp", sale.Timestamp);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
