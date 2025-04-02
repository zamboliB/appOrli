using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControleRespiracao : MonoBehaviour
{
    public Image circuloProgresso; // Elipse que preenche
    public TMP_Text tempoTexto; // Texto que exibe o tempo "00:00"
    public Button botaoGravar, botaoParar, botaoRecomecar, botaoSalvar; // Bot�es
    public Toggle toggleExibirTempo; // Toggle para exibir o tempo salvo

    private float tempoAtual = 0f;
    private bool gravando = false;

    void Start()
    {
        // Configura os bot�es
        botaoGravar.onClick.AddListener(IniciarGravacao);
        botaoParar.onClick.AddListener(PararGravacao);
        botaoRecomecar.onClick.AddListener(Recomecar);
        botaoSalvar.onClick.AddListener(SalvarTempo);

        // Desativa os bot�es que n�o devem aparecer no come�o
        botaoParar.gameObject.SetActive(false);
        botaoRecomecar.gameObject.SetActive(false);
        botaoSalvar.gameObject.SetActive(false);

        // Define o c�rculo vazio e o tempo zerado
        circuloProgresso.fillAmount = 0f;
        tempoTexto.text = "00:00";
    }

    void Update()
    {
        if (gravando)
        {
            tempoAtual += Time.deltaTime;

            if (tempoAtual > 20f) // M�ximo de 20 segundos
            {
                tempoAtual = 20f;
                PararGravacao();
            }

            // Atualiza o texto do tempo
            int segundos = Mathf.FloorToInt(tempoAtual);
            tempoTexto.text = "00:" + segundos.ToString("00");

            // Atualiza o preenchimento da elipse
            circuloProgresso.fillAmount = tempoAtual / 20f;
        }
    }

    void IniciarGravacao()
    {
        gravando = true;
        botaoGravar.gameObject.SetActive(false);
        botaoParar.gameObject.SetActive(true);
    }

    void PararGravacao()
    {
        gravando = false;
        botaoParar.gameObject.SetActive(false);
        botaoRecomecar.gameObject.SetActive(true);
        botaoSalvar.gameObject.SetActive(true);
    }

    void Recomecar()
    {
        tempoAtual = 0f;
        circuloProgresso.fillAmount = 0f;
        tempoTexto.text = "00:00";

        botaoGravar.gameObject.SetActive(true);
        botaoParar.gameObject.SetActive(false);
        botaoRecomecar.gameObject.SetActive(false);
        botaoSalvar.gameObject.SetActive(false);
    }

    void SalvarTempo()
    {
        toggleExibirTempo.GetComponentInChildren<TMP_Text>().text = "Tempo salvo: " + Mathf.FloorToInt(tempoAtual) + "s";
    }
}
