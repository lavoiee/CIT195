﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    class MapView {

        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Player _player;
        World _world;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Default constructor to create the map view objects
        /// </summary>
        public MapView(Player gamePlayer, World gameWorld) {
            _player = gamePlayer;
            _world = gameWorld;

            //InitializeMap();
        }

        #endregion

        #region METHODS
        /*
        public void InitializeMap() {
            MapWindowControl.InitializeMaps();
        }

        public void DisplayWorldMap() {
            DisplayWorldMap(false);
        }

        public void DisplayWorldMap(bool zooming) {
            bool drawing = true;
            int zoom = MapWindowControl.zoomLevels;
            MapWindowControl.Zoom = zoom;
            ConsoleView.DisplayGamePlayScreen("Location Information", Text.CurrentLocationInfo(currentLocation), ActiveMenu.FullMenu, "");
            while (zoom > 0 && zooming) {
                MapWindowControl.Move(0, 0, -1);
                MapWindowControl.DrawScreen();
                zoom -= 1;
            }
            while (drawing) {
                drawing = MovePlayer();
                MapWindowControl.DrawScreen();
            }
        }

        public bool MovePlayer() {
            ConsoleKeyInfo response = Console.ReadKey();

            int moveX = 0;
            int moveY = 0;
            int zoom = 0;

            //if (response.KeyChar == '1') return false;
            if (response.KeyChar == '2') return false;
            if (response.KeyChar == '3') return false;
            if (response.KeyChar == '4') return false;
            if (response.KeyChar == '5') return false;
            if (response.Key == ConsoleKey.A) moveX = -_player.MoveSpeed;
            if (response.Key == ConsoleKey.D) moveX = _player.MoveSpeed;
            if (response.Key == ConsoleKey.W) moveY = _player.MoveSpeed;
            if (response.Key == ConsoleKey.S) moveY = -_player.MoveSpeed;
            if (response.Key == ConsoleKey.E) zoom = -1;
            if (response.Key == ConsoleKey.Q) zoom = 1;

            MapWindowControl.Move(moveX, moveY, zoom);

            return true;
        }
        */
        #endregion
    }
}
