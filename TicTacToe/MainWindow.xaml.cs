using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region privateMembers

        /// <summary>
        /// instance of <see cref="TicTac"/>
        /// </summary>
        private TicTac ticTac;
        /// <summary>
        /// initialise new game
        /// </summary> 

        private void newGame()
        {
            ticTac.defaultTileInit();

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {

                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });
        }

        /// <summary>
        /// button click Event Handler....
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var gridIndex = column + (row * 3);

            if (ticTac.PlayerState && ticTac.GameState)
            {
                if (ticTac.tileValues[gridIndex] != TicTac.BoxState.free)
                {
                    MessageBox.Show("Already Filled!");
                    /// return;
                }

                else
                {
                    ticTac.tileValues[gridIndex] = TicTac.BoxState.cross;
                    button.Content = 'X';
                    ticTac.PlayerState = false;
                }
                ticTac.checkGameState();
            }


            if (!ticTac.PlayerState && ticTac.GameState)
            {

                var btn = Container.Children.Cast<Button>().ToArray();
                var index = ticTac.computerPlay();
                btn[index].Content = "O";
                btn[index].Foreground = Brushes.Red;
                ticTac.tileValues[index] = TicTac.BoxState.zero;
                ticTac.PlayerState = true;
            }

            ticTac.getWinner();

            if (!ticTac.GameState)
            {
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Gold;
                    button.Foreground = Brushes.Black;

                });
            }
        }

        #endregion

        #region publicMembers

        public MainWindow()
        {
            InitializeComponent();
            ticTac = new TicTac();

            newGame();
        }

        #endregion

    }
}
