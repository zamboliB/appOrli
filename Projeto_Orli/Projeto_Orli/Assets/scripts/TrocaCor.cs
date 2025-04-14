using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrocaCor : MonoBehaviour
{
    [Header("Cores")]
    public Color corAtivo;
    public Color corDesativo;

    [Header("Estado inicial")]
    public bool ativo;

    [Header("Referência ao check (ícone)")]
    public GameObject check;

    // Lista global com todos os toggles
    private static List<TrocaCor> todosToggles = new List<TrocaCor>();

    // Cache do componente Image (melhor performance)
    private Image imagem;

    void Start()
    {
        imagem = GetComponent<Image>();

        if (!todosToggles.Contains(this))
        {
            todosToggles.Add(this);
        }

        AtualizarCor(ativo);

        // Garante que pelo menos um toggle fique ativo
        if (!todosToggles.Exists(t => t.ativo))
        {
            Ativar();
        }
    }

    public void TrocarCor()
    {
        // Se já está ativo, não faz nada
        if (ativo)
            return;

        // Desativa todos os outros
        foreach (var toggle in todosToggles)
        {
            toggle.Desativar();
        }

        // Ativa este
        Ativar();
    }

    private void Ativar()
    {
        if (check != null)
            check.SetActive(true);

        if (imagem != null)
            imagem.color = corAtivo;

        ativo = true;
    }

    private void Desativar()
    {
        if (check != null)
            check.SetActive(false);

        if (imagem != null)
            imagem.color = corDesativo;

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
