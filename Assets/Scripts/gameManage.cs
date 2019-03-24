using UnityEngine;
using UnityEngine.UI;
using System;

public class gameManage : MonoBehaviour
{
    public int rows = 0;         //棋盘行数
    public int cols = 0;         //棋盘列数

    public Canvas gameCanvas;       //游戏显示面板
    public GameObject wallPrefab;   //背景墙预置体

    [SerializeField]
    private GameObject tooltip;     //信息浮窗

    public static gameManage myInstance;    //实例化自身供子组件的脚本调用

    private void Awake()
    {
        myInstance = this;
    }

    ///建造按钮
    public void CreateBtn()
    {
        //删除上一个表格
        if(rows != 0 && cols != 0)
        {
            //收集gameCanvas下的子对象
            GameObject obj = transform.Find("gameCanvas").gameObject;
            //使用遍历进行删除
            foreach (Transform child in obj.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        //获取到两个InputField里的字段 并将其转换为数字赋值给rows和cols
        rows = Int32.Parse(GameObject.Find("rows").GetComponent<InputField>().text);
        cols = Int32.Parse(GameObject.Find("cols").GetComponent<InputField>().text);
        AutoGridLayout.m_Column = cols;
        AutoGridLayout.m_Row = rows;

        //根据rows和clos的值创建列表
        CreateWalls();
    }

    ///生成游戏的背景墙
    private void CreateWalls()
    {
        for (int x = rows-1; x >= 0; x--)  //为了让左下角成为（0，0） 因此x使用递减遍历
        {
            for (int y = 0; y < cols; y++)
            {
                //通过预置体对象生成
                GameObject instance = Instantiate(wallPrefab) as GameObject;
                //把它设置在游戏面板上
                instance.transform.SetParent(gameCanvas.transform, false);

                //在方块的文本中显示其所在的坐标(x,y)
                Tile tile = (Tile)instance.GetComponent(typeof(Tile));
                tile.setValue(x, y);
            }
        }
    }

    ///显示和隐藏信息浮窗
    public void ShowToolitip(Vector3 position, string s)
    {
        tooltip.SetActive(true);                                        //显示浮窗可见
        tooltip.transform.position = position;                          //指定浮窗的位置
        tooltip.GetComponentInChildren<Text>().text = "pos:" + s;       //设置信息窗的文字
    }
    public void HideToolitip()
    {
        //关闭信息浮窗
        tooltip.SetActive(false);
    }

}
