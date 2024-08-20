using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Turnthepage : MonoBehaviour
{

    public List<GameObject> Btns;

    public CtrImgMove ctrImgMove;

    private Image[] Lefts;
    private Image[] Rights;
    private int endIndex;
    private void Start()
    {
        endIndex = (int) ctrImgMove.swipeArea.rect.width / ctrImgMove.MovingDistance;
        Lefts = Btns[0].GetComponentsInChildren<Image>();
        Rights = Btns[1].GetComponentsInChildren<Image>();
        changBtn();

    }
    public void Left()
    {
        ctrImgMove.ToRight();
    }

    public void Right()
    {
        ctrImgMove.ToLeft();
    }


    public void changBtn()
    {
        int index = ctrImgMove.nowIndex;
        ChangeBtnColor(index);

    }

    public void ChangeBtnColor(int index)
    {
        
        if (index == 0 && index != endIndex - 1)
        {
            Lefts[1].enabled = false;
            Lefts[2].enabled = true;
            Rights[1].enabled = true;
            Rights[2].enabled = false;
        }
        else if (index > 0 && index < endIndex - 1)
        {
            Lefts[1].enabled = true;
            Lefts[2].enabled = false;
            Rights[1].enabled = true;
            Rights[2].enabled = false;
        }
        else if (index == endIndex - 1)
        {
            Lefts[1].enabled = true;
            Lefts[2].enabled = false;
            Rights[1].enabled = false;
            Rights[2].enabled = true;
        }
        else if (index == endIndex - 1)
        {
            Lefts[1].enabled = false;
            Lefts[2].enabled = true;
            Rights[1].enabled = false;
            Rights[2].enabled = true;
        }
    }


}