using System.Windows.Forms;

namespace Luau
{
    partial class LuauForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LuauForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsbFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbRichCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbHtmlCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFind = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbFindNext = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbFindPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbGoToLine = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbRun = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textArea = new ScintillaNET.Scintilla();
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFile,
            this.tsbEdit,
            this.tsbRun,
            this.tsbHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsbFile
            // 
            this.tsbFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbSave,
            this.tsbSaveAs,
            this.toolStripSeparator3,
            this.tsbClose});
            this.tsbFile.Name = "tsbFile";
            this.tsbFile.Size = new System.Drawing.Size(37, 20);
            this.tsbFile.Text = "File";
            // 
            // tsbOpen
            // 
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsbOpen.Size = new System.Drawing.Size(186, 22);
            this.tsbOpen.Text = "Open";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsbSave.Size = new System.Drawing.Size(186, 22);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbSaveAs
            // 
            this.tsbSaveAs.Name = "tsbSaveAs";
            this.tsbSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.tsbSaveAs.Size = new System.Drawing.Size(186, 22);
            this.tsbSaveAs.Text = "Save As";
            this.tsbSaveAs.Click += new System.EventHandler(this.tsbSaveAs_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(183, 6);
            // 
            // tsbClose
            // 
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.tsbClose.Size = new System.Drawing.Size(186, 22);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCut,
            this.tsbCopy,
            this.tsbRichCopy,
            this.tsbHtmlCopy,
            this.tsbPaste,
            this.tsbSelectAll,
            this.toolStripSeparator1,
            this.tsbFind,
            this.tsbFindNext,
            this.tsbFindPrevious,
            this.tsbReplace,
            this.toolStripSeparator2,
            this.tsbGoToLine});
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(39, 20);
            this.tsbEdit.Text = "Edit";
            // 
            // tsbCut
            // 
            this.tsbCut.Name = "tsbCut";
            this.tsbCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsbCut.Size = new System.Drawing.Size(203, 22);
            this.tsbCut.Text = "Cut";
            this.tsbCut.Click += new System.EventHandler(this.tsbCut_Click);
            // 
            // tsbCopy
            // 
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsbCopy.Size = new System.Drawing.Size(203, 22);
            this.tsbCopy.Text = "Copy";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // tsbRichCopy
            // 
            this.tsbRichCopy.Name = "tsbRichCopy";
            this.tsbRichCopy.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.tsbRichCopy.Size = new System.Drawing.Size(203, 22);
            this.tsbRichCopy.Text = "Copy RTF";
            this.tsbRichCopy.Click += new System.EventHandler(this.tsbRichCopy_Click);
            // 
            // tsbHtmlCopy
            // 
            this.tsbHtmlCopy.Name = "tsbHtmlCopy";
            this.tsbHtmlCopy.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.tsbHtmlCopy.Size = new System.Drawing.Size(203, 22);
            this.tsbHtmlCopy.Text = "Copy HTML";
            this.tsbHtmlCopy.Click += new System.EventHandler(this.tsbHtmlCopy_Click);
            // 
            // tsbPaste
            // 
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsbPaste.Size = new System.Drawing.Size(203, 22);
            this.tsbPaste.Text = "Paste";
            this.tsbPaste.Click += new System.EventHandler(this.tsbPaste_Click);
            // 
            // tsbSelectAll
            // 
            this.tsbSelectAll.Name = "tsbSelectAll";
            this.tsbSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsbSelectAll.Size = new System.Drawing.Size(203, 22);
            this.tsbSelectAll.Text = "Select All";
            this.tsbSelectAll.Click += new System.EventHandler(this.tsbSelectAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // tsbFind
            // 
            this.tsbFind.Name = "tsbFind";
            this.tsbFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tsbFind.Size = new System.Drawing.Size(203, 22);
            this.tsbFind.Text = "Find";
            this.tsbFind.Click += new System.EventHandler(this.tsbFind_Click);
            // 
            // tsbFindNext
            // 
            this.tsbFindNext.Name = "tsbFindNext";
            this.tsbFindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.tsbFindNext.Size = new System.Drawing.Size(203, 22);
            this.tsbFindNext.Text = "Find Next";
            this.tsbFindNext.Click += new System.EventHandler(this.tsbFindNext_Click);
            // 
            // tsbFindPrevious
            // 
            this.tsbFindPrevious.Name = "tsbFindPrevious";
            this.tsbFindPrevious.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
            this.tsbFindPrevious.Size = new System.Drawing.Size(203, 22);
            this.tsbFindPrevious.Text = "Find Previous";
            this.tsbFindPrevious.Click += new System.EventHandler(this.tsbFindPrevious_Click);
            // 
            // tsbReplace
            // 
            this.tsbReplace.Name = "tsbReplace";
            this.tsbReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.tsbReplace.Size = new System.Drawing.Size(203, 22);
            this.tsbReplace.Text = "Replace";
            this.tsbReplace.Click += new System.EventHandler(this.tsbReplace_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(200, 6);
            // 
            // tsbGoToLine
            // 
            this.tsbGoToLine.Name = "tsbGoToLine";
            this.tsbGoToLine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.tsbGoToLine.Size = new System.Drawing.Size(203, 22);
            this.tsbGoToLine.Text = "Go To Line";
            this.tsbGoToLine.Click += new System.EventHandler(this.tsbGoToLine_Click);
            // 
            // tsbRun
            // 
            this.tsbRun.Name = "tsbRun";
            this.tsbRun.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsbRun.Size = new System.Drawing.Size(40, 20);
            this.tsbRun.Text = "Run";
            this.tsbRun.Click += new System.EventHandler(this.tsbRun_Click);
            // 
            // tsbHelp
            // 
            this.tsbHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAbout});
            this.tsbHelp.Name = "tsbHelp";
            this.tsbHelp.Size = new System.Drawing.Size(24, 20);
            this.tsbHelp.Text = "?";
            // 
            // tsbAbout
            // 
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(180, 22);
            this.tsbAbout.Text = "About";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textArea);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbLog);
            this.splitContainer1.Size = new System.Drawing.Size(984, 637);
            this.splitContainer1.SplitterDistance = 637;
            this.splitContainer1.TabIndex = 2;
            // 
            // textArea
            // 
            this.textArea.AdditionalSelectionTyping = true;
            this.textArea.AutomaticFold = ((ScintillaNET.AutomaticFold)(((ScintillaNET.AutomaticFold.Show | ScintillaNET.AutomaticFold.Click) 
            | ScintillaNET.AutomaticFold.Change)));
            this.textArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textArea.IndentationGuides = ScintillaNET.IndentView.Real;
            this.textArea.Lexer = ScintillaNET.Lexer.Lua;
            this.textArea.Location = new System.Drawing.Point(0, 0);
            this.textArea.MouseSelectionRectangularSwitch = true;
            this.textArea.MultipleSelection = true;
            this.textArea.Name = "textArea";
            this.textArea.Size = new System.Drawing.Size(637, 637);
            this.textArea.TabIndex = 1;
            this.textArea.UseTabs = true;
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.SystemColors.Window;
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(0, 0);
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(343, 637);
            this.tbLog.TabIndex = 1;
            this.tbLog.Text = "";
            // 
            // sfd
            // 
            this.sfd.Filter = "Lua files|*.lua|All Files|*.*";
            // 
            // ofd
            // 
            this.ofd.Filter = "Lua files|*.lua|All Files|*.*";
            // 
            // LuauForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LuauForm";
            this.Text = "Luau";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LuauForm_FormClosing);
            this.Load += new System.EventHandler(this.LuauForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsbFile;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ScintillaNET.Scintilla textArea;
        private System.Windows.Forms.ToolStripMenuItem tsbRun;
        private System.Windows.Forms.RichTextBox tbLog;
        private System.Windows.Forms.ToolStripMenuItem tsbEdit;
        private System.Windows.Forms.ToolStripMenuItem tsbFind;
        private System.Windows.Forms.ToolStripMenuItem tsbReplace;
        private System.Windows.Forms.ToolStripMenuItem tsbOpen;
        private System.Windows.Forms.ToolStripMenuItem tsbSave;
        private System.Windows.Forms.ToolStripMenuItem tsbSaveAs;
        private System.Windows.Forms.ToolStripMenuItem tsbCut;
        private System.Windows.Forms.ToolStripMenuItem tsbCopy;
        private System.Windows.Forms.ToolStripMenuItem tsbPaste;
        private System.Windows.Forms.ToolStripMenuItem tsbSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsbRichCopy;
        private System.Windows.Forms.ToolStripMenuItem tsbHtmlCopy;
        private System.Windows.Forms.ToolStripMenuItem tsbGoToLine;
        private System.Windows.Forms.ToolStripMenuItem tsbFindNext;
        private System.Windows.Forms.ToolStripMenuItem tsbFindPrevious;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsbHelp;
        private System.Windows.Forms.ToolStripMenuItem tsbAbout;
        private SaveFileDialog sfd;
        private OpenFileDialog ofd;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem tsbClose;
    }
}

