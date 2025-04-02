using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;  // Para UI, caso queira pegar o código da interface
using System.Collections;

public class Spotify : MonoBehaviour
{
    private string clientId = "2d36a41a9e094ad19808099625606d3f";  // Substitua pelo seu Client ID
    private string clientSecret = "ef2ac17d89e942e9a52eb963ce21abd1";  // Substitua pelo seu Client Secret
    private string redirectUri = "http://localhost:3000/callback";  // Mesmo que cadastrou no Spotify Developer

    // Variáveis para UI (caso queira pegar o código da interface)
    public InputField authorizationCodeInput;  // Campo para inserir manualmente o código
    public Button requestTokenButton;  // Botão para disparar o request

    private void Start()
    {
        // Atribui o botão para chamar o RequestAccessToken quando pressionado
        requestTokenButton.onClick.AddListener(OnRequestTokenButtonClicked);
    }

    // Método chamado quando o botão é clicado
    private void OnRequestTokenButtonClicked()
    {
        string authorizationCode = authorizationCodeInput.text;  // Obtém o código de autorização do campo de texto

        if (string.IsNullOrEmpty(authorizationCode))
        {
            Debug.LogError("Por favor, insira o código de autorização.");
            return;
        }

        // Chama o método para solicitar o token de acesso
        RequestAccessToken(authorizationCode);
    }

    public void OpenSpotifyLogin()
    {
        string scope = "user-read-playback-state user-modify-playback-state streaming";

        string authUrl = $"https://accounts.spotify.com/authorize?client_id={clientId}" +
                         $"&response_type=code&redirect_uri={redirectUri}&scope={scope}";

        Application.OpenURL(authUrl);
    }

    public void RequestAccessToken(string authorizationCode)
    {
        StartCoroutine(GetSpotifyAccessToken(authorizationCode));
    }

    private IEnumerator GetSpotifyAccessToken(string authorizationCode)
    {
        WWWForm form = new WWWForm();
        form.AddField("grant_type", "authorization_code");
        form.AddField("code", authorizationCode);
        form.AddField("redirect_uri", redirectUri);
        form.AddField("client_id", clientId);
        form.AddField("client_secret", clientSecret);

        using (UnityWebRequest request = UnityWebRequest.Post("https://accounts.spotify.com/api/token", form))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string json = request.downloadHandler.text;

                Debug.Log("Access Token recebido: " + json);

                // Aqui você pode pegar o access token da resposta JSON
                // Exemplo:
                // AccessTokenResponse response = JsonUtility.FromJson<AccessTokenResponse>(json);
                // Debug.Log("Token: " + response.access_token);

            }
            else
            {
                Debug.LogError("Erro ao obter Access Token: " + request.error);
            }
        }
    }

    // Classe para deserializar a resposta JSON
    [System.Serializable]
    public class AccessTokenResponse
    {
        public string access_token;
        public string token_type;
        public int expires_in;
    }
}





