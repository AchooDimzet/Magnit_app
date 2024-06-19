using mshtml;
using Magnit_app.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Magnit_app.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReportSalesWindow.xaml
    /// </summary>
    public partial class ReportSalesWindow : Window
    {
        public ReportSalesWindow()
        {
            InitializeComponent();
            var productSales = AppData.Context.ProductSales.ToList();
            var productItems = AppData.Context.Product_items.ToList();
            var result = new StringBuilder();

            result.Append("<html>");
            result.Append("<meta charset='utf-8'/>");
            result.Append("<body>");
            result.Append("<p align='center'> <b>Отчёт по продажам</b> </p>");
            result.Append("<table width=100% border=1 bordercolor=#000 style='border-collapse:collapse;'>");
            result.Append("<tr>");
            
            result.Append("</tr>");

            foreach (var item in productSales)
            {
                result.Append("<tr>");
                result.Append("<td align=center><b>Номер продажи</b></td>");
                result.Append("<td align=center><b>Работник</b></td>");
                result.Append("</tr>");
                result.Append("<tr>");
                result.Append($"<td align=center>{item.Id_sale}</td>");
                result.Append($"<td align=center>{item.Sales.Workers.FullName}</td>");
                result.Append("</tr>");
                result.Append("<td align=center><b>Название продукта</b></td>");
                result.Append("<td align=center><b>Цена</b></td>");
                result.Append("<td align=center><b>Количество</b></td>");
                foreach (var items in productItems.Where(p => p.Article_number == item.Id_product)) 
                {
                    result.Append("<tr>");
                    result.Append($"<td align=center>{items.Name}</td>");
                    result.Append($"<td align=center>{items.Price}</td>");
                    result.Append($"<td align=center>{item.Count}</td>");
                    result.Append("</tr>");
                }
                result.Append("</tr>");

            }
            result.Append("</table>");
            result.Append("</body>");
            result.Append("</html>");
            WebPrint.NavigateToString(result.ToString());
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var document = WebPrint.Document as IHTMLDocument2;
            document.execCommand("Print");
        }
    }
}
