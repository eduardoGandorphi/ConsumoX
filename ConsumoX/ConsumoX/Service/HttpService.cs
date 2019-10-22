using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoX.Service
{
    public class HttpService<T>
    {
        string BaseAdress;
        string ApiName;
        public HttpService(string baseAdress, string apiName)
        {
            this.BaseAdress = baseAdress;
            this.ApiName = apiName;
        }
        public async Task<T> Get(string numero)
        {
            var cliente = GetCliente();
            var retorno = await cliente.GetAsync(ApiName);
            var strRetorno = await retorno.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<T>(strRetorno);
            return obj;
        }
        public async Task<T> Post(T toPost)
        {
            var cliente = GetCliente();
            var toSend = new StringContent(JsonConvert.SerializeObject(toPost));
            var retorno = await cliente.PostAsync(ApiName, toSend);
            var strRetorno = await retorno.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<T>(strRetorno);
            return obj;
        }
        private HttpClient GetCliente()
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(BaseAdress);
            cliente.DefaultRequestHeaders.Accept.Add
                (new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue
                    ("application/json"));
            cliente.Timeout = new TimeSpan(10000);
            return cliente;
        }
    }
}
