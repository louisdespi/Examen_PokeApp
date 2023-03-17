using System.Net.Http.Json;

namespace PokeApp2.Services
{
    public class PokeApiService
    {
        public enum EndPoints
        {
            VersionGroup,
            Version,
            Generation,
        }
        const string BASE_SEARCH_URL = "https://pokeapi.co/api/v2";
        HttpClient client;
        public PokeApiService()
        {
            this.client = new();
        }
        private async Task<Search> Search (EndPoints target, int offset = 0, int limit = 20)
        {
            string url = BASE_SEARCH_URL;
            switch (target)
            {
                case EndPoints.VersionGroup:
                    url += "/version-group";
                    break;
                case EndPoints.Version:
                    url += "/version";
                    break;
                case EndPoints.Generation:
                    url += "/generation";
                    break;
                default:
                    return null;
            }
            HttpResponseMessage searchResponse = (await client.GetAsync($"{url}?offset={offset}&limit={limit}"));
            if (!searchResponse.IsSuccessStatusCode) return null;
            Search search = (await searchResponse.Content.ReadFromJsonAsync<Search>());
            return search;
        }

        private async Task<List<T>> Search<T> (EndPoints target, int offset = 0, int limit = 20)
        {
            Search search = (await Search(target));
            if (search is null) return null;
            List<ApiResource> results = search.Results;
            List<T> ret = new List<T>();
            foreach (ApiResource result in results)
            {
                HttpResponseMessage searchResponse = (await client.GetAsync(result.Url));
                if (!searchResponse.IsSuccessStatusCode) return null;
                T obj = (await searchResponse.Content.ReadFromJsonAsync<T>());
                if (obj is null) return null;
                ret.Add(obj);
            }
            return ret;
        }

        public async Task<T> GetObjAsync<T>(ApiResource resource)
        {
            HttpResponseMessage searchResponse = (await client.GetAsync(resource.Url));
            if (!searchResponse.IsSuccessStatusCode) return default;
            T ObjResult = (await searchResponse.Content.ReadFromJsonAsync<T>());
            return ObjResult;
        }

        public async Task<List<T>> GetListObjAsync<T>(List<ApiResource> resources)
        {
            List<T> ret = new List<T>();
            foreach (ApiResource resource in resources)
            {
                HttpResponseMessage searchResponse = (await client.GetAsync(resource.Url));
                if (!searchResponse.IsSuccessStatusCode) continue;
                T ObjResult = (await searchResponse.Content.ReadFromJsonAsync<T>());
                if (ObjResult is null) continue;
                ret.Add(ObjResult);
            }
            return ret;
        }

        public async Task<List<PokeApp2.Models.VersionGroup>> GetAllVersionsAsync()
        {
            Search initSearch = (await Search(EndPoints.VersionGroup));
            if (initSearch is null) return null;
            List<VersionGroup> ret = await Search<VersionGroup>(EndPoints.VersionGroup, 0, initSearch.Count);
            return ret;
        }

        public async Task<List<Generation>> GetAllGenerationsAsync()
        {
            Search initSearch = (await Search(EndPoints.Generation));
            if (initSearch is null) return null;
            List<Generation> ret = await Search<Generation>(EndPoints.Generation, 0, initSearch.Count);
            return ret;
        }
    }
}
