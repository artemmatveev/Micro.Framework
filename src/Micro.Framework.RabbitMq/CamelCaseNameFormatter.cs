namespace Micro.Framework.RabbitMq
{    
    public class CamelCaseNameFormatter : IEntityNameFormatter
    {
        static CamelCaseNameFormatter _instance;        
        readonly IEntityNameFormatter _original;

        private CamelCaseNameFormatter() { }
        public CamelCaseNameFormatter(IEntityNameFormatter original)
        {
            _original = original;
        }

        public static CamelCaseNameFormatter Instance => _instance ?? (_instance = new CamelCaseNameFormatter());

        public string FormatEntityName<T>()
        {
            if (_original != null)
                return _original.FormatEntityName<T>();

            var type = typeof(T);
            var namespaceCamelCaseParts = type.Namespace.Split('.').Select(x => char.ToLowerInvariant(x[0]) + x.Substring(1));
            var entityCamelCase = char.ToLowerInvariant(type.Name[0]) + type.Name.Substring(1);

            return $"{string.Join('.', namespaceCamelCaseParts)}:{entityCamelCase}";
        }
    } 
}
