using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace HW_NP_7._0
{
    public partial class Form1 : Form
    {
        private RandomOrgApi randomOrgApi;
        private bool isPlayerOneTurn = true;
        private int player1Score = 0;
        private int player2Score = 0;
        private GameMode gameMode;

        public Form1()
        {
            InitializeComponent();
            randomOrgApi = new RandomOrgApi();
            gameMode = GameMode.HumanVsHuman;
            UpdateTurnIndicator();
        }

        private async void btnRoll_Click(object sender, EventArgs e)
        {
            btnRoll.Enabled = false;

            await AnimateDiceRoll();

            int diceValue = await randomOrgApi.RollDice();
            UpdateDiceImage(diceValue);

            UpdateScore(diceValue);

            if (gameMode == GameMode.HumanVsHuman)
            {
                isPlayerOneTurn = !isPlayerOneTurn;
                UpdateTurnIndicator();
            }
            else if (gameMode == GameMode.HumanVsComputer)
            {
                await Task.Delay(500); // Пауза перед ходом компьютера
                await ComputerTurn();
            }

            btnRoll.Enabled = true;
        }

        private async Task ComputerTurn()
        {
            lblPlayerTurn.Text = "Ход компьютера";

            await AnimateDiceRoll();

            int diceValue = await randomOrgApi.RollDice();
            UpdateDiceImage(diceValue);

            player2Score += diceValue;
            lblPlayer2Score.Text = $"Счет компьютера: {player2Score}";

            lblPlayerTurn.Text = "Ваш ход";
        }

        private void UpdateScore(int diceValue)
        {
            if (isPlayerOneTurn)
            {
                player1Score += diceValue;
                lblPlayer1Score.Text = $"Счет игрока 1: {player1Score}";
            }
            else
            {
                player2Score += diceValue;
                if (gameMode == GameMode.HumanVsHuman)
                {
                    lblPlayer2Score.Text = $"Счет игрока 2: {player2Score}";
                }
                else
                {
                    lblPlayer2Score.Text = $"Счет компьютера: {player2Score}";
                }
            }
        }

        private void UpdateTurnIndicator()
        {
            if (gameMode == GameMode.HumanVsHuman)
            {
                lblPlayerTurn.Text = isPlayerOneTurn ? "Ходит игрок 1" : "Ходит игрок 2";
            }
            else if (gameMode == GameMode.HumanVsComputer)
            {
                lblPlayerTurn.Text = "Ваш ход";
            }
        }

        private void UpdateDiceImage(int diceValue)
        {
            switch (diceValue)
            {
                case 1:
                    pbDice.Image = Properties.Resources.dice_1;
                    break;
                case 2:
                    pbDice.Image = Properties.Resources.dice_2;
                    break;
                case 3:
                    pbDice.Image = Properties.Resources.dice_3;
                    break;
                case 4:
                    pbDice.Image = Properties.Resources.dice_4;
                    break;
                case 5:
                    pbDice.Image = Properties.Resources.dice_5;
                    break;
                case 6:
                    pbDice.Image = Properties.Resources.dice_6;
                    break;
                default:
                    pbDice.Image = null;
                    break;
            }
        }

        private async Task AnimateDiceRoll()
        {
            int animationSteps = 10;
            int delay = 50;

            Random rnd = new Random();
            for (int i = 0; i < animationSteps; i++)
            {
                int randomValue = rnd.Next(1, 7);
                UpdateDiceImage(randomValue);
                await Task.Delay(delay);
            }
        }

        private void rbHumanVsHuman_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHumanVsHuman.Checked)
            {
                gameMode = GameMode.HumanVsHuman;
                ResetGame();
            }
        }

        private void rbHumanVsComputer_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHumanVsComputer.Checked)
            {
                gameMode = GameMode.HumanVsComputer;
                ResetGame();
            }
        }

        private void ResetGame()
        {
            isPlayerOneTurn = true;
            player1Score = 0;
            player2Score = 0;
            lblPlayer1Score.Text = "Счет игрока 1: 0";
            lblPlayer2Score.Text = gameMode == GameMode.HumanVsHuman ? "Счет игрока 2: 0" : "Счет компьютера: 0";
            UpdateTurnIndicator();
            pbDice.Image = null;
        }
    }

    public enum GameMode
    {
        HumanVsHuman,
        HumanVsComputer
    }

    public class RandomOrgApi
    {
        private readonly string apiKey = "db46b969-8397-4358-8f22-24245f2b011e";
        private readonly string apiUrl = "https://api.random.org/json-rpc/4/invoke";

        public async Task<int> RollDice()
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new
                {
                    jsonrpc = "2.0",
                    method = "generateIntegers",
                    @params = new
                    {
                        apiKey = apiKey,
                        n = 1,
                        min = 1,
                        max = 6,
                        replacement = true
                    },
                    id = 1
                };

                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(apiUrl, content);
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var resultObject = JsonConvert.DeserializeObject<RandomOrgResponse>(jsonResponse);

                return resultObject.result.random.data[0];
            }
        }
    }

    public class RandomOrgResponse
    {
        public string jsonrpc { get; set; }
        public RandomOrgResult result { get; set; }
        public int id { get; set; }
    }

    public class RandomOrgResult
    {
        public RandomData random { get; set; }
        public int bitsUsed { get; set; }
        public int bitsLeft { get; set; }
        public int requestsLeft { get; set; }
        public int advisoryDelay { get; set; }
    }

    public class RandomData
    {
        public List<int> data { get; set; }
        public string completionTime { get; set; }
    }
}
