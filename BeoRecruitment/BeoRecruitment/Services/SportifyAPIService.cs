using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using BeoRecruitment.Services.Interfaces;
using BeoRecruitment.ViewModels;
using BeoRecruitment.Models.Entities;
using System.Linq;

namespace BeoRecruitment.Services
{
    public class SpotifyAPIService : ISpotifyAPIService
    {
        public async Task<string> GetSpotifyAccessTokenAsync()
        {
            string clientId = "aae368d1daac4561af4600d1bfeb3a4f";
            string clientSecret = "c7a7b72a78104a49a607b2480cbb8587";

            using (HttpClient client = new HttpClient())
            {
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token")
                {
                    Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded")
                };

                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string responseData = await response.Content.ReadAsStringAsync();
                JsonDocument jsonDocument = JsonDocument.Parse(responseData);
                JsonElement root = jsonDocument.RootElement;

                if (root.TryGetProperty("access_token", out JsonElement tokenElement))
                {
                    return tokenElement.GetString();
                }
                else
                {
                    throw new Exception("Could not retrieve access token from Spotify.");
                }
            }
        }

        public async Task<List<Artist>> SearchSpotifyAsync(string keyword, string token)
        {
            string apiUrl = $"https://api.spotify.com/v1/search?q={keyword}&type=artist";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    JsonDocument jsonDocument = JsonDocument.Parse(responseData);
                    JsonElement root = jsonDocument.RootElement;

                    List<Artist> artists = new List<Artist>();

                    if (root.TryGetProperty("artists", out JsonElement artistsElement))
                    {
                        if (artistsElement.TryGetProperty("items", out JsonElement itemsElement))
                        {
                            foreach (JsonElement artistElement in itemsElement.EnumerateArray())
                            {
                                string artistId = artistElement.GetProperty("id").GetString();
                                string artistName = artistElement.GetProperty("name").GetString();
                                string externalURL = artistElement.GetProperty("external_urls").GetProperty("spotify").GetString();
                                string followerCount = artistElement.GetProperty("followers").GetProperty("total").GetInt32().ToString("#,##0");
                                string genres = string.Join(", ", artistElement.GetProperty("genres").EnumerateArray().Select(g => g.GetString()).ToArray());
                                string artistImageURL = artistElement.GetProperty("images").EnumerateArray().Select(img => img.GetProperty("url").GetString()).FirstOrDefault();

                                Artist artist = new Artist(artistId, artistName, artistImageURL, genres, followerCount, externalURL);
                                artists.Add(artist);
                            }
                        }
                    }
                    return artists;
                }
                else
                {
                    throw new HttpRequestException($"Error: {response.StatusCode}");
                }
            }
        }

        


    }
}