using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] protected GameObject tile;
    [SerializeField] protected GameObject tile1;
    [SerializeField] protected GameObject select;
    private GameObject selectInst;
    [SerializeField] protected GameObject loader;
    [SerializeField] protected int x;
    [SerializeField] protected int y;
    [SerializeField] protected List<GameObject> Buildings = new List<GameObject>();

    List<Tile_c> TileList = new List<Tile_c>();

    void Start()
    {
        DrawGrid();
        select.SetActive(true);
        selectInst = Instantiate(select, Vector3.zero, Quaternion.identity);
    }

    void Update()
    {

        GameObject n = GetObjectOnClick();

        AddTile(n);

        Hover();

    }
    void AddTile(GameObject n)
    {
        if (n != null)
        {

            if (!TileInList(n))
            {
                TileObjectToList(n);
            }
        }

        for (int i = TileList.Count - 1; i >= 0; i--)
        {
            if (TileList[i].tile != null)
            {
                TileList[i].timer += Time.deltaTime;

                if (TileList[i].timer >= 0.5f)
                {
                    Destroy(TileList[i].loader);
                    ChangeTile(TileList[i].tile);
                    TileList.RemoveAt(i);
                }
            }
            else
            {
                TileList.RemoveAt(i);
            }
        }
    }

    bool TileInList(GameObject t)
    {
        foreach (Tile_c item in TileList)
        {
            if (t == item.tile)
            {
                return true;
            }
        }

        return false;
    }
    void TileObjectToList(GameObject n) {
        Tile_c t = new Tile_c();
        t.tile = n;
        t.loader = Loader(n);
        TileList.Add(t);
    }
    void ChangeTile(GameObject n)
    {

        Vector3 pos = n.transform.position;

        Destroy(n);
        GameObject nov = Instantiate(tile1, pos, Quaternion.identity);
        nov.name = n.name;

    }

    GameObject GetObjectOnClick()
    {
        RaycastHit mtInfo = new RaycastHit();
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out mtInfo))
            {
                return mtInfo.transform.parent.gameObject;
            }
        }
        return null;
    }

    void Hover()
     {
         RaycastHit mtInfo = new RaycastHit();
         if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out mtInfo))
         {
            selectInst.SetActive(true);
            selectInst.transform.position = mtInfo.transform.parent.gameObject.transform.position;
            
         }
         else
        {
            selectInst.SetActive(false);
        }

    }
    GameObject Loader(GameObject n)
    {
        Vector3 pos = n.transform.position;
        GameObject nov = Instantiate(loader, pos, Quaternion.identity);

        return nov;

    }

    Vector3 RandomCoords()
    { 
        Vector3 coord = new Vector3(Random.Range(0,x), 0, Random.Range(0,y));

        return coord;
    }

    void DrawGrid()
    {
        Vector3 houseCoord = RandomCoords();

        for (float i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            { 
                GameObject t = Instantiate(tile, new Vector3(i, 0, j), Quaternion.identity);
                t.name = i.ToString() + "x" + j.ToString();
            }
                
            }
        DrawCity();

        }

    GameObject h;
    void DrawCity() {
        
        Vector3 BuildingCoord = RandomCoords();
        GameObject t = Instantiate(Buildings[1], BuildingCoord, Quaternion.identity);
        List<GameObject> houses = new List<GameObject>();
       
        t.name = BuildingCoord.x.ToString() + "x" + BuildingCoord.z.ToString();
        for (int i = 0; i < x; i++) {
            for (int j = 0; j < y; j++) {
                if (BuildingCoord.x == i || BuildingCoord.x == i+1 || BuildingCoord.x == i-1)
                {
                    if (BuildingCoord.z == j || BuildingCoord.z == j + 1 || BuildingCoord.z == j - 1)
                        h = Instantiate(Buildings[1], new Vector3(i, 0,j), Quaternion.identity);
                        h.name = i.ToString() + "x" + j.ToString();
                        Debug.Log(h.name);
                        
                        houses.Add(h);
                }
               
            }
        }
       
    }

     
}

public class Tile_c
{
    public GameObject tile;
    public float timer;
    public GameObject loader;

}


