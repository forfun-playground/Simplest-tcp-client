using System;
using System.Collections.Generic;
using ForFun.Playground.SimpleTcpClient.Meta;
using ForFun.Playground.SimpleTcpClient.Pipeline;
using forfun.sandbox.uwns.util.pack.flat;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Handlers
{
    public class FlatbufResponseSnapshot : InboundMessageHandlerBase<Packet, Metadata>
    {
        public override bool IsAccept(Packet pkt)
        {
            return pkt.DataType == Message.SnapshotResponse;
        }

        public override Metadata Process(Packet pkt)
        {
            var snapshot = new Snapshot();
            var response = pkt.Data<SnapshotResponse>().Value;
            try
            {
                snapshot.Radius = response.Radius;
                snapshot.Targets.AddRange(BuildListOfMetaTargets(response));
                snapshot.Players.AddRange(BuildListOfMetaPlayable(response));
                snapshot.NonPlayers.AddRange(BuildListOfMetaNonPlayable(response));
            }
            catch (Exception e)
            {
                Debug.Log(" FlatbufResponseSnapshot: " + e.Message + e.StackTrace);
            }
            return snapshot;
        }

        private IEnumerable<Snapshot.Target> BuildListOfMetaTargets(SnapshotResponse response)
        {
            var metalist = new List<Snapshot.Target>();
            for (var i = 0; i < response.TargetsLength; i++)
            {
                var actor = response.Targets(i);
                var metaactor = BuildOfMetaTarget(actor.Value);
                metalist.Add(metaactor);
            }
            return metalist;
        }

        private Snapshot.Target BuildOfMetaTarget(Actor actor)
        {
            return new Snapshot.Target()
            {
                Uid = actor.Uid,
                Active = actor.Active,
                Position = BuildOfMetaVector(actor.Position)
            };
        }

        private IEnumerable<Snapshot.Playable> BuildListOfMetaPlayable(SnapshotResponse response)
        {
            var metalist = new List<Snapshot.Playable>();
            for (var i = 0; i < response.PlayersLength; i++)
            {
                var agent = response.Players(i);
                var metaagent = BuildOfMetaPlayable(agent.Value);
                metalist.Add(metaagent);
            }
            return metalist;
        }

        private Snapshot.Playable BuildOfMetaPlayable(Agent agent)
        {
            return new Snapshot.Playable()
            {
                Uid = agent.Uid,
                Active = agent.Active,
                Tid = agent.Tid,
                Position = BuildOfMetaVector(agent.Position),
                Velocity = BuildOfMetaVector(agent.Velocity)
            };
        }

        private IEnumerable<Snapshot.NonPlayable> BuildListOfMetaNonPlayable(SnapshotResponse response)
        {
            var metalist = new List<Snapshot.NonPlayable>();
            for (var i = 0; i < response.NonPlayersLength; i++)
            {
                var agent = response.NonPlayers(i);
                var metaagent = BuildOfMetaNonPlayable(agent.Value);
                metalist.Add(metaagent);
            }
            return metalist;
        }

        private Snapshot.NonPlayable BuildOfMetaNonPlayable(Agent agent)
        {
            return new Snapshot.NonPlayable()
            {
                Uid = agent.Uid,
                Active = agent.Active,
                Tid = agent.Tid,
                Position = BuildOfMetaVector(agent.Position),
                Velocity = BuildOfMetaVector(agent.Velocity)
            };
        }

        private Metadata.Vector BuildOfMetaVector(Vector vector)
        {
            return new Metadata.Vector()
            {
                X = vector.X,
                Y = vector.Y
            };
        }
    }
}