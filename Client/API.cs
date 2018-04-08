using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class APIClient
{
    private HttpClient client;

    public APIClient(string url)
    {
        this.client = new HttpClient();
        this.client.BaseAddress = new Uri(url);
        this.client.DefaultRequestHeaders.Accept.Clear();
        this.client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<T> GetObjectAsync<T>(string path)
    {
        T obj = default(T);
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            obj = await response.Content.ReadAsAsync<T>();
        }
        return obj;
    }
}

