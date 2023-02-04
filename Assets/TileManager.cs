using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] protected GameObject tile;
    [SerializeField] protected GameObject tile1;
    [SerializeField] protected GameObject select;
    protected Renderer renderer;

    private float counter = 0;
    private string TileSelected


    void Start()
    {
        for (float i = 1; i < 10; i++)
        {
            for (int j=0; j < 10; j++)
            {

                GameObject t = Instantiate(tile, new Vector3(i, 0, j), Quaternion.identity);
                t.name = i.ToString() + "x" + j.ToString();
                //t.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }

        }

        renderer = GetComponent<Renderer>();

    }


    void Update()
    {
        string n = "";
        n = GetNameOnClick();


        if (n!="") {
            counter += Time.deltaTime;
            
        }
        Hover();

    }

    void ChangeTile(string n) {
        GameObject find = GameObject.Find(n);
        string ime = find.name;
        Vector3 pos = find.transform.position;
        Destroy(find);
        GameObject nov = Instantiate(tile1, pos, Quaternion.identity);
        nov.name = ime;
        //nov.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }
    GameObject GetNameOnClick() {
        RaycastHit mtInfo = new RaycastHit();
        string name = "";
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out mtInfo))
             {
                Debug.Log("It's working");
                Debug.Log(mtInfo.transform.parent.gameObject.name);
            }
            else
            {
                Debug.Log("Ne");
            }
        }
        return mtInfo.transform.parent.gameObject;
        
    }
    void Hover() {
        RaycastHit mtInfo = new RaycastHit();
        string name = "";
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out mtInfo))
        {
            Debug.Log("It's working");
            select.SetActive(true);
            select.transform.position = mtInfo.transform.parent.gameObject.transform.position;
        }
        else
        {
            select.SetActive(false);
        }

    }

}
