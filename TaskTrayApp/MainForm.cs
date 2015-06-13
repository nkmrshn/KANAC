using Kansuji;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using TaskTrayApp.Properties;

namespace TaskTrayApp
{
    public partial class MainForm : Form
    {
        private ClipboardViewer viewer;
        private ContextMenuStrip menu = new ContextMenuStrip();
        private ToolStripMenuItem exit = new ToolStripMenuItem();
        private ToolStripRadioButtonMenuItem activate = new ToolStripRadioButtonMenuItem();
        private ToolStripRadioButtonMenuItem deactivate = new ToolStripRadioButtonMenuItem();
        private ToolStripRadioButtonMenuItem normal = new ToolStripRadioButtonMenuItem();
        private ToolStripRadioButtonMenuItem wide = new ToolStripRadioButtonMenuItem();
        private ToolStripSeparator separator = new ToolStripSeparator();

        public MainForm()
        {
            viewer = new ClipboardViewer(this);
            viewer.ClipboardHandler += viewer_ClipboardHandler;

            InitializeComponent();

            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;

            activate.Text = Resources.Activate;
            activate.Checked = Properties.Settings.Default.Activated;
            activate.CheckedChanged += activate_CheckedChanged;

            deactivate.Text = Resources.Deactivate;
            deactivate.Checked = !Properties.Settings.Default.Activated;
            deactivate.CheckedChanged += deactivate_CheckedChanged;

            normal.Text = Resources.Normal;
            normal.Checked = !Properties.Settings.Default.WideCharacter;
            normal.CheckedChanged += normal_CheckedChanged;

            wide.Text = Resources.Wide;
            wide.Checked = Properties.Settings.Default.WideCharacter;
            wide.CheckedChanged += wide_CheckedChanged;

            exit.Text = Resources.Exit;
            exit.Click += exit_Click;

            activate.DropDownItems.AddRange(new ToolStripItem[] { normal, wide });
            menu.Items.AddRange(new ToolStripItem[] { activate, deactivate, separator, exit });
            menu.Opening += menu_Opening;
            notifyIcon.ContextMenuStrip = menu;
            notifyIcon.Text = Resources.NofityIconText;
            notifyIcon.Icon = activate.Checked ? Resources.ActivatedIcon : Resources.DeactivatedIcon;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Hide();
        }

        private void menu_Opening(object sender, CancelEventArgs e)
        {
            TopMost = false;
        }

        private void activate_CheckedChanged(object sender, EventArgs e)
        {
            if (activate.Checked)
            {
                notifyIcon.Icon = Resources.ActivatedIcon;
                Properties.Settings.Default.Activated = true;
                Properties.Settings.Default.Save();
            }
        }

        private void deactivate_CheckedChanged(object sender, EventArgs e)
        {
            if (deactivate.Checked)
            {
                notifyIcon.Icon = Resources.DeactivatedIcon;
                Properties.Settings.Default.Activated = false;
                Properties.Settings.Default.Save();
            }
        }

        private void normal_CheckedChanged(object sender, EventArgs e)
        {
            if (normal.Checked)
            {
                Properties.Settings.Default.WideCharacter = false;
                Properties.Settings.Default.Save();
            }
        }

        private void wide_CheckedChanged(object sender, EventArgs e)
        {
            if (wide.Checked)
            {
                Properties.Settings.Default.WideCharacter = true;
                Properties.Settings.Default.Save();
            }
        }

        private void viewer_ClipboardHandler(object sender, ClipboardEventArgs ev)
        {
            if (activate.Checked)
            {
                Clipboard.SetDataObject(ev.Text.ReplaceKansujiToNumber(wide.Checked), true);
            }
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                activate.Checked = !activate.Checked;
                deactivate.Checked = !activate.Checked;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
