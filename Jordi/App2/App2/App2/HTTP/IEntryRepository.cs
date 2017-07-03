using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App2.HTTP
{
    public interface IEntryRepository
    {
        Task<IEnumerable<Entry>> TopEntriesAsync();
    }
}
