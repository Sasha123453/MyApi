using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json.Linq;
using randomStringMyApi.Models;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace randomStringMyApi.Controllers
{
	[Route("api/strings/{id}")]
	[ApiController]
	public class StringsController : ControllerBase
	{
		[HttpGet]
		public string GetStrings(string id)
		{
			string[] targetStrings = id.Split("&"); 
			int count = int.Parse(Regex.Match(targetStrings[0], @"([0-9 ]+)").Value);
			int length = int.Parse(Regex.Match(targetStrings[1], @"([0-9 ]+)").Value);
			StringsModel model = new StringsModel(count, length);
			model.RandomString(count, length);
			string jsonString = JsonSerializer.Serialize(model);
			return jsonString;
		}
	}
}
