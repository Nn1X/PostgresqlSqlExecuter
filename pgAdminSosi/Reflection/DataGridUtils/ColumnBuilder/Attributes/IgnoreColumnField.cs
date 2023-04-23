using System;

namespace pgAdminSosi.Helpers.DataGridUtils.ColumnBuilder.Attributes
{
    [System.AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false)]
    sealed class IgnoreColumnFieldAttribute : Attribute { }

}
