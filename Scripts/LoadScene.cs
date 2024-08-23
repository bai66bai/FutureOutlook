using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public RectTransform RectTransform;
    public List<TextMeshProUGUI> Texts;
    public Turnthepage Turnthepage;
    public CtrImgMove CtrImgMove;
    private Item item;
    public void ChangeItem(Item Item)
    {
        item = Item;
        RectTransform.localPosition = item.XLoclpostion;
        CtrImgMove.nowIndex = item.IdentificationIndex;
        Turnthepage.changBtn();
        ChangeTextColor(item.IdentificationIndex);
    }
    

    public void ChangeTextColor(int cindex)
    {
        Texts.ForEach(text =>
        {
            int index = cindex == 4 ? cindex - 1 : cindex;
            if (Texts.IndexOf(text) == index)
            {
                text.color = new Color(3 / 255f, 117 / 255f, 230 / 255f);
            }
            else
            {
                text.color = new Color(128 / 255f, 128 / 255f, 128 / 255f);
            }
        });
    }
}