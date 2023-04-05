using Microsoft.AspNetCore.Mvc;
using randomStringMyApi.Models;

namespace randomStringMyApi.Controllers
{
	public class RandomController : Controller
	{
		public async Task<IActionResult> Index(int Count, int Length)
		{
			HttpClient client = new HttpClient();
			string baseString = $"https://localhost:7075/api/Strings/count={Count}&length={Length}";
			HttpResponseMessage response = await client.GetAsync(baseString);
			response.EnsureSuccessStatusCode();
			string responseBody = await response.Content.ReadAsStringAsync();
			StringsModel stringsModel = System.Text.Json.JsonSerializer.Deserialize<StringsModel>(responseBody)!;
			return View(stringsModel);
		}
	}
}
