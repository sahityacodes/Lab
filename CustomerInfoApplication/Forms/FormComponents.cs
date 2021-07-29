namespace CustomerInfoApplication.Forms
{
    class FormComponents
    {
        internal void ChangeVisibility(CustomerInformationForm customerForm, bool enableTextName, bool enableContactPersonName, bool enablePhone, bool enableBtnaddNewRecord,
            bool enableBtn2, bool enableBtnInsert, bool enableBtnUpdate, bool enableReset)
        {
            customerForm.txtBoxName.Enabled = enableTextName;
            customerForm.contactPersonName.Enabled = enableContactPersonName;
            customerForm.phone.Enabled = enablePhone;
            customerForm.btn_addNewRecord.Visible = enableBtnaddNewRecord;
            customerForm.button2.Visible = enableBtn2;
            customerForm.btnInsert.Visible = enableBtnInsert;
            customerForm.btnUpdate.Visible = enableBtnUpdate;
            customerForm.btnReset.Visible = enableReset;
        }

    }
}
