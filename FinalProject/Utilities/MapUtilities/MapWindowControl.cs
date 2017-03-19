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

        private static int posX = 1300;
        private static int posY = 850;

        private static int moveSpeed = 5;

        private static int scale = 1600;
        public static int xZoom = 20;
        public static int yZoom = 20;
        public static int zoomLevels = 20;

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
            map = new NoiseMap(windowWidth + 1, windowHeight + 1, 3465, xZoom, yZoom, scale, 8, 0.85f, 1.5f, windowWidth / 2 + posX, windowHeight / 2 + posY);
            //treeMap = new NoiseMap(SCREEN_WIDTH, SCREEN_HEIGHT, 86263, scale, 8, 0.75f, 1.5f, SCREEN_WIDTH / 2 + posX, SCREEN_HEIGHT / 2 + posY);
        }

        public static int[] Move(int moveX, int moveY, int zoom) {

            if (zoom == -1) if (xZoom > 1 && yZoom > 1) { xZoom -= 1; yZoom -= 1; };
            if (zoom == 1) if (xZoom < zoomLevels && yZoom < zoomLevels) { xZoom += 1; yZoom += 1; };

            posX += moveX * xZoom;
            posY += moveY * yZoom;

            map.Xzoom = xZoom;
            map.Yzoom = yZoom;
            map.OffsetX = posX;
            map.OffsetY = posY;

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
            for (int y = 0; y < windowHeight; y += 1) {
                //ChangeColors(prevColor, mapType);
                Console.Write(toWrite);
                Console.SetCursorPosition(windowLeft, windowTop + y);
                prevColor = temp;
                nextChar = ChangeColors(prevColor, mapType);
                toWrite = "";
                for (int x = 0; x < windowWidth; x++) {
                    if (y != windowHeight || x != windowWidth) {
                        temp = (int)map.Map[x, y];
                        if (temp > maxTemp) maxTemp = temp;
                        if (temp < minTemp) minTemp = temp;
                        if (temp == prevColor || prevColor == -1) {
                            if (x <= windowWidth - 1 && y != windowHeight) {
                                toWrite += "▒";//nextChar.ToString();
                                prevColor = temp;
                            }
                            if (x >= windowWidth - 1) {
                                prevColor = temp;
                                ChangeColors(prevColor, mapType);
                                Console.Write(toWrite);
                                toWrite = "";
                            }
                        } else {
                            ChangeColors(prevColor, mapType);
                            Console.Write(toWrite);
                            prevColor = temp;
                            //ChangeColors(prevColor, mapType);
                            toWrite = "▒";// nextChar.ToString();▒
                        }
                        //WriteScreen(temp, prevColor, toWrite);
                    }
                }
            }
        }

        static char ChangeColors(int c, string mapType) {
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
                return '▒';
            }
            if (mapType == "intro") {
                if (c == 0) {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Black;
                    return ' ';
                }
                if (c == 1) {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Black;
                    return '░';
                }
                if (c == 2) {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Black;
                    return '▒';
                }
                if (c == 3) {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Black;
                    return '▒';
                }
                if (c == 4) {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    return ' ';
                }
                if (c == 5) {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    return '░';
                }
                if (c == 6) {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    return '▒';
                }
                if (c == 7) {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    return '▒';
                }
                if (c == 8) {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    return ' ';
                }
                if (c == 9) {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    return '░';
                }
                if (c == 15) {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.White;
                    return '▒';
                }
            }
            return '!';
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
