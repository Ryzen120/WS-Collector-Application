using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;using System.Text.RegularExpressions;
using System.IO;

namespace WS_Collector
{
    public partial class WSCollector : Form
    {
        private Dictionary<string, Card> cardDictionary = new Dictionary<string, Card>();
        private List<Card> gUserCollection = new List<Card>();
        private List<Card> gAllCards = new List<Card>();

        private string gSearchText;
        private string gSearchTextMyCollection;
        private string gSeriesSelection;
        private string gSeriesSelectionForFilteringCurrentList;
        private string gCollectionFilePath;
        private string gCardIdToFilterBy;
        private string gCardTypeFilter;
        private string gRarityFilter;
        private string gLevelFilter;
        private string gSoulFilter;
        private string gPowerFilter;
        private string gExpansion;
        private string gTrigger;

        private int gPageIndex = 0;
        private int gPageSize = 100;
        private int gTotalItems = 20095;

        public WSCollector()
        {
            InitializeComponent();

            // Double buffering is a technique used to reduce or eliminate flickering and improve the rendering performance of the control when it is being redrawn.
            typeof(ListView).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(m_ListViewAllCards, true, null);

            // Setup path for collection file
            gCollectionFilePath = Environment.GetEnvironmentVariable("USERPROFILE") + "\\MyCollectionFile.txt";

            // Disable delete button
            m_ButtonDeleteFromMyCollection.Enabled = false;

            // Create tooltip for collection button explaining file
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;    // Time the tooltip remains visible if the pointer is stationary.
            toolTip1.InitialDelay = 1000;    // Time before the tooltip appears.
            toolTip1.ReshowDelay = 500;      // Time before the tooltip reappears if the pointer moves from one control to another.
            toolTip1.ShowAlways = true;      // Show the tooltip even if the form is not active.

            // Set up the Tooltip text for the Button.
            toolTip1.SetToolTip(this.m_ButtonViewMyCollection, "This is your collection! It is saved to a .txt file on your machine at C:\\Users\\userName\\MyCollectionFile.txt. \n Please never delete this file unless you want to delete your entire collection!");

            // Setup for large icons and ListView event handlers
            m_ListViewAllCards.View = View.LargeIcon;
            m_ListViewAllCards.LargeImageList = imageListCards;
            this.m_ListViewAllCards.ItemActivate += new System.EventHandler(this.m_ListViewAllCards_ItemActivate);

            // Manually defined choices for the dropdowns
            var seriesChoices = new List<string>
            {
                "Accel World (AW)",
                "Angel Beats! / Kud (AB, KW, Kab)",
                "Arifureta: From Commonplace to World's Strongest (ARI)",
                "Assault Lily (ALL)",
                "Attack on Titan (AOT)",
                "Azur Lane (AZL)",
                "Bang Dream (BD)",
                "Black Rock Shooter (BR)",
                "Bofuri (BFR)",
                "CANAAN (CN)",
                "Cardcaptor Sakura (CCS)",
                "Chain Chronicle (CC)",
                "Charlotte (CHA, Kch)",
                "CLANNAD (CL, Kcl)",
                "Crayon Shin-Chan (CS)",
                "Da Capo/Dal Segno (DC, DC2, DC3, DS, DC4)",
                "Darling in the Franxx (FXX)",
                "Date A Live (DAL)",
                "Day Break Illusion (GT)",
                "Devil Survivor 2 (DS2)",
                "Disgaea (DG)",
                "Dog Days (DD)",
                "Evangelion (EV)",
                "FAIRY TAIL (FT)",
                "Familiar of Zero (ZM)",
                "Fate (FS, FU, FH)",
                "Fate/Apocrypha (APO)",
                "Fate/Grand Order (FGO)",
                "Fate/Zero (FZ)",
                "Fujimi Fantasia Bunko (Fab,Foy,Fii,Fks,Fkm,Fkz,Fsl,Fsi,F35,Fos,Fdl,Fdy,Ftr,Fdd,Fhc,Ffp,Fmr,Fra)",
                "Gargantia (GG)",
                "Gigant Shooter Tsukasa (GST)",
                "Girl Friend Beta (GF)",
                "Goblin Slayer (GBS)",
                "Godzilla (GZL)",
                "Guilty Crown (GC)",
                "Guilty Gear (GGST)",
                "Gurren Lagann (GL)",
                "Haruhi Suzumiya (SY, Ssy)",
                "Hina Logic (HLL)",
                "Idolmaster (IM, IAS)",
                "Imas Cinderella Girls (IMC)",
                "Imas Million Live (IMS, IAS)",
                "Index / Railgun (ID, RG)",
                "Is the Order a Rabbit?? (GU)",
                "Jojo's Bizarre Adventure (JJ)",
                "Kadokawa Sneaker Bunko (Snk,Sks,Sst,Ssy,Snw,Ssw,Shh,Smi,Sls,Seo,Sky,Ssk,Ssh,Shg,Sfl,Smc,Smu,Sle,Srm)",
                "KanColle (KC)",
                "Katanagatari (KG)",
                "Kemono Friends (KMN)",
                "Key 20th Anniversary (Kab, Kch, Kcl, Klb, Krw)",
                "Kill La Kill (KLK)",
                "Kiznaiver (KI)",
                "Konosuba (KS, Sks)",
                "Leapt thr. Space/My-Hime/Otome (SK, MH)",
                "Little Busters! (LB, KW, Klb)",
                "Log Horizon (LH)",
                "Lost Decade (LOD)",
                "Love Live! (LL)",
                "Love Live Nijigasaki (LNJ)",
                "Love Live! Sunshine!! (LSS)",
                "Lucky Star (LS)",
                "Macross Frontier (MF)",
                "Madoka Magica (MM, MR)",
                "MELTY BLOOD / Kyoukai (MB, KK)",
                "Miku (PD)",
                "Milky Holmes (MK, MK2)",
                "Monogatari Series (BM, NM, MG)",
                "Mushoku Tensei: Jobless Reincarnation (MTI)",
                "Nanoha (NS, N1, NV, NA, N2, NR, ND)",
                "Nichijou (NJ)",
                "Nisekoi (NK)",
                "No Game No Life (NGL)",
                "Osomatsu-san (OMS)",
                "Overlord (OVL)",
                "Persona (P3, P4, PQ, P5)",
                "Phantom (PT)",
                "Princess Connect (PRD)",
                "Prisma Illya (PI)",
                "Psycho-Pass (PP)",
                "Puyo Puyo (PY)",
                "Quintessential Quintuples (5HY)",
                "Rascal Does Not Dream of Bunny Girl Senpai (SBY)",
                "Rent-A-Girlfriend (KNK)",
                "Revue Starlight (RSL)",
                "Rewrite (RW, Krw)",
                "Re:Zero (RZ)",
                "Robotics;Notes (RN)",
                "Saekano (SHS)",
                "Sakura Wars (SKR)",
                "Schoolgirl Strikers (SGS)",
                "Sengoku BASARA (SB)",
                "Shana (SS)",
                "Shining Force (SE, SF)",
                "Spy Family (SPY)",
                "Star Wars (SW)",
                "Steins Gate (STG)",
                "Summer Pockets (SMP)",
                "Sword Art Gun Gale (GGO)",
                "Sword Art Online (SAO)",
                "Symphogear (SG)",
                "Terra Formars (TF)",
                "That Time I Got Reincarnated as a Slime (TSK)",
                "The Fruit of Grisaia (GRI)",
                "THE KING OF FIGHTERS (KF)",
                "To Love-Ru (TL)",
                "Visual Arts (VA)",
                "Vividred Operation (VR)",
                "ViVid Strike! (VS)",
                "Wooser (Woo)",
                "Yuuna (YYS)"

            };

            var cardTypeChoices = new List<string>
            {
                "",
                "Rule",
                "Character",
                "Climax",
                "Event"
            };

            var rarityChoices = new List<string>
            {
                "",
                "TD ",
                "PR ",
                "SR ",
                "RR ",
                "SP ",
                "R ",
                "RRR ",
                "U ",
                "C ",
                "CR ",
                "CC ",
                "XR ",
                "RR ",
                "SSP ",
                "μR ",
                "R ",
                "U ",
                "C ",
                "PPR ",
                "SPM ",
                "SEC ",
                "GGR ",
                "HR ",
                "BDR ",
                "STR ",
                "DD ",
                "JJR ",
                "FBR ",
                "KR ",
                "SSP ",
                "OFR ",
                "HYR ",
                "RBR ",
                "PFR ",
                "RTR ",
                "TRV ",
                "TTR ",
                "N ",
                "HLP ",
                "MDR ",
                "DSR ",
                "PS ",
                "ATR ",
                "SCC ",
                "OFR ",
                "SPYR "
            };

            var levelChoices = new List<string>
            {
                "",
                "0",
                "1",
                "2",
                "3"
            };

            var soulChoices = new List<string>
            {
                "",
                "0",
                "1",
                "2",
                "3"
            };

            var powerChoices = new List<string>
            {
                "",
                "500",
                "1000",
                "1500",
                "2000",
                "2500",
                "3000",
                "3500",
                "4000",
                "4500",
                "5000",
                "5500",
                "6000",
                "6500",
                "7000",
                "7500",
                "8000",
                "8500",
                "9000",
                "9500",
                "10000"
            };

            var expansionChoices = new List<string>
            {
                "",
                "Puella Magi Madoka Magica",
                "PR Card 【Weiẞ Side】",
                "PR Card 【Schwarz Side】",
                "Two Worlds(SAO/S20PE04) PR Card 【Schwarz Side】",
                "Disgaea ～Hour of Darkness～",
                "Sword Art Online",
                "Start of the Battle(SAO/S20TE02) Sword Art Online",
                "Start of the Battle(SAO/S20TE07) Sword Art Online",
                "Snow Mountain on Floor 55(SAO/S20TE12) Sword Art Online",
                "Start of the Battle(SAO/S20E017) Sword Art Online",
                "Like a Date(SAO/S20E055) Sword Art Online",
                "Start of the Adventure(SAO/S20E057) Sword Art Online",
                "For Someone Special(SAO/S20E080) Sword Art Online",
                "For Someone Special(SAO/S20E080S) Sword Art Online",
                "Start of the Battle(SAO/S20E090) Sword Art Online",
                "Snow Mountain on Floor 55(SAO/S20E093) Sword Art Online",
                "Start of the Battle(SAO/S20TE02R) Sword Art Online",
                "Start of the Battle(SAO/S20TE07R) Sword Art Online",
                "Fate/Zero",
                "Belief in Justice(FZ/S17E003) Fate/Zero",
                "Belief in Justice(FZ/S17E003R) Fate/Zero",
                "Style of Heresy(FZ/S17E004) Fate/Zero",
                "\"Magic Power Unleashed\"(FZ/S17E007) Fate/Zero",
                "Vessel of the Holy Grail(FZ/S17E008S) Fate/Zero",
                "Vessel of the Holy Grail(FZ/S17E008) Fate/Zero",
                "End of Reign(FZ/S17E009) Fate/Zero",
                "End of Reign(FZ/S17E009S) Fate/Zero",
                "Living as a Human(FZ/S17E010) Fate/Zero",
                "Pursuit of the Ideal(FZ/S17E012) Fate/Zero",
                "Noble Phantasm Unleashed(FZ/S17E015) Fate/Zero",
                "\"Magic Power Unleashed\"(FZ/S17E007R) Fate/Zero",
                "Time to Hunt(FZ/S17E021) Fate/Zero",
                "Red Spear Which Cancels Magic(FZ/S17E037) Fate/Zero",
                "Red Spear Which Cancels Magic(FZ/S17E037SP) Fate/Zero",
                "Corrupted Heart(FZ/S17E067) Fate/Zero",
                "Cost of Life(FZ/S17E068) Fate/Zero",
                "Black Murderous Intent(FZ/S17E070) Fate/Zero",
                "Artifice to Sure Victory(FZ/S17E076) Fate/Zero",
                "Jewel Magic(FZ/S17E077) Fate/Zero",
                "Proud Royal Path(FZ/S17E079) Fate/Zero",
                "The Emptiness Within(FZ/S17E086) Fate/Zero",
                "The Emptiness Within(FZ/S17E086S) Fate/Zero",
                "Hatsune Miku Project DIVA ƒ",
                "BAKEMONOGATARI",
                "Sword Art Online Vol.2",
                "Two Worlds(SAO/S26E069) Sword Art Online Vol.2",
                "Love Live!",
                "Angel Beats! Re:Edit",
                "KILL la KILL",
                "Persona 4 ver.E",
                "FAIRY TAIL ver.E",
                "NISEKOI False Love",
                "NISEKOI False Love ver.E",
                "Hatsune Miku: Project DIVA F 2nd",
                "Sword Art Online II",
                "Kancolle",
                "Love Live! DX",
                "Attack on Titan",
                "Fate/stay night [Unlimited Blade Works]",
                "PUELLA MAGI MADOKA MAGICA THE MOVIE Rebellion",
                "LOG HORIZON",
                "Kancolle, 2nd Fleet",
                "Love Live! School idol festival",
                "Love Live! Vol.2",
                "【Tutorial Deck】 Detective Opera Milky Holmes",
                "The Melancholy of Haruhi Suzumiya",
                "NISEMONOGATARI",
                "THE IDOLM@STER CINDERELLA GIRLS ~Smile~",
                "THE IDOLM@STER CINDERELLA GIRLS ~Power~",
                "THE IDOLM@STER CINDERELLA GIRLS ~Heart~",
                "THE IDOLM@STER CINDERELLA GIRLS",
                "Opposing Blade, Melody of Light(IMC/W41E110) THE IDOLM@STER CINDERELLA GIRLS",
                "Opposing Blade, Melody of Light(IMC/W41E110R) THE IDOLM@STER CINDERELLA GIRLS",
                "Opposing Blade, Melody of Light(IMC/W41E110S) THE IDOLM@STER CINDERELLA GIRLS",
                "Fate/stay night [Unlimited Blade Works] Vol.2",
                "Sword Art Online Ⅱ Vol.2",
                "Disgaea",
                "NISEKOI: False Love",
                "Love Live! DX Vol.2",
                "Fate/kaleid liner PRISMA ILLYA",
                "To Loveru Darkness 2nd",
                "Love Live! Sunshine!!",
                "BanG Dream!",
                "Sword Art Online Re: Edit",
                "KanColle : Fleet in the Deep Sea, Sighted!",
                "Accel・World",
                "KONOSUBA God’s blessing on this wonderful world!",
                "Attack on Titan Vol.2",
                "Accel・World Infinite Burst",
                "Sword Art Online The Movie – Ordinal Scale –",
                "Persona 5",
                "GURREN LAGANN",
                "BanG Dream! Girls Band Party! [Roselia]",
                "BanG Dream! Girls Band Party!",
                "Fate/Apocrypha",
                "KanColle : Arrival! Reinforcement Fleets from Europe!",
                "KONOSUBA God’s blessing on this wonderful world! 2",
                "Re:ZERO Starting Life in Another World",
                "Cardcaptor Sakura : Clear Card",
                "No Game No Life",
                "SAO Alternative – Gun Gale Online –",
                "BanG Dream! Girls Band Party! MULTI LIVE",
                "Revue Starlight",
                "Batman Ninja",
                "【Demo Deck】Batman Ninja",
                "Re:ZERO Starting Life in Another World Vol.2",
                "BanG Dream! Girls Band Party! Vol.2",
                "Rascal Does Not Dream of Bunny Girl Senpai",
                "Fate/stay night [Heaven’s Feel]",
                "Goblin Slayer",
                "Sword Art Online Alicization",
                "JoJo's Bizarre Adventure: Golden Wind",
                "Fujimi Fantasia Bunko",
                "BanG Dream! [RAISE A SUILEN]",
                "BanG Dream! Vol.2",
                "That Time I Got Reincarnated as a Slime",
                "Re:ZERO Starting Life in Another World Memory Snow",
                "Nazarick: Tomb of the Undead",
                "KONOSUBA God’s blessing on this wonderful world! Legend of Crimson",
                "【Demo Deck】 Adventure Time",
                "Adventure Time",
                "Mob Psycho 100",
                "Fate/Grand Order Absolute Demonic Front: Babylonia",
                "Magia Record: Puella Magi Madoka Magica Side Story",
                "Re:ZERO Starting Life in Another World The Frozen Bond",
                "Date A Live",
                "TV Anime \"Magia Record: Puella Magi Madoka Magica Side Story\"",
                "BOFURI: I Don’t Want to Get Hurt, so I’ll Max Out My Defense.",
                "Kaguyasama: Love is War",
                "The Seven Deadly Sins",
                "Fate/stay night [Heaven's Feel] Vol.2",
                "That Time I Got Reincarnated as a Slime Vol.2",
                "Sword Art Online Alicization Vol.2",
                "The Quintessential Quintuplets",
                "Date A Bullet",
                "RWBY",
                "BanG Dream! Girls Band Party [Morfonica]",
                "BanG Dream! Girls Band Party Morfonica×RAISE A SUILEN",
                "BanG Dream! Girls Band Party Extra Booster Poppin’Party×Roselia",
                "RentAGirlfriend",
                "Mushoku Tensei: Jobless Reincarnation",
                "BanG Dream! Girls Band Party Premium Booster",
                "hololive production 0th Generation",
                "hololive production 1st Generation",
                "hololive production 2nd Generation",
                "hololive production Gamers",
                "hololive production 3rd Generation",
                "hololive production 4th Generation",
                "hololive production 5th Generation",
                "hololive production",
                "Fate/Grand Order THE MOVIE Divine Realm of the Round Table: Camelot",
                "Agateram(FGO/S87E077) Fate/Grand Order THE MOVIE Divine Realm of the Round Table: Camelot",
                "Agateram(FGO/S87E077R) Fate/Grand Order THE MOVIE Divine Realm of the Round Table: Camelot",
                "Is It Wrong to Try to Pick Up Girls in a Dungeon?",
                "Tokyo Revengers",
                "The Quintessential Quintuplets 2",
                "Attack On Titan: Final Season",
                "Rascal Does Not Dream of a Dreaming Girl",
                "Saekano: How to Raise a Boring Girlfriend",
                "Miss Kobayashi’s Dragon Maid",
                "The Seven Deadly Sins: Revival of The Commandments",
                "Kaguyasama: Love Is War?",
                "Power Up Set 2023 KILL La KILL",
                "Power Up Set 2023 The Melancholy of Suzumiya Haruhi",
                "Power Up Set 2023 LOG HORIZON",
                "Date A Live Vol.2",
                "BanG Dream! Girls Band Party! 5th Anniversary",
                "Animation Sword Art Online 10th Anniversary",
                "Saekano♭ How to Raise a Boring Girlfriend. flat",
                "The Fruit of Grisaia",
                "The Quintessential Quintuplets Movie",
                "Avatar: The Last Airbender",
                "Revue Starlight Re LIVE",
                "That Time I Got Reincarnated as a Slime Vol.3",
                "hololive production Vol.2",
                "Nazarick: Tomb of the Undead Vol.2",
                "Revue Starlight The Movie",
                "Azur Lane Eagle Union Ver.",
                "Azur Lane Royal Navy Ver.",
                "Azur Lane Sakura Empire Ver.",
                "Azur Lane Iron Blood Ver.",
                "Azur Lane",
                "Arifureta: From Commonplace to World’s Strongest",
                "Guilty Gear Strive",
                "SPY x FAMILY"
            };

            var triggerChoices = new List<string>
            {
                "",
                "Soul+1",
                "Soul+2",
                "Pool",
                "Comeback",
                "Return",
                "Draw",
                "Treasure",
                "Shot",
                "Gate",
                "Choice",
                "Standby"
            };

            // Populate the comboBoxSeries with these choices
            foreach (var choice in seriesChoices)
            {
                m_DropDownSeries.Items.Add(choice);
                m_DropDownFilterBySeries.Items.Add(choice);
            }

            foreach(var cardType in cardTypeChoices)
            {
                m_DropDownCardType.Items.Add(cardType);
            }

            foreach (var rarity in rarityChoices)
            {
                m_DropDownRarity.Items.Add(rarity);
            }

            foreach (var level in levelChoices)
            {
                m_DropDownLevel.Items.Add(level);
            }

            foreach (var soul in soulChoices)
            {
                m_DropDownSoul.Items.Add(soul);
            }

            foreach (var power in powerChoices)
            {
                m_DropDownPower.Items.Add(power);
            }

            foreach (var trigger in triggerChoices)
            {
                m_DropDownTrigger.Items.Add(trigger);
            }

            foreach (var expansion in expansionChoices)
            {
                m_DropDownExpansion.Items.Add(expansion);
            }

            // Set a default selection for series dropdowns so users can mass query off the rip.
            m_DropDownSeries.SelectedIndex = 0;
            m_DropDownFilterBySeries.SelectedIndex = 0;

            // Load initial card data to screen for fun. meh idk, skipping this for now.
            //LoadMoreData();
        }

        private async void m_ButtonQuery_Click(object sender, EventArgs e)
        {
            try
            {
                // Do some cleaunup before doing anything else.
                m_ButtonDeleteFromMyCollection.Enabled = false;
                ControlFilterStates(false);
                m_LabelClearingList.Visible = true;
                Task task1 = Task.Run(() => ClearLists());
                await task1;
                m_LabelClearingList.Visible = false;
                m_ListViewAllCards.Items.Clear();
                m_LabelResultsCount.Text = "Results Count: 0";
                imageListCards.Images.Clear();

                // Pattern to match content within parentheses
                string pattern = @"\(([^)]*)\)";

                Match match = Regex.Match(gSeriesSelection, pattern);
                if (match.Success)
                {
                    string extracted = match.Groups[1].Value; // Extracted content within the parentheses
                    Console.WriteLine(extracted); // Outputs: FS, FU, FH, FZ
                    gSeriesSelection = extracted;
                }

                //LoadCardToListView(gSeriesSelection);
                Task task2 = Task.Run(() => LoadCardToListView(gSeriesSelection));
                await task2;

                ControlFilterStates(true);
                m_LabelResultsCount.Text = "Results Count: " + m_ListViewAllCards.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: " + ex.Message + "\n\n" +
                        "Program will now close. Please restart and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private async void LoadCardToListView(string series)
        {
            DataManager dataManager = new DataManager();
            var cards = dataManager.GetCardsBySeries(series);

            // Update UI incrementally
            await Task.Run(() =>
            {
                int batchCount = 0;
                foreach (var card in cards)
                {
                    Invoke((MethodInvoker)delegate 
                    { 
                        PopulateListView(card);
                        m_LabelResultsCount.Text = "Results Count: " + m_ListViewAllCards.Items.Count.ToString();
                    });

                    if (++batchCount % 10 == 0) // Adjust batch size as needed
                    {
                        System.Threading.Thread.Sleep(1); // Give UI thread time to update, but keep this very short
                    }
                }
            });

        }
      
        private void PopulateListView(Card card, bool bypassCheck = false)
        {
            if (bypassCheck || !cardDictionary.ContainsKey(card.ID.ToString()))
            {
                // Check if the card's ID already exists in the dictionary to avoid duplicates
                if (!cardDictionary.ContainsKey(card.ID.ToString()))
                {
                    // Only add the image to the ImageList if it doesn't already contain this key
                    if (!imageListCards.Images.ContainsKey(card.ID.ToString()))
                    {
                        imageListCards.Images.Add(card.ID.ToString(), card.CardImage);
                    }

                    // Since the key doesn't exist in the dictionary, it's safe to add the card
                    cardDictionary.Add(card.ID.ToString(), card);

                    // Create and add the ListViewItem
                    ListViewItem item = new ListViewItem
                    {
                        Text = "Card ID: " + card.ID + " " +  card.CardName + "\n" + card.CardNumber, // Display the card name
                        ImageKey = card.ID.ToString()
                    };
                    m_ListViewAllCards.Items.Add(item);
                }
                else
                {
                    MessageBox.Show($"Card '{card.CardName}' is already in the collection.", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        private void m_TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            gSearchText = m_TextBoxSearch.Text;
        }

        private async void m_ButtonSearch_Click(object sender, EventArgs e)
        {

            try
            {
                if (String.IsNullOrEmpty(m_TextBoxSearch.Text))
                {
                    MessageBox.Show("Please provide text in the search field before attempting to search for cards.\n\n" +
                        "You may search by things such as Card name, number, ID, card text, souls, power, etc.\n\n" +
                        "***NOTE*** If you provide text that is too broad (like a blank space or a single letter), this could lead to a very large query of card data and crash the program.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    m_LabelClearingList.Visible = true;
                    m_ButtonDeleteFromMyCollection.Enabled = false;
                    ControlFilterStates(false);
                    Task task1 = Task.Run(() => ClearLists());
                    await task1;
                    m_LabelClearingList.Visible = false;
                    m_ListViewAllCards.Items.Clear();
                    m_LabelResultsCount.Text = "Results Count: 0";
                    imageListCards.Images.Clear();

                    DataManager dataManager = new DataManager();
                    List<Card> cards = dataManager.SearchCards(gSearchText);

                    await Task.Run(() =>
                    {
                        int batchCount = 0;
                        foreach (var card in cards)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                PopulateListView(card);
                                m_LabelResultsCount.Text = "Results Count: " + m_ListViewAllCards.Items.Count.ToString();
                            });

                            if (++batchCount % 10 == 0) // Adjust batch size as needed
                            {
                                System.Threading.Thread.Sleep(1); // Give UI thread time to update, but keep this very short
                            }
                        }
                    });
                    ControlFilterStates(true);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error occured: " + ex.Message + "\n\n" +
                        "Program will now close. Please restart and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void m_ListViewAllCards_ItemActivate(object sender, EventArgs e)
        {
            if (m_ListViewAllCards.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = m_ListViewAllCards.SelectedItems[0];
                string imageKey = selectedItem.ImageKey;
                Image cardImage = imageListCards.Images[imageKey];

                // Retrieve the full Card object based on the selected item or imageKey
                // This assumes you have a method or means to retrieve the Card object. If not, you'll need to implement this.
                Card selectedCard = GetCardByImageKey(imageKey); // You need to implement GetCardByImageKey or a similar method

                // Now open the new form with the image and details
                FormImagePreview imagePreviewForm = new FormImagePreview(
                    cardImage,
                    selectedCard.CardName,
                    selectedCard.Expansion,
                    selectedCard.CardText,
                    selectedCard.CardNumber,
                    selectedCard.ID.ToString()
                );
                imagePreviewForm.ShowDialog(); // ShowDialog() makes it modal, use Show() for non-modal
            }
        }

        private Card GetCardByImageKey(string imageKey)
        {
            if (cardDictionary.TryGetValue(imageKey, out Card card))
            {
                return card;
            }
            else
            {
                // Handle the case where the card is not found. You might return null or throw an exception.
                return null;
            }
        }

        private void m_ButtonLoadMore_Click(object sender, EventArgs e)
        {
            m_ButtonDeleteFromMyCollection.Enabled = false;
            LoadMoreData();
            m_LabelResultsCount.Text = "Results Count: " + m_ListViewAllCards.Items.Count.ToString();
        }

        private void LoadMoreData()
        {
            // Check if there's more data to load
            if (gPageIndex < gTotalItems)
            {

                DataManager dataManager = new DataManager();
                List<Card> cards = dataManager.RetrieveCardsChunk(gPageIndex, gPageSize);

                foreach (var card in cards)
                {
                    PopulateListView(card);
                }

                gPageIndex += cards.Count; // Prepare offset for the next load

                if (gPageIndex >= gTotalItems)
                {
                    m_ButtonLoadMore.Enabled = false;
                }

                cards.Clear();
            }

            m_ListViewAllCards.Clear();

        }

        private void m_DropDownSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            gSeriesSelection = m_DropDownSeries.SelectedItem.ToString();
        }

        private async void m_ButtonClearList_Click(object sender, EventArgs e)
        {
            m_LabelClearingList.Visible = true;
            m_ButtonDeleteFromMyCollection.Enabled = false;
            Task task1 = Task.Run(() => ClearLists());
            await task1;
            m_LabelClearingList.Visible = false;
            m_ListViewAllCards.Items.Clear();
            m_LabelResultsCount.Text = "Results Count: 0";
            imageListCards.Images.Clear();
        }

        private void ClearLists()
        {
            // Dispose of images to free up resources immediately
            foreach (Image image in imageListCards.Images)
            {
                image?.Dispose(); // The null conditional operator is used to avoid attempting to dispose a null reference.
            }

            // Dispose of Card images
            foreach (var card in cardDictionary.Values)
            {
                card.CardImage?.Dispose();
            }

            // Now clear the collections
            cardDictionary.Clear();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void m_ButtonAddToMyCollection_Click(object sender, EventArgs e)
        {
            DataManager dataManager = new DataManager();
            m_ButtonDeleteFromMyCollection.Enabled = false;

            foreach (ListViewItem checkedItem in m_ListViewAllCards.CheckedItems)
            {
                string key = checkedItem.ImageKey;
                var card = dataManager.GetCardById(key);
                AddCardToCollectionAndFile(card);

                if (card != null)
                {
                    AddCardToCollectionAndFile(card);
                }
            }
            MessageBox.Show("Collection update complete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddCardToCollectionAndFile(Card card)
        {
            // Check if the card is already in the in-memory collection
            if (!gUserCollection.Contains(card))
            {
                // Read all existing IDs from the collection file
                HashSet<string> existingIds = new HashSet<string>();
                if (File.Exists(gCollectionFilePath))
                {
                    var lines = File.ReadAllLines(gCollectionFilePath);
                    foreach (var line in lines)
                    {
                        existingIds.Add(line);
                    }
                }

                // Check if the card's ID is not in the file
                if (!existingIds.Contains(card.ID.ToString()))
                {
                    gUserCollection.Add(card); // Add to in-memory collection

                    // Append the card ID to the collection file
                    try
                    {
                        File.AppendAllLines(gCollectionFilePath, new[] { card.ID.ToString() });
                        MessageBox.Show("The card: " + card.CardName + " was added to your collection!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Failed to update the collection file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Optionally handle the case where the card is already in the file
                    MessageBox.Show("The card: " + card.CardName +  " is already in your collection.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DeleteCardFromCollectionAndFile(Card card)
        {
            if (gUserCollection.Contains(card))
            {
                // Remove the card from the in-memory collection
                gUserCollection.Remove(card);

                // Read all existing IDs from the collection file into a list
                List<string> existingIds = new List<string>();
                if (File.Exists(gCollectionFilePath))
                {
                    existingIds = File.ReadAllLines(gCollectionFilePath).ToList();
                }

                // Remove the card's ID from the list of IDs
                if (existingIds.Remove(card.ID.ToString()))
                {
                    // Rewrite the collection file without the removed ID
                    try
                    {
                        File.WriteAllLines(gCollectionFilePath, existingIds);
                        MessageBox.Show("The card: " + card.CardName + " was removed from your collection!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ViewMyCollection();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Failed to update the collection file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Optionally handle the case where the card ID was not found in the file
                    MessageBox.Show("The card: " + card.CardName + " was not found in your collection.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void m_ButtonViewMyCollection_Click(object sender, EventArgs e)
        {
            m_ButtonDeleteFromMyCollection.Enabled = true;
            ViewMyCollection();
            m_LabelResultsCount.Text = "Results Count: " + m_ListViewAllCards.Items.Count.ToString();
        }

        private void ViewMyCollection()
        {
            DataManager dataManager = new DataManager();

            gUserCollection.Clear();
            m_ListViewAllCards.Items.Clear();
            cardDictionary.Clear(); // Clear existing entries to avoid "already exists" issues

            if (File.Exists(gCollectionFilePath))
            {
                var lines = File.ReadAllLines(gCollectionFilePath);
                foreach (var line in lines)
                {
                    // Use the new method to fetch a card by its ID
                    var card = dataManager.GetCardById(line);
                    if (card != null)
                    {
                        gUserCollection.Add(card);
                        PopulateListView(card); // Add the card to the ListView
                    }
                }
            }
            else
            {
                MessageBox.Show("Your collection file did not exist. You do not have a collection :(", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void m_ButtonDeleteFromMyCollection_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem checkedItem in m_ListViewAllCards.CheckedItems)
            {
                string key = checkedItem.ImageKey; // Assuming the ImageKey identifies the Card
                if (cardDictionary.TryGetValue(key, out Card card))
                {
                    DeleteCardFromCollectionAndFile(card);
                }
            }

            m_LabelResultsCount.Text = "Results Count: " + m_ListViewAllCards.Items.Count.ToString();
        }

        private async void m_ButtonFilterResults_Click(object sender, EventArgs e)
        {
            try
            {
                m_ButtonFilterResults.Enabled = false;
                Task task1 = Task.Run(() => ClearLists());
                await task1;

                DataManager dataManager = new DataManager();

                string pattern = @"\(([^)]*)\)"; // Pattern to match content within parentheses

                Match match = Regex.Match(gSeriesSelection, pattern);
                if (match.Success)
                {
                    string extracted = match.Groups[1].Value; // Extracted content within the parentheses
                    Console.WriteLine(extracted); // Outputs: FS, FU, FH, FZ
                    gSeriesSelection = extracted;
                }

                gAllCards = dataManager.GetCardsByFilters(gSeriesSelection, gCardTypeFilter, gPowerFilter, gLevelFilter, gSoulFilter, gCardIdToFilterBy, gRarityFilter, gExpansion, gTrigger);

                RepopulateListView(gAllCards);

                m_LabelResultsCount.Text = "Results Count: " + m_ListViewAllCards.Items.Count.ToString();
                m_ButtonFilterResults.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured: " + ex.Message + "\n\n" +
                        "Program will now close. Please restart and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void RepopulateListView(List<Card> cards)
        {
            m_ListViewAllCards.BeginUpdate(); // Prevent flickering and improve performance
            m_ListViewAllCards.Items.Clear();

            foreach (var card in cards)
            {
                var item = new ListViewItem(card.CardName)
                {
                    Tag = card
                };
                if (!imageListCards.Images.ContainsKey(card.ID.ToString()))
                {
                    imageListCards.Images.Add(card.ID.ToString(), card.CardImage);
                }

                // If you use ImageList and each card has an associated image
                if (imageListCards.Images.ContainsKey(card.ID.ToString()))
                {
                    item.Text = "Card ID: " + card.ID + " " + card.CardName + "\n" + card.CardNumber;
                    item.ImageKey = card.ID.ToString();
                }
                m_ListViewAllCards.Items.Add(item);
            }

            m_ListViewAllCards.EndUpdate();
        }

        private void m_DropDownFilterBySeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            gSeriesSelectionForFilteringCurrentList = m_DropDownFilterBySeries.SelectedItem.ToString();
            
        }

        private void m_TextBoxFilterByCardID_TextChanged(object sender, EventArgs e)
        {
            gCardIdToFilterBy = m_TextBoxFilterByCardID.Text;
        }

        private void m_DropDownCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            gCardTypeFilter = m_DropDownCardType.SelectedItem.ToString();
        }

        private void m_DropDownRarity_SelectedIndexChanged(object sender, EventArgs e)
        {
            gRarityFilter = m_DropDownRarity.SelectedItem.ToString();
        }

        private void m_DropDownLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            gLevelFilter = m_DropDownLevel.SelectedItem.ToString();
        }

        private void m_DropDownSoul_SelectedIndexChanged(object sender, EventArgs e)
        {
            gSoulFilter = m_DropDownSoul.SelectedItem.ToString();
        }

        private void m_DropDownPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            gPowerFilter = m_DropDownPower.SelectedItem.ToString();
        }

        private void ControlFilterStates(bool state)
        {
            m_ButtonFilterResults.Enabled = state;
            m_ButtonApplyFiltersToCollection.Enabled = state;
        }

        private void m_DropDownExpansion_SelectedIndexChanged(object sender, EventArgs e)
        {
            gExpansion = m_DropDownExpansion.SelectedItem.ToString();
        }

        private void m_DropDownTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            gTrigger = m_DropDownTrigger.SelectedItem.ToString();
        }

        private async void m_ButtonApplyFiltersToCollection_Click(object sender, EventArgs e)
        {
            m_ButtonApplyFiltersToCollection.Enabled = false;
            Task task1 = Task.Run(() => ClearLists());
            await task1;

            DataManager dataManager = new DataManager();

            string pattern = @"\(([^)]*)\)"; // Pattern to match content within parentheses

            Match match = Regex.Match(gSeriesSelectionForFilteringCurrentList, pattern);
            if (match.Success)
            {
                string extracted = match.Groups[1].Value; // Extracted content within the parentheses
                Console.WriteLine(extracted); // Outputs: FS, FU, FH, FZ
                gSeriesSelectionForFilteringCurrentList = extracted;
            }

            string ids = "";

            if (File.Exists(gCollectionFilePath))
            {

                 var lines = File.ReadAllLines(gCollectionFilePath);
                 // Filter out any empty lines to ensure the IDs string is correctly formatted
                 var filteredLines = lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
                 ids = string.Join(",", filteredLines);

            }
            else
            {
                MessageBox.Show("Your collection file did not exist. You do not have a collection :(", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            gAllCards = dataManager.GetCardsByFiltersForCollection(gSeriesSelectionForFilteringCurrentList, gCardTypeFilter, gPowerFilter, gLevelFilter, gSoulFilter, ids, gRarityFilter, gExpansion, gTrigger);

            RepopulateListView(gAllCards);

            m_LabelResultsCount.Text = "Results Count: " + m_ListViewAllCards.Items.Count.ToString();
            m_ButtonApplyFiltersToCollection.Enabled = true;


        }

        private void m_ButtonResetFilters_Click(object sender, EventArgs e)
        { 

            m_TextBoxFilterByCardID.Text = "";
            m_DropDownCardType.SelectedIndex = 0;
            m_DropDownRarity.SelectedIndex = 0;
            m_DropDownExpansion.SelectedIndex = 0;
            m_DropDownLevel.SelectedIndex = 0;
            m_DropDownSoul.SelectedIndex = 0;
            m_DropDownPower.SelectedIndex = 0;
            m_DropDownTrigger.SelectedIndex = 0;

            MessageBox.Show("Filters have been reset!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void m_TextBoxSearchCurrentList_TextChanged(object sender, EventArgs e)
        {
            gSearchTextMyCollection = m_TextBoxSearchCurrentList.Text;
        }

        private async void m_ButtonSearchCollection_Click(object sender, EventArgs e)
        {
            m_LabelClearingList.Visible = true;
            m_ButtonDeleteFromMyCollection.Enabled = false;
            ControlFilterStates(false);
            Task task1 = Task.Run(() => ClearLists());
            await task1;
            m_LabelClearingList.Visible = false;
            m_ListViewAllCards.Items.Clear();
            m_LabelResultsCount.Text = "Results Count: 0";
            imageListCards.Images.Clear();

            DataManager dataManager = new DataManager();
            List<Card> cards = dataManager.SearchCardsInCollection(gSearchTextMyCollection, gCollectionFilePath);

            await Task.Run(() =>
            {
                int batchCount = 0;
                foreach (var card in cards)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        PopulateListView(card);
                        m_LabelResultsCount.Text = "Results Count: " + m_ListViewAllCards.Items.Count.ToString();
                    });

                    if (++batchCount % 10 == 0) // Adjust batch size as needed
                    {
                        System.Threading.Thread.Sleep(1); // Give UI thread time to update, but keep this very short
                    }
                }
            });
            ControlFilterStates(true);
        }

        private void m_ButtonInformation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello there! Thanks for using the WS Collector app! Here is some helpful information to get you started.\n\n" +
                "1. The Search Database for a Card lets you query the local database file for cards that match your text in the box. It searches against all card fields like Name, number, series, expansion, level and more.\n\n" +
                "2. The Search Database by Series must always have a selection in order to keep the application from loading 20,000+ cards and crashing :). This also provides a handy way to look at series specific card lists.\n\n" +
                "3. Once you Search by cards or series, you may select additional filters in the middle of the application and click on Apply filters to Database Series. This will narrow down the list provided by your search even more.\n\n" +
                "4. On the right of the app, you will see a My collection button. Once you have added cards to the collection by selecting a card checkbox and clicking on the Add to collection, they will show up there.\n\n" +
                "5. If you wish to filter your collection, click on My Collection, select a proper series under the Filter My Collection by Series dropdown, add any additonal filters or search values, and click Apply Filters to Colelction Series.\n\n" +
                "6. The clear list button on the bottom left will clear out all cards on the screen and let you start a new search.\n\n" +
                "NOTE: Your collection data is stored in a text file located on your machine at path C:\\Users\\userName\\MyCollectionFile.txt. \nPlease never delete this file unless you want to delete your entire collection!\n\n" +
                "", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
