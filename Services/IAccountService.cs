using System.Threading.Tasks;

namespace CodingProject
{
    public interface IAccountService
    {
        public Task<double> GetAccountAmount(int accountId);
    }
}