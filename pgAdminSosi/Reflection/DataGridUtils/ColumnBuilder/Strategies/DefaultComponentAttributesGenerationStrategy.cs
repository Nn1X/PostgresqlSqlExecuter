using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace pgAdminSosi.Helpers.DataGridUtils.ColumnBuilder.Strategies
{
    /// <summary>
    /// Назначает компоненту поле для биндинга данных и размер по-умолчанию (200px)
    /// </summary>
    public class DefaultComponentAttributesGenerationStrategy : GenerationStrategy
    {
        public override void Do(string property, int num)
        {
            var width = property.ToLower() == "id" ? "50px" : "200px";

            Builder.AddAttribute(num, "Field", property);
            Builder.AddAttribute(num, "Width", width);
        }
    }
}
