using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace GhcFlokGenerator
{
    public class GhcFlokGeneratorInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "GhcFlokGenerator";
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
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("f10b3c44-3912-462e-ba5e-50ec32c5232c");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
