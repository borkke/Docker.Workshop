using System.Net.Http;
using System.Threading.Tasks;

namespace Notes.Services
{
    public class UserApiClient
    {
	    private readonly HttpClient _client;

	    public UserApiClient(HttpClient client)
	    {
		    _client = client;
	    }

	    public async Task<User> GetById(int id)
	    {
		    var response = await _client.GetAsync($"http://usersapi/api/users/{id}");
		    response.EnsureSuccessStatusCode();
		    return await response.Content.ReadAsAsync<User>();
		}
    }

	public class User
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Conuntry { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public string Number { get; set; }
	}
}
