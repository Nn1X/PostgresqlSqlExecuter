using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pgAdminSosi.Helpers.DataGridUtils.ColumnBuilder.Attributes
{
    /// <summary>
    /// Атрибут модели, указывающий на то, какое название будет присвоено сгенерированной колонке
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    sealed class ColumnCaptionAttribute : Attribute
    {
        readonly string caption;

        public ColumnCaptionAttribute(string columnCaption)
        {
            caption = columnCaption;

        }

        public string Caption
        {
            get { return caption; }
        }
    }
}
