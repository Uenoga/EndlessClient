﻿// Original Work Copyright (c) Ethan Moffat 2014-2016
// This file is subject to the GPL v2 License
// For additional details, see the LICENSE file

using System;
using System.Linq;
using System.Threading.Tasks;
using EOLib.Domain.Character;
using EOLib.Net.Builders;
using EOLib.Net.Communication;

namespace EOLib.Domain.Chat
{
    public class ChatActions : IChatActions
    {
        private readonly IChatRepository _chatRepository;
        private readonly ICharacterProvider _characterProvider;
        private readonly IChatTypeCalculator _chatTypeCalculator;
        private readonly IChatPacketBuilder _chatPacketBuilder;
        private readonly IPacketSendService _packetSendService;
        private readonly ILocalCommandHandler _localCommandHandler;
        private readonly IChatProcessor _chatProcessor;

        public ChatActions(IChatRepository chatRepository,
                           ICharacterProvider characterProvider,
                           IChatTypeCalculator chatTypeCalculator,
                           IChatPacketBuilder chatPacketBuilder,
                           IPacketSendService packetSendService,
                           ILocalCommandHandler localCommandHandler,
                           IChatProcessor chatProcessor)
        {
            _chatRepository = chatRepository;
            _characterProvider = characterProvider;
            _chatTypeCalculator = chatTypeCalculator;
            _chatPacketBuilder = chatPacketBuilder;
            _packetSendService = packetSendService;
            _localCommandHandler = localCommandHandler;
            _chatProcessor = chatProcessor;
        }

        public async Task SendChatToServer(string chat, string targetCharacter)
        {
            var chatType = _chatTypeCalculator.CalculateChatType(chat);

            if (chatType == ChatType.Command)
            {
                if (HandleCommand(chat))
                    return;

                //treat unhandled command as local chat
                chatType = ChatType.Local;
            }

            if (chatType == ChatType.PM)
            {
                if (string.IsNullOrEmpty(_chatRepository.PMTarget1))
                    _chatRepository.PMTarget1 = targetCharacter;
                else if (string.IsNullOrEmpty(_chatRepository.PMTarget2))
                    _chatRepository.PMTarget2 = targetCharacter;
            }

            chat = _chatProcessor.RemoveFirstCharacterIfNeeded(chat, chatType, targetCharacter);

            var chatPacket = _chatPacketBuilder.BuildChatPacket(chatType, chat, targetCharacter);
            await _packetSendService.SendPacketAsync(chatPacket);

            AddChatForLocalDisplay(chatType, chat, targetCharacter);
        }

        /// <summary>
        /// Returns true if the text is a command (#) and can be handled as such, false if it should be sent to the server as a public chat string
        /// </summary>
        private bool HandleCommand(string commandString)
        {
            var command = new string(commandString.Substring(1)
                .TakeWhile(x => x != ' ')
                .ToArray())
                .Trim();
            var parameters = new string(commandString.SkipWhile(x => x != ' ')
                .ToArray())
                .Trim();
            return _localCommandHandler.HandleCommand(command, parameters);
        }

        private void AddChatForLocalDisplay(ChatType chatType, string chat, string targetCharacter)
        {
            var who = _characterProvider.MainCharacter.Name;
            switch (chatType)
            {
                case ChatType.Admin:
                    _chatRepository.AllChat[ChatTab.Group].Add(new ChatData(who, chat, ChatIcon.HGM, ChatColor.Admin));
                    break;
                case ChatType.PM:
                    var chatData = new ChatData(who, chat, ChatIcon.Note, ChatColor.PM);

                    if(targetCharacter == _chatRepository.PMTarget1)
                        _chatRepository.AllChat[ChatTab.Private1].Add(chatData);
                    else if (targetCharacter == _chatRepository.PMTarget2)
                        _chatRepository.AllChat[ChatTab.Private2].Add(chatData);
                    else
                        throw new ArgumentException("Unexpected target character!", nameof(targetCharacter));

                    break;
                case ChatType.Local:
                    _chatRepository.AllChat[ChatTab.Local].Add(new ChatData(who, chat));
                    break;
                case ChatType.Global:
                    _chatRepository.AllChat[ChatTab.Global].Add(new ChatData(who, chat));
                    break;
                case ChatType.Guild:
                    //todo: there are special cases here for guild chat that aren't handled
                    _chatRepository.AllChat[ChatTab.Group].Add(new ChatData(who, chat));
                    break;
                case ChatType.Party:
                    _chatRepository.AllChat[ChatTab.Local].Add(new ChatData(who, chat, ChatIcon.PlayerPartyDark, ChatColor.PM));
                    _chatRepository.AllChat[ChatTab.Group].Add(new ChatData(who, chat, ChatIcon.PlayerPartyDark));
                    break;
                case ChatType.Announce:
                    _chatRepository.AllChat[ChatTab.Local].Add(new ChatData(who, chat, ChatIcon.GlobalAnnounce, ChatColor.ServerGlobal));
                    _chatRepository.AllChat[ChatTab.Global].Add(new ChatData(who, chat, ChatIcon.GlobalAnnounce, ChatColor.ServerGlobal));
                    _chatRepository.AllChat[ChatTab.Group].Add(new ChatData(who, chat, ChatIcon.GlobalAnnounce, ChatColor.ServerGlobal));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(chatType), chatType, "Unexpected ChatType encountered");
            }
        }
    }

    public interface IChatActions
    {
        Task SendChatToServer(string chat, string targetCharacter);
    }
}