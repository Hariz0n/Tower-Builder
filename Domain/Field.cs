using System;
using System.Collections.Generic;
using System.Drawing;

namespace TowerBuilder.Domain
{
    public class Field : IField
    {
        private readonly Box[,] _field = null;
        public int Size { get; }
        public int Level { get; private set; }
        public int PseudoX { get; private set; }
        public bool IsGameEnded = false;
        private Difficulty _difficulty;
        private bool Reversed { get; set; } = false;

        public event Action BlockMoved;

        public event Action LevelChanged;
        public event Action GameEnded; 

        public Field(int size, Difficulty difficulty)
        {
            Size = size;
            _difficulty = difficulty;
            _field = new Box[size, size];
            Level = size - 1;
            PseudoX = (size-1) / 2;
        }

        public void PlaceBox(int x = 0, int y = 0)
        {
            if(IsGameEnded)
                return;
            
            if (_field[PseudoX, Level] != null)
                throw new ArgumentException("На данном поле уже есть блок");
            _field[PseudoX, Level] = new Box();
            MoveBlockVertical(PseudoX, Level);
            PseudoX = (Size - 1) / 2;
            Reversed = false;
        }

        public void MovePseudoBlockHorizontal()
        {
            if(IsGameEnded)
                return;
            
            if (PseudoX == 0)
                Reversed = false;
            if (PseudoX == Size - 1)
                Reversed = true;
            if (Reversed)
                PseudoX -= 1;
            else
                PseudoX += 1;
            
            BlockMoved?.Invoke();
        }

        private void MoveBlockVertical(int x, int y)
        {
            if(IsGameEnded)
                return;
            
            int iY = y;
            while (iY < Size-1 && IsEmpty(x, iY+1))
            {
                _field[x, iY] = null;
                _field[x, iY + 1] = new Box();
                iY += 1;
                BlockMoved?.Invoke();
            }

            if (iY == 0)
            {
                IsGameEnded = true;
                GameEnded?.Invoke();
                IsGameEnded = true;
                return;
            }

            if (Level >= iY)
            {
                Level = iY-1;
                LevelChanged?.Invoke();
            }
        }

        public bool IsEmpty(int x, int y)
        {
            return _field[x, y] is null;
        }

        public List<Point> GetBlocks()
        {
            var res = new List<Point>();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if(_field[i,j] != null)
                        res.Add(new Point(i, j));
                }
            }
            res.Add(new Point(PseudoX, Level));
            return res;
        }
    }
}