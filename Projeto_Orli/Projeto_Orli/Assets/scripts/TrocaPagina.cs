using UnityEngine;

public class TrocaPagina : MonoBehaviour
{
    public GameObject paginaMostrar;  // Painel que ser� ativado
    public GameObject paginaEsconder; // Painel que ser� desativado

    public void MudarPagina()
    {
        paginaMostrar.SetActive(true);  // Ativa o painel novo
        paginaEsconder.SetActive(false); // Esconde o painel atual
    }
}
