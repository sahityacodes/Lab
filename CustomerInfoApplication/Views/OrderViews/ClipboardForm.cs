using System.Windows.Forms;

namespace CustomerInfoApplication.Views.OrderViews
{
    public partial class ClipboardForm : DevExpress.XtraEditors.XtraForm
    {
        public ClipboardForm()
        {
            InitializeComponent();
        }

        private void pasteButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SendKeys.Send("^{v}");
        }

        public string getPastedData()
        {
            return clipText.Text;
        }
    }
}