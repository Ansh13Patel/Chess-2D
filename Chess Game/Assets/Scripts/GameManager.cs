using Google.Protobuf.WellKnownTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public int[] enpassent;
    public bool specialmove = true;
    private bool gameover = false;
    private GameObject lastselect;
    public GameObject whitewin;
    public GameObject blackwin;
    public List<GameObject> chessprefap;
    private List<GameObject> activechessprefap;
    

    private void Start()
    {
        enpassent = new int[2] { -1, -1 };
        boardmanager = this;
        placeallchessman();
    }

    private void Update()
    {
        if (gameover == false)
        {
            selectchessman();
            movechessman();
        }
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
                    if (hit.transform.gameObject.tag == activepiece)
                    {
                        if (playerinfo[(int)hit.transform.gameObject.transform.position.x, (int)hit.transform.gameObject.transform.position.y])
                        {

                            hit.transform.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
                            lastselect = hit.transform.gameObject;
                            player = playerinfo[(int)lastselect.transform.position.x, (int)lastselect.transform.position.y];
                            allowedmoves = playerinfo[(int)lastselect.transform.position.x, (int)lastselect.transform.position.y].possiblemove();
                            selected = true;
                            ismove = false;
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
                    // captaure gameobject
                    p = playerinfo[(int)hit1.transform.gameObject.transform.position.x, (int)hit1.transform.gameObject.transform.position.y];
                    if (p != null)
                    {
                        if(p.GetType() == typeof(king))
                        {
                            // GameOver
                            gameover = true;
                            if (p.iswhite)
                            {
                                whitewin.SetActive(true);
                            }
                            else
                            {
                                blackwin.SetActive(true);
                            }
                        }
                        if (p != null && p.iswhite != Iswhite)
                        {
                            activechessprefap.Remove(p.gameObject);
                            Destroy(p.gameObject);
                        }
                    }

                    // capture pawns by Enpassent move.
                    if(enpassent[0] == (int)hit1.transform.gameObject.transform.position.x && enpassent[1] == (int)hit1.transform.gameObject.transform.position.y)
                    {
                        if (Iswhite)
                        {
                            p = playerinfo[(int)hit1.transform.gameObject.transform.position.x, (int)hit1.transform.gameObject.transform.position.y - 10];
                        }
                        else
                        {
                            p = playerinfo[(int)hit1.transform.gameObject.transform.position.x, (int)hit1.transform.gameObject.transform.position.y + 10];
                        }
                        Destroy(p.gameObject);
                    }
                    enpassent[0] = -1;
                    enpassent[1] = -1;

                    // enpassent move
                    if(player.GetType ()== typeof(pawns))
                    {
                        if ((int)hit1.transform.gameObject.transform.position.y == 70)
                        {
                            activechessprefap.Remove(player.gameObject);
                            Destroy(player.gameObject);
                            placechessmens(0,new Vector2((int)hit1.transform.gameObject.transform.position.x, (int)hit1.transform.gameObject.transform.position.y),0);
                            player = playerinfo[(int)hit1.transform.gameObject.transform.position.x, (int)hit1.transform.gameObject.transform.position.y];
                            lastselect = player.gameObject;
                        }
                        else if ((int)hit1.transform.gameObject.transform.position.y == 0)
                        {
                            activechessprefap.Remove(player.gameObject);
                            Destroy(player.gameObject);
                            placechessmens(9, new Vector2((int)hit1.transform.gameObject.transform.position.x, (int)hit1.transform.gameObject.transform.position.y),180);
                            player = playerinfo[(int)hit1.transform.gameObject.transform.position.x, (int)hit1.transform.gameObject.transform.position.y];
                            lastselect = player.gameObject;
                        }
                        if (player.currenty== 10 && (int)hit1.transform.gameObject.transform.position.y == 30)
                        {
                            enpassent[0] = (int)hit1.transform.gameObject.transform.position.x;
                            enpassent[1] = (int)hit1.transform.gameObject.transform.position.y - 10;
                        }
                        else if (player.currenty == 60 && (int)hit1.transform.gameObject.transform.position.y == 40)
                        {
                            enpassent[0] = (int)hit1.transform.gameObject.transform.position.x;
                            enpassent[1] = (int)hit1.transform.gameObject.transform.position.y + 10;
                        }
                       
                    }

                    
                    // spawn rook and king.
                    if(specialmove == true)
                    {
                        if(player.GetType() == typeof(king))
                        {
                           if((int)hit1.transform.gameObject.transform.position.x == player.currentx +20 || (int)hit1.transform.gameObject.transform.position.x == player.currentx - 20)
                            {
                                    if((int)hit1.transform.gameObject.transform.position.x == player.currentx - 20)
                                    {
                                        playerinfo[0, player.currenty].gameObject.transform.position = new Vector3(30, player.currenty, 0);
                                    }
                                    else
                                    {
                                        playerinfo[70, player.currenty].gameObject.transform.position = new Vector3(50, player.currenty, 0);
                                    }
                            }
                        }
                    }

                    playerinfo[player.currentx, player.currenty] = null;
                    lastselect.transform.position = hit1.transform.gameObject.transform.position;

                    // special move.
                    if (player.GetType() == typeof(rook) || player.GetType() == typeof(king))
                    {
                        specialmove = false;
                    }

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
   
    private void placechessmens(int index,Vector2 pos,float r)
    {
        GameObject go = Instantiate(chessprefap[index], pos, Quaternion.Euler(r,0f,0f)) as GameObject;
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
        placechessmens(4, Vector2.zero,0);
        placechessmens(3, new Vector2(10,0),0);
        placechessmens(2, new Vector2(20,0), 0);
        placechessmens(0, new Vector2(30,0), 0);
        placechessmens(1, new Vector2(40,0), 0);
        placechessmens(4, new Vector2(70,0), 0);
        placechessmens(3, new Vector2(60,0), 0);
        placechessmens(2, new Vector2(50,0), 0);
        placechessmens(5, new Vector2(0, 10), 0);
        placechessmens(5, new Vector2(10, 10), 0);
        placechessmens(5, new Vector2(20, 10), 0);
        placechessmens(5, new Vector2(30, 10), 0);
        placechessmens(5, new Vector2(40, 10), 0);
        placechessmens(5, new Vector2(50, 10), 0);
        placechessmens(5, new Vector2(60, 10), 0);
        placechessmens(5, new Vector2(70, 10), 0);
        
        // placing black piece.
        placechessmens(10, new Vector2(0,70),180);
        placechessmens(8, new Vector2(10,70), 180);
        placechessmens(6, new Vector2(20,70), 180);
        placechessmens(9, new Vector2(30,70), 180);
        placechessmens(7, new Vector2(40,70), 180);
        placechessmens(10, new Vector2(70,70), 180);
        placechessmens(8, new Vector2(60,70), 180);
        placechessmens(6, new Vector2(50,70), 180);
        placechessmens(11, new Vector2(0,60), 180);
        placechessmens(11, new Vector2(10,60), 180);
        placechessmens(11, new Vector2(10,60), 180);
        placechessmens(11, new Vector2(10,60), 180);
        placechessmens(11, new Vector2(20,60), 180);
        placechessmens(11, new Vector2(30,60), 180);
        placechessmens(11, new Vector2(40,60), 180);
        placechessmens(11, new Vector2(50,60), 180);
        placechessmens(11, new Vector2(60,60), 180);
        placechessmens(11, new Vector2(70,60), 180);
    }
}
