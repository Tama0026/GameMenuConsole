using System.Collections.Generic;
using System.Windows;

namespace GameMenu
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void one_player_btn_Click(object sender, RoutedEventArgs e)
        {
            // Define single-player games with their images
            var singlePlayerGames = new List<Game>
            {
                new Game { Name = "Space Shooter", ImagePath = "Logo_Game/space_shooter.jpg" },
                new Game { Name = "FlappyBird", ImagePath = "Logo_Game/flappybird.jpg" },
                new Game { Name = "Snake", ImagePath = "Logo_Game/snake.png" },
            };

            // Pass the list of games to the GameListWindow
            GameListWindow gameListWindow = new GameListWindow(singlePlayerGames);
            gameListWindow.Show();
        }

        private void two_player_btn_Click(object sender, RoutedEventArgs e)
        {
            // Define multi-player games with their images
            var multiPlayerGames = new List<Game>
            {
                new Game { Name = "Chess", ImagePath = "Logo_Game/chess.jpg" },
                new Game { Name = "Tetris", ImagePath = "Logo_Game/tetris.jpg" },
                new Game { Name = "Memory", ImagePath = "Logo_Game/memory.png" }

            };

            // Pass the list of games to the GameListWindow
            GameListWindow gameListWindow = new GameListWindow(multiPlayerGames);
            gameListWindow.Show();
        }

        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to exit?", "Confirm exit", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
