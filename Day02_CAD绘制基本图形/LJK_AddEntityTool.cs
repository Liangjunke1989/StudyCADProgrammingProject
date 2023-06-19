using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02_CAD绘制基本图形
{
    public static class LJK_AddEntityTool
    {
        /// <summary>
        /// 将图形对象添加到图形文件中
        /// </summary>
        /// <param name="db">图形数据库</param>
        /// <param name="entity">图形对象实体</param>
        /// <returns>图形对象ObjectId</returns>
        public static ObjectId AddEntityToModelSpace(this Database db, Entity entity)   //此时this关键字使用,成为了db的拓展方法。
        {
            //声明ObjectId，用于返回
            ObjectId entityId = ObjectId.Null;
            //开启事务处理
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                //打开“块表”
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);//父子转行？
                //打开“块表记录”
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                //添加图形到“块表记录”
                entityId = btr.AppendEntity(entity);
                //更新数据信息
                trans.AddNewlyCreatedDBObject(entity, true);
                //提交事务
                trans.Commit();
            }
            return entityId;
        }

        /// <summary>
        /// 将图形对象添加到图形文件中方法01
        /// </summary>
        /// <param name="db">图形数据库</param>
        /// <param name="ents">图形对象实体，可变参数</param>
        /// <returns>图形对象ObjectId集合</returns>
        public static List<ObjectId> AddEntityToModelSpace01(this Database db, params Entity[] ents)
        {
            List<ObjectId> entityIds;
            //开启事务处理
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                //打开“块表”
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);//父子转行？
                //打开“块表记录”
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                entityIds = new List<ObjectId>();
                foreach (var entity in ents)
                {
                    // 添加图形到“块表记录”
                    var entityId = btr.AppendEntity(entity);
                    entityIds.Append(entityId);
                    //更新数据信息
                    trans.AddNewlyCreatedDBObject(entity, true);
                }
                //提交事务
                trans.Commit();
            }
            return entityIds;
        }

        /// <summary>
        /// 将图形对象添加到图形文件中方法02
        /// </summary>
        /// <param name="db">图形数据库</param>
        /// <param name="ents">图形对象实体，可变参数</param>
        /// <returns>图形对象ObjectId数组</returns>
        public static ObjectId[] AddEntityToModelSpace02(this Database db, params Entity[] ents)
        {
            ObjectId[] entityIds;
            //开启事务处理
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                //打开“块表”
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);//父子转行？
                //打开“块表记录”
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                entityIds = new ObjectId[ents.Length];
                for (int i = 0; i < ents.Length; i++)
                {
                    // 添加图形到“块表记录”
                    entityIds[i] = btr.AppendEntity(ents[i]);
                    //更新数据信息
                    trans.AddNewlyCreatedDBObject(ents[i], true);

                }
                //提交事务
                trans.Commit();
            }
            return entityIds;
        }
    }
}
