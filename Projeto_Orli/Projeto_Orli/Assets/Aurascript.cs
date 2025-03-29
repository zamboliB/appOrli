using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AuraButton : MonoBehaviour
{
    public Button auraButton;          // O botão da aura
    public Image aura;                 // Primeira versão da aura (brilhando)
    public Image aura_versao_2;        // Segunda versão da aura (brilhando diferente)
    public Sprite alegria_icone;       // Imagem da aura sem brilho

    private bool brilhoAtivo = true;
    private bool interagido = false;

    void Start()
    {
        auraButton.onClick.AddListener(AbrirTelaAura); // Adiciona evento ao clique

        // Verifica se a aura foi desativada anteriormente
        if (PlayerPrefs.GetInt("AuraDesativada", 0) == 1)
        {
            DesativarBrilho();
        }
        else
        {
            CoroutineManager.Instance.StartCoroutine(LoopBrilho());
        }
    }

    IEnumerator LoopBrilho()
    {
        while (brilhoAtivo)
        {
            if (interagido)
                yield break;

            // Ativa a primeira aura e desativa a segunda
            aura.gameObject.SetActive(true);
            aura_versao_2.gameObject.SetActive(false);
            yield return StartCoroutine(AjustarAura(aura, 0.9f, 1.0f, 1.0f, 1.05f, 2.0f)); // Escala mais sutil

            if (interagido)
                yield break;

            // Transição suave entre as auras
            yield return StartCoroutine(TransicaoSuave());

            // Ativa a segunda aura e desativa a primeira
            aura.gameObject.SetActive(false);
            aura_versao_2.gameObject.SetActive(true);
            yield return StartCoroutine(AjustarAura(aura_versao_2, 1.0f, 0.9f, 1.0f, 1.05f, 2.0f)); // Escala mais sutil
        }
    }

    IEnumerator TransicaoSuave()
    {
        // Suavizando a troca das auras antes da transição de volta
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 0.5f; // Ajuste a velocidade da transição para ser mais suave
            yield return null;
        }
    }

    IEnumerator AjustarAura(Image auraImage, float minAlpha, float maxAlpha, float minScale, float maxScale, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            if (interagido)
                yield break;

            elapsed += Time.deltaTime;
            float t = Mathf.PingPong(elapsed / duration, 1);
            float alpha = Mathf.Lerp(minAlpha, maxAlpha, t);
            float scale = Mathf.Lerp(minScale, maxScale, t);
            auraImage.color = new Color(1, 1, 1, alpha);
            auraImage.transform.localScale = new Vector3(scale, scale, 1);
            yield return null;
        }
    }

    void AbrirTelaAura()
    {
        interagido = true;
        brilhoAtivo = false; // Para o efeito de brilho
        SceneManager.LoadScene("TelaAura"); // Troca para a tela da aura
    }

    public void DesativarBrilho()
    {
        interagido = true;
        brilhoAtivo = false; // Para o loop de brilho
        aura.gameObject.SetActive(false);
        aura_versao_2.gameObject.SetActive(false);
        auraButton.image.sprite = alegria_icone; // Muda a imagem para a versão sem brilho

        // Salva que a aura foi desativada
        PlayerPrefs.SetInt("AuraDesativada", 1);
        PlayerPrefs.Save();
    }
}
