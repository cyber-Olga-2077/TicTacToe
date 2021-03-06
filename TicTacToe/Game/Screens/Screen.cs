﻿using System;
using System.Collections.Generic;
using TicTacToe.Game.Data;
using TicTacToe.Game.GUI.RenderObjects;

namespace TicTacToe.Game.Screens
{
    internal abstract class Screen : IScreen, IDisposable
    {
        public Gamestate Gamestate { get; protected set; }
        public PlayersManager PlayersManager { get; protected set; }
        public ScreenType EScreen { get; protected set; }
        public int ScreenWidth { get; protected set; }
        public int ScreenHeight { get; protected set; }

        public Screen(Gamestate gamestate, PlayersManager playersManager, ScreenType eScreen)
        {
            Gamestate = gamestate;
            PlayersManager = playersManager;
            EScreen = eScreen;
        }

        public abstract List<IRenderObject> GetRenderData();

        public ScreenType GetEScreen()
        {
            return EScreen;
        }

        public abstract void Dispose();
    }
}