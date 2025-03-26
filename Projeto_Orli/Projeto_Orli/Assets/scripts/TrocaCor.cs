using UnityEngine;
using UnityEngine.UI;

public class TrocaCor : MonoBehaviour
{

    public Color corAtivo;
    public Color corDesativo;
   public bool ativo;
    public GameObject check;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TrocarCor()
    {
        if (!ativo)
        {
            check.SetActive(true);
            gameObject.GetComponent<Image>().color = new Color(corAtivo.r, corAtivo.g, corAtivo.b,255);
            ativo = true;
        }else
        {
            check.SetActive(false);
            gameObject.GetComponent<Image>().color = new Color(corDesativo.r, corDesativo.g, corDesativo.b,255);
            ativo = false;
        }
    }
}
