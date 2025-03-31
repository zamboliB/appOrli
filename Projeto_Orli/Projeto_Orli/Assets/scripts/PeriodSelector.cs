using UnityEngine;
using UnityEngine.UI;

public class PeriodSelector : MonoBehaviour
{
    // Botões de seleção
    public Button weeklyButton;
    public Button monthlyButton;
    public Button yearlyButton;

    // Imagens de fundo dos botões
    public Image weeklyBackground;
    public Image monthlyBackground;
    public Image yearlyBackground;

    // Gráficos (GameObjects ou UI Image)
    public GameObject weeklyGraph;
    public GameObject monthlyGraph;
    public GameObject yearlyGraph;

    private string activeGraph = "weekly"; // Sempre começa com o semanal ativo

    private void Start()
    {
        SelectWeekly(); // Garante que o gráfico semanal está ativado no início
    }

    public void SelectWeekly()
    {
        activeGraph = "weekly";
        UpdateGraph();
    }

    public void SelectMonthly()
    {
        activeGraph = "monthly";
        UpdateGraph();
    }

    public void SelectYearly()
    {
        activeGraph = "yearly";
        UpdateGraph();
    }

    private void UpdateGraph()
    {
        Debug.Log("Atualizando gráfico para: " + activeGraph);

        bool isWeekly = (activeGraph == "weekly");
        bool isMonthly = (activeGraph == "monthly");
        bool isYearly = (activeGraph == "yearly");

        // Ativa/desativa os gráficos
        weeklyGraph.SetActive(isWeekly);
        monthlyGraph.SetActive(isMonthly);
        yearlyGraph.SetActive(isYearly);

        // **Garante que só um fundo rosa aparece de cada vez**
        weeklyBackground.gameObject.SetActive(isWeekly);
        monthlyBackground.gameObject.SetActive(isMonthly);
        yearlyBackground.gameObject.SetActive(isYearly);
    }
}