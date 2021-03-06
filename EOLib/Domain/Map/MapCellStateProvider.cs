﻿// Original Work Copyright (c) Ethan Moffat 2014-2016
// This file is subject to the GPL v2 License
// For additional details, see the LICENSE file

using System.Linq;
using EOLib.Domain.Character;
using EOLib.Domain.Extensions;
using EOLib.Domain.NPC;
using EOLib.IO.Map;
using EOLib.IO.Repositories;

namespace EOLib.Domain.Map
{
    public class MapCellStateProvider : IMapCellStateProvider
    {
        private readonly ICurrentMapStateProvider _mapStateProvider;
        private readonly IMapFileProvider _mapFileProvider;

        public MapCellStateProvider(ICurrentMapStateProvider mapStateProvider,
                                    IMapFileProvider mapFileProvider)
        {
            _mapStateProvider = mapStateProvider;
            _mapFileProvider = mapFileProvider;
        }

        public IMapCellState GetCellStateAt(int x, int y)
        {
            if (x < 0 || y < 0 || x > CurrentMap.Properties.Width || y > CurrentMap.Properties.Height)
                return new MapCellState {TileSpec = TileSpec.MapEdge};

            var tileSpec = CurrentMap.Tiles[y, x];
            var warp = CurrentMap.Warps[y, x];
            var chest = CurrentMap.Chests.FirstOrDefault(c => c.X == x && c.Y == y);
            var sign = CurrentMap.Signs.FirstOrDefault(s => s.X == x && s.Y == y);

            var character = _mapStateProvider.Characters.FirstOrDefault(c => CharacterAtCoordinates(c, x, y));
            var npc = _mapStateProvider.NPCs.FirstOrDefault(n => NPCAtCoordinates(n, x, y));
            var items = _mapStateProvider.MapItems.Where(i => i.X == x && i.Y == y);

            return new MapCellState
            {
                Items     = items.ToList(),
                TileSpec  = tileSpec,
                Warp      = warp == null ? Optional<IWarp>.Empty : new Warp(warp),
                Chest     = chest == null ? Optional<IChest>.Empty : new Chest(chest),
                Sign      = sign == null ? Optional<ISign>.Empty : new Sign(sign),
                Character = character == null ? Optional<ICharacter>.Empty : new Optional<ICharacter>(character),
                NPC       = npc == null ? Optional<INPC>.Empty : new Optional<INPC>(npc)
            };
        }

        private static bool CharacterAtCoordinates(ICharacter character, int x, int y)
        {
            return character.RenderProperties.IsActing(CharacterActionState.Walking)
                ? character.RenderProperties.GetDestinationX() == x && character.RenderProperties.GetDestinationY() == y
                : character.RenderProperties.MapX == x && character.RenderProperties.MapY == y;
        }

        private static bool NPCAtCoordinates(INPC npc, int x, int y)
        {
            return npc.IsActing(NPCActionState.Walking)
                ? npc.GetDestinationX() == x && npc.GetDestinationY() == y
                : npc.X == x && npc.Y == y;
        }

        private IMapFile CurrentMap => _mapFileProvider.MapFiles[_mapStateProvider.CurrentMapID];
    }

    public interface IMapCellStateProvider
    {
        IMapCellState GetCellStateAt(int x, int y);
    }
}