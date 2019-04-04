#region Imports

//using System.Windows.Forms.VisualStyles;
//using Zeroit.Framework.Widgets;

#endregion

namespace Zeroit.Framework.Form
{
    //public partial class CustomForm : System.Windows.Forms.Form
    //{
    //    private int originalleft;
    //    private int originaltop;
    //    private int pbottom;
    //    internal bool winMaxed = false;
    //    internal Size originalSize;
    //    private int theWidth;
    //    private bool enableShadow = false;
        



    //    private ResizeLocation rLoc;

    //    //Windows API Constants (Form Resize)
    //    internal const int WM_NCLBUTTONDOWN = 161;
    //    internal const int HT_CAPTION = 0x2;
    //    internal const int HTBOTTOM = 15;
    //    internal const int HTBOTTOMLEFT = 16;
    //    internal const int HTBOTTOMRIGHT = 17;
    //    internal const int HTRIGHT = 11;
    //    internal const int HTLEFT = 10;
    //    internal const int HTTOP = 12;
    //    internal const int WS_MAXIMIZE = 0x01000000;
    //    internal const int WM_COMMAND = 0x111;
    //    internal const int SIZE_MAXIMIZED = 2;
    //    internal const int WM_SIZE = 0x0005;
    //    internal const int SW_MAXIMIZE = 3;
    //    internal const int SW_NORMAL = 1;

    //    #region Enums

    //    private enum ResizeLocation
    //    {
    //        //Determines the position of the cursor.
    //        top = 0,
    //        left = 1,
    //        right = 2,
    //        bottom = 3,
    //        bottomleft = 4,
    //        bottomright = 5,
    //        none = 6,
    //    }

    //    #endregion

    //    #region Public Properties

        

    //    #endregion


    //    public CustomForm()
    //    {

    //        SetStyle(ControlStyles.ResizeRedraw, true);
                        
    //        InitializeComponent();
            
    //        this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

            
    //    }

    //    #region Private Methods

    //    private void resize(ResizeLocation e)
    //    {
    //        //The resize function using the Windows API (SendMessage() and ReleaseCapture()).
    //        int dir = -1;
    //        switch (e)
    //        {
    //            case ResizeLocation.top:
    //                dir = HTTOP;
    //                break;
    //            case ResizeLocation.left:
    //                dir = HTLEFT;
    //                break;
    //            case ResizeLocation.right:
    //                dir = HTRIGHT;
    //                break;
    //            case ResizeLocation.bottom:
    //                dir = HTBOTTOM;
    //                break;
    //            case ResizeLocation.bottomleft:
    //                dir = HTBOTTOMLEFT;
    //                break;
    //            case ResizeLocation.bottomright:
    //                dir = HTBOTTOMRIGHT;
    //                break;
    //        }
    //        if (dir != -1)
    //        {
    //            API.ReleaseCapture();
    //            API.SendMessage(this.Handle, WM_NCLBUTTONDOWN, dir, 0);
    //        }
    //    }

    //    #endregion

    //    #region Overrides

    //    protected override CreateParams CreateParams
    //    {
    //        //Enables the form to be minimized through the taskbar.
    //        get
    //        {
    //            CreateParams cp = base.CreateParams;
    //            cp.Style |= 0x20000;
    //            return cp;
    //        }
    //    }

    //    protected override void WndProc(ref Message m)
    //    {
    //        base.WndProc(ref m);
    //    }

    //    public override string Text
    //    {
    //        //updates the titleCaption...
    //        get
    //        {
    //            return base.Text;
    //        }
    //        set
    //        {
    //            titleCaption.Text = value;
    //            base.Text = value;
    //        }
    //    }

    //    protected override void OnResize(EventArgs e)
    //    {
            
    //    }

    //    #endregion

    //    #region Events

    //    private void panelmod1_MouseDoubleClick(object sender, MouseEventArgs e)
    //    {
    //        //Maximizes or Restores the window when you double-click the titlebar, similar to a regular window.
    //        if (this.WindowState == FormWindowState.Maximized)
    //        {
    //            cmdMaxRes_Click(cmdMaxRes, null);
    //        }
    //        else if (this.WindowState == FormWindowState.Normal)
    //        {
    //            cmdMaxRes_Click(cmdMaxRes, null);
    //        }
    //    }

    //    private void cmdMaxRes_Paint(object sender, PaintEventArgs e)
    //    {

    //    }


    //    private void titleCaption_Layout(object sender, LayoutEventArgs e)
    //    {
    //        //recenter the caption
    //        int formWidth = this.Width;
    //        int captionWidth = titleCaption.Width;
    //        if (titleCaption.Left < cmdMaxRes.Right)
    //        {
    //            titleCaption.Left = cmdMaxRes.Right + 5;
    //        }
    //        else if (titleCaption.Left > cmdMaxRes.Right + 5)
    //        {
    //            titleCaption.Left = this.Width / 2 - (titleCaption.Width / 2);
    //        }
    //        if ((formWidth / 2) - (captionWidth / 2) > cmdMaxRes.Right)
    //        {
    //            titleCaption.Left = this.Width / 2 - (titleCaption.Width / 2);
    //        }
    //    }

    //    internal void toppnl_MouseMove(object sender, MouseEventArgs e)
    //    {
    //        //Resize function (top)
    //        if (MouseButtons.ToString() == "Left")
    //        {
    //            if (this.WindowState != FormWindowState.Maximized)
    //            {
    //                resize(rLoc);
    //            }
    //        }
    //    }

    //    internal void nwsize_MouseMove(object sender, MouseEventArgs e)
    //    {
    //        //Resize function (left and bottom side)
    //        if (MouseButtons.ToString() == "Left")
    //        {
    //            if (this.WindowState != FormWindowState.Maximized)
    //            {
    //                resize(rLoc);
    //            }
    //        }
    //    }

    //    private void titlebar_MouseDown(object sender, MouseEventArgs e)
    //    {
    //        //a shared MouseDown function(titleCaption,title bar, sizing edges).
    //        //Retrieves the form's current location on the screen.
    //        loc = e.Location;
    //        theWidth = this.Width;
    //        pright = this.Right;
    //        pbottom = this.Bottom;
    //        Cursor.Clip = Screen.PrimaryScreen.WorkingArea;
    //        //For the resizing edges...
    //        try
    //        {
    //            Panel panel = (Panel)sender;
    //            switch (panel.Name)
    //            {
    //                case "toppnl":
    //                    rLoc = ResizeLocation.top;
    //                    break;
    //                case "leftpnl":
    //                    rLoc = ResizeLocation.left;
    //                    break;
    //                case "leftpnl2":
    //                    rLoc = ResizeLocation.left;
    //                    break;
    //                case "rightpnl":
    //                    rLoc = ResizeLocation.right;
    //                    break;
    //                case "rightpnl2":
    //                    rLoc = ResizeLocation.right;
    //                    break;
    //                case "bottompnl":
    //                    rLoc = ResizeLocation.bottom;
    //                    break;
    //                case "bottompnl2":
    //                    rLoc = ResizeLocation.bottom;
    //                    break;
    //                case "nwsize":
    //                    rLoc = ResizeLocation.bottomleft;
    //                    break;
    //                case "swresize":
    //                    rLoc = ResizeLocation.bottomright;
    //                    break;
    //            }
    //        }
    //        catch { }
    //    }

    //    private void titlebar_MouseMove(object sender, MouseEventArgs e)
    //    {
    //        //Function for form dragging.
    //        if (this.WindowState != FormWindowState.Maximized)
    //        {
    //            if (MouseButtons.ToString() == "Left")
    //            {
    //                API.ReleaseCapture();
    //                API.SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
    //            }
    //        }
    //    }

    //    internal void rightpnl_MouseMove(object sender, MouseEventArgs e)
    //    {
    //        //Resize Function (right):
    //        if (MouseButtons.ToString() == "Left")
    //        {
    //            if (this.WindowState != FormWindowState.Maximized)
    //            {
    //                resize(rLoc);
    //            }
    //        }
    //    }

    //    internal void bottompnl_MouseMove(object sender, MouseEventArgs e)
    //    {
    //        //Resize Function (bottom);
    //        if (MouseButtons.ToString() == "Left")
    //        {
    //            if (this.WindowState != FormWindowState.Maximized)
    //            {
    //                resize(rLoc);
    //            }
    //        }
    //    }

    //    internal void swresize_MouseMove(object sender, MouseEventArgs e)
    //    {
    //        //The bottom right corner resize function.
    //        if (MouseButtons.ToString() == "Left")
    //        {
    //            if (this.WindowState != FormWindowState.Maximized)
    //            {
    //                resize(rLoc);
    //            }
    //        }
    //    }

    //    private void mactheme_Resize(object sender, EventArgs e)
    //    {
    //        //Function to center the caption position and update the form to avoid flickers.
    //        //Always determine the maximum workingArea of the screen.
    //        this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
    //        int formWidth = this.Width;
    //        int captionWidth = titleCaption.Width;
    //        if (titleCaption.Left < cmdMaxRes.Right)
    //        {
    //            titleCaption.Left = cmdMaxRes.Right + 5;
    //        }
    //        else if (titleCaption.Left > cmdMaxRes.Right + 5)
    //        {
    //            titleCaption.Left = this.Width / 2 - (titleCaption.Width / 2);
    //        }
    //        if ((formWidth / 2) - (captionWidth / 2) > cmdMaxRes.Right)
    //        {
    //            titleCaption.Left = this.Width / 2 - (titleCaption.Width / 2);
    //        }
    //        this.Update();
    //    }

    //    internal void leftpnl_MouseMove(object sender, MouseEventArgs e)
    //    {
    //        //Resize function (left side)
    //        if (MouseButtons.ToString() == "Left")
    //        {
    //            if (this.WindowState != FormWindowState.Maximized)
    //            {
    //                resize(rLoc);
    //            }
    //        }
    //    }

    //    private void bufferedPanel1_MouseUp(object sender, MouseEventArgs e)
    //    {
    //        //releases the cursors limit when dragging the form around, to allow cursor to go to the taskbar.
    //        Cursor.Clip = Screen.PrimaryScreen.Bounds;
    //    }

    //    private void mactheme_Activated(object sender, EventArgs e)
    //    {
    //        //Sets the the titlebar's background to its normal color to determine that it's active.
    //        //panelmod1.BackgroundImage = Properties.Resources.titlebar;
    //    }

    //    private void mactheme_Deactivate(object sender, EventArgs e)
    //    {
    //        //Sets the titlebar's background to a lighter color to determine that it's inactive and reset the cursor limits.
    //        //panelmod1.BackgroundImage = Properties.Resources.titlebarunfocused1;
    //        Cursor.Clip = Screen.PrimaryScreen.Bounds;
    //    }

    //    private void cmdClose_MouseMove(object sender, MouseEventArgs e)
    //    {
    //        //change the backgroundimage...
    //        //cmdClose.BackgroundImage = Properties.Resources.controlbutton_close;
    //    }

    //    private void cmdClose_MouseLeave(object sender, EventArgs e)
    //    {
    //        //restores the original button image...
    //        //cmdClose.BackgroundImage = Properties.Resources.controlbutton_normal;
    //    }

    //    private void cmdMin_MouseMove(object sender, MouseEventArgs e)
    //    {
    //        //sets the background image to minimize...
    //        //cmdMin.BackgroundImage = Properties.Resources.controlbutton_min;
    //    }

    //    private void cmdMin_MouseLeave(object sender, EventArgs e)
    //    {
    //        //restores the original image of cmdMin background image...
    //        //cmdMin.BackgroundImage = Properties.Resources.controlbutton_normal;
    //    }

    //    private void cmdMaxRes_MouseMove(object sender, MouseEventArgs e)
    //    {
    //        //sets cmdMaxRes' background image '+'...
    //        //cmdMaxRes.BackgroundImage = Properties.Resources.controlbutton_maxres;
    //    }

    //    private void cmdMaxRes_MouseLeave(object sender, EventArgs e)
    //    {
    //        //restores cmdMaxRes' background image to normal...
    //        //cmdMaxRes.BackgroundImage = Properties.Resources.controlbutton_normal;
    //    }

    //    private void cmdClose_Click(object sender, EventArgs e)
    //    {
    //        //Closes the form.
    //        this.Close();
    //        this.Dispose();
    //    }

    //    private void cmdMin_Click(object sender, EventArgs e)
    //    {
    //        //minimizes the form.
    //        this.WindowState = FormWindowState.Minimized;
    //    }

    //    private void cmdMaxRes_Click(object sender, EventArgs e)
    //    {
    //        if (this.winMaxed == false)
    //        {
    //            //Maximizes the form and removes the resizing cursors of the edges.
    //            originalleft = this.Left;
    //            originaltop = this.Top;
    //            originalSize = this.Size;
    //            this.DesktopLocation = new Point(0, 0);
    //            this.Size = this.MaximumSize;
    //            leftpnl.Cursor = Cursors.Arrow;
    //            leftpnl2.Cursor = Cursors.Arrow;
    //            rightpnl.Cursor = Cursors.Arrow;
    //            rightpnl2.Cursor = Cursors.Arrow;
    //            bottompnl.Cursor = Cursors.Arrow;
    //            bottompnl2.Cursor = Cursors.Arrow;
    //            nwsize.Cursor = Cursors.Arrow;
    //            swresize.Cursor = Cursors.Arrow;
    //            toppnl.Cursor = Cursors.Arrow;

    //            leftpnl.MouseMove -= new MouseEventHandler(leftpnl_MouseMove);
    //            leftpnl2.MouseMove -= new MouseEventHandler(leftpnl_MouseMove);
    //            toppnl.MouseMove -= new MouseEventHandler(toppnl_MouseMove);
    //            bottompnl.MouseMove -= new MouseEventHandler(bottompnl_MouseMove);
    //            bottompnl2.MouseMove -= new MouseEventHandler(bottompnl_MouseMove);
    //            rightpnl.MouseMove -= new MouseEventHandler(rightpnl_MouseMove);
    //            rightpnl2.MouseMove -= new MouseEventHandler(rightpnl_MouseMove);
    //            swresize.MouseMove -= new MouseEventHandler(swresize_MouseMove);
    //            nwsize.MouseMove -= new MouseEventHandler(nwsize_MouseMove);
    //            titleCaption.MouseMove -= new MouseEventHandler(titlebar_MouseMove);
    //            panelmod1.MouseMove -= new MouseEventHandler(titlebar_MouseMove);

    //            winMaxed = true;
    //        }
    //        else
    //        {
    //            //Restores the form and returns the resizing cursors of the edges.
    //            API.ShowWindow(this.Handle, SW_NORMAL);
    //            this.Top = originaltop;
    //            this.Left = originalleft;
    //            this.Size = originalSize;
    //            leftpnl.Cursor = Cursors.SizeWE;
    //            leftpnl2.Cursor = Cursors.SizeWE;
    //            rightpnl.Cursor = Cursors.SizeWE;
    //            rightpnl2.Cursor = Cursors.SizeWE;
    //            bottompnl.Cursor = Cursors.SizeNS;
    //            bottompnl2.Cursor = Cursors.SizeNS;
    //            nwsize.Cursor = Cursors.SizeNESW;
    //            swresize.Cursor = Cursors.SizeNWSE;
    //            toppnl.Cursor = Cursors.SizeNS;

    //            leftpnl.MouseMove += new MouseEventHandler(leftpnl_MouseMove);
    //            leftpnl2.MouseMove += new MouseEventHandler(leftpnl_MouseMove);
    //            toppnl.MouseMove += new MouseEventHandler(toppnl_MouseMove);
    //            bottompnl.MouseMove += new MouseEventHandler(bottompnl_MouseMove);
    //            bottompnl2.MouseMove += new MouseEventHandler(bottompnl_MouseMove);
    //            rightpnl.MouseMove += new MouseEventHandler(rightpnl_MouseMove);
    //            rightpnl2.MouseMove += new MouseEventHandler(rightpnl_MouseMove);
    //            swresize.MouseMove += new MouseEventHandler(swresize_MouseMove);
    //            nwsize.MouseMove += new MouseEventHandler(nwsize_MouseMove);
    //            titleCaption.MouseMove += new MouseEventHandler(titlebar_MouseMove);
    //            panelmod1.MouseMove += new MouseEventHandler(titlebar_MouseMove);

    //            winMaxed = false;
    //        }
    //    }

    //    #endregion

    //    private int shadowBlur = 10;
    //    private int shadowSpread = -5;
    //    private int shadowV = 0;
    //    private int shadowH = 0;
    //    private Color shadowColor = Color.Black;

    //    [Category("Shadow"),
    //     Browsable(true),
    //     Description("This Enables the form to have shadow effect")]
    //    public bool Shadow
    //    {
    //        get { return enableShadow; }
    //        set
    //        {
    //            enableShadow = value;
    //            Invalidate();
    //        }
    //    }

    //    [Category("Shadow"),
    //     Browsable(true),
    //     Description("Sets the blured level of the shadow.")]
    //    public int Blur
    //    {
    //        get { return shadowBlur; }
    //        set
    //        {
    //            shadowBlur = value;
    //            Invalidate();
    //        }
    //    }

    //    [Category("Shadow"),
    //     Browsable(true),
    //     Description("Set to change how the shadow spreads.")]
    //    public int Dispersion
    //    {
    //        get { return shadowSpread; }
    //        set
    //        {
    //            shadowSpread = value;
    //            Invalidate();
    //        }
    //    }

    //    [Category("Shadow"),
    //     Browsable(true),
    //     Description("Set to change the vertical direction of the shadow.")]
    //    public int VerticalDirection
    //    {
    //        get { return shadowV; }
    //        set
    //        {
    //            shadowV = value;
    //            Invalidate();
    //        }

    //    }

    //    [Category("Shadow"),
    //     Browsable(true),
    //     Description("Set to change the horizontal direction of the shadow.")]
    //    public int HorizontalDirection
    //    {
    //        get { return shadowH; }
    //        set
    //        {
    //            shadowH = value;
    //            Invalidate();
    //        }

    //    }

    //    [Category("Shadow"), 
    //     Browsable(true),
    //     Description("Set to change the shadow color.")]
    //    public Color ColorOfShadow
    //    {
    //        get { return shadowColor; }
    //        set
    //        {
    //            shadowColor = value;
    //            Invalidate();
    //        }
    //    }



        
    //    private void CustomForm_Load(object sender, EventArgs e)
    //    {
    //        //if (enableShadow)
    //        //{

    //        //    ZeroitDropshadow AddShadow = new ZeroitDropshadow(this);
    //        //    AddShadow.ShadowBlur = shadowBlur;
    //        //    AddShadow.ShadowSpread = shadowSpread;
    //        //    AddShadow.ShadowV = shadowV;
    //        //    AddShadow.ShadowH = shadowH;
    //        //    AddShadow.ShadowColor = shadowColor;
    //        //    AddShadow.ActivateShadow();
    //        //    AddShadow.RefreshShadow();
    //        //}


    //    }


        
    //}

    //public class API
    //{
    //    //Windows API for resizing the window.
    //    [DllImport("user32.dll")]
    //    public static extern int SendMessage(IntPtr hWnd, uint Msg, long lParam, long wParam);
    //    [DllImport("user32.dll")]
    //    public static extern bool ReleaseCapture();
    //    [DllImport("user32.dll")]
    //    public static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
    //}
    
    //public class CustomFormThemeManager
    //{
    //    //Functions for applying the  form theme.
    //    public CustomFormThemeManager()
    //    {
    //        //ThemeManager()
    //    }
    //    public void ApplyFormThemeSizable(System.Windows.Forms.Form clientForm)
    //    {
    //        //This thread makes the specified form to be a control of the created Mac themed form (Resizable).
    //        CustomForm frm = new CustomForm();      //Creates a new Mac themed borderless form (generated by the mactheme class).
    //        frm.TopMost = clientForm.TopMost;    //Determines if the themed form should be in the TopMost level.
    //        frm.ShowInTaskbar = clientForm.ShowInTaskbar;  //Determines if the themed form should appear in the taskbar.
    //        frm.ShowIcon = clientForm.ShowIcon;   //Determines if the themed form should show its icon in the taskbar.

    //        //Checks if the user wants to disable some sizing buttons...
    //        if (clientForm.MaximizeBox == false)
    //        {
    //            frm.ControlBox = false;
    //            frm.cmdMaxRes.Visible = false;
    //            frm.MaximizeBox = false;
    //        }
    //        if (clientForm.MinimizeBox == false)
    //        {
    //            frm.cmdMaxRes.Left = frm.cmdMin.Left;
    //            frm.cmdMin.Visible = false;
    //            frm.MinimizeBox = false;
    //        }
    //        //////////////////////////////////////////////////////////

    //        clientForm.TopLevel = false;               //Sets the TopLevel property of the clientForm to false so that we can add it as a client control on our mac themed form.
    //        clientForm.FormBorderStyle = FormBorderStyle.None;   //Makes the clientForm borderless.
    //        frm.Width = clientForm.Width + 8;      //Adjusts the width of the Mac themed form.
    //        frm.Top = 0;                                     //Sets the default top location to 0.
    //        frm.Left = 0;                                     //Sets the default left location to 0.

    //        frm.StartPosition = clientForm.StartPosition;  //Sets the themed form's StartPosition same as the clientForm's StartPositon. If {0,0} location is used and it is needed to be applied, just set the clientForm's StartPosition to manual.
    //        if (clientForm.Top != 0)
    //        {
    //            frm.StartPosition = FormStartPosition.Manual;   //Sets the Form's Startup position to manual.
    //            frm.Top = clientForm.Top;                 //Sets the themed form's top the same as the clientForm's top position.
    //        }
    //        if (clientForm.Left != 0)
    //        {
    //            frm.StartPosition = FormStartPosition.Manual;   //Sets the Form's Startup position to manual.
    //            frm.Left = clientForm.Left;                  //Sets the themed form's left the same as the clientForm's Left position.
    //        }

    //        frm.Height = clientForm.Height + 28; //Adjusts the height of the Mac themed form.
    //        clientForm.Top = 0;                           //Sets the clientForm's top location to 0.
    //        clientForm.Left = 3;                           //Sets the clientForms' left location.
    //        frm.Text = clientForm.Text;                         //Sets the mac themed form's Text property to the specified title (param = formTitle).
    //        clientForm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;    //Anchors the clientForm so it fits the themed form during resizing process.
    //        frm.titleCaption.Text = clientForm.Text;        //Sets the themed form's titleCaption Text property to the specified title (param = formTitle).
    //        frm.bodypanel.Controls.Add(clientForm); //Adds the clientForm to the bodypanel's Controls collection.
    //        frm.Icon = clientForm.Icon;                 //Sets the themed form's Icon property the same as the clientForm's Icon property.

    //        Size zeroSize = new Size(0, 0);            //The default minimum size of a form (0,0).
    //        if (clientForm.MinimumSize != zeroSize)   //If the minimum width and height of the clientForm is not on default (0,0)....
    //        {
    //            frm.MinimumSize = new Size(clientForm.MinimumSize.Width + 8, clientForm.MinimumSize.Height + 28);  //Sets the minimum size of the themed form.
    //        }
    //        if (clientForm.Width < frm.MinimumSize.Width)
    //        {
    //            clientForm.Width = frm.MinimumSize.Width;
    //        }
    //        if (clientForm.Height < frm.MinimumSize.Height)
    //        {
    //            clientForm.Height = frm.MinimumSize.Height;
    //        }
    //        clientForm.FormClosed += new FormClosedEventHandler(onThemedForm_Close);  //If the client form is closed, the themed form should also close as well.
    //        frm.Show();  //Show the generated themed form with the clientForm as it's child control.


    //    }
    //    public void ApplyFormThemeDialog(System.Windows.Forms.Form clientForm, System.Windows.Forms.Form parentForm)
    //    {
    //        //This thread makes the specified form to be a control of the created Mac themed form (Fixed Single).
    //        CustomForm frm = new CustomForm();      //Creates a new Mac themed borderless form (generated by this library).
    //        clientForm.FormBorderStyle = FormBorderStyle.None;   //Makes the clientForm borderless.
    //        frm.Width = clientForm.Width + 8;      //Adjusts the width of the Mac themed form.
    //        frm.Height = clientForm.Height + 28; //Adjusts the height of the Mac themed form.
    //        frm.Owner = parentForm;                   //Sets the owner of the themed form to the specified parentForm.
    //        frm.StartPosition = clientForm.StartPosition;  //Sets the themed form's StartPosition same as the clientForm's StartPositon. If {0,0} location is used and it is needed to be applied, just set the clientForm's StartPosition to manual.

    //        if (clientForm.Top != 0)
    //        {
    //            frm.StartPosition = FormStartPosition.Manual; //Sets the Form's Startup position to manual.
    //            frm.Top = clientForm.Top;                 //Sets the themed form's top the same as the clientForm's top position.
    //        }
    //        if (clientForm.Left != 0)
    //        {
    //            frm.StartPosition = FormStartPosition.Manual; //Sets the Form's Startup position to manual.
    //            frm.Left = clientForm.Left;                  //Sets the themed form's left the same as the clientForm's Left position.
    //        }
    //        clientForm.TopLevel = false;               //Sets the TopLevel property of the clientForm to false so that we can add it as a client control on our mac themed form.

    //        //Sets the edges' cursor to normal and disable their resizing function;
    //        frm.leftpnl.Cursor = Cursors.Arrow;
    //        frm.leftpnl2.Cursor = Cursors.Arrow;
    //        frm.rightpnl.Cursor = Cursors.Arrow;
    //        frm.rightpnl2.Cursor = Cursors.Arrow;
    //        frm.bottompnl2.Cursor = Cursors.Arrow;
    //        frm.bottompnl.Cursor = Cursors.Arrow;
    //        frm.toppnl.Cursor = Cursors.Arrow;
    //        frm.leftpnl.MouseMove -= frm.leftpnl_MouseMove;
    //        frm.leftpnl2.MouseMove -= frm.leftpnl_MouseMove;
    //        frm.rightpnl.MouseMove -= frm.rightpnl_MouseMove;
    //        frm.rightpnl2.MouseMove -= frm.rightpnl_MouseMove;
    //        frm.bottompnl.MouseMove -= frm.bottompnl_MouseMove;
    //        frm.bottompnl2.MouseMove -= frm.bottompnl_MouseMove;
    //        frm.toppnl.MouseMove -= frm.toppnl_MouseMove;
    //        ///////////////////////////////////////////////////////////

    //        //Do not show in taskbar and removes the minimize and maximize/restore buttons...
    //        frm.cmdMaxRes.Visible = false;
    //        frm.cmdMin.Visible = false;
    //        frm.ShowInTaskbar = false;
    //        ///////////////////////////////////////////////////////////////////

    //        clientForm.Top = 0;                           //Sets the clientForm's top location to 0.
    //        clientForm.Left = 3;                           //Sets the clientForms' left location.
    //        frm.Text = clientForm.Text;                         //Sets the mac themed form's Text property to the specified title (param = formTitle).
    //        clientForm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;    //Anchors the clientForm so it fits the themed form during resizing process.
    //        frm.titleCaption.Text = clientForm.Text;        //Sets the themed form's titleCaption Text property to the specified title (param = formTitle).
    //        frm.bodypanel.Controls.Add(clientForm); //Adds the clientForm to the bodypanel's Controls collection.
    //        frm.Icon = clientForm.Icon;                 //Sets the themed form's Icon property the same as the clientForm's Icon property.

    //        Size zeroSize = new Size(0, 0);            //The default minimum size of a form (0,0).
    //        if (clientForm.MinimumSize != zeroSize)   //If the minimum width and height of the clientForm is not on default (0,0)....
    //        {
    //            frm.MinimumSize = new Size(clientForm.MinimumSize.Width + 8, clientForm.MinimumSize.Height + 28); //Sets the minimum size of the themed form.
    //        }
    //        if (clientForm.Width < frm.MinimumSize.Width)
    //        {
    //            clientForm.Width = frm.MinimumSize.Width;
    //        }
    //        if (clientForm.Height < frm.MinimumSize.Height)
    //        {
    //            clientForm.Height = frm.MinimumSize.Height;
    //        }
    //        clientForm.FormClosed += new FormClosedEventHandler(onThemedForm_Close);  //If the clientForm closes, the themed dialog closes as well.
    //        frm.Show();  //Show the generated themed form with the clientForm as it's child control.
    //    }
    //    private void onThemedForm_Close(object sender, FormClosedEventArgs e)
    //    {
    //        //An event handler for closing the themed form to avoid leaving it running.
    //        try
    //        {
    //            //Gets the sender and checks if it is a mac themed form...
    //            System.Windows.Forms.Form frm = (System.Windows.Forms.Form)sender;
    //            CustomForm thm = (CustomForm)frm.ParentForm;
    //            thm.Close();  //closes the themed form.
    //        }
    //        catch
    //        {
    //            //Error message not displayed.
    //        }
    //    }
    //    public void ApplyFormThemeSingleSizable(System.Windows.Forms.Form clientForm)
    //    {
    //        //This thread makes the specified form to be a control of the created Mac themed form (Resizable, Thin Single Pixel borders, Corner resizing not available).
    //        CustomForm frm = new CustomForm();      //Creates a new Mac themed borderless form (generated by the mactheme class).
    //        frm.TopMost = clientForm.TopMost;    //Determines if the themed form should be in the TopMost level.
    //        frm.ShowInTaskbar = clientForm.ShowInTaskbar;  //Determines if the themed form should appear in the taskbar.
    //        frm.ShowIcon = clientForm.ShowIcon;   //Determines if the themed form should show its icon in the taskbar.

    //        //Checks if the user wants to disable some sizing buttons...
    //        if (clientForm.MaximizeBox == false)
    //        {
    //            frm.ControlBox = false;
    //            frm.cmdMaxRes.Visible = false;
    //            frm.MaximizeBox = false;
    //        }
    //        if (clientForm.MinimizeBox == false)
    //        {
    //            frm.cmdMaxRes.Left = frm.cmdMin.Left;
    //            frm.cmdMin.Visible = false;
    //            frm.MinimizeBox = false;
    //        }
    //        //////////////////////////////////////////////////////////

    //        clientForm.TopLevel = false;               //Sets the TopLevel property of the clientForm to false so that we can add it as a client control on our mac themed form.
    //        clientForm.FormBorderStyle = FormBorderStyle.None;   //Makes the clientForm borderless.
    //        frm.Width = clientForm.Width + 8;      //Adjusts the width of the Mac themed form.
    //        frm.Height = clientForm.Height + 28; //Adjusts the height of the Mac themed form.
    //        frm.leftpnl2.Width = 0;                            //Makes the thick resizable edge disappear.
    //        frm.rightpnl2.Width = 0;                         //Makes the thick resizable edge disappear.
    //        frm.bottompnl2.Height = 0;                   //Makes the thick resizalbe edge disappear.
    //        frm.bodypanel.Left = 1;                     //Sets the themed form's form container (bodypanel) near the gray edge.
    //        frm.Top = 0;                                     //Sets the default top location to 0.
    //        frm.Left = 0;                                     //Sets the default left location to 0.

    //        frm.StartPosition = clientForm.StartPosition;  //Sets the themed form's StartPosition same as the clientForm's StartPositon. If {0,0} location is used and it is needed to be applied, just set the clientForm's StartPosition to manual.
    //        if (clientForm.Top != 0)
    //        {
    //            frm.StartPosition = FormStartPosition.Manual;   //Sets the Form's Startup position to manual.
    //            frm.Top = clientForm.Top;                 //Sets the themed form's top the same as the clientForm's top position.
    //        }
    //        if (clientForm.Left != 0)
    //        {
    //            frm.StartPosition = FormStartPosition.Manual;   //Sets the Form's Startup position to manual.
    //            frm.Left = clientForm.Left;                  //Sets the themed form's left the same as the clientForm's Left position.
    //        }


    //        clientForm.Top = 0;                           //Sets the clientForm's top location to 0.
    //        clientForm.Left = 0;                           //Sets the clientForms' left location.
    //        clientForm.Width += 6;                     //Adds width to the clientForm to reach the right edge.
    //        clientForm.Height += 5;                     //Adds height to the clientform to reach the bottom edge.
    //        frm.bodypanel.Height += 2;              //Adds height to the clientForm container to reach the bottom edge.
    //        frm.Text = clientForm.Text;                         //Sets the mac themed form's Text property to the specified title (param = formTitle).
    //        clientForm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;    //Anchors the clientForm so it fits the themed form during resizing process.
    //        frm.titleCaption.Text = clientForm.Text;        //Sets the themed form's titleCaption Text property to the specified title (param = formTitle).
    //        frm.bodypanel.Controls.Add(clientForm); //Adds the clientForm to the bodypanel's Controls collection.
    //        frm.Icon = clientForm.Icon;                 //Sets the themed form's Icon property the same as the clientForm's Icon property.

    //        Size zeroSize = new Size(0, 0);            //The default minimum size of a form (0,0).
    //        if (clientForm.MinimumSize != zeroSize)   //If the minimum width and height of the clientForm is not on default (0,0)....
    //        {
    //            frm.MinimumSize = new Size(clientForm.MinimumSize.Width + 8, clientForm.MinimumSize.Height + 28);  //Sets the minimum size of the themed form.
    //        }
    //        if (clientForm.Width < frm.MinimumSize.Width)
    //        {
    //            clientForm.Width = frm.MinimumSize.Width;
    //        }
    //        if (clientForm.Height < frm.MinimumSize.Height)
    //        {
    //            clientForm.Height = frm.MinimumSize.Height;
    //        }
    //        clientForm.FormClosed += new FormClosedEventHandler(onThemedForm_Close);  //If the client form is closed, the themed form should also close as well.
    //        frm.Show();  //Show the generated themed form with the clientForm as it's child control.

    //    }
    //}


    //[ToolboxItem(false)]
    //public class panelmod : Panel
    //{
    //    public panelmod()
    //    {
    //        //sets the DoubleBuffered property of the panel to true.
    //        //this.DoubleBuffered = true;
    //    }
    //}
}
