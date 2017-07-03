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
				new Item { Id = Guid.NewGuid().ToString(), Ingredients = "Buy some cat food", Method="jemoeder", Image=1, IsVegetarian=1, Recom=0, Imagedata="http://ichef.bbci.co.uk/food/ic/food_16x9_448/recipes/aclassicspongecakewi_9406_16x9.jpg", Serves="Serves 8", Title="Test", Length=1, Preptimemin=30, Cookinmin=50, Favourite=0},
                new Item { Id = Guid.NewGuid().ToString(), Ingredients = "[' 350g/12oz penne pasta ', ' 2 x 80g/3oz packs Parma ham, snipped into small pieces', ' 250g/9oz small brown chestnut mushrooms, halved or quartered', ' ", Method="['Cook the pasta in a pan of boiling salted water according to the packet instructions. Drain and set aside', 'Heat a frying pan until hot. Add the pieces of Parma ham ", Image=1, IsVegetarian=0, Recom=0, Imagedata="http://bloemennederland.nl/wp-content/uploads/2009/10/Zonnebloemen-300x180.jpg", Serves="Serves 6", Title="15 minute pasta", Length=9, Preptimemin=30, Cookinmin=30, Favourite=0},
                new Item { Id = Guid.NewGuid().ToString(), Ingredients = "[' 350g/12oz penne pasta ', ' 2 x 80g/3oz packs Parma ham, snipped into small pieces', ' 250g/9oz small brown chestnut mushrooms, halved or quartered', ' ", Method="['Cook the pasta in a pan of boiling salted water according to the packet instructions. Drain and set aside', 'Heat a frying pan until hot. Add the pieces of Parma ham ", Image=1, IsVegetarian=1, Recom=0, Imagedata="http://ichef.bbci.co.uk/food/ic/food_16x9_448/recipes/aclassicspongecakewi_9406_16x9.jpg", Serves="Serves 6", Title="15 minute pasta", Length=9, Preptimemin=30, Cookinmin=30, Favourite=0},
				//new Item { Id = Guid.NewGuid().ToString(), Text = "Buy some new candles", Description="Pine and cranberry for that winter feel"},
				//new Item { Id = Guid.NewGuid().ToString(), Text = "Complete holiday shopping", Description="Keep it a secret!"},
				//new Item { Id = Guid.NewGuid().ToString(), Text = "Finish a todo list", Description="Done"},
                //new Item { Id = Guid.NewGuid().ToString(), Text = "ManManMan", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."},
            };

			foreach (Item item in _items)
			{
				items.Add(item);
			}

			isInitialized = true;
		}
	}
}
