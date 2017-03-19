using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    class Noise {
        /// <summary>
        /// Returns a map of coherent noise in a two dimensional array
        /// </summary>
        /// <param name="mapWidth"></param>
        /// <param name="mapHeight"></param>
        /// <param name="seed"></param>
        /// <param name="xZoom"></param>
        /// <param name="yZoom"></param>
        /// <param name="scale"></param>
        /// <param name="octaves"></param>
        /// <param name="persistance"></param>
        /// <param name="lacunarity"></param>
        /// <param name="_offsetX"></param>
        /// <param name="_offsetY"></param>
        /// <returns></returns>
        public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, int xZoom, int yZoom, float scale, int octaves, float persistance, float lacunarity, int _offsetX, int _offsetY) {
            float[,] noiseMap = new float[mapWidth, mapHeight];

            System.Random prng = new System.Random(seed);
            int[] offsetX = new int[octaves];
            int[] offsetY = new int[octaves];

            float maxPossibleHeight = 0;
            float amplitude = 1;
            float frequency = 1;

            for (int i = 0; i < octaves; i++) {
                offsetX[i] = prng.Next(-100000, 100000) + _offsetX;
                offsetY[i] = prng.Next(-100000, 100000) - _offsetY;

                maxPossibleHeight += amplitude;
                amplitude *= persistance;
            }

            if (scale <= 0) {
                scale = 0.0001f;
            }

            float halfWidth = mapWidth * xZoom / 2f;
            float halfHeight = mapHeight * yZoom / 2f;


            for (int y = 0; y < mapHeight * yZoom; y += yZoom) {
                for (int x = 0; x < mapWidth * xZoom; x += xZoom) {

                    amplitude = 1;
                    frequency = 1;
                    float noiseHeight = 0;

                    for (int i = 0; i < octaves; i++) {
                        float sampleX = (x - halfWidth + offsetX[i]) / scale * frequency;
                        float sampleY = (y - halfHeight + offsetY[i]) / scale * frequency;
                        float perlinValue = PerlinNoise(sampleX, sampleY) * 2 - 1;
                        noiseHeight += perlinValue * amplitude;

                        amplitude *= persistance;
                        frequency *= lacunarity;
                    }

                    noiseMap[x / (xZoom), y / (yZoom)] = noiseHeight;
                }
            }

            for (int y = 0; y < mapHeight; y++) {
                for (int x = 0; x < mapWidth; x++) {
                    float normalizedHeight = (noiseMap[x, y] + 1) / (maxPossibleHeight / 0.9f);
                    normalizedHeight *= -12;
                    normalizedHeight = normalizedHeight - normalizedHeight % 1;
                    //noiseMap[x, y] = normalizedHeight;
                    noiseMap[x, y] = Clamp(normalizedHeight, 0, 12);
                }
            }
            return noiseMap;
        }

        /// <summary>
        /// Constrains a float between a min and max
        /// </summary>
        /// <param name="toClamp"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static float Clamp(float toClamp, float min, float max) {
            float clamped = toClamp;
            if (clamped < min) clamped = min;
            if (clamped > max) clamped = max;
            return clamped;
        }
        /// I stole everything below this and made the scary red lines go away
        public static float PerlinNoise(float x, float y) {
            var X = (int)Math.Floor(x) & 0xff;
            var Y = (int)Math.Floor(y) & 0xff;
            x -= (float)Math.Floor(x);
            y -= (float)Math.Floor(y);
            float u = Fade(x);
            float v = Fade(y);
            var A = (perm[X] + Y) & 0xff;
            var B = (perm[X + 1] + Y) & 0xff;
            return Lerp(v, Lerp(u, Grad(perm[A], x, y), Grad(perm[B], x - 1, y)),
                           Lerp(u, Grad(perm[A + 1], x, y - 1), Grad(perm[B + 1], x - 1, y - 1)));
        }

        static float Fade(float t) {
            return t * t * t * (t * (t * 6 - 15) + 10);
        }

        static float Lerp(float t, float a, float b) {
            return a + t * (b - a);
        }

        static float Grad(int hash, float x, float y) {
            return ((hash & 1) == 0 ? x : -x) + ((hash & 2) == 0 ? y : -y);
        }

        static int[] perm = {
        151,160,137,91,90,15,
        131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,
        190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
        88,237,149,56,87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
        77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,
        102,143,54, 65,25,63,161, 1,216,80,73,209,76,132,187,208, 89,18,169,200,196,
        135,130,116,188,159,86,164,100,109,198,173,186, 3,64,52,217,226,250,124,123,
        5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,
        223,183,170,213,119,248,152, 2,44,154,163, 70,221,153,101,155,167, 43,172,9,
        129,22,39,253, 19,98,108,110,79,113,224,232,178,185, 112,104,218,246,97,228,
        251,34,242,193,238,210,144,12,191,179,162,241, 81,51,145,235,249,14,239,107,
        49,192,214, 31,181,199,106,157,184, 84,204,176,115,121,50,45,127, 4,150,254,
        138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180,
        151
    };

    }
}
