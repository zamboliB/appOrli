using UnityEngine;
using System.Collections.Generic;

public class Spotifyfeliz : MonoBehaviour
{
    // Dicion�rio com todas as playlists e �lbuns
    private Dictionary<string, string> spotifyLinks = new Dictionary<string, string>
    {
        { "playlist1", "37i9dQZF1DX47UHGK8zGt8" },
        { "playlist2", "4GE9mkn9F6pQieB64NQE8z" },
        { "playlist3", "37i9dQZF1DXaKgOqDv3HpW" },
        { "playlist4", "37i9dQZF1DXdPec7aLTmlC" },
        { "playlist5", "37i9dQZF1EVJSvZp5AOML2" },
        { "playlist6", "37i9dQZF1DWUIDYTCle9M9" },
        { "album1", "0SUK8T53mt8wyyisBjldgl" },
        { "album2", "0mp7FJ26CwdYXB1O61RfWG" },
        { "album3", "4AeYedTuISOISxGSsM2uOo" }
    };

    // M�todo para abrir a playlist ou �lbum no Spotify
    public void OpenSpotify(string id)
    {
        if (spotifyLinks.TryGetValue(id, out string spotifyID))
        {
            string tipo = id.StartsWith("playlist") ? "playlist" : "album";
            string spotifyUrl = $"spotify:{tipo}:{spotifyID}"; // Link para o app do Spotify
            string webUrl = $"https://open.spotify.com/{tipo}/{spotifyID}"; // Link para o navegador

            Application.OpenURL(spotifyUrl); // Tenta abrir no app do Spotify
            Application.OpenURL(webUrl); // Se n�o abrir no app, carrega no navegador
        }
        else
        {
            Debug.LogError("ID inv�lido: " + id);
        }
    }
}






