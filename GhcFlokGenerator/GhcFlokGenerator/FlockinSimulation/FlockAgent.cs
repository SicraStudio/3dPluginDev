using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Rhino.Geometry;

namespace GhcFlokGenerator.FlockinSimulation
{
    public class FlockAgent
    {

        public Point3d Position;
        public Vector3d Velocity;

        public FlockSystem FlockSystem;

        public FlockAgent(Point3d position, Vector3d velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        public void UpdateVelocityAndPosition()
        {
            Position += Velocity;
        }

    }
}
