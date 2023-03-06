using Dapper;
using DataAccess.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess;
public class DepartmentRepository
{
    private readonly SqlConnection _connection;

    public DepartmentRepository(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
    }

    public async Task<int> CreateDepartment(string DName, int MgrSSN)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@DName", DName);
        parameters.Add("@MgrSSN", MgrSSN);
        parameters.Add("@NewDeptID", dbType: DbType.Int32, direction: ParameterDirection.Output);

        await _connection.ExecuteAsync("usp_CreateDepartment", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("@NewDeptID");
    }


    public async Task UpdateDepartmentName(int DNumber, string DName)
    {
        await _connection.ExecuteAsync("usp_UpdateDepartmentName", new { DNumber, DName }, commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateDepartmentManager(int DNumber, int MgrSSN)
    {
        await _connection.ExecuteAsync("usp_UpdateDepartmentManager", new { DNumber, MgrSSN }, commandType: CommandType.StoredProcedure);
    }


    public async Task DeleteDepartment(int DNumber)
    {
        await _connection.ExecuteAsync("usp_DeleteDepartment", new { DNumber }, commandType: CommandType.StoredProcedure);
    }

    public async Task<Department> GetDepartment(int DNumber)
    {
        return await _connection.QuerySingleOrDefaultAsync<Department>("usp_GetDepartment", new { DNumber }, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<Department>> GetAllDepartments()
    {
        return await _connection.QueryAsync<Department>("usp_GetAllDepartments", commandType: CommandType.StoredProcedure);
    }
}
