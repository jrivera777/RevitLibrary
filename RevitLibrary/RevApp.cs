using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Events;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace RevitLibrary
{
    class RevApp : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("SimulEICon");
            PushButton pushButton = ribbonPanel.AddItem(new PushButtonData("Search Elements",
            "SimulEICon", @"C:\Documents and Settings\fdot\My Documents\Visual Studio 2010\Projects\RevitLibrary\RevitLibrary\bin\Debug\RevitLibrary.dll", "RevitLibrary.ReadElements")) as PushButton;

            Bitmap bit = Properties.Resources.house2;
            BitmapSource largeImage = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bit.GetHbitmap(),IntPtr.Zero,System.Windows.Int32Rect.Empty,BitmapSizeOptions.FromWidthAndHeight(bit.Width, bit.Height));
            pushButton.LargeImage = largeImage;
            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }



        
    }
}
