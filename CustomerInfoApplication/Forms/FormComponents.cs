namespace CustomerInfoApplication.Forms
{
    public class FormComponents
    {
        CustomerInformationForm CustomerForm;

        public FormComponents(CustomerInformationForm customerInformationForm)
        {
            CustomerForm = customerInformationForm;
        }

        public void ChangeVisibility(bool enableTextName, bool enableContactPersonName, bool enablePhone, bool enableBtnaddNewRecord,
            bool enableBtn2, bool enableBtnInsert, bool enableBtnUpdate, bool enableReset)
        {
            CustomerForm.txtBoxName.Enabled = enableTextName;
            CustomerForm.contactPersonName.Enabled = enableContactPersonName;
            CustomerForm.phone.Enabled = enablePhone;
            CustomerForm.btn_addNewRecord.Visible = enableBtnaddNewRecord;
            CustomerForm.button2.Visible = enableBtn2;
            CustomerForm.btnInsert.Visible = enableBtnInsert;
            CustomerForm.btnUpdate.Visible = enableBtnUpdate;
            CustomerForm.btnReset.Visible = enableReset;
        }
    }
}
