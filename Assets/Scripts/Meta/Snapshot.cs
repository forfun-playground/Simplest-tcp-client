using System.Collections.Generic;

namespace ForFun.Playground.SimpleTcpClient.Meta
{
    public class Snapshot : Metadata
    {
        public float Radius;
        public readonly List<Target> Targets = new List<Target>();
        public readonly List<Playable> Players = new List<Playable>();
        public readonly List<NonPlayable> NonPlayers = new List<NonPlayable>();

        public List<Actor> GetAllActors()
        {
            var allActors = new List<Actor>();
            allActors.AddRange(Targets);
            allActors.AddRange(Players);
            allActors.AddRange(NonPlayers);
            return allActors;
        }

        public class Actor
        {
            public int Uid;
            public bool Active;
            public Vector Position;
        }

        public class Target : Actor { }

        public class Agent : Actor
        {
            public int Tid;
            public Vector Velocity;
        }

        public class Playable : Agent { }

        public class NonPlayable : Agent { }

    }
}