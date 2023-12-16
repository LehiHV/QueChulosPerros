    using QueChulosPerros.Server.Authentication;
using QueChulosPerros.Shared.Model;

public class UserAccountService
{
    private List<UserAccount> _userAccountList;
    private List<Trabajador> trabajadorList;
    HttpClient http = new HttpClient();

    public async Task InitializeUserAccountsAsync()
    {
        trabajadorList = await http.GetFromJsonAsync<List<Trabajador>>("https://localhost:7184/api/Trabajadors");
        _userAccountList = trabajadorList.Select(t => new UserAccount { UserName = t.Name, Password = t.Password, Role = (bool)t.Admin ? "Administrador" : "Trabajador", Branch = t.Branch }).ToList();
    }

    public async Task<UserAccount?> GetUserAccountByUserName(string userName)
    {
        if (_userAccountList == null)
        {
            await InitializeUserAccountsAsync();
        }

        return _userAccountList?.FirstOrDefault(x => x.UserName == userName);
    }
}
