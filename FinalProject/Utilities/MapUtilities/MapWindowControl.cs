using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    public static class MapWindowControl {

        #region Fields
        private static int windowWidth;
        private static int windowHeight;
        private static int windowLeft;
        private static int windowTop;

        private static NoiseMap map;
        private static NoiseMap treeMap;
        private static NoiseMap rockMap;

        private static int posX = 1332;
        private static int posY = 866;

        private static int moveSpeed = 5;

        private static int scale = 1600;
        public static int xZoom = 20;
        public static int yZoom = 20;
        public static int zoomLevels = 20;

        public static int seed = 3465;

        private static Random prng = new Random();
        #endregion Fields

        #region Properties
        public static int Zoom {
            get { return xZoom; }
            set { xZoom = value; yZoom = value; }
        }

        public static int WindowWidth {
            get { return windowWidth; }
        }

        public static int WindowHeight {
            get { return windowHeight; }
        }

        public static int WindowLeft {
            get { return windowLeft; }
        }

        public static int WindowTop {
            get { return windowTop; }
        }

        public static NoiseMap Map {
            get { return map; }
        }

        #endregion

        #region Methods
        public static void InitializeMaps() {
            windowWidth = ConsoleLayout.MainBoxWidth - 2;
            windowHeight = ConsoleLayout.MainBoxHeight - 2;
            windowLeft = ConsoleLayout.MainBoxPositionLeft + 1;
            windowTop = ConsoleLayout.MainBoxPositionTop + 1;
            map = new NoiseMap(windowWidth + 1, windowHeight + 1, seed, xZoom, yZoom, scale, 8, 0.85f, 1.5f, windowWidth / 2 + posX, windowHeight / 2 + posY);
            treeMap = new NoiseMap(windowWidth + 1, windowHeight + 1, seed+1, xZoom, yZoom, scale*.125f, 8, 0.85f, 1.8f, windowWidth / 2 + posX, windowHeight / 2 + posY);
            rockMap = new NoiseMap(windowWidth + 1, windowHeight + 1, seed + 10, xZoom, yZoom, scale * .0125f, 8, 1f, 0.18f, windowWidth / 2 + posX, windowHeight / 2 + posY);
        }

        public static int[] Move(int moveX, int moveY, int zoom) {

            if (zoom == -1) if (xZoom > 1 && yZoom > 1) { xZoom -= 1; yZoom -= 1; };
            if (zoom == 1) if (xZoom < zoomLevels && yZoom < zoomLevels) { xZoom += 1; yZoom += 1; };

            posX += moveX * xZoom;
            posY += moveY * yZoom;


            // TODO encapsulate this
            map.Xzoom = xZoom;
            map.Yzoom = yZoom;
            map.OffsetX = posX;
            map.OffsetY = posY;

            treeMap.Xzoom = xZoom;
            treeMap.Yzoom = yZoom;
            treeMap.OffsetX = posX;
            treeMap.OffsetY = posY;

            rockMap.Xzoom = xZoom;
            rockMap.Yzoom = yZoom;
            rockMap.OffsetX = posX;
            rockMap.OffsetY = posY;

            int[] pos = { posX, posY };

            return pos;
        }

        public static void DrawScreen() {
            int minTemp = 15;
            int maxTemp = 0;
            Console.CursorVisible = false;
            Console.SetCursorPosition(windowLeft, windowTop);
            int prevColor = -1;
            string toWrite = "";
            string mapType = "terrain";
            char nextChar;
            int temp = -1;
            string terrainFeature = "first";
            string terrainFeaturePrev = "";
            bool changed = true;
            for (int y = 0; y < windowHeight; y += 1) {
                //ChangeColors(prevColor, mapType);
                //changed = false;
                Console.Write(toWrite);
                Console.SetCursorPosition(windowLeft, windowTop + y);
                prevColor = temp;
                terrainFeaturePrev = terrainFeature;
                nextChar = ChangeColors(prevColor, mapType, terrainFeaturePrev);
                toWrite = "";
                for (int x = 0; x < windowWidth; x++) {
                    if (y != windowHeight || x != windowWidth) {
                        changed = true;
                        terrainFeature = "";
                        if ((int)treeMap.Map[x, y] > 9 && prevColor > 4 && prevColor < 8)
                            terrainFeature = "tree";
                        if ((int)rockMap.Map[x, y] > 11 && prevColor > 4 && prevColor < 12)
                            terrainFeature = "rock";
                        temp = (int)map.Map[x, y];
                        if ((temp == prevColor || prevColor == -1) && (terrainFeature == terrainFeaturePrev))
                            changed = false;
                        if (!changed) {
                            if (x <= windowWidth - 1 && y != windowHeight) {
                                toWrite += "▒";//nextChar.ToString();
                                prevColor = temp;
                                terrainFeaturePrev = terrainFeature;
                            }
                            if (x >= windowWidth - 1) {
                                prevColor = temp;
                                terrainFeaturePrev = terrainFeature;
                                ChangeColors(prevColor, mapType, terrainFeaturePrev);
                                Console.Write(toWrite);
                                toWrite = "";
                            }
                        } else {
                            nextChar = ChangeColors(prevColor, mapType, terrainFeaturePrev);
                            Console.Write(toWrite);
                            prevColor = temp;
                            terrainFeaturePrev = terrainFeature;
                            //ChangeColors(prevColor, mapType);
                            toWrite = "▒";//nextChar.ToString();//▒
                        }
                        //WriteScreen(temp, prevColor, toWrite);
                    }
                }
            }
        }

        public static char ChangeColors(int c, string mapType, string environmentObject) {
            if (mapType == "terrain") {
                if (c == 0) {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                if (c == 1) {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                if (c == 2) {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                if (c == 3) {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                if (c == 4) {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                if (c == 5) {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                if (c == 6) {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                if (c == 7) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                if (c == 8) {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                if (c == 9) {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                if (c == 10) {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                if (c == 11) {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                if (c == 12) {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                if (c == 15) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                if (environmentObject == "tree") {
                    Console.ForegroundColor = ConsoleColor.Black;
                    return '1';
                }
                if (environmentObject == "rock") {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return 'o';
                }
                if (environmentObject == "player") {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    return 'X';
                }
                if (environmentObject == "item") {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    return '!';
                }
                if (environmentObject == "location") {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    return '^';
                }
                return '▒';
            }
            return '!';
        }

        // Returns the height of the center of the viewport (the player)
        public static int GetHeightAtPosition() {
            return (int)map.Map[(ConsoleLayout.MainBoxWidth - 2) / 2, (ConsoleLayout.MainBoxHeight - 2) / 2];
        }
        public static int GetHeightAtPosition(int x, int y) {
            return (int)map.Map[x, y];
        }
        public static int GetDistance(int x1, int y1, int x2, int y2) {
            return ((int)Math.Sqrt((x2-x1) * (x2-x1) + (y2-y1) * (y2 - y1)));
        }
        static string GetRandomAlpha() {
            return ((char)('A' + GetRandom(26))).ToString();
        }
        static int GetRandom(int _max) {
            return prng.Next(0, _max);
        }
        static int GetRandom(int _min, int _max) {
            return prng.Next(_min, _max);
        }
        #endregion
    }
}
