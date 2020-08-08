using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rook : playerinfo
{
    private void Start()
    {
        setposition((int)transform.position.x, (int)transform.position.y);
    }
    
    public override bool[,] possiblemove()
    {
        playerinfo p;
        playerinfo player = GameManager.boardmanager.playerinfo[currentx, currenty];
        bool[,] r = new bool[80, 80];

        // left move and forward move.
        if (currentx <= 70 && currentx >=0)
        {
            for (int i = 10; currentx-i >= 0; i += 10)
            {
                p = GameManager.boardmanager.playerinfo[currentx-i,currenty];
                if (p != null)
                {
                    if (p.iswhite == !player.iswhite)
                    {
                        r[currentx-i, currenty] = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    r[currentx-i, currenty] = true;
                }
            }
            for (int i = 10; currenty+i <= 70; i += 10)
            {
                p = GameManager.boardmanager.playerinfo[currentx, currenty+i];
                if (p !=null)
                {
                    if (p.iswhite == !player.iswhite)
                    {
                        r[currentx, currenty+i] = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    r[currentx, currenty+i] = true;
                }
            }
        }

        //right move.
        if(currentx !=70)
        {
            for (int i = 10; currentx+i <= 70; i += 10)
            {
                p = GameManager.boardmanager.playerinfo[currentx+i, currenty];
                if (p != null)
                {
                    if (p.iswhite == !player.iswhite)
                    {
                        r[currentx+i, currenty] = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    r[currentx+i, currenty] = true;
                }
            }
        }
 
        // backward move.
        if(currenty!=0)
        {
            for (int i = 10; currenty - i >= 0; i += 10)
            {
                p = GameManager.boardmanager.playerinfo[currentx, currenty-i];
                if (p != null)
                {
                    if (p.iswhite == !player.iswhite)
                    {
                        r[currentx, currenty-i] = true;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    r[currentx, currenty-i] = true;
                }
            }
        }

       return r;
    } 

}
