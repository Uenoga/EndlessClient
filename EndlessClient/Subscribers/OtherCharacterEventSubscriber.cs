﻿// Original Work Copyright (c) Ethan Moffat 2014-2017
// This file is subject to the GPL v2 License
// For additional details, see the LICENSE file

using EOLib.Domain.Notifiers;

namespace EndlessClient.Subscribers
{
    public class OtherCharacterEventSubscriber : IOtherCharacterEventNotifier
    {
        public void OtherCharacterTakeDamage(int characterID,
                                             int playerPercentHealth,
                                             int damageTaken)
        {
            //todo: show health bar
        }

        public void OtherCharacterSaySomething(int characterID, string message)
        {
            //todo: chat bubble
        }

        public void AdminAnnounce(string message)
        {
            //todo: chat bubbles for all visible characters
        }
    }
}
