using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrocaVibracao : MonoBehaviour
{
    public Color corAtivo;
    public Color corDesativo;
    public bool ativo;
    public GameObject check;

    private static List<TrocaVibracao> todosToggles = new List<TrocaVibracao>(); // Lista global de todos os toggles

    void Start()
    {
        // Adiciona este toggle à lista
        if (!todosToggles.Contains(this))
        {
            todosToggles.Add(this);
        }

        // Atualiza a cor de acordo com o estado inicial
        AtualizarCor(ativo);
    }

    public void TrocarVibracao()
    {
        if (!ativo)
        {
            // Desativa todos os outros toggles antes de ativar este
            foreach (var toggle in todosToggles)
            {
                toggle.Desativar();
            }

            Ativar();
        }
        else
        {
            // Se já está ativo, apenas desativa este toggle
            Desativar();
        }
    }

    private void Ativar()
    {
        check.SetActive(true); // Exibe o ícone de "check"
        gameObject.GetComponent<Image>().color = corAtivo; // Muda a cor para o estado ativo
        ativo = true;
    }

    private void Desativar()
    {
        check.SetActive(false); // Esconde o ícone de "check"
        gameObject.GetComponent<Image>().color = corDesativo; // Muda a cor para o estado desativo
        ativo = false;
    }

    private void AtualizarCor(bool estadoAtivo)
    {
        if (estadoAtivo)
        {
            Ativar();
        }
        else
        {
            Desativar();
        }
    }
}
