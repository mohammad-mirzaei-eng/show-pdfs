using PdfiumViewer;

namespace show_pdf
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ZoomTrackBar_MouseUp(object? sender, MouseEventArgs e)
        {
            panel1.ScrollControlIntoView((sender as TrackBar));
        }

        private void UpdatePanelLocations()
        {
            int y = 0;

            panel1.VerticalScroll.Value = 0;  // Reset scroll position
            // Rest of the method remains the same
            foreach (Control control in panel1.Controls)
            {
                if (control is Panel containerPanel)
                {
                    containerPanel.Location = new Point(0, y);
                    y += containerPanel.Height + 10;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Multiselect = true;
                    ofd.Filter = "PDF Files|*.pdf";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        int y = 0;
                        foreach (var item in ofd.FileNames)
                        {
                            using (var document = PdfDocument.Load(item))
                            {
                                ///TODO read all page from pdf and show on pic
                                //for (int i = 0; i < document.PageCount; i++)
                                //{
                                //using (var image = document.Render(i, 3000, 3000, false))
                                //{
                                //.
                                //.
                                //.
                                //}
                                using (var image = document.Render(0, 3000, 3000, false))
                                {
                                    // Create container panel for each PDF
                                    Panel containerPanel = new Panel
                                    {
                                        Size = new Size(panel1.Width - 25, 400),
                                        Location = new Point(0, y),
                                        BorderStyle = BorderStyle.FixedSingle,
                                        AutoScroll = true
                                    };

                                    // Create PictureBox
                                    PictureBox pic = new PictureBox
                                    {
                                        Image = new Bitmap(image),
                                        SizeMode = PictureBoxSizeMode.Zoom,
                                        Dock = DockStyle.None,
                                        Size = new Size(300, 300),
                                        Anchor = AnchorStyles.Top | AnchorStyles.Left
                                    };

                                    // Add zoom controls
                                    TrackBar zoomTrackBar = new TrackBar
                                    {
                                        Minimum = 50,
                                        Maximum = 300,
                                        Value = 100,
                                        Width = 150,
                                        Location = new Point(10, 310),
                                        Anchor = AnchorStyles.Left | AnchorStyles.Bottom
                                    };

                                    Label zoomLabel = new Label
                                    {
                                        Text = "Zoom: 100%",
                                        Location = new Point(170, 310),
                                        Anchor = AnchorStyles.Left | AnchorStyles.Bottom
                                    };

                                    // Zoom functionality
                                    zoomTrackBar.ValueChanged += (s, ev) =>
                                    {
                                        float zoom = zoomTrackBar.Value / 100f;
                                        pic.Size = new Size((int)(300 * zoom), (int)(300 * zoom));
                                        zoomLabel.Text = $"Zoom: {zoomTrackBar.Value}%";
                                        containerPanel.Height = pic.Height + 100;
                                        UpdatePanelLocations();
                                    };

                                    zoomTrackBar.MouseUp += ZoomTrackBar_MouseUp;

                                    // Add mouse wheel zoom support
                                    pic.MouseWheel += (s, ev) =>
                                    {
                                        if (Control.ModifierKeys == Keys.Control)
                                        {
                                            int newValue = zoomTrackBar.Value + (ev.Delta > 0 ? 10 : -10);
                                            zoomTrackBar.Value = Math.Clamp(newValue, zoomTrackBar.Minimum, zoomTrackBar.Maximum);
                                            panel1.ScrollControlIntoView(pic);
                                        }
                                    };

                                    // Add right-click menu
                                    ContextMenuStrip contextMenu = new ContextMenuStrip();
                                    contextMenu.Items.Add("Reset Zoom", null, (s, ev) =>
                                    {
                                        zoomTrackBar.Value = 100;
                                    });
                                    contextMenu.Items.Add("Fit to Width", null, (s, ev) =>
                                    {
                                        pic.Size = new Size(containerPanel.Width - 20, (int)((containerPanel.Width - 20) * (300f / 300f)));
                                        zoomTrackBar.Value = (int)((float)pic.Width / 300 * 100);
                                    });
                                    pic.ContextMenuStrip = contextMenu;

                                    // Add controls to container
                                    containerPanel.Controls.Add(pic);
                                    containerPanel.Controls.Add(zoomTrackBar);
                                    containerPanel.Controls.Add(zoomLabel);
                                    panel1.Controls.Add(containerPanel);

                                    y += containerPanel.Height + 10;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
