using System;

namespace randomStringMyApi.Models
{
	public class StringsModel
	{
		public string[] Strings { get; set; }
		public int Count { get; set; }
		public int Length { get; set; }
		public StringsModel(int count, int length)
		{
			Count = count;
			Length = length;
			Strings = new string[count];
		}
		public void RandomString(int count, int length)
		{
			Random random= new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			for (int i = 0; i < count; i++)
			{
				string k = new string(Enumerable.Repeat(chars, length)
				.Select(s => s[random.Next(s.Length)]).ToArray());
				Strings[i] = k;
			}
		}
	}
}
