using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopiaTrocaCor : MonoBehaviour
{
    public Color corAtivo;
    public Color corDesativo;
    public bool ativo;
    public GameObject check;

    private static List<CopiaTrocaCor> todosToggles = new List<CopiaTrocaCor>(); // Lista global de todos os toggles

    void Start()
    {
        // Adiciona este toggle à lista
        if (!todosToggles.Contains(this))
        {
            todosToggles.Add(this);
        }

        // Se nenhum estiver ativo, ativa automaticamente o primeiro
        if (!AlgumToggleAtivo())
        {
            Ativar(); // Ativa este toggle, caso nenhum esteja ativo
        }
        else
        {
            AtualizarCor(ativo); // Atualiza a cor com base no estado do toggle
        }
    }

    public void TrocarCor()
    {
        if (!ativo)
        {
            // Desativa todos os outros antes de ativar este
            foreach (var toggle in todosToggles)
            {
                toggle.Desativar();
            }

            Ativar(); // Ativa este toggle
        }
    }

    private void Ativar()
    {
        check.SetActive(true); // Exibe o ícone de "check" ou algo visual que indica que está ativo
        gameObject.GetComponent<Image>().color = corAtivo; // Muda a cor do toggle para a ativa
        ativo = true; // Marca como ativo
    }

    private void Desativar()
    {
        check.SetActive(false); // Esconde o ícone de "check"
        gameObject.GetComponent<Image>().color = corDesativo; // Muda a cor para o estado desativo
        ativo = false; // Marca como desativo
    }

    private void AtualizarCor(bool estadoAtivo)
    {
        if (estadoAtivo)
        {
            Ativar(); // Se o toggle estiver ativo, chama a função Ativar()
        }
        else
        {
            Desativar(); // Caso contrário, chama a função Desativar()
        }
    }

    // Método que verifica se há pelo menos um toggle ativo
    private bool AlgumToggleAtivo()
    {
        foreach (var toggle in todosToggles)
        {
            if (toggle.ativo)
            {
                return true; // Retorna true se algum toggle estiver ativo
            }
        }
        return false; // Retorna false se nenhum toggle estiver ativo
    }
}
