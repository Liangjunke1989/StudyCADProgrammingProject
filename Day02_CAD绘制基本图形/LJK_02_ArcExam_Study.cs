using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;

namespace Day02_CAD绘制基本图形
{
    public class LJK_02_ArcExam_Study
    {
        [CommandMethod("TestArcDemo")]
        public void TestArcDemo()
        {
            //圆弧的几个名词
            //Angle:角； Degree：角度； Radian:弧度； Radius:半径
            Arc arc01 = new Arc();
            arc01.Center = new Point3d(-200, -200, 0);
            arc01.StartAngle = -Math.PI / 2;                                          //CAD此时的角度采用的是弧度值
            arc01.EndAngle = Math.PI / 2;
            arc01.Radius = 200; //半径为200的弧度

            Arc arc02 = new Arc(new Point3d(0,0,0), 200, -Math.PI / 4, Math.PI/6);
            Arc arc03 = new Arc(new Point3d(300, 300, 0), new Vector3d(0, 0, 1), 200, -Math.PI / 2, Math.PI / 4);
            Arc arc04 = new Arc(new Point3d(600, 600, 0), 200, -Math.PI / 3, Math.PI / 3);

            Database db = HostApplicationServices.WorkingDatabase;
            db.AddEntitiesToModelSpace(arc01, arc02, arc03, arc04);
            Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
            editor.WriteMessage("----------测试完成！！！----------");
        }
    }
}
