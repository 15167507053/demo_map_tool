using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]             //在编辑模式下执行
[AddComponentMenu("Layout/Auto Grid Layout Group", 152)]    //[添加组件菜单（“布局/自动网格布局组”，152）

public class AutoGridLayout : GridLayoutGroup
{
    public static int m_Column = 1, m_Row = 1;  //行数与列数

    //计算水平布局输入
    public override void CalculateLayoutInputHorizontal()
    {
        //调用基类上已被其他方法重写的方法
        base.CalculateLayoutInputHorizontal();
        //如果没有这一行 那么只会生成一个方块

        //计算出可用于填充的空白部分的尺寸（从整体中减去方块间的间距和填充）
        float fHeight = (rectTransform.rect.height - ((m_Row - 1) * (spacing.y))) - ((padding.top + padding.bottom));
        //高 = （整体高 -（行数 * 纵向间距）） - （上/下 填充）
        float fWidth = (rectTransform.rect.width - ((m_Column - 1) * (spacing.x))) - ( (padding.right + padding.left));
        //宽 = （整体宽 -（列数 - 横向间距）） - （左/右 填充）

        //计算单个方块的尺寸 并将计算出来的尺寸赋值给方块
        Vector2 vSize = new Vector2(fWidth / m_Column, (fHeight) / m_Row);  //方块宽 = 空余宽 / 列数， 方块高 = 空余高 / 行数
        cellSize = vSize;
    }
}
