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
                    StartSpaceShooter();
                    break;
                case "Snake":
                    StartSnake();
                    break;
                case "Tetris":
                    StartTetris();
                    break;
                case "FlappyBird":
                    StartFlappyBird();
                    break;
                case "Memory":
                    StartMemory();
                    break;
                case "Chess":
                    StartChess();
                    break;
                default:
                    MessageBox.Show("Game not found!");
                    break;
            }
        }

        private void StartSpaceShooter()
        {
            SpaceShooterGame game1 = new SpaceShooterGame();
            game1.Show();
        }

        private void StartSnake()
        {
            Snake snake = new Snake();
            snake.Show();
        }

        private void StartTetris()
        {
            Tetris game1 = new Tetris();
            game1.Show();
        }
        private void StartFlappyBird()
        {
            FlappyBird game1 = new FlappyBird();
            game1.Show();
        }
        private void StartChess()
        {
            ChessUI.MainWindow game1 = new ChessUI.MainWindow();
            game1.Show();
        }
        private void StartMemory()
        {
            Memory.MainWindow game1 = new Memory.MainWindow();
            game1.Show();
        }
    }
}
