using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GameMenu
{
    public class Game
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }

    public partial class GameListWindow : Window
    {
        private SpaceShooterGame spaceShooterWindow;
        private Snake snakeWindow;
        private Tetris tetrisWindow;
        private FlappyBird flappyBirdWindow;
        private ChessUI.MainWindow chessWindow;
        private Memory.MainWindow memoryWindow;

        public GameListWindow(List<Game> games)
        {
            InitializeComponent();
            gameList.ItemsSource = games; // Set the ItemsSource to the list of games passed in
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            Button playButton = sender as Button;
            string selectedGame = playButton.Tag as string;

            if (!string.IsNullOrEmpty(selectedGame))
            {
                StartGame(selectedGame);
                this.Close(); // Close the window after selecting a game
            }
        }

        private void StartGame(string gameName)
        {
            switch (gameName)
            {
                case "Space Shooter":
                    OpenSingleWindow(ref spaceShooterWindow, CreateSpaceShooterWindow);
                    break;
                case "Snake":
                    OpenSingleWindow(ref snakeWindow, CreateSnakeWindow);
                    break;
                case "Tetris":
                    OpenSingleWindow(ref tetrisWindow, CreateTetrisWindow);
                    break;
                case "FlappyBird":
                    OpenSingleWindow(ref flappyBirdWindow, CreateFlappyBirdWindow);
                    break;
                case "Chess":
                    OpenSingleWindow(ref chessWindow, CreateChessWindow);
                    break;
                case "Memory":
                    OpenSingleWindow(ref memoryWindow, CreateMemoryWindow);
                    break;
                default:
                    MessageBox.Show("Game not found!");
                    break;
            }
        }

        private void OpenSingleWindow<T>(ref T gameWindow, System.Func<T> createWindow) where T : Window
        {
            if (gameWindow == null || !gameWindow.IsVisible)
            {
                gameWindow = createWindow();
                gameWindow.Closed += GameWindow_Closed;
                gameWindow.Show();
            }
            else
            {
                gameWindow.Activate(); // Bring the existing window to the front
            }
        }

        private void GameWindow_Closed(object sender, System.EventArgs e)
        {
            // Reset the reference to null when the window is closed
            if (sender is SpaceShooterGame) spaceShooterWindow = null;
            else if (sender is Snake) snakeWindow = null;
            else if (sender is Tetris) tetrisWindow = null;
            else if (sender is FlappyBird) flappyBirdWindow = null;
            else if (sender is ChessUI.MainWindow) chessWindow = null;
            else if (sender is Memory.MainWindow) memoryWindow = null;
        }

        private SpaceShooterGame CreateSpaceShooterWindow() => new SpaceShooterGame();
        private Snake CreateSnakeWindow() => new Snake();
        private Tetris CreateTetrisWindow() => new Tetris();
        private FlappyBird CreateFlappyBirdWindow() => new FlappyBird();
        private ChessUI.MainWindow CreateChessWindow() => new ChessUI.MainWindow();
        private Memory.MainWindow CreateMemoryWindow() => new Memory.MainWindow();
    }
}
