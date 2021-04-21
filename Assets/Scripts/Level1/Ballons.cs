using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Ballons : MonoBehaviour
{
    public GameObject randomColorObj;
   

    public Text liveText;
    public Text puanText;
    public GameObject levelPanel;
   
    public float minX = -5.0f;
    public float maxX = 5.0f;
    public float minY = -3.0f;
    public float maxY = 0f;
    [SerializeField]
    Color[] colors = new Color[5];
    
    int live;
    int puan;

    void Start()
    {
       
        live = 3;
        puan = 0;

        colors[0] = Color.red;
        colors[1] = Color.blue;
        colors[2] = Color.green;
        colors[3] = Color.yellow;
        colors[4] = Color.cyan;


        Color32 randomColor = colors[Random.Range(0, colors.Length - 1)];
     
        randomColorObj.GetComponent<Renderer>().material.color = randomColor;
        
    }


    void Update()
    {
        if (live != 0)
        {
            CheckUpdateColor();
        }
        else
        {
            levelPanel.SetActive(true);
            SceneManager.LoadScene("GameScene");
        }
 
    }

    void CheckUpdateColor()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null )
                {
                    
                    if (hit.transform.GetComponent<Renderer>().material.color == randomColorObj.GetComponent<Renderer>().material.color)
                    {
                        puan += 10;
                        puanText.text = puan.ToString();
                    }
                    else
                    {
                        puan -= 5;
                        puanText.text = puan.ToString();
                        live--;
                        liveText.text = live.ToString();
                    }
                }
                Destroy(hit.transform.gameObject);
            }
        }
    }

    
}
