using UnityEngine;

public class SaveManager : MonoBehaviour
{
    void OnApplicationQuit()
    {
        PlayerPrefs.Save(); // Salva os dados antes de sair do Play Mode
        Debug.Log("Dados salvos!");
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Mant�m o SaveManager ao trocar de cena
    }

}

