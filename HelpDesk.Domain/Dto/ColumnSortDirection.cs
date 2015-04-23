using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Dto
{
    /// <summary>
    /// A sort direction for columns in a list view
    /// </summary>
    public enum ColumnSortDirection
    {
        /// <summary>
        /// column values should be sorted in ascending order
        /// </summary>
        Ascending,
        /// <summary>
        /// column values should be sorted in descending order
        /// </summary>
        Descending
    }
}
