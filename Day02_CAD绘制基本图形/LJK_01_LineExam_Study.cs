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

    public class LJK_01_LineExam_Study
    {
        [CommandMethod("TestDrawOneLine")]
        public void TestDrawOneLineDemo00()
        {
            Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
            editor.WriteMessage("--LJK,开始测试！！！---");
            //------------------------------------------测试一---------------------------------------------
            Line line01 = new Line(new Point3d(100, 100, 0), new Point3d(200, 100, 0));
            Database db = HostApplicationServices.WorkingDatabase;
            //ObjectId entityId = LJK_AddEntityTool.AddEntityToModelSpace(db,line01);//使用静态类的静态方法
            ObjectId entityId = db.AddEntityToModelSpace(line01);//使用拓展方法
            editor.WriteMessage("---"+line01.BlockName+"已经绘制完成！！！LJK---");
        }

        [CommandMethod("TestDrawMultiSegmentLine01")]
        public void TestDrawMultiSegmentLineDemo01()
        {
            Database db = HostApplicationServices.WorkingDatabase;
            Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
            //------------------------------------------测试二---------------------------------------------
            Line line02 = new Line(new Point3d(0, 0, 0), new Point3d(500, 500, 0));
            Line line03 = new Line(new Point3d(500, 500, 0), new Point3d(500, 0, 0));
            Line line04 = new Line(new Point3d(500, 0, 0), new Point3d(0, 0, 0));
            List<ObjectId> ids01 = db.AddEntityToModelSpace01(line02, line03, line04);
            editor.WriteMessage("----使用集合的方式，三条线段完成绘制！！！LJK，测试完成！---");
        }

        [CommandMethod("TestDrawMultiSegmentLine02")]
        public void TestDrawMultiSegmentLineDemo02()
        {
            Database db = HostApplicationServices.WorkingDatabase;
            Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
            //------------------------------------------测试三---------------------------------------------
            Line line05 = new Line(new Point3d(500, 500, 0), new Point3d(1500, 500, 0));
            Line line06 = new Line(new Point3d(1500, 500, 0), new Point3d(1500, 1000, 0));
            Line line07 = new Line(new Point3d(1500, 1000, 0), new Point3d(2000, 1000, 0));
            ObjectId[] ids02 = db.AddEntitiesToModelSpace(line05, line06, line07);
            editor.WriteMessage("----使用数组的方式，三条线段完成绘制！！！LJK，测试完成！---");
        }

        [CommandMethod("TestDrawMultiSegmentLine03")]
        public void TestDrawMultiSegmentLineDemo03()
        {
            Database db = HostApplicationServices.WorkingDatabase;
            Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
            //------------------------------------------测试四---------------------------------------------
            Double lineLength = 1500;
            Double lineAngle = 45;
            db.AddLineToModelSpace(new Point3d(1000, 1000, 0), new Point3d(3000, 1000, 0));
            db.AddLineToModelSpace(new Point3d(3000, 1000, 0), new Point3d(3000, 3000, 0));
            db.AddLineToModelSpace(new Point3d(3000,3000, 0), lineLength, lineAngle);
            editor.WriteMessage("----使用LJK程序开发的方式绘制直线完成绘制！！！LJK，测试完成！---");
        }

    }
}
