using QueChulosPerros.Shared.Model;

namespace QueChulosPerros.Server.Authentication
{
    public class UserAccountService
    {
        private List<UserAccount> _userAccountList;

        public UserAccountService()
        {
            _userAccountList = new List<UserAccount>
        {
            new UserAccount{ UserName = "admin", Password = "admin", Role = "Administrator", Branch = Branch.Ambos },
            new UserAccount{ UserName = "worker1", Password = "worker1", Role = "Trabajador", Branch = Branch.Tecomán },
            new UserAccount{ UserName = "worker2", Password = "worker2", Role = "Trabajador", Branch = Branch.Villa_de_Álvarez }

        };
        }

        public UserAccount? GetUserAccountByUserName(string userName)
        {
            return _userAccountList.FirstOrDefault(x => x.UserName == userName);
        }        
    }
}
