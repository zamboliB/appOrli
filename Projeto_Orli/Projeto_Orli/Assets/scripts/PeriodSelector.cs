using UnityEngine;
using UnityEngine.UI;

public class PeriodSelector : MonoBehaviour
{
    // Bot�es de sele��o
    public Button weeklyButton;
    public Button monthlyButton;
    public Button yearlyButton;

    // Imagens de fundo dos bot�es
    public Image weeklyBackground;
    public Image monthlyBackground;
    public Image yearlyBackground;

    // Gr�ficos (GameObjects ou UI Image)
    public GameObject weeklyGraph;
    public GameObject monthlyGraph;
    public GameObject yearlyGraph;

    private string activeGraph = "weekly"; // Sempre come�a com o semanal ativo

    private void Start()
    {
        SelectWeekly(); // Garante que o gr�fico semanal est� ativado no in�cio
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
        Debug.Log("Atualizando gr�fico para: " + activeGraph);

        bool isWeekly = (activeGraph == "weekly");
        bool isMonthly = (activeGraph == "monthly");
        bool isYearly = (activeGraph == "yearly");

        // Ativa/desativa os gr�ficos
        weeklyGraph.SetActive(isWeekly);
        monthlyGraph.SetActive(isMonthly);
        yearlyGraph.SetActive(isYearly);

        // **Garante que s� um fundo rosa aparece de cada vez**
        weeklyBackground.gameObject.SetActive(isWeekly);
        monthlyBackground.gameObject.SetActive(isMonthly);
        yearlyBackground.gameObject.SetActive(isYearly);
    }
}