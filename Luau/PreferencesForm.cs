using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Luau.Properties;

namespace Luau
{
    public partial class PreferencesForm : Form
    {
        private List<string> _fonts;
        private bool _manuallyClosing;

        public PreferencesForm()
        {
            InitializeComponent();
        }

        internal void LoadPreferences()
        {
            cbFont.SelectedIndex = _fonts.IndexOf(Settings.Default.EditorFont);
            nudFontSize.Value = Settings.Default.EditorFontSize;
            
            bcText.BackColor = Settings.Default.StyleLuaDefault;
            bcComment.BackColor = Settings.Default.StyleLuaComment;
            bcLineComment.BackColor = Settings.Default.StyleLuaCommentLine;
            bcNumber.BackColor = Settings.Default.StyleLuaNumber;
            bcOperator.BackColor = Settings.Default.StyleLuaOperator;
            bcWordKeyword.BackColor = Settings.Default.StyleLuaWord;
            bcWord2Keyword.BackColor = Settings.Default.StyleLuaWord2;
            bcWord3Keyword.BackColor = Settings.Default.StyleLuaWord3;
            bcString.BackColor = Settings.Default.StyleLuaString;
            bcCharacter.BackColor = Settings.Default.StyleLuaCharacter;
            bcStringLiteral.BackColor = Settings.Default.StyleLuaLiteralString;
            bcPreprocessor.BackColor = Settings.Default.StyleLuaPreprocessor;
            bcEditorbackground.BackColor = Settings.Default.StyleEditorBackground;
        }

        internal void SavePreferences()
        {
            Settings.Default.EditorFont = (string)cbFont.SelectedItem;
            Settings.Default.EditorFontSize = (int) nudFontSize.Value;
        }

        private void PreferencesForm_Load(object sender, EventArgs e)
        {
            _fonts = FontFamily.Families.Select(f => f.Name).ToList();
            cbFont.DataSource = _fonts;
            
            LoadPreferences();
        }

        private void PreferencesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_manuallyClosing)
                return;

            var result = MessageBox.Show(Resources.WarningPreferenceChanges, Resources.Warning, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            switch (result)
            {
                case DialogResult.Yes:
                    SaveAndClose();
                    break;
                case DialogResult.No:
                    _manuallyClosing = true;
                    Close();
                    break;
                default:
                    e.Cancel = true;
                    break;
            }
        }

        private void bcText_Click(object sender, EventArgs e)
        {
            colorPicker.Color = Settings.Default.StyleLuaDefault;
            if (colorPicker.ShowDialog() != DialogResult.OK) return;

            Settings.Default.StyleLuaDefault = colorPicker.Color;
            bcText.BackColor = Settings.Default.StyleLuaDefault;
        }

        private void bcComment_Click(object sender, EventArgs e)
        {
            colorPicker.Color = Settings.Default.StyleLuaComment;
            if (colorPicker.ShowDialog() != DialogResult.OK) return;

            Settings.Default.StyleLuaComment = colorPicker.Color;
            bcComment.BackColor = Settings.Default.StyleLuaComment;
        }

        private void bcLineComment_Click(object sender, EventArgs e)
        {
            colorPicker.Color = Settings.Default.StyleLuaCommentLine;
            if (colorPicker.ShowDialog() != DialogResult.OK) return;

            Settings.Default.StyleLuaCommentLine = colorPicker.Color;
            bcLineComment.BackColor = Settings.Default.StyleLuaCommentLine;
        }

        private void bcNumber_Click(object sender, EventArgs e)
        {
            colorPicker.Color = Settings.Default.StyleLuaNumber;
            if (colorPicker.ShowDialog() != DialogResult.OK) return;

            Settings.Default.StyleLuaNumber = colorPicker.Color;
            bcNumber.BackColor = Settings.Default.StyleLuaNumber;
        }

        private void bcOperator_Click(object sender, EventArgs e)
        {
            colorPicker.Color = Settings.Default.StyleLuaOperator;
            if (colorPicker.ShowDialog() != DialogResult.OK) return;

            Settings.Default.StyleLuaOperator = colorPicker.Color;
            bcOperator.BackColor = Settings.Default.StyleLuaOperator;
        }

        private void bcWordKeyword_Click(object sender, EventArgs e)
        {
            colorPicker.Color = Settings.Default.StyleLuaWord;
            if (colorPicker.ShowDialog() != DialogResult.OK) return;

            Settings.Default.StyleLuaWord = colorPicker.Color;
            bcWordKeyword.BackColor = Settings.Default.StyleLuaWord;
        }

        private void bcWord2Keyword_Click(object sender, EventArgs e)
        {
            colorPicker.Color = Settings.Default.StyleLuaWord2;
            if (colorPicker.ShowDialog() != DialogResult.OK) return;

            Settings.Default.StyleLuaWord2 = colorPicker.Color;
            bcWord2Keyword.BackColor = Settings.Default.StyleLuaWord2;
        }

        private void bcWord3Keyword_Click(object sender, EventArgs e)
        {
            colorPicker.Color = Settings.Default.StyleLuaWord3;
            if (colorPicker.ShowDialog() != DialogResult.OK) return;

            Settings.Default.StyleLuaWord3 = colorPicker.Color;
            bcWord3Keyword.BackColor = Settings.Default.StyleLuaWord3;
        }

        private void bcString_Click(object sender, EventArgs e)
        {
            colorPicker.Color = Settings.Default.StyleLuaString;
            if (colorPicker.ShowDialog() != DialogResult.OK) return;

            Settings.Default.StyleLuaString = colorPicker.Color;
            bcString.BackColor = Settings.Default.StyleLuaString;
        }

        private void bcCharacter_Click(object sender, EventArgs e)
        {
            colorPicker.Color = Settings.Default.StyleLuaCharacter;
            if (colorPicker.ShowDialog() != DialogResult.OK) return;

            Settings.Default.StyleLuaCharacter = colorPicker.Color;
            bcCharacter.BackColor = Settings.Default.StyleLuaCharacter;
        }

        private void bcStringLiteral_Click(object sender, EventArgs e)
        {
            colorPicker.Color = Settings.Default.StyleLuaLiteralString;
            if (colorPicker.ShowDialog() != DialogResult.OK) return;

            Settings.Default.StyleLuaLiteralString = colorPicker.Color;
            bcStringLiteral.BackColor = Settings.Default.StyleLuaLiteralString;
        }

        private void bcPreprocessor_Click(object sender, EventArgs e)
        {
            colorPicker.Color = Settings.Default.StyleLuaPreprocessor;
            if (colorPicker.ShowDialog() != DialogResult.OK) return;

            Settings.Default.StyleLuaPreprocessor = colorPicker.Color;
            bcPreprocessor.BackColor = Settings.Default.StyleLuaPreprocessor;
        }

        private void bcEditorbackground_Click(object sender, EventArgs e)
        {
            colorPicker.Color = Settings.Default.StyleEditorBackground;
            if (colorPicker.ShowDialog() != DialogResult.OK) return;

            Settings.Default.StyleEditorBackground = colorPicker.Color;
            bcEditorbackground.BackColor = Settings.Default.StyleEditorBackground;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            SaveAndClose();
        }

        private void SaveAndClose()
        {
            SavePreferences();
            Settings.Default.Save();
            _manuallyClosing = true;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            _manuallyClosing = true;
            Close();
        }
    }
}
