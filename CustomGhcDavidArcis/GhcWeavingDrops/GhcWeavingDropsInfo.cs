using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace GhcWeavingDrops
{
    public class GhcWeavingDropsInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "GhcWeavingDrops";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "Created with the purpose of creating ripple waves on a grid of points.";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("c6f7eca1-b47f-454c-8163-e22ea1e0b3a7");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "David 'Sicra' Arcis for DAISA SL";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "darcis@es.lladro.com";
            }
        }
    }
}
