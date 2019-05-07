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
            //var faces = extrusion.getfa
            // var firstFace = faces.First();
            // var edges = firstFace.GetEdges() as Edge[];
            int fCo = 1;
            //var facesOfExtr = extrusion.GetFaces() as object[];
            
            /*foreach (var f in facesOfExtr)
            {
                //  var edges = f.GetEdges() as Edge[];
                var faceType = f.GetType();
                //foreach (var ed in edges)
                //{
                //    var v1 = ed.GetStartVertex() as Vertex;
                //    var v2 = ed.GetEndVertex() as Vertex;
                //}
            }*/

            Part.ClearSelection();
            // Part.ISelectionManager.select
            //chamfer1
            //boolstatus = Part.Extension.SelectByID2("", "EDGE", -8.00045398596791, 0.52646990119959, -0.748640760309002, true, 0, null, 0);
            //boolstatus = Part.DeSelectByID("", "EDGE", -7.99489786722341, 0.575877913136708, -0.765275849633809);
            //boolstatus = Part.Extension.SelectByID2("", "EDGE", -8.00103688672834, 0.494900583499657, 0.753104451891517, true, 0, null, 0);
            //boolstatus = Part.Extension.SelectByID2("", "EDGE", -8.00521637346293, 0.484120176682012, -0.734382112316183, true, 0, null, 0);
            //boolstatus = Part.DeSelectByID("", "EDGE", -7.99874237682849, 0.580375379002817, 0.746234660423795);
            //boolstatus = Part.Extension.SelectByID2("", "EDGE", -8.00382713063834, 0.578539514174906, 0.76145847721304, true, 0, null, 0);
            var firstVal = -widthOfMainPart / 2.0;
            var secondVal = widthOfMainPart / 2.0;
            sketchManager.InsertSketch(false);
            Part.Extension.SelectByID2("", "EDGE", 0, 0.04, firstVal, true, 1, null, 1);
            Part.Extension.SelectByID2("", "EDGE", 0, 0.04, secondVal, true, 1, null, 1);
            Part.FeatureManager.InsertFeatureChamfer(4, 2, 2.5, 0, 0.6, 0, 0, 0);

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
