﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NitroxModel.DataStructures;
using NitroxServer.GameLogic;
using NitroxServer.GameLogic.Bases;
using NitroxServer.GameLogic.Entities;
using NitroxServer.GameLogic.Items;
using NitroxServer.GameLogic.Vehicles;
using ProtoBufNet;

namespace NitroxServer.Serialization.World
{
    [ProtoContract]
    public class WorldData
    {
        public const long VERSION = 1;

        [ProtoMember(1)]
        public List<Int3> ParsedBatchCells { get; set; }

        [ProtoMember(2)]
        public DateTime? ServerStartTime { get; set; }

        [ProtoMember(3)]
        public EntityData EntityData { get; set; }

        [ProtoMember(4)]
        public VehicleData VehicleData { get; set; }

        [ProtoMember(5)]
        public InventoryData InventoryData { get; set; }

        [ProtoMember(6)]
        public GameData GameData { get; set; }

        [ProtoMember(7)]
        public EscapePodData EscapePodData { get; set; }

        public bool IsValid()
        {
            return (ParsedBatchCells != null) && // Always returns false on empty saves
                   (ServerStartTime.HasValue) &&
                   (VehicleData != null) &&
                   (InventoryData != null) &&
                   (GameData != null) &&
                   (EntityData != null) &&
                   (EntityData.SerializableEntities.Count > 0) &&
                   (EscapePodData != null);
        }
    }
}
