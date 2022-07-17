namespace FilePreviewer
{
    public partial class FilePreviewerForm : Form
    {
        private StreamReader reader;
        /// <summary>how many characters should be load each time</summary>
        private int characterAmountPerLoad = 1024;
        public FilePreviewerForm()
        {
            InitializeComponent();
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            var dialogResult = this.openFileDialog1.ShowDialog();
            if (dialogResult.ToString() != "OK")
            {
                return; // user cancelled the dialog
            }
            string filePath = this.openFileDialog1.FileName;
            reader = new StreamReader(filePath);
            loadFileContentIncremental();
        }

        private void loadFileContentIncremental()
        {
            string line = string.Empty;
            while (line.Length < this.characterAmountPerLoad)
            {
                var temp = this.reader.ReadLine();
                if (temp == null)
                {
                    // the end of the input stream is reached
                    MessageBox.Show("the end of the input stream is reached.");
                    break;
                }
                line += temp;
            }
            this.richTextBox1.Text += line;
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            loadFileContentIncremental();
        }
    }
}
