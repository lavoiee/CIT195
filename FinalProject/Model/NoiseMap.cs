using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject {
    class NoiseMap {
        #region ENUMERABLES
        #endregion

        #region FIELDS

        private int _mapWidth;
        private int _mapHeight;
        private int _seed;
        private int _xZoom;
        private int _yZoom;
        private float _scale;
        private int _octaves;
        private float _persistance;
        private float _lacunarity;
        private int _offsetX;
        private int _offsetY;

        private float[,] _map;

        #endregion

        #region PROPERTIES

        public int MapWidth {
            get { return _mapWidth; }
            set { _mapWidth = value; }
        }

        public int MapHeight {
            get { return _mapHeight; }
            set { _mapHeight = value; }
        }

        public int Seed {
            get { return _seed; }
            set { _seed = value; }
        }

        public int Xzoom {
            get { return _xZoom; }
            set { _xZoom = value; }
        }

        public int Yzoom {
            get { return _yZoom; }
            set { _yZoom = value; }
        }

        public float Scale {
            get { return _scale; }
            set { _scale = value; }
        }

        public int Octaves {
            get { return _octaves; }
            set { _octaves = value; }
        }

        public float Persistance {
            get { return _persistance; }
            set { _persistance = value; }
        }

        public float Lacunarity {
            get { return _lacunarity; }
            set { _lacunarity = value; }
        }

        public int OffsetX {
            get { return _offsetX; }
            set { _offsetX = value; Update(); }
        }

        public int OffsetY {
            get { return _offsetY; }
            set { _offsetY = value; Update(); }
        }

        public float[,] Map {
            get { return _map; }
            set { _map = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public NoiseMap(int mapWidth, int mapHeight, int seed, int xZoom, int yZoom, float scale, int octaves, float persistance, float lacunarity, int offsetX, int offsetY) {
            _mapWidth = mapWidth;
            _mapHeight = mapHeight;
            _seed = seed;
            _xZoom = xZoom;
            _yZoom = yZoom;
            _scale = scale;
            _octaves = octaves;
            _persistance = persistance;
            _lacunarity = lacunarity;
            _offsetX = offsetX;
            _offsetY = offsetY;

            _map = new float[_mapWidth, _mapHeight];

            Update();
        }

        #endregion

        #region METHODS

        public void Update() {
            _map = Noise.GenerateNoiseMap(_mapWidth, _mapHeight, _seed, _xZoom, _yZoom, _scale, _octaves, _persistance, _lacunarity, _offsetX, _offsetY);
        }
        #endregion

    }
}
