using DevExpress.Blazor;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace pgAdminSosi.Helpers.DataGridUtils.ColumnBuilder.Strategies
{
    /// <summary>
    /// Интерфейс, описывающий стратегию генерации колонок в DxDataGrid
    /// </summary>
    public interface IGenetationStrategy
    {
        public RenderTreeBuilder Builder { set; }
        public void Do(string property, int num);
        //public void AddColumn(RenderTreeBuilder builder, int num, string name, Type columnType);
    }

    public class GenerationStrategy : IGenetationStrategy
    {
        public RenderTreeBuilder Builder { get; set; }

        public virtual void Do(string property, int num) { }
    }
}
