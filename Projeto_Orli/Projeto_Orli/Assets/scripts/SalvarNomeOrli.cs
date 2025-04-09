using UnityEngine;
using UnityEngine.UI;
using TMPro; // Importa o TextMeshPro

public class SalvarNomeOrli: MonoBehaviour
{
    public TMP_InputField inputNome;  // Campo onde o usuário digita o nome
    public TMP_Text textoNome;  // Texto onde o nome salvo aparece no perfil

    void Start()
    {
        // Se já houver um nome salvo, carregamos ele
        if (PlayerPrefs.HasKey("NomeOrli"))
        {
            string nomeSalvo = PlayerPrefs.GetString("NomeOrli");
            textoNome.text = nomeSalvo; // Atualiza o texto do perfil
        }
    }

    public void SalvarNome()
    {
        string novoNome = inputNome.text;

        if (!string.IsNullOrEmpty(novoNome)) // Evita salvar um nome vazio
        {
            PlayerPrefs.SetString("NomeOrli", novoNome);
            PlayerPrefs.Save(); // Salva permanentemente

            textoNome.text = novoNome; // Atualiza o texto do perfil
        }
    }
}
