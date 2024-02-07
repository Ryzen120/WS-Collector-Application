
namespace WS_Collector
{
    partial class WSCollector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WSCollector));
            this.m_ListViewAllCards = new System.Windows.Forms.ListView();
            this.m_ButtonQuery = new System.Windows.Forms.Button();
            this.imageListCards = new System.Windows.Forms.ImageList(this.components);
            this.m_TextBoxSearch = new System.Windows.Forms.TextBox();
            this.m_LabelSearch = new System.Windows.Forms.Label();
            this.m_ButtonSearch = new System.Windows.Forms.Button();
            this.m_DropDownSeries = new System.Windows.Forms.ComboBox();
            this.m_LabelSeries = new System.Windows.Forms.Label();
            this.m_ButtonClearList = new System.Windows.Forms.Button();
            this.m_LabelResultsCount = new System.Windows.Forms.Label();
            this.m_ButtonAddToMyCollection = new System.Windows.Forms.Button();
            this.m_ButtonViewMyCollection = new System.Windows.Forms.Button();
            this.m_ButtonDeleteFromMyCollection = new System.Windows.Forms.Button();
            this.m_LabelClearingList = new System.Windows.Forms.Label();
            this.m_ButtonFilterResults = new System.Windows.Forms.Button();
            this.m_DropDownCardType = new System.Windows.Forms.ComboBox();
            this.m_LabelCardType = new System.Windows.Forms.Label();
            this.m_LabelPower = new System.Windows.Forms.Label();
            this.m_DropDownPower = new System.Windows.Forms.ComboBox();
            this.m_LabelLevel = new System.Windows.Forms.Label();
            this.m_DropDownLevel = new System.Windows.Forms.ComboBox();
            this.m_LabelSoul = new System.Windows.Forms.Label();
            this.m_DropDownSoul = new System.Windows.Forms.ComboBox();
            this.m_LabelRarity = new System.Windows.Forms.Label();
            this.m_DropDownRarity = new System.Windows.Forms.ComboBox();
            this.m_LabelFilterSeries = new System.Windows.Forms.Label();
            this.m_DropDownFilterBySeries = new System.Windows.Forms.ComboBox();
            this.m_SearchCurrrentList = new System.Windows.Forms.Label();
            this.m_TextBoxSearchCurrentList = new System.Windows.Forms.TextBox();
            this.m_LabelFilterByID = new System.Windows.Forms.Label();
            this.m_TextBoxFilterByCardID = new System.Windows.Forms.TextBox();
            this.m_LabelExpansion = new System.Windows.Forms.Label();
            this.m_DropDownExpansion = new System.Windows.Forms.ComboBox();
            this.m_DropDownTrigger = new System.Windows.Forms.ComboBox();
            this.m_LabelTrigger = new System.Windows.Forms.Label();
            this.m_ButtonApplyFiltersToCollection = new System.Windows.Forms.Button();
            this.m_ButtonResetFilters = new System.Windows.Forms.Button();
            this.m_ButtonSearchCollection = new System.Windows.Forms.Button();
            this.m_ButtonInformation = new System.Windows.Forms.Button();
            this.m_ButtonLoadMore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_ListViewAllCards
            // 
            this.m_ListViewAllCards.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.m_ListViewAllCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ListViewAllCards.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_ListViewAllCards.CheckBoxes = true;
            this.m_ListViewAllCards.HideSelection = false;
            this.m_ListViewAllCards.HotTracking = true;
            this.m_ListViewAllCards.HoverSelection = true;
            this.m_ListViewAllCards.Location = new System.Drawing.Point(12, 149);
            this.m_ListViewAllCards.Name = "m_ListViewAllCards";
            this.m_ListViewAllCards.Size = new System.Drawing.Size(1634, 621);
            this.m_ListViewAllCards.TabIndex = 0;
            this.m_ListViewAllCards.UseCompatibleStateImageBehavior = false;
            // 
            // m_ButtonQuery
            // 
            this.m_ButtonQuery.Location = new System.Drawing.Point(411, 41);
            this.m_ButtonQuery.Name = "m_ButtonQuery";
            this.m_ButtonQuery.Size = new System.Drawing.Size(92, 23);
            this.m_ButtonQuery.TabIndex = 1;
            this.m_ButtonQuery.Text = "Search Series";
            this.m_ButtonQuery.UseVisualStyleBackColor = true;
            this.m_ButtonQuery.Click += new System.EventHandler(this.m_ButtonQuery_Click);
            // 
            // imageListCards
            // 
            this.imageListCards.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListCards.ImageSize = new System.Drawing.Size(205, 256);
            this.imageListCards.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // m_TextBoxSearch
            // 
            this.m_TextBoxSearch.Location = new System.Drawing.Point(217, 8);
            this.m_TextBoxSearch.Name = "m_TextBoxSearch";
            this.m_TextBoxSearch.Size = new System.Drawing.Size(188, 20);
            this.m_TextBoxSearch.TabIndex = 2;
            this.m_TextBoxSearch.TextChanged += new System.EventHandler(this.m_TextBoxSearch_TextChanged);
            // 
            // m_LabelSearch
            // 
            this.m_LabelSearch.AutoSize = true;
            this.m_LabelSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelSearch.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelSearch.Location = new System.Drawing.Point(12, 9);
            this.m_LabelSearch.Name = "m_LabelSearch";
            this.m_LabelSearch.Size = new System.Drawing.Size(201, 16);
            this.m_LabelSearch.TabIndex = 3;
            this.m_LabelSearch.Text = "Search Database for a Card";
            // 
            // m_ButtonSearch
            // 
            this.m_ButtonSearch.Location = new System.Drawing.Point(411, 6);
            this.m_ButtonSearch.Name = "m_ButtonSearch";
            this.m_ButtonSearch.Size = new System.Drawing.Size(92, 23);
            this.m_ButtonSearch.TabIndex = 4;
            this.m_ButtonSearch.Text = "Search";
            this.m_ButtonSearch.UseVisualStyleBackColor = true;
            this.m_ButtonSearch.Click += new System.EventHandler(this.m_ButtonSearch_Click);
            // 
            // m_DropDownSeries
            // 
            this.m_DropDownSeries.FormattingEnabled = true;
            this.m_DropDownSeries.Location = new System.Drawing.Point(217, 43);
            this.m_DropDownSeries.Name = "m_DropDownSeries";
            this.m_DropDownSeries.Size = new System.Drawing.Size(188, 21);
            this.m_DropDownSeries.TabIndex = 6;
            this.m_DropDownSeries.SelectedIndexChanged += new System.EventHandler(this.m_DropDownSeries_SelectedIndexChanged);
            // 
            // m_LabelSeries
            // 
            this.m_LabelSeries.AutoSize = true;
            this.m_LabelSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelSeries.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelSeries.Location = new System.Drawing.Point(14, 43);
            this.m_LabelSeries.Name = "m_LabelSeries";
            this.m_LabelSeries.Size = new System.Drawing.Size(199, 16);
            this.m_LabelSeries.TabIndex = 7;
            this.m_LabelSeries.Text = "Search Database by Series";
            // 
            // m_ButtonClearList
            // 
            this.m_ButtonClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_ButtonClearList.Location = new System.Drawing.Point(12, 778);
            this.m_ButtonClearList.Name = "m_ButtonClearList";
            this.m_ButtonClearList.Size = new System.Drawing.Size(75, 23);
            this.m_ButtonClearList.TabIndex = 8;
            this.m_ButtonClearList.Text = "Clear List";
            this.m_ButtonClearList.UseVisualStyleBackColor = true;
            this.m_ButtonClearList.Click += new System.EventHandler(this.m_ButtonClearList_Click);
            // 
            // m_LabelResultsCount
            // 
            this.m_LabelResultsCount.AutoSize = true;
            this.m_LabelResultsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelResultsCount.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelResultsCount.Location = new System.Drawing.Point(12, 130);
            this.m_LabelResultsCount.Name = "m_LabelResultsCount";
            this.m_LabelResultsCount.Size = new System.Drawing.Size(101, 13);
            this.m_LabelResultsCount.TabIndex = 9;
            this.m_LabelResultsCount.Text = "Results Count: 0";
            // 
            // m_ButtonAddToMyCollection
            // 
            this.m_ButtonAddToMyCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ButtonAddToMyCollection.Location = new System.Drawing.Point(1251, 120);
            this.m_ButtonAddToMyCollection.Name = "m_ButtonAddToMyCollection";
            this.m_ButtonAddToMyCollection.Size = new System.Drawing.Size(130, 23);
            this.m_ButtonAddToMyCollection.TabIndex = 10;
            this.m_ButtonAddToMyCollection.Text = "Add to Collection";
            this.m_ButtonAddToMyCollection.UseVisualStyleBackColor = true;
            this.m_ButtonAddToMyCollection.Click += new System.EventHandler(this.m_ButtonAddToMyCollection_Click);
            // 
            // m_ButtonViewMyCollection
            // 
            this.m_ButtonViewMyCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ButtonViewMyCollection.Location = new System.Drawing.Point(1384, 120);
            this.m_ButtonViewMyCollection.Name = "m_ButtonViewMyCollection";
            this.m_ButtonViewMyCollection.Size = new System.Drawing.Size(130, 23);
            this.m_ButtonViewMyCollection.TabIndex = 11;
            this.m_ButtonViewMyCollection.Text = "My Collection";
            this.m_ButtonViewMyCollection.UseVisualStyleBackColor = true;
            this.m_ButtonViewMyCollection.Click += new System.EventHandler(this.m_ButtonViewMyCollection_Click);
            // 
            // m_ButtonDeleteFromMyCollection
            // 
            this.m_ButtonDeleteFromMyCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ButtonDeleteFromMyCollection.Location = new System.Drawing.Point(1516, 120);
            this.m_ButtonDeleteFromMyCollection.Name = "m_ButtonDeleteFromMyCollection";
            this.m_ButtonDeleteFromMyCollection.Size = new System.Drawing.Size(130, 23);
            this.m_ButtonDeleteFromMyCollection.TabIndex = 12;
            this.m_ButtonDeleteFromMyCollection.Text = "Delete from Collection";
            this.m_ButtonDeleteFromMyCollection.UseVisualStyleBackColor = true;
            this.m_ButtonDeleteFromMyCollection.Click += new System.EventHandler(this.m_ButtonDeleteFromMyCollection_Click);
            // 
            // m_LabelClearingList
            // 
            this.m_LabelClearingList.AutoSize = true;
            this.m_LabelClearingList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelClearingList.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelClearingList.Location = new System.Drawing.Point(214, 128);
            this.m_LabelClearingList.Name = "m_LabelClearingList";
            this.m_LabelClearingList.Size = new System.Drawing.Size(174, 15);
            this.m_LabelClearingList.TabIndex = 13;
            this.m_LabelClearingList.Text = "Clearing list... Please wait";
            this.m_LabelClearingList.Visible = false;
            // 
            // m_ButtonFilterResults
            // 
            this.m_ButtonFilterResults.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_ButtonFilterResults.Location = new System.Drawing.Point(588, 120);
            this.m_ButtonFilterResults.Name = "m_ButtonFilterResults";
            this.m_ButtonFilterResults.Size = new System.Drawing.Size(172, 23);
            this.m_ButtonFilterResults.TabIndex = 14;
            this.m_ButtonFilterResults.Text = "Apply Filters to Database Series";
            this.m_ButtonFilterResults.UseVisualStyleBackColor = true;
            this.m_ButtonFilterResults.Click += new System.EventHandler(this.m_ButtonFilterResults_Click);
            // 
            // m_DropDownCardType
            // 
            this.m_DropDownCardType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_DropDownCardType.FormattingEnabled = true;
            this.m_DropDownCardType.Location = new System.Drawing.Point(681, 37);
            this.m_DropDownCardType.Name = "m_DropDownCardType";
            this.m_DropDownCardType.Size = new System.Drawing.Size(121, 21);
            this.m_DropDownCardType.TabIndex = 15;
            this.m_DropDownCardType.SelectedIndexChanged += new System.EventHandler(this.m_DropDownCardType_SelectedIndexChanged);
            // 
            // m_LabelCardType
            // 
            this.m_LabelCardType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_LabelCardType.AutoSize = true;
            this.m_LabelCardType.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelCardType.Location = new System.Drawing.Point(619, 40);
            this.m_LabelCardType.Name = "m_LabelCardType";
            this.m_LabelCardType.Size = new System.Drawing.Size(56, 13);
            this.m_LabelCardType.TabIndex = 16;
            this.m_LabelCardType.Text = "Card Type";
            // 
            // m_LabelPower
            // 
            this.m_LabelPower.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_LabelPower.AutoSize = true;
            this.m_LabelPower.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelPower.Location = new System.Drawing.Point(935, 64);
            this.m_LabelPower.Name = "m_LabelPower";
            this.m_LabelPower.Size = new System.Drawing.Size(37, 13);
            this.m_LabelPower.TabIndex = 17;
            this.m_LabelPower.Text = "Power";
            // 
            // m_DropDownPower
            // 
            this.m_DropDownPower.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_DropDownPower.FormattingEnabled = true;
            this.m_DropDownPower.Location = new System.Drawing.Point(808, 61);
            this.m_DropDownPower.Name = "m_DropDownPower";
            this.m_DropDownPower.Size = new System.Drawing.Size(121, 21);
            this.m_DropDownPower.TabIndex = 18;
            this.m_DropDownPower.SelectedIndexChanged += new System.EventHandler(this.m_DropDownPower_SelectedIndexChanged);
            // 
            // m_LabelLevel
            // 
            this.m_LabelLevel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_LabelLevel.AutoSize = true;
            this.m_LabelLevel.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelLevel.Location = new System.Drawing.Point(935, 16);
            this.m_LabelLevel.Name = "m_LabelLevel";
            this.m_LabelLevel.Size = new System.Drawing.Size(33, 13);
            this.m_LabelLevel.TabIndex = 19;
            this.m_LabelLevel.Text = "Level";
            // 
            // m_DropDownLevel
            // 
            this.m_DropDownLevel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_DropDownLevel.FormattingEnabled = true;
            this.m_DropDownLevel.Location = new System.Drawing.Point(808, 13);
            this.m_DropDownLevel.Name = "m_DropDownLevel";
            this.m_DropDownLevel.Size = new System.Drawing.Size(121, 21);
            this.m_DropDownLevel.TabIndex = 20;
            this.m_DropDownLevel.SelectedIndexChanged += new System.EventHandler(this.m_DropDownLevel_SelectedIndexChanged);
            // 
            // m_LabelSoul
            // 
            this.m_LabelSoul.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_LabelSoul.AutoSize = true;
            this.m_LabelSoul.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelSoul.Location = new System.Drawing.Point(935, 41);
            this.m_LabelSoul.Name = "m_LabelSoul";
            this.m_LabelSoul.Size = new System.Drawing.Size(28, 13);
            this.m_LabelSoul.TabIndex = 21;
            this.m_LabelSoul.Text = "Soul";
            // 
            // m_DropDownSoul
            // 
            this.m_DropDownSoul.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_DropDownSoul.FormattingEnabled = true;
            this.m_DropDownSoul.Location = new System.Drawing.Point(808, 37);
            this.m_DropDownSoul.Name = "m_DropDownSoul";
            this.m_DropDownSoul.Size = new System.Drawing.Size(121, 21);
            this.m_DropDownSoul.TabIndex = 22;
            this.m_DropDownSoul.SelectedIndexChanged += new System.EventHandler(this.m_DropDownSoul_SelectedIndexChanged);
            // 
            // m_LabelRarity
            // 
            this.m_LabelRarity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_LabelRarity.AutoSize = true;
            this.m_LabelRarity.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelRarity.Location = new System.Drawing.Point(641, 64);
            this.m_LabelRarity.Name = "m_LabelRarity";
            this.m_LabelRarity.Size = new System.Drawing.Size(34, 13);
            this.m_LabelRarity.TabIndex = 23;
            this.m_LabelRarity.Text = "Rarity";
            // 
            // m_DropDownRarity
            // 
            this.m_DropDownRarity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_DropDownRarity.FormattingEnabled = true;
            this.m_DropDownRarity.Location = new System.Drawing.Point(681, 61);
            this.m_DropDownRarity.Name = "m_DropDownRarity";
            this.m_DropDownRarity.Size = new System.Drawing.Size(121, 21);
            this.m_DropDownRarity.TabIndex = 24;
            this.m_DropDownRarity.SelectedIndexChanged += new System.EventHandler(this.m_DropDownRarity_SelectedIndexChanged);
            // 
            // m_LabelFilterSeries
            // 
            this.m_LabelFilterSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_LabelFilterSeries.AutoSize = true;
            this.m_LabelFilterSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_LabelFilterSeries.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelFilterSeries.Location = new System.Drawing.Point(1131, 47);
            this.m_LabelFilterSeries.Name = "m_LabelFilterSeries";
            this.m_LabelFilterSeries.Size = new System.Drawing.Size(210, 16);
            this.m_LabelFilterSeries.TabIndex = 25;
            this.m_LabelFilterSeries.Text = "Filter My Collection by Series";
            // 
            // m_DropDownFilterBySeries
            // 
            this.m_DropDownFilterBySeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_DropDownFilterBySeries.FormattingEnabled = true;
            this.m_DropDownFilterBySeries.Location = new System.Drawing.Point(1347, 42);
            this.m_DropDownFilterBySeries.Name = "m_DropDownFilterBySeries";
            this.m_DropDownFilterBySeries.Size = new System.Drawing.Size(188, 21);
            this.m_DropDownFilterBySeries.TabIndex = 26;
            this.m_DropDownFilterBySeries.SelectedIndexChanged += new System.EventHandler(this.m_DropDownFilterBySeries_SelectedIndexChanged);
            // 
            // m_SearchCurrrentList
            // 
            this.m_SearchCurrrentList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_SearchCurrrentList.AutoSize = true;
            this.m_SearchCurrrentList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_SearchCurrrentList.ForeColor = System.Drawing.Color.Snow;
            this.m_SearchCurrrentList.Location = new System.Drawing.Point(1174, 15);
            this.m_SearchCurrrentList.Name = "m_SearchCurrrentList";
            this.m_SearchCurrrentList.Size = new System.Drawing.Size(167, 16);
            this.m_SearchCurrrentList.TabIndex = 27;
            this.m_SearchCurrrentList.Text = "Search Card Collection";
            // 
            // m_TextBoxSearchCurrentList
            // 
            this.m_TextBoxSearchCurrentList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_TextBoxSearchCurrentList.Location = new System.Drawing.Point(1347, 14);
            this.m_TextBoxSearchCurrentList.Name = "m_TextBoxSearchCurrentList";
            this.m_TextBoxSearchCurrentList.Size = new System.Drawing.Size(188, 20);
            this.m_TextBoxSearchCurrentList.TabIndex = 28;
            this.m_TextBoxSearchCurrentList.TextChanged += new System.EventHandler(this.m_TextBoxSearchCurrentList_TextChanged);
            // 
            // m_LabelFilterByID
            // 
            this.m_LabelFilterByID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_LabelFilterByID.AutoSize = true;
            this.m_LabelFilterByID.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelFilterByID.Location = new System.Drawing.Point(632, 17);
            this.m_LabelFilterByID.Name = "m_LabelFilterByID";
            this.m_LabelFilterByID.Size = new System.Drawing.Size(43, 13);
            this.m_LabelFilterByID.TabIndex = 29;
            this.m_LabelFilterByID.Text = "Card ID";
            // 
            // m_TextBoxFilterByCardID
            // 
            this.m_TextBoxFilterByCardID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_TextBoxFilterByCardID.Location = new System.Drawing.Point(681, 14);
            this.m_TextBoxFilterByCardID.Name = "m_TextBoxFilterByCardID";
            this.m_TextBoxFilterByCardID.Size = new System.Drawing.Size(121, 20);
            this.m_TextBoxFilterByCardID.TabIndex = 30;
            this.m_TextBoxFilterByCardID.TextChanged += new System.EventHandler(this.m_TextBoxFilterByCardID_TextChanged);
            // 
            // m_LabelExpansion
            // 
            this.m_LabelExpansion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_LabelExpansion.AutoSize = true;
            this.m_LabelExpansion.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelExpansion.Location = new System.Drawing.Point(619, 88);
            this.m_LabelExpansion.Name = "m_LabelExpansion";
            this.m_LabelExpansion.Size = new System.Drawing.Size(56, 13);
            this.m_LabelExpansion.TabIndex = 31;
            this.m_LabelExpansion.Text = "Expansion";
            // 
            // m_DropDownExpansion
            // 
            this.m_DropDownExpansion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_DropDownExpansion.FormattingEnabled = true;
            this.m_DropDownExpansion.Location = new System.Drawing.Point(681, 85);
            this.m_DropDownExpansion.Name = "m_DropDownExpansion";
            this.m_DropDownExpansion.Size = new System.Drawing.Size(121, 21);
            this.m_DropDownExpansion.TabIndex = 32;
            this.m_DropDownExpansion.SelectedIndexChanged += new System.EventHandler(this.m_DropDownExpansion_SelectedIndexChanged);
            // 
            // m_DropDownTrigger
            // 
            this.m_DropDownTrigger.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_DropDownTrigger.FormattingEnabled = true;
            this.m_DropDownTrigger.Location = new System.Drawing.Point(808, 85);
            this.m_DropDownTrigger.Name = "m_DropDownTrigger";
            this.m_DropDownTrigger.Size = new System.Drawing.Size(121, 21);
            this.m_DropDownTrigger.TabIndex = 33;
            this.m_DropDownTrigger.SelectedIndexChanged += new System.EventHandler(this.m_DropDownTrigger_SelectedIndexChanged);
            // 
            // m_LabelTrigger
            // 
            this.m_LabelTrigger.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_LabelTrigger.AutoSize = true;
            this.m_LabelTrigger.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelTrigger.Location = new System.Drawing.Point(935, 88);
            this.m_LabelTrigger.Name = "m_LabelTrigger";
            this.m_LabelTrigger.Size = new System.Drawing.Size(40, 13);
            this.m_LabelTrigger.TabIndex = 34;
            this.m_LabelTrigger.Text = "Trigger";
            // 
            // m_ButtonApplyFiltersToCollection
            // 
            this.m_ButtonApplyFiltersToCollection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_ButtonApplyFiltersToCollection.Location = new System.Drawing.Point(847, 120);
            this.m_ButtonApplyFiltersToCollection.Name = "m_ButtonApplyFiltersToCollection";
            this.m_ButtonApplyFiltersToCollection.Size = new System.Drawing.Size(172, 23);
            this.m_ButtonApplyFiltersToCollection.TabIndex = 35;
            this.m_ButtonApplyFiltersToCollection.Text = "Apply Filters to Collection Series";
            this.m_ButtonApplyFiltersToCollection.UseVisualStyleBackColor = true;
            this.m_ButtonApplyFiltersToCollection.Click += new System.EventHandler(this.m_ButtonApplyFiltersToCollection_Click);
            // 
            // m_ButtonResetFilters
            // 
            this.m_ButtonResetFilters.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_ButtonResetFilters.Location = new System.Drawing.Point(766, 120);
            this.m_ButtonResetFilters.Name = "m_ButtonResetFilters";
            this.m_ButtonResetFilters.Size = new System.Drawing.Size(75, 23);
            this.m_ButtonResetFilters.TabIndex = 36;
            this.m_ButtonResetFilters.Text = "Reset Filters";
            this.m_ButtonResetFilters.UseVisualStyleBackColor = true;
            this.m_ButtonResetFilters.Click += new System.EventHandler(this.m_ButtonResetFilters_Click);
            // 
            // m_ButtonSearchCollection
            // 
            this.m_ButtonSearchCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ButtonSearchCollection.Location = new System.Drawing.Point(1541, 12);
            this.m_ButtonSearchCollection.Name = "m_ButtonSearchCollection";
            this.m_ButtonSearchCollection.Size = new System.Drawing.Size(105, 23);
            this.m_ButtonSearchCollection.TabIndex = 37;
            this.m_ButtonSearchCollection.Text = "Search Collection";
            this.m_ButtonSearchCollection.UseVisualStyleBackColor = true;
            this.m_ButtonSearchCollection.Click += new System.EventHandler(this.m_ButtonSearchCollection_Click);
            // 
            // m_ButtonInformation
            // 
            this.m_ButtonInformation.Location = new System.Drawing.Point(93, 778);
            this.m_ButtonInformation.Name = "m_ButtonInformation";
            this.m_ButtonInformation.Size = new System.Drawing.Size(75, 23);
            this.m_ButtonInformation.TabIndex = 38;
            this.m_ButtonInformation.Text = "Information";
            this.m_ButtonInformation.UseVisualStyleBackColor = true;
            this.m_ButtonInformation.Click += new System.EventHandler(this.m_ButtonInformation_Click);
            // 
            // m_ButtonLoadMore
            // 
            this.m_ButtonLoadMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ButtonLoadMore.Enabled = false;
            this.m_ButtonLoadMore.Location = new System.Drawing.Point(1541, 778);
            this.m_ButtonLoadMore.Name = "m_ButtonLoadMore";
            this.m_ButtonLoadMore.Size = new System.Drawing.Size(105, 23);
            this.m_ButtonLoadMore.TabIndex = 5;
            this.m_ButtonLoadMore.Text = "Beta - Load More";
            this.m_ButtonLoadMore.UseVisualStyleBackColor = true;
            this.m_ButtonLoadMore.Click += new System.EventHandler(this.m_ButtonLoadMore_Click);
            // 
            // WSCollector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1658, 813);
            this.Controls.Add(this.m_ButtonInformation);
            this.Controls.Add(this.m_ButtonSearchCollection);
            this.Controls.Add(this.m_ButtonResetFilters);
            this.Controls.Add(this.m_ButtonApplyFiltersToCollection);
            this.Controls.Add(this.m_LabelTrigger);
            this.Controls.Add(this.m_DropDownTrigger);
            this.Controls.Add(this.m_DropDownExpansion);
            this.Controls.Add(this.m_LabelExpansion);
            this.Controls.Add(this.m_TextBoxFilterByCardID);
            this.Controls.Add(this.m_LabelFilterByID);
            this.Controls.Add(this.m_TextBoxSearchCurrentList);
            this.Controls.Add(this.m_SearchCurrrentList);
            this.Controls.Add(this.m_DropDownFilterBySeries);
            this.Controls.Add(this.m_LabelFilterSeries);
            this.Controls.Add(this.m_DropDownRarity);
            this.Controls.Add(this.m_LabelRarity);
            this.Controls.Add(this.m_DropDownSoul);
            this.Controls.Add(this.m_LabelSoul);
            this.Controls.Add(this.m_DropDownLevel);
            this.Controls.Add(this.m_LabelLevel);
            this.Controls.Add(this.m_DropDownPower);
            this.Controls.Add(this.m_LabelPower);
            this.Controls.Add(this.m_LabelCardType);
            this.Controls.Add(this.m_DropDownCardType);
            this.Controls.Add(this.m_ButtonFilterResults);
            this.Controls.Add(this.m_LabelClearingList);
            this.Controls.Add(this.m_ButtonDeleteFromMyCollection);
            this.Controls.Add(this.m_ButtonViewMyCollection);
            this.Controls.Add(this.m_ButtonAddToMyCollection);
            this.Controls.Add(this.m_LabelResultsCount);
            this.Controls.Add(this.m_ButtonClearList);
            this.Controls.Add(this.m_LabelSeries);
            this.Controls.Add(this.m_DropDownSeries);
            this.Controls.Add(this.m_ButtonLoadMore);
            this.Controls.Add(this.m_ButtonSearch);
            this.Controls.Add(this.m_LabelSearch);
            this.Controls.Add(this.m_TextBoxSearch);
            this.Controls.Add(this.m_ButtonQuery);
            this.Controls.Add(this.m_ListViewAllCards);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1674, 852);
            this.Name = "WSCollector";
            this.Text = " WS Collector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView m_ListViewAllCards;
        private System.Windows.Forms.Button m_ButtonQuery;
        private System.Windows.Forms.ImageList imageListCards;
        private System.Windows.Forms.TextBox m_TextBoxSearch;
        private System.Windows.Forms.Label m_LabelSearch;
        private System.Windows.Forms.Button m_ButtonSearch;
        private System.Windows.Forms.ComboBox m_DropDownSeries;
        private System.Windows.Forms.Label m_LabelSeries;
        private System.Windows.Forms.Button m_ButtonClearList;
        private System.Windows.Forms.Label m_LabelResultsCount;
        private System.Windows.Forms.Button m_ButtonAddToMyCollection;
        private System.Windows.Forms.Button m_ButtonViewMyCollection;
        private System.Windows.Forms.Button m_ButtonDeleteFromMyCollection;
        private System.Windows.Forms.Label m_LabelClearingList;
        private System.Windows.Forms.Button m_ButtonFilterResults;
        private System.Windows.Forms.ComboBox m_DropDownCardType;
        private System.Windows.Forms.Label m_LabelCardType;
        private System.Windows.Forms.Label m_LabelPower;
        private System.Windows.Forms.ComboBox m_DropDownPower;
        private System.Windows.Forms.Label m_LabelLevel;
        private System.Windows.Forms.ComboBox m_DropDownLevel;
        private System.Windows.Forms.Label m_LabelSoul;
        private System.Windows.Forms.ComboBox m_DropDownSoul;
        private System.Windows.Forms.Label m_LabelRarity;
        private System.Windows.Forms.ComboBox m_DropDownRarity;
        private System.Windows.Forms.Label m_LabelFilterSeries;
        private System.Windows.Forms.ComboBox m_DropDownFilterBySeries;
        private System.Windows.Forms.Label m_SearchCurrrentList;
        private System.Windows.Forms.TextBox m_TextBoxSearchCurrentList;
        private System.Windows.Forms.Label m_LabelFilterByID;
        private System.Windows.Forms.TextBox m_TextBoxFilterByCardID;
        private System.Windows.Forms.Label m_LabelExpansion;
        private System.Windows.Forms.ComboBox m_DropDownExpansion;
        private System.Windows.Forms.ComboBox m_DropDownTrigger;
        private System.Windows.Forms.Label m_LabelTrigger;
        private System.Windows.Forms.Button m_ButtonApplyFiltersToCollection;
        private System.Windows.Forms.Button m_ButtonResetFilters;
        private System.Windows.Forms.Button m_ButtonSearchCollection;
        private System.Windows.Forms.Button m_ButtonInformation;
        private System.Windows.Forms.Button m_ButtonLoadMore;
    }
}

