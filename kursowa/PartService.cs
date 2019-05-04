using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;

namespace kursowa
{
    public class PartService
    {
        private static PartService instance;

        private SldWorks sldApp;
        ModelDoc2 swDoc;
        private PartService()
        {
            initSolidworks();
        }

        public static PartService GetInstance()
        {
            if (instance == null)
            {
                instance = new PartService();
            }

            return instance;
        }

        public void MakeBolid()
        {
            #region parameters
            double lengthOfMainPart = 800 / 100.0;
            double heightOfMainPart = 80 / 100.0;
            double widthOfMainPart = 150 / 100.0;
            #endregion
            var Part = swDoc;
            SketchSegment segment;
            SketchManager sketchManager = Part.SketchManager;
            FeatureManager featureManager = Part.FeatureManager;
            bool boolstatus;
            boolstatus = Part.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            Part.SketchManager.InsertSketch(true);
            segment = sketchManager.CreateLine(0, 0, 0, -lengthOfMainPart, 0, 0);
            segment = sketchManager.CreateLine(-lengthOfMainPart, 0, 0, -lengthOfMainPart, heightOfMainPart, 0);
            segment = sketchManager.CreateLine(-lengthOfMainPart, heightOfMainPart, 0, 0, heightOfMainPart, 0);
            segment = sketchManager.CreateLine(0, heightOfMainPart, 0, 0, 0, 0);
            Part.Extension.SelectByID2("Line4", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            var extrusion = featureManager.FeatureExtrusion2(true, false, false, 6, 0, widthOfMainPart, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);
            sketchManager.InsertSketch(true);
            var faces = extrusion.getfa
           // var firstFace = faces.First();
           // var edges = firstFace.GetEdges() as Edge[];


            Part.ClearSelection();
           // Part.ISelectionManager.select
            //chamfer1


        }

        private void initSolidworks()
        {
            sldApp = new SldWorks();
            int longstatus = 0;
            sldApp.ActivateDoc2("Part7", false, ref longstatus);
            swDoc = ((ModelDoc2)(sldApp.ActiveDoc));
        }
    }
}
