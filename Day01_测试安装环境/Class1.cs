using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;

namespace Day01_测试安装环境
{
    public class Class1
    {
        [CommandMethod("TestDemo")]
        public void TestDemo()
        {
            Editor ed=Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("HelloWorld!!!我是来学习CAD二次开发的！！！");
        }
        [CommandMethod("HelloWorld")]
        public void TestCAD() 
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            MessageBox.Show("HelloWorld");
        }
    }
}
