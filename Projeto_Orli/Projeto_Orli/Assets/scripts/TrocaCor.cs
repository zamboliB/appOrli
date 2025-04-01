using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrocaCor : MonoBehaviour
{
    public Color corAtivo;
    public Color corDesativo;
    public bool ativo;
    public GameObject check;

    private static List<TrocaCor> todosToggles = new List<TrocaCor>(); // Lista global de todos os toggles

    void Start()
    {
        // Adiciona este toggle à lista
        if (!todosToggles.Contains(this))
        {
            todosToggles.Add(this);
        }

        // Define a cor inicial
        AtualizarCor(ativo);
    }

    public void TrocarCor()
    {
        if (!ativo)
        {
            // Desativa todos os outros toggles antes de ativar este
            foreach (var toggle in todosToggles)
            {
                if (toggle != this)
                {
                    toggle.Desativar();
                }
            }

            Ativar();
        }
        else
        {
            Desativar();
        }
    }

    private void Ativar()
    {
        check.SetActive(true);
        gameObject.GetComponent<Image>().color = corAtivo;
        ativo = true;
    }

    public void Desativar()
    {
        check.SetActive(false);
        gameObject.GetComponent<Image>().color = corDesativo;
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
