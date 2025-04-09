using UnityEngine;
using UnityEngine.UI;


public class SetCor : MonoBehaviour
{

    public GameObject GameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SetaCor()
    {
       gameObject.GetComponent<Image>().color = GameManager.GetComponent<Armazena_Cor>().colorList[0];
    }
}
