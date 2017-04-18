using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GhcFlokGenerator
{
    public class GhcFlokGeneratorComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public GhcFlokGeneratorComponent()
          : base("GhcFlokGenerator", "Nickname",
              "Description",
              "Category", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Reset", "Reset", "Reset", GH_ParamAccess.item, false);
            pManager.AddBooleanParameter("Play", "Play", "Play", GH_ParamAccess.item, false);
            pManager.AddBooleanParameter("3d", "3d", "3d", GH_ParamAccess.item, false);
            pManager.AddIntegerParameter("Count", "Count", "Number of agents", GH_ParamAccess.item, 50);
            pManager.AddNumberParameter("Timestep", "Timestep", "Timestep", GH_ParamAccess.item, 0.02);
            pManager.AddNumberParameter("Neighbourhood Radius", "Neighbourhood Radius", "Neighbourhood Radius", GH_ParamAccess.item, 3.5);
            pManager.AddNumberParameter("Alignment", "Alignment", "Alignment", GH_ParamAccess.item, 0.5);
            pManager.AddNumberParameter("Cohesion", "Cohesion", "Cohesion", GH_ParamAccess.item, 0.5);
            pManager.AddNumberParameter("Separation", "Separation", "Separation", GH_ParamAccess.item, 0.5);
            pManager.AddNumberParameter("Separation Distance", "Separation Distance", "Separation Distance", GH_ParamAccess.item, 1.5);
            pManager.AddCircleParameter("Repellers", "Repellers", "Repellers", GH_ParamAccess.list);
            pManager[10].Optional = true;
            pManager.AddBooleanParameter("Use Parallel", "Use Parallel", "Use Parallel", GH_ParamAccess.item, false);
            pManager.AddBooleanParameter("Use R-Tree", "Use R-Tree", "Use R-Tree", GH_ParamAccess.item, false);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            bool iReset , iPlay, i3D, iUseParallel, iUseRTree;
            int iCount;
            double iTimestep, iNeighbourhoodRadius, iAlignment, iCohesion, iSeparation, iSeparationDistance;
            List<Circle> iRepellers = new List<Circle>();


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
            get { return new Guid("{167891ee-541b-4926-912c-967e153a97ef}"); }
        }
    }
}
