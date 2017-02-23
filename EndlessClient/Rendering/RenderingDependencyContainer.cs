﻿// Original Work Copyright (c) Ethan Moffat 2014-2016
// This file is subject to the GPL v2 License
// For additional details, see the LICENSE file

using EndlessClient.Rendering.Character;
using EndlessClient.Rendering.CharacterProperties;
using EndlessClient.Rendering.Chat;
using EndlessClient.Rendering.Factories;
using EndlessClient.Rendering.Map;
using EndlessClient.Rendering.MapEntityRenderers;
using EndlessClient.Rendering.NPC;
using EndlessClient.Rendering.Sprites;
using EOLib.DependencyInjection;
using EOLib.Domain.Notifiers;
using Microsoft.Practices.Unity;

namespace EndlessClient.Rendering
{
    public class RenderingDependencyContainer : IDependencyContainer
    {
        public void RegisterDependencies(IUnityContainer container)
        {
            //factories
            container
                .RegisterType<ICharacterRendererFactory, CharacterRendererFactory>()
                .RegisterType<INPCRendererFactory, NPCRendererFactory>()
                .RegisterType<IRenderTargetFactory, RenderTargetFactory>()
                .RegisterType<IMapRendererFactory, MapRendererFactory>()
                .RegisterType<IMouseCursorRendererFactory, MouseCursorRendererFactory>();

            //character
            container
                .RegisterType<ICharacterPropertyRendererBuilder, CharacterPropertyRendererBuilder>()
                .RegisterType<ICharacterTextures, CharacterTextures>()
                .RegisterType<ICharacterSpriteCalculator, CharacterSpriteCalculator>()
                .RegisterVaried<IOtherCharacterAnimationNotifier, CharacterAnimationActions>()
                .RegisterInstance<ICharacterRendererProvider, CharacterRendererRepository>()
                .RegisterInstance<ICharacterRendererRepository, CharacterRendererRepository>()
                .RegisterInstance<ICharacterStateCache, CharacterStateCache>()
                .RegisterType<ICharacterRendererUpdater, CharacterRendererUpdater>()
                .RegisterType<ICharacterAnimationActions, CharacterAnimationActions>();

            //map
            container
                .RegisterType<IMapRenderDistanceCalculator, MapRenderDistanceCalculator>()
                .RegisterType<IRenderOffsetCalculator, RenderOffsetCalculator>()
                .RegisterVaried<IMapChangedNotifier, MapChangedActions>()
                .RegisterType<IMapChangedActions, MapChangedActions>()
                .RegisterInstance<IMapEntityRendererProvider, MapEntityRendererProvider>()
                .RegisterInstance<IMapItemGraphicProvider, MapItemGraphicProvider>()
                .RegisterInstance<IDoorStateUpdater, DoorStateUpdater>();

            //npc
            container
                .RegisterInstance<INPCRendererProvider, NPCRendererRepository>()
                .RegisterInstance<INPCRendererRepository, NPCRendererRepository>()
                .RegisterType<INPCSpriteSheet, NPCSpriteSheet>()
                .RegisterInstance<INPCStateCache, NPCStateCache>()
                .RegisterType<INPCRendererUpdater, NPCRendererUpdater>()
                .RegisterVaried<INPCActionNotifier, NPCActions>();

            //chat
            container
                .RegisterInstance<IChatBubbleTextureProvider, ChatBubbleTextureProvider>()
                .RegisterInstance<IChatBubbleRepository, ChatBubbleRepository>()
                .RegisterInstance<IChatBubbleProvider, ChatBubbleRepository>()
                .RegisterType<IChatBubbleUpdater, ChatBubbleUpdater>();

            container.RegisterType<IRendererRepositoryResetter, RendererRepositoryResetter>();
        }
    }
}
