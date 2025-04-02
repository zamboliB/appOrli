using UnityEngine;

public class Spotifyfeliz : MonoBehaviour
{
    // ID da playlist que voc� quer abrir
    private string playlistID = "37i9dQZF1DWUIDYTCle9M9"; // Substitua pelo ID da sua playlist

    // M�todo para abrir no Spotify
    public void OpenSpotifyPlaylist()
    {
        string spotifyUrl = "spotify:playlist:" + playlistID; // Link direto para o app do Spotify
        string webUrl = "https://open.spotify.com/playlist/" + playlistID; // Link para o navegador

        // Tenta abrir o Spotify diretamente
        Application.OpenURL(spotifyUrl);

        // Caso o app n�o esteja instalado, abre no navegador
        Application.OpenURL(webUrl);
    }
}
