using UnityEngine;
using System.Collections.Generic;

public class SpotifyNatureza : MonoBehaviour
{
    // Dicionário com todas as playlists e álbuns
    private Dictionary<string, string> spotifyLinks = new Dictionary<string, string>
    {
        { "playlist1", "4p2S0MyPgRlSjjVdluePCs" },
        { "playlist2", "37i9dQZF1DXavtmWzC1MpQ" },
        { "playlist3", "37i9dQZF1DX2DjEOgyULQF" },
        { "playlist4", "5rqpkcL5AbqHPflePPLSsC" },
        { "playlist5", "6BmOwexd5PirOZp7g4N0Ir" },
        { "playlist6", "0KppmJToTjNDi2h55yTYq5" },
        { "playlist7", "4IX2GdECzW88uT8ZYBz8VB" },
        { "playlist8", "37i9dQZF1DX1jk5JfpZoMf" },
        { "playlist9", "4dq0mJF4mhDFQ5K3H4VgtT" }
    };

    // Método para abrir a playlist ou álbum no Spotify
    public void OpenSpotify(string id)
    {
        if (spotifyLinks.TryGetValue(id, out string spotifyID))
        {
            string tipo = id.StartsWith("playlist") ? "playlist" : "album";
            string spotifyUrl = $"spotify:{tipo}:{spotifyID}"; // Link para o app do Spotify
            string webUrl = $"https://open.spotify.com/{tipo}/{spotifyID}"; // Link para o navegador

            Application.OpenURL(spotifyUrl); // Tenta abrir no app do Spotify
            Application.OpenURL(webUrl); // Se não abrir no app, carrega no navegador
        }
        else
        {
            Debug.LogError("ID inválido: " + id);
        }
    }
}






