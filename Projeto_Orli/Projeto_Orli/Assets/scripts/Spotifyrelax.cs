using UnityEngine;


public class Spotifyrelax : MonoBehaviour
{
    // ID da playlist que você quer abrir
    private string playlistID = "37i9dQZF1DXaKgOqDv3HpW"; // Substitua pelo ID da sua playlist

    // Método para abrir no Spotify
    public void OpenSpotifyPlaylist()
    {
        string webUrl = "https://open.spotify.com/playlist/" + playlistID; // Link para o navegador
        string spotifyUrl = "spotify:playlist:" + playlistID; // Link direto para o app do Spotify

        // Tenta abrir o Spotify diretamente
        Application.OpenURL(spotifyUrl);

        // Caso o app não esteja instalado, abre no navegador
        Application.OpenURL(webUrl);
    }
}




