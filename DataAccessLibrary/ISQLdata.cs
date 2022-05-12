
namespace DataAccessLibrary
{
    public interface ISQLdata
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task SavaData<T>(string sql, T parameters);
    }
}