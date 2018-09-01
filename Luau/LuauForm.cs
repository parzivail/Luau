using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Luau.Properties;
using MoonSharp.Interpreter;
using ScintillaNET;
using ScintillaNET_FindReplaceDialog;

namespace Luau
{
    public partial class LuauForm : Form
    {
        private LuaInterpreter _interpreter;
        private FindReplace _findReplace;
        private string _savedFileName;
        private bool _isAtSavePoint = true;

        public LuauForm()
        {
            InitializeComponent();
        }

        private void LuauForm_Load(object sender, EventArgs e)
        {
            CreateUntitledFile();
            _interpreter = new LuaInterpreter();
            _interpreter.Print += InterpreterOnPrint;
            _interpreter.LuaError += InterpreterOnLuaError;
            _interpreter.CsError += InterpreterOnCsError;

            LoadEditorStyles(textArea);
            LoadLogStyles(textArea, tbLog);

            textArea.SavePointLeft += TextArea_SavePointLeft;
            textArea.SavePointReached += TextArea_SavePointReached;

            _findReplace = new FindReplace(textArea);

            Info($">>> {Resources.LogOutput}");
        }

        private void LuauForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!TryCloseFile())
                e.Cancel = true;
        }

        private static void LoadLogStyles(Scintilla scintilla, Control log)
        {
            log.Font = new Font(scintilla.Styles[Style.Default].Font, scintilla.Styles[Style.Default].Size);
        }

        private static void LoadEditorStyles(Scintilla scintilla)
        {
            var alphaChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var numericChars = "0123456789";
            var accentedChars = "ŠšŒœŸÿÀàÁáÂâÃãÄäÅåÆæÇçÈèÉéÊêËëÌìÍíÎîÏïÐðÑñÒòÓóÔôÕõÖØøÙùÚúÛûÜüÝýÞþßö";

            // Configuring the default style with properties
            // we have common to every lexer style saves time.
            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Default].Font = "Consolas";
            scintilla.Styles[Style.Default].Size = 10;
            scintilla.StyleClearAll();

            // Configure the Lua lexer styles
            scintilla.Styles[Style.Lua.Default].ForeColor = Color.Silver;
            scintilla.Styles[Style.Lua.Comment].ForeColor = Color.Green;
            scintilla.Styles[Style.Lua.CommentLine].ForeColor = Color.Green;
            scintilla.Styles[Style.Lua.Number].ForeColor = Color.Olive;
            scintilla.Styles[Style.Lua.Word].ForeColor = Color.Blue;
            scintilla.Styles[Style.Lua.Word2].ForeColor = Color.DodgerBlue;
            scintilla.Styles[Style.Lua.Word3].ForeColor = Color.DarkSlateBlue;
            scintilla.Styles[Style.Lua.Word4].ForeColor = Color.DarkSlateBlue;
            scintilla.Styles[Style.Lua.String].ForeColor = Color.Red;
            scintilla.Styles[Style.Lua.Character].ForeColor = Color.Red;
            scintilla.Styles[Style.Lua.LiteralString].ForeColor = Color.Red;
            scintilla.Styles[Style.Lua.StringEol].BackColor = Color.Pink;
            scintilla.Styles[Style.Lua.Operator].ForeColor = Color.Purple;
            scintilla.Styles[Style.Lua.Preprocessor].ForeColor = Color.Maroon;
            scintilla.WordChars = alphaChars + numericChars + accentedChars;

            // Console.WriteLine(scintilla.DescribeKeywordSets());

            // Keywords
            scintilla.SetKeywords(0, "and break do else elseif end for function if in local nil not or repeat return then until while false true goto");
            // Basic Functions
            scintilla.SetKeywords(1, "assert collectgarbage dofile error _G getmetatable ipairs loadfile next pairs pcall print rawequal rawget rawset setmetatable tonumber tostring type _VERSION xpcall string table math coroutine io os debug getfenv gcinfo load loadlib loadstring require select setfenv unpack _LOADED LUA_PATH _REQUIREDNAME package rawlen package bit32 utf8 _ENV");
            // String Manipulation & Mathematical
            scintilla.SetKeywords(2, "string.byte string.char string.dump string.find string.format string.gsub string.len string.lower string.rep string.sub string.upper table.concat table.insert table.remove table.sort math.abs math.acos math.asin math.atan math.atan2 math.ceil math.cos math.deg math.exp math.floor math.frexp math.ldexp math.log math.max math.min math.pi math.pow math.rad math.random math.randomseed math.sin math.sqrt math.tan string.gfind string.gmatch string.match string.reverse string.pack string.packsize string.unpack table.foreach table.foreachi table.getn table.setn table.maxn table.pack table.unpack table.move math.cosh math.fmod math.huge math.log10 math.modf math.mod math.sinh math.tanh math.maxinteger math.mininteger math.tointeger math.type math.ult bit32.arshift bit32.band bit32.bnot bit32.bor bit32.btest bit32.bxor bit32.extract bit32.replace bit32.lrotate bit32.lshift bit32.rrotate bit32.rshift utf8.char utf8.charpattern utf8.codes utf8.codepoint utf8.len utf8.offset");
            // Input and Output Facilities and System Facilities
            scintilla.SetKeywords(3, "coroutine.create coroutine.resume coroutine.status coroutine.wrap coroutine.yield io.close io.flush io.input io.lines io.open io.output io.read io.tmpfile io.type io.write io.stdin io.stdout io.stderr os.clock os.date os.difftime os.execute os.exit os.getenv os.remove os.rename os.setlocale os.time os.tmpname coroutine.isyieldable coroutine.running io.popen module package.loaders package.seeall package.config package.searchers package.searchpath require package.cpath package.loaded package.loadlib package.path package.preload");

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
            scintilla.Margins[2].Width = 20;

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

        private void Log(string log)
        {
            tbLog.AppendText($"{log}{Environment.NewLine}", Color.Black);
        }

        private void Info(string log)
        {
            tbLog.AppendText($"{log}{Environment.NewLine}", Color.LightGray);
        }

        private void Critical(string log)
        {
            tbLog.AppendText($"{log}{Environment.NewLine}", Color.Red);
        }

        private void InterpreterOnPrint(object sender, string s)
        {
            Log(s);
        }

        private void InterpreterOnLuaError(object sender, InterpreterException exception)
        {
            Critical($">>> {Resources.LogError}:");
            Critical($">>> {exception.DecoratedMessage}");
        }

        private void InterpreterOnCsError(object sender, Exception exception)
        {
            Critical($">>> {Resources.LogError}:");
            Critical($">>> {exception.Message}");
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

            File.WriteAllText(_savedFileName, textArea.Text);
            SetTitle(_savedFileName, false);
            textArea.SetSavePoint();
            return true;
        }

        private void CreateUntitledFile()
        {
            _savedFileName = null;
            textArea.ClearAll();
            SetTitle(Resources.FileUntitled, false);
            textArea.SetSavePoint();
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
            tbLog.Clear();
            Info($">>> {Resources.LogRunningScript}");
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            _interpreter.Run(textArea.Text);

            stopwatch.Stop();
            Info($"<<< {Resources.LogExitedAfter} {stopwatch.Elapsed}");
        }

        private void tsbFind_Click(object sender, EventArgs e)
        {
            _findReplace.ShowFind();
        }

        private void tsbReplace_Click(object sender, EventArgs e)
        {
            _findReplace.ShowReplace();
        }

        private void tsbCut_Click(object sender, EventArgs e)
        {
            if (tbLog.Focused)
                tbLog.Cut();
            else
                textArea.Cut();
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            if (tbLog.Focused)
                tbLog.Copy();
            else
                textArea.Copy();
        }

        private void tsbPaste_Click(object sender, EventArgs e)
        {
            if (tbLog.Focused)
                tbLog.Paste();
            else
                textArea.Paste();
        }

        private void tsbSelectAll_Click(object sender, EventArgs e)
        {
            if (tbLog.Focused)
                tbLog.SelectAll();
            else
                textArea.SelectAll();
        }

        private void tsbRichCopy_Click(object sender, EventArgs e)
        {
            if (tbLog.Focused)
                tbLog.Copy();
            else
                textArea.Copy(CopyFormat.Rtf);
        }

        private void tsbHtmlCopy_Click(object sender, EventArgs e)
        {
            if (tbLog.Focused)
                tbLog.Copy();
            else
                textArea.Copy(CopyFormat.Html);
        }

        private void tsbGoToLine_Click(object sender, EventArgs e)
        {
            new GoTo(textArea).ShowGoToDialog();
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
            textArea.Text = File.ReadAllText(ofd.FileName);
            SetTitle(_savedFileName, false);
            textArea.SetSavePoint();
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
    }
}
