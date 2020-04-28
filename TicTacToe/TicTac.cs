using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class TicTac
    {

        #region privateMembers
        /// <summary>
        /// maxsize of tilevales array <see cref="tileValues"/>
        /// </summary>
        public int maxSize { get; private set; } = 9;
        #endregion

        #region publicVariables

        public int maxRowSize { get; private set; } = 3;
        public int maxcolSize { get; private set; } = 3;

        public bool PlayerState { get; set; } = true;

        public bool GameState { get; set; } = true;

        /// <summary>
        /// state of gridBox
        /// </summary>
        public enum BoxState
        {
            /// empty game tile
            free,
            /// game tile with X
            cross,
            /// game tile with O
            zero
        }

        public BoxState[] tileValues;

        public TicTac() => this.tileValues = new BoxState[9];

        public void defaultTileInit()
        {

            for (int i = 0; i < maxSize; ++i)
            {
                tileValues[i] = BoxState.free;
            }
        }

        public int computerPlay()
        {

            int index = 0;

            while (true)
            {
                Random random = new Random();
                index = random.Next(0, 8);

                if (tileValues[index] == BoxState.free)
                    break;
            }

            return index;
        }

        public void checkGameState()
        {
            foreach (var tile in this.tileValues)
            {
                if (tile == TicTac.BoxState.free)
                {
                    this.GameState = true;
                    break;
                }
                else
                {
                    this.GameState = false;
                }

            }
        }


        public void getWinner()
        {
            var temp = this.maxRowSize;
            var temp2 = 0;
            bool foundPattern = false;
            for (var j = 0; j < this.maxRowSize; ++j)
            {
                for (var i = temp2; i < temp; ++i)
                {
                    if (tileValues[i] != BoxState.cross)
                    {
                        this.GameState = true;
                        break;
                    }

                    else if (tileValues[i] == BoxState.cross)
                    {
                        this.GameState = false;
                        foundPattern = true;
                    }
                }

                if (foundPattern)
                    break;

                temp += this.maxRowSize;
                temp2 += 2 + 1;
            }


        }
        #endregion

    }

}
