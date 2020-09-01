using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class king : playerinfo
{
    
    void Start()
    {
        setposition((int)transform.position.x, (int)transform.position.y);  
    }

    public override bool[,] possiblemove()
    {
        playerinfo p;
        playerinfo player = GameManager.boardmanager.playerinfo[currentx, currenty];
        bool[,] r = new bool[80, 80];

        // special move.
        if (GameManager.boardmanager.specialmove == true)
        {
            playerinfo p1, p2, p3, p4;
            if (currenty == 0) 
            {
                p =  GameManager.boardmanager.playerinfo[currentx - 10, currenty];
                p1 = GameManager.boardmanager.playerinfo[currentx - 20, currenty];
                p2 = GameManager.boardmanager.playerinfo[currentx - 30, currenty];
                p3 = GameManager.boardmanager.playerinfo[currentx + 10, currenty];
                p4 = GameManager.boardmanager.playerinfo[currentx + 20, currenty];
                if(p==null && p1 == null && p2 == null )
                {
                    r[currentx - 20, currenty] = true;
                }
                if (p3 == null && p4 == null)
                {
                    r[currentx + 20, currenty] = true;
                }

            }
            else if(currenty == 70)
            {
                p =  GameManager.boardmanager.playerinfo[currentx - 10, currenty];
                p1 = GameManager.boardmanager.playerinfo[currentx - 20, currenty];
                p2 = GameManager.boardmanager.playerinfo[currentx - 30, currenty];
                p3 = GameManager.boardmanager.playerinfo[currentx + 10, currenty];
                p4 = GameManager.boardmanager.playerinfo[currentx + 20, currenty];
                if (p == null && p1 == null && p2 == null)
                {
                    r[currentx - 20, currenty] = true;
                }
                if (p3 == null && p4 == null)
                {
                    r[currentx + 20, currenty] = true;
                }

            }
        }

        // forward move.
        if(currenty !=70)
        {
            p = GameManager.boardmanager.playerinfo[currentx, currenty + 10];
            if (p != null)
            {
                if (p.iswhite == !player.iswhite)
                {
                    r[currentx, currenty + 10] = true; 
                }
            }
            else
            {
                r[currentx, currenty + 10] = true;
            }
        }

        // backward move.
        if(currenty != 0)
        {
            p = GameManager.boardmanager.playerinfo[currentx, currenty - 10];
            if (p != null)
            { 
                if (p.iswhite == !player.iswhite)
                {
                    r[currentx, currenty - 10] = true;
                }            
            }
            else
            {
                r[currentx, currenty - 10] = true;
            }
        }

        // left move.
        if(currentx != 0)
        {
            p = GameManager.boardmanager.playerinfo[currentx-10, currenty];
            if (p != null)
            {
                if (p.iswhite == !player.iswhite)
                {
                    r[currentx - 10, currenty] = true;
                }
            }
            else
            {
                r[currentx - 10, currenty] = true;
            }
        }

        // right move.
        if (currentx != 70)
        {
            p = GameManager.boardmanager.playerinfo[currentx + 10, currenty];
            if (p != null)
            {
                if (p.iswhite == !player.iswhite)
                {
                    r[currentx + 10, currenty] = true;
                }
            }
            else
            {
                r[currentx + 10, currenty] = true;
            }
        }

        // forward and backward right diagonal move.
        if (currentx != 70)
        {
            // forward right diagonal move.
            if (currenty != 0)
            {
                p = GameManager.boardmanager.playerinfo[currentx + 10, currenty - 10];
                if (p != null)
                {
                    if (p.iswhite == !player.iswhite)
                    {
                        r[currentx + 10, currenty - 10] = true;
                    }
                }
                else
                {
                    r[currentx + 10, currenty - 10] = true;
                }
            }

            // backward right diagonal move.
            if (currenty != 70)
            {
                p = GameManager.boardmanager.playerinfo[currentx + 10, currenty + 10];
                if (p != null)
                {
                    if (p.iswhite == !player.iswhite)
                    {
                        r[currentx + 10, currenty + 10] = true;
                    }
                }
                else
                {
                    r[currentx + 10, currenty + 10] = true;
                }
            }

        }

        // forward and backward left diagonal move.
        if (currentx != 0)
        {
            // forward left diagonal move.
            if (currenty != 0)
            {
                p = GameManager.boardmanager.playerinfo[currentx - 10, currenty - 10];
                if (p != null)
                {
                    if (p.iswhite == !player.iswhite)
                    {
                        r[currentx - 10, currenty - 10] = true;
                    }
                }
                else
                {
                    r[currentx - 10, currenty - 10] = true;
                }
            }

            // backward left diagonal move.
            if (currenty != 70)
            {
                p = GameManager.boardmanager.playerinfo[currentx - 10, currenty + 10];
                if (p != null)
                {
                    if (p.iswhite == !player.iswhite)
                    {
                        r[currentx - 10, currenty + 10] = true;
                    }
                }
                else
                {
                    r[currentx - 10, currenty + 10] = true;
                }
            }

        }

         return r;
    }
    
}
