﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bishop : playerinfo
{
    void Start()
    {
        setposition((int)transform.position.x, (int)transform.position.y);
    }

    public override bool[,] possiblemove()
    {
        bool[,] r = new bool[80, 80];
        playerinfo p;
        playerinfo player = GameManager.boardmanager.playerinfo[currentx, currenty];

        // forward left moves
        if (currentx != 0 && currenty != 70)
        {
            for (int i = 10; currentx - i >= 0; i += 10)
            {
                if (currenty + i <= 70)
                {
                    p = GameManager.boardmanager.playerinfo[currentx - i, currenty + i];
                    if (p != null)
                    {
                        if (p.iswhite == !player.iswhite)
                        {
                            r[currentx - i, currenty + i] = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        r[currentx - i, currenty + i] = true;
                    }
                }
                else
                {
                    continue;
                }

            }
        }

        //forward right moves
        if (currentx != 70 && currenty != 70)
        {
            for (int i = 10; currentx + i <= 70; i += 10)
            {
                if (currenty + i <= 70)
                {
                    p = GameManager.boardmanager.playerinfo[currentx + i, currenty + i];
                    if (p != null)
                    {
                        if (p.iswhite == !player.iswhite)
                        {
                            r[currentx + i, currenty + i] = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        r[currentx + i, currenty + i] = true;
                    }
                }
                else
                {
                    continue;
                }

            }
        }

        //backward right moves
        if (currentx != 70 && currenty != 0)
        {
            for (int i = 10; currenty - i > 0; i += 10)
            {
                if (currentx + i <= 70)
                {
                    p = GameManager.boardmanager.playerinfo[currentx + i, currenty - i];
                    if (p != null)
                    {
                        if (p.iswhite == !player.iswhite)
                        {
                            r[currentx + i, currenty - i] = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        r[currentx + i, currenty - i] = true;
                    }
                }
                else
                {
                    continue;
                }

            }
        }

        //backward left moves
        if(currentx !=0 && currenty != 0)
        {
            for(int i = 10; currenty - i > 0; i += 10)
            {
                if (currentx - i >= 0)
                {
                    p = GameManager.boardmanager.playerinfo[currentx - i, currenty - i];
                    if (p != null)
                    {
                        if (p.iswhite == !player.iswhite)
                        {
                            r[currentx - i, currenty - i] = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        r[currentx - i, currenty - i] = true;
                    }
                }
                else
                {
                    continue;
                }
            }
        }

       return r;
    }

}
