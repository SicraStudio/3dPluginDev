using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

using GhcWeavingDrops.Properties;

namespace GhcWeavingDrops
{
    public class GhcWeavingDropsComponent : GH_Component
    {
        private const String RESET = "Reset";
        private const String ROWS = "Grid row count";
        private const String COLS = "Grid column count";
        private const String PTS = "Center point";
        private const String AMP = "Amplitude";
        private const String WAVE_LENGTH = "Wave length";
        private const String SPEED = "Speed";
        private const String FALLOFF = "Falloff";
        private const String PLAY = "Play";
        private const String OUT_POINTS = "Output Points";

        private double t = 0.0;


        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public GhcWeavingDropsComponent()
          : base("Surface Weaving Drops", "srfWaveDrops",
              "This component creates ripples along a grid of points with list of points as ripple centers",
              "Lladro", "Geo Generation")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {

            pManager.AddBooleanParameter(RESET, "reset", "Resets to initial state", GH_ParamAccess.item, true);
            pManager.AddIntegerParameter(ROWS, "rows", "Amount of rows in the points grid", GH_ParamAccess.item, 10);
            pManager.AddIntegerParameter(COLS, "cols", "Amount of columns in the points grid", GH_ParamAccess.item, 10);
            pManager.AddPointParameter(PTS, "center pts", "Points for the center of the ripples", GH_ParamAccess.list, new Point3d(0.0,0.0,0.0));
            pManager.AddNumberParameter(AMP, "amplitude", "Amplitudes of the ripples waves", GH_ParamAccess.list, 3.0);
            pManager.AddNumberParameter(WAVE_LENGTH, "wave length", "Ripples waves' length", GH_ParamAccess.list, 13.0);
            pManager.AddNumberParameter(SPEED, "speed", "Speed for rippling", GH_ParamAccess.list, 2.0);
            pManager.AddNumberParameter(FALLOFF, "falloff", "Waves falloff", GH_ParamAccess.list, 0.1);
            pManager.AddBooleanParameter(PLAY, "play", "Plays the animation", GH_ParamAccess.item, true);

        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter(OUT_POINTS, "output points", "Points in ripple", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            // user data inputs

            bool iReset = true;
            DA.GetData(RESET, ref iReset);

            int iRows = 0;
            DA.GetData(ROWS, ref iRows);

            int iCols = 0;
            DA.GetData(COLS, ref iCols);

            List<Point3d> iCenters = new List<Point3d>();
            DA.GetDataList(PTS, iCenters);

            List<double> iAmps = new List<double>();
            DA.GetDataList(AMP, iAmps);

            List<double> iWaveLengths = new List<double>();
            DA.GetDataList(WAVE_LENGTH, iWaveLengths);

            List<double> iSpeeds = new List<double>();
            DA.GetDataList(SPEED, iSpeeds);

            List<double> iFalloffs = new List<double>();
            DA.GetDataList(FALLOFF, iFalloffs);

            bool iPlay = false;
            DA.GetData(PLAY, ref iPlay);

            // END user data inputs


            // intermediate variables

            List<Point3d> basePoints = new List<Point3d>();

            double x, y, z, dist;

            // END intermediate variables


            if (iReset)
            {
                t = 0.0;
                //iPlay = false;
                return;
            }


            // grid gen

            for (int i = 0; i < iRows; i++)
            {
                for (int j = 0; j < iCols; j++)
                {
                    x = i;
                    y = j;
                    z = 0.0;

                    for (int k = 0; k < iCenters.Count; k++)
                    {
                        dist = iCenters[k].DistanceTo(new Point3d(x, y, 0.0));

                        z += iAmps[k] * Math.Cos((dist - t * iSpeeds[k]) / iWaveLengths[k] * 2.0 * Math.PI) / (1.0 + dist * iFalloffs[k]);
                    }

                    basePoints.Add(new Point3d(x, y, z));
                }
            }

            // END grid gen


            t += 0.1;


            // set output data

            DA.SetDataList(OUT_POINTS, basePoints);

            // END set output data


            // Move the butt!!!!!!!!
            if (iPlay)
            {
                ExpireSolution(true);
            }



        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return Resources.ic_wave_02;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{e148d353-9e0b-4ed3-9db2-4cad5096ee55}"); }
        }
    }
}
