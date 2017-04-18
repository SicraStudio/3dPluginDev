using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace AnimatedCircularWeaving
{
    public class AnimatedCircularWeavingInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "AnimatedCircularWeaving";
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
                return new Guid("8a7f1f53-6304-4600-86ab-e8d49af79334");
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
