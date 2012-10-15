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
            // Set the large image shown on button
            Uri uriImage = new Uri(@"C:\Documents and Settings\fdot\My Documents\Visual Studio 2010\Projects\RevitLibrary\RevitLibrary\Images\house2.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;
            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        
    }
}
