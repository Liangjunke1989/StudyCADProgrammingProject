using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02_CAD绘制基本图形
{
    
    public class LineExam
    {
        [CommandMethod("LineDemo")]
        public void LineDemo()
        {
            //声明一个直线对象
            Line line01 = new Line();
            //声明直线的起始点
            Point3d starPoint = new Point3d(100, 100, 0);
            Point3d endPoint = new Point3d(200, 200, 0);
            //给直线赋值
            line01.StartPoint = starPoint;
            line01.EndPoint = endPoint; //此时存储在内存中


            //声明图形数据库对象
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            //开启事务处理
            using (Transaction trans=db.TransactionManager.StartTransaction())
            {
                //打开块表
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                //打开块表记录
                BlockTableRecord btr=(BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace],OpenMode.ForWrite);
                //加直线到块表记录
                btr.AppendEntity(line01);
                //更新数据
                trans.AddNewlyCreatedDBObject(line01, true);
                //事务提交
                trans.Commit();
            }
            doc.Editor.WriteMessage("LJK,一条直线创建完成！！！");
        }
        
    }
}
