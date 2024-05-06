using Backend.Helpers.Abstract;
using Backend.Models;
using Dapper;
using MySql.Data.MySqlClient;


namespace Backend.Helpers.Currency
{
    public class CurrencyManager : ConnectionManager
    {
        public CurrencyManager():base()
        {           
        }

        public List<DataCurrency> GetCurrencyActive()
        {
            try
            {
                var query = "SELECT * FROM tipo_moneda WHERE activo = 1;";
                List<DataCurrency> currency = new List<DataCurrency>();
                using(var connection = new MySqlConnection(DbConnection))
                {
                    currency = connection.Query<DataCurrency>(query).AsList();
                }
                return currency;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error obteniendo tipos de moneda de la db: {ex.Message}");
            }
        }
    }
}
