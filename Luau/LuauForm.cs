using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Luau.Properties;
using Microsoft.Win32;
using MoonSharp.Interpreter;
using ScintillaNET;
using ScintillaNET_FindReplaceDialog;

namespace Luau
{
    public partial class LuauForm : Form
    {
        private LuaInterpreter _interpreter;
        private Stopwatch _stopwatch;
        private FindReplace _findReplace;
        private string _savedFileName;
        private bool _isAtSavePoint = true;
        private SimulatorForm _simForm;

        public static LuauForm Instance { get; private set; }

        public LuauForm()
        {
            InitializeComponent();
        }

        private void LuauForm_Load(object sender, EventArgs e)
        {
            Instance = this;
            CreateUntitledFile();

            _interpreter = new LuaInterpreter();
            _interpreter.Print += InterpreterOnPrint;
            _interpreter.ExecutionStart += InterpreterOnExecutionStart;
            _interpreter.ExecutionComplete += InterpreterOnExecutionComplete;
            _interpreter.LuaError += InterpreterOnLuaError;
            _interpreter.CsError += InterpreterOnCsError;

            _stopwatch = new Stopwatch();

            ReloadStyles();

            scintilla.SavePointLeft += TextArea_SavePointLeft;
            scintilla.SavePointReached += TextArea_SavePointReached;

            _findReplace = new FindReplace(scintilla);
        }

        private void LuauForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!TryCloseFile())
                e.Cancel = true;

            _simForm?.Stop();

            // Awful hack to make sure the copied text persists when the window closes
            if (Clipboard.ContainsText())
                Clipboard.SetDataObject(Clipboard.GetText(), true);
        }

        private void LoadLogStyles()
        {
            log.BackColor = Settings.Default.StyleEditorBackground;
            log.ForeColor = Settings.Default.StyleLuaDefault;
            log.Font = new Font(scintilla.Styles[Style.Default].Font, scintilla.Styles[Style.Default].Size);

            logErr.BackColor = Settings.Default.StyleEditorBackground;
            logErr.ForeColor = Settings.Default.StyleLuaDefault;
            logErr.Font = new Font(scintilla.Styles[Style.Default].Font, scintilla.Styles[Style.Default].Size);
        }

        private void LoadEditorStyles()
        {
            const string alphaChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numericChars = "0123456789";
            const string accentedChars = "ŠšŒœŸÿÀàÁáÂâÃãÄäÅåÆæÇçÈèÉéÊêËëÌìÍíÎîÏïÐðÑñÒòÓóÔôÕõÖØøÙùÚúÛûÜüÝýÞþßö";

            // Configuring the default style with properties
            // we have common to every lexer style saves time.
            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Default].Font = Settings.Default.EditorFont;
            scintilla.Styles[Style.Default].Size = Settings.Default.EditorFontSize;
            scintilla.Styles[Style.Default].BackColor = Settings.Default.StyleEditorBackground;
            scintilla.StyleClearAll();

            // Configure the Lua lexer styles
            scintilla.Styles[Style.Lua.Default].ForeColor = Settings.Default.StyleLuaDefault;

            scintilla.Styles[Style.Lua.Comment].ForeColor = Settings.Default.StyleLuaComment;
            scintilla.Styles[Style.Lua.CommentLine].ForeColor = Settings.Default.StyleLuaCommentLine;

            scintilla.Styles[Style.Lua.Number].ForeColor = Settings.Default.StyleLuaNumber;
            scintilla.Styles[Style.Lua.Operator].ForeColor = Settings.Default.StyleLuaOperator;

            scintilla.Styles[Style.Lua.Word].ForeColor = Settings.Default.StyleLuaWord;
            scintilla.Styles[Style.Lua.Word2].ForeColor = Settings.Default.StyleLuaWord2;
            scintilla.Styles[Style.Lua.Word3].ForeColor = Settings.Default.StyleLuaWord3;

            scintilla.Styles[Style.Lua.String].ForeColor = Settings.Default.StyleLuaString;
            scintilla.Styles[Style.Lua.Character].ForeColor = Settings.Default.StyleLuaCharacter;
            scintilla.Styles[Style.Lua.LiteralString].ForeColor = Settings.Default.StyleLuaLiteralString;

            scintilla.Styles[Style.Lua.Preprocessor].ForeColor = Settings.Default.StyleLuaPreprocessor;

            scintilla.WordChars = alphaChars + numericChars + accentedChars;

            // Keywords
            scintilla.SetKeywords(0, "and break do else elseif end for function if in local nil not or repeat return then until while false true goto");
            // Basic Functions
            scintilla.SetKeywords(1, "require assert collectgarbage dofile error _G getmetatable ipairs loadfile next pairs pcall print rawequal rawget rawset setmetatable tonumber tostring type _VERSION xpcall string table math coroutine io os debug getfenv gcinfo load loadlib loadstring require select setfenv unpack _LOADED LUA_PATH _REQUIREDNAME package rawlen package bit32 utf8 _ENV");
            // String Manipulation & Mathematical
            scintilla.SetKeywords(2, "string.byte string.char string.dump string.find string.format string.gsub string.len string.lower string.rep string.sub string.upper table.concat table.insert table.remove table.sort math.abs math.acos math.asin math.atan math.atan2 math.ceil math.cos math.deg math.exp math.floor math.frexp math.ldexp math.log math.max math.min math.pi math.pow math.rad math.random math.randomseed math.sin math.sqrt math.tan string.gfind string.gmatch string.match string.reverse string.pack string.packsize string.unpack table.foreach table.foreachi table.getn table.setn table.maxn table.pack table.unpack table.move math.cosh math.fmod math.huge math.log10 math.modf math.mod math.sinh math.tanh math.maxinteger math.mininteger math.tointeger math.type math.ult bit32.arshift bit32.band bit32.bnot bit32.bor bit32.btest bit32.bxor bit32.extract bit32.replace bit32.lrotate bit32.lshift bit32.rrotate bit32.rshift utf8.char utf8.charpattern utf8.codes utf8.codepoint utf8.len utf8.offset");

            // Instruct the lexer to calculate folding
            scintilla.SetProperty("fold", "1");
            scintilla.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            scintilla.Margins[1].Type = MarginType.Number;
            scintilla.Margins[1].Mask = 0;
            scintilla.Margins[1].Sensitive = true;
            scintilla.Margins[1].Width = 30;

            // Configure a margin to display folding symbols
            scintilla.Margins[2].Type = MarginType.Symbol;
            scintilla.Margins[2].Mask = Marker.MaskFolders;
            scintilla.Margins[2].Sensitive = true;
            scintilla.Margins[2].Width = 15;

            // Set colors for all folding markers
            for (var i = 25; i <= 31; i++)
            {
                scintilla.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                scintilla.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Configure folding markers with respective symbols
            scintilla.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scintilla.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
        }

        private void ReloadStyles()
        {
            LoadEditorStyles();
            LoadLogStyles();
        }

        private void ClearOutputs()
        {
            log.Clear();
            logErr.Clear();
        }

        private void Print(string msg)
        {
            tabsOutput.SelectedTab = tabOutput;
            log.AppendText($"{msg}{Environment.NewLine}");
        }

        private void Critical(string msg)
        {
            tabsOutput.SelectedTab = tabErrors;
            logErr.AppendText($"{msg}{Environment.NewLine}");
        }

        private void InterpreterOnPrint(object sender, string s)
        {
            void MethodInvokerDelegate()
            {
                Print(s);
            }

            Invoke((MethodInvoker)MethodInvokerDelegate);
        }

        private void InterpreterOnLuaError(object sender, InterpreterException exception)
        {
            void MethodInvokerDelegate()
            {
                Critical($">>> {Resources.LogError}:");
                Critical($">>> {exception.DecoratedMessage}");
            }

            Invoke((MethodInvoker)MethodInvokerDelegate);
        }

        private void InterpreterOnCsError(object sender, Exception exception)
        {
            void MethodInvokerDelegate()
            {
                if (exception is ThreadAbortException)
                    Critical($">>> {Resources.LogScriptHalted}");
                else
                {
                    Critical($">>> {Resources.LogError}:");
                    Critical($">>> {exception.Message}");
                }
            }

            Invoke((MethodInvoker)MethodInvokerDelegate);
        }

        private void InterpreterOnExecutionStart(object sender, EventArgs eventArgs)
        {
            void MethodInvokerDelegate()
            {
                log.Clear();
                tsbHalt.Enabled = true;
            }

            Invoke((MethodInvoker)MethodInvokerDelegate);

            statusRunTime.Text = Resources.LogRunningScript;
            _stopwatch.Restart();
        }

        private void InterpreterOnExecutionComplete(object sender, ExitCondition exitCondition)
        {
            void MethodInvokerDelegate()
            {
                statusRunTime.Text = string.Format(Resources.LogExitedAfter, _stopwatch.Elapsed);
                tsbHalt.Enabled = false;
            }

            Invoke((MethodInvoker)MethodInvokerDelegate);

            _stopwatch.Stop();
        }

        private void TextArea_SavePointReached(object sender, EventArgs e)
        {
            SetTitle(_savedFileName ?? Resources.FileUntitled, false);
            _isAtSavePoint = true;
        }

        private void TextArea_SavePointLeft(object sender, EventArgs e)
        {
            SetTitle(_savedFileName ?? Resources.FileUntitled, true);
            _isAtSavePoint = false;
        }

        private void SetTitle(string fileName, bool unsaved)
        {
            Text = string.Format(Resources.LuauTItle, fileName, unsaved ? "*" : "");
        }

        private bool SaveFile(bool overwriteCurrent)
        {
            if (!overwriteCurrent || _savedFileName == null)
            {
                if (sfd.ShowDialog(this) != DialogResult.OK)
                    return false;

                _savedFileName = sfd.FileName;
            }

            File.WriteAllText(_savedFileName, scintilla.Text);
            SetTitle(_savedFileName, false);
            scintilla.SetSavePoint();
            return true;
        }

        private void CreateUntitledFile()
        {
            _savedFileName = null;
            scintilla.ClearAll();
            SetTitle(Resources.FileUntitled, false);
            scintilla.SetSavePoint();
        }

        private bool TryCloseFile()
        {
            if (_isAtSavePoint) return true;

            var result = MessageBox.Show(Resources.WarningUnsavedChanges, Resources.Warning, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            switch (result)
            {
                case DialogResult.Yes:
                    return SaveFile(true);
                case DialogResult.No:
                    return true;
                default:
                    return false;
            }
        }

        private void tsbRun_Click(object sender, EventArgs e)
        {
            ClearOutputs();
            _interpreter.Run(scintilla.Text);
        }

        private void tsbHalt_Click(object sender, EventArgs e)
        {
            _interpreter.Halt();
        }

        private void tsbFind_Click(object sender, EventArgs e)
        {
            _findReplace.ShowFind();
        }

        private void tsbReplace_Click(object sender, EventArgs e)
        {
            _findReplace.ShowReplace();
        }

        private void tsbGoToLine_Click(object sender, EventArgs e)
        {
            new GoTo(scintilla).ShowGoToDialog();
        }

        private void tsbFindNext_Click(object sender, EventArgs e)
        {
            _findReplace.Window.FindNext();
        }

        private void tsbFindPrevious_Click(object sender, EventArgs e)
        {
            _findReplace.Window.FindPrevious();
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog(this) != DialogResult.OK)
                return;

            _savedFileName = ofd.FileName;
            scintilla.Text = File.ReadAllText(ofd.FileName);
            SetTitle(_savedFileName, false);
            scintilla.SetSavePoint();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveFile(true);
        }

        private void tsbSaveAs_Click(object sender, EventArgs e)
        {
            SaveFile(false);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            if (TryCloseFile())
                CreateUntitledFile();
        }

        private void tsbAbout_Click(object sender, EventArgs e)
        {
            new LuauAboutBox().ShowDialog(this);
        }

        private void tsbPreferences_Click(object sender, EventArgs e)
        {
            var prefForm = new PreferencesForm();
            prefForm.ShowDialog(this);
            ReloadStyles();
        }

        private void tsbCtxEnable_Click(object sender, EventArgs e)
        {
            var key = Registry.ClassesRoot.CreateSubKey("Directory\\Background\\shell\\Luau");
            if (key == null)
            {
                MessageBox.Show(Resources.ErrorCantCreateRegistryKey, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            key.SetValue(null, "Open Luau Here");
            key.SetValue("Icon", "\"%LUAU_ROOT%\\Extras\\luau_icon.ico\",0", RegistryValueKind.ExpandString);

            key = key.CreateSubKey("command");
            if (key == null)
            {
                MessageBox.Show(Resources.ErrorCantCreateRegistryKey, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            key.SetValue(null, "\"%LUAU_ROOT%\\Luau.exe\" -d \"%v\"", RegistryValueKind.ExpandString);

            key.Close();

            MessageBox.Show(Resources.InfoAddedContextMenu, Resources.Info, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsbCtxDisable_Click(object sender, EventArgs e)
        {
            var key = Registry.ClassesRoot.CreateSubKey("Directory\\Background\\shell");
            if (key == null)
                return;

            key.DeleteSubKeyTree("Luau");
            key.Close();
        }

        public void ShowSimulator()
        {
            Invoke(new Action(() =>
            {
                _simForm?.Stop();

                _simForm = new SimulatorForm(this);
                Task.Factory.StartNew(() =>
                {
                    Application.Run(_simForm);
                });
            }));
        }
    }
}
