using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawns : playerinfo
{
    void start()
    {
        setposition((int)transform.position.x, (int)transform.position.y);
    }
    public override bool[,] possiblemove()
    {
        bool[,] r = new bool[80, 80];
        playerinfo p, p1;
        if (iswhite)
        {
           
            // middle first move
            if (currenty == 10)
            {
                p = GameManager.boardmanager.playerinfo[currentx, currenty + 10];
                p1 = GameManager.boardmanager.playerinfo[currentx, currenty + 20];
                if (p == null)
                {
                    r[currentx, currenty + 10] = true;
                }
                if(p1 == null)
                {
                    r[currentx, currenty + 20] = true;
                }
            }

            // middle move
            if (currenty != 10 && currenty != 70)
            {
                p = GameManager.boardmanager.playerinfo[currentx, currenty + 10];
                if (p == null)
                {
                    r[currentx, currenty + 10] = true;
                }
            }

            // diagonal right
            if (currentx != 70 && currenty != 70)
            {
                p = GameManager.boardmanager.playerinfo[currentx + 10, currenty + 10];
                if (p != null && p.iswhite == false)
                {
                    r[currentx + 10, currenty + 10] = true;
                }
            }

            //diagonal left
            if (currentx != 0 && currenty != 70)
            {
                p = GameManager.boardmanager.playerinfo[currentx - 10, currenty + 10];
                if (p != null && p.iswhite == false)
                {
                    r[currentx - 10, currenty + 10] = true;
                }
            }

        }

        else
         {
            // middle first move
            if (currenty == 60)
            {
                p = GameManager.boardmanager.playerinfo[currentx, currenty - 10];
                p1 = GameManager.boardmanager.playerinfo[currentx, currenty - 20];
                if (p == null && p1 == null)
                {
                    r[currentx, currenty - 10] = true;
                    r[currentx, currenty - 20] = true;
                }
            }

            // middle move
            if (currenty != 60 && currenty != 0)
            {
                p = GameManager.boardmanager.playerinfo[currentx, currenty - 10];
                if (p == null)
                {
                    r[currentx, currenty - 10] = true;
                }
            }

            // diagonal right
            if (currentx != 0 && currenty != 0)
            {
                p = GameManager.boardmanager.playerinfo[currentx - 10, currenty - 10];
                if (p != null && p.iswhite == true)
                {
                    r[currentx - 10, currenty - 10] = true;
                }
            }

            //diagonal left
            if (currentx != 70 && currenty != 0)
            {
                p = GameManager.boardmanager.playerinfo[currentx + 10, currenty - 10];
                if (p != null && p.iswhite == true)
                {
                    r[currentx + 10, currenty - 10] = true;
                }
            }

         }


        return r;
    }


}
