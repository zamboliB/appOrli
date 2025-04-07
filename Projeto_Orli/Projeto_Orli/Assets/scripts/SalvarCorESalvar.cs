using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SalvarCorESalvar : MonoBehaviour
{
    [Header("Referências no Perfil")]
    public TMP_Text textoNomePerfil;
    public TMP_InputField inputNome;
    public Image imagemColorida; // A imagem que muda de cor

    void Start()
    {
        // Carrega o nome salvo (apenas no perfil)
        if (PlayerPrefs.HasKey("NomeOrli"))
        {
            string nomeSalvo = PlayerPrefs.GetString("NomeOrli");
            if (textoNomePerfil != null) textoNomePerfil.text = nomeSalvo;
        }

        // Carrega a cor salva
        if (PlayerPrefs.HasKey("CorR"))
        {
            float r = PlayerPrefs.GetFloat("CorR");
            float g = PlayerPrefs.GetFloat("CorG");
            float b = PlayerPrefs.GetFloat("CorB");
            float a = PlayerPrefs.GetFloat("CorA");

            Color corSalva = new Color(r, g, b, a);
            if (imagemColorida != null) imagemColorida.color = corSalva;
        }
    }

    // Salva o nome digitado
    public void SalvarNome()
    {
        string novoNome = inputNome.text;

        if (!string.IsNullOrEmpty(novoNome))
        {
            PlayerPrefs.SetString("NomeOrli", novoNome);
            PlayerPrefs.Save();

            if (textoNomePerfil != null) textoNomePerfil.text = novoNome;
        }
    }

    // Essa função deve ser chamada na cena do Color Picker
    public void SalvarCorSelecionada(Image imagemComCorEscolhida)
    {
        Color cor = imagemComCorEscolhida.color;

        PlayerPrefs.SetFloat("CorR", cor.r);
        PlayerPrefs.SetFloat("CorG", cor.g);
        PlayerPrefs.SetFloat("CorB", cor.b);
        PlayerPrefs.SetFloat("CorA", cor.a);
        PlayerPrefs.Save();
    }
}
