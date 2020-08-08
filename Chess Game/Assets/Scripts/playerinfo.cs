using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class playerinfo : MonoBehaviour
{
    public bool iswhite;
    public int currentx { set; get; }
    public int currenty { set; get; }

    public void setposition(int x, int y)
    {
        currentx = x;
        currenty = y;
    }
    public virtual bool[,] possiblemove()
    {
        return new bool[80, 80];
    }
}
