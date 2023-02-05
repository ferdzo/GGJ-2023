using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disaster : MonoBehaviour
{

    [SerializeField] protected GameObject tile2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ApplyDisaster(GameObject n)
    {

        Vector3 pos = n.transform.position;

        Destroy(n);
        GameObject nov = Instantiate(tile2, pos, Quaternion.identity);
        nov.name = n.name;

        //nov.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    GameObject GetObjectOnClick()
    {
        RaycastHit mtInfo = new RaycastHit();
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out mtInfo))
            {
                //Debug.Log("It's working");
                //Debug.Log(mtInfo.transform.parent.gameObject.name);
                return mtInfo.transform.parent.gameObject;
            }
        }
        return null;
    }

}
