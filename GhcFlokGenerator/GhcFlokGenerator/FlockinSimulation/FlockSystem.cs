using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Rhino.Geometry;

namespace GhcFlokGenerator.FlockinSimulation
{
    public class FlockSystem
    {

        public List<FlockAgent> Agents;

        public double Timestep;
        public double NeighbourhoodRadius;
        public double FieldOfView;
        public double AlignmentStrength;
        public double CohesionStrength;
        public double SeparationStrength;
        public double SeparationDistance;
        public double MinSpeed;
        public double MaxSpeed;
        public List<Circle> Repellers;
        public bool UseRTree;

        public FlockSystem(int agentCount, bool is3D)
        {
            Agents = new List<FlockAgent>();

            if (is3D)
            {
                for (int i = 0; i < agentCount; i++)
                {
                    FlockAgent agent = new FlockAgent(
                            Util.GetRandomPoint(0.0, 30.0, 0.0, 30.0, 0.0, 30.0),
                            Util.GetRandomUnitVector() * 4
                        );

                    agent.FlockSystem = this;

                    Agents.Add(agent);
                }
            }
            else
            {
                for (int i = 0; i < agentCount; i++)
                {
                    FlockAgent agent = new FlockAgent(
                            Util.GetRandomPoint(0.0, 30.0, 0.0, 30.0, 0.0, 0.0),
                            Util.GetRandomUnitVectorXY() * 4    
                        );

                    agent.FlockSystem = this;

                    Agents.Add(agent);
                }
            }
        }

        public void Update()
        {
            foreach (FlockAgent agent in Agents)
            {
                agent.UpdateVelocityAndPosition();
            }
        }

    }
}
