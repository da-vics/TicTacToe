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
        private int maxSize { get; set; } = 9;

        private bool foundPattern { get; set; }
        #endregion

        #region publicVariables

        public int maxRowSize { get; private set; } = 3;
        public int maxcolSize { get; private set; } = 3;

        public bool PlayerState { get; set; }

        public bool GameState { get; private set; }

        public int[] winSegments;

        public IdentifyWinner winner;

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

        public enum IdentifyWinner
        {
            NULL,
            player,
            computer,
            stalemate
        }

        public BoxState[] tileValues;

        public TicTac()
        {
            this.winSegments = new int[3] { 0, 0, 0 };
            this.tileValues = new BoxState[9];
            this.winner = new IdentifyWinner();
            this.foundPattern = false;
            this.PlayerState = true;
            this.GameState = true;
        }

        public void defaultTileInit()
        {
            for (int i = 0; i < maxSize; ++i)
            {
                tileValues[i] = BoxState.free;
            }

            winner = IdentifyWinner.NULL;
            this.foundPattern = false;
            this.PlayerState = true;
            this.GameState = true;
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
            if (this.winner == IdentifyWinner.NULL)
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

                if (this.GameState != true)
                {
                    winner = IdentifyWinner.stalemate;
                }

            }
        }


        public void getWinner(BoxState tempstate)
        {
            if (this.GameState != false)
            {
                getwin(tempstate);

                if (foundPattern)
                {
                    if (tempstate == BoxState.cross)
                        winner = IdentifyWinner.player;

                    else if (tempstate == BoxState.zero)
                        winner = IdentifyWinner.computer;
                }

                this.checkGameState();
            }

        }

        private void getwin(BoxState boxState)
        {
            var segindex = 0;
            var temp = this.maxRowSize;
            var temp2 = 0;
            for (var j = 0; j < this.maxRowSize; ++j)
            {
                for (var i = temp2; i < temp; ++i)
                {
                    if (tileValues[i] != boxState)
                    {
                        this.GameState = true;
                        foundPattern = false;
                        break;
                    }

                    else if (tileValues[i] == boxState)
                    {
                        this.winSegments[segindex++] = i;
                        this.GameState = false;
                        foundPattern = true;
                    }
                }

                if (foundPattern)
                    break;

                segindex = 0;
                temp += this.maxRowSize;
                temp2 += 2 + 1;
            }

            if (foundPattern) return; ///

            segindex = 0;
            temp = 6;
            temp2 = 0;
            var temp3 = temp2;

            for (var j = 0; j < this.maxcolSize; ++j)
            {
                for (var i = temp2; i <= temp; i += 3)
                {
                    if (tileValues[i] != boxState)
                    {
                        this.GameState = true;
                        foundPattern = false;
                        break;
                    }

                    else if (tileValues[i] == boxState)
                    {
                        this.winSegments[segindex++] = i;
                        this.GameState = false;
                        foundPattern = true;
                    }
                }

                if (foundPattern)
                    break;

                segindex = 0;
                temp += 1;
                temp3 += 1;
                temp2 = temp3;
            }
            if (foundPattern) return; ///


            segindex = 0;
            temp = 8;
            temp2 = 0;
            var incr = 4;

            for (var j = 0; j < this.maxcolSize - 1; ++j)
            {
                for (var i = temp2; i <= temp; i += incr)
                {
                    if (tileValues[i] != boxState)
                    {
                        this.GameState = true;
                        foundPattern = false;
                        break;
                    }

                    else if (tileValues[i] == boxState)
                    {
                        this.winSegments[segindex++] = i;
                        this.GameState = false;
                        foundPattern = true;
                    }
                }

                if (foundPattern)
                    break;

                segindex = 0;
                temp -= 2;
                temp2 += 2;
                incr -= 2;
            }

        }

        #endregion

    }

}
