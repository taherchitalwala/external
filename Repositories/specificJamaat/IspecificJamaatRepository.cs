using alvazaratAPI53.Models.specificJamaat;

namespace alvazaratAPI53.Repositories.specificJamaat
{
    public interface IspecificJamaatRepository
    {
        Task<IEnumerable<specificJamaatList>> GetspecificJamaat(string? param1 = null);
    }
}
