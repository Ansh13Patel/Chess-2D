using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public static Highlight instance { set; get; }
    public GameObject highlightprefap;
    private List<GameObject> highlights;
    

    void Start()
    {
        instance = this;
        highlights = new List<GameObject>();
    }

    public GameObject gethighlight()
    {
        GameObject go;
        go = Instantiate(highlightprefap);
        highlights.Add(go);
        return go;
    }

    public void highlightallowedmoves(bool[,] moves)
    {
        for(int i = 0; i < 80; i++)
        {
            for (int j = 0; j < 80; j++)
            {
                if (moves[i,j])
                {
                    GameObject go = gethighlight();
                    go.transform.position = new Vector2(i, j);
                }
            }
        }
    }

    public void hidehighlight()
    {
        foreach(GameObject go in highlights)
        {
            Destroy(go);
        }
    }
}
