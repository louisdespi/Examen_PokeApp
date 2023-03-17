namespace PokeApp2.Models
{
    public class ApiResource
    {
        [JsonIgnore]
        public PokeApiService ApiService { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public async Task<T> AquireTarget<T>()
        {
            T ret = await ApiService.GetObjAsync<T>(this);
            return ret;
        }
    }

    /*public class ApiResource<U>
    {
        [JsonIgnore]
        public PokeApiService ApiService { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public async Task<T> AquireTarget<T>()
        {
            T ret = await ApiService.GetObjAsync<T>(this);
            return ret;
        }
    }*/
}
