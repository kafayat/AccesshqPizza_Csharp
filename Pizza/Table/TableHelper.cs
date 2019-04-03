using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Table
{
    public class TableHelper
    {
        private IWebElement _element;
        public TableHelper(IWebElement element)
        {
            this._element = element;
        }

        By TableHeaderRow = By.CssSelector("thead th");
        By TableDataRow = By.CssSelector("tbody tr");
        By TableCell = By.TagName("td");

        public int GetColumnIndex(string columnName)
        {
            IList<IWebElement> tableHeaders = _element.FindElements(TableHeaderRow);
            for (int i = 0; i < tableHeaders.Count; i++) {
                if (tableHeaders[i].Text.Equals(columnName)) {
                    return i;
                }
            }
            throw new Exception(" No column titled " + columnName + " found");
        }

        public List<IWebElement> GetItemRowCells(string searchTerm, string fromColumn)
        {
            int findColumnIndex = GetColumnIndex(fromColumn);
            IList<IWebElement> tableRows = _element.FindElements(TableDataRow);
            foreach (IWebElement row in tableRows) {
                IList<IWebElement> tableCells = row.FindElements(TableCell);
                if (tableCells[findColumnIndex].Text.Equals(searchTerm))
                {
                    return tableCells.ToList();
                }
            }
            throw new Exception("No cell data found");
        }
    }
}
