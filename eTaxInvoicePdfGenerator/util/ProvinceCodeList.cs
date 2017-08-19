using eTaxInvoicePdfGenerator.Dao;
using ETDA.Invoice.Api.Entities;
using System.Collections.Generic;
using System.Windows.Controls;

namespace eTaxInvoicePdfGenerator.util
{
    internal class ProvinceCodeList
    {
        internal void SetAmphoe(ComboBox comboBox, string code)
        {
            List<AddressCodeListObj> list = new AddressCodeListDao().AmphoeList(code);
            comboBox.DisplayMemberPath = "amphoe_th";
            comboBox.SelectedValuePath = "code";
            comboBox.ItemsSource = list;
            comboBox.SelectedIndex = 0;
        }

        internal void SetChangwat(ComboBox comboBox)
        {
            List<AddressCodeListObj> list = new AddressCodeListDao().ProvinceList();
            comboBox.DisplayMemberPath = "changwat_th";
            comboBox.SelectedValuePath = "code";
            comboBox.ItemsSource = list;
            comboBox.SelectedIndex = 0;
        }
        internal void SetTambon(ComboBox comboBox, string code)
        {
            List<AddressCodeListObj> list = new AddressCodeListDao().TambonList(code);
            comboBox.DisplayMemberPath = "tambon_th";
            comboBox.SelectedValuePath = "code";
            comboBox.ItemsSource = list;
            comboBox.SelectedIndex = 0;
        }
    }
}