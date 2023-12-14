using QueChulosPerros.Shared.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QueChulosPerros.Server.Authentication
{
    public class UserAccountService
    {
        private List<UserAccount> _userAccountList;

        public async Task InitializeUserAccountsAsync()
        {
            using (HttpClient http = new HttpClient())
            {
                _userAccountList = await http.GetFromJsonAsync<List<UserAccount>>("api/Trabajadors");
            }
        }

        public UserAccount? GetUserAccountByUserName(string userName)
        {
            return _userAccountList?.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
