using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingCare.Components.Services.StorageService
{
    public interface IStorageService
    {
        public Task<T?> GetValue<T>(string key);
        public Task SetValue<T>(string key, T value);
        public Task ClearValue(string key);
        public Task Clear();
    }
}
