using System.Data;

namespace ReadFile
{
    /// <summary>
    /// This Interface, exposes contract method to get collection of DataTable Type
    /// </summary>
    public interface IDataRepository
    {
        DataTable Get();
    }
}
