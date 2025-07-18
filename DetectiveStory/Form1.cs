using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DetectiveStory
{
    public partial class detectivegame_Form : Form
    {
        private GameManager gameManager = new GameManager();
        public string name;
        private String gender;
        private Panel previousPanel;
        private List<Evidence> evidenceItems = new List<Evidence>();
        private Puzzle currentPuzzle;
        private string currentRoom;
        public detectivegame_Form()
        {
            InitializeComponent();
            ShowPanel(StartPanel);
            InitializeEvidence();
        }

        private Panel GetCurrentlyVisiblePanel()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Panel panel && panel.Visible)
                {
                    return panel;
                }
            }
            return null;
        }

        private void InitializeEvidence()
        {
            evidenceItems.Add(new Evidence("Vase", vasePic, vaseInventoryPic));
            evidenceItems.Add(new Evidence("Bloody Glove", bloodyglovePic, bloodygloveInventoryPic));
            evidenceItems.Add(new Evidence("Shoe Print", shoeprintPic, shoeprintInventoryPic));
            evidenceItems.Add(new Evidence("ID Card", idcardPic, idcardInventoryPic));
            evidenceItems.Add(new Evidence("Car Keys", carkeysPic, carkeysInventoryPic));
            evidenceItems.Add(new Evidence("Hair Brush",hairbrushPic,hairbrushInventoryPic));
            evidenceItems.Add(new Evidence("Torn Will2", will2Pic, will2InventoryPic));
            evidenceItems.Add(new Evidence("Broken Family Frame", brokenFamilyPic, brokenfamilyInventoryPic));
            evidenceItems.Add(new Evidence("Money", moneyPic,moneyInventoryPic));
            evidenceItems.Add(new Evidence("Lipstick Print on Scarf", scarfPic, scarfInventoryPic));
            evidenceItems.Add(new Evidence("Code", codePic, codeInventoryPic));
            evidenceItems.Add(new Evidence("Half Apple Rotten", rottenapplePic, rottenappleInventoryPic));
            evidenceItems.Add(new Evidence("Wine Glass Broke",wineglassPic,wineglassInventoryPic));
            evidenceItems.Add(new Evidence("Burnt Appron", appronburntPic, apronburntInventoryPic));
            evidenceItems.Add(new Evidence("Knife Rack", kniferackPic, kniferackInventoryPic));
            evidenceItems.Add(new Evidence("Pill", PillPic, pillInventoryPic));
            evidenceItems.Add(new Evidence("CCTV Broke", CCTVPic, CCTVInventoryPic));
            evidenceItems.Add(new Evidence("Earing ", earingPic, earingInventoryPic));
            evidenceItems.Add(new Evidence("Gun", gunPic, gunInventoryPic));
            evidenceItems.Add(new Evidence("Finger Print", fingerprintPic, fingerprintInventoryPic));
            evidenceItems.Add(new Evidence("Will 1", will1Pic, will1InventoryPic));
            evidenceItems.Add(new Evidence("Bullet Hole", bulletholePic, bulletHoleInventoryPic));
        }

        private void ShowPanel(Panel panelToShow)
        {
            // Hide all main panels
            StartPanel.Visible = false;
            NamePanel.Visible = false;
            GenderPanel.Visible = false;
            GenderPanelFemale.Visible = false;
            GenderPanelMale.Visible = false;


            // Show selected panel
            panelToShow.Visible = true;
            panelToShow.BringToFront();
        }

        private void Office()
        {
            previousPanel = GetCurrentlyVisiblePanel();
            ShowPanel(femaleOfficepanel);
            if(gender == "female")
            {
                femaleofficepic.Visible = true;
                maleOfficePic.Visible = false;
            }
            else
            {
                maleOfficePic.Visible = true;
                femaleofficepic.Visible = false;
            }
        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            ShowPanel(NamePanel);
        }
        private void FemaleBtn_Click(object sender, EventArgs e)
        {
            name = nameTxt.Text;
            if (!gameManager.CreateDetective(name, "Female"))
            {
                MessageBox.Show("Please enter your name.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                greetinglbl2.Text = gameManager.GetGreeting();
                ShowPanel(GenderPanel);
                GenderPanelFemale.Visible = true;
                GenderPanelMale.Visible = false;
            }
            gender = "female";
        }

        private void MaleBtn_Click(object sender, EventArgs e)
        {
            name = nameTxt.Text;
            NamePanel.Visible = true;
            
            NamePanel.Visible = false;
            if (!gameManager.CreateDetective(name, "Male"))
            {
                MessageBox.Show("Please enter your name.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                greetinglbl1.Text = gameManager.GetGreeting();
                ShowPanel(GenderPanel);
                GenderPanelMale.Visible = true;
                GenderPanelFemale.Visible = false;
            }
            gender = "male";
        }

        private void ContinueBtn_Click(object sender, EventArgs e)
        {
            ShowPanel(livingRoomPanel);
            ShowPanel(instructionPanel);
            var remover = new TimedRemover(instructionPanel, 4000); 
            remover.Start();
        }

        private void ContinueFemaleBtn_Click(object sender, EventArgs e)
        {
            ShowPanel(livingRoomPanel);
            ShowPanel(instructionPanel);
            var remover = new TimedRemover(instructionPanel, 4000); 
            remover.Start();
        }

        private void vasePic_Click(object sender, EventArgs e)
        {
            vasePic.Visible = false;
            
        }

        private void bloodyglovePic_Click(object sender, EventArgs e)
        {
            bloodyglovePic.Visible = false;
        }

        private void shoeprintPic_Click(object sender, EventArgs e)
        {
            shoeprintPic.Visible = false;
        }

        private void idcardPic_Click(object sender, EventArgs e)
        {
            idcardPic.Visible = false;
        }

        private void carkeysPic_Click(object sender, EventArgs e)
        {
            carkeysPic.Visible = false;
        }

        private void bedroomBtn_Click(object sender, EventArgs e)
        {
            currentPuzzle = new Bedroom();
            currentRoom = "Bedroom";
            puzzleLbl.Text = currentPuzzle.GetRandomRiddle();
            ShowPanel(puzzlePanel);
            //ShowPanel(bedroomPanel);
        }

        private void KitchenBtn_Click(object sender, EventArgs e)
        {
            currentPuzzle = new Kitchen();
            currentRoom = "Kitchen";
            puzzleLbl.Text = currentPuzzle.GetRandomRiddle();
            ShowPanel(puzzlePanel);
            //ShowPanel(kitchenPanel);
        }

        private void LibraryBtn_Click(object sender, EventArgs e)
        {
            currentPuzzle = new Library();
            currentRoom = "Library";
            puzzleLbl.Text = currentPuzzle.GetRandomRiddle();
            ShowPanel(puzzlePanel);
            //ShowPanel(LibraryPanel);
        }

        private void GardenBtn_Click(object sender, EventArgs e)
        {
            currentPuzzle = new Garden();
            currentRoom = "Garden";
            puzzleLbl.Text = currentPuzzle.GetRandomRiddle();
            ShowPanel(puzzlePanel);
            //ShowPanel(gardenPanel);
        }

        private void inventoryPic_Click(object sender, EventArgs e)
        {
            ShowPanel(Inventory_Panel);
        }

        private void OfficeSymbolPic_Click(object sender, EventArgs e)
        {
            Office();
        }

        private void XBtn_Click(object sender, EventArgs e)
        {
            Inventory_Panel.Visible = false;
        }

        private void backbedroomBtn_Click(object sender, EventArgs e)
        {
            ShowPanel(livingRoomPanel);
        }

        private void inventoryroomPic_Click(object sender, EventArgs e)
        {
            ShowPanel(Inventory_Panel);
        }
        private void officeroomPic_Click(object sender, EventArgs e)
        {
            Office();
        }

        private void InventorykitchenPic_Click(object sender, EventArgs e)
        {
            ShowPanel(Inventory_Panel);
        }

        private void officeKitchenPic_Click(object sender, EventArgs e)
        {
            Office();
        }

        private void backKitchenBtn_Click(object sender, EventArgs e)
        {
            ShowPanel(livingRoomPanel);
        }

        private void inventoryGardenPic_Click(object sender, EventArgs e)
        {
            ShowPanel(Inventory_Panel);
        }

        private void backGardenBtn_Click(object sender, EventArgs e)
        {
            ShowPanel(livingRoomPanel);
        }

        private void InvetorylibraryPic_Click(object sender, EventArgs e)
        {
            ShowPanel(Inventory_Panel);
        }

        private void BackLibraryBtn_Click(object sender, EventArgs e)
        {
            ShowPanel(livingRoomPanel);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Office();
        }

        private void XpuzzleBtn_Click(object sender, EventArgs e)
        {
            puzzlePanel.Visible = false;
        }

        private void okaypuzBtn_Click(object sender, EventArgs e)
        {
            string answer = answerpuzTxt.Text.Trim();

            if (currentPuzzle.CheckAnswer(answer))
            {
                puzzlePanel.Visible = false;

                switch (currentRoom)
                {
                    case "Bedroom":
                        ShowPanel(bedroomPanel);
                        break;
                    case "Kitchen":
                        ShowPanel(kitchenPanel);
                        break;
                    case "Library":
                        ShowPanel(LibraryPanel);
                        break;
                    case "Garden":
                        ShowPanel(gardenPanel);
                        break;
                }

            }
            else if (!currentPuzzle.HasAttemptsLeft())
            {
                MessageBox.Show("Access Denied! ", "You loose ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShowPanel(losepanel);
            }
            else
            {
                MessageBox.Show("Access Denied! Attempts left: 2", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            answerpuzTxt.Clear();
            var remover = new TimedRemover(cautionLbl, 2000);
            remover.Start();

        }

        private void InventoryfemOfficePic_Click(object sender, EventArgs e)
        {
            ShowPanel(Inventory_Panel);
        }

        private void officeGardenPic_Click_1(object sender, EventArgs e)
        {
            Office();
        }

        private void officeRoomPic_Click_1(object sender, EventArgs e)
        {
            Office();
        }

        private void backOfficeBtn_Click(object sender, EventArgs e)
        {
            if (previousPanel != null)
            {
                ShowPanel(previousPanel);
            }
            else
            {
                ShowPanel(livingRoomPanel); 
            }
        }

        private void interogateBtn_Click(object sender, EventArgs e)
        {

        }

        private void lockerLibPic_Click(object sender, EventArgs e)
        {

        }
    }
}
