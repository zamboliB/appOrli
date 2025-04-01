using UnityEngine;
using UnityEngine.UI;
using TMPro; // Importa o TextMeshPro

public class SalvarNomeOrli : MonoBehaviour
{
    public TMP_InputField inputNome;  // Campo onde o usuário digita o nome
    public TMP_Text textoNomePerfil;  // Texto onde o nome salvo aparece no perfil
    public TMP_Text textoNomeHome;    // Texto onde o nome salvo aparece na home

    void Start()
    {
        // Se já houver um nome salvo, carregamos ele
        if (PlayerPrefs.HasKey("NomeOrli"))
        {
            string nomeSalvo = PlayerPrefs.GetString("NomeOrli");
            textoNomePerfil.text = nomeSalvo; // Atualiza o texto do perfil
            textoNomeHome.text = nomeSalvo;   // Atualiza o texto da home
        }
    }

    public void SalvarNome()
    {
        string novoNome = inputNome.text;

        if (!string.IsNullOrEmpty(novoNome)) // Evita salvar um nome vazio
        {
            PlayerPrefs.SetString("NomeOrli", novoNome);
            PlayerPrefs.Save(); // Salva permanentemente

            textoNomePerfil.text = novoNome; // Atualiza o texto do perfil
            textoNomeHome.text = novoNome;   // Atualiza o texto da home
        }
    }
}
