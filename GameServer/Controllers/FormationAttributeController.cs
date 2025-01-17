﻿using GameServer.Controllers.Attributes;
using GameServer.Network;
using GameServer.Network.Messages;
using Protocol;

namespace GameServer.Controllers;
internal class FormationAttributeController : Controller
{
    public FormationAttributeController(PlayerSession session) : base(session)
    {
        // FormationAttributeController.
    }

    [NetEvent(MessageId.TimeCheckRequest)]
    public ResponseMessage OnTimeCheckRequest() => Response(MessageId.TimeCheckResponse, new TimeCheckResponse());

    [NetEvent(MessageId.FormationAttrRequest)]
    public ResponseMessage OnFormationAttrRequest() => Response(MessageId.FormationAttrResponse, new FormationAttrResponse());
}
