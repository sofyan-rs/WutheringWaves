﻿using GameServer.Systems.Entity.Component;
using Protocol;

namespace GameServer.Systems.Entity;
internal class PlayerEntity : EntityBase
{
    public PlayerEntity(long id, int configId, int playerId) : base(id)
    {
        ConfigId = configId;
        PlayerId = playerId;
    }

    public int ConfigId { get; }
    public int PlayerId { get; }

    public override void AddComponents()
    {
        base.AddComponents();

        EntityConcomitantsComponent concomitantsComponent = ComponentSystem.Create<EntityConcomitantsComponent>();
        concomitantsComponent.CustomEntityIds.Add(Id);

        EntityVisionSkillComponent visionSkillComponent = ComponentSystem.Create<EntityVisionSkillComponent>();
        visionSkillComponent.SetExploreTool(1001);

        _ = ComponentSystem.Create<EntityAttributeComponent>();
        InitAttributes();
    }

    private void InitAttributes()
    {
        EntityAttributeComponent attributeComponent = ComponentSystem.Get<EntityAttributeComponent>();
        attributeComponent.SetAttribute(EAttributeType.Life, 1000);
        attributeComponent.SetAttribute(EAttributeType.LifeMax, 1000);
        attributeComponent.SetAttribute(EAttributeType.Lv, 1);
    }

    public override EEntityType Type => EEntityType.Player;
    public override EntityConfigType ConfigType => EntityConfigType.Character;

    public override EntityPb Pb
    {
        get
        {
            EntityPb pb = new()
            {
                Id = Id,
                EntityType = (int)Type,
                ConfigType = (int)ConfigType,
                EntityState = (int)State,
                ConfigId = ConfigId,
                Pos = Pos,
                Rot = Rot,
                PlayerId = PlayerId,
                LivingStatus = (int)LivingStatus,
                IsVisible = IsVisible,
                InitLinearVelocity = new(),
                InitPos = new()
            };

            pb.ComponentPbs.AddRange(ComponentSystem.Pb);

            return pb;
        }
    }
}
