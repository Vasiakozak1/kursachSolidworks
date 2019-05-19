using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        private double widthOfMainPart;
        private double heightOfMainPart;
        private double lengthOfMainPart;
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
            lengthOfMainPart = 800 / 100.0;
            heightOfMainPart = 80 / 100.0;
            widthOfMainPart = 150 / 100.0;
            #endregion
            createPart();
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
            Part.Extension.SelectByID2("Line1", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            var extrusion = featureManager.FeatureExtrusion2(true, false, false, 6, 0, widthOfMainPart, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);
            sketchManager.InsertSketch(true);

            Part.ClearSelection();

            var firstVal = -widthOfMainPart / 2.0;
            var secondVal = widthOfMainPart / 2.0;
            sketchManager.InsertSketch(false);
            Part.Extension.SelectByID2("", "EDGE", 0, 0.04, firstVal, true, 1, null, 1);
            Part.Extension.SelectByID2("", "EDGE", 0, 0.04, secondVal, true, 1, null, 1);
            Part.FeatureManager.InsertFeatureChamfer(4, 2, 2.5, 0, 0.6, 0, 0, 0);

            Part.ClearSelection2(true);
            Part.Extension.SelectByID2("", "EDGE", -1.60359675146537E-03, 0.468692650695658, -0.161665083159619, false, 1, null, 0);
            Part.Extension.SelectByID2("", "EDGE", 1.24126468108443E-05, 0.432705387515739, 0.150090293621304, true, 1, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.2, 0.02, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));


            Part.ClearSelection2(true);
            //sketchManager.InsertSketch(false);
            Part.Extension.SelectByID2("", "EDGE", -2.50145207253843, 0.409842119252346, 0.759927555199994, true, 1, null, 0);
            Part.Extension.SelectByID2("", "EDGE", -2.50145207253843, 0.409842119252346, 0.759927555199994, false, 1, null, 0);

            Part.FeatureManager.FeatureFillet3(195, 3, 3, 0, 0, 0, 0, 0, null, null, null, null, null, null);

            Part.ClearSelection2(true);
            //sketchManager.InsertSketch(false);
            Part.Extension.SelectByID2("", "EDGE", -9.92190741726517E-04, 0.423385979796308, 0.156783427202669, false, 1, null, 0);
            Part.Extension.SelectByID2("", "EDGE", -3.0946920736028E-03, 0.461205360135011, -0.128842154520996, true, 1, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.2, 3, 0, 0, 0, 0, 0, null, null, null, null, null, null);

            //Start creating bottom part
            Part.Extension.SelectByID2("Top Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            sketchManager.InsertSketch(true);
            Part.ClearSelection2(true);
            double distanceBetweenMainPartAndWheel = 125.0 / 100.0;
            double widthOFDetailThatLinksMainPartAndWheel = 60.0 / 100.0;
            Part.SketchManager.CreateLine(-lengthOfMainPart, -widthOfMainPart / 2, 0, -lengthOfMainPart, -widthOfMainPart / 2 - 125 / 100.0, 0);
            Part.SketchManager.CreateLine(-lengthOfMainPart, -widthOfMainPart / 2 - 125 / 100.0, 0, -lengthOfMainPart + widthOFDetailThatLinksMainPartAndWheel, -widthOfMainPart / 2 - distanceBetweenMainPartAndWheel, 0);
            Part.SketchManager.CreateLine(-lengthOfMainPart + 60 / 100.0, -widthOfMainPart / 2 - 125.0 / 100.0, 0, -lengthOfMainPart + widthOFDetailThatLinksMainPartAndWheel, (-widthOfMainPart / 2 - 125 / 100.0) + 42.57247318 / 100.0, 0);
            double x1ForArc1 = -lengthOfMainPart + 122.31294971 / 100.0;
            double y1ForArc1 = -widthOfMainPart / 2.0;
            double z1ForArc1 = 0.0;
            double x2ForArc1 = x1ForArc1 + 106.29290168 / 100.0;
            double y2ForArc1 = y1ForArc1 - 226.27818952 / 100.0;
            double z2ForArc1 = 0.0;
            double x3ForArc1 = -lengthOfMainPart + 60.0 / 100.0;
            double y3ForArc1 = -widthOfMainPart / 2.0 + (-125.0 + 42.57247318) / 100.0;
            double z3ForArc1 = 0.0;
            // Part.SketchManager.Create3PointArc(x1ForArc, y1ForArc, z1ForArc, x2ForArc, y2ForArc, z2ForArc, x3ForArc, y3ForArc, z3ForArc);
            Part.SketchManager.Create3PointArc(x1ForArc1, y1ForArc1, 0.0, -7.4, -1.574275, 0.0, -7.022504, -1.175317, 0.0);
            Part.SetPickMode();
            Part.ClearSelection2(true);
            Part.SketchManager.CreateLine(-6.776871, -widthOfMainPart / 2.0, 0, -7.4, -widthOfMainPart / 2.0, 0);
            Part.SketchManager.CreateLine(-7.4, -widthOfMainPart / 2.0, 0, -7.4, -1.273082, 0);
            Part.SketchManager.CreateLine(-7.4, -widthOfMainPart / 2.0, 0, -lengthOfMainPart, -widthOfMainPart / 2.0, 0);
            Part.SketchManager.Create3PointArc(-7.017346, -widthOfMainPart / 2.0, 0, -7.4, -1.273082, 0, -7.17822, -1.06516, 0);
            Part.SetPickMode();
            Part.ClearSelection2(true);

            //Mirror arcs
            //Part.SketchManager.CreateLine(-8.0, 0.0, 0.0, 0.0, 0.007679, 0);
            //Part.SetPickMode();
            //Part.ClearSelection2(true);
            //Part.Extension.SelectByID2("Line1", "SKETCHSEGMENT", -7.99267683991916, 0.138805887620156, 1.19032121890109, true, 0, null, 0);
            //boolstatus = Part.Extension.SelectByID2("Line2", "SKETCHSEGMENT", -7.59539420107798, 0.219650124111973, 1.95852827802445, true, 0, null, 0);
            //boolstatus = Part.Extension.SelectByID2("Line3", "SKETCHSEGMENT", -7.42479493618359, 0.223148596970411, 1.7838255099833, true, 0, null, 0);
            //boolstatus = Part.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", -7.154460157051, 0.216445664243084, 1.30903823320347, true, 0, null, 0);
            //boolstatus = Part.Extension.SelectByID2("Line4", "SKETCHSEGMENT", -6.89335930010243, 2.9561552520363E-04, 0.754778201532673, true, 0, null, 0);
            //boolstatus = Part.Extension.SelectByID2("Line6", "SKETCHSEGMENT", -7.43467953799967, 0.165906571087912, 0.871988920136775, true, 0, null, 0);
            //boolstatus = Part.Extension.SelectByID2("Arc2", "SKETCHSEGMENT", -7.18099306278382, 0.199199844738935, 1.06625012508156, true, 0, null, 0);
            ////Part.SketchMirror();
            //Part.Extension.SelectByID2("Line7", "SKETCHSEGMENT", -7.53505894461789, 0.104497374176439, 1.54634204907547E-02, true, 0, null, 0);
            //Part.SetPickMode();
            //Part.ClearSelection2(true);

            //Wing
            Part.SketchManager.CreateLine(x1ForArc1, y1ForArc1, z1ForArc1, x1ForArc1 + 107.68705029 / 100.0, y1ForArc1, z1ForArc1);
            Part.SketchManager.CreateLine(x1ForArc1 + 107.68705029 / 100.0, y1ForArc1, z1ForArc1, x1ForArc1 + (107.68705029 + 70.0) / 100.0, y1ForArc1 - 40.0 / 100, z1ForArc1);
            Part.SketchManager.CreateLine(x1ForArc1 + (107.68705029 + 70.0) / 100.0, y1ForArc1 - 40.0 / 100, z1ForArc1, x1ForArc1 + (107.68705029 + 70.0) / 100.0, y1ForArc1 - 90.0 / 100, z1ForArc1);
            double x1ForArc3 = Math.Round((x1ForArc1 + (107.68705029 + 70.0 + 240.0) / 100.0), 1);
            double y1ForArc3 = Math.Round(y1ForArc1 - (90.0 - 23.32770382) / 100.00, 1);
            double z1FForArc3 = 0.0;
            //Part.SketchManager.CreateLine(x1ForArc1 + (107.68705029 + 70.0) / 100.0, y1ForArc1 - 90.0 / 100, z1ForArc1, x1ForArc3, y1ForArc3, z1FForArc3);
            Part.SketchManager.Create3PointArc(x1ForArc3, y1ForArc3, z1FForArc3, -5, -1.65, 0, -3.988716, -1.938586, 0);
            double x1ForArc4 = x1ForArc3 + 110.0 / 100;
            double y1ForArc4 = y1ForArc3 + 78.15763134 / 100.0;
            double z1ForArc4 = 0.0;
            //Part.SketchManager.CreateLine(x1ForArc3, y1ForArc3, z1FForArc3, x1ForArc4, y1ForArc4, z1ForArc4);
            Part.SketchManager.Create3PointArc(x1ForArc4, y1ForArc4, z1ForArc4, x1ForArc3, y1ForArc3, z1FForArc3, -2.114926, -0.999068, 0);
            double x1ForArc5 = x1ForArc4 + 70.0 / 100.0;
            double y1ForArc5 = y1ForArc4 - 130.82992752 / 100.0;
            double z1ForArc5 = 0.0;
            //Part.SketchManager.CreateLine(x1ForArc4, y1ForArc4, z1ForArc4, x1ForArc5, y1ForArc5, z1ForArc5);
            Part.SketchManager.Create3PointArc(x1ForArc5, y1ForArc5, z1ForArc5, x1ForArc4, y1ForArc4, z1ForArc4, -1.047119, -1.215711, 0);
            double x2ForArc6 = x1ForArc4 + 13.58 / 100.0;
            double y2ForArc6 = y1ForArc4 + 7.03 / 100.0;
            double z2ForArc6 = 0.0;
            double x1ForArc6 = x1ForArc5;
            double y1ForArc6 = y1ForArc5 + 43.1674111 / 100.0;
            double z1ForArc6 = 0.0;
            //Part.SketchManager.CreateLine(x1ForArc6, y1ForArc6, z1ForArc6, x2ForArc6, y2ForArc6, z2ForArc6);
            Part.SketchManager.Create3PointArc(x1ForArc6, y1ForArc6, z1ForArc6, x2ForArc6, y2ForArc6, z2ForArc6, -1.004515, -0.966642, 0);
            double x2ForLine = x1ForArc6;
            double y2ForLine = y1ForArc6 + 110.0 / 100.0;
            double z2ForLine = 0.0;
            Part.SketchManager.CreateLine(x1ForArc6, y1ForArc6, z1ForArc6, x2ForLine, y2ForLine, z2ForLine);
            Part.SketchManager.Create3PointArc(x2ForArc6, y2ForArc6, z2ForArc6, x2ForLine, y2ForLine, z2ForLine, -1.097502, -0.462248, 0);
            double x2ForBackWing1 = 0;
            double y2ForBackWing1 = y1ForArc5;
            double z2ForBackWing1 = 0;
            Part.SketchManager.CreateLine(x1ForArc5, y1ForArc5, z1ForArc5, x2ForBackWing1, y2ForBackWing1, z2ForBackWing1);
            double halfOFLengthOFBackWing = 192.904 / 100.0;
            double x2ForBackWing2 = 0;
            double y2ForBackWIng2 = y2ForBackWing1 + halfOFLengthOFBackWing;
            double z2ForBackWing2 = 0;
            Part.SketchManager.CreateLine(x2ForBackWing1, y2ForBackWing1, z2ForBackWing1, x2ForBackWing2, y2ForBackWIng2, z2ForBackWing2);
            double x2ForBackWing3 = 0;
            double y2ForBackWing3 = y2ForBackWIng2 + halfOFLengthOFBackWing;
            double z2ForBackWIng3 = 0;
            Part.SketchManager.CreateLine(x2ForBackWing2, y2ForBackWIng2, z2ForBackWing2, x2ForBackWing3, y2ForBackWing3, z2ForBackWIng3);
            double x2ForBackWing4 = x1ForArc5;
            double y2ForBackWing4 = y2ForBackWing3;
            double z2ForBackWing4 = 0;
            Part.SketchManager.CreateLine(x2ForBackWing3, y2ForBackWing3, z2ForBackWIng3, x2ForBackWing4, y2ForBackWing4, z2ForBackWing4);
            //The same but another side of bolide
            double x2ForCorpseToWheelLine1 = -lengthOfMainPart;
            double y2ForCorpseToWheelLine1 = widthOfMainPart / 2 + distanceBetweenMainPartAndWheel;
            double z2ForCorpseToWheelLine1 = 0.0;
            Part.SketchManager.CreateLine(-lengthOfMainPart, widthOfMainPart / 2, 0, x2ForCorpseToWheelLine1, y2ForCorpseToWheelLine1, z2ForCorpseToWheelLine1);
            double x2ForCorpseToWheelLine2 = x2ForCorpseToWheelLine1 + widthOFDetailThatLinksMainPartAndWheel;
            double y2ForCoprseToWheelLine2 = y2ForCorpseToWheelLine1;
            double z2ForCoprseToWheelLine2 = z2ForCorpseToWheelLine1;
            Part.SketchManager.CreateLine(x2ForCorpseToWheelLine1, y2ForCorpseToWheelLine1, z2ForCorpseToWheelLine1, x2ForCorpseToWheelLine2, y2ForCoprseToWheelLine2, z2ForCoprseToWheelLine2);
            double x2ForCorpseToWheelLine3 = x2ForCorpseToWheelLine2;
            double y2ForCoprseToWheelLine3 = y2ForCorpseToWheelLine1 - 42.57247318 / 100.0;
            double z2ForCoprseToWheelLine3 = z2ForCoprseToWheelLine2;
            Part.SketchManager.CreateLine(x2ForCorpseToWheelLine2, y2ForCoprseToWheelLine2, z2ForCoprseToWheelLine2, x2ForCorpseToWheelLine3, y2ForCoprseToWheelLine3, z2ForCoprseToWheelLine3);
            double x1ForCorpseToWheelArc1 = x1ForArc1;
            double y1ForCorpseToWheelArc1 = -y1ForArc1;
            double z1ForCorpseToWheelArc1 = 0;
            Part.SketchManager.Create3PointArc(x2ForCorpseToWheelLine3, y2ForCoprseToWheelLine3, z2ForCoprseToWheelLine3, x1ForCorpseToWheelArc1, y1ForCorpseToWheelArc1, z1ForCorpseToWheelArc1, -7.02437, 1.177213, 0);
            double x2ForCorpseToWheelLine4 = -lengthOfMainPart + 60.0 / 100.0;
            double y2ForCorpseToWheelLine4 = widthOfMainPart / 2.0;
            double z2ForCorpseToWheelLine4 = 0;
            Part.SketchManager.CreateLine(x1ForCorpseToWheelArc1, y1ForCorpseToWheelArc1, z1ForCorpseToWheelArc1, x2ForCorpseToWheelLine4, y2ForCorpseToWheelLine4, z2ForCorpseToWheelLine4);
            double x2ForCoprseToWheelLine5 = x2ForCorpseToWheelLine4;
            double y2ForCorpseToWheelLine5 = widthOfMainPart / 2 + 52.3082 / 100.0;
            double z2ForCorpseToWheelLine5 = 0;
            Part.SketchManager.CreateLine(x2ForCorpseToWheelLine4, y2ForCorpseToWheelLine4, z2ForCorpseToWheelLine4, x2ForCoprseToWheelLine5, y2ForCorpseToWheelLine5, z2ForCorpseToWheelLine5);
            double x1ForCorpseToWheelArc2 = -lengthOfMainPart + 98.2654 / 100.0;
            double y1ForCorpseToWheelArc2 = y1ForCorpseToWheelArc1;
            double z1ForCorpseToWheelArc2 = z1ForCorpseToWheelArc1;
            Part.SketchManager.CreateLine(x2ForCorpseToWheelLine4, y2ForCorpseToWheelLine4, z2ForCorpseToWheelLine4, -lengthOfMainPart, widthOfMainPart / 2.0, z2ForCoprseToWheelLine2);
            Part.SketchManager.Create3PointArc(x2ForCoprseToWheelLine5, y2ForCorpseToWheelLine5, z2ForCorpseToWheelLine5, x1ForCorpseToWheelArc2, y1ForCorpseToWheelArc2, z1ForCorpseToWheelArc2, -7.169033, 0.997835, 0);
            double x2ForCorpseLine1 = x1ForArc1 + 107.68705029 / 100.0;
            double y2ForCorpseLine1 = widthOfMainPart / 2.0;
            double z2ForCorpseLine1 = 0;
            Part.SketchManager.CreateLine(x1ForCorpseToWheelArc2, y1ForCorpseToWheelArc2, z1ForCorpseToWheelArc2, x2ForCorpseLine1, y2ForCorpseLine1, z2ForCorpseLine1);
            double x2ForCorpseLine2 = x2ForCorpseLine1 + 70.0 / 100.0;
            double y2ForCorpseLine2 = y2ForCorpseLine1 + 40.0 / 100.0;
            double z2ForCorpseLine2 = 0.0;
            Part.SketchManager.CreateLine(x2ForCorpseLine1, y2ForCorpseLine1, z2ForCorpseLine1, x2ForCorpseLine2, y2ForCorpseLine2, z2ForCorpseLine2);
            double x2ForCorpseLine3 = x2ForCorpseLine2;
            double y2ForCorpseLine3 = y2ForCorpseLine2 + 50.0 / 100.0;
            double z2ForCorpseLIne3 = 0.0;
            Part.SketchManager.CreateLine(x2ForCorpseLine2, y2ForCorpseLine2, z2ForCorpseLine2, x2ForCorpseLine3, y2ForCorpseLine3, z2ForCorpseLIne3);
            double x2ForCorpseArc1 = x1ForArc3;
            double y2ForCorpseArc1 = -y1ForArc3;
            double z2ForCorpseArc1 = z1FForArc3;
            Part.SketchManager.Create3PointArc(x2ForCorpseLine3, y2ForCorpseLine3, z2ForCorpseLIne3, x2ForCorpseArc1, y2ForCorpseArc1, z2ForCorpseArc1, -3.563352, 1.899428, 0);
            double x2ForCorpseArc2 = x1ForArc4;
            double y2ForCorpseArc2 = -y1ForArc4;
            double z2ForCorpseArc2 = z1ForArc4;
            Part.SketchManager.Create3PointArc(x2ForCorpseArc1, y2ForCorpseArc1, z2ForCorpseArc1, x2ForCorpseArc2, y2ForCorpseArc2, z2ForCorpseArc2, -2.025267, 0.941125, 0);
            double x2ForCorpseArc3 = x2ForBackWing4;
            double y2ForCorpseArc3 = y2ForBackWing4;
            double z2ForCorpseArc3 = z2ForBackWing4;
            Part.SketchManager.Create3PointArc(x2ForCorpseArc2, y2ForCorpseArc2, z2ForCorpseArc2, x2ForCorpseArc3, y2ForCorpseArc3, z2ForCorpseArc3, -1.158409, 1.11352, 0);
            double x2ForCorpseArc4 = x2ForArc6;
            double y2ForCorpseArc4 = -y2ForArc6;
            double z2ForCorpseArc4 = z2ForArc6;
            double x1ForCorpseArc4 = x1ForArc6;
            double y1ForCorpseArc4 = -y1ForArc6;
            double z1ForCorpseArc4 = z1ForArc6;
            Part.SketchManager.Create3PointArc(x1ForCorpseArc4, y1ForCorpseArc4, z1ForCorpseArc4, x2ForCorpseArc4, y2ForCorpseArc4, z2ForCorpseArc4, -1.058286, 0.989618, 0);
            double x2ForCorpseLine4 = x2ForLine;
            double y2ForCorpseLine4 = -y2ForLine;
            double z2ForCorpseLine4 = z2ForLine;
            Part.SketchManager.CreateLine(x2ForCorpseArc4, y2ForCorpseArc4, z2ForCorpseArc4, x2ForCorpseLine4, y2ForCorpseLine4, z2ForCorpseLine4);
            Part.SketchManager.CreateLine(x1ForCorpseArc4, y1ForCorpseArc4, z1ForCorpseArc4, x2ForCorpseLine4, y2ForCorpseLine4, z2ForCorpseLine4);
            //close needed counturs
            Part.SketchManager.CreateLine(-8, 0.75, 0, -2.5, 0.75, 0);
            Part.SketchManager.CreateLine(-2.5, 0.75, 0, 0, 0.15, 0);
            Part.SketchManager.CreateLine(0, 0.15, 0, 0, 0.007679, 0);
            Part.SketchManager.CreateLine(-0.042941, -0.116145, 0, -0.153325, -0.186798, 0);
            Part.SketchManager.CreateLine(-0.153325, -0.186798, 0, -2.502459, -0.729218, 0);
            Part.SketchManager.CreateLine(-2.502459, -0.729218, 0, -2.85496, -0.75, 0);
            Part.SketchManager.CreateLine(-2.85496, -0.75, 0, -5.7, -0.75, 0);
            Part.SketchManager.CreateLine(-8, -0.75, 0, -8, 0.75, 0);
       
            Thread.Sleep(100);
          //  ForTest();
            Part.SetPickMode();
            //Part.ClearSelection2(true);
            //Part.Extension.SelectByID2("Sketch40", "SKETCH", -6.99006116553235, 1.06375414014607, 2.05137105845649, false, 4, null, 0);
            Part.SelectionManager.EnableContourSelection = true;
            Part.Extension.SelectByID2("Sketch2", "SKETCHREGION", -3.9841093791155, 1.92165359018481E-02, -1.11273181579067, true, 4, null, 0);

            Part.Extension.SelectByID2("Sketch2", "SKETCHREGION", -6.90010975425287, 1.05342333640838, 1.97602960993305, true, 0, null, 0);
            Part.Extension.SelectByID2("Sketch2", "SKETCHREGION", -6.21591444832203, 2.1019999157831, -0.191076915736342, true, 0, null, 0);
            Part.Extension.SelectByID2("Sketch2", "SKETCHREGION", -4.3896245678695, -0.268919542014907, 1.3356196563234, true, 0, null, 0);
            Part.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, 0.4, 0.4, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);
            Part.SelectionManager.EnableContourSelection = false;
            frontLoft();
            driverSit();
            backWing();
            frontWing();
            partEnhancing();
        }

        private void partEnhancing()
        {
            var Part = swDoc;
            Part.Extension.SelectByID2("", "FACE", -6.78380047555572, 0.799999999999955, 0.159023701085346, true, 1, null, 0);
            Part.ClearSelection2(true);
            Part.Extension.SelectByID2("", "FACE", -6.78380047555572, 0.799999999999955, 0.159023701085346, false, 1, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.04, 0.01, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));

            //box after driver sit
            double yForCutSketch = 1.4 - 0.04;
            double xModify = 0.01;

            Part.Extension.SelectByID2("", "FACE", -4.63307708814716, 1.28901517171221, 8.23006348072184E-02, false, 0, null, 0);
            Part.SketchManager.InsertSketch(true);
            Part.ClearSelection2(true);
            Part.SketchManager.CreateLine(-0.380286, 1.4, 0, -0.380286, 0.84, 0);
            Part.SketchManager.CreateLine(-0.380286, 0.84, 0, 0.371344, 0.84, 0);
            Part.SketchManager.CreateLine(0.371344, 0.84, 0, 0.371344, 1.4, 0);
            Part.SketchManager.CreateLine(0.371344, 1.4, 0, -0.380286, 1.4, 0);
            Part.ClearSelection2(true);
            Part.Extension.SelectByID2("Line4", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            Part.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, 0.0001, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);
            Part.Extension.SelectByID2("", "FACE", -4.63317708814719, 1.24926405903166, -0.14330009478595, false, 0, null, 0);
            Part.SketchManager.InsertSketch(true);
            Part.ClearSelection2(true);
            Part.SketchManager.CreateLine(0.371344, 0.84, 0, 0.371344, 1.379237, 0);
            Part.SketchManager.CreateLine(0.371344, 1.379237, 0, -0.380286, 1.379237, 0);
            Part.SketchManager.CreateLine(-0.380286, 1.379237, 0, -0.380286, 0.84, 0);
            Part.SketchManager.CreateLine(-0.380286, 0.84, 0, 0.371344, 0.84, 0);
            Part.SketchManager.CreateLine(0.371344, 0.84, 0, 0.37193, 0.839418, 0);

            Part.Extension.SelectByID2("Sketch16", "SKETCHREGION", -5.51604502564569, 1.19197485065642, -0.126607830934105, true, 4, null, 0);
            Part.ClearSelection2(true);
            Part.Extension.SelectByID2("Line7", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            Part.Extension.SelectByID2("Sketch16", "SKETCH", -5.51604502564569, 1.19197485065642, -0.126607830934105, true, 4, null, 0);
            Part.SelectionManager.EnableContourSelection = true;
            Part.Extension.SelectByID2("Sketch16", "SKETCHREGION", -5.51604502564569, 1.19197485065642, -0.126607830934105, true, 4, null, 0);
            Part.FeatureManager.FeatureCut3(true, false, false, 0, 0, 0.4, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            //Part.Extension.SelectByID2("Sketch15", "SKETCH", -5.72262221451914, 1.24042065615908, -0.196461220419769, false, 4, null, 0);
            //Part.SelectionManager.EnableContourSelection = true;
            //Part.Extension.SelectByID2("Sketch15", "SKETCHREGION", -5.72262221451914, 1.24042065615908, -0.196461220419769, true, 4, null, 0);
            //Part.FeatureManager.FeatureCut3(true, false, false, 0, 0, 0.4, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);
            //fillet body of bolide
            Part.ClearSelection2(true);
            Part.Extension.SelectByID2("", "FACE", -4.35581964091523, -0.286223915777839, 1.90017473567309, false, 1, null, 0);
            Part.Extension.SelectByID2("", "FACE", -5.25123865609476, -0.230184693308786, 1.00643505366014, true, 1, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.05, 0.01, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));
            Part.Extension.SelectByID2("", "FACE", -2.09706721471295, -0.291886555545148, -0.992037571497576, false, 1, null, 0);
            Part.Extension.SelectByID2("", "FACE", -5.39972580624135, -0.141173405468749, -0.921585253576325, true, 1, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.05, 0.01, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));
            Part.Extension.SelectByID2("", "EDGE", -1.77920169917604, 1.17432679479634E-03, -0.576110982775106, false, 1, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.05, 0.01, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));

            createAssembly();
            loadComponentsAndMergeThem();
        }

        private void loadComponentsAndMergeThem()
        {
            var Part = swDoc as AssemblyDoc;
            Part.AddComponent("qaz", 4.63740979769643, 5.48276643779863, 8.53843062725727);
            Part.AddComponent("wheel", 1.39531012250518, 4.40312976879068, 10.8170748953016);
            Part.AddComponent("wheel", 1.35574414456642, 4.40593699540477, 6.187419028048);
            Part.AddComponent("wheel", 8.61716884937414, 4.78001097240485, 6.3049939495686);
            Part.AddComponent("wheel", 8.61145906332604, 4.37909759429749, 10.8762716813799);
        }

        public void MakeWheel()
        {
            createPart();
            var Part = swDoc;
            var skethManager = Part.SketchManager;
            double wheelRadius = 80 / 100.0;
            double wheelWidth = 80 / 100.0;
            double wheelInnerCircleRadiusCooficient = 80.0 / 45.0;
            double wheelOuterInnerCIrcleRadiusCooficient = 80.0 / 55.0;
            double innerCircleRadius = wheelRadius / wheelInnerCircleRadiusCooficient;
            double outerInnerCircleRadius = wheelRadius / wheelOuterInnerCIrcleRadiusCooficient;
            Part.InsertSketch2(true);
            Part.Extension.SelectByID2("Front Plane", "PLANE", 0, 0, 0, false, 0, null, 0);
            skethManager.CreateCircleByRadius(0, 0, 0, wheelRadius);
            Part.FeatureManager.FeatureExtrusion2(true, false, false, 6, 0, wheelWidth, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);
            Part.ClearSelection2(true);
            Part.InsertSketch2(true);
            Part.Extension.SelectByID2("", "FACE", 0, 0, wheelWidth, false, 0, null, 0);
            Part.CreateCircleByRadius2(0, 0, 0, innerCircleRadius);
            Part.CreateCircleByRadius2(0, 0, 0, outerInnerCircleRadius);
            Part.FeatureManager.FeatureCut3(true, false, false, 0, 0, 0.3, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);
            //Part.ClearSelection2(true);
            Part.Extension.SelectByID2("", "FACE", wheelRadius - 0.1, 0, wheelWidth / 2.0, false, 0, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.12, 0.012, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));
            Part.Extension.SelectByID2("", "FACE", 0, 0, -wheelWidth / 2.0, false, 0, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.12, 0.012, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));
            Part.ClearSelection2(true);
            Part.Extension.SelectByID2("", "FACE", 0, 0, wheelWidth / 2.0, false, 0, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.1, 0.01, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));
        }

        private void driverSit()
        {
            var Part = swDoc;
            Part.ClearSelection2(true);
            Part.Extension.SelectByID2("", "FACE", -5.28052862972274, 0.800000000000011, -0.238494155555618, false, 0, null, 0);
            Part.SketchManager.InsertSketch(true);
            Part.SketchManager.CreateCenterRectangle(-5.36149579331694, 0, 0, -4.63307708814727, -0.462608672434962, 0);
            Part.FeatureManager.FeatureCut3(true, false, false, 0, 0, 0.8, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, false, true, true, true, true, false, 0, 0, false);
            Part.SetPickMode();
            Part.SketchManager.CreateCornerRectangle(-4.63307708814727, 0.420286319388215, 0, -4.22371876712762, -0.411343800446971, 0);

            Part.Extension.SelectByID2("Line5", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            Part.Extension.SelectByID2("Line6", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            Part.Extension.SelectByID2("Point5", "SKETCHPOINT", 0, 0, 0, true, 0, null, 0);
            Part.Extension.SelectByID2("Line2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            Part.Extension.SelectByID2("Line1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            Part.Extension.SelectByID2("Line4", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            Part.Extension.SelectByID2("Line3", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            Part.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, 0.6, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);
            Part.SelectionManager.EnableContourSelection = false;
            Part.Extension.SelectByID2("", "FACE", -4.17494969332389, 1.1999999999999, -0.140817434635633, false, 0, null, 0);
            Part.SketchManager.InsertSketch(true);
            Part.SketchManager.CreateCornerRectangle(-4.63307708814727, 0.420286319388215, 0, -4.22371876712762, -0.411343800446971, 0);
            Part.Extension.SelectByID2("Line5", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            Part.Extension.SelectByID2("Line6", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            Part.Extension.SelectByID2("Point5", "SKETCHPOINT", 0, 0, 0, true, 0, null, 0);
            Part.Extension.SelectByID2("Line2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            Part.Extension.SelectByID2("Line1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            Part.Extension.SelectByID2("Line4", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            Part.Extension.SelectByID2("Line3", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            Part.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, 0.6, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);
            Part.ClearSelection2(true);
            Part.Extension.SelectByID2("", "FACE", -2.75156595535274, 0.799999999999898, -4.17453473646923E-02, false, 0, null, 0);
            Part.SketchManager.CreateCenterRectangle(-2.47113664829637, 0, 0, -2.39507345882777, -0.102003289060338, 0);
            Part.ClearSelection2(true);
            Part.Extension.SelectByID2("Line5", "SKETCHSEGMENT", 0, 0, 0, false, 0, null, 0);
            Part.Extension.SelectByID2("Line6", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            Part.Extension.SelectByID2("Point1", "SKETCHPOINT", 0, 0, 0, true, 0, null, 0);
            Part.Extension.SelectByID2("Line2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            Part.Extension.SelectByID2("Line1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            Part.Extension.SelectByID2("Line4", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            Part.Extension.SelectByID2("Line3", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, 0);
            Part.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, 0.25, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);
            Part.ClearSelection2(true);
            Part.SetPickMode();
            Part.Extension.SelectByID2("", "FACE", -4.22371876712768, 1.10450359450118, -0.118317316638695, false, 0, null, 0);
            Part.SketchManager.InsertSketch(true);
            Part.SketchManager.CreateCornerRectangle(0.420286319388215, 1.4, 0, -0.411343800446971, 0.8, 0);
            //Part.ClearSelection2(true);
            Part.Extension.SelectByID2("", "FACE", -2.54719983776491, 0.908906353457098, -0.026032517450119, false, 0, null, 0);
            Part.SketchManager.InsertSketch(false);
            Part.SketchManager.CreateCornerRectangle(-0.102003289060338, 1.05, 0, 0.102003289060338, 0.8, 0);
            Part.ClearSelection2(true);
            Part.Extension.SelectByID2("Sketch9", "SKETCH", -1.45008445005374E-02, 0.942770069762113, 0, false, 1, null, 0);
            Part.Extension.SelectByID2("Sketch10", "SKETCH", 5.42524031643943E-02, 1.13591583025177, 0, true, 1, null, 0);
            Part.FeatureManager.InsertProtrusionBlend(false, true, false, 1, 0, 0, 1, 1, true, true, false, 0, 0, 0, true, true, true);
        }
        private void backWing()
        {
            var Part = swDoc;
            double heightOfSpoiler = 198.0;
            Part.ClearSelection2(true);
            Part.InsertSketch();
            // Line for direction
            Part.Extension.SelectByID2("", "FACE", -300 / 100.0, 0.04, widthOfMainPart / 2.0, false, 0, null, 0);
            Part.SketchManager.CreateLine(-337.10445637 / 100.0, 0, 0, -285.49601322 / 100.0, 80.0 / 100.0, 0);
            Part.ClearSelection2(true);
            Part.InsertSketch();
            Part.Extension.SelectByID2("", "FACE", -0.7471, 0.5085, -0.3293, false, 0, null, 0);
            Part.SketchManager.CreateLine(19.2685305 / 100.0, 80.0 / 100.0, 0, 57.69612755 / 100.0, 0, 0);
            Part.ClearSelection2(true);
            Part.InsertSketch();
            Part.Extension.SelectByID2("", "FACE", -0.4259, 0, 0.9371, false, 0, null, 0);
            Part.SketchManager.CreateSketchSlot((int)swSketchSlotCreationType_e.swSketchSlotCreationType_center_line, (int)swSketchSlotLengthType_e.swSketchSlotLengthType_CenterCenter, 0.128689376070244, -0.4078, -1.00, 0, -0.264120136634895, -1.00, 0, 0, 0, 0, 1, false);

            Part.ClearSelection2(true);
            Part.Extension.SelectByID2("", "FACE", -0.5415, 0, -1.1320, false, 0, null, 0);
            Part.SketchManager.CreateSketchSlot((int)swSketchSlotCreationType_e.swSketchSlotCreationType_center_line, (int)swSketchSlotLengthType_e.swSketchSlotLengthType_CenterCenter, 0.128689376070244, -0.4078, 1.00, 0, -0.264120136634895, 1.0, 0, 0, 0, 0, 1, false);
            Part.Extension.SelectByID2("Line1@Sketch11", "EXTSKETCHSEGMENT", -323.55282659 / 100.0, 21.00684144 / 100.0, widthOfMainPart / 2.0, true, 16, null, 0);
            Part.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, heightOfSpoiler / 100.0, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);
            Part.ClearSelection2(true);

            Part.InsertSketch();
            double lengthOfSpoiler = 500;
            double widthOfSpoiler = 70;
            double heightOfSpoilerWing = 30 / 100.0;
            double xCooficient = 198.0 / 107.34;
            double yCooficient = 198.0 / 166.38;
            
            double xForSelectTopFace = (-55.15 / 100.0) + (heightOfSpoiler / xCooficient) / 100.0;
            double yForSelectTopFace = 0.0 + (heightOfSpoiler / yCooficient) / 100.0;
            double zForSelectTopFace = -93.57 / 100.0 - 0.5 / 100.0;
            Part.Extension.SelectByID2("", "FACE", xForSelectTopFace, yForSelectTopFace, zForSelectTopFace, false, 0, null, 0);

            Part.SketchManager.CreateLine(xForSelectTopFace - 0.07, (lengthOfSpoiler / 2) / 100, 0, (xForSelectTopFace - 0.07), (-lengthOfSpoiler / 2) / 100, 0);
            Part.SketchManager.CreateLine(xForSelectTopFace - 0.07, (-lengthOfSpoiler / 2) / 100, 0, (xForSelectTopFace - 0.07) + (widthOfSpoiler) / 100, (-lengthOfSpoiler / 2) / 100, 0);
            Part.SketchManager.CreateLine((xForSelectTopFace - 0.07) + (widthOfSpoiler) / 100, (-lengthOfSpoiler / 2) / 100, 0, (xForSelectTopFace - 0.07) + (widthOfSpoiler) / 100, (lengthOfSpoiler / 2) / 100, 0);
            Part.SketchManager.CreateLine((xForSelectTopFace - 0.07) + (widthOfSpoiler) / 100, (lengthOfSpoiler / 2) / 100, 0, (xForSelectTopFace - 0.07), (lengthOfSpoiler / 2) / 100, 0);
            Part.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, heightOfSpoilerWing, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);
            //filletForWing
            Part.ClearSelection2(true);
            Part.Extension.SelectByID2("", "FACE", xForSelectTopFace - 0.07, yForSelectTopFace + 0.04, 0, false, 0, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.05, 0.01, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));
            Part.Extension.SelectByID2("", "FACE", xForSelectTopFace, yForSelectTopFace + 0.04, (lengthOfSpoiler / 2) / 100, false, 0, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.05, 0.01, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));
            Part.Extension.SelectByID2("", "FACE", (xForSelectTopFace - 0.07) + (widthOfSpoiler) / 100, yForSelectTopFace + 0.04, 0, false, 0, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.05, 0.01, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));
            Part.Extension.SelectByID2("", "FACE", xForSelectTopFace, yForSelectTopFace + 0.04, (-lengthOfSpoiler / 2) / 100, false, 0, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.05, 0.01, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));
        }

        public void ForTest()
        {
            var Part = swDoc;
            // Part.SetPickMode();
            //Part.ClearSelection2(true);
            //Part.Extension.SelectByID2("Sketch40", "SKETCH", -6.99006116553235, 1.06375414014607, 2.05137105845649, false, 4, null, 0);
            //Part.SelectionManager.EnableContourSelection = true;
            //Part.Extension.SelectByID2("Sketch2", "SKETCHREGION", -3.9841093791155, 1.92165359018481E-02, -1.11273181579067, true, 4, null, 0);

            //Part.Extension.SelectByID2("Sketch2", "SKETCHREGION", -6.90010975425287, 1.05342333640838, 1.97602960993305, true, 0, null, 0);
            //Part.Extension.SelectByID2("Sketch2", "SKETCHREGION", -6.21591444832203, 2.1019999157831, -0.191076915736342, true, 0, null, 0);
            //Part.Extension.SelectByID2("Sketch2", "SKETCHREGION", -4.3896245678695, -0.268919542014907, 1.3356196563234, true, 0, null, 0);
            //Part.FeatureManager.FeatureExtrusion2(true, false, true, 0, 0, 0.4, 0.4, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);
            //Part.SelectionManager.EnableContourSelection = false;
            createAssembly();
            loadComponentsAndMergeThem();

        }
        private void frontLoft()
        {
            var Part = swDoc;
            Part.Extension.SelectByID2("", "FACE", -7.99999999999977, 0.381015673338915, -3.80499400459939E-02, true, 0, null, 0);
            Part.FeatureManager.InsertRefPlane(8, 2, 0, 0, 0, 0);
            Part.ClearSelection2(true);
            Part.Extension.SelectByID2("Plane1", "PLANE", 0, 0, 0, false, 0, null, 0);
            Part.SketchManager.InsertSketch(true);
            Part.ClearSelection2(true);
            Part.Extension.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAddConstToRectEntity, (int)swUserPreferenceOption_e.swDetailingNoOptionSpecified, true);
            Part.Extension.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchAddConstLineDiagonalType, (int)swUserPreferenceOption_e.swDetailingNoOptionSpecified, true);
            //Part.SketchManager.CreateCenterRectangle(0, 0, 0, 0.553556388852371, -0.408147627572497, 0);
            Part.SketchManager.CreateSketchSlot((int)swSketchSlotCreationType_e.swSketchSlotCreationType_center_line, (int)swSketchSlotLengthType_e.swSketchSlotLengthType_CenterCenter, 0.434645807379192, 0, 0, 0, 0.353245820902068, 0, 0, 0, 0, 0, 1, false);
            Part.SketchManager.InsertSketch(true);
            Part.ClearSelection2(true);
            Part.Extension.SelectByID2("", "FACE", -7.99999999999994, -0.296707483999711, -0.152796546734919, false, 0, null, 0);
            Part.SketchManager.InsertSketch(true);
            Part.ClearSelection2(true);
            Part.SketchManager.CreateLine(-0.75, 0.8, 0, 0.75, 0.8, 0);
            Part.SketchManager.CreateLine(0.75, 0.8, 0, 0.75, 0, 0);
            Part.SketchManager.CreateLine(0.75, 0, 0, -0.75, 0, 0);
            Part.SketchManager.CreateLine(-0.75, 0, 0, -0.75, 0.8, 0);
            //Part.SetPickMode();
            Part.ClearSelection2(true);
            //Part.SketchManager.InsertSketch(false);
            //Part.Extension.SelectByID2("Sketch3", "SKETCH", -2.80409477329613E-02, 0.408147627572497, 0, true, 0, null, 0);
            //Part.ClearSelection2(true);
            //Part.Extension.SelectByID2("Sketch4", "SKETCH", -8, 0.8, -0.75, false, 1, null, 0);
            //Part.Extension.SelectByID2("Sketch3", "SKETCH", -2.80409477329613E-02, 0.408147627572497, 0, true, 1, null, 0);
            //Part.DeSelectByID("Sketch3", "SKETCH", -2.80409477329613E-02, 0.408147627572497, 0);
            //Part.Extension.SelectByID2("Sketch3", "SKETCH", -2.80409477329613E-02, 0.408147627572497, 0, true, 1, null, 0);
            //Part.FeatureManager.InsertProtrusionBlend(false, true, false, 1, 0, 0, 1, 1, true, true, false, 0, 0, 0, true, true, true);
            bool boolstatus;
            boolstatus = Part.Extension.SelectByID2("Sketch3", "SKETCH", -0.253844899360843, 0.408147627572497, 0, true, 0, null, 0);
            boolstatus = Part.Extension.SelectByID2("Sketch4", "SKETCH", -0.422763854958134, 0, 0, true, 0, null, 0);
            boolstatus = Part.DeSelectByID("Sketch4", "SKETCH", -0.75, 0.295114728382344, 0);
            boolstatus = Part.Extension.SelectByID2("Sketch4", "SKETCH", -0.75, 0.295114728382344, 0, true, 0, null, 0);
            boolstatus = Part.DeSelectByID("Sketch4", "SKETCH", -0.548309646518064, 0.8, 0);
            boolstatus = Part.Extension.SelectByID2("Sketch4", "SKETCH", -0.548309646518064, 0.8, 0, true, 0, null, 0);
            Part.ClearSelection2(true);
            boolstatus = Part.Extension.SelectByID2("Sketch3", "SKETCH", -0.253844899360843, 0.408147627572497, 0, false, 1, null, 0);
            boolstatus = Part.Extension.SelectByID2("Sketch4", "SKETCH", -0.548309646518064, 0.8, 0, true, 1, null, 0);
            Part.FeatureManager.InsertProtrusionBlend(false, true, false, 1, 0, 0, 1, 1, true, true, false, 0, 0, 0, true, true, true);
            Part.Extension.SelectByID2("", "FACE", -965.89 / 100.0, 31.67 / 100.0, -7.12 / 100.0, false, 0, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.07, 0.01, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));

        }

        private void frontWing()
        {
            var Part = swDoc;
            double horizontalPosition = 150 / 100.0;
            double verticalPosition = 15.0 / 100.0;
            double wingLength = 400.0 / 100.0;
            double wingThickness = 10.0 / 100.0;

            double minCoorx = 800.0 / 100.0;
            double maxCoorx = 1000.0 / 100.0;
            double minCoory = -20.0 / 100.0;
            double maxCoory = 70.0 / 100.0;
            double minVerticalPosForPlane = 40.0 / 100.0;
            double maxVerticalPosForPlane = 70.0 / 100.0;

            double x1ForWing = minCoorx + horizontalPosition;
            double x2ForWing = x1ForWing - 0.37;
            double y1ForWing = wingLength / 2.0;
            double y2ForWing = y1ForWing - 0.15;

            Part.Extension.SelectByID2("", "FACE", -7.12654479544284, -0.399999999999991, 0.143392113246762, true, 0, null, 0);
            Part.FeatureManager.InsertRefPlane(264, minVerticalPosForPlane + verticalPosition, 0, 0, 0, 0);
            Part.Extension.SelectByID2("Plane2", "PLANE", -6.95448737120442, 1.67659184505504, -1.93606080449792, false, 0, null, 0);
            Part.SketchManager.InsertSketch(true);
            Part.ClearSelection2(true);
            Part.SketchManager.CreateLine(x1ForWing, y1ForWing, 0, x2ForWing, y2ForWing, 0);
            Part.SketchManager.CreateLine(x2ForWing, y2ForWing, 0, x2ForWing, -y2ForWing, 0);
            Part.SketchManager.CreateLine(x2ForWing, -y2ForWing, 0, x1ForWing, -y1ForWing, 0);
            Part.SketchManager.CreateLine(x1ForWing, -y1ForWing, 0, x1ForWing, y1ForWing, 0);
            //Part.SketchManager.CreateLine(9.190258, 1.862041, 0, 9.576248, 2.01019, 0);
            //Part.SketchManager.CreateLine(9.576248, 2.01019, 0, 9.576248, -2.08774, 0);
            //Part.SketchManager.CreateLine(9.576248, -2.08774, 0, 9.190258, -1.906886, 0);
            //Part.SketchManager.CreateLine(9.190258, -1.906886, 0, 9.190258, 1.862041, 0);
            Part.SetPickMode();
            Part.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, wingThickness, 0.01, false, false, false, false, 1.74532925199433E-02, 1.74532925199433E-02, false, false, false, false, true, true, true, 0, 0, false);
            Part.SelectionManager.EnableContourSelection = false;

            double xForSelecting = ((-minCoorx) - horizontalPosition) + 0.05;
            double y1ForSelecting = verticalPosition;
            double y2ForSelecting = verticalPosition - wingThickness;
            double z1ForSelecting = wingLength / 2.0 - 0.15;
            double z2ForSelecting = (-wingLength / 2.0) + 0.15;
            Part.ClearSelection2(true);
            Part.Extension.SelectByID2("", "FACE", xForSelecting, y1ForSelecting, z1ForSelecting, false, 0, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.04, 0.01, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));
            Part.Extension.SelectByID2("", "FACE", xForSelecting, y2ForSelecting, z1ForSelecting, false, 0, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.04, 0.01, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));
            Part.Extension.SelectByID2("", "FACE", xForSelecting, y1ForSelecting, z2ForSelecting, false, 0, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.04, 0.01, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));
            Part.Extension.SelectByID2("", "FACE", xForSelecting, y2ForSelecting, z2ForSelecting, false, 0, null, 0);
            Part.FeatureManager.FeatureFillet3(195, 0.04, 0.01, 0, 0, 0, 0, (0), (0), (0), (0), (0), (0), (0));
        }

        private void rotateCamera1()
        {

        }

        private void initSolidworks()
        {
            sldApp = new SldWorks();
            int longstatus = 0;
            sldApp.ActivateDoc2("Part2", false, ref longstatus);
            swDoc = ((ModelDoc2)(sldApp.ActiveDoc));
        }
        private void createPart()
        {
            swDoc = null;
            int longstatus = 0;
            swDoc = ((ModelDoc2)(sldApp.NewDocument("C:\\ProgramData\\SOLIDWORKS\\SOLIDWORKS 2016\\templates\\Part.prtdot", 0, 0, 0)));
            sldApp.ActivateDoc2("Part2", false, ref longstatus);
            swDoc = ((ModelDoc2)(sldApp.ActiveDoc));
            ModelView myModeview = null;
            myModeview = ((ModelView)(swDoc.ActiveView));
            myModeview.FrameState = ((int)(swWindowState_e.swWindowMaximized));
        }
        private void createAssembly()
        {
            swDoc = ((ModelDoc2)(sldApp.NewDocument("C:\\ProgramData\\SOLIDWORKS\\SOLIDWORKS 2016\\templates\\Assembly.asmdot", 0, 0, 0)));
            int longstatus = 0;
            sldApp.ActivateDoc2("Assem7", false, ref longstatus);
            swDoc = ((ModelDoc2)(sldApp.ActiveDoc));
        }
    }
}
