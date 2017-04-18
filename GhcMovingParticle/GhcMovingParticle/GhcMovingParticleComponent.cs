using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace GhcMovingParticle
{
    public class GhcMovingParticleComponent : GH_Component
    {

        Point3d currentPosition = new Point3d(0.0, 0.0, 0.0);

        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public GhcMovingParticleComponent()
          : base("Moving Particle", "MvPrtc",
              "Creates a moving point in the direction specified by the user",
              "Workshop", "Utilities")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Reset", "Reset", "Resets the point position", GH_ParamAccess.item);
            pManager.AddVectorParameter("Velocity", "Velocity", "Velocity of the motion", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Play", "Play", "Play", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Particle", "Particle", "Produced particle", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // we get the data form the params inputs
            bool iReset = true;
            DA.GetData(0, ref iReset);

            Vector3d iVelocity = new Vector3d();
            DA.GetData(1, ref iVelocity);

            bool iPlay = true;
            DA.GetData(2, ref iPlay);


            if (iReset)
            {
                currentPosition = new Point3d(0.0, 0.0, 0.0);
                return;
            }


            currentPosition += iVelocity;
            // outputting data
            DA.SetData(0, currentPosition);

            if (iPlay)
            {
                // recomputing component
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
            get { return new Guid("{9367f0af-ec0c-428d-a330-60afe380e4dd}"); }
        }
    }
}
