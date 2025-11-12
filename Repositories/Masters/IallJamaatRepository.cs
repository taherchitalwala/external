using alvazaratAPI53.Models.Masters;

namespace alvazaratAPI53.Repositories.Masters
{
    public interface IallJamaatRepository 
    {
        Task<IEnumerable<allJamaatList>> GetAllJamaats(string? param1 = null);
        //test
    }
}
