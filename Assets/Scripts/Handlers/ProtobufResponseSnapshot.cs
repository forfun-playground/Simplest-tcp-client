using System;
using System.Collections.Generic;
using System.Linq;
using Forfun.Sandbox.Uwns.Client.Sheme.Proto;
using Meta;
using Pipeline;
using UnityEngine;

namespace Handlers
{
    public class ProtobufResponseSnapshot : InboundMessageHandlerBase<Message, Metadata>
    {
        public override bool IsAccept(Message msg)
        {
            return msg.RequestCase == Message.RequestOneofCase.SnapshotResponse;
        }

        public override Metadata Process(Message msg)
        {
            var response = msg.SnapshotResponse;
            var snapshot = new Snapshot();
            try
            {
                snapshot.Radius = response.Radius;
                snapshot.Targets.AddRange(BuildListOfMetaTargets(response.Targets));
                snapshot.Players.AddRange(BuildListOfMetaPlayable(response.Players));
                snapshot.NonPlayers.AddRange(BuildListOfMetaNonPlayable(response.NonPlayers));
            }
            catch (Exception e)
            {
                Debug.Log(" ProtobufResponseSnapshot: " + e.Message + e.StackTrace);
            }

            return snapshot;
        }

        private IEnumerable<Snapshot.Target> BuildListOfMetaTargets(IEnumerable<Actor> actors)
        {
            return actors.Select(BuildOfMetaTarget).ToList();
        }

        private Snapshot.Target BuildOfMetaTarget(Actor actor)
        {
            return new Snapshot.Target()
            {
                Uid = actor.Uid,
                Active = actor.Active,
                Position = MetaVectorBuild(actor.Position)
            };
        }

        private IEnumerable<Snapshot.Playable> BuildListOfMetaPlayable(IEnumerable<Agent> agents)
        {
            return agents.Select(BuildOfMetaPlayable).ToList();
        }

        private Snapshot.Playable BuildOfMetaPlayable(Agent agent)
        {
            return new Snapshot.Playable()
            {
                Uid = agent.Uid,
                Active = agent.Active,
                Tid = agent.TargetId,
                Position = MetaVectorBuild(agent.Position),
                Velocity = MetaVectorBuild(agent.Velocity)
            };
        }

        private IEnumerable<Snapshot.NonPlayable> BuildListOfMetaNonPlayable(IEnumerable<Agent> agents)
        {
            return agents.Select(BuildOfNonPlayable).ToList();
        }

        private Snapshot.NonPlayable BuildOfNonPlayable(Agent agent)
        {
            return new Snapshot.NonPlayable()
            {
                Uid = agent.Uid,
                Active = agent.Active,
                Tid = agent.TargetId,
                Position = MetaVectorBuild(agent.Position),
                Velocity = MetaVectorBuild(agent.Velocity)
            };
        }

        private static Metadata.Vector MetaVectorBuild(Vector vector)
        {
            return new Metadata.Vector()
            {
                X = vector.X,
                Y = vector.Y
            };
        }
    }
}