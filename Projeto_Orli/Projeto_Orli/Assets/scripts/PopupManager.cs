using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupManager : MonoBehaviour
{
    public void GoToHome()
    {
        Debug.Log("Tentando carregar a cena Home..."); // Isso mostra no Console se o código está rodando

        if (Application.CanStreamedLevelBeLoaded("Home"))
        {
            PlayerPrefs.SetInt("HideButton", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Home");
        }
        else
        {
            Debug.LogError("Erro: A cena 'Home' não pode ser carregada. Verifique o Build Settings!");
        }
    }
}
