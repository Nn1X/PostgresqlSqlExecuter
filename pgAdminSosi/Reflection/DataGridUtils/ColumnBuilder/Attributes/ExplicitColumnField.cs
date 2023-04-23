using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pgAdminSosi.Helpers.DataGridUtils.ColumnBuilder.Attributes
{
    /// <summary>
    /// Атрибут модели, явно указывающий поле для параметра Field
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    sealed class ExplicitColumnFieldAttribute : Attribute
    {
        readonly string field;

        public ExplicitColumnFieldAttribute(string columnField)
        {
            field = columnField;

        }

        public string Field
        {
            get { return field; }
        }
    }
}
