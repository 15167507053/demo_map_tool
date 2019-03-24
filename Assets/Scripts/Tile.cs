using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    private Text TileText;  //方块文字

    void Awake()
    {
        TileText = GetComponentInChildren<Text>();  //获取到方块的text组件
    }

    ///将坐标赋值给方块
    public void setValue(int x, int y)
    {
        TileText.text = string.Format("({0},{1})", x, y);   //方块上显示自身所处坐标
    }

    ///使用接口实现触摸侦测
    public void OnPointerEnter(PointerEventData eventData)
    {
        string s = TileText.text;   //获取到方块的内容
        Debug.Log(s);

        gameManage.myInstance.ShowToolitip(transform.position, s); //显示浮窗
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("exit");

        gameManage.myInstance.HideToolitip();   //隐藏浮窗
    }

}

