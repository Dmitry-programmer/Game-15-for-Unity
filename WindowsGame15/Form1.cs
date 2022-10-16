using Board15;



namespace WindowsGame15
{
    public partial class FormGame15 : Form
    {
        const int size = 4;
        Game game;

        public FormGame15()
        {
            InitializeComponent();
            game = new Game(size);
            HideButtons();
        }

        private void b00_Click(object sender, EventArgs e)
        {
            if (game.Solved())
                return;
            Button button = (Button)sender;
            int x = int.Parse(button.Name.Substring(1,1));
            int y = int.Parse(button.Name.Substring(2,1));
            game.PressAt(x, y);
            ShowButtons();
            if (game.Solved())
                labelMoves.Text = $"Game Finished in {game.Moves} moves";

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            game.Start(1000 + DateTime.Now.DayOfYear);
            ShowButtons();

        }

        void HideButtons()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    ShowDigitAt(0, x, y);
            labelMoves.Text = "Moves: 0";
        }

        void ShowButtons()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    ShowDigitAt(game.GetDigitAt(x,y), x, y);
            labelMoves.Text = "Moves: " + game.Moves;
        }

        void ShowDigitAt(int digit, int x, int y)
        {
            Button button = (Button)Controls["b" + x + y];
            button.Text = DecToHex (digit);
            button.Visible = digit > 0;
        }

        string DecToHex(int digit)
        {
            if (digit == 0)
                return "";
            if (digit < 10)
                return digit.ToString();
            return ((char)('A' + digit - 10)).ToString();
        }
    }
}