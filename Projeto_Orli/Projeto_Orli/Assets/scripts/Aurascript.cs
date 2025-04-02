using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AuraButton : MonoBehaviour
{
    public Button auraButton;          // O botão da aura
    public Image aura;                 // Primeira versão da aura (brilhando)
    public Image auraVersao2;          // Segunda versão da aura (brilhando diferente)
    public Sprite alegriaIcone;        // Imagem da aura sem brilho

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
            CoroutineHandler.Instance.StartCoroutine(LoopBrilho()); // Inicia o efeito de brilho
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
            auraVersao2.gameObject.SetActive(false);
            yield return new WaitForSeconds(1);
            StartCoroutine(AjustarAura(aura, 0.9f, 1.0f, 1.0f, 1.1f, 1.2f));

            if (interagido)
                yield break;

            // Ativa a segunda aura e desativa a primeira
            aura.gameObject.SetActive(false);
            auraVersao2.gameObject.SetActive(true);
            yield return new WaitForSeconds(1); 
            StartCoroutine(AjustarAura(auraVersao2, 1.0f, 0.9f, 1.1f, 1.0f, 1.2f));
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
        auraVersao2.gameObject.SetActive(false);
        auraButton.image.sprite = alegriaIcone; // Muda a imagem para a versão sem brilho

        // Salva que a aura foi desativada
        PlayerPrefs.SetInt("AuraDesativada", 1);
        PlayerPrefs.Save();
    }
}
