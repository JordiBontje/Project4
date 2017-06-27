using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App2.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(App2.Services.MockDataStore))]
namespace App2.Services
{
	public class MockDataStore : IDataStore<Item>
	{
		bool isInitialized;
		List<Item> items;

		public async Task<bool> AddItemAsync(Item item)
		{
			await InitializeAsync();

			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			await InitializeAsync();

			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(Item item)
		{
			await InitializeAsync();

			var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(_item);

			return await Task.FromResult(true);
		}

		public async Task<Item> GetItemAsync(string id)
		{
			await InitializeAsync();

			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			await InitializeAsync();

			return await Task.FromResult(items);
		}

		public Task<bool> PullLatestAsync()
		{
			return Task.FromResult(true);
		}


		public Task<bool> SyncAsync()
		{
			return Task.FromResult(true);
		}

		public async Task InitializeAsync()
		{
			if (isInitialized)
				return;

			items = new List<Item>();
			var _items = new List<Item>
			{
				new Item { Id = Guid.NewGuid().ToString(), Text = "Buy some cat food", Description="The cats are hungry"},
				new Item { Id = Guid.NewGuid().ToString(), Text = "Learn F#", Description="Seems like a functional idea"},
				new Item { Id = Guid.NewGuid().ToString(), Text = "Learn to play guitar", Description="Noted"},
				new Item { Id = Guid.NewGuid().ToString(), Text = "Buy some new candles", Description="Pine and cranberry for that winter feel"},
				new Item { Id = Guid.NewGuid().ToString(), Text = "Complete holiday shopping", Description="Keep it a secret!"},
				new Item { Id = Guid.NewGuid().ToString(), Text = "Finish a todo list", Description="Done"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "ManManMan", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."},
            };

			foreach (Item item in _items)
			{
				items.Add(item);
			}

			isInitialized = true;
		}
	}
}
