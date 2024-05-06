using Backend.Helpers.Abstract;
using Backend.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace Backend.Helpers.BranchOffices
{
    public class BranchOfficesManager : ConnectionManager
    {
        public BranchOfficesManager() : base()
        {

        }

        public List<DataBranchOffices> GetAllBranchOffices()
        {
            try
            {
                var query = "SELECT a.*, a.fecha_creacion as 'fechaCreacion', b.abreviatura as 'moneda', b.id as 'idMoneda' FROM sucursales a INNER JOIN tipo_moneda b ON a.id_tipo_moneda = b.id;";
                List<DataBranchOffices> response = new List<DataBranchOffices>();
                using (var connection = new MySqlConnection(DbConnection))
                {
                    response = connection.Query<DataBranchOffices>(query).AsList();
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error obteniendo sucursales: {ex.Message}");
            }
        }

        public string CreateBranchOfficeManager(DataBranchOffices branchOffice)
        {
            try
            {
                bool existCode = ExistCode(branchOffice.Codigo);
                if (existCode)
                    return "El código de la sucursal ya existe.";
                else
                {
                    var status = CreateBranchOffices(branchOffice);
                    if (status) 
                        return "Ok";
                    else 
                        return "Ocurrió un error creando la sucursal.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ExistCode(string code)
        {
            try
            {
                var query = $@"SELECT count(id ) FROM sucursales WHERE codigo='{code}';";
                using (var connection = new MySqlConnection(DbConnection))
                {
                    var response = connection.Query<int>(query).FirstOrDefault();
                    if (response > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error obteniendo sucursales: {ex.Message}");
            }
        }
        private bool CreateBranchOffices(DataBranchOffices branchOffice)
        {
            try
            {
                var query = $@"INSERT INTO sucursales VALUES (null, '{branchOffice.Codigo}', 
'{branchOffice.Moneda}','{branchOffice.Descripcion}', '{branchOffice.Direccion}', 
'{branchOffice.Identificacion}','{branchOffice.FechaCreacion.ToString("yyyy-MM-dd")}', now());";
                using (var connection = new MySqlConnection(DbConnection))
                {
                    var response = connection.Execute(query);
                    if (response > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error obteniendo sucursales: {ex.Message}");
            }
        }

        public bool DeleteOfficeManager(int id)
        {
            try
            {
                var query = $"DELETE FROM sucursales WHERE id = {id}";
                using (var connection = new MySqlConnection(DbConnection))
                {
                    var row = connection.Execute(query);
                    if(row > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateOfficeManager(DataBranchOffices branchOffice)
        {
            try
            {
                var query = $"UPDATE sucursales SET id_tipo_moneda='{branchOffice.IdMoneda}', descripcion='{branchOffice.Descripcion}', " +
                    $"direccion='{branchOffice.Direccion}',identificacion='{branchOffice.Identificacion}'" +
                    $" WHERE id = {branchOffice.Id};";
                using (var connection = new MySqlConnection(DbConnection))
                {
                    var row = connection.Execute(query);
                    if (row > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
