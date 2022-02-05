using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingLibrary_6_3
{
    public class SelectionsUtils
    {
        public static List<XYZ> GetPoints(ExternalCommandData commandData,
                            string promptMessage, ObjectSnapTypes objectSnapTypes, int pointCount = 0)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;

            List<XYZ> points = new List<XYZ>();

            int pointNumber = 0;
            while (true)
            {
                XYZ pickedPoint = null;
                try
                {
                    pickedPoint = uidoc.Selection.PickPoint(objectSnapTypes, promptMessage);
                    points.Add(pickedPoint);
                    pointNumber++;
                    if (pointNumber == pointCount)
                    {
                        break;
                    }
                }
                catch (Autodesk.Revit.Exceptions.OperationCanceledException ex)
                {
                    break;
                }

            }

            return points;
        }
    }
}
