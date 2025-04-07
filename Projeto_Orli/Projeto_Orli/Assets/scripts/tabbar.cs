using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class tabbar : MonoBehaviour
{
    [System.Serializable]
    public class Aba
    {
        public Button botao;
        public Image icone;
        public Sprite spriteAtivo;
        public Sprite spriteInativo;
        public TextMeshProUGUI texto;
        public Color corAtivo;
        public Color corInativo;
        public GameObject painel;
    }

    public Aba[] abas;
    public float duracaoTransicao = 0.25f;

    private int abaAtiva = 0;

    void Start()
    {
        // Recupera aba salva
        abaAtiva = PlayerPrefs.GetInt("AbaAtiva", 0);
        AtualizarAbas();

        // Adiciona eventos nos botões
        for (int i = 0; i < abas.Length; i++)
        {
            int index = i;
            abas[i].botao.onClick.AddListener(() => TrocarAba(index));
        }
    }

    public void TrocarAba(int index)
    {
        if (index == abaAtiva) return;

        abaAtiva = index;
        PlayerPrefs.SetInt("AbaAtiva", abaAtiva);
        AtualizarAbas();
    }

    private void AtualizarAbas()
    {
        for (int i = 0; i < abas.Length; i++)
        {
            bool ativo = (i == abaAtiva);

            // Sprite do ícone
            abas[i].icone.sprite = ativo ? abas[i].spriteAtivo : abas[i].spriteInativo;

            // Cor do texto
            abas[i].texto.color = ativo ? abas[i].corAtivo : abas[i].corInativo;

            // Ativar painel
            abas[i].painel.SetActive(ativo);

            // (Opcional) Adicionar animação aqui se quiser
        }
    }
}
