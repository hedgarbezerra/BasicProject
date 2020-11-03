using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.API
{
    public class RequestClient : IRequestClient
    {
        private readonly RestClient _client;
        public RequestClient()
        {
            this._client = new RestClient();
        }

        public RequestClient(string urlBase)
        {
            this._client = new RestClient(urlBase);
        }

        public T Get<T>(string url)
        {
            var request = new RestRequest(url, Method.GET, DataFormat.Json);

            var response = _client.Get<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço {response.ResponseUri}");
        }

        public T Post<T>(string url, object param)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddJsonBody(param);

            var response = _client.Post<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço {response.ResponseUri}");
        }

        public T Post<T>(string url, List<KeyValuePair<string, object>> param)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            //request.AddJsonBody(param);
            param.ForEach(p => request.AddParameter(p.Key, p.Value));

            var response = _client.Post<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço {response.ResponseUri}");
        }

        public T Put<T>(string url, object param)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddJsonBody(param);

            var response = _client.Put<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço {response.ResponseUri}");
        }

        public T Put<T>(string url, List<KeyValuePair<string, object>> param)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            //request.AddJsonBody(param);
            param.ForEach(p => request.AddParameter(p.Key, p.Value));

            var response = _client.Put<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço {response.ResponseUri}");
        }


        public T Get<T>(string url, List<KeyValuePair<string, object>> param = null)
        {
            var request = new RestRequest(url, Method.GET, DataFormat.Json);

            if (param != null)
            {
                param.ForEach(p => request.AddParameter(p.Key, p.Value, ParameterType.GetOrPost));
            }

            var response = _client.Get<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço {response.ResponseUri}");
        }


        public async Task<T> GetAsync<T>(string url)
        {
            var request = new RestRequest(url, Method.GET, DataFormat.Json);

            var response = await _client.ExecuteGetAsync<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço {response.ResponseUri}");
        }
        public async Task<T> PostAsync<T>(string url, object param)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddJsonBody(param);

            var response = await _client.ExecutePostAsync<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço {response.ResponseUri}");
        }
        public async Task<T> PostAsync<T>(string url, List<KeyValuePair<string, object>> param)
        {
            var request = new RestRequest(url, Method.POST, DataFormat.Json);

            param.ForEach(p => request.AddParameter(p.Key, p.Value));

            var response = await _client.ExecutePostAsync<T>(request);

            if (response.IsSuccessful)
            {
                return new JsonDeserializer().Deserialize<T>(response);
            }

            throw new Exception($"Houve um erro {response.StatusCode} ao tentar conectar ao endereço {response.ResponseUri}");
        }

        public void AdicionarCookies(List<Cookie> cookies)
        {
            this._client.CookieContainer = new CookieContainer();

            cookies.ForEach(cookie => this._client.CookieContainer.Add(cookie));
        }
    }
}
