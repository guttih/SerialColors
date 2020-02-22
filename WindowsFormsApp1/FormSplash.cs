using System.Windows.Forms;
namespace SerialColors
{
    public partial class FormSplash : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public string Heading
        {
            get { return labelHeading.Text; }
            set { labelHeading.Text = value; }
        }

        public string Message
        {
            get { return labelMessage.Text; }
            set { labelMessage.Text = value;
            }
        }
        private void InitForm(string Message)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
            Heading = "";
            this.Message = Message;
        }
        public FormSplash(string Message)
        {
            InitForm(Message);
        }

        public FormSplash(string Heading, string Message)
        {
            InitForm(Message);
            this.Heading = Heading;
        }

        public void Set(string Heading, string Message)
        {
            this.Heading = Heading;
            this.Message = Message;
            Application.DoEvents();
        }
    }
}
