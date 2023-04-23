using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pgAdminSosi.Helpers.DataGridUtils.ColumnBuilder.Attributes
{
    /// <summary>
    /// Атрибут модели, указывающий на то, какой индекс группы будет присвоен сгенерированной колонке
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Field, Inherited = false)]
    sealed class ColumnGroupIndexAttribute : Attribute
    {
        readonly int groupIndex;

        public ColumnGroupIndexAttribute(int index)
        {
            groupIndex = index;
        }

        public int GroupIndex
        {
            get { return groupIndex; }
        }
    }
}
