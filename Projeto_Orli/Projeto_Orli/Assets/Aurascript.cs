using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AuraButton : MonoBehaviour
{
    public Button auraButton;  // O botão da aura
    public Image aura;         // Primeira versão da aura (brilhando)
    public Image aura_versao_2; // Segunda versão da aura (brilhando diferente)
    public Sprite alegria_icone; // Imagem da aura sem brilho
    private bool brilhoAtivo = true;

    void Start()
    {
        auraButton.onClick.AddListener(AbrirTelaAura); // Adiciona evento ao clique

        // Se a aura foi desativada na escolha do usuário, muda para a versão sem brilho
        if (PlayerPrefs.GetInt("AuraDesativada", 0) == 1)
        {
            DesativarBrilho();
        }
        else
        {
            StartCoroutine(LoopBrilho()); // Inicia o efeito de brilho
        }
    }

    IEnumerator LoopBrilho()
    {
        while (brilhoAtivo)
        {
            yield return StartCoroutine(AjustarAura(aura, 0.9f, 1.0f, 1.0f, 1.1f));

            // Alterna para a segunda imagem brilhando
            aura.gameObject.SetActive(false);
            aura_versao_2.gameObject.SetActive(true);

            yield return StartCoroutine(AjustarAura(aura_versao_2, 1.0f, 0.9f, 1.1f, 1.0f));

            // Alterna de volta para a primeira aura brilhando
            aura_versao_2.gameObject.SetActive(false);
            aura.gameObject.SetActive(true);
        }
    }

    IEnumerator AjustarAura(Image aura, float minAlpha, float maxAlpha, float minScale, float maxScale)
    {
        float duration = 1.2f; // Tempo total da transição
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.PingPong(elapsed / duration, 1);
            float alpha = Mathf.Lerp(minAlpha, maxAlpha, t);
            float scale = Mathf.Lerp(minScale, maxScale, t);
            aura.color = new Color(1, 1, 1, alpha);
            aura.transform.localScale = new Vector3(scale, scale, 1);
            yield return null;
        }
    }

    void AbrirTelaAura()
    {
        brilhoAtivo = false; // Para o efeito de brilho
        SceneManager.LoadScene("TelaAura"); // Troca para a tela da aura
    }

    public void DesativarBrilho()
    {
        brilhoAtivo = false; // Para o loop de brilho
        aura.gameObject.SetActive(false);
        aura_versao_2.gameObject.SetActive(false);
        auraButton.image.sprite = alegria_icone; // Muda a imagem para a versão sem brilho
      

        // Salva que a aura foi desativada
        PlayerPrefs.SetInt("AuraDesativada", 1);
        PlayerPrefs.Save();
    }
}
