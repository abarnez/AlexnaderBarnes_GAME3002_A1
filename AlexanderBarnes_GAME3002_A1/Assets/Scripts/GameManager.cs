using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Cube1, Cube2, Cube3, Cube4, Cube5, Cube6;
    public int counter;
    public bool check1, check2, check3, check4, check5, check6;
    public Canvas nextLevelUI, gameOver;
    // Start is called before the first frame update
    void Start()
    {
        check1 = false;
        check2 = false;
        check3 = false;
        check4 = false;
        check5 = false;
        check6 = false;
        counter = 0;


    }

    // Update is called once per frame
    void Update()
    {
        Check();
        if(check1 && check2 && check3 && check4 && check5 && check6)
        {
            nextLevelUI.GetComponent<Canvas>().enabled = true;
            gameOver.enabled = false;
            
            
        }
    }

    public void Check()
    {
        if (Cube1 == null)
        {
            check1 = true;
        }

        if (Cube2 == null)
        {
            check2 = true;
        }

        if (Cube3 == null)
        {
            check3 = true;
        }

        if (Cube4 == null)
        {
            check4 = true;
        }

        if (Cube5 == null)
        {
            check5 = true;
        }

        if (Cube6 == null)
        {
            check6 = true;
        }

      
    }
}
