using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public playerinfo[,] playerinfo;
    private playerinfo player;
    private bool[,] allowedmoves;
    private string activepiece = "white";
    public static GameManager boardmanager { set; get; }
    public bool Iswhite = true;
    private bool selected = false;
    private bool ismove = false;
    private GameObject lastselect;
    public List<GameObject> chessprefap;
    private List<GameObject> activechessprefap;
    

    private void Start()
    {
        boardmanager = this;
        placeallchessman();
    }

    private void Update()
    {
        selectchessman();
        movechessman();
        
    }

    public void selectchessman()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
            if (hit)
            {
                if (hit.transform.gameObject.tag != "allowed")
                {
                    if (ismove == false)
                    {
                        Highlight.instance.hidehighlight();
                    }
                }
            }
            if (selected == true)
            {
                lastselect.GetComponent<SpriteRenderer>().color = Color.white;
            }
            if (hit)
            {
                if (hit.transform.gameObject.tag == activepiece )
                {
                    if (playerinfo[(int)hit.transform.gameObject.transform.position.x, (int)hit.transform.gameObject.transform.position.y])
                    {
                        hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
                        lastselect = hit.transform.gameObject;
                        player = playerinfo[(int)lastselect.transform.position.x, (int)lastselect.transform.position.y];
                        selected = true;
                        ismove = false;
                        allowedmoves = playerinfo[(int)lastselect.transform.position.x, (int)lastselect.transform.position.y].possiblemove();
                        Highlight.instance.highlightallowedmoves(allowedmoves);
                    }
                }
                else return;
            }
            else return;
        }
    }

    public void movechessman()
    {
        playerinfo p;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit1 = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
            if (hit1)
            {
                if (hit1.transform.gameObject.tag == "allowed" && ismove == false)
                {
                    p = playerinfo[(int)hit1.transform.gameObject.transform.position.x, (int)hit1.transform.gameObject.transform.position.y];
                    if (p != null)
                    {
                        if (p != null && p.iswhite != Iswhite)
                        {
                            Destroy(p.gameObject);
                        }
                    }
                    playerinfo[player.currentx, player.currenty] = null;
                    lastselect.transform.position = hit1.transform.gameObject.transform.position;
                    playerinfo[(int)hit1.transform.gameObject.transform.position.x, (int)hit1.transform.gameObject.transform.position.y] = player;
                    player.currentx = (int)hit1.transform.gameObject.transform.position.x;
                    player.currenty = (int)hit1.transform.gameObject.transform.position.y;
                    Iswhite = !Iswhite;
                    Highlight.instance.hidehighlight();
                    if (activepiece == "white")
                    {
                        activepiece = "black";
                    }
                    else
                    {
                        activepiece = "white";
                    }
                }
            }
        }
    }
   
    private void placechessmens(int index,Vector2 pos)
    {
        GameObject go = Instantiate(chessprefap[index], pos, Quaternion.identity) as GameObject;
        go.transform.SetParent(transform);
        playerinfo[(int)pos.x, (int)pos.y] = go.GetComponent<playerinfo>();
        playerinfo[(int)pos.x, (int)pos.y].setposition((int)pos.x, (int)pos.y);
        activechessprefap.Add(go);
    }

    private void placeallchessman()
    {
        activechessprefap = new List<GameObject>();
        playerinfo = new playerinfo[80, 80];

        // placing white piece.
        placechessmens(4, Vector2.zero);
        placechessmens(3, new Vector2(10,0));
        placechessmens(2, new Vector2(20,0));
        placechessmens(0, new Vector2(30,0));
        placechessmens(1, new Vector2(40,0));
        placechessmens(4, new Vector2(70,0));
        placechessmens(3, new Vector2(60,0));
        placechessmens(2, new Vector2(50,0));
        placechessmens(5, new Vector2(0, 10));
        placechessmens(5, new Vector2(10, 10));
        placechessmens(5, new Vector2(20, 10));
        placechessmens(5, new Vector2(30, 10));
        placechessmens(5, new Vector2(40, 10));
        placechessmens(5, new Vector2(50, 10));
        placechessmens(5, new Vector2(60, 10));
        placechessmens(5, new Vector2(70, 10));
        
        // placing black piece.
        placechessmens(10, new Vector2(0,70));
        placechessmens(8, new Vector2(10,70));
        placechessmens(6, new Vector2(20,70));
        placechessmens(9, new Vector2(30,70));
        placechessmens(7, new Vector2(40,70));
        placechessmens(10, new Vector2(70,70));
        placechessmens(8, new Vector2(60,70));
        placechessmens(6, new Vector2(50,70));
        placechessmens(11, new Vector2(0,60));
        placechessmens(11, new Vector2(10,60));
        placechessmens(11, new Vector2(20,60));
        placechessmens(11, new Vector2(30,60));
        placechessmens(11, new Vector2(40,60));
        placechessmens(11, new Vector2(50,60));
        placechessmens(11, new Vector2(60,60));
        placechessmens(11, new Vector2(70,60));
    }
}
