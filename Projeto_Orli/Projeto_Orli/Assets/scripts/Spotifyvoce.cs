using UnityEngine;


public class Spotifyvoce : MonoBehaviour
{
    // ID da playlist que voc� quer abrir
    private string playlistID = "0mp7FJ26CwdYXB1O61RfWG"; // Substitua pelo ID da sua playlist

    // M�todo para abrir no Spotify
    public void OpenSpotifyPlaylist()
    {
        string webUrl = "https://open.spotify.com/intl-pt/album/" + playlistID; // Link para o navegador
        string spotifyUrl = "spotify:playlist:" + playlistID; // Link direto para o app do Spotify

        // Tenta abrir o Spotify diretamente
        Application.OpenURL(spotifyUrl);

        // Caso o app n�o esteja instalado, abre no navegador
        Application.OpenURL(webUrl);
    }
}




