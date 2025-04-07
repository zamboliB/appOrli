using UnityEngine;
using System.Collections.Generic;

public class SpotifyFrequencia : MonoBehaviour
{
    // Dicionário com todas as playlists e álbuns
    private Dictionary<string, string> spotifyLinks = new Dictionary<string, string>
    {
        { "playlist1", "37i9dQZF1DWSFn2ideAJpT" },
        { "playlist2", "2RtkziI4ASNkhQ6QxgvmLt" },
        { "playlist3", "37i9dQZF1E8MdZfBXPi4nh" },
        { "playlist4", "37i9dQZF1DWTvEFX6xtoQd" },
        { "playlist5", "0juxr3SbRXzXyeEfv5Z9RZ" },
        { "playlist6", "5L0pZc5oNutFxMY1xOss84" },
        { "playlist7", "11DlFvEjs5gTsaQhMdQ3ND" },
        { "playlist8", "37i9dQZF1DX10jlupqH0Bt" },
        { "playlist9", "3PNADKRA2SGtfs53JoyV90" }
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






