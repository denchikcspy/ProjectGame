using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp5.Battle;
using WindowsFormsApp5.Entities;
using WindowsFormsApp5.Entities.Items;
using WindowsFormsApp5.Utils;

namespace WindowsFormsApp5.Forms
{
    public partial class BattleForm : Form
    {
        private Player player;
        private Enemy enemy;
        private PlayerInfo prevForm;

        private Random random = new Random();

        public BattleForm(Player player, PlayerInfo playerInfoForm)
        {
            InitializeComponent();

            this.player = player;
            this.prevForm = playerInfoForm;
            CreateEnemy();
            InitializeBattle();


        }

        //----------------------------------------------------
        // Звичайна атака
        //----------------------------------------------------

        private void btnAttack_Click(object sender, EventArgs e)
        {
            BattleActionResult result =
                player.UseNormalAttack(enemy);

            ExecutePlayerAction(result);
        }

        //----------------------------------------------------
        // Сильна атака
        //----------------------------------------------------

        private void btnStrongAttack_Click(object sender, EventArgs e)
        {
            BattleActionResult result =
                player.UseStrongAttack(enemy);

            ExecutePlayerAction(result);
        }

        //----------------------------------------------------
        // Ремонт
        //----------------------------------------------------

        private void btnRepair_Click(object sender, EventArgs e)
        {
            BattleActionResult result =
                player.Repair();

            ExecutePlayerAction(result);
        }

        //----------------------------------------------------
        // Відпочинок
        //----------------------------------------------------

        private void btnRest_Click(object sender, EventArgs e)
        {
            BattleActionResult result =
                player.Rest();

            ExecutePlayerAction(result);
        }

        //----------------------------------------------------
        // Створення ворога
        //----------------------------------------------------

        private void CreateEnemy()
        {
            int level = player.getLevel();

            enemy = new Enemy(
                "Panzer IV",
                level,

                new ProgressBarValueHelper(
                    350 + level * 50
                ),

                new ProgressBarValueHelper(
                    100
                ),

                18 + level * 2,      // Endurance
                12 + level,          // Agility
                15 + level,          // Intelligence

                new Weapon(
                    "75 мм KwK 40",
                    0,
                    75,
                    80 + level * 15,
                    110 + level * 5,
                    null
                ),

                new Armor(
                    "Лобова броня",
                    0,
                    80 + level * 5,
                    null
                ),
                new BattleSprites()
                {
                    Idle = Properties.Resources.EnemyIdle,
                    NormalAttack = Properties.Resources.EnemyNormalAttack,
                    StrongAttack = Properties.Resources.EnemyStrongAttack,
                    Repair = Properties.Resources.EnemyRepair,
                    Damaged = Properties.Resources.EnemyDamaged,
                    Destroyed = Properties.Resources.EnemyDestroyed
                }
            );
        }

        //----------------------------------------------------
        // Початок бою
        //----------------------------------------------------

        private void InitializeBattle()
        {
            lblPlayerName.Text = player.getName();

            lblEnemyName.Text = enemy.getName();

            lblEnemyLevel.Text =
                "Рівень: " + enemy.getLevel();

            UpdateUI();

            pictureBoxPlayer.SizeMode =
                PictureBoxSizeMode.Zoom;

            pictureBoxEnemy.SizeMode =
                PictureBoxSizeMode.Zoom;

            UpdatePlayerImage(BattleImageState.None);

            UpdateEnemyImage(BattleImageState.None);

            AddLog("======= ПОЧАТОК БОЮ =========");
            AddLog(player.getName() + " зустрів " + enemy.getName());
        }

        //----------------------------------------------------
        // Оновлення всього інтерфейсу
        //----------------------------------------------------

        private void UpdateUI()
        {
            //--------------------------------

            progressBarPlayerHP.Maximum =
                player.getMaxHP();

            progressBarPlayerHP.Value =
                player.getCurrentHP();

            lblPlayerHP.Text =
                player.getCurrentHP()
                + " / "
                + player.getMaxHP();

            //--------------------------------

            progressBarPlayerMP.Maximum =
                player.getMaxMP();

            progressBarPlayerMP.Value =
                player.getCurrentMP();

            lblPlayerMP.Text =
                player.getCurrentMP()
                + " / "
                + player.getMaxMP();

            //--------------------------------

            progressBarEnemyHP.Maximum =
                enemy.getMaxHP();

            progressBarEnemyHP.Value =
                enemy.getCurrentHP();

            lblEnemyHP.Text =
                enemy.getCurrentHP()
                + " / "
                + enemy.getMaxHP();

            //--------------------------------

            if (player.getMainGunCooldown() == 0)
            {
                labelCooldown.Text =
                    "Основна гармата готова";
            }
            else
            {
                labelCooldown.Text =
                    "Перезарядка: "
                    + player.getMainGunCooldown()
                    + " ход.";
            }

            //--------------------------------

            btnAttack.Enabled =
                player.CanUseNormalAttack();

            btnStrongAttack.Enabled =
                player.CanUseStrongAttack();

            btnRepair.Enabled =
                player.CanRepair();

            btnRest.Enabled = true;
        }

        //----------------------------------------------------
        // Картинка гравця
        //----------------------------------------------------

        private void UpdatePlayerImage(
            BattleImageState state)
        {
            switch (state)
            {
                case BattleImageState.None:
                    pictureBoxPlayer.Image =
                        player.getSprites().Idle;
                    break;

                case BattleImageState.NormalAttack:
                    pictureBoxPlayer.Image =
                        player.getSprites().NormalAttack;
                    break;

                case BattleImageState.StrongAttack:
                    pictureBoxPlayer.Image =
                        player.getSprites().StrongAttack;
                    break;

                case BattleImageState.Repair:
                    pictureBoxPlayer.Image =
                        player.getSprites().Repair;
                    break;

                case BattleImageState.Damaged:
                    pictureBoxPlayer.Image =
                        player.getSprites().Damaged;
                    break;

                case BattleImageState.Destroyed:
                    pictureBoxPlayer.Image =
                        player.getSprites().Destroyed;
                    break;
            }
        }

        //----------------------------------------------------
        // Картинка ворога
        //----------------------------------------------------

        private void UpdateEnemyImage(
            BattleImageState state)
        {
            switch (state)
            {
                case BattleImageState.None:
                    pictureBoxEnemy.Image =
                        enemy.getSprites().Idle;
                    break;

                case BattleImageState.NormalAttack:
                    pictureBoxEnemy.Image =
                        enemy.getSprites().NormalAttack;
                    break;

                case BattleImageState.StrongAttack:
                    pictureBoxEnemy.Image =
                        enemy.getSprites().StrongAttack;
                    break;

                case BattleImageState.Repair:
                    pictureBoxEnemy.Image =
                        enemy.getSprites().Repair;
                    break;

                case BattleImageState.Damaged:
                    pictureBoxEnemy.Image =
                        enemy.getSprites().Damaged;
                    break;

                case BattleImageState.Destroyed:
                    pictureBoxEnemy.Image =
                        enemy.getSprites().Destroyed;
                    break;
            }
        }
        //----------------------------------------------------
        // Додавання запису у журнал
        //----------------------------------------------------

        private void AddLog(string text)
        {
            richTextBoxBattleLog.AppendText(text + Environment.NewLine);
            richTextBoxBattleLog.ScrollToCaret();
        }

        //----------------------------------------------------
        // Хід ворога
        //----------------------------------------------------

        private void EnemyTurn()
        {
            if (enemy.IsDead())
                return;

            enemy.StartTurn();

            BattleActionResult result =
                enemy.DecideAction(player);

            UpdateEnemyImage(result.ImageState);

            AddLog(result.LogText);

            if (result.IsCritical)
            {
                AddLog($"Критичне влучання!\n\tНанесено {result.DamageDone} шкоди.\n");
            }
                

            if (result.WasBlockedByArmor)
            {
                AddLog("Броня частково поглинула шкоду.");
            }
                

            if (result.WasDodged)
            {
                AddLog("Гравець частково ухилився.");
            }
                

            if (result.TargetDestroyed)
            {
                AddLog("Ваш танк знищено!");

                UpdatePlayerImage(
                    BattleImageState.Destroyed);

                UpdateUI();

                CheckBattleEnd();

                return;
            }

            

            UpdateUI();
        }

        //----------------------------------------------------
        // Завершення ходу
        //----------------------------------------------------

        private void EndTurn()
        {
            player.StartTurn();

            EnemyTurn();

            UpdateUI();

            CheckBattleEnd();
        }

        //----------------------------------------------------
        // Перевірка завершення бою
        //----------------------------------------------------

        private void CheckBattleEnd()
        {
            //==========================
            // Перемога
            //==========================
            if (enemy.IsDead())
            {
                UpdateEnemyImage(BattleImageState.Destroyed);

                AddLog("");
                AddLog("====== ПЕРЕМОГА ======");
                AddLog("Ворог знищений.");

                
                

                AddLog("Отримано " + enemy.getRewardGold() + " золота.");
                AddLog("Отримано " + enemy.getRewardXP() + " досвіду.");
                
                MessageBox.Show($"Ворога знищено, ви отримали {enemy.getRewardGold()} грошей та {enemy.getRewardXP()} досвіду", "Ви виграли!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                player.addMoney(enemy.getRewardGold());
                player.addExperience(enemy.getRewardXP());


                DisableButtons();
                    this.prevForm.Visible = true;
                    player.FullRepair();
                    this.prevForm.RefreshUI();
                    
                    

                    this.Close();

                    return;
                

                
            }

            //==========================
            // Поразка
            //==========================
            if (player.IsDead())
            {
                UpdatePlayerImage(BattleImageState.Destroyed);

                AddLog("");
                AddLog("====== ПОРАЗКА ======");
                AddLog("Ваш танк було знищено.");

                

                MessageBox.Show(
                    "Поразка!",
                    "Бій завершено",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DisableButtons();
                this.prevForm.Visible = true;

                this.prevForm.RefreshUI();
                player.FullRepair();
                
                this.Close();

                return;
            }
        }

        //----------------------------------------------------
        // Вимкнення кнопок
        //----------------------------------------------------

        private void DisableButtons()
        {
            btnAttack.Enabled = false;
            btnStrongAttack.Enabled = false;
            btnRepair.Enabled = false;
            btnRest.Enabled = false;
        }

        //----------------------------------------------------
        // Дія гравця
        //----------------------------------------------------

        private void ExecutePlayerAction(BattleActionResult result)
        {
            // Картинка гравця (той, хто атакує)
            UpdatePlayerImage(result.ImageState);

            AddLog(result.LogText);

            if (result.IsCritical)
                AddLog($"Критичне влучання! Нанесено {result.DamageDone} шкоди.");

            if (result.WasBlockedByArmor)
                AddLog($"Броня ворога поглинула частину шкоди. Нанесено {result.DamageDone} шкоди.");

            if (result.WasDodged)
                AddLog($"Ворог частково ухилився. Нанесено {result.DamageDone} шкоди.");

            // Показуємо правильну картинку ворога
            if (result.TargetDestroyed)
            {
                UpdateEnemyImage(BattleImageState.Destroyed);
            }
            else
            {
                UpdateEnemyImage(BattleImageState.Damaged);
            }

            UpdateUI();

            // Якщо ворог загинув — завершуємо бій і НЕ виконуємо хід ворога
            if (enemy.IsDead())
            {
                CheckBattleEnd();
                return;
            }

            // Інакше ворог ходить
            EndTurn();
        }
        
    }
}