using System;
using System.Collections.Generic;

namespace CrowdSimulator
{
    public class Field
    {
        private const int XFields = 6;
        
        private const int YFields = 6;

        private List<Human>[,] humans;

        private readonly int xTile;

        private readonly int yTile;

        public Field(int Width, int Height)
        {
            this.xTile = Width / XFields;
            this.yTile = Height / YFields;

            this.CreateArray();
        }

        public void Update(IEnumerable<Human> Humans)
        {
            this.CreateArray();

            foreach (var h in Humans)
            {
                var x = Math.Min(2, Math.Max(0, (int)Math.Floor(h.Position.X / this.xTile)));
                var y = Math.Min(2, Math.Max(0, (int)Math.Floor(h.Position.Y / this.yTile)));

                this.humans[x, y].Add(h);

                h.FieldIndex = new Vec2(x, y);
            }
        }

        public List<Human> GetNearestNeighbour(Vec2 FieldIndex, Vec2 Position)
        {
            int[,] leftUp = {{0, -1}, {-1, -1}, {-1, 0}};
            int[,] leftDown = {{-1, 0}, {-1, 1}, {0, 1}};
            int[,] rightUp = {{0, -1}, {1, -1}, {1, 0}};
            int[,] rightDown = {{1, 0}, {1, 1}, {0, 1}};

            var leftRight = 0;
            var upDown = 0;

            var neighbour = new List<Human>();

            if((Position.Xi % this.xTile) > (this.xTile / 2))
            {
                leftRight = 1;
            }

            if ((Position.Yi % this.yTile) > (this.yTile / 2))
            {
                upDown = 1;
            }

            switch (leftRight)
            {
                case 0:
                {
                    switch (upDown)
                    {
                        case 0:
                        {
                            neighbour.AddRange(this.GetFields(FieldIndex, leftUp));
                        } break;

                        case 1:
                        {
                            neighbour.AddRange(this.GetFields(FieldIndex, leftDown));
                        } break;
                    }
                }break;

                case 1:
                {
                    switch (upDown)
                    {
                        case 0:
                        {
                            neighbour.AddRange(this.GetFields(FieldIndex, rightUp));
                        } break;

                        case 1:
                        {
                            neighbour.AddRange(this.GetFields(FieldIndex, rightDown));
                        } break;
                    }
                }break;
            }

            neighbour.AddRange(this.humans[FieldIndex.Xi, FieldIndex.Yi]);

            return neighbour;
        }

        private IEnumerable<Human> GetFields(Vec2 Field, int[,] Offsets)
        {
            var neightbour = new List<Human>();

            for (int i = 0; i < (Offsets.GetLength(0) - 1); i++)
            {
                int x = Field.Xi + Offsets[i, 0];
                int y = Field.Yi + Offsets[i, 1];

                if (!(x >= 0 && x < XFields))
                {
                    continue;
                }

                if (!(y >= 0 && y < YFields))
                {
                    continue;
                }

                neightbour.AddRange(this.humans[x, y]);
            }

            return neightbour;
        }

        private void CreateArray()
        {
            this.humans = new List<Human>[XFields, YFields];

            for (var x = 0; x < XFields; x++)
            {
                for (var y = 0; y < YFields; y++)
                {
                    this.humans[x, y] = new List<Human>();
                }
            }
        }
    }
}
