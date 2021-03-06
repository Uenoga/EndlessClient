﻿// Original Work Copyright (c) Ethan Moffat 2014-2016
// This file is subject to the GPL v2 License
// For additional details, see the LICENSE file

using EOLib.Net.Translators;

namespace EOLib.Domain.Protocol
{
    public interface IInitializationData : ITranslatedData
    {
        InitReply Response { get; }

        int this[InitializationDataKey key] { get; }
    }

    public enum InitializationDataKey
    {
        //response: OK
        SequenceByte1,
        SequenceByte2,
        SendMultiple,
        ReceiveMultiple,
        ClientID,
        HashResponse,
        //response: Out of Date
        RequiredVersionNumber,
        //response: Banned
        BanType,
        BanTimeRemaining
    }
}
