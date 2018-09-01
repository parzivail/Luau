namespace Luau
{
    partial class PreferencesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
            this.tabFonts = new System.Windows.Forms.TabPage();
            this.gColors = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.bcEditorbackground = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.bcPreprocessor = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.bcStringLiteral = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.bcCharacter = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.bcString = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.bcWord3Keyword = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.bcWord2Keyword = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.bcWordKeyword = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.bcOperator = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.bcNumber = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.bcLineComment = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bcComment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bcText = new System.Windows.Forms.Button();
            this.lNotice = new System.Windows.Forms.Label();
            this.gFonts = new System.Windows.Forms.GroupBox();
            this.nudFontSize = new System.Windows.Forms.NumericUpDown();
            this.lEditorFontSize = new System.Windows.Forms.Label();
            this.lEditorFont = new System.Windows.Forms.Label();
            this.cbFont = new System.Windows.Forms.ComboBox();
            this.tabsSettings = new System.Windows.Forms.TabControl();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.tabFonts.SuspendLayout();
            this.gColors.SuspendLayout();
            this.gFonts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).BeginInit();
            this.tabsSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabFonts
            // 
            this.tabFonts.Controls.Add(this.gColors);
            this.tabFonts.Controls.Add(this.lNotice);
            this.tabFonts.Controls.Add(this.gFonts);
            this.tabFonts.Location = new System.Drawing.Point(4, 22);
            this.tabFonts.Name = "tabFonts";
            this.tabFonts.Padding = new System.Windows.Forms.Padding(3);
            this.tabFonts.Size = new System.Drawing.Size(476, 335);
            this.tabFonts.TabIndex = 0;
            this.tabFonts.Text = "Fonts and Colors";
            this.tabFonts.UseVisualStyleBackColor = true;
            // 
            // gColors
            // 
            this.gColors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gColors.Controls.Add(this.label13);
            this.gColors.Controls.Add(this.bcEditorbackground);
            this.gColors.Controls.Add(this.label12);
            this.gColors.Controls.Add(this.bcPreprocessor);
            this.gColors.Controls.Add(this.label11);
            this.gColors.Controls.Add(this.bcStringLiteral);
            this.gColors.Controls.Add(this.label10);
            this.gColors.Controls.Add(this.bcCharacter);
            this.gColors.Controls.Add(this.label9);
            this.gColors.Controls.Add(this.bcString);
            this.gColors.Controls.Add(this.label8);
            this.gColors.Controls.Add(this.bcWord3Keyword);
            this.gColors.Controls.Add(this.label7);
            this.gColors.Controls.Add(this.bcWord2Keyword);
            this.gColors.Controls.Add(this.label6);
            this.gColors.Controls.Add(this.bcWordKeyword);
            this.gColors.Controls.Add(this.label5);
            this.gColors.Controls.Add(this.bcOperator);
            this.gColors.Controls.Add(this.label4);
            this.gColors.Controls.Add(this.bcNumber);
            this.gColors.Controls.Add(this.label3);
            this.gColors.Controls.Add(this.bcLineComment);
            this.gColors.Controls.Add(this.label2);
            this.gColors.Controls.Add(this.bcComment);
            this.gColors.Controls.Add(this.label1);
            this.gColors.Controls.Add(this.bcText);
            this.gColors.Location = new System.Drawing.Point(8, 93);
            this.gColors.Name = "gColors";
            this.gColors.Size = new System.Drawing.Size(460, 221);
            this.gColors.TabIndex = 2;
            this.gColors.TabStop = false;
            this.gColors.Text = "Colors";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(193, 153);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Editor Background";
            // 
            // bcEditorbackground
            // 
            this.bcEditorbackground.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bcEditorbackground.Location = new System.Drawing.Point(314, 149);
            this.bcEditorbackground.Name = "bcEditorbackground";
            this.bcEditorbackground.Size = new System.Drawing.Size(20, 20);
            this.bcEditorbackground.TabIndex = 24;
            this.bcEditorbackground.UseVisualStyleBackColor = true;
            this.bcEditorbackground.Click += new System.EventHandler(this.bcEditorbackground_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(193, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Preprocessor";
            // 
            // bcPreprocessor
            // 
            this.bcPreprocessor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bcPreprocessor.Location = new System.Drawing.Point(314, 123);
            this.bcPreprocessor.Name = "bcPreprocessor";
            this.bcPreprocessor.Size = new System.Drawing.Size(20, 20);
            this.bcPreprocessor.TabIndex = 22;
            this.bcPreprocessor.UseVisualStyleBackColor = true;
            this.bcPreprocessor.Click += new System.EventHandler(this.bcPreprocessor_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(193, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "String Literal";
            // 
            // bcStringLiteral
            // 
            this.bcStringLiteral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bcStringLiteral.Location = new System.Drawing.Point(314, 97);
            this.bcStringLiteral.Name = "bcStringLiteral";
            this.bcStringLiteral.Size = new System.Drawing.Size(20, 20);
            this.bcStringLiteral.TabIndex = 20;
            this.bcStringLiteral.UseVisualStyleBackColor = true;
            this.bcStringLiteral.Click += new System.EventHandler(this.bcStringLiteral_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(193, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Character";
            // 
            // bcCharacter
            // 
            this.bcCharacter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bcCharacter.Location = new System.Drawing.Point(314, 71);
            this.bcCharacter.Name = "bcCharacter";
            this.bcCharacter.Size = new System.Drawing.Size(20, 20);
            this.bcCharacter.TabIndex = 18;
            this.bcCharacter.UseVisualStyleBackColor = true;
            this.bcCharacter.Click += new System.EventHandler(this.bcCharacter_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(193, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "String";
            // 
            // bcString
            // 
            this.bcString.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bcString.Location = new System.Drawing.Point(314, 45);
            this.bcString.Name = "bcString";
            this.bcString.Size = new System.Drawing.Size(20, 20);
            this.bcString.TabIndex = 16;
            this.bcString.UseVisualStyleBackColor = true;
            this.bcString.Click += new System.EventHandler(this.bcString_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(193, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "String/Math Keyword";
            // 
            // bcWord3Keyword
            // 
            this.bcWord3Keyword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bcWord3Keyword.Location = new System.Drawing.Point(314, 19);
            this.bcWord3Keyword.Name = "bcWord3Keyword";
            this.bcWord3Keyword.Size = new System.Drawing.Size(20, 20);
            this.bcWord3Keyword.TabIndex = 14;
            this.bcWord3Keyword.UseVisualStyleBackColor = true;
            this.bcWord3Keyword.Click += new System.EventHandler(this.bcWord3Keyword_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Common Fn. Keyword";
            // 
            // bcWord2Keyword
            // 
            this.bcWord2Keyword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bcWord2Keyword.Location = new System.Drawing.Point(127, 175);
            this.bcWord2Keyword.Name = "bcWord2Keyword";
            this.bcWord2Keyword.Size = new System.Drawing.Size(20, 20);
            this.bcWord2Keyword.TabIndex = 12;
            this.bcWord2Keyword.UseVisualStyleBackColor = true;
            this.bcWord2Keyword.Click += new System.EventHandler(this.bcWord2Keyword_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Lua Keword";
            // 
            // bcWordKeyword
            // 
            this.bcWordKeyword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bcWordKeyword.Location = new System.Drawing.Point(127, 149);
            this.bcWordKeyword.Name = "bcWordKeyword";
            this.bcWordKeyword.Size = new System.Drawing.Size(20, 20);
            this.bcWordKeyword.TabIndex = 10;
            this.bcWordKeyword.UseVisualStyleBackColor = true;
            this.bcWordKeyword.Click += new System.EventHandler(this.bcWordKeyword_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Operator";
            // 
            // bcOperator
            // 
            this.bcOperator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bcOperator.Location = new System.Drawing.Point(127, 123);
            this.bcOperator.Name = "bcOperator";
            this.bcOperator.Size = new System.Drawing.Size(20, 20);
            this.bcOperator.TabIndex = 8;
            this.bcOperator.UseVisualStyleBackColor = true;
            this.bcOperator.Click += new System.EventHandler(this.bcOperator_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Number";
            // 
            // bcNumber
            // 
            this.bcNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bcNumber.Location = new System.Drawing.Point(127, 97);
            this.bcNumber.Name = "bcNumber";
            this.bcNumber.Size = new System.Drawing.Size(20, 20);
            this.bcNumber.TabIndex = 6;
            this.bcNumber.UseVisualStyleBackColor = true;
            this.bcNumber.Click += new System.EventHandler(this.bcNumber_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Line Comment";
            // 
            // bcLineComment
            // 
            this.bcLineComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bcLineComment.Location = new System.Drawing.Point(127, 71);
            this.bcLineComment.Name = "bcLineComment";
            this.bcLineComment.Size = new System.Drawing.Size(20, 20);
            this.bcLineComment.TabIndex = 4;
            this.bcLineComment.UseVisualStyleBackColor = true;
            this.bcLineComment.Click += new System.EventHandler(this.bcLineComment_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Comment";
            // 
            // bcComment
            // 
            this.bcComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bcComment.Location = new System.Drawing.Point(127, 45);
            this.bcComment.Name = "bcComment";
            this.bcComment.Size = new System.Drawing.Size(20, 20);
            this.bcComment.TabIndex = 2;
            this.bcComment.UseVisualStyleBackColor = true;
            this.bcComment.Click += new System.EventHandler(this.bcComment_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text";
            // 
            // bcText
            // 
            this.bcText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bcText.Location = new System.Drawing.Point(127, 19);
            this.bcText.Name = "bcText";
            this.bcText.Size = new System.Drawing.Size(20, 20);
            this.bcText.TabIndex = 0;
            this.bcText.UseVisualStyleBackColor = true;
            this.bcText.Click += new System.EventHandler(this.bcText_Click);
            // 
            // lNotice
            // 
            this.lNotice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lNotice.AutoSize = true;
            this.lNotice.Location = new System.Drawing.Point(3, 317);
            this.lNotice.Name = "lNotice";
            this.lNotice.Size = new System.Drawing.Size(372, 13);
            this.lNotice.TabIndex = 1;
            this.lNotice.Text = "Note: Changed settings will automatically be saved when this dialog is closed.";
            // 
            // gFonts
            // 
            this.gFonts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gFonts.Controls.Add(this.nudFontSize);
            this.gFonts.Controls.Add(this.lEditorFontSize);
            this.gFonts.Controls.Add(this.lEditorFont);
            this.gFonts.Controls.Add(this.cbFont);
            this.gFonts.Location = new System.Drawing.Point(8, 6);
            this.gFonts.Name = "gFonts";
            this.gFonts.Size = new System.Drawing.Size(460, 81);
            this.gFonts.TabIndex = 0;
            this.gFonts.TabStop = false;
            this.gFonts.Text = "Fonts";
            // 
            // nudFontSize
            // 
            this.nudFontSize.Location = new System.Drawing.Point(127, 46);
            this.nudFontSize.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFontSize.Name = "nudFontSize";
            this.nudFontSize.Size = new System.Drawing.Size(121, 20);
            this.nudFontSize.TabIndex = 1;
            this.nudFontSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lEditorFontSize
            // 
            this.lEditorFontSize.AutoSize = true;
            this.lEditorFontSize.Location = new System.Drawing.Point(6, 48);
            this.lEditorFontSize.Name = "lEditorFontSize";
            this.lEditorFontSize.Size = new System.Drawing.Size(81, 13);
            this.lEditorFontSize.TabIndex = 2;
            this.lEditorFontSize.Text = "Editor Font Size";
            // 
            // lEditorFont
            // 
            this.lEditorFont.AutoSize = true;
            this.lEditorFont.Location = new System.Drawing.Point(6, 22);
            this.lEditorFont.Name = "lEditorFont";
            this.lEditorFont.Size = new System.Drawing.Size(58, 13);
            this.lEditorFont.TabIndex = 1;
            this.lEditorFont.Text = "Editor Font";
            // 
            // cbFont
            // 
            this.cbFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFont.FormattingEnabled = true;
            this.cbFont.Location = new System.Drawing.Point(127, 19);
            this.cbFont.Name = "cbFont";
            this.cbFont.Size = new System.Drawing.Size(121, 21);
            this.cbFont.TabIndex = 0;
            // 
            // tabsSettings
            // 
            this.tabsSettings.Controls.Add(this.tabFonts);
            this.tabsSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsSettings.Location = new System.Drawing.Point(0, 0);
            this.tabsSettings.Name = "tabsSettings";
            this.tabsSettings.SelectedIndex = 0;
            this.tabsSettings.Size = new System.Drawing.Size(484, 361);
            this.tabsSettings.TabIndex = 0;
            // 
            // colorPicker
            // 
            this.colorPicker.AnyColor = true;
            this.colorPicker.FullOpen = true;
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.tabsSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesForm";
            this.Text = "Preferences";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreferencesForm_FormClosing);
            this.Load += new System.EventHandler(this.PreferencesForm_Load);
            this.tabFonts.ResumeLayout(false);
            this.tabFonts.PerformLayout();
            this.gColors.ResumeLayout(false);
            this.gColors.PerformLayout();
            this.gFonts.ResumeLayout(false);
            this.gFonts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontSize)).EndInit();
            this.tabsSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabFonts;
        private System.Windows.Forms.TabControl tabsSettings;
        private System.Windows.Forms.GroupBox gFonts;
        private System.Windows.Forms.ComboBox cbFont;
        private System.Windows.Forms.NumericUpDown nudFontSize;
        private System.Windows.Forms.Label lEditorFontSize;
        private System.Windows.Forms.Label lEditorFont;
        private System.Windows.Forms.Label lNotice;
        private System.Windows.Forms.GroupBox gColors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bcText;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button bcEditorbackground;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button bcPreprocessor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button bcStringLiteral;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button bcCharacter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button bcString;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bcWord3Keyword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bcWord2Keyword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bcWordKeyword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bcOperator;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bcNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bcLineComment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bcComment;
        private System.Windows.Forms.ColorDialog colorPicker;
    }
}