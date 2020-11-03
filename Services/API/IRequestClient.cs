using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Services.API
{
    public interface IRequestClient
    {
        void AdicionarCookies(List<Cookie> cookies);
        T Get<T>(string url);
        T Get<T>(string url, List<KeyValuePair<string, object>> param = null);
        Task<T> GetAsync<T>(string url);
        T Post<T>(string url, List<KeyValuePair<string, object>> param);
        T Post<T>(string url, object param);
        Task<T> PostAsync<T>(string url, List<KeyValuePair<string, object>> param);
        Task<T> PostAsync<T>(string url, object param);
        T Put<T>(string url, List<KeyValuePair<string, object>> param);
        T Put<T>(string url, object param);
    }
}