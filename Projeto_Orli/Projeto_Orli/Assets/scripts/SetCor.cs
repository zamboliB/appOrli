using UnityEngine;
using UnityEngine.UI;


public class SetCor : MonoBehaviour
{



  


    public GameObject GameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  

    // Update is called once per frame
    public void Update()
    {

        gameObject.GetComponent<Image>().color = GameManager.GetComponent<ColorPick>().objeto.color;
        
    }
}
