using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02_CAD绘制基本图形
{
    public static class LJK_BaseTool
    {
        /// <summary>
        /// 角度值转成弧度值
        /// </summary>
        /// <param name="degree">角度值</param>
        /// <returns>弧度值</returns>
        public static double DegreeToRadian(this Double degree)//Angle:角度； Degree：度； Radian:弧度
        {

            return degree * Math.PI / 180;
        }

        /// <summary>
        /// 弧度值转成角度值
        /// </summary>
        /// <param name="radian">弧度值</param>
        /// <returns>角度值</returns>
        public static double RadianToDegree(this Double radian)//Angle:角； Degree：角度； Radian:弧度； Radius:半径
        {

            return radian * 180 / Math.PI;
        }
    }
}
