using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight : playerinfo
{

    void Start()
    {
        setposition((int)transform.position.x, (int)transform.position.y);
    }


    public override bool[,] possiblemove()
    {
        playerinfo p;
        playerinfo player = GameManager.boardmanager.playerinfo[(int)transform.position.x,(int)transform.position.y];
        bool[,] r = new bool[80, 80];

        //right forward move in y-axis.
        if (currentx != 0 && currenty != 60 && currenty != 70)
        {
            p = GameManager.boardmanager.playerinfo[currentx - 10, currenty + 20];
            if (p != null) 
            {
                if (p.iswhite == !player.iswhite)
                {
                    r[currentx - 10, currenty + 20] = true;
                }
            }
            else
            {
                r[currentx - 10, currenty + 20] = true;
            }
        }

        //left forward move in y-axis.
        if(currentx != 70 && currenty != 60 && currenty != 70)
        {
            p = GameManager.boardmanager.playerinfo[currentx + 10, currenty + 20];
            if (p != null)
            {
                if (p.iswhite == !player.iswhite)
                {
                    r[currentx + 10, currenty + 20] = true;
                }
            }
            else
            {
                r[currentx + 10, currenty + 20] = true;
            }
        }

        //right backward move in y-axis.
        if (currentx != 0 && currenty != 0 && currenty !=10)
        {
            p = GameManager.boardmanager.playerinfo[currentx - 10, currenty - 20];
            if (p != null)
            {
                if (p.iswhite == !player.iswhite)
                {
                    r[currentx - 10, currenty - 20] = true;
                }
            }
            else
            {
                r[currentx - 10, currenty - 20] = true;
            }
        }

        //left backward move in y-axis.
        if (currentx != 70 && currenty != 0 && currenty !=10)
        {
            p = GameManager.boardmanager.playerinfo[currentx + 10, currenty - 20];
            if (p != null)
            {
                if (p.iswhite == !player.iswhite)
                {
                    r[currentx + 10, currenty - 20] = true;
                }
            }
            else
            {
                r[currentx + 10, currenty - 20] = true;
            }
        }

        //left forward move in x- axis.
        if(currentx != 0 && currentx != 10 && currenty != 70)
        {
            p = GameManager.boardmanager.playerinfo[currentx - 20, currenty + 10];
            if (p != null)
            {
                if (p.iswhite == !player.iswhite)
                {
                    r[currentx - 20, currenty + 10] = true;
                }
            }
            else
            {
                r[currentx - 20, currenty + 10] = true;
            }
        }

        //right forward move in x- axis.
        if (currentx != 60 && currentx != 70  && currenty != 70)
        {
            p = GameManager.boardmanager.playerinfo[currentx + 20, currenty + 10];
            if (p != null)
            {
                if (p.iswhite == !player.iswhite)
                {
                    r[currentx + 20, currenty + 10] = true;
                }
            }
            else
            {
                r[currentx + 20, currenty + 10] = true;
            }
        }

        //left backward move in x- axis.
        if (currentx != 0 && currentx != 10 && currenty != 0)
        {
            p = GameManager.boardmanager.playerinfo[currentx - 20, currenty - 10];
            if (p != null)
            {
                if (p.iswhite == !player.iswhite)
                {
                    r[currentx - 20, currenty - 10] = true;
                }
            }
            else
            {
                r[currentx - 20, currenty - 10] = true;
            }
        }

        //right backward move in x- axis.
        if (currentx != 60 && currentx != 70 && currenty != 0)
        {
            p = GameManager.boardmanager.playerinfo[currentx + 20, currenty - 10];
            if (p != null)
            {
                if (p.iswhite == !player.iswhite)
                {
                    r[currentx + 20, currenty - 10] = true;
                }
            }
            else
            {
                r[currentx + 20, currenty - 10] = true;
            }
        }

      return r;
    }
}
