using System;
using System.Drawing;
using System.Threading;

namespace TowerBuilder.Domain
{
    public class Field : IField
    {
        public Box[,] field = null;
        public int Size { get; set; }
        public int Level { get; set; }
        public int PseudoX { get; set; }
        public bool IsGameEnded = false;
        public int HardDelay { get; set; }
        public int StartMoveDelay { get; set; } = 650;
        public int BlocksCount { get; set; }
        public bool Reversed { get; set; } = false;

        public event Action BlockMoved;
        public event Action<Field> GameEnded; 

        public Field(int size)
        {
            Size = size;
            field = new Box[size, size];
            Level = size - 1;
            PseudoX = (size-1) / 2;
        }

        public void PlaceBox(int x, int y)
        {
            if (field[x, y] != null)
                throw new ArgumentException("На данном поле уже есть блок");
            field[x, y] = new Box();
            MoveBlockVertical(x, y);
        }

        public void MovePseudoBlockHorizontal()
        {
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

        public void MoveBlockVertical(int x, int y)
        {
            int iY = y;
            while (iY < Size-1 && IsEmpty(x, iY+1))
            {
                field[x, iY] = null;
                field[x, iY + 1] = new Box();
                iY += 1;
                BlockMoved?.Invoke();
                Thread.Sleep(250);
            }

            if (iY == 0)
            {
                IsGameEnded = true;
                GameEnded?.Invoke(this);
            }
                
                

            if (Level >= iY)
                Level = iY-1;
        }

        public bool IsEmpty(int x, int y)
        {
            return field[x, y] is null;
        }
    }
}