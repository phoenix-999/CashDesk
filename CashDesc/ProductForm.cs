using DataLib.Models;
using LanguageLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashDesc
{
    public partial class ProductForm : Form
    {
        public ProductForm(DataRow productRow, List<ProductType> productTypes)
        {
            InitializeComponent();
            this.Text = Config.Language[StrResourceKeys.Product] + " " + productRow["Productname"];
            _product = productRow;
            InitControls();
        }

        BusinessLogic businessLogic = new BusinessLogic();
        DataRow _product;
        public bool RowAdded { get; private set; } = false;

        void InitControls()
        {
            lbProductName.Text = Config.Language[StrResourceKeys.ProductName];
            lbProductType.Text = Config.Language[StrResourceKeys.ProductType];
            lbPrice.Text = Config.Language[StrResourceKeys.Price];
            lbDescription.Text = Config.Language[StrResourceKeys.Description];
            btnApply.Text = Config.Language[StrResourceKeys.Apply];
            btnApply.DialogResult = DialogResult.OK;
            btnCancel.Text = Config.Language[StrResourceKeys.Cancel];

            tbProductName.Text = _product["ProductName"] as string;
            MainForm.InitProductTypeList(cbProductType, _product["TypeId"] as int?);
            decimal price;
            bool parseResult = decimal.TryParse(_product["Price"].ToString(), out price);
            nudPrice.Value = price;
            tbDescription.Text = _product["Description"] as string;

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            _product["ProductName"] = string.IsNullOrEmpty(tbProductName.Text) ? null : tbProductName.Text;//Если null - ошибка обработки данных. Поле не должно быть null. Иначе улетит пустая строка.
            _product["Price"] = nudPrice.Value;
            _product["Description"] = tbDescription.Text;
            ProductType type = cbProductType.SelectedItem as ProductType;
            if(type != null)
            {
                _product["TypeId"] = type.Id;
                _product["TypeName"] = type.TypeName;
            }
            RowAdded = true;
        }
    }
}
