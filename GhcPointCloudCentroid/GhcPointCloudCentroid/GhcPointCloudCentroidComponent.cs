using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GhcPointCloudCentroid
{
    public class GhcPointCloudCentroidComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public GhcPointCloudCentroidComponent()
          : base("Centroid", "Centroid",
              "Finds the centroid of a cloud of point and compute the distance from the centroid to the points",
              "Workshop", "Utilities")
        {

        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {

            pManager.AddPointParameter("Points", "Pts", "Points", GH_ParamAccess.list);

        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {

            pManager.AddPointParameter("Centroid", "Centroid", "Centroid", GH_ParamAccess.item);
            pManager.AddNumberParameter("Distances", "Distances", "Distance from points to the centroid", GH_ParamAccess.list);

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            List<Point3d> iPoints = new List<Point3d>();
            DA.GetDataList("Points", iPoints);

            Point3d centroid = new Point3d(0.0, 0.0, 0.0);

            foreach (Point3d point in iPoints)
            {
                centroid += point;
            }

            centroid /= iPoints.Count;

            DA.SetData("Centroid", centroid);

            List<double> distances = new List<double>();

            foreach (Point3d point in iPoints)
            {
                distances.Add(centroid.DistanceTo(point));
            }

            DA.SetDataList("Distances", distances);
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
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{4788aae0-4dbe-4d16-9caf-f5231a160a0d}"); }
        }
    }
}
